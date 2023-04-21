using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
                case "man":
                    return Parameter.Manufacturer;
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
    }
}
