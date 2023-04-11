using ESNLib.Tools;
using Microsoft.Office.Core;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockManagerDB
{
    /// <summary>
    /// A singleton class holding data which are Parts, Projects, Versions, Materials
    /// </summary>
    public class DataHolderSingleton
    {
        /// <summary>
        /// The list of parts
        /// </summary>
        public SortedDictionary<string, Part> Parts { get; private set; }
        /// <summary>
        /// The list of projects containing versions and materials
        /// </summary>
        public SortedDictionary<string, Project> Projects { get; private set; }

        /// <summary>
        /// The instance of the singleton
        /// </summary>
        private static DataHolderSingleton _instance = null;
        /// <summary>
        /// Read only access to the instance
        /// </summary>
        public static DataHolderSingleton Instance => _instance;

        /// <summary>
        /// The file that is used for this singleton
        /// </summary>
        private string _filepath;
        /// <summary>
        /// The file that is used for this singleton. To change this, call <see cref="DataHolderSingleton.LoadNew(string)"/>
        /// </summary>
        public string Filepath => _filepath;

        /// <summary>
        /// Private constructor
        /// </summary>
        private DataHolderSingleton(string file)
        {
            _filepath = file;
            Load();
        }

        /// <summary>
        /// Load data from the filepath
        /// </summary>
        public void Load()
        {
            SettingsManager.LoadFrom(Filepath, out DataExportClass data);
            Parts = data?.GetParts() ?? new SortedDictionary<string, Part>();
            Projects = data?.GetProjects() ?? new SortedDictionary<string, Project>();
            // Save just after loading
            Save();
        }

        /// <summary>
        /// Save data to the filepath
        /// </summary>
        public void Save()
        {
            SettingsManager.SaveTo(Filepath, new DataExportClass(Parts, Projects), backup: true, indent: true);
        }

        /// <summary>
        /// Close the file. This variable will be unusable now...
        /// </summary>
        public void Close()
        {
            Save();
            Parts = null;
            Projects = null;
            _filepath = null;
            _instance = null;
        }

        /// <summary>
        /// Create a new singleton for the specified file
        /// </summary>
        /// <param name="filepath">The StockManager</param>
        /// <returns></returns>
        public static DataHolderSingleton LoadNew(string filepath)
        {
            DataHolderSingleton s = new DataHolderSingleton(filepath);
            _instance = s;

            return s;
        }
    }

    /// <summary>
    /// Used to export the data into a file
    /// </summary>
    internal class DataExportClass
    {
        public DataExportClass()
        {
        }

        public DataExportClass(SortedDictionary<string, Part> parts, SortedDictionary<string, Project> projects)
        {
            Parts = parts.Values.ToList();
            Projects = projects.Values.ToList();
        }

        public List<Part> Parts { get; set; }
        public List<Project> Projects { get; set; }

        public SortedDictionary<string, Part> GetParts()
        {
            return new SortedDictionary<string, Part>(Parts.ToDictionary(p => p.MPN, p => p));
        }

        public SortedDictionary<string, Project> GetProjects()
        {
            return new SortedDictionary<string, Project>(Projects.ToDictionary(p => p.Name, p => p));
        }
    }

    /// <summary>
    /// Define a part
    /// </summary>
    public class Part : ICloneable
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
        [JsonIgnore]
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
        [JsonIgnore]
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
        [JsonIgnore]
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
        public SortedDictionary<Parameter, string> Parameters = new SortedDictionary<Parameter, string>();

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

        public override string ToString()
        {
            return $"MPN:{MPN}; Stock:{Stock}; Location:{Location}";
        }

        public object Clone()
        {
            Part newPart = new Part();

            foreach (KeyValuePair<Parameter, string> item in this.Parameters)
            {
                newPart.Parameters.Add(item.Key, item.Value);
            }

            return newPart;
        }

        /// <summary>
        /// Class to compare the price of two Parts
        /// </summary>
        public class ComparePrice : IComparer<Part>
        {
            public int Compare(Part x, Part y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }

        public class CompareMPN : IComparer<Part>
        {
            public int Compare(Part x, Part y)
            {
                return x.MPN.CompareTo(y.MPN);
            }
        }
    }

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
        public SortedDictionary<string, ProjectVersion> Versions { get; set; } = new SortedDictionary<string, ProjectVersion>();
    }

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
