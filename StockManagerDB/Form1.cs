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

namespace StockManagerDB
{
    public partial class Form1 : Form
    {
        const string Filename = "myDB.sqlite";
        DBWrapper dbw = new DBWrapper(Filename);
        private FastDataListView partLV;
        ExcelManager em = new ExcelManager(@"C:\Workspace\01_Programming\StockManagerExcelBased\Import.xlsx");

        List<PartClass> parts => dbw.PartsList;

        public Form1()
        {
            InitializeComponent();

            partLV = fdlviewParts;
            InitListView(partLV);
        }

        private void DisplayParts()
        {
            partLV.DataSource = dbw.PartsList;
            partLV.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbw.CreateDatabase(true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbw.LoadDatabaseList();
            parts.ForEach((x) => Console.WriteLine(x.ToString()));

            DisplayParts();
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
            DisplayParts();
        }
    }
}
