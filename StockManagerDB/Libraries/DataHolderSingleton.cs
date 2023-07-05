using ESNLib.Tools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockManagerDB
{
    /// <summary>
    /// A singleton class holding data which are Parts, Projects, Versions, Materials
    /// </summary>
    public class DataHolderSingleton
    {
        /// <summary>
        /// Disable the logging of history of parts into a .smdh file
        /// </summary>
        public static bool __disable_history = false;

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

        public void InvokeOnProjectsListModified(EventArgs e) =>
            OnProjectsListModified?.Invoke(this, e);

        /// <summary>
        /// The file that is used for this singleton
        /// </summary>
        private readonly string _filepath;

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

            if (!__disable_history)
            {
                DataHolderHistorySingleton.LoadNew(file);
            }
        }

        public bool DeletePart(Part part, string note = "")
        {
            if (!Parts.ContainsKey(part.MPN))
            {
                return false;
            }

            Parts.Remove(part.MPN);
            ApplyNote(part, note);

            if (!__disable_history)
                DataHolderHistorySingleton.AddDeleteEvent(part);

            return true;
        }

        public bool DeletePart(string MPN, string note = "")
        {
            if (!Parts.ContainsKey(MPN))
            {
                return false;
            }

            Part part = Parts[MPN];
            Parts.Remove(MPN);
            ApplyNote(part, note);

            if (!__disable_history)
                DataHolderHistorySingleton.AddDeleteEvent(part);

            return true;
        }

        public bool AddPart(Part part, string note = "")
        {
            if (Parts.ContainsKey(part.MPN))
            {
                return false;
            }

            Parts.Add(part.MPN, part);
            ApplyNote(part, note);

            if (!__disable_history)
                DataHolderHistorySingleton.AddInsertEvent(part);

            return true;
        }

        /// <summary>
        /// Manually apply the edit to the history. oldPart must be created with <seealso cref="Part.CloneForHistory"/>
        /// </summary>
        /// <param name="newPart"></param>
        /// <param name="oldPart"></param>
        /// <returns></returns>
        public bool ManualEditPart(Part newPart, Part oldPart)
        {
            // Update event to history
            if (!__disable_history)
                DataHolderHistorySingleton.AddUpdateEvent(oldPart, newPart);

            return true;
        }

        /// <summary>
        /// Same as <see cref="ManualEditPart(Part, Part)"/> but add a note for the history.
        /// </summary>
        /// <param name="newPart"></param>
        /// <param name="oldPart"></param>
        /// <returns></returns>
        public bool DigikeyUpdatePart(Part newPart, Part oldPart)
        {
            ApplyNote(oldPart, "Digikey update");
            // Update event to history
            if (!__disable_history)
                DataHolderHistorySingleton.AddUpdateEvent(oldPart, newPart);

            return true;
        }

        /// <summary>
        /// Add a note the the part for history
        /// </summary>
        public void ApplyNote(Part oldPart, string note)
        {
            if (string.IsNullOrEmpty(note))
            {
                return;
            }

            note = $"{note.Trim()} ";
            oldPart.note += note;
        }

        /// <summary>
        /// Add a note the the part for history
        /// </summary>
        public void RemoveNote(Part part)
        {
            part.note = "";
        }

        public bool EditPart(string MPN, Part.Parameter param, string value, string note = "")
        {
            if (!Parts.ContainsKey(MPN))
            {
                return false;
            }

            Part newPart = Parts[MPN];
            return EditPart(newPart, param, value, note);
        }

        public bool EditPart(Part newPart, Part.Parameter param, string value, string note = "")
        {
            // Update event, clone the part beforehand
            Part oldPart = newPart.CloneForHistory();
            ApplyNote(oldPart, note);
            RemoveNote(newPart);

            switch (param)
            {
                case Part.Parameter.MPN:
                    if (Parts.ContainsKey(value))
                    {
                        throw new ArgumentOutOfRangeException(
                            "Unable to edit part. MPN already exists...",
                            "value"
                        );
                    }

                    Parts.Remove(newPart.MPN);
                    newPart.Parameters[param] = value;
                    Parts.Add(newPart.MPN, newPart);
                    break;

                case Part.Parameter.Manufacturer:
                case Part.Parameter.Description:
                case Part.Parameter.Category:
                case Part.Parameter.Location:
                case Part.Parameter.Stock:
                case Part.Parameter.LowStock:
                case Part.Parameter.Price:
                case Part.Parameter.Supplier:
                case Part.Parameter.SPN:
                    newPart.Parameters[param] = value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Parameter unknown...", "param");
            }

            // Update event to history
            if (!__disable_history)
                DataHolderHistorySingleton.AddUpdateEvent(oldPart, newPart);

            return true;
        }

        /// <summary>
        /// Load data from the filepath
        /// </summary>
        public void Load()
        {
            SettingsManager.LoadFrom(Filepath, out DataExportClass data);
            Parts = data?.GetParts() ?? new Dictionary<string, Part>();
            Projects = data?.GetProjects() ?? new Dictionary<string, Project>();
        }

        /// <summary>
        /// Save data to the filepath
        /// </summary>
        public void Save()
        {
            try
            {
                SettingsManager.SaveTo(
                    Filepath,
                    new DataExportClass(Parts, Projects),
                    backup: SettingsManager.BackupMode.datetimeFormatAppdata,
                    indent: true,
                    internalFileName: "settings.txt"
                );

                // Also save the history
                DataHolderHistorySingleton.Instance?.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to save. Maybe the file is open in another process.\nError:\n"
                        + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Close the file. This variable will be unusable now...
        /// </summary>
        public void Close()
        {
            // Save(); no longer save on exit.
            Parts = null;
            Projects = null;
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
}
