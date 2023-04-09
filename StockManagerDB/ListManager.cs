using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB
{
    /// <summary>
    /// Manage the list of parts and projects
    /// </summary>
    public class ListManager : IDisposable
    {
        private readonly string filepath;
        private SaveList list = new SaveList();

        public SaveList Data
        {
            get
            {
                if (list == null)
                    list = new SaveList();
                return list;
            }
        }

        public ListManager(string filepath)
        {
            this.filepath = filepath;
            Load();
            Save();
        }

        public void Load()
        {
            ESNLib.Tools.SettingsManager.LoadFrom(filepath, out list);
        }

        public void Save()
        {
            ESNLib.Tools.SettingsManager.SaveTo(filepath, list, backup: true, indent: false);
        }

        public static string GetDefaultPath(string name, string folder = null)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ESN", "StockManager");
            if (folder != null)
            {
                path = Path.Combine(path, folder);
            }
            path = Path.Combine(path, name + ".txt");
            return path;
        }

        public static ListManager CreateNew(string filepath, bool templateItems = false)
        {
            ListManager lmi = new ListManager(filepath);
            lmi.Clear();
            if (templateItems)
            {
                lmi.Data.Parts.Add(new PartClass() { MPN = "Part1" });
                lmi.Data.Components.Add(new ComponentClass() { Parent = "Project1", MPN = "Part1", Quantity = 1 });
            }
            lmi.Save();
            return lmi;
        }

        public bool Clear()
        {
            Data.Clear();
            Save();
            return true;
        }

        public static bool Clear(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return false;
            }

            ListManager lmi = new ListManager(filepath);
            return lmi.Clear();
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// The list saved to the file
        /// </summary>
        public class SaveList
        {
            /// <summary>
            /// Parts
            /// </summary>
            public List<PartClass> Parts
            {
                get
                {
                    if (_parts == null)
                        _parts = new List<PartClass>();
                    return _parts;
                }
                set
                {
                    _parts = value;
                }
            }
            private List<PartClass> _parts;
            /// <summary>
            /// Parts used by projects
            /// </summary>
            public List<ComponentClass> Components
            {
                get
                {
                    if (_components == null)
                        _components = new List<ComponentClass>();
                    return _components;
                }
                set
                {
                    _components = value;
                }
            }
            private List<ComponentClass> _components;

            public void Clear()
            {
                Parts.Clear();
                Components.Clear();
            }
        }

    }
}
