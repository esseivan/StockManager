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
        List<PartClass> parts = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dbw.CreateDatabase(true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parts = dbw.LoadDatabase();
            parts.ForEach((x) => Console.WriteLine(x.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parts[0].Stock += 0.02f;

            dbw.UpdatePart(parts[0]);
        }
    }
}
