using BrightIdeasSoftware;
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
        /// <summary>
        /// filepath to the database
        /// </summary>
        private string filepath = string.Empty;

        /// <summary>
        /// Manage the lists
        /// </summary>
        private ListManager myList;

        /// <summary>
        /// The listview where the parts are displayed
        /// </summary>
        private readonly FastDataListView partLV;

        /// <summary>
        /// List of parts in the database
        /// </summary>
        public List<PartClass> Parts => myList.Data.Parts;

        /// <summary>
        /// Indicate if a DB is open
        /// </summary>
        private bool IsDBOpen => (null != myList);

        /// <summary>
        /// Update CheckListView when checkItemChanged
        /// </summary>
        private bool UpdateOnCheck = true;

        private frmProjects _projectForm = null;
        private frmProjects projectForm
        {
            get
            {
                if (IsDBOpen)
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

        private void _projectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.BringToFront();
            _projectForm = null;
        }

        public frmMain()
        {
            InitializeComponent();
            LoggerClass.Init();
            LoggerClass.Write("Idle");

#warning What to do with that ?
            //DBWrapper.OnListModified += Dbw_OnListModified;

            partLV = listviewParts;
            InitListView(partLV);
            partLV.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            partLV.CellEditUseWholeCell = true;
            InitListView(listviewChecked);

            cbboxFilterType.SelectedIndex = 2;

            UpdateCountLabel();
        }

        #region Display

        private void UpdateCountLabel()
        {
            if (myList == null)
            {
                labelCount.Text = "No database open...";
            }
            else
            {
                labelCount.Text = $"{partLV.FilteredObjects.Cast<object>().Count()}/{Parts.Count}";
            }
        }

        private void UpdateDisplay(bool resize = false)
        {
            if (!IsDBOpen)
            {
                partLV.DataSource = new List<PartClass>();
                return;
            }

            partLV.DataSource = Parts;
            //partLV.DataSource = parts;
            if (resize)
            {
                partLV.AutoResizeColumns();
            }
            partLV.Focus();

            UpdateCountLabel();

            UpdateCheckedListview();
        }

        #endregion

        #region ListView management

        private void InitListView(FastDataListView listview)
        {
            listview.View = View.Details;
            listview.GridLines = true;
            listview.FullRowSelect = true;

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

        private List<PartClass> GetCheckedParts()
        {
            return partLV.CheckedObjectsEnumerable.Cast<PartClass>().ToList();
        }

        private List<PartClass> GetAll()
        {
            return Parts;
        }

        /// <summary>
        /// Return parts that will be validation for the action
        /// </summary>
        /// <returns></returns>
        private List<PartClass> GetPartForProcess()
        {
            if (onlyAffectCheckedPartsToolStripMenuItem.Checked)
                return GetCheckedParts();
            return GetAll();
        }

        #endregion

        /// <summary>
        /// Import parts from excel file into the database
        /// </summary>
        private void ImportFromExcel()
        {
            if (!IsDBOpen)
            {
                MessageBox.Show("No database selected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "All files|*.*",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                ExcelManager em = new ExcelManager(ofd.FileName);
                List<PartClass> p = em.GetParts();
                Cursor = Cursors.Default;

                if ((null == p) || (0 == p.Count))
                {
                    LoggerClass.Write("No part found");
                    return;
                }

                if (MessageBox.Show($"Please confirm the additions of '{p.Count}' parts to the current databse. This cannot be undone\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                // Add all
                Cursor = Cursors.WaitCursor;
                Parts.AddRange(p);
                myList.Save();
                //dbw.AddPartRange(p);
                Cursor = Cursors.Default;
                UpdateDisplay();
            }
        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
        }

        /// <summary>
        /// Create a new empty database
        /// </summary>
        private void CreateNewDatabase()
        {
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager File|*.smf|All files|*.*",
            };
            if (fsd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fsd.FileName))
                {
                    MessageBox.Show("This file already exists. Please select another one...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                filepath = fsd.FileName;
                myList = ListManager.CreateNew(filepath, true);
                myList.OnPartsListModified += MyList_OnPartsListModified;

                //dbw = new DBWrapper(filepath);
                //dbw.CreateDatabase(true);
                SetTitle();
                UpdateDisplay(true);
            }
        }

        private void MyList_OnPartsListModified(object sender, EventArgs e)
        {
            myList.Save();
            UpdateDisplay();
        }

        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewDatabase();
        }

        private void SetTitle()
        {
            if (IsDBOpen)
                this.Text = $"Stock Manager - {Path.GetFileName(filepath)}";
            else
                this.Text = "Stock Manager";
        }

        /// <summary>
        /// Open the specified database
        /// </summary>
        private void OpenDatabase()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager File|*.smf|All files|*.*",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                myList = new ListManager(filepath);
                myList.OnPartsListModified += MyList_OnPartsListModified;
                //dbw = new DBWrapper(filepath);
                //dbw.LoadDatabase();
                SetTitle();
                UpdateDisplay(true);
            }
        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }

        /// <summary>
        /// Filter a text in the part list
        /// </summary>
        /// <param name="txt">Text to filter</param>
        /// <param name="matchKind">Type of filter</param>
        public void Filter(string txt, int matchKind)
        {
            ObjectListView olv = partLV;
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default:
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1:
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2:
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }

            // Text highlighting requires at least a default renderer
            if (olv.DefaultRenderer == null)
                olv.DefaultRenderer = new HighlightTextRenderer(filter);

            olv.AdditionalFilter = filter;
        }

        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {
            Filter(((TextBox)sender).Text, this.cbboxFilterType.SelectedIndex);
            UpdateCountLabel();
        }

        private void cbboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(txtboxFilter.Text, this.cbboxFilterType.SelectedIndex);
            UpdateCountLabel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoggerClass.Write("Closing... Stopping logger", "Info");
            LoggerClass.logger.Dispose();
        }

        /// <summary>
        /// Delete the checked parts
        /// </summary>
        private void DeleteCheckedParts()
        {
            var checkedParts = GetCheckedParts();

            if (MessageBox.Show($"Please confirm the deletion of '{checkedParts.Count}' parts. This cannot be undone !\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            myList.Data.Parts.RemoveRange(checkedParts);
            myList.Save();
        }

        #region Actions

        private void MakeOrder()
        {
            List<PartClass> parts = GetPartForProcess();
            // Select parts with current stock lower than lowStock limit
            var selected = parts.Where((part) => (part.Stock < part.LowStock));

            Console.WriteLine(selected.Count() + " parts to order");
        }

        #endregion

        private void makeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeOrder();
        }

        private void UpdateCheckedListview()
        {
            if (!UpdateOnCheck)
                return;

            List<PartClass> checkedParts = GetCheckedParts();
            listviewChecked.DataSource = checkedParts;
        }

        private void listviewParts_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateCheckedListview();
        }

        private void checkAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOnCheck = false;
            //partLV.CheckAll();
            partLV.CheckObjects(partLV.FilteredObjects);
            partLV.Focus();
            UpdateOnCheck = true;
            UpdateCheckedListview();
        }

        private void uncheckAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateOnCheck = false;
            //partLV.UncheckAll();
            partLV.UncheckObjects(partLV.FilteredObjects);
            partLV.Focus();
            UpdateOnCheck = true;
            UpdateCheckedListview();
        }

        private void DELETECheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCheckedParts();
        }

        private void listviewParts_CellEditFinished(object sender, CellEditEventArgs e)
        {
            PartClass part = e.RowObject as PartClass;
            PartClass.Parameter editedParameter = (PartClass.Parameter)(e.Column.Index);
            string newValue = e.NewValue.ToString();
            if (editedParameter == PartClass.Parameter.UNDEFINED)
            {
                throw new InvalidOperationException("Unable to edit 'undefined'");
            }
            else
            {
                // Apply manually the new value
                part.Parameters[editedParameter] = newValue;
                myList.Save();
                //dbw.UpdatePart(part);
            }

            UpdateDisplay();
            UpdateCheckedListview();
        }

        private void CloseDatabase()
        {
            //dbw = null;
            myList = null;
            UpdateDisplay();
            SetTitle();
        }

        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseDatabase();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importOrderFromDigikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectForm == null)
                return;
            projectForm.Show();
        }

        private void AddEmptyPart()
        {
            var result = ESNLib.Controls.Dialog.ShowDialog("Enter the MPN (Manufacturer Product Number) for the part...", Title: "Enter input", Input: true, Btn2: ESNLib.Controls.Dialog.ButtonType.Cancel);

            if (result.DialogResult != ESNLib.Controls.Dialog.DialogResult.OK)
            {
                return;
            }

            PartClass pc = new PartClass()
            {
                MPN = result.UserInput,
            };
            myList.Data.Parts.Add(pc);
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            AddEmptyPart();
        }

        private void DuplicateSelectedPart()
        {
            // Get selected part, not checked
            PartClass pc = partLV.SelectedObject as PartClass;
            if (pc == null)
                return;

            var result = ESNLib.Controls.Dialog.ShowDialog("Enter the new MPN (Manufacturer Product Number) for the part...", Title: "Enter input", Input: true, Btn2: ESNLib.Controls.Dialog.ButtonType.Cancel);

            if (result.DialogResult != ESNLib.Controls.Dialog.DialogResult.OK)
            {
                return;
            }

            pc = pc.Clone() as PartClass;
            pc.MPN = result.UserInput;
            myList.Data.Parts.Add(pc);
        }

        private void btnDuplicatePart_Click(object sender, EventArgs e)
        {
            DuplicateSelectedPart();
        }

        private void addToProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }
    }
}
