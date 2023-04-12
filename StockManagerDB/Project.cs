using System;
using System.Collections.Generic;
using System.Linq;

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
        public SortedDictionary<Version, ProjectVersion> Versions { get; set; } = new SortedDictionary<Version, ProjectVersion>();

        public class CompareName : IComparer<Project>
        {
            public int Compare(Project x, Project y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }
}
