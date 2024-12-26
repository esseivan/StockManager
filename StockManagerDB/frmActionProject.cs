using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dhs = StockManagerDB.DataHolderSingleton;

namespace StockManagerDB
{
    public partial class frmActionProject : Form
    {
        private dhs data => dhs.Instance;

        public ProjectVersion SelectedProjectVersion
        {
            get => GetSelectedProjectVersion();
        }

        public void ApplySettings()
        {
            this.Font = AppSettings.Settings.AppFont;
        }

        public frmActionProject()
        {
            InitializeComponent();

            UpdateProjectList();
        }

        /// <summary>
        /// Get the currently selected project name
        /// </summary>
        /// <returns>Project name</returns>
        public string GetSelectedProjectName()
        {
            if (comboboxProjects.SelectedIndex == -1)
                return null;
            return comboboxProjects.SelectedItem.ToString();
        }

        /// <summary>
        /// Get the currently selected project name
        /// </summary>
        /// <returns>Project name</returns>
        public string GetSelectedVersion()
        {
            if (comboboxVersions.SelectedIndex == -1)
                return null;
            return comboboxVersions.SelectedItem.ToString();
        }

        /// <summary>
        /// Get the selected <see cref="ProjectVersion"/>
        /// </summary>
        /// <returns></returns>
        public ProjectVersion GetSelectedProjectVersion()
        {
            string project = GetSelectedProjectName();
            if (project == null)
                return null;

            string version = GetSelectedVersion();
            if (version == null)
                return null;

            return data.Projects[project].Versions[version];
        }

        /// <summary>
        /// Update the list of projects
        /// </summary>
        private void UpdateProjectList()
        {
            string selProj = comboboxProjects.SelectedItem?.ToString() ?? null;

            comboboxProjects.DataSource = data.Projects.Keys.ToList();

            if ((selProj != null) && (comboboxProjects.Items.Contains(selProj)))
                comboboxProjects.SelectedItem = selProj;
        }

        /// <summary>
        /// Update the list of versions for the selected project
        /// </summary>
        private void UpdateVersionList()
        {
            string project = GetSelectedProjectName();

            if (project == null)
            {
                comboboxVersions.DataSource = null;
                return;
            }
            comboboxVersions.DataSource = data.Projects[project].Versions.Keys.ToList();

            if (comboboxVersions.Items.Count > 0)
            {
                comboboxVersions.SelectedIndex = 0;
            }
        }

        private void comboboxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVersionList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
