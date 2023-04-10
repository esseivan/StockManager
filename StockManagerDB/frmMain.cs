using BrightIdeasSoftware;
using ESNLib.Controls;
using ESNLib.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private ListManager myList;

        /// <summary>
        /// List of parts in the database
        /// </summary>
        private ListPlus<PartClass> Parts => myList.Data.Parts;

        /// <summary>
        /// Indicate if a file is loaded
        /// </summary>
        private bool IsFileLoaded => (null != myList);

        /// <summary>
        /// Update CheckListView when checkItemChanged
        /// </summary>
        private bool UpdateOnCheck = true;

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
                        _projectForm = new frmProjects(filepath);
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

        #endregion

        public frmMain()
        {
            InitializeComponent();
            LoggerClass.Init();
            LoggerClass.Write("Application started...", Logger.LogLevels.Info);

            ListManager.OnPartsListModified += ListManager_OnPartsListModified;

            // Setup listviews
            ListViewSetColumns();
            listviewParts.DefaultRenderer = filterHighlightRenderer;

            // Set default filter type
            cbboxFilterType.SelectedIndex = 2;

            // Set number label
            UpdateNumberLabel();
        }

        #region Listviews and display

        /// <summary>
        /// Called when the list is modified in any way
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListManager_OnPartsListModified(object sender, EventArgs e)
        {
            myList.Save(); // Save the changes
            UpdateListviews(); // Update listviews contents
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
            if (myList == null)
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
            // If not file loaded, set them to be empty
            if (!IsFileLoaded)
            {
                listviewParts.DataSource = new List<PartClass>();
                listviewChecked.DataSource = new List<PartClass>();
                return;
            }

            // Main list view : all parts
            listviewParts.DataSource = Parts;
            // Resize columns if required
            if (resizeColumns)
            {
                listviewParts.AutoResizeColumns();
            }
            // Set focus to main listview
            listviewParts.Focus();
            // Update the number label
            UpdateNumberLabel();
            // Update the checked listview
            UpdateCheckedListview();
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
        }

        /// <summary>
        /// Initialisation of the listviews
        /// </summary>
        /// <param name="listview"></param>
        private void ListViewSetColumns()
        {
            // Setup columns
            olvcMPN.AspectGetter = delegate (object x) { return ((PartClass)x).MPN; };
            olvcMAN.AspectGetter = delegate (object x) { return ((PartClass)x).Manufacturer; };
            olvcDesc.AspectGetter = delegate (object x) { return ((PartClass)x).Description; };
            olvcCat.AspectGetter = delegate (object x) { return ((PartClass)x).Category; };
            olvcLocation.AspectGetter = delegate (object x) { return ((PartClass)x).Location; };
            olvcStock.AspectGetter = delegate (object x) { return ((PartClass)x).Stock; };
            olvcLowStock.AspectGetter = delegate (object x) { return ((PartClass)x).LowStock; };
            olvcPrice.AspectGetter = delegate (object x) { return ((PartClass)x).Price; };
            olvcSupplier.AspectGetter = delegate (object x) { return ((PartClass)x).Supplier; };
            olvcSPN.AspectGetter = delegate (object x) { return ((PartClass)x).SPN; };

            olvcMPN2.AspectGetter = delegate (object x) { return ((PartClass)x).MPN; };
            olvcMAN2.AspectGetter = delegate (object x) { return ((PartClass)x).Manufacturer; };
            olvcDesc2.AspectGetter = delegate (object x) { return ((PartClass)x).Description; };
            olvcCat2.AspectGetter = delegate (object x) { return ((PartClass)x).Category; };
            olvcLocation2.AspectGetter = delegate (object x) { return ((PartClass)x).Location; };
            olvcStock2.AspectGetter = delegate (object x) { return ((PartClass)x).Stock; };
            olvcLowStock2.AspectGetter = delegate (object x) { return ((PartClass)x).LowStock; };
            olvcPrice2.AspectGetter = delegate (object x) { return ((PartClass)x).Price; };
            olvcSupplier2.AspectGetter = delegate (object x) { return ((PartClass)x).Supplier; };
            olvcSPN2.AspectGetter = delegate (object x) { return ((PartClass)x).SPN; };
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
        private List<PartClass> GetCheckedParts()
        {
            return listviewParts.CheckedObjectsEnumerable.Cast<PartClass>().ToList();
        }

        /// <summary>
        /// Get all parts
        /// </summary>
        /// <returns></returns>
        private List<PartClass> GetAll()
        {
            return Parts;
        }

        /// <summary>
        /// Return parts that will be processed in the next action
        /// </summary>
        /// <returns></returns>
        private List<PartClass> GetPartForProcess()
        {
            // If "onlyAffectCheckedParts" is checked, get checked parts. Otherwise all parts
            if (onlyAffectCheckedPartsToolStripMenuItem.Checked)
                return GetCheckedParts();
            return GetAll();
        }

        #endregion

        #region File management

        /// <summary>
        /// Import parts from excel file into the database
        /// </summary>
        private void ImportFromExcel()
        {
            // A file must be loaded prior to importing.
            if (!IsFileLoaded)
            {
                MessageBox.Show("No file loaded ! Open or create a new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "All files|*.*",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Extract the parts. This is a hardcoded way
                Cursor = Cursors.WaitCursor;
                ExcelManager em = new ExcelManager(ofd.FileName);
                List<PartClass> p = em.GetParts();
                Cursor = Cursors.Default;

                if ((null == p) || (0 == p.Count))
                {
                    LoggerClass.Write("No part found");
                    return;
                }

                // Confirmation
                if (MessageBox.Show($"Please confirm the additions of '{p.Count}' parts to the current databse. This cannot be undone\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                // Add the parts to the list
                Cursor = Cursors.WaitCursor;
                Parts.AddRange(p);
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Create a new file with a template part
        /// </summary>
        private void CreateNewFile()
        {
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager File|*.smf|All files|*.*",
            };
            if (fsd.ShowDialog() == DialogResult.OK)
            {
                // Never overwrite files. Ask the user to manually delete the file...
                if (File.Exists(fsd.FileName))
                {
                    MessageBox.Show("This file already exists.\nPlease select another one or manually delete that file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save path
                filepath = fsd.FileName;
                // Create new empty file (with template part)
                myList = ListManager.CreateNew(filepath, true);
                SetTitle();
                // Update listviews content + resize columns
                UpdateListviews(true);
            }
        }

        /// <summary>
        /// Open the specified file
        /// </summary>
        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager File|*.smf|All files|*.*",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Save path
                filepath = ofd.FileName;
                // Load the file
                myList = new ListManager(filepath);
                SetTitle();
                // Update listviews content + resize columns
                UpdateListviews(true);
            }
        }

        /// <summary>
        /// Close the currently open file
        /// </summary>
        private void CloseFile()
        {
            myList = null;
            SetTitle();
            UpdateListviews();
        }
        #endregion

        #region PartManagement

        /// <summary>
        /// Create a new empty part
        /// </summary>
        private void AddEmptyPart()
        {
            // Ask the user for the MPN
            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the MPN (Manufacturer Product Number) for the part...", Title: "Enter input", Input: true, Btn2: Dialog.ButtonType.Cancel);

            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            // Create empty part with the specified MPN
            PartClass pc = new PartClass()
            {
                MPN = result.UserInput,
            };

            // Add to list
            Parts.Add(pc);
        }

        /// <summary>
        /// Delete the checked parts
        /// </summary>
        private void DeleteCheckedParts()
        {
            var checkedParts = GetCheckedParts();

            // If none checked, abort
            if (0 == checkedParts.Count)
            {
                return;
            }

            // Ask confirmation
            if (MessageBox.Show($"Please confirm the deletion of '{checkedParts.Count}' parts. This cannot be undone !\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            // Remove them from the list
            Parts.RemoveRange(checkedParts);
        }

        /// <summary>
        /// Duplicate the selected (not checked) part
        /// </summary>
        private void DuplicateSelectedPart()
        {
            // Get selected part
            PartClass pc = listviewParts.SelectedObject as PartClass;
            if (pc == null)
                return;
            
            // Ask the user for the new MPN
            var result = Dialog.ShowDialog("Enter the new MPN (Manufacturer Product Number) for the part...", Title: "Enter input", Input: true, Btn2: Dialog.ButtonType.Cancel);

            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            // Clone the part and apply the new MPN
            pc = pc.Clone() as PartClass;
            pc.MPN = result.UserInput;

            // Add to the list
            Parts.Add(pc);
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
            PartClass part = e.RowObject as PartClass;
            // Get the edited parameter and value
            PartClass.Parameter editedParameter = (PartClass.Parameter)(e.Column.Index);
            string newValue = e.NewValue.ToString();

            if (editedParameter == PartClass.Parameter.UNDEFINED)
            {
                throw new InvalidOperationException("Unable to edit 'undefined'");
            }

            // Apply the changes to the part
            part.Parameters[editedParameter] = newValue;
            myList.Save();

            UpdateListviews();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Make order for parts with 'stock' lower than 'lowStock'
        /// </summary>
        private void MakeOrder()
        {
            List<PartClass> parts = GetPartForProcess();
            // Select parts with current stock lower than lowStock limit
            IEnumerable<PartClass> selected = parts.Where((part) => (part.Stock < part.LowStock));

            // TODO : Actually make order
            Console.WriteLine(selected.Count() + " parts to order");
        }

        #endregion

        #region Misc Events

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoggerClass.Write("Closing... Stopping logger", Logger.LogLevels.Info);
            LoggerClass.logger.Dispose();
        }
        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
        }
        private void makeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeOrder();
        }
        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewFile();
        }
        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
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

            UpdateCheckedListview();
        }
        private void uncheckAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uncheck all in view
            UpdateOnCheck = false;
            listviewParts.UncheckObjects(listviewParts.FilteredObjects);
            listviewParts.Focus();
            UpdateOnCheck = true;

            UpdateCheckedListview();
        }
        private void DELETECheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCheckedParts();
        }
        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void importOrderFromDigikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            throw new NotImplementedException();
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open projects form
            projectForm.Show();
        }
        private void _projectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the project form is closed, bring to fron the main form
            this.BringToFront();
            _projectForm = null;
        }
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            AddEmptyPart();
        }
        private void btnDuplicatePart_Click(object sender, EventArgs e)
        {
            DuplicateSelectedPart();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DeleteCheckedParts();
        }

        #endregion

    }
}
