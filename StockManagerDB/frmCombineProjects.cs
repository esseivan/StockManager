using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using dhs = StockManagerDB.DataHolderSingleton;

namespace StockManagerDB
{
    public partial class frmCombineProjects : Form
    {
        /// <summary>
        /// Manage the lists
        /// </summary>
        private dhs data => dhs.Instance;

        public event EventHandler ProjectCombined;

        public frmCombineProjects()
        {
            InitializeComponent();
            UpdateProjectList();
        }

        /// <summary>
        /// Update the list of projects
        /// </summary>
        private void UpdateProjectList()
        {
            listView1.Items.Clear();
            foreach (var project in data.Projects)
            {
                listView1.Items.Add(project.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get selected projects
            var items = listView1.SelectedItems;
            if (items.Count <= 0)
            {
                return;
            }

            List<string> candidateProjects = new List<string>();
            foreach (ListViewItem item in items)
            {
                candidateProjects.Add(item.Text);
            }

            LoggerClass.Write($"Found {candidateProjects.Count} projects to combine");

            // Get all versions, and get the name of the first project. Append '_combined'
            string project_name = $"{data.Projects[candidateProjects[0]].Name}_combined";

            // Using dictionary to keep track of existing version number.
            Dictionary<string, ProjectVersion> candidateVersions =
                new Dictionary<string, ProjectVersion>();
            foreach (string project in candidateProjects)
            {
                foreach (ProjectVersion version in data.Projects[project].Versions.Values)
                {
                    // If version already existing, add a suffix
                    string version_name = version.Version;

                    if (candidateVersions.ContainsKey(version_name))
                    {
                        version_name = $"{version_name} ({project})";
                    }
                    version.Version = version_name;
                    candidateVersions.Add(version_name, version);
                }
            }

            LoggerClass.Write($"Found {candidateVersions.Count} versions in those projects");

            // Changing version's owner
            foreach (var version in candidateVersions)
            {
                version.Value.Project = project_name;
            }

            // Removing old projects
            foreach (var project in candidateProjects)
            {
                data.Projects.Remove(project);
            }

            // Creating new project
            Project p = new Project(project_name);

            // Add versions
            foreach (var version in candidateVersions.Values)
            {
                p.Versions.Add(version.Version, version);
            }

            data.Projects.Add(p.Name, p);

            LoggerClass.Write($"Projects successfully combined into {project_name}");

            ProjectCombined?.Invoke(this, EventArgs.Empty);

            UpdateProjectList();
        }
    }
}
