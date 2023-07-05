using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StockManagerDB
{
    /// <summary>
    /// Define a version of a project
    /// </summary>
    public class ProjectVersion : ICloneable
    {
        /// <summary>
        /// Name of the project that have this version
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Version. Unique amongst the versions of a project
        /// </summary>
        public string Version
        {
            get => _version;
            set
            {
                if (System.Version.TryParse(value, out _))
                {
                    _version = value;
                }
                else
                {
                    LoggerClass.Write($"Invalid version : '{value}'");
                    _version = new Version(1, 0, 0).ToString();
                }
            }
        }

        [JsonIgnore]
        private string _version;

        /// <summary>
        /// List of material
        /// </summary>
        public List<Material> BOM { get; set; } = new List<Material>();

        public object Clone()
        {
            ProjectVersion newVersion = new ProjectVersion()
            {
                Project = Project,
                Version = Version,
            };

            foreach (Material material in BOM)
            {
                newVersion.BOM.Add(material.Clone() as Material);
            }

            return newVersion;
        }

        public override string ToString()
        {
            return $"Project '{Project}' - v{Version} : {BOM.Count} items";
        }
    }
}
