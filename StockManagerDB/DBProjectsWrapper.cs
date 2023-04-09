using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB
{
    public class DBProjectsWrapper
    {
        private readonly string filename;
        private Dictionary<string, List<ComponentClass>> remoteComponents = new Dictionary<string, List<ComponentClass>>();
        private Dictionary<string, List<ComponentClass>> localComponents = new Dictionary<string, List<ComponentClass>>();

        public event EventHandler<EventArgs> OnListModified;

        public Dictionary<string, List<ComponentClass>> Components => localComponents;

        public DBProjectsWrapper(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Add to the remoteComponents list
        /// </summary>
        /// <param name="component"></param>
        private void AddComponentToRemoteList(ComponentClass component)
        {
            if (!remoteComponents.ContainsKey(component.Parent))
            {
                remoteComponents[component.Parent] = new List<ComponentClass>();
            }
            remoteComponents[component.Parent].Add(component);
        }

        /// <summary>
        /// Add to the remoteComponents list
        /// </summary>
        /// <param name="component"></param>
        private void AddComponentToLocalList(ComponentClass component)
        {
            if (!localComponents.ContainsKey(component.Parent))
            {
                localComponents[component.Parent] = new List<ComponentClass>();
            }
            localComponents[component.Parent].Add(component.Clone() as ComponentClass);
        }

        /// <summary>
        /// Synchronise parts with actual remote ones
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<ComponentClass>> CloneParts(Dictionary<string, List<ComponentClass>> components)
        {
            Dictionary<string, List<ComponentClass>> output = new Dictionary<string, List<ComponentClass>>();
            foreach (var item in components)
            {
                output.Add(item.Key, new List<ComponentClass>());
                foreach (ComponentClass component in item.Value)
                {
                    output[item.Key].Add(component.Clone() as ComponentClass);
                }
            }

            return output;
        }

        /// <summary>
        /// Load the components from the database
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<ComponentClass>> LoadComponents()
        {
            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                // Create a new DataTable object to hold the data retrieved from the SQLite database
                DataTable dataTable = new DataTable();

                // Retrieve the data from the SQLite database
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM ComponentProjectLink", connection);
                dataAdapter.Fill(dataTable);

                List<ComponentClass> newComponents = ComponentClass.CreateFromDB(dataTable);

                remoteComponents = new Dictionary<string, List<ComponentClass>>();
                localComponents = new Dictionary<string, List<ComponentClass>>();

                foreach (ComponentClass component in newComponents)
                {
                    AddComponentToRemoteList(component);
                    AddComponentToLocalList(component);
                }

                dataAdapter.Dispose();
                connection.Close();
            }

            OnListModified?.Invoke(this, EventArgs.Empty);
            return localComponents;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="projectName"></param>
        public void CreateProject(string projectName)
        {
            // Add dummy component
            ComponentClass dummy = new ComponentClass()
            {
                Parent = projectName,
                MPN = "Template",
                Quantity = "0",
                Reference = "R1"
            };

            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                // Insert part
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO ComponentProjectLink (parent, mpn, quantity, reference)\r\nVALUES (@Parent, @MPN, @Quantity, @Reference);"
                    , connection))
                {
                    command.Parameters.AddWithValue("@Parent", dummy.Parent);
                    command.Parameters.AddWithValue("@MPN", dummy.MPN);
                    command.Parameters.AddWithValue("@Quantity", dummy.Quantity);
                    command.Parameters.AddWithValue("@Reference", dummy.Reference);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            AddComponentToRemoteList(dummy);
            AddComponentToLocalList(dummy);
            OnListModified?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="projectName"></param>
        public void DuplicateProject(string projectName, string referenceProjectName)
        {
            // Get component list
            List<ComponentClass> newComponents = remoteComponents[referenceProjectName];

            // Edit their parent project
            newComponents.ForEach((component) => component.Parent = projectName);

            // Add them all
            AddComponentsRange(newComponents);
        }

        /// <summary>
        /// Add a list of components. Only call the OnListModified event once
        /// </summary>
        /// <param name="components"></param>
        /// <returns>List of added parts. Compare to check which were not added</returns>
        public List<ComponentClass> AddComponentsRange(IEnumerable<ComponentClass> components)
        {
            List<ComponentClass> addedParts = new List<ComponentClass>();
            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                foreach (ComponentClass component in components)
                {
                    // Part already exists
                    if (remoteComponents.ContainsKey(component.MPN))
                    {
                        continue;
                    }
                    addedParts.Add(component);

                    // Insert part
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO ComponentProjectLink (parent, mpn, quantity, reference)\r\nVALUES (@Parent, @MPN, @Quantity, @Reference);"
                    , connection))
                    {
                        command.Parameters.AddWithValue("@Parent", component.Parent);
                        command.Parameters.AddWithValue("@MPN", component.MPN);
                        command.Parameters.AddWithValue("@Quantity", component.Quantity);
                        command.Parameters.AddWithValue("@Reference", component.Reference);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }

            addedParts.ForEach((component) =>
            {
                AddComponentToRemoteList(component);
                AddComponentToLocalList(component);
            });
            OnListModified?.Invoke(this, EventArgs.Empty);

            return addedParts;
        }

        /// <summary>
        /// Rename the project
        /// </summary>
        /// <param name="oldProjectName"></param>
        /// <param name="newProjectName"></param>
        public void RenameProject(string oldProjectName, string newProjectName)
        {
            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"UPDATE ComponentProjectLink SET parent='{newProjectName}' WHERE parent='{oldProjectName}';"
                        , connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            // local changes
            // Easier to load all again
            LoadComponents();
        }


    }
}
