namespace StockManagerDB
{
    /// <summary>
    /// Define a material inside a BOM (Bill Of Materials)
    /// </summary>
    public class Material
    {
        /// <summary>
        /// The MPN of the part. Unique amongst a version
        /// </summary>
        public string MPN { get; set; }
        /// <summary>
        /// The quantity for this part
        /// </summary>
        public float Quantity { get; set; }
        /// <summary>
        /// The reference for this part, if any
        /// </summary>
        public string Reference { get; set; }
    }
}
