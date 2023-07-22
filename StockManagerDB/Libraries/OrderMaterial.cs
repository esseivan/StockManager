using System.Text.Json.Serialization;

namespace StockManagerDB
{
    /// <summary>
    /// Define a material inside a BOM (Bill Of Materials)
    /// </summary>
    public class OrderMaterial
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
    }
}
