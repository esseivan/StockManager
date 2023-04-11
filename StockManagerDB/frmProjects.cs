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

namespace StockManagerDB
{
    public partial class frmProjects : Form
    {
        private List<string> projects = new List<string>();

        private readonly ListManager myList;
        private List<PartClass> Parts => myList.Data.Parts;
        private ListPlus<ComponentClass> Components => myList.Data.Components;

        public frmProjects(ListManager listmanager)
        {
            this.myList = listmanager;

            InitializeComponent();

            ListViewSetColumns();

            ListManager.OnPartsListModified += ListManager_OnPartsListModified;
            ListManager.OnComponentsListModified += ListManager_OnComponentsListModified;
        }

        private void ListManager_OnComponentsListModified(object sender, EventArgs e)
        {
            myList.Save();
            PopulateLists();
        }

        private void ListManager_OnPartsListModified(object sender, EventArgs e)
        {
            PopulateLists();
        }

        #region ListView Init

        private void ListViewSetColumns()
        {
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
            List<string> allParents = Components.Select((comp) => comp.Parent).ToList();
            // Remove duplicates
            projects.Clear();
            allParents.ForEach((parent) =>
            {
                if (!projects.Contains(parent))
                    projects.Add(parent);
            });

            comboBox1.DataSource = projects;
            comboBox1.Text = textPrevious;

            UpdateComponentList();
        }

        /// <summary>
        /// Get the components for the specified project parent
        /// </summary>
        /// <param name="parent">The project</param>
        /// <returns></returns>
        private List<ComponentClass> GetComponents(string parent)
        {
            List<ComponentClass> selectedComponents = Components.Where((comp) => comp.Parent.Equals(parent)).ToList();
            return selectedComponents;
        }


        private void CreateNewProject()
        {
            Dialog.ShowDialogResult result = Dialog.ShowDialog("Enter the name for the project", Title: "Enter name", Input: true, DefaultInput: "Project", Btn1: Dialog.ButtonType.OK, Btn2: Dialog.ButtonType.Cancel);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }

            // Add dummy component
            ComponentClass dummy = new ComponentClass()
            {
                Parent = result.UserInput,
                MPN = "Template",
                Quantity = 0,
                Reference = "R1"
            };

            Components.Add(dummy);
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

            List<ComponentClass> projectComponents = GetComponents(currentName);
            projectComponents.ForEach((comp) => comp.Parent = result.UserInput);
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

            List<ComponentClass> projectComponents = GetComponents(currentName);
            // Clone them all
            List<ComponentClass> newComponents = projectComponents.Select((comp) => comp.Clone() as ComponentClass).ToList();
            // Apply new parent
            newComponents.ForEach((comp) => comp.Parent = result.UserInput);
            // Add to list
            Components.AddRange(newComponents);
        }

        private string GetSelectedProjectName()
        {
            if (comboBox1.SelectedIndex == -1)
                return null;
            return comboBox1.SelectedItem.ToString();
        }

        private void DeleteProject()
        {
            string project = GetSelectedProjectName();
            if (project == null)
            {
                return;
            }

            List<ComponentClass> projectComponents = GetComponents(project);
            Components.RemoveRange(projectComponents);
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
            DeleteProject();
        }

        private void UpdateComponentList()
        {
            string selectedProject = GetSelectedProjectName();

            if (selectedProject == null)
            {
                listviewComponents.DataSource = new List<ComponentClass>();
                return;
            }

            listviewComponents.DataSource = GetComponents(selectedProject);
            //listviewComponents.AutoResizeColumns();
            listviewComponents.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComponentList();
        }

        private void UpdateComponent(ComponentClass oldComponent, ComponentClass newComponent)
        {
            DeleteComponent(oldComponent);
            AddComponent(newComponent);
        }

        private void listviewComponents_CellEditFinished(object sender, CellEditEventArgs e)
        {
            ComponentClass oldComponent = e.RowObject as ComponentClass;

            ComponentClass.Parameter editedParameter = (ComponentClass.Parameter)(e.Column.Index + 1);
            ComponentClass newComponent = oldComponent.Clone() as ComponentClass;
            string newValue = e.NewValue.ToString();
            newComponent.Parameters[editedParameter] = newValue;

            if (editedParameter == ComponentClass.Parameter.UNDEFINED)
            {
                throw new InvalidOperationException("Unable to edit 'undefined'");
            }
            else
            {
                // Apply manually the new value
                UpdateComponent(oldComponent, newComponent);
            }

            UpdateComponentList();
        }

        private void AddComponent(ComponentClass component)
        {
            Components.Add(component);
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            string project = GetSelectedProjectName();
            if (project == null)
                return;

            ComponentClass newComponent = new ComponentClass()
            {
                Parent = project,
                MPN = "NA",
                Quantity = 0,
                Reference = "NA"
            };

            AddComponent(newComponent);
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (listviewComponents.SelectedIndex == -1)
                return;

            string project = GetSelectedProjectName();
            if (project == null)
                return;

            // Get selected component
            ComponentClass component = listviewComponents.SelectedObject as ComponentClass;

            int selectedIndexBefore = listviewComponents.SelectedIndex;
            AddComponent(component.Clone() as ComponentClass);
            listviewComponents.SelectedIndex = selectedIndexBefore;
        }

        private void DeleteComponent(ComponentClass component)
        {
            // Remove old component from list and add new 
            if (!Components.Contains(component))
            {
                LoggerClass.Write("Unable to delete component. Not found", ESNLib.Tools.Logger.LogLevels.Error);
                return;
            }

            Components.Remove(component);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listviewComponents.SelectedIndex == -1)
                return;

            string project = GetSelectedProjectName();
            if (project == null)
                return;

            // Get selected component
            ComponentClass component = listviewComponents.SelectedObject as ComponentClass;

            int selectedIndexBefore = listviewComponents.SelectedIndex;
            DeleteComponent(component);
            if (selectedIndexBefore >= listviewComponents.Items.Count)
                selectedIndexBefore--;
            listviewComponents.SelectedIndex = selectedIndexBefore;
        }

        private void duplicateAllCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string project = GetSelectedProjectName();
            if (project == null)
                return;

            // Get all checked
            List<ComponentClass> objects = listviewComponents.CheckedObjectsEnumerable.Cast<ComponentClass>().ToList();
            IEnumerable<ComponentClass> newComponents = objects.Select((comp) => comp.Clone() as ComponentClass);

            Components.AddRange(newComponents);
        }

        private void RemoveComponentsFromParent(string parent, IEnumerable<ComponentClass> components)
        {
            List<ComponentClass> projectComponents = GetComponents(parent);

            IEnumerable<ComponentClass> selectedComponents = projectComponents.Intersect(components);

            Components.RemoveRange(selectedComponents);
        }

        private void DELETEAllCheckedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string project = GetSelectedProjectName();
            if (project == null)
                return;

            // Get all checked
            var objects = listviewComponents.CheckedObjectsEnumerable.Cast<ComponentClass>();

            RemoveComponentsFromParent(project, objects);
        }
    }
}
