using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CsvHelper;
using ESNLib.Controls;
using ESNLib.Tools;
using dhs = StockManagerDB.DataHolderSingleton;

namespace StockManagerDB
{
    public partial class frmProjects : Form
    {
        private dhs data => dhs.Instance;

        public SortedDictionary<string, Material> Components;

        private ProjectVersion selectedProjectVersion = null;

        private List<Material> BOM => selectedProjectVersion?.BOM;

        public event EventHandler<PartEditEventArgs> OnPartEditRequested;
        public event EventHandler<ProjectProcessRequestedEventArgs> OnProjectProcessRequested;
        public event EventHandler<ProjectOrderRequestedEventArgs> OnProjectOrder;

        private frmCombineProjects _combineForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmCombineProjects combineForm
        {
            get
            {
                if (_combineForm == null)
                {
                    _combineForm = new frmCombineProjects();
                    _combineForm.FormClosing += _combineForm_FormClosing;
                    _combineForm.ProjectCombined += _combineForm_ProjectCombined;
                }
                return _combineForm;
            }
            set
            {
                _combineForm?.Close();
                _combineForm = value;
            }
        }

        public void ApplySettings()
        {
            this.Font = AppSettings.Settings.AppFont;
            this.groupBox1.Font =
                this.groupBox2.Font =
                this.groupBox3.Font =
                    AppSettings.Settings.AppFont;
        }

        public frmProjects()
        {
            InitializeComponent();

            ApplySettings();

            ListViewSetColumns();

            dhs.OnPartListModified += Dhs_OnListModified;
            dhs.OnProjectsListModified += Dhs_OnListModified;

            UpdateProjectList();

            listviewMaterials.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            SetStatus("Idle...");
        }

        #region ListView Init

        public void ProjectsHaveChanged()
        {
            data.InvokeOnProjectsListModified(EventArgs.Empty);
            UpdateProjectList();
        }

        public void VersionsHaveChanged()
        {
            data.InvokeOnProjectsListModified(EventArgs.Empty);
            UpdateVersionList();
        }

