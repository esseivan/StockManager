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
        private SaveList list;

        public event EventHandler<EventArgs> OnPartsListModified;
        public event EventHandler<EventArgs> OnComponentsListModified;

        public SaveList Data
        {
            get
            {
                if (list == null)
                {
                    list = new SaveList();
                    list.Parts.OnListModified += Parts_OnListModified;
                    list.Components.OnListModified += Components_OnListModified;
                }
                return list;
            }
        }

        private void Components_OnListModified(object sender, EventArgs e)
        {
            OnComponentsListModified?.Invoke(this, EventArgs.Empty);
        }

        private void Parts_OnListModified(object sender, EventArgs e)
        {
            OnPartsListModified?.Invoke(this, EventArgs.Empty);
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
            list.Parts.OnListModified += Parts_OnListModified;
            list.Components.OnListModified += Components_OnListModified;
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
            public ListPlus<PartClass> Parts
            {
                get
                {
                    if (_parts == null)
                        _parts = new ListPlus<PartClass>();
                    return _parts;
                }
                set
                {
                    _parts = value;
                }
            }
            private ListPlus<PartClass> _parts;
            /// <summary>
            /// Parts used by projects
            /// </summary>
            public ListPlus<ComponentClass> Components
            {
                get
                {
                    if (_components == null)
                        _components = new ListPlus<ComponentClass>();
                    return _components;
                }
                set
                {
                    _components = value;
                }
            }
            private ListPlus<ComponentClass> _components;

            public void Clear()
            {
                Parts.Clear();
                Components.Clear();
            }
        }

    }
}
