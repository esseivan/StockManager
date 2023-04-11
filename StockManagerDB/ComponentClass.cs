using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockManagerDB
{
    public class ComponentClass : ICloneable
    {
        /// <summary>
        /// Count the IDs, the number of created components
        /// </summary>
        private static int ID_Counter = 1;

        public static ListManager ListManagerPointer = null;

        /// <summary>
        /// ID of the component
        /// </summary>
        [JsonIgnore]
        public int ID
        {
            get => int.TryParse(IDStr, out int valueInt) ? valueInt : 0;
            set
            {
                Parameters[Parameter.ID] = value.ToString();
                // If ID > ID_Counter, save that as the ID_Counter
                if (value > ID_Counter)
                    ID_Counter = value;
            }
        }
        public string IDStr
        {
            get => Parameters.TryGetValue(Parameter.ID, out string value) ? value : string.Empty;
            set => Parameters[Parameter.ID] = value;
        }

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
        [JsonIgnore]
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
        [JsonIgnore]
        public PartClass PartLink
        {
            get
            {
                if (ListManagerPointer == null)
                    return null;

                var list = ListManagerPointer.Data.Parts.Where((part) => part.MPN.Equals(MPN));
                if (list.Count() > 0)
                    return list.First();
                return null;
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
            ID,
            Parent,
            MPN,
            Quantity,
            Reference,
        }

        /// <summary>
        /// Create a new component
        /// </summary>
        public ComponentClass()
        {
            this.ID = ID_Counter++;
        }

        public object Clone()
        {
            ComponentClass newPart = new ComponentClass();

            foreach (KeyValuePair<Parameter, string> item in this.Parameters)
            {
                // Do not clone ID
                if (item.Key == Parameter.ID || item.Key == Parameter.UNDEFINED)
                    continue;

                newPart.Parameters.Add(item.Key, item.Value);
            }

            return newPart;
        }
    }
}
