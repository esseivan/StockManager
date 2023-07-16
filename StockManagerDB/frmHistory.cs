using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using dhsh = StockManagerDB.DataHolderHistorySingleton;

namespace StockManagerDB
{
    public partial class frmHistory : Form
    {
        private dhsh data => dhsh.Instance;

        private List<Part> History => data.PartHistory;

        private frmSearch search = null;

        public void ApplySettings()
        {
            this.Font = AppSettings.Settings.AppFont;
        }

        public frmHistory()
        {
            InitializeComponent();

            ApplySettings();

            ListViewSetColumns();
            listviewParts.DefaultRenderer = filterHighlightRenderer;

            UpdateList();
            listviewParts.AutoResizeColumns();
        }

        public void UpdateList()
        {
            listviewParts.DataSource = null;
            listviewParts.DataSource = History;
        }

        /// <summary>
        /// Initialisation of the listviews
        /// </summary>
        /// <param name="listview"></param>
        private void ListViewSetColumns()
        {
            // Setup columns
            olvcMPN.AspectGetter = delegate(object x)
            {
                return ((Part)x).MPN;
            };
            olvcMAN.AspectGetter = delegate(object x)
            {
                return ((Part)x).Manufacturer;
            };
            olvcDesc.AspectGetter = delegate(object x)
            {
                return ((Part)x).Description;
            };
            olvcCat.AspectGetter = delegate(object x)
            {
                return ((Part)x).Category;
            };
            olvcLocation.AspectGetter = delegate(object x)
            {
                return ((Part)x).Location;
            };
            olvcStock.AspectGetter = delegate(object x)
            {
                return ((Part)x).Stock;
            };
            olvcLowStock.AspectGetter = delegate(object x)
            {
                return ((Part)x).LowStock;
            };
            olvcPrice.AspectGetter = delegate(object x)
            {
                return ((Part)x).Price;
            };
            olvcSupplier.AspectGetter = delegate(object x)
            {
                return ((Part)x).Supplier;
            };
            olvcSPN.AspectGetter = delegate(object x)
            {
                return ((Part)x).SPN;
            };

            olvcValidFrom.AspectGetter = delegate(object x)
            {
                return ((Part)x).ValidFrom;
            };
            olvcValidUntil.AspectGetter = delegate(object x)
            {
                return ((Part)x).ValidUntil;
            };
            olvcStatus.AspectGetter = delegate(object x)
            {
                return ((Part)x).Status;
            };
            olvcVersion.AspectGetter = delegate(object x)
            {
                return ((Part)x).Version;
            };
            olvcNote.AspectGetter = delegate(object x)
            {
                return ((Part)x).note;
            };

            // Make the decoration
            RowBorderDecoration rbd = new RowBorderDecoration
            {
                BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2),
                BoundsPadding = new Size(1, 1),
                CornerRounding = 4.0f
            };

            // Put the decoration onto the hot item
            listviewParts.HotItemStyle = new HotItemStyle
            {
                BackColor = Color.Azure,
                Decoration = rbd
            };
        }

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
        /// Clear all filtering for the parts
        /// </summary>
        private void ClearAdvancedFiltering()
        {
            olvcCat.UseFiltering = false;
            olvcCat.ValuesChosenForFiltering = null;
            // Must define to non null first to update categories
            listviewParts.AdditionalFilter = new TextMatchFilter(listviewParts);
            listviewParts.AdditionalFilter = null;
        }

