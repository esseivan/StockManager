using System;
using System.Text.Json.Serialization;

namespace StockManagerDB
{
    /// <summary>
    /// Define a material inside a BOM (Bill Of Materials)
    /// </summary>
    public class Material : ICloneable
    {
        /// <summary>
        /// The MPN of the part. Unique amongst a version
        /// </summary>
        public string MPN { get; set; }

        /// <summary>
        /// The quantity for this part
        /// </summary>
        [JsonIgnore]
        public float Quantity
        {
            get => float.TryParse(QuantityStr, out float value) ? value : 0;
            set => QuantityStr = value.ToString();
        }

        /// <summary>
        /// The quantity for this part
        /// </summary>
        public string QuantityStr { get; set; }

        /// <summary>
        /// The reference for this part, if any
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Link to the corresponding part
        /// </summary>
        [JsonIgnore]
        public Part PartLink
        {
            get
            {
                if (DataHolderSingleton.Instance == null)
                {
                    return null;
                }

                if (!DataHolderSingleton.Instance.Parts.ContainsKey(MPN))
                {
                    return null;
                }

                return DataHolderSingleton.Instance.Parts[MPN];
            }
        }

        public object Clone()
        {
            Material newMaterial = new Material()
            {
                MPN = MPN,
                Quantity = Quantity,
                Reference = Reference
            };

            return newMaterial;
        }
    }
}
