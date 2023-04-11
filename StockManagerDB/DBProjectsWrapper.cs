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
    [Obsolete("Obsolete")]
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

        public void RemoveEmptyProjects()
        {
            var toDelete = localComponents.Where((x) => x.Value.Count == 0).ToArray();

            foreach (var item in toDelete)
            {
                remoteComponents.Remove(item.Key);
                localComponents.Remove(item.Key);
            }
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

        private void RemoveComponentsFromLists(ComponentClass component)
        {
            // Remove using MPN... This is not unique so warning !!
#warning Not unique deletion
            remoteComponents[component.Parent].RemoveAll((c) => c.MPN.Equals(component.MPN));
            localComponents[component.Parent].RemoveAll((c) => c.MPN.Equals(component.MPN));
        }

        /// <summary>
        /// Synchronise parts with actual remote ones
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<ComponentClass>> CloneComponentList(Dictionary<string, List<ComponentClass>> components)
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
                Quantity = 0,
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
        /// Duplicate a existing project
        /// </summary>
        /// <param name="projectName"></param>
        public void DeleteProject(string projectName)
        {
            // Get component list
            List<ComponentClass> componentsToBeDeleted = remoteComponents[projectName];

            if (componentsToBeDeleted.Count == 0)
                throw new InvalidOperationException("No component to delete...");

            // Remove them all
            RemoveComponentRangeParent(projectName, componentsToBeDeleted);
        }

        /// <summary>
        /// Duplicate a existing project
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
        /// <returns>List of added components. Compare to check which were not added</returns>
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

        /// <summary>
        /// Remove the specified component from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RemoveComponent(string componentParent, string componentMPN)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM ComponentProjectLink WHERE parent='{componentParent}' AND mpn='{componentMPN}';"
                        , connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            ComponentClass component = remoteComponents[componentParent].Where((comp) => componentMPN.Equals(comp.MPN)).First();
            remoteComponents[componentParent].Remove(component);
            localComponents[componentParent].Remove(component);
            OnListModified?.Invoke(this, EventArgs.Empty);

            return true;
        }

        /// <summary>
        /// Remove the specified component from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RemoveComponentRangeParent(string parent, IEnumerable<ComponentClass> components)
        {
            components = components.Where((comp) => comp.Parent.Equals(parent)).ToArray();

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                foreach (ComponentClass comp in components)
                {
#warning Not unique deletion
                    using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM ComponentProjectLink WHERE parent='{comp.Parent}' AND mpn='{comp.MPN}';"
                        , connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }

            foreach (ComponentClass component in components)
            {
                RemoveComponentsFromLists(component);
            }
            OnListModified?.Invoke(this, EventArgs.Empty);

            return true;
        }

        /// <summary>
        /// Remove the specified component from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool RemoveComponent(ComponentClass component)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM ComponentProjectLink WHERE parent='{component.Parent}' AND mpn='{component.MPN}';"
                        , connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            remoteComponents[component.Parent].Remove(component);
            localComponents[component.Parent].Remove(component);
            OnListModified?.Invoke(this, EventArgs.Empty);

            return true;
        }

        public bool AddComponent(ComponentClass component)
        {
            // Create a connection to the database
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filename};Version=3;"))
            {
                connection.Open();

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
                connection.Close();
            }
            AddComponentToRemoteList(component);
            AddComponentToLocalList(component);
            OnListModified?.Invoke(this, EventArgs.Empty);

            return true;
        }

        /// <summary>
        /// Apply changes to a part to the database
        /// </summary>
        /// <param name="updatedPart">The updated PartClass part</param>
        /// <returns>True if success. False if failed</returns>
        public bool UpdateComponent(ComponentClass updatedComponent, ComponentClass oldComponent)
        {
            // There isn't really a update component. We delete the old one and create a new one
            RemoveComponent(oldComponent);
            return AddComponent(updatedComponent);
        }
    }
}
