using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// filepath to the database
        /// </summary>
        private string filepath = string.Empty;
        /// <summary>
        /// Manage the database
        /// </summary>
        private DBWrapper dbw
        {
            get => _dbw;
            set
            {
                _dbw = value;
                _dbw.OnListModified += Dbw_OnListModified;
            }
        }
        private DBWrapper _dbw = null;
        /// <summary>
        /// The listview where the parts are displayed
        /// </summary>
        private readonly FastDataListView partLV;


        const string Filename = "myDB.sqlite";
        ExcelManager em = new ExcelManager(@"C:\Workspace\01_Programming\StockManagerExcelBased\Import.xlsx");

        public List<PartClass> parts => dbw.PartsList;

        /// <summary>
        /// Indicate if a DB is open
        /// </summary>
        private bool IsDBOpen => (null != dbw);

        public Form1()
        {
            InitializeComponent();

            partLV = fdlviewParts;
            InitListView(partLV);
        }

        #region Display

        private void UpdateDisplay()
        {
            partLV.DataSource = parts;
            partLV.AutoResizeColumns();
        }

        private void Dbw_OnListModified(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            dbw.CreateDatabase(true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbw.LoadDatabaseList();
            parts.ForEach((x) => Console.WriteLine(x.ToString()));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            parts[0].Stock += 0.02f;

            dbw.UpdatePart(parts[0]);
        }

        #region ListView management

        private void InitListView(FastDataListView listview)
        {
            listview.View = View.Details;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            listview.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            listview.CellEditUseWholeCell = true;

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
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            dbw.CreateDatabase();
            dbw.LoadDatabaseList();
            PartClass newPart = new PartClass() { MPN = "T1", Stock = 2, Location = "D003" };
            bool res = dbw.AddPart(newPart);
            if (!res)
            {
                Console.WriteLine("Unable to add part, already existing : " + newPart.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
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
                ExcelManager em = new ExcelManager(ofd.FileName);
                List<PartClass> p = em.GetParts();

                if ((null == p) || (0 == p.Count))
                {
                    LoggerClass.Write("No part found");
                    return;
                }

                if (MessageBox.Show($"Please confirm the additions of '{p.Count}' parts to the current databse. This cannot be undone\nContinue ?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                // Add all
                dbw.AddPartRange(p);
            }
        }

        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "sqlite|*.sqlite|All files|*.*",
            };
            if (fsd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fsd.FileName))
                {
                    MessageBox.Show("This file already exists. Please select another one...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                filepath = fsd.FileName;
                dbw = new DBWrapper(filepath);
                dbw.CreateDatabase(true);
            }
        }


        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "sqlite|*.sqlite|All files|*.*",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                dbw = new DBWrapper(filepath);
                dbw.LoadDatabase();
            }
        }
    }
}
