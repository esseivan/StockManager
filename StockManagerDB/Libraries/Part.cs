using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace StockManagerDB
{
    /// <summary>
    /// Define a part
    /// </summary>
    public class Part : ICloneable
    {
        /// <summary>
        /// Manufacturer Product Number. Unique and is used as identifier
        /// </summary>
        public string MPN
        {
            get => Parameters.TryGetValue(Parameter.MPN, out string value) ? value : string.Empty;
            set => Parameters[Parameter.MPN] = value;
        }

        /// <summary>
        /// Manufacturer
        /// </summary>
        public string Manufacturer
        {
            get =>
                Parameters.TryGetValue(Parameter.Manufacturer, out string value)
                    ? value
                    : string.Empty;
            set => Parameters[Parameter.Manufacturer] = value;
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get =>
                Parameters.TryGetValue(Parameter.Description, out string value)
                    ? value
                    : string.Empty;
            set => Parameters[Parameter.Description] = value;
        }

        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get =>
                Parameters.TryGetValue(Parameter.Category, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Category] = value;
        }

        /// <summary>
        /// Part location
        /// </summary>
        public string Location
        {
            get =>
                Parameters.TryGetValue(Parameter.Location, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Location] = value;
        }

        /// <summary>
        /// Actual stock
        /// </summary>
        [JsonIgnore]
        public float Stock
        {
            get => float.TryParse(StockStr, out float valuefloat) ? valuefloat : 0;
            set => Parameters[Parameter.Stock] = value.ToString();
        }
        public string StockStr
        {
            get => Parameters.TryGetValue(Parameter.Stock, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Stock] = value;
        }

        /// <summary>
        /// Low stock threshold
        /// </summary>
        [JsonIgnore]
        public float LowStock
        {
            get => float.TryParse(LowStockStr, out float valuefloat) ? valuefloat : 0;
            set => Parameters[Parameter.LowStock] = value.ToString();
        }
        public string LowStockStr
        {
            get =>
                Parameters.TryGetValue(Parameter.LowStock, out string value) ? value : string.Empty;
            set => Parameters[Parameter.LowStock] = value;
        }

        /// <summary>
        /// Average unit price
        /// </summary>
        [JsonIgnore]
        public float Price
        {
            get => float.TryParse(PriceStr, out float valuefloat) ? valuefloat : 0;
            set => Parameters[Parameter.Price] = value.ToString();
        }
        public string PriceStr
        {
            get => Parameters.TryGetValue(Parameter.Price, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Price] = value;
        }

        /// <summary>
        /// Supplier
        /// </summary>
        public string Supplier
        {
            get =>
                Parameters.TryGetValue(Parameter.Supplier, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Supplier] = value;
        }

        /// <summary>
        /// Supplier Product Number
        /// </summary>
        public string SPN
        {
            get => Parameters.TryGetValue(Parameter.SPN, out string value) ? value : string.Empty;
            set => Parameters[Parameter.SPN] = value;
        }

        /// <summary>
        /// CSV of substitutes parts
        /// </summary>
        public string Substitutes
        {
            get =>
                Parameters.TryGetValue(Parameter.Substitute, out string value)
                    ? value
                    : string.Empty;
            set => Parameters[Parameter.Substitute] = value;
        }

        /// <summary>
        /// Obsolete part. Cannot be automatically ordered
        /// </summary>
        [JsonIgnore]
        public bool Obsolete
        {
            get => bool.TryParse(ObsoleteStr, out bool valueBool) ? valueBool : false;
            set => Parameters[Parameter.Obsolete] = value.ToString();
        }
        public string ObsoleteStr
        {
            get =>
                Parameters.TryGetValue(Parameter.Obsolete, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Obsolete] = value;
        }

        /// <summary>
        /// This part version is valid from this date
        /// </summary>
        [JsonInclude]
        public DateTime ValidFrom;

        /// <summary>
        /// This part version is valid until this date
        /// </summary>
        [JsonInclude]
        public DateTime ValidUntil;

        /// <summary>
        /// The status of the part
        /// </summary>
        [JsonInclude]
        public string Status;

        /// <summary>
        /// The version of this part
        /// </summary>
        [JsonInclude]
        public int Version;

        /// <summary>
        /// Note on this version
        /// </summary>
        [JsonInclude]
        public string note = "";

        /// <summary>
        /// List of parameters
        /// </summary>
        public Dictionary<Parameter, string> Parameters = new Dictionary<Parameter, string>();

        /// <summary>
        /// List of possible parameters
        /// </summary>
        public enum Parameter
        {
            UNDEFINED,
            MPN,
            Manufacturer,
            Description,
            Category,
            Location,
            Stock,
            LowStock,
            Price,
            Supplier,
            SPN,
            Substitute,
            Obsolete,
        }

        public Part() { }

        /// <summary>
        /// Convert string header to parameter type. Used to import from excel, where the value is the header name
        /// </summary>
        /// <param name="value">The string to be converted</param>
        /// <returns>The Paramter type equivalent of the value</returns>
        public static Parameter GetParameter(string value)
        {
            if (Enum.TryParse(value, true, out Parameter output))
                return output;

            switch (value.ToLowerInvariant())
            {
                case "art. number":
                    return Parameter.MPN;
                case "place":
                    return Parameter.Location;
                case "man":
                    return Parameter.Manufacturer;
                case "in stock":
                    return Parameter.Stock;
                case "min in stock":
                    return Parameter.LowStock;
                case "default art. number":
                    return Parameter.SPN;
                case "default retailer":
                    return Parameter.Supplier;
                case "default unit price":
                    return Parameter.Price;
                case "desc":
                    return Parameter.Description;
                case "category":
                    return Parameter.Category;
                case "threshold":
                    return Parameter.LowStock;
                default:
                    return Parameter.UNDEFINED;
            }
        }

        public override string ToString()
        {
            return $"MPN:{MPN}; Stock:{Stock}; Location:{Location}";
        }

        public string ToLongString()
        {
            return $"MPN:{MPN}; Desc:{Description}; Man:{Manufacturer}; SPN:{SPN}; Price:{PriceStr}";
        }

        /// <summary>
        /// Clone the part to be stored in the History
        /// </summary>
        /// <returns>Part with cloned validFrom, validUntil, version, status</returns>
        public Part CloneForHistory()
        {
            Part oldPart = Clone() as Part;

            oldPart.ValidFrom = ValidFrom;
            oldPart.ValidUntil = ValidUntil;
            oldPart.Version = Version;
            oldPart.Status = Status;

            return oldPart;
        }

        public object Clone()
        {
            Part newPart = new Part();

            foreach (KeyValuePair<Parameter, string> item in this.Parameters)
            {
                newPart.Parameters.Add(item.Key, item.Value);
            }

            return newPart;
        }

        /// <summary>
        /// List of URL format for link to their parts. the supplier MUST be in lowercase
        /// </summary>
        Dictionary<string, string> suppliersUrl = new Dictionary<string, string>()
        {
            { "digikey", @"https://www.digikey.ch/products/en?keywords={0}" },
            { "farnell", @"https://ch.farnell.com/fr-CH/{0}" },
            { "distrelec", @"https://www.distrelec.ch/search?q={0}" },
            { "conrad", @"https://www.conrad.ch/fr/p/{0}" },
            { "mouser", @"https://www.mouser.ch/ProductDetail/{0}" },
            { "bauhaus", @"https://www.bauhaus.ch/fr/search?query={0}" },
            { "bricoetloisirs", @"https://bricoetloisirs.ch/p/{0}" },
            { "aliexpress", @"https://www.aliexpress.com/item/{0}" },
            { "banggood", @"https://www.banggood.com/search/{0}" },
            { "jumbo", @"https://www.jumbo.ch/fr/p/{0}" },
        };

        /// <summary>
        /// Open a webpage for the part from the supplier
        /// </summary>
        public void OpenSupplierUrl()
        {
            string supplier = Supplier.ToLower();
            if (suppliersUrl.ContainsKey(supplier))
            {
                string url = string.Format(suppliersUrl[supplier], SPN);
                LoggerClass.Write($"Openning URL \"{url}\"");
                Process.Start(url);
            }
        }

        /// <summary>
        /// Copy the MPN to the clipboard
        /// </summary>
        public void CopyMPNToClipboard()
        {
            Clipboard.SetText(MPN);
        }

        /// <summary>
        /// Copy the SPN to the clipboard
        /// </summary>
        public void CopySPNToClipboard()
        {
            if (string.IsNullOrEmpty(SPN))
            {
                return;
            }

            Clipboard.SetText(SPN);
        }

        /// <summary>
        /// Class to compare the price of two Parts
        /// </summary>
        public class ComparePrice : IComparer<Part>
        {
            public int Compare(Part x, Part y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }

        public class CompareMPN : IComparer<Part>
        {
            public int Compare(Part x, Part y)
            {
                return x.MPN.CompareTo(y.MPN);
            }
        }

        public class CompareMPNThenVersion : Comparer<Part>
        {
            public override int Compare(Part x, Part y)
            {
                if (x.MPN.Equals(y.MPN))
                {
                    // Same MPN, sort by version High -> Low
                    return y.Version.CompareTo(x.Version);
                }
                else
                {
                    // Different MPN, sort by MPN A-Z
                    return x.MPN.CompareTo(y.MPN);
                }
            }
        }

        /// <summary>
        /// Compare valid until date from most recent to least recent
        /// </summary>
        public class CompareValidUntil : Comparer<Part>
        {
            public override int Compare(Part x, Part y)
            {
                return y.ValidUntil.CompareTo(x.ValidUntil);
            }
        }
    }
}
