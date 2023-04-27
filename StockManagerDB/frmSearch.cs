using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public event EventHandler<FilterEventArgs> OnFilterSet;

        private readonly bool IsReady = false;

        private readonly Type enumType;

        public frmSearch()
        {
            InitializeComponent();

            enumType = typeof(Part.Parameter);
            InitLists();

            cbboxFilterType.SelectedIndex = 0;

            IsReady = true;
        }
        public frmSearch(Type enumType)
        {
            InitializeComponent();

            this.enumType = enumType;
            InitLists();

            cbboxFilterType.SelectedIndex = 0;

            IsReady = true;
        }

        private void InitLists(bool haveCategories = true)
        {
            if (haveCategories)
            {
                List<string> categories = Parts.Select((p) => p.Category).Distinct().ToList();
                categories.Sort();

                listviewCategories.Items.AddRange(categories.Select((p) => new ListViewItem(p)).ToArray());
                listviewCategories.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
            {
                this.Controls.Remove(listviewCategories);
                this.Controls.Remove(label3);
                this.Controls.Remove(txtboxCategory);
                this.Controls.Remove(btnClearCat);
            }

            listviewType.Items.Clear();
            listviewType.Items.AddRange(Enum.GetNames(enumType).Select((x) => new ListViewItem(x)).ToArray());
            listviewType.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listviewType.SelectedIndices.Add(0);
        }

        private void InvokeOnFilterSet()
        {
            if (listviewType.SelectedIndices.Count == 0)
            {
                return;
            }

            var args = new FilterEventArgs
            {
                text = txtboxFilter.Text,
                category = (listviewCategories.SelectedItems.Count > 0 ? listviewCategories.SelectedItems[0].Text : null),
                filterType = cbboxFilterType.SelectedIndex,
                filterIn = Enum.Parse(enumType, listviewType.SelectedItems[0].Text)
            };

            OnFilterSet?.Invoke(this, args);
        }

        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {
            if (listviewType.SelectedIndices.Count == 0)
            {
                listviewType.SelectedIndices.Add(0);
            }

            InvokeOnFilterSet();
        }

        private void listviewType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!IsReady)
                return;

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

        private void btnClearCat_Click(object sender, EventArgs e)
        {
            txtboxCategory.Clear();
        }

        private void cbboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsReady)
                return;

            InvokeOnFilterSet();
        }
    }

    public class FilterEventArgs : EventArgs
    {
        public string text;
        public string category;
        public object filterIn;
        public int filterType;
    }
}