        public void MaterialsHaveChanged()
        {
            data.InvokeOnProjectsListModified(EventArgs.Empty);
            UpdateMaterialList();
            UpdateTotalPrice();
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
            olvcNote.AspectGetter = delegate(object x)
            {
                return ((Material)x).Note;
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
                if (!((Material)x).HasPartLink)
                    return 0;
                return ((Material)x).PartLink.Price * ((Material)x).Quantity;
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
                if (!((Material)x).HasPartLink)
                    return 0;
                return ((Material)x).PartLink.Price * ((Material)x).Quantity * (byte)numMult.Value;
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
            RowBorderDecoration rbd = new RowBorderDecoration
            {
                BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2),
                BoundsPadding = new Size(1, 1),
                CornerRounding = 4.0f,
            };

            // Put the decoration onto the hot item
            listviewMaterials.HotItemStyle = new HotItemStyle
            {
                BackColor = Color.Azure,
                Decoration = rbd,
            };
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
                    Trimming = StringTrimming.EllipsisCharacter,
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
            comboboxVersions.DataSource = data.Projects[project].Versions.Keys.ToList();

            if (comboboxVersions.Items.Count > 0)
            {
                comboboxVersions.SelectedIndex = 0;
            }
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

            // If same datasource
            if (listviewMaterials.DataSource == BOM)
            {
                var last = listviewMaterials.CheckedObjects;
                listviewMaterials.DataSource = null;
                listviewMaterials.DataSource = BOM;
                listviewMaterials.CheckObjects(last);
            }
            else
            {
                listviewMaterials.DataSource = BOM;
                listviewMaterials.CheckAll();
            }

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
            listviewMaterials.CheckAll();
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
                Reference = "",
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

            Material material = e.RowObject as Material;

            string editedColumnName = e.Column.Text;
            int editedColumn = e.Column.Index - 1;
            string newValue = e.NewValue.ToString();

            switch (editedColumnName)
            {
                case "Manufacturer PN": // mpn
                    // Verify that an actual change is made
                    if (material.MPN?.Equals(newValue) ?? false)
                    {
                        // No changes
                        LoggerClass.Write("No change detected. Aborting...");
                        return;
                    }
                    material.MPN = newValue;
                    break;
                case "Quantity": // quantity
                    // Verify that an actual change is made
                    if (material.QuantityStr?.Equals(newValue) ?? false)
                    {
                        // No changes
                        LoggerClass.Write("No change detected. Aborting...");
                        return;
                    }
                    material.QuantityStr = newValue;
                    break;
                case "Reference": // reference
                    // Verify that an actual change is made
                    if (material.Reference?.Equals(newValue) ?? false)
                    {
                        // No changes
                        LoggerClass.Write("No change detected. Aborting...");
                        return;
                    }
                    material.Reference = newValue;
                    break;
                case "Note":
                    // Verify that an actual change is made
                    if (material.Note?.Equals(newValue) ?? false)
                    {
                        // No changes
                        LoggerClass.Write("No change detected. Aborting...");
                        return;
                    }
                    material.Note = newValue;
                    break;
                case "LowStock": // LowStock
                    // Here we edit the PartLink
                    if (material.PartLink == null)
                    {
                        // No link
                        LoggerClass.Write("No Part link... Aborting...");
                        return;
                    }

                    // Verify that an actual change is made
                    if (material.PartLink.LowStockStr?.Equals(newValue) ?? false)
                    {
                        // No changes
                        LoggerClass.Write("No change detected. Aborting...");
                        return;
                    }

                    // Do not edit here. Use callback
                    OnPartEditRequested?.Invoke(
                        this,
                        new PartEditEventArgs()
                        {
                            part = material.PartLink,
                            editedParamter = Part.Parameter.LowStock,
                            value = newValue,
                        }
                    );

                    break;
                case "Location": // Location
                    // Here we edit the PartLink
                    if (material.PartLink == null)
                    {
                        // No link
                        LoggerClass.Write("No Part link... Aborting...");
                        return;
                    }

                    // Verify that an actual change is made
                    if (material.PartLink.Location?.Equals(newValue) ?? false)
                    {
                        // No changes
                        LoggerClass.Write("No change detected. Aborting...");
                        return;
                    }

                    // Do not edit here. Use callback
                    OnPartEditRequested?.Invoke(
                        this,
                        new PartEditEventArgs()
                        {
                            part = material.PartLink,
                            editedParamter = Part.Parameter.Location,
                            value = newValue,
                        }
                    );

                    break;
                default:
                    LoggerClass.Write(
                        $"Unable to edit this column, header='{editedColumnName}'",
                        Logger.LogLevels.Error
                    );
                    break;
            }

            MaterialsHaveChanged();
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
            p.Versions.Values.ToList().ForEach((v) => v.Project = newName); // Update versions' project name
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
            LoggerClass.Write($"Deletion of project {project}...");

            // Ask confirmation
            Dialog.DialogConfig dc = new Dialog.DialogConfig()
            {
                Message =
                    $"Warning, this action cannot be undone !\nPlease confirm the deletion of the project :\n{project}\nDo you really want to delete it ?",
                Title = "Warning",
                Icon = Dialog.DialogIcon.Warning,
                Button1 = Dialog.ButtonType.Custom1,
                Button2 = Dialog.ButtonType.Cancel,
                CustomButton1Text = "DELETE",
            };
            Dialog.ShowDialogResult result = Dialog.ShowDialog(dc);
            if (result.DialogResult != Dialog.DialogResult.Custom1)
            {
                LoggerClass.Write("Deletion cancelled by user...");
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

            LoggerClass.Write($"Deletion of {project} version {version} requested...");
            // Ask confirmation
            Dialog.DialogConfig dc = new Dialog.DialogConfig()
            {
                Message =
                    $"Warning, this action cannot be undone !\nPlease confirm the deletion of the version :\n{project} - {version}\nDo you really want to delete it ?",
                Title = "Warning",
                Icon = Dialog.DialogIcon.Warning,
                Button1 = Dialog.ButtonType.Custom1,
                Button2 = Dialog.ButtonType.Cancel,
                CustomButton1Text = "DELETE",
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

        /// <summary>
        /// Ask the user for a multiplier
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool AskUserMultiplier(string text, out int n)
        {
            Dialog.DialogConfig dc = new Dialog.DialogConfig()
            {
                Message = text,
                Title = "Enter input",
                Button1 = Dialog.ButtonType.OK,
                Button2 = Dialog.ButtonType.Cancel,
                DefaultInput = "1",
                Input = true,
                Icon = Dialog.DialogIcon.Question,
            };
            Dialog.ShowDialogResult res = Dialog.ShowDialog(dc);
            if (res.DialogResult != Dialog.DialogResult.OK)
            {
                n = 0;
                return false;
            }

            // Parse input
            if (!int.TryParse(res.UserInput, out n))
            {
                MessageBox.Show(
                    $"Unable to parse your input : '{res.UserInput}'\nAborting...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        private bool ImportDigikeyList()
        {
            if (selectedProjectVersion == null)
            {
                throw new InvalidOperationException("No project version selected");
            }

            // Ask file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel (*.csv)|*.csv|All files|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            LoggerClass.Write($"Loading Digikey list...", Logger.LogLevels.Debug);

            string file = ofd.FileName;
            int processedParts = 0;
            // Read lines
            using (var reader = new StreamReader(file))
            {
                // Skip first 2 lines
                _ = reader.ReadLine();
                _ = reader.ReadLine();

                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = new List<CsvPartImport>();
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var record = new CsvPartImport
                        {
                            MPN = csv.GetField("Manufacturer Part Number"),
                            Quantity = csv.GetField("Requested Quantity 1"),
                        };

                        records.Add(record);
                    }

                    processedParts = ActionDigikeyListProcessParts(records);
                }
            }

            // Ask update of part list
            MaterialsHaveChanged();
            return true;
        }

        /// <summary>
        /// Process the list of selected part from the list. Parts already present will have their current stock updated
        /// </summary>
        private int ActionDigikeyListProcessParts(List<CsvPartImport> records)
        {
            LoggerClass.Write($"{records.Count} part(s) found to process...");

            int processedParts = 0;
            foreach (CsvPartImport item in records)
            {
                if (item == null)
                {
                    LoggerClass.Write(
                        "Null row found... Should not happen",
                        Logger.LogLevels.Error
                    );
                    continue;
                }

                if (string.IsNullOrEmpty(item.MPN))
                {
                    continue;
                }

                processedParts++;
                Material newMaterial = new Material()
                {
                    MPN = item.MPN,
                    QuantityStr = item.Quantity,
                    Note = "__imported",
                };
                AddMaterial(newMaterial);
            }

            return processedParts;
        }

        public bool ActionExportProjects()
        {
            // Ask save path
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager Data|*.smd|Text file, Json|*.txt, *.json|All files|*.*",
            };
            if (fsd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            var selectedFilter = fsd.FilterIndex;

            bool zipFile;
            switch (selectedFilter)
            {
                case 2: // .txt
                    zipFile = false;
                    break;

                default:
                case 1: // .smd
                    zipFile = true;
                    break;
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

            DataExportClass dec = new DataExportClass(null, projects, null);

            SettingsManager.SaveTo(
                fsd.FileName,
                dec,
                backup: SettingsManager.BackupMode.None,
                indent: true,
                zipFile: zipFile
            );

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

            SettingsManager.LoadFrom(ofd.FileName, out DataExportClass dec, zipFile: true);

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

        private void ProcessProjectCheckedParts()
        {
            // Get checked parts
            IEnumerable<Material> checkedParts = listviewMaterials.CheckedObjects.Cast<Material>();

            // If no checked parts, return
            if (checkedParts.Count() == 0)
            {
                return;
            }

            // For all the checked parts, remove the quantity for the project from the part list (general one)
            // First, ask to confirm the multiplier, negative number to add allowed
            string text =
                "Please enter the number of time to remove the project's BOM from the part list\n(Note that a negative number is allowed)";
            if (!AskUserMultiplier(text, out int n))
            {
                return; // Cancelled or error
            }

            // Ask confirmation
            if (
                MessageBox.Show(
                    $"Confirm the process of '{n}' time(s) for the selected project '{selectedProjectVersion.Project}'\n{checkedParts.Count()} out of {BOM.Count} checked part in BOM.\nThe BOM will be substracted from your current stock !",
                    "Confirmation",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                ) != DialogResult.OK
            )
            {
                return;
            }

            LoggerClass.Write(
                $"Procesing project '{selectedProjectVersion.Project}' for '{n}' time(s)..."
            );

            // Callback to main form
            OnProjectProcessRequested?.Invoke(
                this,
                new ProjectProcessRequestedEventArgs()
                {
                    numberOfTimes = n,
                    materials = checkedParts,
                    projectName = selectedProjectVersion.Project,
                }
            );

            SetSuccessStatus(true);
            this.BringToFront();
        }

        #endregion

        #region Misc Events

        private void SetStatus(string status)
        {
            SetStatus(status, SystemColors.ControlText);
        }

        private void SetStatus(string status, Color color)
        {
            labelStatus.ForeColor = color;
            labelStatus.Text = status;

            // Restart timer
            statusTimeoutTimer.Stop();
            statusTimeoutTimer.Start();
        }

        private void SetSuccessStatus(bool result)
        {
            SetStatus(
                result ? "Success !" : "Failed",
                result ? SystemColors.ControlText : Color.Red
            );
        }

        private void UpdateTotalPrice()
        {
            // Update total price
            IEnumerable<Material> selected = listviewMaterials.CheckedObjects.Cast<Material>();

            float totalPrice = 0;
            foreach (Material mat in selected)
            {
                if (!mat.HasPartLink)
                    continue;

                totalPrice += mat.Quantity * mat.PartLink.Price;
            }

            totalPrice = (float)Math.Round(totalPrice, 2);

            txtboxTotalPrice.Text = totalPrice.ToString();
        }

        private void listviewMaterials_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateTotalPrice();
        }

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

        private void listviewMaterials_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            // When rightclicking a cell, copy the MPN of the corresponding row
            if (!(e.Model is Material))
            {
                return;
            }

            contextMenuStrip1.Show(Cursor.Position);
        }

        private void processProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessProjectCheckedParts();
        }

        private void statusTimeoutTimer_Tick(object sender, EventArgs e)
        {
            statusTimeoutTimer.Stop();
            labelStatus.ForeColor = SystemColors.ControlText;
            labelStatus.Text = string.Empty;
        }

        private void orderTheSelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text =
                "Please enter the number of time to add the project's BOM to the order list\n(Note that a negative number is allowed)";
            if (!AskUserMultiplier(text, out int n))
            {
                return;
            }

            var selected = listviewMaterials.CheckedObjects.Cast<Material>();
            OnProjectOrder?.Invoke(
                this,
                new ProjectOrderRequestedEventArgs()
                {
                    materials = selected,
                    numberOfTimes = n,
                    projectName = selectedProjectVersion.Project,
                    OrderIfRequired = false, // Order no matter what
                }
            );
        }

        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listviewMaterials.CheckAll();
        }

        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listviewMaterials.UncheckAll();
        }

