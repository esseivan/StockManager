using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StockManagerDB.frmProjects;

namespace StockManagerDB
{
    public partial class frmOrder : Form
    {
        private const string CustomPartsProjectName = "CustomParts",
            LowStockOrderProjectName = "LowStock Order";

        /// <summary>
        /// The actual parts to order refering to project list
        /// </summary>
        private readonly Dictionary<string, Material> PartsToOrder =
            new Dictionary<string, Material>();

        private Dictionary<string, ProjectOrderInfos> ProjectsToOrder
        {
            get => DataHolderSingleton.Instance.OrderList;
            set => DataHolderSingleton.Instance.OrderList = value;
        }

        private bool InfosVisible
        {
            get => AppSettings.Settings.Order_ShowInfos;
            set => AppSettings.Settings.Order_ShowInfos = value;
        }
        private bool MoreInfosVisible
        {
            get => AppSettings.Settings.Order_ShowMoreInfos;
            set => AppSettings.Settings.Order_ShowMoreInfos = value;
        }

        private bool init = true;

        public frmOrder()
        {
            InitializeComponent();
            label2.Visible = false;

            ApplySettings();
            ListViewSetColumns();

            init = false;
        }

        public void ApplySettings()
        {
            /**** Font ****/
            //Font newFontNormal = new Font(newFont, FontStyle.Regular);
            if (AppSettings.Settings.AppFont == null)
            {
                AppSettings.ResetToDefault();
            }
            Font newFontNormal = AppSettings.Settings.AppFont; // If user has set bold for all, then set bold for all
            this.Font =
                this.label1.Font =
                this.cbbSuppliers.Font =
                this.textBulkAdd.Font =
                    newFontNormal;
            //this.menuStrip1.Font = this.statusStrip1.Font = newFontNormal;
            // Apply bold fonts
            Font newFontBold = new Font(
                AppSettings.Settings.AppFont,
                FontStyle.Bold | AppSettings.Settings.AppFont.Style
            ); // Add bold style
        }

