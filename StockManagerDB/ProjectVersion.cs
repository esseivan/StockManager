using System;
using System.Collections.Generic;

namespace StockManagerDB
{
    /// <summary>
    /// Define a version of a project
    /// </summary>
    public class ProjectVersion
    {
        /// <summary>
        /// Name of the project that have this version
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// Version. Unique amongst the versions of a project
        /// </summary>
        public Version Version { get; set; }
        /// <summary>
        /// List of material
        /// </summary>
        public SortedDictionary<string, Material> BOM { get; set; } = new SortedDictionary<string, Material>();

        public override string ToString()
        {
            return $"Project '{Project}' - {Version} : {BOM.Count} materials";
        }
    }
}