        /// <summar
        private void cbboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(txtboxFilter.Text, this.cbboxFilterType.SelectedIndex);
        }

        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {
            Filter(txtboxFilter.Text, this.cbboxFilterType.SelectedIndex);
        }

        private void btnAdv_Click(object sender, EventArgs e)
        {
            if (search == null)
            {
                search = new frmSearch(typeof(AdvancedPartParameters));
                search.OnFilterSet += Search_OnFilterSet;
                search.FormClosed += Search_FormClosed;
                search.Text = "History Advanced Filter";
            }

            search.Show();
        }

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the history form is closed, bring to fron the main form
            this.BringToFront();
            search = null;
            ClearAdvancedFiltering();
        }

        private void Search_OnFilterSet(object sender, FilterEventArgs e)
        {
            this.BringToFront();
            search.BringToFront();

            // Clear filter on this form
            txtboxFilter.Clear();

            // Apply filter
            string txt = e.text;
            AdvancedPartParameters filterIn = (AdvancedPartParameters)e.filterIn;
            string category = e.category;

            ObjectListView olv = listviewParts;
            TextMatchFilter filter = null;
            if (!string.IsNullOrEmpty(txt))
            {
                switch (e.filterType)
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

            filterHighlightRenderer.FilterInColumn = null;
            if (filter != null)
            {
                OLVColumn column = null;

                switch (filterIn)
                {
                    case AdvancedPartParameters.MPN:
                        column = olvcMPN;
                        break;
                    case AdvancedPartParameters.Manufacturer:
                        column = olvcMAN;
                        break;
                    case AdvancedPartParameters.Description:
                        column = olvcDesc;
                        break;
                    case AdvancedPartParameters.Category:
                        column = olvcCat;
                        break;
                    case AdvancedPartParameters.Location:
                        column = olvcLocation;
                        break;
                    case AdvancedPartParameters.Stock:
                        column = olvcStock;
                        break;
                    case AdvancedPartParameters.LowStock:
                        column = olvcLowStock;
                        break;
                    case AdvancedPartParameters.Price:
                        column = olvcPrice;
                        break;
                    case AdvancedPartParameters.Supplier:
                        column = olvcSupplier;
                        break;
                    case AdvancedPartParameters.SPN:
                        column = olvcSPN;
                        break;
                    case AdvancedPartParameters.ValidFrom:
                        column = olvcValidFrom;
                        break;
                    case AdvancedPartParameters.ValidUntil:
                        column = olvcValidUntil;
                        break;
                    case AdvancedPartParameters.Status:
                        column = olvcStatus;
                        break;
                    case AdvancedPartParameters.Version:
                        column = olvcVersion;
                        break;
                    case AdvancedPartParameters.Note:
                        column = olvcNote;
                        break;
                    default:
                        break;
                }

                if (column != null)
                {
                    filter.Columns = new OLVColumn[] { column };
                }
                filterHighlightRenderer.FilterInColumn = column;
            }

            if (!string.IsNullOrEmpty(category))
            {
                // Apply category filter
                olvcCat.ValuesChosenForFiltering = new string[] { category };
                olvcCat.UseFiltering = true;
            }
            else
            {
                olvcCat.UseFiltering = false;
            }

            olv.AdditionalFilter = filter ?? new TextMatchFilter(olv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listviewParts.AutoResizeColumns();
        }

        public enum AdvancedPartParameters
        {
            UNDEFINED,
            MPN,
            Manufacturer,
            Description,
            Category,
            Location,
            Stock,
            LowStock,
            Price,
            Supplier,
            SPN,
            ValidFrom,
            ValidUntil,
            Status,
            Version,
            Note,
        }

        private void frmHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (search != null)
            {
                search.Close();
            }
        }

        private void listviewParts_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            // When rightclicking a cell, copy the MPN of the corresponding row
            if (!(e.Model is Material))
            {
                return;
            }

            contextMenuStrip1.Show(Cursor.Position);
        }

        private void copyMPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewParts.SelectedObject is Part part))
            {
                return;
            }

            part.CopyMPNToClipboard();
        }

        private void openSupplierUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewParts.SelectedObject is Part part))
            {
                return;
            }

            part.OpenSupplierUrl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string helpText = @"Each line is a change made to a part, and is a clone of that part before the change.
The new (and present) state is not in this list as it is the valid one.

There are some more columns to give more informations :
    'Valid From' and 'Valid Until' : Indicate the date span at which this line was valid
    'Status' : Indicate additional information for the part. 
        'Inserted' when the part is new
        'Deleted' when the part was deleted
        'MPN Changed to ...' when the MPN of the part has changed
    'Version' : Indicate the version (revision) of the line (part)
    'Note' : Indicate what made a change to this part. Empty for manual change.";

            MessageBox.Show(helpText, "Information");
        }

        private void copySPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewParts.SelectedObject is Part part))
            {
                return;
            }

            part.CopySPNToClipboard();
        }
    }
}
