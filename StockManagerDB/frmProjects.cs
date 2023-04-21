using BrightIdeasSoftware;
using ESNLib.Controls;
using ESNLib.Tools;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

        private List<Material> BOM => selectedProjectVersion?.BOM;

        public frmProjects()
        {
            InitializeComponent();

            ListViewSetColumns();

            dhs.OnPartListModified += Dhs_OnListModified;
            ;
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
            olvcMPN.AspectGetter = delegate(object x)
            {
                return ((Material)x).MPN;
            };
            olvcQuantity.AspectGetter = delegate(object x)
            {
                return ((Material)x).Quantity;
            };
            olvcReference.AspectGetter = delegate(object x)
            {
                return ((Material)x).Reference;
            };
            olvcMAN.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Manufacturer;
            };
            olvcDesc.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Description;
            };
            olvcCat.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Category;
            };
            olvcLocation.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Location;
            };
            olvcStock.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Stock;
            };
            olvcLowStock.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.LowStock;
            };
            olvcPrice.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Price;
            };
            olvcSupplier.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.Supplier;
            };
            olvcSPN.AspectGetter = delegate(object x)
            {
                return ((Material)x).PartLink?.SPN;
            };

            olvcTotalQuantity.AspectGetter = delegate(object x)
            {
                return ((Material)x).Quantity * (byte)numMult.Value;
            };
            olvcTotalPrice.AspectGetter = delegate(object x)
            {
                return (((Material)x).PartLink?.Price ?? 0) * (byte)numMult.Value;
            };
            olvcAvailable.AspectGetter = delegate(object x)
            {
                bool isAvailable =
                    (((Material)x).Quantity * (byte)numMult.Value)
                    <= (((Material)x).PartLink?.Stock ?? 0);
                return isAvailable ? "Yes" : "No";
            };
            olvcAvailable.Renderer = new AvailableCellRenderer();

            // Make the decoration
            RowBorderDecoration rbd = new RowBorderDecoration();
            rbd.BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2);
            rbd.BoundsPadding = new Size(1, 1);
            rbd.CornerRounding = 4.0f;

            // Put the decoration onto the hot item
            listviewMaterials.HotItemStyle = new HotItemStyle();
            listviewMaterials.HotItemStyle.BackColor = Color.Azure;
            listviewMaterials.HotItemStyle.Decoration = rbd;
        }

        public class AvailableCellRenderer : BaseRenderer
        {
            public override void Render(Graphics g, Rectangle r)
            {
                string stateText = this.GetText();
                bool isAvailable = stateText.Equals("Yes");

                Brush brush = isAvailable ? Brushes.LightGreen : Brushes.LightCoral;
                g.FillRectangle(brush, r);

                StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                };
                switch (this.Column.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        fmt.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Left:
                        fmt.Alignment = StringAlignment.Near;
                        break;
                    case HorizontalAlignment.Right:
                        fmt.Alignment = StringAlignment.Far;
                        break;
                }
                g.DrawString(this.GetText(), this.Font, this.TextBrush, r, fmt);
            }
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

            string selVer = comboboxVersions.SelectedItem?.ToString() ?? null;

            comboboxVersions.DataSource = data.Projects[project].Versions.Keys.ToList();

            if ((selVer != null) && (comboboxVersions.Items.Contains(selVer)))
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

            listviewMaterials.DataSource = null;
            listviewMaterials.DataSource = BOM;
            //listviewComponents.AutoResizeColumns();
            listviewMaterials.Focus();

            if (
                (listviewMaterials.SelectedObject is Material selMat)
                && (listviewMaterials.Objects.Cast<Material>().Contains(selMat))
            )
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

            BOM.Add(material);
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

            BOM.Remove(material);
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

        /// <summary>
        /// Create a new <see cref="Material"/>
        /// </summary>
        private void CreateNewMaterial()
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the new MPN for the material",
                Title: "Enter MPN",
                Input: true,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
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

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the new MPN for the project",
                Title: "Enter MPN",
                Input: true,
                DefaultInput: material.MPN,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
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
                    LoggerClass.Write(
                        "Unable to edit this column",
                        ESNLib.Tools.Logger.LogLevels.Error
                    );
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
            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the name for the project",
                Title: "Enter name",
                Input: true,
                DefaultInput: "Project",
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if (data.Projects.ContainsKey(result.UserInput))
            {
                LoggerClass.Write(
                    $"Project with name '{result.UserInput}' already existing...",
                    ESNLib.Tools.Logger.LogLevels.Error
                );
                MessageBox.Show(
                    $"Project with name '{result.UserInput}' already existing...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the new name for the project",
                Title: "Enter new name",
                Input: true,
                DefaultInput: currentName,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            string newName = result.UserInput;

            if (data.Projects.ContainsKey(newName))
            {
                LoggerClass.Write(
                    $"Project with name '{result.UserInput}' already existing...",
                    ESNLib.Tools.Logger.LogLevels.Error
                );
                MessageBox.Show(
                    $"Project with name '{result.UserInput}' already existing...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the name for the duplicated project",
                Title: "Enter new name",
                Input: true,
                DefaultInput: currentName,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            string newName = result.UserInput;

            if (data.Projects.ContainsKey(newName))
            {
                LoggerClass.Write(
                    $"Project with name '{result.UserInput}' already existing...",
                    ESNLib.Tools.Logger.LogLevels.Error
                );
                MessageBox.Show(
                    $"Project with name '{result.UserInput}' already existing...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the new version",
                Title: "Enter new version",
                Input: true,
                DefaultInput: new Version(1, 0, 0).ToString(),
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if (data.Projects[project].Versions.ContainsKey(result.UserInput))
            {
                MessageBox.Show(
                    "This version already exists...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            LoggerClass.Write("Adding version...");
            ProjectVersion pv = new ProjectVersion()
            {
                Version = result.UserInput,
                Project = project,
            };

            data.Projects[project].Versions.Add(pv.Version, pv);

            VersionsHaveChanged();
            LoggerClass.Write("Version added");
        }

        /// <summary>
        /// Delete the selected version
        /// </summary>
        private void DeleteVersion()
        {
            string project = GetSelectedProjectName();
            if (project == null)
            {
                return;
            }

            string version = GetSelectedVersion();

            if (!data.Projects[project].Versions.ContainsKey(version))
            {
                throw new InvalidOperationException("Version not found in the project...");
            }

            LoggerClass.Write($"Deletion of {project} v{version} requested...");
            // Ask confirmation
            Dialog.DialogConfig dc = new Dialog.DialogConfig()
            {
                Message =
                    $"Warning, this action cannot be undone !\nPlease confirm the deletion of the version :\n{project} - v{version}\nDo you really want to delete it ?",
                Title = "Warning",
                Icon = Dialog.DialogIcon.Warning,
                Button1 = Dialog.ButtonType.Custom1,
                Button2 = Dialog.ButtonType.Cancel,
                CustomButton1Text = "DELETE"
            };
            Dialog.ShowDialogResult result = Dialog.ShowDialog(dc);
            if (result.DialogResult != Dialog.DialogResult.Custom1)
            {
                LoggerClass.Write("Deletion cancelled by user...");
                return;
            }

            LoggerClass.Write("Deleting...");
            data.Projects[project].Versions.Remove(version);
            VersionsHaveChanged();
            LoggerClass.Write("Deletion finished");
        }

        /// <summary>
        /// Duplicate the selected version
        /// </summary>
        private void DuplicateVersion()
        {
            string project = GetSelectedProjectName();
            if (project == null)
            {
                return;
            }

            string version = GetSelectedVersion();
            if (version == null)
            {
                return;
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the new version",
                Title: "Enter new version",
                Input: true,
                DefaultInput: version,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            if (data.Projects[project].Versions.ContainsKey(result.UserInput))
            {
                MessageBox.Show(
                    "This version already exists...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            LoggerClass.Write("Duplicating version...");
            ProjectVersion newVersion = selectedProjectVersion.Clone() as ProjectVersion;
            newVersion.Version = result.UserInput;
            data.Projects[project].Versions.Add(newVersion.Version, newVersion);
            LoggerClass.Write("Version duplication finished");
            VersionsHaveChanged();
        }

        private void RenameVersion()
        {
            string project = GetSelectedProjectName();
            if (project == null)
            {
                return;
            }

            string version = GetSelectedVersion();
            if (version == null)
            {
                return;
            }

            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the new version",
                Title: "Enter new version",
                Input: true,
                DefaultInput: version,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            // If unchanged
            if (result.UserInput.Equals(version))
            {
                return;
            }

            if (data.Projects[project].Versions.ContainsKey(result.UserInput))
            {
                MessageBox.Show(
                    "This version already exists...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            LoggerClass.Write("Renaming version...");
            ProjectVersion selectedVersion = selectedProjectVersion;
            data.Projects[project].Versions.Remove(version);
            selectedVersion.Version = result.UserInput;
            data.Projects[project].Versions.Add(selectedVersion.Version, selectedVersion);
            LoggerClass.Write("Renaming finished");
            VersionsHaveChanged();
        }

        #endregion

        #region Actions

        public bool ActionExportProjects()
        {
            // Ask save path
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };
            if (fsd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            if (File.Exists(fsd.FileName))
            {
                LoggerClass.Write(
                    $"Unable to export... File already exists",
                    Logger.LogLevels.Debug
                );
                MessageBox.Show(
                    "Unable to export projects. The selected file already exists...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            LoggerClass.Write($"Exporting projects...", Logger.LogLevels.Debug);
            Dictionary<string, Project> projects = data.Projects;

            LoggerClass.Write(
                $"{projects.Count} project(s) found for export",
                Logger.LogLevels.Debug
            );

            DataExportClass dec = new DataExportClass(null, projects);

            SettingsManager.SaveTo(fsd.FileName, dec, backup: false, indent: true, zipFile: true);

            return true;
        }

        public bool ImportProjects()
        {
            // Ask file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            SettingsManager.LoadFrom(ofd.FileName, out DataExportClass dec, isZipped: true);

            List<Project> projects = dec.Projects;
            foreach (Project project in projects)
            {
                if (!data.Projects.ContainsKey(project.Name))
                {
                    data.Projects.Add(project.Name, project);
                }
                else
                {
                    Project currentProject = data.Projects[project.Name];
                    // Add versions
                    foreach (ProjectVersion version in project.Versions.Values)
                    {
                        if (!currentProject.Versions.ContainsKey(version.Version))
                        {
                            currentProject.Versions.Add(version.Version, version);
                        }
                    }
                }
            }

            ProjectsHaveChanged();
            return true;
        }

        #endregion

        #region Misc Events

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            DeleteVersion();
            comboboxVersions.Focus();
        }

        private void btnVerDup_Click(object sender, EventArgs e)
        {
            DuplicateVersion();
            comboboxVersions.Focus();
        }

        private void btnVerRen_Click(object sender, EventArgs e)
        {
            RenameVersion();
            comboboxVersions.Focus();
        }

        private void resizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listviewMaterials.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void numMult_ValueChanged(object sender, EventArgs e)
        {
            listviewMaterials.Invalidate();
        }

        private void exportAllProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionExportProjects();
        }

        private void importProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportProjects();
        }

        #endregion
    }
}