        /// <summary>
        /// Initialisation of the listviews
        /// </summary>
        /// <param name="listview"></param>
        private void ListViewSetColumns()
        {
            // Setup columns
            olvcMPN.AspectGetter = delegate (object x)
            {
                return ((Material)x).MPN;
            };
            olvcQuantity.AspectGetter = delegate (object x)
            {
                return ((Material)x).Quantity;
            };
            olvcMAN.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Manufacturer;
            };
            olvcDesc.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Description;
            };
            olvcCat.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Category;
            };
            olvcLocation.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Location;
            };
            olvcStock.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Stock;
            };
            olvcLowStock.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.LowStock;
            };
            olvcPrice.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Price;
            };
            olvcSupplier.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Supplier;
            };
            olvcSPN.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.SPN;
            };
            olvcTotalPrice.AspectGetter = delegate (object x)
            {
                return ((Material)x).PartLink?.Price * ((Material)x).Quantity;
            };

            // Make the decoration
            RowBorderDecoration rbd = new RowBorderDecoration
            {
                BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2),
                BoundsPadding = new Size(1, 1),
                CornerRounding = 4.0f
            };

            // Put the decoration onto the hot item
            listviewMaterials.HotItemStyle = new HotItemStyle
            {
                BackColor = Color.Azure,
                Decoration = rbd
            };
        }

        private void UpdateProjectList()
        {
            textboxProjects.Text = string.Join(
                "\n",
                ProjectsToOrder.Select(
                    (x) => $"{x.Value.n}{(x.Value.exactOrder ? "*" : "")}x {x.Key}"
                )
            );
        }

        private void UpdateBulkAddText()
        {
            if (cbbSuppliers.SelectedIndex == -1)
                return;

            IEnumerable<Material> filteredParts;

            if (cbbSuppliers.SelectedIndex == 0)
            {
                filteredParts = PartsToOrder.Values;
            }
            else
            {
                string supplier = cbbSuppliers.SelectedItem.ToString();

                filteredParts = PartsToOrder
                    .Where(
                        (x) =>
                            (
                                (
                                    x.Value.PartLink?.Supplier?.Equals(
                                        supplier,
                                        StringComparison.InvariantCultureIgnoreCase
                                    ) ?? false
                                ) && !string.IsNullOrEmpty(x.Value.PartLink?.Supplier)
                            )
                    )
                    .Select((x) => x.Value);
            }

            bool useMpn = checkboxUseMpn.Checked;
            bool invertCol = checkboxInvertCol.Checked;

            string bulkText;
            if (!invertCol)
            {
                bulkText = string.Join(
                    "\n",
                    filteredParts.Select(
                        (m) => $"{m.QuantityStr}, {(useMpn ? m.MPN : (m.PartLink?.SPN ?? "Undefined"))}"
                    )
                );
            }
            else
            {
                bulkText = string.Join(
                    "\n",
                    filteredParts.Select(
                        (m) => $"{(useMpn ? m.MPN : (m.PartLink?.SPN ?? "Undefined"))}, {m.QuantityStr}"
                    )
                );
            }

            textBulkAdd.Text = bulkText;
        }

        /// <summary>
        /// Calculate the parts to order according to current projects and app settings
        /// </summary>
        private void RecalculatePartToOrder()
        {
            // The following projects are not affected
            string[] unaffectedProjectsName = new string[]
            {
                //CustomPartsProjectName, // Custom user parts
                LowStockOrderProjectName, // Low stock order
            };

            PartsToOrder.Clear();
            List<ProjectOrderInfos> IgnoredMaterial = new List<ProjectOrderInfos>();

            // Add all materials to a list
            foreach (
                KeyValuePair<string, ProjectOrderInfos> item in ProjectsToOrder
            )
            {
                ProjectOrderInfos poc = item.Value;

                if (unaffectedProjectsName.Contains(item.Key)) // Ignore projects
                {
                    IgnoredMaterial.Add(poc);
                    continue;
                }

                if (poc.exactOrder) // Constant quantities
                {
                    IgnoredMaterial.Add(poc);
                    continue;
                }

                foreach (Material m in poc.materials.Values)
                {
                    // Add to existing
                    if (PartsToOrder.ContainsKey(m.MPN))
                    {
                        PartsToOrder[m.MPN].Quantity += m.Quantity * poc.n;
                    }
                    // New material
                    else
                    {
                        PartsToOrder.Add(
                            m.MPN,
                            new Material() { MPN = m.MPN, Quantity = m.Quantity * poc.n, }
                        );
                    }
                }
            }

            // Edit quantities according to actual stock
            foreach (Material m in PartsToOrder.Values)
            {
                m.Quantity = PartUtils.GetActualOrderQuantity(
                    m,
                    true,
                    AppSettings.Settings.OrderDoNotExceedLowStock,
                    AppSettings.Settings.OrderMoreUntilLowStockMinimum
                );
            }

            // Add previously ignored materials
            foreach (ProjectOrderInfos poc in IgnoredMaterial)
            {
                foreach (Material m in poc.materials.Values)
                {
                    // Add to existing
                    if (PartsToOrder.ContainsKey(m.MPN))
                    {
                        PartsToOrder[m.MPN].Quantity += m.Quantity * poc.n;
                    }
                    // New material
                    else
                    {
                        PartsToOrder.Add(
                            m.MPN,
                            new Material() { MPN = m.MPN, Quantity = m.Quantity * poc.n, }
                        );
                    }
                }
            }

            // Remove all 0 quantity materials
            //for (int i = 0; i < PartsToOrder.Count; i++)
            //{
            //    if (PartsToOrder.ElementAt(i).Value.Quantity == 0)
            //    {
            //        PartsToOrder.Remove(PartsToOrder.ElementAt(i).Key);
            //        i--;
            //    }
            //}
        }

        private void PartsHaveChanged(bool recalculate = true)
        {
            Cursor = Cursors.WaitCursor;
            if (recalculate)
                RecalculatePartToOrder();
            listviewMaterials.DataSource = PartsToOrder.Values.ToList();
            UpdateProjectList();
            UpdateBulkAddText();
            Cursor = Cursors.Default;
        }

        public void SetSuppliers(IEnumerable<string> suppliers)
        {
            init = true;
            cbbSuppliers.Items.Clear();
            cbbSuppliers.Items.Add("All");
            cbbSuppliers.Items.AddRange(suppliers.Where((x) => !string.IsNullOrEmpty(x)).ToArray());
            if (cbbSuppliers.Items.Count > 0)
                cbbSuppliers.SelectedIndex = 0;
            init = false;

            UpdateBulkAddText();
        }

        /// <summary>
        /// Add parts to order to the list according to lowstock and stock parameters
        /// </summary>
        /// <param name="parts">List of parts to order if necessary</param>
        public bool AddPartsToOrderList(IEnumerable<Part> parts)
        {
            if (ProjectsToOrder.ContainsKey(LowStockOrderProjectName))
            {
                // Delete current and make a new one
                ProjectsToOrder.Remove(LowStockOrderProjectName);
            }

            // Create material list
            List<Material> mList = new List<Material>();

            foreach (Part part in parts)
            {
                float qty = part.LowStock - part.Stock;
                if (qty < 0)
                {
                    continue; // No order to do for this part
                }

                mList.Add(new Material() { MPN = part.MPN, Quantity = qty, });
            }

            // Add to projects
            ProjectsToOrder[LowStockOrderProjectName] = new ProjectOrderInfos()
            {
                name = LowStockOrderProjectName,
                n = 1,
                materials = mList.ToDictionary((x) => x.MPN),
            };

            DataHolderSingleton.Instance.Save();
            PartsHaveChanged();

            return true;
        }

        public bool RemoveProjectToOrder(string projectName)
        {
            bool result = false;
            if (ProjectsToOrder.ContainsKey(projectName))
            {
                ProjectsToOrder.Remove(projectName);
                result = true;
            }

            DataHolderSingleton.Instance.Save();
            PartsHaveChanged();

            return result;
        }

        /// <summary>
        /// Add a project to the order list. If already in, update ONLY the multiplier by adding the new and the old ones.
        /// </summary>
        /// <param name="projectName">Name of the project displayed to the user</param>
        /// <param name="multiplier">How many time (more) to order the project</param>
        /// <param name="projectMaterial">List of material for the project. Only used for the first time the project is added</param>
        /// <param name="orderExactly">If set to true, nothing is taken from current stock</param>
        /// <returns>True if <paramref name="projectMaterial"/> and <paramref name="orderExactly"/> are used. False otherwise</returns>
        public bool AddProjectToOrder(
            string projectName,
            int multiplier,
            bool orderExactly,
            IEnumerable<Material> projectMaterial
        )
        {
            bool result;
            ProjectOrderInfos poc;
            if (ProjectsToOrder.ContainsKey(projectName))
            {
                // Project already in list. Not updating projectMaterial
                poc = ProjectsToOrder[projectName];
                poc.n += multiplier;

                result = false;
            }
            else
            {
                ProjectsToOrder[projectName] = poc = new ProjectOrderInfos()
                {
                    name = projectName,
                    n = multiplier,
                    exactOrder = orderExactly,
                };

                Dictionary<string, Material> materials = new Dictionary<string, Material>();
                foreach (Material m in projectMaterial)
                {
                    if (materials.ContainsKey(m.MPN))
                    {
                        materials[m.MPN].Quantity += m.Quantity;
                    }
                    else
                    {
                        materials[m.MPN] = new Material() { MPN = m.MPN, Quantity = m.Quantity, };
                    }
                }

                poc.materials = materials;

                result = true;
            }

            DataHolderSingleton.Instance.Save();
            PartsHaveChanged();

            return result;
        }

        /// <summary>
        /// Add custom parts with 0 as starting quantities.
        /// </summary>
        /// <param name="parts">List of parts</param>
        /// <returns>true everytime</returns>
        public bool AddCustomPartsToOrder(IEnumerable<Part> parts)
        {
            ProjectOrderInfos poc;
            if (ProjectsToOrder.ContainsKey(CustomPartsProjectName))
            {
                poc = ProjectsToOrder[CustomPartsProjectName];
            }
            else
            {
                ProjectsToOrder[CustomPartsProjectName] = poc =
                    new ProjectOrderInfos() { name = CustomPartsProjectName, n = 1, };
            }

            // Merge parts. If part not present, add with 0 as the quantity
            foreach (Part p in parts)
            {
                if (!poc.materials.ContainsKey(p.MPN))
                {
                    poc.materials.Add(p.MPN, new Material() { MPN = p.MPN, Quantity = 0, });
                }
            }

            DataHolderSingleton.Instance.Save();
            PartsHaveChanged();

            return true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ask confirmation
            if (
                MessageBox.Show(
                    "Confirm that you want to clear ALL this list.\nClear all ?",
                    "Warning",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes
            )
            {
                return;
            }

            ProjectsToOrder.Clear();
            PartsToOrder.Clear();
            DataHolderSingleton.Instance.Save();
            PartsHaveChanged();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            olvcMAN.IsVisible = olvcLocation.IsVisible = olvcCat.IsVisible = InfosVisible;
            olvcDesc.IsVisible = olvcMPN.IsVisible = MoreInfosVisible;
            listviewMaterials.RebuildColumns();

            // Apply current settings
            if (ProjectsToOrder == null)
            {
                ProjectsToOrder = new Dictionary<string, ProjectOrderInfos>();
            }
            PartsHaveChanged();
        }

        /// <summary>
        /// Delete selected parts
        /// </summary>
        private void deleteSelection()
        {
            IEnumerable<Material> selected = listviewMaterials.SelectedObjects.Cast<Material>();

            foreach (Material item in selected)
            {
                if (PartsToOrder.ContainsKey(item.MPN))
                {
                    PartsToOrder.Remove(item.MPN);
                }
            }

            listviewMaterials.DataSource = PartsToOrder.Values.ToList();
            UpdateBulkAddText();
        }

        private void deleteSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSelection();
        }

        private void cbbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                return;
            }

            UpdateBulkAddText();
        }

        private void copyMPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewMaterials.SelectedObject is Material mat))
            {
                return;
            }

            mat.PartLink.CopyMPNToClipboard();
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

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBulkAdd.Text))
            {
                return;
            }
            Clipboard.SetText(textBulkAdd.Text);
            label2.Visible = true;
            statusTimeoutTimer.Start();
        }

        private void statusTimeoutTimer_Tick(object sender, EventArgs e)
        {
            statusTimeoutTimer.Stop();
            label2.Visible = false;
        }

        /// <summary>
        /// Called when a cell is edited
        /// </summary>
        private void ApplyEdit(CellEditEventArgs e)
        {
            // Get the unedited part version
            Material item = e.RowObject as Material;
            // Get the edited parameter and value
            string newValue = e.NewValue.ToString();

            item.QuantityStr = newValue;

            PartsHaveChanged(false);
        }

        private void UpdateInfos()
        {
            InfosVisible = !InfosVisible;
            olvcMAN.IsVisible = olvcLocation.IsVisible = olvcCat.IsVisible = InfosVisible;
            listviewMaterials.RebuildColumns();
        }

        private void UpdateMoreInfos()
        {
            MoreInfosVisible = !MoreInfosVisible;
            olvcDesc.IsVisible = olvcMPN.IsVisible = MoreInfosVisible;
            listviewMaterials.RebuildColumns();
        }

        private void listviewMaterials_CellEditFinished(object sender, CellEditEventArgs e)
        {
            ApplyEdit(e);
        }

        private void resizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listviewMaterials.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void showInfosToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInfos();
        }

        private void showMoreInfosToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMoreInfos();
        }

        private void checkboxUseMPN_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBulkAddText();
        }

        private void copySPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewMaterials.SelectedObject is Part part))
            {
                return;
            }

            part.CopySPNToClipboard();
        }

        private void checkboxInvertCol_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBulkAddText();
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PartsHaveChanged();
        }
    }
}
