using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dhs = StockManagerDB.DataHolderSingleton;

namespace StockManagerDB
{
    public partial class frmSearch : Form
    {
        /// <summary>
        /// Manage the lists
        /// </summary>
        private dhs data => dhs.Instance;

        /// <summary>
        /// List of parts in the database
        /// </summary>
        private List<Part> Parts => data.Parts.Values.ToList();

        public frmSearch()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            listView1.Items.AddRange(
                Parts.Select((p) => new ListViewItem(p.Category)).Distinct().ToArray()
            );
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
