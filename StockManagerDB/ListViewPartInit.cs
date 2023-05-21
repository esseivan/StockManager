using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public abstract class ListViewInit
    {
        public static void InitListPart(FastDataListView olv)
        {
            olv.AllowCheckWithSpace = true;
            olv.AllowColumnReorder = true;
            olv.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            olv.AutoGenerateColumns = false;
            olv.CellEditActivation = BrightIdeasSoftware
                .ObjectListView
                .CellEditActivateMode
                .DoubleClick;
            olv.CheckBoxes = true;
            olv.Cursor = System.Windows.Forms.Cursors.Default;
            olv.DataSource = null;
            olv.EmptyListMsg = "(Empty)";
            olv.FullRowSelect = true;
            olv.GridLines = true;
            olv.HideSelection = false;
            olv.Margin = new System.Windows.Forms.Padding(2);
            olv.Name = "listviewParts";
            olv.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware
                .ObjectListView
                .ColumnSelectBehaviour
                .Submenu;
            olv.ShowCommandMenuOnRightClick = true;
            olv.ShowGroups = false;
            olv.ShowImagesOnSubItems = true;
            olv.SortGroupItemsByPrimaryColumn = false;
            olv.TabIndex = 6;
            olv.TintSortColumn = true;
            olv.UseAlternatingBackColors = true;
            olv.UseCompatibleStateImageBehavior = false;
            olv.UseFilterIndicator = true;
            olv.UseFiltering = true;
            olv.UseHotItem = true;
            olv.UseHyperlinks = true;
            olv.UseTranslucentHotItem = true;
            olv.View = System.Windows.Forms.View.Details;
            olv.VirtualMode = true;

            //
            // olvcSelect
            //
            OLVColumn olvcSelect = new OLVColumn();
            olvcSelect.IsEditable = false;
            olvcSelect.MaximumWidth = 22;
            olvcSelect.MinimumWidth = 22;
            olvcSelect.Text = "";
            olvcSelect.Width = 22;
            //
            // olvcMPN
            //
            OLVColumn olvcMPN = new OLVColumn();
            olvcMPN.MinimumWidth = 20;
            olvcMPN.Text = "Manufacturer PN";
            olvcMPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // olvcMAN
            //
            OLVColumn olvcMAN = new OLVColumn();
            olvcMAN.MinimumWidth = 20;
            olvcMAN.Text = "Manufacturer";
            olvcMAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // olvcDesc
            //
            OLVColumn olvcDesc = new OLVColumn();
            olvcDesc.MinimumWidth = 20;
            olvcDesc.Text = "Description";
            olvcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // olvcCat
            //
            OLVColumn olvcCat = new OLVColumn();
            olvcCat.MinimumWidth = 20;
            olvcCat.Text = "Category";
            olvcCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // olvcLocation
            //
            OLVColumn olvcLocation = new OLVColumn();
            olvcLocation.MinimumWidth = 20;
            olvcLocation.Text = "Location";
            olvcLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // olvcStock
            //
            OLVColumn olvcStock = new OLVColumn();
            olvcStock.MinimumWidth = 20;
            olvcStock.Text = "Stock";
            olvcStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            olvcStock.Width = 75;
            //
            // olvcLowStock
            //
            OLVColumn olvcLowStock = new OLVColumn();
            olvcLowStock.MinimumWidth = 20;
            olvcLowStock.Text = "LowStock";
            olvcLowStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            olvcLowStock.Width = 75;
            //
            // olvcPrice
            //
            OLVColumn olvcPrice = new OLVColumn();
            olvcPrice.MinimumWidth = 20;
            olvcPrice.Text = "Price";
            olvcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            olvcPrice.Width = 75;
            //
            // olvcSupplier
            //
            OLVColumn olvcSupplier = new OLVColumn();
            olvcSupplier.MinimumWidth = 20;
            olvcSupplier.Text = "Supplier";
            olvcSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // olvcSPN
            //
            OLVColumn olvcSPN = new OLVColumn();
            olvcSPN.MinimumWidth = 20;
            olvcSPN.Text = "SPN";
            olvcSPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            List<OLVColumn> columns = new List<OLVColumn>()
            {
                olvcSelect,
                olvcMPN,
                olvcMAN,
                olvcDesc,
                olvcCat,
                olvcLocation,
                olvcStock,
                olvcLowStock,
                olvcPrice,
                olvcSupplier,
                olvcSPN,
            };
            olv.AllColumns.AddRange(columns);
            olv.Columns.AddRange(columns.Cast<ColumnHeader>().ToArray());

            // Setup aspect getters

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

            // Make the decoration
            RowBorderDecoration rbd = new RowBorderDecoration
            {
                BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2),
                BoundsPadding = new Size(1, 1),
                CornerRounding = 4.0f
            };

            // Put the decoration onto the hot item
            olv.HotItemStyle = new HotItemStyle { BackColor = Color.Azure, Decoration = rbd };
        }
    }
}
