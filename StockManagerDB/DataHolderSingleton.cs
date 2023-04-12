using ESNLib.Tools;
using Microsoft.Office.Core;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public Dictionary<string, Part> Parts { get; private set; }
        /// <summary>
        /// The list of projects containing versions and materials
        /// </summary>
        public Dictionary<string, Project> Projects { get; private set; }

        /// <summary>
        /// The instance of the singleton
        /// </summary>
        private static DataHolderSingleton _instance = null;
        /// <summary>
        /// Read only access to the instance
        /// </summary>
        public static DataHolderSingleton Instance => _instance;

        public static event EventHandler<EventArgs> OnPartListModified;
        public static event EventHandler<EventArgs> OnProjectsListModified;

        public void InvokeOnPartListModified(EventArgs e) => OnPartListModified?.Invoke(this, e);
        public void InvokeOnProjectsListModified(EventArgs e) => OnProjectsListModified?.Invoke(this, e);

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
            Parts = data?.GetParts() ?? new Dictionary<string, Part>();
            Projects = data?.GetProjects() ?? new Dictionary<string, Project>();
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

        public DataExportClass(Dictionary<string, Part> parts, Dictionary<string, Project> projects)
        {
            Parts = parts.Values.ToList();
            Projects = projects.Values.ToList();
        }

        public List<Part> Parts { get; set; }
        public List<Project> Projects { get; set; }

        public Dictionary<string, Part> GetParts()
        {
            return new Dictionary<string, Part>(Parts.ToDictionary(p => p.MPN, p => p));
        }

        public Dictionary<string, Project> GetProjects()
        {
            return new Dictionary<string, Project>(Projects.ToDictionary(p => p.Name, p => p));
        }
    }
}
