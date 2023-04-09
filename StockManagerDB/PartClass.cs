using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace StockManagerDB
{
    /// <summary>
    /// Define a single part.
    /// </summary>
    public class PartClass : ICloneable
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
            get => Parameters.TryGetValue(Parameter.Manufacturer, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Manufacturer] = value;
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get => Parameters.TryGetValue(Parameter.Description, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Description] = value;
        }
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get => Parameters.TryGetValue(Parameter.Category, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Category] = value;
        }
        /// <summary>
        /// Part location
        /// </summary>
        public string Location
        {
            get => Parameters.TryGetValue(Parameter.Location, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Location] = value;
        }
        /// <summary>
        /// Actual stock
        /// </summary>
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
        public float LowStock
        {
            get => float.TryParse(LowStockStr, out float valuefloat) ? valuefloat : 0;
            set => Parameters[Parameter.LowStock] = value.ToString();
        }
        public string LowStockStr
        {
            get => Parameters.TryGetValue(Parameter.LowStock, out string value) ? value : string.Empty;
            set => Parameters[Parameter.LowStock] = value;
        }
        /// <summary>
        /// Average unit price
        /// </summary>
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
            get => Parameters.TryGetValue(Parameter.Supplier, out string value) ? value : string.Empty;
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
        /// Index in the list
        /// </summary>
        public int ShowIndex = 0;

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

        /// <summary>
        /// Make a link between database column index and PartClass parameter
        /// </summary>
        public static Dictionary<int, Parameter> DatabaseLink = new Dictionary<int, Parameter>()
        {
            {0, Parameter.MPN         },
            {1, Parameter.Manufacturer},
            {2, Parameter.Description },
            {3, Parameter.Category    },
            {4, Parameter.Location     },
            {5, Parameter.Stock       },
            {6, Parameter.LowStock    },
            {7, Parameter.Price       },
            {8, Parameter.Supplier    },
            {9, Parameter.SPN         },
        };

        /// <summary>
        /// Make a link between a parameter and the database column name
        /// </summary>
        public static Dictionary<Parameter, string> DatabaseLinkStr = new Dictionary<Parameter, string>()
        {
            { Parameter.MPN          , "mpn"          },
            { Parameter.Manufacturer , "manufacturer" },
            { Parameter.Description  , "description"  },
            { Parameter.Category     , "category"     },
            { Parameter.Location     , "storage"      },
            { Parameter.Stock        , "stock"        },
            { Parameter.LowStock     , "low_stock"    },
            { Parameter.Price        , "price"        },
            { Parameter.Supplier     , "supplier"     },
            { Parameter.SPN          , "spn"          },
        };

        /// <summary>
        /// Create a PartClass List from a DataTable table imported from a sql database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<PartClass> CreateFromDB(DataTable table)
        {
            int nCol = table.Columns.Count;
            List<PartClass> parts = new List<PartClass>();

            foreach (DataRow row in table.Rows)
            {
                PartClass part = new PartClass();
                // skip first value (id)
                for (int i = 0; i < nCol; i++)
                {
                    part.Parameters[DatabaseLink[i]] = row[i].ToString();
                }
                parts.Add(part);
            }

            return parts;
        }

        /// <summary>
        /// Create a PartClass variable from a DataRow imported from a sql database
        /// </summary>
        /// <param name="row"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        public static PartClass CreateFromDB(DataRow row, int nCol)
        {
            PartClass part = new PartClass();

            // skip first value (id)
            for (int i = 0; i < nCol; i++)
            {
                part.Parameters[DatabaseLink[i]] = row[i].ToString();
            }

            return part;
        }

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

        /// <summary>
        /// Class to compare the price of two PartClasses
        /// </summary>
        public class ComparePrice : IComparer<PartClass>
        {
            public int Compare(PartClass x, PartClass y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }

        public override string ToString()
        {
            return $"MPN:{MPN}; Stock:{Stock}; Location:{Location}";
        }

        public object Clone()
        {
            PartClass newPart = new PartClass();

            foreach (KeyValuePair<Parameter, string> item in this.Parameters)
            {
                newPart.Parameters.Add(item.Key, item.Value);
            }

            return newPart;
        }
    }
}
