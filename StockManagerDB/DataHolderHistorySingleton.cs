using ESNLib.Tools;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockManagerDB
{
    public class DataHolderHistorySingleton
    {
        public List<Part> PartHistory { get; private set; }

        /// <summary>
        /// The instance of the singleton
        /// </summary>
        private static DataHolderHistorySingleton _instance = null;
        /// <summary>
        /// Read only access to the instance
        /// </summary>
        [JsonIgnore]
        public static DataHolderHistorySingleton Instance => _instance;


        /// <summary>
        /// The file that is used for this singleton
        /// </summary>
        private readonly string _filepath;
        /// <summary>
        /// The file that is used for this singleton. To change this, call <see cref="DataHolderHistorySingleton.LoadNew(string)"/>
        /// </summary>
        [JsonIgnore]
        public string Filepath => _filepath;

        /// <summary>
        /// Private constructor
        /// </summary>
        private DataHolderHistorySingleton(string file)
        {
            // Change extension
            _filepath = Path.ChangeExtension(file, ".smdh");

            Load();
        }

        /// <summary>
        /// Load data from the filepath
        /// </summary>
        public void Load()
        {
            SettingsManager.LoadFrom(Filepath, out List<Part> data);
            PartHistory = data ?? new List<Part>();
            // Save just after loading
            Save();
        }

        /// <summary>
        /// Save data to the filepath
        /// </summary>
        public void Save()
        {
            // Sort before save
            PartHistory.Sort(new Part.CompareMPNThenVersion());

            SettingsManager.SaveTo(Filepath, PartHistory, backup: true, indent: true, internalFileName: "history.txt");
        }

        /// <summary>
        /// Create a new singleton for the specified file
        /// </summary>
        /// <param name="filepath">The StockManager</param>
        /// <returns></returns>
        public static DataHolderHistorySingleton LoadNew(string filepath)
        {
            DataHolderHistorySingleton s = new DataHolderHistorySingleton(filepath);
            _instance = s;

            return s;
        }

        /// <summary>
        /// New part inserted into the list
        /// </summary>
        public static void AddInsertEvent(Part part)
        {
            // No event added to the history, but the part parameters are set
            part.Version = 0;
            part.ValidFrom = DateTime.Now;
            part.ValidUntil = default;
            part.Status = "Insert ";
        }

        /// <summary>
        /// Part delete from the list
        /// </summary>
        public static void AddDeleteEvent(Part part)
        {
            part.ValidUntil = DateTime.Now;
            part.Status = "Delete";

            // Add to history
            Instance.PartHistory.Add(part);
        }

        /// <summary>
        /// Part updated
        /// </summary>
        public static void AddUpdateEvent(Part oldPart, Part newPart)
        {
            oldPart.ValidUntil = DateTime.Now;
            if (oldPart.MPN != newPart.MPN)
            {
                oldPart.Status += $"MPN changed to {newPart.MPN}";
            }

            newPart.ValidFrom = DateTime.Now;
            newPart.Version++;
            newPart.Status = string.Empty;

            // Add to history
            Instance.PartHistory.Add(oldPart);
        }
    }
}