        private void copyMPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewMaterials.SelectedObject is Material mat))
            {
                return;
            }

            Clipboard.SetText(mat.MPN);
            SetStatus("Copied to clipboard...");
        }

        private void openSupplierUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewMaterials.SelectedObject is Material mat))
            {
                return;
            }

            if (!mat.HasPartLink)
            {
                return;
            }

            mat.PartLink.OpenSupplierUrl();
            SetStatus("Web page openned...");
        }

        private void btnImportDigikeyList_Click(object sender, EventArgs e)
        {
            ImportDigikeyList();
        }

        private void orderMissingForTheSelectedProjectToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            string text =
                "Please enter the number of time to add the project's BOM to the order list\n(Note that a negative number is allowed)";
            if (!AskUserMultiplier(text, out int n))
            {
                return;
            }

            var selected = listviewMaterials.CheckedObjects.Cast<Material>();
            OnProjectOrder?.Invoke(
                this,
                new ProjectOrderRequestedEventArgs()
                {
                    materials = selected,
                    numberOfTimes = n,
                    projectName = selectedProjectVersion.Project,
                    OrderIfRequired = true, // Order only if required, according to current stock
                    GuaranteeLowStock = true, // Do not go under the lowStock set value
                }
            );
        }

        private void removeFromOrderFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnProjectOrder?.Invoke(
                this,
                new ProjectOrderRequestedEventArgs()
                {
                    materials = null,
                    numberOfTimes = 0,
                    projectName = selectedProjectVersion.Project,
                }
            );
        }

        private void copySPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewMaterials.SelectedObject is Part part))
            {
                return;
            }

            part.CopySPNToClipboard();
            SetStatus("Copied to clipboard...");
        }

        private void _combineForm_ProjectCombined(object sender, EventArgs e)
        {
            ProjectsHaveChanged();
        }

        private void _combineForm_FormClosing(object sender, FormClosingEventArgs e) { }

        private void combineMultipleProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            combineForm.Show();
            combineForm.BringToFront();
        }

        #endregion
    }

    public class PartEditEventArgs : EventArgs
    {
        public Part part;
        public Part.Parameter editedParamter;
        public string value;
    }

    public class ProjectProcessRequestedEventArgs : EventArgs
    {
        public int numberOfTimes;
        public IEnumerable<Material> materials;
        public string projectName;
    }

    public class ProjectOrderRequestedEventArgs : EventArgs
    {
        public int numberOfTimes;
        public IEnumerable<Material> materials;
        public string projectName;
        public bool OrderIfRequired;
        public bool GuaranteeLowStock;
    }
}
