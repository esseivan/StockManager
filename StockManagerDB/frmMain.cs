using BrightIdeasSoftware;
using BrightIdeasSoftware.Design;
using CsvHelper;
using ESNLib.Controls;
using ESNLib.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using dhs = StockManagerDB.DataHolderSingleton;

namespace StockManagerDB
{
    public partial class frmMain : Form
    {
        #region Variables

        /// <summary>
        /// filepath to the database
        /// </summary>
        private string filepath = string.Empty;

        /// <summary>
        /// Manage the lists
        /// </summary>
        private dhs data => dhs.Instance;

        /// <summary>
        /// List of parts in the database
        /// </summary>
        private Dictionary<string, Part> Parts => data.Parts;

        /// <summary>
        /// Indicate if a file is loaded
        /// </summary>
        private bool IsFileLoaded => (null != data);

        /// <summary>
        /// Update CheckListView when checkItemChanged
        /// </summary>
        private bool UpdateOnCheck
        {
            get
            {
                return _updateOnCheck;
            }
            set
            {
                _updateOnCheck = value;
                if (_updateOnCheck)
                {
                    UpdateCheckedListview();
                }
            }
        }
        private bool _updateOnCheck = true;

        private frmProjects _projectForm = null;
        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmProjects projectForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_projectForm == null)
                    {
                        _projectForm = new frmProjects();
                        _projectForm.FormClosed += _projectForm_FormClosed;
                    }
                }
                else
                {
                    if (_projectForm != null)
                    {
                        _projectForm.Close();
                        _projectForm = null;
                    }
                }
                return _projectForm;
            }
            set
            {
                if (_projectForm != null)
                {
                    _projectForm.Close();
                }
                _projectForm = value;
            }
        }

        private frmHistory _historyForm = null;
        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmHistory historyForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_historyForm == null)
                    {
                        _historyForm = new frmHistory();
                        _historyForm.FormClosed += _historyForm_FormClosed;
                    }
                }
                else
                {
                    if (_historyForm != null)
                    {
                        _historyForm.Close();
                        _historyForm = null;
                    }
                }
                return _historyForm;
            }
            set
            {
                if (_historyForm != null)
                {
                    _historyForm.Close();
                }
                _historyForm = value;
            }
        }

        private frmSearch _searchForm = null;
        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmSearch searchForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_searchForm == null)
                    {
                        _searchForm = new frmSearch();
                        _searchForm.FormClosed += _searchForm_FormClosed;
                    }
                }
                else
                {
                    if (_searchForm != null)
                    {
                        _searchForm.Close();
                        _searchForm = null;
                    }
                }
                return _searchForm;
            }
            set
            {
                if (_searchForm != null)
                {
                    _searchForm.Close();
                }
                _searchForm = value;
            }
        }

        #endregion

        public frmMain()
        {
            InitializeComponent();
            LoggerClass.Init();
            LoggerClass.Write("Application started...", Logger.LogLevels.Info);

            // Setup listviews
            ListViewSetColumns();
            listviewParts.DefaultRenderer = filterHighlightRenderer;
            listviewParts.AllowCheckWithSpace = false;

            // Set default filter type
            cbboxFilterType.SelectedIndex = 2;

            // Set number label
            UpdateNumberLabel();
            SetStatus("Idle...");

            frmSearch.OnFilterSet += FrmSearch_OnFilterSet;
        }

        #region Listviews and display

        /// <summary>
        /// Advanced filter callback
        /// </summary>
        private void FrmSearch_OnFilterSet(object sender, FilterEventArgs e)
        {
            // Clear filter on this form
            txtboxFilter.Clear();

            // Apply filter
            string txt = e.text;
            Part.Parameter filterIn = e.filterIn;
            string category = e.category;

            ObjectListView olv = listviewParts;
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txt))
            {
                switch (0)
                {
                    case 0:
                    default: // Anywhere
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1: // At the start
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2: // As a regex string
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }

            filterHighlightRenderer.FilterInColumn = null;
            if (filter != null)
            {
                OLVColumn column = null;

                switch (filterIn)
                {
                    case Part.Parameter.MPN:
                        column = olvcMPN;
                        break;
                    case Part.Parameter.Manufacturer:
                        column = olvcMAN;
                        break;
                    case Part.Parameter.Description:
                        column = olvcDesc;
                        break;
                    case Part.Parameter.Category:
                        column = olvcCat;
                        break;
                    case Part.Parameter.Location:
                        column = olvcLocation;
                        break;
                    case Part.Parameter.Stock:
                        column = olvcStock;
                        break;
                    case Part.Parameter.LowStock:
                        column = olvcLowStock;
                        break;
                    case Part.Parameter.Price:
                        column = olvcPrice;
                        break;
                    case Part.Parameter.Supplier:
                        column = olvcSupplier;
                        break;
                    case Part.Parameter.SPN:
                        column = olvcSPN;
                        break;
                    default:
                        break;
                }

                if (column != null)
                {
                    filter.Columns = new OLVColumn[] { column };
                }
                filterHighlightRenderer.FilterInColumn = column;
            }

            // Model filter clears all current filter on columns. This is what we want
            if (filter == null)
                olv.AdditionalFilter = null;
            else
                olv.AdditionalFilter = filter;

            if (!string.IsNullOrEmpty(category))
            {
                // Apply category filter
                olvcCat.ValuesChosenForFiltering = new string[] { category };
                olvcCat.UseFiltering = true;
            }
            else
            {
                olvcCat.UseFiltering = false;
            }
        }

        private void PartsHaveChanged()
        {
            // Save changes and update listview
            dhs.Instance.InvokeOnPartListModified(EventArgs.Empty);
            data.Save();
            UpdateListviews();

            // Update history if open
            if (historyForm != null)
            {
                historyForm.UpdateList();
            }
        }

        /// <summary>
        /// Set the title of the form
        /// </summary>
        private void SetTitle()
        {
            if (IsFileLoaded)
                this.Text = $"Stock Manager - {Path.GetFileName(filepath)}";
            else
                this.Text = "Stock Manager";
        }

        /// <summary>
        /// Update the label at the bottom that displays the number of parts
        /// </summary>
        private void UpdateNumberLabel()
        {
            if (!IsFileLoaded)
            {
                labelCount.Text = "No database open...";
            }
            else
            {
                labelCount.Text = $"{listviewParts.FilteredObjects.Cast<object>().Count()}/{Parts.Count}";
            }
        }

        /// <summary>
        /// Update the listviews contents
        /// </summary>
        /// <param name="resizeColumns">Resize the columns of the main listview</param>
        private void UpdateListviews(bool resizeColumns = false)
        {
            LoggerClass.Write($"Updating part listview..", Logger.LogLevels.Trace);
            // If not file loaded, set them to be empty
            if (!IsFileLoaded)
            {
                LoggerClass.Write($"No file loaded. Aborting...", Logger.LogLevels.Trace);
                listviewParts.DataSource = new List<Part>();
                listviewChecked.DataSource = new List<Part>();
                btnPartAdd.Enabled = btnPartDup.Enabled = false;
                return;
            }

            // Main list view : all parts
            listviewParts.DataSource = Parts.Values.ToList();

            btnPartDup.Enabled = (listviewParts.Items.Count != 0);
            btnPartAdd.Enabled = IsFileLoaded;

            // Resize columns if required
            if (resizeColumns)
            {
                LoggerClass.Write($"Resizing columns...", Logger.LogLevels.Trace);
                listviewParts.AutoResizeColumns();
            }
            // Set focus to main listview
            listviewParts.Focus();
            // Update the number label
            UpdateNumberLabel();
            // Update the checked listview
            UpdateCheckedListview();
            LoggerClass.Write($"Updating part listview finished", Logger.LogLevels.Trace);
        }

        /// <summary>
        /// Update the checked listview
        /// </summary>
        private void UpdateCheckedListview()
        {
            // Wether to update the checkedlistview or not. 
            // Usefull to disable when using the CheckAll and UnCheckAll actions
            // Otherwise, it will be called a lot of times...

            if (!UpdateOnCheck) // No updated required
                return;

            // Set the content to only the checked parts
            listviewChecked.DataSource = GetCheckedParts();

            btnCheckedPartDel.Enabled = (listviewChecked.Items.Count != 0);
        }

        /// <summary>
        /// Initialisation of the listviews
        /// </summary>
        /// <param name="listview"></param>
        private void ListViewSetColumns()
        {
            // Setup columns
            olvcMPN.AspectGetter = delegate (object x) { return ((Part)x).MPN; };
            olvcMAN.AspectGetter = delegate (object x) { return ((Part)x).Manufacturer; };
            olvcDesc.AspectGetter = delegate (object x) { return ((Part)x).Description; };
            olvcCat.AspectGetter = delegate (object x) { return ((Part)x).Category; };
            olvcLocation.AspectGetter = delegate (object x) { return ((Part)x).Location; };
            olvcStock.AspectGetter = delegate (object x) { return ((Part)x).Stock; };
            olvcLowStock.AspectGetter = delegate (object x) { return ((Part)x).LowStock; };
            olvcPrice.AspectGetter = delegate (object x) { return ((Part)x).Price; };
            olvcSupplier.AspectGetter = delegate (object x) { return ((Part)x).Supplier; };
            olvcSPN.AspectGetter = delegate (object x) { return ((Part)x).SPN; };

            olvcMPN2.AspectGetter = delegate (object x) { return ((Part)x).MPN; };
            olvcMAN2.AspectGetter = delegate (object x) { return ((Part)x).Manufacturer; };
            olvcDesc2.AspectGetter = delegate (object x) { return ((Part)x).Description; };
            olvcCat2.AspectGetter = delegate (object x) { return ((Part)x).Category; };
            olvcLocation2.AspectGetter = delegate (object x) { return ((Part)x).Location; };
            olvcStock2.AspectGetter = delegate (object x) { return ((Part)x).Stock; };
            olvcLowStock2.AspectGetter = delegate (object x) { return ((Part)x).LowStock; };
            olvcPrice2.AspectGetter = delegate (object x) { return ((Part)x).Price; };
            olvcSupplier2.AspectGetter = delegate (object x) { return ((Part)x).Supplier; };
            olvcSPN2.AspectGetter = delegate (object x) { return ((Part)x).SPN; };

            // Make the decoration
            RowBorderDecoration rbd = new RowBorderDecoration();
            rbd.BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2);
            rbd.BoundsPadding = new Size(1, 1);
            rbd.CornerRounding = 4.0f;

            // Put the decoration onto the hot item
            listviewParts.HotItemStyle = new HotItemStyle();
            listviewParts.HotItemStyle.BackColor = Color.Azure;
            listviewParts.HotItemStyle.Decoration = rbd;

            // Put the decoration onto the hot item
            listviewChecked.HotItemStyle = new HotItemStyle();
            listviewChecked.HotItemStyle.BackColor = Color.Azure;
            listviewChecked.HotItemStyle.Decoration = rbd;
        }

        #region TextFiltering

        /// <summary>
        /// Filter a text in the main part listview
        /// </summary>
        /// <param name="txt">Text to filter</param>
        /// <param name="matchKind">Type of filter</param>
        public void Filter(string txt, int matchKind)
        {
            ObjectListView olv = listviewParts;
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default: // Anywhere
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1: // At the start
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2: // As a regex string
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }

            olv.AdditionalFilter = filter;
        }

        /// <summary>
        /// Called when the filter text is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {
            Filter(txtboxFilter.Text, this.cbboxFilterType.SelectedIndex);
            UpdateNumberLabel();
        }

        /// <summary>
        /// Called when the filter type is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(txtboxFilter.Text, this.cbboxFilterType.SelectedIndex);
            UpdateNumberLabel();
        }

        #endregion
        #endregion

        #region ListView management

        /// <summary>
        /// Get the checked parts of the main listview. Note that they are also affected by filters.
        /// </summary>
        /// <returns></returns>
        private List<Part> GetCheckedParts()
        {
            return listviewParts.CheckedObjectsEnumerable.Cast<Part>().ToList();
        }

        /// <summary>
        /// Get all parts
        /// </summary>
        /// <returns></returns>
        private List<Part> GetAll()
        {
            return Parts.Values.ToList();
        }

        /// <summary>
        /// Return parts that will be processed in the next action
        /// </summary>
        /// <returns></returns>
        private List<Part> GetPartForProcess()
        {
            // If "onlyAffectCheckedParts" is checked, get checked parts. Otherwise all parts
            if (onlyAffectCheckedPartsToolStripMenuItem.Checked)
            {
                LoggerClass.Write($"Action executing on checked parts only...", Logger.LogLevels.Debug);
                return GetCheckedParts();
            }
            return GetAll();
        }

        /// <summary>
        /// 'hack' to check selected rows but call the CheckedChanged event only once
        /// </summary>
        private void ToggleCheckSelection()
        {
            bool state = listviewParts.IsChecked(listviewParts.SelectedObjects[0]);
            state = !state;

            UpdateOnCheck = false;
            if (state)
            {
                listviewParts.CheckObjects(listviewParts.SelectedObjects);
            }
            else
            {
                listviewParts.UncheckObjects(listviewParts.SelectedObjects);
            }
            UpdateOnCheck = true;
        }

        #endregion

        #region File management

        /// <summary>
        /// Import parts from excel file into the database
        /// </summary>
        private bool ImportFromExcel()
        {
            LoggerClass.Write($"Importing Excel file...", Logger.LogLevels.Debug);
            // A file must be loaded prior to importing.
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to load Excel file when no Data file is loaded", Logger.LogLevels.Debug);
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "All files|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            LoggerClass.Write($"File selected for Excel import : {ofd.FileName}", Logger.LogLevels.Debug);
            // Extract the parts. This is a hardcoded way
            Cursor = Cursors.WaitCursor;
            ExcelManager em = new ExcelManager(ofd.FileName);
            List<Part> importedParts = em.GetParts();
            em.Dispose();
            Cursor = Cursors.Default;

            if ((null == importedParts) || (0 == importedParts.Count))
            {
                LoggerClass.Write("No part found in that file");
                return false;
            }

            // Confirmation
            LoggerClass.Write($"{importedParts.Count} part(s) found in that file", Logger.LogLevels.Debug);
            if (MessageBox.Show($"Please confirm the additions of '{importedParts.Count}' parts to the current databse. This cannot be undone\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                return false;

            LoggerClass.Write($"Import confirmed. Processing...", Logger.LogLevels.Debug);
            // Add the parts to the list
            Cursor = Cursors.WaitCursor;
            foreach (Part importedPart in importedParts)
            {
                if (Parts.ContainsKey(importedPart.MPN))
                {
                    LoggerClass.Write($"Duplicate part found : MPN={importedPart.MPN}", Logger.LogLevels.Warn);
                    continue;
                }

                data.AddPart(importedPart);
            }
            Cursor = Cursors.Default;
            LoggerClass.Write($"Import finished", Logger.LogLevels.Debug);
            PartsHaveChanged();

            return true;
        }

        /// <summary>
        /// Create a new file with a template part
        /// </summary>
        private bool CreateNewFile()
        {
            LoggerClass.Write($"Creating new data file", Logger.LogLevels.Debug);
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };
            if (fsd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            LoggerClass.Write($"Filepath selected is : {fsd.FileName}", Logger.LogLevels.Debug);
            // Never overwrite files. Ask the user to manually delete the file...
            if (File.Exists(fsd.FileName))
            {
                LoggerClass.Write($"This file already exists. Aborting...", Logger.LogLevels.Debug);
                MessageBox.Show("This file already exists.\nPlease select another one or manually delete that file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LoggerClass.Write($"Creating data file at that path", Logger.LogLevels.Debug);
            // Save path
            filepath = fsd.FileName;
            // Create new empty file (with template part)
            dhs.LoadNew(filepath);
            SetTitle();
            // Update listviews content + resize columns
            UpdateListviews(true);
            LoggerClass.Write($"Creation finished", Logger.LogLevels.Debug);

            return true;
        }

        /// <summary>
        /// Open the specified file
        /// </summary>
        private bool OpenFile()
        {
            LoggerClass.Write($"Openning data file...", Logger.LogLevels.Debug);
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            LoggerClass.Write($"File selected : {ofd.FileName}", Logger.LogLevels.Debug);
            // Save path
            filepath = ofd.FileName;
            // Load the file
            LoggerClass.Write($"Openning that file...", Logger.LogLevels.Debug);
            try
            {
                dhs.LoadNew(filepath);
            }
            catch (Exception)
            {
                filepath = null;
                return false;
            }
            SetTitle();
            // Update listviews content + resize columns
            UpdateListviews(true);
            LoggerClass.Write($"Open finished. {Parts.Count} part(s) found", Logger.LogLevels.Debug);

            return true;
        }

        /// <summary>
        /// Close the currently open file
        /// </summary>
        private bool CloseFile()
        {
            LoggerClass.Write($"Closing file : {filepath}", Logger.LogLevels.Debug);
            data.Close();
            SetTitle();
            UpdateListviews();
            return true;
        }
        #endregion

        #region PartManagement

        /// <summary>
        /// Create a new empty part
        /// </summary>
        private void AddEmptyPart()
        {
            LoggerClass.Write($"Creating a new empty part...", Logger.LogLevels.Debug);
            // Ask the user for the MPN
            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the MPN (Manufacturer Product Number) for the part...", Title: "Enter input", Input: true, Btn2: Dialog.ButtonType.Cancel);

            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                LoggerClass.Write($"Operation cancelled. Aborting...", Logger.LogLevels.Debug);
                return;
            }

            LoggerClass.Write($"Adding a new part with MPN={result.UserInput}...", Logger.LogLevels.Debug);

            if (Parts.ContainsKey(result.UserInput))
            {
                LoggerClass.Write($"Unable to add the new part. The specified MPN is already present...", Logger.LogLevels.Error);
                MessageBox.Show("Unable to add the new part. The specified MPN is already present...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create empty part with the specified MPN
            Part pc = new Part()
            {
                MPN = result.UserInput,
            };

            // Add to list
            data.AddPart(pc);
            PartsHaveChanged();
            LoggerClass.Write($"Part added", Logger.LogLevels.Debug);
        }

        /// <summary>
        /// Delete the checked parts
        /// </summary>
        private void DeleteCheckedParts()
        {
            LoggerClass.Write($"Deletion of checked parts...", Logger.LogLevels.Debug);
            var checkedParts = GetCheckedParts();

            // If none checked, abort
            if (0 == checkedParts.Count)
            {
                LoggerClass.Write($"No parts checked. Aborting...", Logger.LogLevels.Debug);
                return;
            }

            // Ask confirmation
            if (MessageBox.Show($"Please confirm the deletion of '{checkedParts.Count}' parts. This cannot be undone !\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                LoggerClass.Write($"Confirmation denied", Logger.LogLevels.Debug);
                return;
            }

            LoggerClass.Write($"Deletion of {checkedParts.Count} part(s)...", Logger.LogLevels.Debug);
            // Remove them from the list
            checkedParts.ForEach((part) => data.DeletePart(part));
            LoggerClass.Write($"Deletion finished", Logger.LogLevels.Debug);
            PartsHaveChanged();
        }

        /// <summary>
        /// Duplicate the selected (not checked) part
        /// </summary>
        private void DuplicateSelectedPart()
        {
            LoggerClass.Write($"Duplicating selected part...", Logger.LogLevels.Debug);
            // Get selected part
            if (!(listviewParts.SelectedObject is Part pc))
            {
                LoggerClass.Write($"No selected part. Aborting...", Logger.LogLevels.Debug);
                return;
            }

            // Ask the user for the new MPN
            var result = Dialog.ShowDialog("Enter the new MPN (Manufacturer Product Number) for the part...", Title: "Enter input", Input: true, DefaultInput: pc.MPN, Btn2: Dialog.ButtonType.Cancel);

            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                LoggerClass.Write($"Operation cancelled. Aborting...", Logger.LogLevels.Debug);
                return;
            }

            LoggerClass.Write($"Duplicating the part...", Logger.LogLevels.Debug);

            if (Parts.ContainsKey(result.UserInput))
            {
                LoggerClass.Write($"Unable to duplicate the part. The specified MPN is already present...", Logger.LogLevels.Error);
                MessageBox.Show("Unable to duplicate the part. The specified MPN is already present...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clone the part and apply the new MPN
            pc = pc.Clone() as Part;
            pc.MPN = result.UserInput;

            // Add to the list
            data.AddPart(pc);
            PartsHaveChanged();
            LoggerClass.Write($"Cloning finished", Logger.LogLevels.Debug);
        }

        /// <summary>
        /// Custom event made to be called before determining the bounds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listviewParts_CellEditRequested(object sender, CellEditEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                return;
            }

            e.ListViewItem.Focused = true;
            Rectangle columnBounds = listviewParts.CalculateColumnVisibleBounds(listviewParts.Bounds, e.Column);
            int maxX = listviewParts.Width - 21; // Scroll bar + edges : 21 offset
            int rightSide = columnBounds.X + columnBounds.Width;
            int leftSide = columnBounds.X;

            int dx = 0;
            if (leftSide < 0)
            {
                // Scroll left
                dx = leftSide;
            }
            else if (rightSide > maxX)
            {
                // Scroll right
                dx = rightSide - maxX;
            }

            if (dx != 0)
            {
                Console.WriteLine($"scroll dx={dx}");
                listviewParts.PauseAnimations(true);
                listviewParts.LowLevelScroll(dx, 0);
                listviewParts.Invalidate();
                listviewParts.PauseAnimations(false);
            }
        }

        /// <summary>
        /// Called when a cell is edited
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private void listviewParts_CellEditFinished(object sender, CellEditEventArgs e)
        {
            // Get the unedited part version
            Part part = e.RowObject as Part;
            // Get the edited parameter and value
            Part.Parameter editedParameter = (Part.Parameter)(e.Column.Index);
            string newValue = e.NewValue.ToString();

            LoggerClass.Write($"Cell with MPN={part.MPN} edited : Parameter={editedParameter}, Newvalue={newValue}", Logger.LogLevels.Debug);
            if (editedParameter == Part.Parameter.UNDEFINED)
            {
                throw new InvalidOperationException("Unable to edit 'undefined'");
            }
            // Verify that an actual change is made
            if (part.Parameters[editedParameter]?.Equals(newValue) ?? false)
            {
                // No changes
                LoggerClass.Write("No change detected. Aborting...");
                return;
            }

            // Verify that the new MPN doesn't already exists
            if ((editedParameter == Part.Parameter.MPN) && Parts.ContainsKey(newValue))
            {
                LoggerClass.Write("Unable to edit MPN value. Another part already have this MPN value.", Logger.LogLevels.Error);
                MessageBox.Show("Unable to edit the MPN to the specified value. Another part with this MPN already exists...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            data.EditPart(part, editedParameter, newValue);

            PartsHaveChanged();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Make order for parts with 'stock' lower than 'lowStock'
        /// </summary>
        private bool ActionMakeOrder()
        {
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LoggerClass.Write($"Making automated order...", Logger.LogLevels.Debug);
            List<Part> parts = GetPartForProcess();
            // Select parts with current stock lower than lowStock limit
            IEnumerable<Part> selected = parts.Where((part) => (part.Stock < part.LowStock));

            // TODO : Actually make order
            LoggerClass.Write($"{selected.Count()} part(s) found for automatic order", Logger.LogLevels.Debug);
            Console.WriteLine(selected.Count() + " parts to order");

            return true;
        }

        private void ActionDigikeyProcessParts(List<CsvPartImport> records)
        {
            LoggerClass.Write($"{records.Count} part(s) found to process...");

            foreach (CsvPartImport item in records)
            {
                if (item == null)
                {
                    LoggerClass.Write("Null row found... Should not happen", Logger.LogLevels.Error);
                    continue;
                }

                if (string.IsNullOrEmpty(item.MPN))
                {
                    continue;
                }

                // Try converting quantity
                if (!float.TryParse(item.Quantity, out float quantity))
                {
                    LoggerClass.Write($"Unable to parse quantity : '{item.Quantity}'", Logger.LogLevels.Error);
                    continue;
                }

                if (!Parts.ContainsKey(item.MPN))
                {
                    LoggerClass.Write($"Part '{item.MPN}' not available in present list. Creating new part...");
                    Part p = new Part()
                    {
                        MPN = item.MPN,
                        Description = item.Description,
                        Category = "__automatically_generated",
                        Supplier = "Digikey",
                        SPN = item.SPN
                    };
                    data.AddPart(p);
                }

                // Process edit
                Part part = Parts[item.MPN];
                LoggerClass.Write($"Changing stock of '{part.MPN}' from {part.Stock} to {part.Stock + quantity}");
                data.EditPart(part, Part.Parameter.Stock, (part.Stock + quantity).ToString());
            }
        }

        private bool ActionImportDigikeyOrder()
        {
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel xlsx (*.xlsx, *.csv)|*.xlsx;*.csv|All files (*.*)|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            LoggerClass.Write($"Loading Digikey order...", Logger.LogLevels.Debug);

            string file = ofd.FileName;
            if (Path.GetExtension(file).Equals(".csv", StringComparison.InvariantCultureIgnoreCase))
            {
                // Read lines
                using (var reader = new StreamReader(file))
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
                            Quantity = csv.GetField("Quantity"),
                        };
                        // Read the rest only if required
                        if (!Parts.ContainsKey(record.MPN))
                        {
                            record.SPN = csv.GetField("Part Number");
                            record.Description = csv.GetField("Description");
                        }

                        records.Add(record);
                    }

                    ActionDigikeyProcessParts(records);
                }
            }
            else if (Path.GetExtension(file).Equals(".xlsx", StringComparison.InvariantCultureIgnoreCase))
            {

            }

            // Ask update of part list
            PartsHaveChanged();
            return true;
        }

        private bool ActionImportClipboardDigikeyOrder()
        {
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string content = Clipboard.GetText();

            LoggerClass.Write($"Loading Digikey order from clipboard...", Logger.LogLevels.Debug);

            try
            {
                // Separate by lines
                content = content.Replace("\r", "");
                string[] lines = content.Split('\n');

                if (lines.Length < 2)
                {
                    throw new InvalidOperationException("Unsufficient number of lines...");
                }

                List<CsvPartImport> records = new List<CsvPartImport>();

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] fields = line.Split('\t');
                    CsvPartImport part = new CsvPartImport()
                    {
                        MPN = fields[3],
                        Quantity = fields[1],
                        SPN = fields[2],
                        Description = fields[4],
                    };
                    records.Add(part);
                }


                ActionDigikeyProcessParts(records);

                // Ask update of part list
                PartsHaveChanged();

                return true;
            }
            catch (Exception)
            {
                LoggerClass.Write("Unable to load ordre from clipboard...", Logger.LogLevels.Error);
                MessageBox.Show("Unable to import order content from clipboard...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ActionExportParts()
        {
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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
                LoggerClass.Write($"Unable to export... File already exists", Logger.LogLevels.Debug);
                MessageBox.Show("Unable to export parts. The selected file already exists...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            LoggerClass.Write($"Exporting parts...", Logger.LogLevels.Debug);
            List<Part> parts = GetPartForProcess();

            LoggerClass.Write($"{parts.Count} part(s) found for export", Logger.LogLevels.Debug);

            Dictionary<string, Part> exportParts = new Dictionary<string, Part>();
            parts.ForEach((p) => exportParts.Add(p.MPN, p));
            DataExportClass dec = new DataExportClass(exportParts, null);

            SettingsManager.SaveTo(fsd.FileName, dec, backup: false, indent: true, zipFile: true);

            return true;
        }

        public bool ActionImportParts()
        {
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Ask save path
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            LoggerClass.Write($"Importing parts...", Logger.LogLevels.Debug);

            SettingsManager.LoadFrom(ofd.FileName, out DataExportClass dec, isZipped: true);

            if ((dec == null) || (dec.Parts == null) || (dec.Parts.Count == 0))
            {
                LoggerClass.Write("No data found...");
                MessageBox.Show("No data found in this file...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            LoggerClass.Write($"{dec.Parts.Count} part(s) found to import...");

            // Confirmation
            if (MessageBox.Show($"Please confirm the additions of '{dec.Parts.Count}' parts to the current databse. This cannot be undone\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                return false;

            int partCounter = 0;
            foreach (Part part in dec.Parts)
            {
                if (data.AddPart(part))
                {
                    partCounter++;
                }
                else
                {
                    LoggerClass.Write($"Part MPN='{part.MPN}' already present... Skipped");
                }
            }

            PartsHaveChanged();
            SetStatus($"{partCounter}/{dec.Parts.Count} part(s) imported !", Color.Blue);
            MessageBox.Show($"{partCounter}/{dec.Parts.Count} part(s) imported !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
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
        private void SetWorkingStatus()
        {
            SetStatus("Working...");
            labelStatus.Invalidate();
        }
        private void SetSuccessStatus(bool result)
        {
            SetStatus(result ? "Success !" : "Failed", result ? SystemColors.ControlText : Color.Red);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoggerClass.Write("Closing... Stopping logger", Logger.LogLevels.Info);
            LoggerClass.logger.Dispose();
        }
        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ImportFromExcel();
            SetSuccessStatus(result);
        }
        private void makeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ActionMakeOrder();
            SetSuccessStatus(result);
        }
        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = CreateNewFile();
            SetSuccessStatus(result);
        }
        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = OpenFile();
            SetSuccessStatus(result);
        }
        private void listviewParts_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateCheckedListview();
        }
        private void checkAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check all in view
            UpdateOnCheck = false;
            listviewParts.CheckObjects(listviewParts.FilteredObjects);
            listviewParts.Focus();
            UpdateOnCheck = true;
        }
        private void uncheckAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uncheck all in view
            UpdateOnCheck = false;
            listviewParts.UncheckObjects(listviewParts.FilteredObjects);
            listviewParts.Focus();
            UpdateOnCheck = true;
        }
        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = CloseFile();
            SetSuccessStatus(result);
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void importOrderFromDigikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ActionImportDigikeyOrder();
            SetSuccessStatus(result);
        }
        private void importOrderFromDigikeyFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ActionImportClipboardDigikeyOrder();
            SetSuccessStatus(result);
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggerClass.Write($"Openning project window...", Logger.LogLevels.Debug);
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to open projects, no file loaded...", Logger.LogLevels.Error);
                return;
            }

            // Open projects form
            projectForm.Show();
            projectForm.BringToFront();
        }
        private void openHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggerClass.Write($"Openning history window...", Logger.LogLevels.Debug);
            if (!IsFileLoaded)
            {
                LoggerClass.Write("Unable to open history, no file loaded...", Logger.LogLevels.Error);
                return;
            }

            // Open projects form
            historyForm.Show();
            historyForm.BringToFront();
        }
        private void _projectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the project form is closed, bring to fron the main form
            this.BringToFront();
            _projectForm = null;
        }

        private void _historyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the history form is closed, bring to fron the main form
            this.BringToFront();
            _historyForm = null;
        }
        private void _searchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the history form is closed, bring to fron the main form
            this.BringToFront();
            _searchForm = null;
        }
        private void listviewParts_KeyDown(object sender, KeyEventArgs e)
        {
            // 'hack' to check selected rows but call the CheckedChanged event only once
            if (e.KeyCode == Keys.Space)
            {
                ToggleCheckSelection();
            }
        }
        private void listviewParts_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            // When rightclicking a cell, copy the MPN of the corresponding row
            if (!(e.Model is Part selectedPart))
            {
                return;
            }

            Clipboard.SetText(selectedPart.MPN);
            SetStatus("Copied to clipboard...");
        }
        private void btnPartAdd_Click(object sender, EventArgs e)
        {
            AddEmptyPart();
            listviewParts.Focus();
        }

        private void btnPartDup_Click(object sender, EventArgs e)
        {
            DuplicateSelectedPart();
            listviewParts.Focus();
        }

        private void btnCheckedPartDel_Click(object sender, EventArgs e)
        {
            DeleteCheckedParts();
            listviewParts.Focus();
        }

        private void resizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listviewParts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewChecked.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void statusTimeoutTimer_Tick(object sender, EventArgs e)
        {
            statusTimeoutTimer.Stop();
            labelStatus.ForeColor = SystemColors.ControlText;
            labelStatus.Text = string.Empty;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.Save();
        }
        private void exportPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Export the parts
            ActionExportParts();
        }
        private void importPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionImportParts();
        }
        private void advancedSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFileLoaded)
                return;

            searchForm.Show();
        }

        #endregion
    }
}
