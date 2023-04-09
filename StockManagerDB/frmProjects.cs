using BrightIdeasSoftware;
using ESNLib.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public partial class frmProjects : Form
    {
        private readonly DBProjectsWrapper dbpw;
        private readonly string Filepath;

        private List<string> projects;

        /// <summary>
        /// The listview where the parts are displayed
        /// </summary>
        private readonly FastDataListView compLV;

        public frmProjects(string filepath)
        {
            InitializeComponent();

            compLV = listviewComponents;
            InitListView(compLV);
            compLV.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            compLV.CellEditUseWholeCell = true;

            this.Filepath = filepath;
            dbpw = new DBProjectsWrapper(Filepath);
            dbpw.OnListModified += Dbpw_OnListModified;
            dbpw.LoadComponents();
        }

        #region ListView Init

        private void InitListView(FastDataListView listview)
        {
            listview.View = View.Details;
            listview.GridLines = true;
            listview.FullRowSelect = true;

            // Setup columns
            olvcMPN.AspectGetter = delegate (object x) { return ((ComponentClass)x).MPN; };
            olvcQuantity.AspectGetter = delegate (object x) { return ((ComponentClass)x).Quantity; };
            olvcReference.AspectGetter = delegate (object x) { return ((ComponentClass)x).Reference; };
            olvcMAN.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Manufacturer; };
            olvcDesc.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Description; };
            olvcCat.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Category; };
            olvcLocation.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Location; };
            olvcStock.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Stock; };
            olvcLowStock.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.LowStock; };
            olvcPrice.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Price; };
            olvcSupplier.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.Supplier; };
            olvcSPN.AspectGetter = delegate (object x) { return ((ComponentClass)x).PartLink?.SPN; };
        }

        #endregion

        private void PopulateLists()
        {
            string textPrevious = comboBox1.Text;
            projects = dbpw.Components.Keys.ToList();
            comboBox1.DataSource = projects;
            comboBox1.Text = textPrevious;
        }

        private void Dbpw_OnListModified(object sender, EventArgs e)
        {
            PopulateLists();
        }

        private void CreateNewProject()
        {
            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the name for the project", Title: "Enter name", Input: true, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            dbpw.CreateProject(result.UserInput);
        }

        private void RenameProject(string currentName)
        {
            if (currentName == null)
                return;

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the new name for the project", Title: "Enter new name", Input: true, DefaultInput: currentName, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            dbpw.RenameProject(currentName, result.UserInput);
        }

        private void DuplicateProject(string currentName)
        {
            if (currentName == null)
                return;

            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the name for the duplicated project", Title: "Enter new name", Input: true, DefaultInput: currentName, Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            dbpw.DuplicateProject(result.UserInput, currentName);
        }

        private string GetSelectedProjectName()
        {
            if (comboBox1.SelectedIndex == -1)
                return null;
            return comboBox1.SelectedItem.ToString();
        }

        private void listviewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewProject();
        }

        private void renameSelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameProject(GetSelectedProjectName());
        }

        private void duplicateSelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DuplicateProject(GetSelectedProjectName());
        }

        private void DELETESelectedProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UpdateComponentList(string selectedProject)
        {
            compLV.DataSource = dbpw.Components[selectedProject];
            compLV.AutoResizeColumns();
            compLV.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProject = GetSelectedProjectName();

            if (selectedProject == null)
                return;

            UpdateComponentList(selectedProject);
        }
    }
}
