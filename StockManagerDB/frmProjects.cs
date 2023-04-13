using BrightIdeasSoftware;
using ESNLib.Controls;
using Microsoft.Vbe.Interop;
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
    public partial class frmProjects : Form
    {
        private dhs data => dhs.Instance;

        public SortedDictionary<string, Material> Components;

        private ProjectVersion selectedProjectVersion = null;

        public frmProjects()
        {
            InitializeComponent();

            ListViewSetColumns();

            dhs.OnPartListModified += Dhs_OnListModified; ;
            dhs.OnProjectsListModified += Dhs_OnListModified;

            UpdateProjectList();
        }

        #region ListView Init

        private void ProjectsHaveChanged()
        {
            data.InvokeOnProjectsListModified(EventArgs.Empty);
            UpdateProjectList();
        }

        private void VersionsHaveChanged()
        {
            data.InvokeOnProjectsListModified(EventArgs.Empty);
            UpdateVersionList();
        }

        private void MaterialsHaveChanged()
        {
            data.InvokeOnProjectsListModified(EventArgs.Empty);
            UpdateMaterialList();
        }

        private void Dhs_OnListModified(object sender, EventArgs e)
        {
            data.Save();
        }

        /// <summary>
        /// Initialisation of the listviews
        /// </summary>
        /// <param name="listview"></param>
        private void ListViewSetColumns()
        {
            // Setup columns
            olvcMPN.AspectGetter = delegate (object x) { return ((Material)x).MPN; };
            olvcQuantity.AspectGetter = delegate (object x) { return ((Material)x).Quantity; };
            olvcReference.AspectGetter = delegate (object x) { return ((Material)x).Reference; };
            olvcMAN.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Manufacturer; };
            olvcDesc.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Description; };
            olvcCat.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Category; };
            olvcLocation.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Location; };
            olvcStock.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Stock; };
            olvcLowStock.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.LowStock; };
            olvcPrice.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Price; };
            olvcSupplier.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.Supplier; };
            olvcSPN.AspectGetter = delegate (object x) { return ((Material)x).PartLink?.SPN; };
        }

        #endregion

        #region Project and Material display

        /// <summary>
        /// Update the list of projects
        /// </summary>
        private void UpdateProjectList()
        {
            string selProj = comboboxProjects.SelectedItem?.ToString() ?? null;

            comboboxProjects.DataSource = data.Projects.Keys.ToList();

            if ((selProj != null)
            && (comboboxProjects.Items.Contains(selProj)))
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

            string selVer = comboboxVersions.SelectedItem?.ToString() ?? null;

            comboboxVersions.DataSource = data.Projects[project].Versions.Keys.ToList();

            if ((selVer != null)
            && (comboboxVersions.Items.Contains(selVer)))
                comboboxVersions.SelectedItem = selVer;
        }

        /// <summary>
        /// Update the material list according to selected <see cref="ProjectVersion"/>
        /// </summary>
        private void UpdateMaterialList()
        {
            selectedProjectVersion = GetSelectedProjectVersion();
            if (selectedProjectVersion == null)
            {
                listviewMaterials.DataSource = null;
                return;
            }

            Material selMat = listviewMaterials.SelectedObject as Material;

            listviewMaterials.DataSource = selectedProjectVersion.BOM.Values.ToList();
            //listviewComponents.AutoResizeColumns();
            listviewMaterials.Focus();

            if ((selMat != null)
            && (listviewMaterials.Objects.Cast<Material>().Contains(selMat)))
                listviewMaterials.SelectedObject = selMat;
        }

        /// <summary>
        /// Get the currently selected project name
        /// </summary>
        /// <returns>Project name</returns>
        private string GetSelectedProjectName()
        {
            if (comboboxProjects.SelectedIndex == -1)
                return null;
            return comboboxProjects.SelectedItem.ToString();
        }

        /// <summary>
        /// Get the currently selected project name
        /// </summary>
        /// <returns>Project name</returns>
        private string GetSelectedVersion()
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

        #endregion

        #region Material management

        /// <summary>
        /// Add a new <see cref="Material"/>
        /// </summary>
        /// <param name="material"></param>
        /// <exception cref="InvalidOperationException">No <see cref="ProjectVersion"/> selected</exception>
        private void AddMaterial(Material material)
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            if (selectedProjectVersion.BOM.ContainsKey(material.MPN))
            {
                throw new InvalidOperationException("Material MPN already exists");
            }

            selectedProjectVersion.BOM.Add(material.MPN, material);
            MaterialsHaveChanged();

        }
        /// <summary>
        /// Delete the specified <see cref="Material"/>
        /// </summary>
        /// <param name="material"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void DeleteMaterial(Material material)
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            if (!selectedProjectVersion.BOM.ContainsKey(material.MPN))
            {
                LoggerClass.Write("Unable to delete component. Not found", ESNLib.Tools.Logger.LogLevels.Error);
                throw new InvalidOperationException("Material MPN not found");
            }

            selectedProjectVersion.BOM.Remove(material.MPN);
            MaterialsHaveChanged();
        }

        /// <summary>
        /// Edit a <see cref="Material"/>
        /// </summary>
        /// <param name="oldMaterial"></param>
        /// <param name="newMaterial"></param>
        private void EditMaterial(Material oldMaterial, Material newMaterial)
        {
            DeleteMaterial(oldMaterial);
            AddMaterial(newMaterial);
        }

        private static int newMaterialCounter = 0;
        /// <summary>
        /// Create a new <see cref="Material"/>
        /// </summary>
        private void CreateNewMaterial()
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the new MPN for the material", Title: "Enter MPN", Input: true, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if (selectedProjectVersion.BOM.ContainsKey(result.UserInput))
            {
                MessageBox.Show("This MPN is already in the list...");
                return;
            }

            Material newMaterial = new Material()
            {
                MPN = result.UserInput,
                Quantity = 0,
                Reference = ""
            };

            AddMaterial(newMaterial);
        }

        /// <summary>
        /// Duplicate the selected <see cref="Material"/>. Only one selection allowed
        /// </summary>
        private void DeleteSelectedMaterial()
        {
            // Only allow a single selection
            if (listviewMaterials.SelectedIndex == -1)
            {
                return;
            }

            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            // Get selected component
            Material material = listviewMaterials.SelectedObject as Material;

            // Save selected index to restore
            int selectedIndexBefore = listviewMaterials.SelectedIndex;

            DeleteMaterial(material);

            if (selectedIndexBefore >= listviewMaterials.Items.Count)
                selectedIndexBefore--;
            listviewMaterials.SelectedIndex = selectedIndexBefore;
        }

        /// <summary>
        /// Duplicate all checked <see cref="Material"/>
        /// </summary>
        private void DuplicateAllCheckedMaterial()
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            // Get all checked
            List<Material> checkedMaterials = listviewMaterials.CheckedObjectsEnumerable.Cast<Material>().ToList();
            // Duplicate them
            List<Material> newComponents = checkedMaterials.Select((comp) => comp.Clone() as Material).ToList();

            newComponents.ForEach((c) => selectedProjectVersion.BOM.Add(c.MPN, c));
            MaterialsHaveChanged();
        }

        /// <summary>
        /// Remove all checked <see cref="Material"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">MPN not found in list</exception>
        private void DeleteAllCheckedMaterials()
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            // Get all checked
            List<Material> checkedMaterials = listviewMaterials.CheckedObjectsEnumerable.Cast<Material>().ToList();

            foreach (Material item in checkedMaterials)
            {
                if (!selectedProjectVersion.BOM.ContainsKey(item.MPN))
                {
                    throw new InvalidOperationException("Material MPN not found");
                }

                selectedProjectVersion.BOM.Remove(item.MPN);
            }
            MaterialsHaveChanged();
        }

        /// <summary>
        /// Duplicate selected <see cref="Material"/>
        /// </summary>
        private void DuplicateSelectedMaterials()
        {
            // Only allow a single selection
            if (listviewMaterials.SelectedIndex == -1)
            {
                return;
            }

            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }


            // Get selected component
            Material material = listviewMaterials.SelectedObject as Material;

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the new MPN for the project", Title: "Enter MPN", Input: true, DefaultInput: material.MPN, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if(selectedProjectVersion.BOM.ContainsKey(result.UserInput))
            {
                MessageBox.Show("This MPN is already present in the list...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedIndexBefore = listviewMaterials.SelectedIndex;

            Material newMaterial = material.Clone() as Material;
            newMaterial.MPN = result.UserInput;
            AddMaterial(newMaterial);

            listviewMaterials.SelectedIndex = selectedIndexBefore;
        }

        /// <summary>
        /// Apply <see cref="CellEditEventArgs"/> event
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void ApplyEdit(CellEditEventArgs e)
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            Material oldMaterial = e.RowObject as Material;

            int editedColumn = e.Column.Index - 1;
            string newValue = e.NewValue.ToString();

            Material newMaterial = oldMaterial.Clone() as Material;

            switch (editedColumn)
            {
                case 0: // mpn
                    newMaterial.MPN = newValue;
                    break;
                case 1: // quantity
                    newMaterial.QuantityStr = newValue;
                    break;
                case 2: // reference
                    newMaterial.Reference = newValue;
                    break;
                default:
                    LoggerClass.Write("Unable to edit this column", ESNLib.Tools.Logger.LogLevels.Error);
                    break;
            }

            // Apply manually the new value
            EditMaterial(oldMaterial, newMaterial);
        }

        #endregion

        #region Project management

        /// <summary>
        /// Create new <see cref="Project"/>
        /// </summary>
        private void CreateNewProject()
        {
            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the name for the project", Title: "Enter name", Input: true, DefaultInput: "Project", Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if (data.Projects.ContainsKey(result.UserInput))
            {
                LoggerClass.Write($"Project with name '{result.UserInput}' already existing...", ESNLib.Tools.Logger.LogLevels.Error);
                MessageBox.Show($"Project with name '{result.UserInput}' already existing...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Project p = new Project(result.UserInput);

            data.Projects.Add(p.Name, p);

            ProjectsHaveChanged();
        }

        /// <summary>
        /// Rename the <see cref="Project"/>
        /// </summary>
        /// <param name="currentName"></param>
        private void RenameProject(string currentName)
        {
            if (string.IsNullOrEmpty(currentName))
            {
                LoggerClass.Write("New name is empty", ESNLib.Tools.Logger.LogLevels.Error);
                return;
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the new name for the project", Title: "Enter new name", Input: true, DefaultInput: currentName, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            string newName = result.UserInput;

            if (data.Projects.ContainsKey(newName))
            {
                LoggerClass.Write($"Project with name '{result.UserInput}' already existing...", ESNLib.Tools.Logger.LogLevels.Error);
                MessageBox.Show($"Project with name '{result.UserInput}' already existing...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Project p = data.Projects[currentName];
            p.Name = newName;
            data.Projects.Remove(currentName);
            data.Projects.Add(p.Name, p);

            ProjectsHaveChanged();
        }

        /// <summary>
        /// Duplicate the <see cref="Project"/>
        /// </summary>
        /// <param name="currentName"></param>
        private void DuplicateProject(string currentName)
        {
            if (string.IsNullOrEmpty(currentName))
            {
                LoggerClass.Write("New name is empty", ESNLib.Tools.Logger.LogLevels.Error);
                return;
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the name for the duplicated project", Title: "Enter new name", Input: true, DefaultInput: currentName, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            string newName = result.UserInput;

            if (data.Projects.ContainsKey(newName))
            {
                LoggerClass.Write($"Project with name '{result.UserInput}' already existing...", ESNLib.Tools.Logger.LogLevels.Error);
                MessageBox.Show($"Project with name '{result.UserInput}' already existing...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Project p = data.Projects[currentName].Clone() as Project;
            p.Name = newName;
            data.Projects.Add(p.Name, p);

            ProjectsHaveChanged();
        }

        /// <summary>
        /// Delete the <see cref="Project"/>
        /// </summary>
        private void DeleteSelectedProject()
        {
            string project = GetSelectedProjectName();
            if (project == null)
            {
                return;
            }

            data.Projects.Remove(project);

            ProjectsHaveChanged();
        }

        #endregion

        #region Version management

        /// <summary>
        /// Add a new version to the selected project
        /// </summary>
        private void AddVersion()
        {
            string project = GetSelectedProjectName();
            if (project == null)
            {
                return;
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the new version", Title: "Enter new version", Input: true, DefaultInput: new Version(1, 0, 0).ToString(), Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if (data.Projects[project].Versions.ContainsKey(result.UserInput))
            {
                MessageBox.Show("This version already exists...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProjectVersion pv = new ProjectVersion()
            {
                Version = result.UserInput,
                Project = project,
            };

            data.Projects[project].Versions.Add(pv.Version, pv);

            VersionsHaveChanged();
        }

        private void DeleteVersion()
        {

        }

        #endregion

        #region Misc Events

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void renameSelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void duplicateSelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void DELETESelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void comboboxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVersionList();
        }
        private void comboboxVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMaterialList();
        }
        private void listviewComponents_CellEditFinished(object sender, CellEditEventArgs e)
        {
            ApplyEdit(e);
        }
        private void btnAddComponent_Click(object sender, EventArgs e)
        {
        }
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
        }
        private void duplicateAllCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateAllCheckedMaterial();
        }
        private void DELETEAllCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAllCheckedMaterials();
        }

        #endregion

        private void btnMatAdd_Click(object sender, EventArgs e)
        {
            CreateNewMaterial();
            listviewMaterials.Focus();
        }

        private void btnMatDup_Click(object sender, EventArgs e)
        {
            DuplicateSelectedMaterials();
            listviewMaterials.Focus();
        }

        private void btnMatDel_Click(object sender, EventArgs e)
        {
            DeleteSelectedMaterial();
            listviewMaterials.Focus();
        }

        private void btnProAdd_Click(object sender, EventArgs e)
        {
            CreateNewProject();
            comboboxProjects.Focus();
        }

        private void btnProDel_Click(object sender, EventArgs e)
        {
            DeleteSelectedProject();
            comboboxProjects.Focus();
        }

        private void btnProDup_Click(object sender, EventArgs e)
        {
            DuplicateProject(GetSelectedProjectName());
            comboboxProjects.Focus();
        }

        private void btnProRen_Click(object sender, EventArgs e)
        {
            RenameProject(GetSelectedProjectName());
            comboboxProjects.Focus();
        }

        private void btnVerAdd_Click(object sender, EventArgs e)
        {
            AddVersion();
            comboboxVersions.Focus();
        }

        private void btnVerDel_Click(object sender, EventArgs e)
        {

        }

        private void btnVerDup_Click(object sender, EventArgs e)
        {

        }

        private void btnVerRen_Click(object sender, EventArgs e)
        {

        }
    }
}
