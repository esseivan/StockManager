using System.Collections.Generic;

namespace StockManagerDB
{
    /// <summary>
    /// Define a project
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Name of the project. Unique amongst the projects
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// List of version identified by their unique VersionStr
        /// </summary>
        public Dictionary<string, ProjectVersion> Versions { get; set; } = new Dictionary<string, ProjectVersion>();
    }
}
