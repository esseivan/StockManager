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

        /// <summary>
        /// Filter set event
        /// </summary>
        public static event EventHandler<FilterEventArgs> OnFilterSet;

        public frmSearch()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            listviewCategories.Items.AddRange(Parts.Select((p) => p.Category).Distinct().Select((p) => new ListViewItem(p)).ToArray());
            listviewCategories.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewCategories.SelectedIndices.Add(0);

            listviewType.Items.Clear();
            listviewType.Items.AddRange(Enum.GetNames(typeof(Part.Parameter)).Select((x) => new ListViewItem(x)).ToArray());
            listviewType.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewType.SelectedIndices.Add(0);
        }

        private void InvokeOnFilterSet()
        {
            if(listviewType.SelectedIndices.Count == 0)
            {
                return;
            }

            var args = new FilterEventArgs()
            {
                text = textBox1.Text,
                category = (listviewCategories.SelectedItems.Count > 0 ? listviewCategories.SelectedItems[0].Text : null),
            };

            args.filterIn = (Part.Parameter)Enum.Parse(typeof(Part.Parameter), listviewType.SelectedItems[0].Text);

            OnFilterSet?.Invoke(this, args);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (listviewType.SelectedIndices.Count == 0)
            {
                listviewType.SelectedIndices.Add(0);
            }

            InvokeOnFilterSet();
        }

        private void listviewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(listviewType.SelectedIndices.Count.ToString());
            if (listviewType.SelectedIndices.Count == 0)
            {
                return;
            }

            InvokeOnFilterSet();
        }

        private bool RuntimeTextboxEdit = false;
        private void listviewCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RuntimeTextboxEdit)
            {
                RuntimeTextboxEdit = false;
                return;
            }

            RuntimeTextboxEdit = true;
            if (listviewCategories.SelectedIndices.Count == 0)
            {
                txtboxCategory.Text = string.Empty;
                return;
            }

            txtboxCategory.Text = listviewCategories.SelectedItems[0].Text;

            InvokeOnFilterSet();
        }

        private void txtboxCategory_TextChanged(object sender, EventArgs e)
        {
            if (RuntimeTextboxEdit)
            {
                RuntimeTextboxEdit = false;
                return;
            }
            RuntimeTextboxEdit = true;
            listviewCategories.SelectedIndices.Clear();

            InvokeOnFilterSet();
        }
    }

    public class FilterEventArgs : EventArgs
    {
        public string text;
        public string category;
        public Part.Parameter filterIn;
    }
}
