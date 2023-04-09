using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB
{
    public class ComponentClass : ICloneable
    {
        /// <summary>
        /// Parent project name
        /// </summary>
        public string Parent
        {
            get => Parameters.TryGetValue(Parameter.Parent, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Parent] = value;
        }
        /// <summary>
        /// Manufacturer Product Number. Not unique in this case
        /// </summary>
        public string MPN
        {
            get => Parameters.TryGetValue(Parameter.MPN, out string value) ? value : string.Empty;
            set => Parameters[Parameter.MPN] = value;
        }
        /// <summary>
        /// Quantity of this component used
        /// </summary>
        public float Quantity
        {
            get => float.TryParse(QuantityStr, out float valuefloat) ? valuefloat : 0;
            set => Parameters[Parameter.Quantity] = value.ToString();
        }
        public string QuantityStr
        {
            get => Parameters.TryGetValue(Parameter.Quantity, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Quantity] = value;
        }
        /// <summary>
        /// Reference in the schematic
        /// </summary>
        public string Reference
        {
            get => Parameters.TryGetValue(Parameter.Reference, out string value) ? value : string.Empty;
            set => Parameters[Parameter.Reference] = value;
        }

        /// <summary>
        /// Link to the corresponding part
        /// </summary>
        public PartClass PartLink
        {
            get
            {
                if (DBWrapper.Parts.ContainsKey(MPN))
                {
                    return DBWrapper.Parts[MPN];
                }
                else
                {
                    return null;
                }
            }
        }

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
            Parent,
            MPN,
            Quantity,
            Reference,
        }

        /// <summary>
        /// Make a link between database column index and PartClass parameter
        /// </summary>
        public static Dictionary<int, Parameter> DatabaseLink = new Dictionary<int, Parameter>()
        {
            {0, Parameter.Parent    },
            {1, Parameter.MPN       },
            {2, Parameter.Quantity  },
            {3, Parameter.Reference },
        };

        /// <summary>
        /// Make a link between a parameter and the database column name
        /// </summary>
        public static Dictionary<Parameter, string> DatabaseLinkStr = new Dictionary<Parameter, string>()
        {
            { Parameter.Parent      , "parent"      },
            { Parameter.MPN         , "mpn"         },
            { Parameter.Quantity    , "quantity"    },
            { Parameter.Reference   , "reference"   },
        };


        /// <summary>
        /// Create a PartClass List from a DataTable table imported from a sql database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<ComponentClass> CreateFromDB(DataTable table)
        {
            int nCol = table.Columns.Count;
            List<ComponentClass> components = new List<ComponentClass>();

            foreach (DataRow row in table.Rows)
            {
                ComponentClass component = new ComponentClass();
                // skip first value (id)
                for (int i = 0; i < nCol; i++)
                {
                    component.Parameters[DatabaseLink[i]] = row[i].ToString();
                }
                components.Add(component);
            }

            return components;
        }

        public object Clone()
        {
            ComponentClass newPart = new ComponentClass();

            foreach (KeyValuePair<Parameter, string> item in this.Parameters)
            {
                newPart.Parameters.Add(item.Key, item.Value);
            }

            return newPart;
        }
    }
}
