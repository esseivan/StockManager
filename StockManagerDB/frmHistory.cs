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
using dhsh = StockManagerDB.DataHolderHistorySingleton;

namespace StockManagerDB
{
    public partial class frmHistory : Form
    {
        private dhsh data => dhsh.Instance;

        private List<Part> History => data.PartHistory;

        public frmHistory()
        {
            InitializeComponent();

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
            RowBorderDecoration rbd = new RowBorderDecoration();
            rbd.BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2);
            rbd.BoundsPadding = new Size(1, 1);
            rbd.CornerRounding = 4.0f;

            // Put the decoration onto the hot item
            listviewParts.HotItemStyle = new HotItemStyle();
            listviewParts.HotItemStyle.BackColor = Color.Azure;
            listviewParts.HotItemStyle.Decoration = rbd;
        }
    }
}
