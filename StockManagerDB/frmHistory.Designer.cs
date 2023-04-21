namespace StockManagerDB
{
    partial class frmHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listviewParts = new BrightIdeasSoftware.FastDataListView();
            this.olvcMPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcMAN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCat = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcStock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLowStock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSupplier = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcValidFrom = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcValidUntil = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.filterHighlightRenderer = new BrightIdeasSoftware.HighlightTextRenderer();
            this.olvcNote = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).BeginInit();
            this.SuspendLayout();
            // 
            // listviewParts
            // 
            this.listviewParts.AllColumns.Add(this.olvcMPN);
            this.listviewParts.AllColumns.Add(this.olvcMAN);
            this.listviewParts.AllColumns.Add(this.olvcDesc);
            this.listviewParts.AllColumns.Add(this.olvcCat);
            this.listviewParts.AllColumns.Add(this.olvcLocation);
            this.listviewParts.AllColumns.Add(this.olvcStock);
            this.listviewParts.AllColumns.Add(this.olvcLowStock);
            this.listviewParts.AllColumns.Add(this.olvcPrice);
            this.listviewParts.AllColumns.Add(this.olvcSupplier);
            this.listviewParts.AllColumns.Add(this.olvcSPN);
            this.listviewParts.AllColumns.Add(this.olvcValidFrom);
            this.listviewParts.AllColumns.Add(this.olvcValidUntil);
            this.listviewParts.AllColumns.Add(this.olvcStatus);
            this.listviewParts.AllColumns.Add(this.olvcVersion);
            this.listviewParts.AllColumns.Add(this.olvcNote);
            this.listviewParts.AllowCheckWithSpace = true;
            this.listviewParts.AllowColumnReorder = true;
            this.listviewParts.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewParts.AutoGenerateColumns = false;
            this.listviewParts.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.listviewParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcMPN,
            this.olvcMAN,
            this.olvcDesc,
            this.olvcCat,
            this.olvcLocation,
            this.olvcStock,
            this.olvcLowStock,
            this.olvcPrice,
            this.olvcSupplier,
            this.olvcSPN,
            this.olvcValidFrom,
            this.olvcValidUntil,
            this.olvcStatus,
            this.olvcVersion,
            this.olvcNote});
            this.listviewParts.Cursor = System.Windows.Forms.Cursors.Default;
            this.listviewParts.DataSource = null;
            this.listviewParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listviewParts.EmptyListMsg = "(Empty)";
            this.listviewParts.FullRowSelect = true;
            this.listviewParts.GridLines = true;
            this.listviewParts.HideSelection = false;
            this.listviewParts.Location = new System.Drawing.Point(0, 0);
            this.listviewParts.Margin = new System.Windows.Forms.Padding(2);
            this.listviewParts.Name = "listviewParts";
            this.listviewParts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewParts.ShowCommandMenuOnRightClick = true;
            this.listviewParts.ShowGroups = false;
            this.listviewParts.ShowImagesOnSubItems = true;
            this.listviewParts.Size = new System.Drawing.Size(953, 450);
            this.listviewParts.SortGroupItemsByPrimaryColumn = false;
            this.listviewParts.TabIndex = 7;
            this.listviewParts.TintSortColumn = true;
            this.listviewParts.UseAlternatingBackColors = true;
            this.listviewParts.UseCompatibleStateImageBehavior = false;
            this.listviewParts.UseFilterIndicator = true;
            this.listviewParts.UseFiltering = true;
            this.listviewParts.UseHotItem = true;
            this.listviewParts.UseHyperlinks = true;
            this.listviewParts.UseTranslucentHotItem = true;
            this.listviewParts.View = System.Windows.Forms.View.Details;
            this.listviewParts.VirtualMode = true;
            // 
            // olvcMPN
            // 
            this.olvcMPN.Text = "Manufacturer PN";
            this.olvcMPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcMAN
            // 
            this.olvcMAN.Text = "Manufacturer";
            this.olvcMAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcDesc
            // 
            this.olvcDesc.Text = "Description";
            this.olvcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcCat
            // 
            this.olvcCat.Text = "Category";
            this.olvcCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcLocation
            // 
            this.olvcLocation.Text = "Location";
            this.olvcLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcStock
            // 
            this.olvcStock.MinimumWidth = 75;
            this.olvcStock.Text = "Stock";
            this.olvcStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcStock.Width = 75;
            // 
            // olvcLowStock
            // 
            this.olvcLowStock.MinimumWidth = 75;
            this.olvcLowStock.Text = "LowStock";
            this.olvcLowStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcLowStock.Width = 75;
            // 
            // olvcPrice
            // 
            this.olvcPrice.MinimumWidth = 75;
            this.olvcPrice.Text = "Price";
            this.olvcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcPrice.Width = 75;
            // 
            // olvcSupplier
            // 
            this.olvcSupplier.Text = "Supplier";
            this.olvcSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcSPN
            // 
            this.olvcSPN.Text = "SPN";
            this.olvcSPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcValidFrom
            // 
            this.olvcValidFrom.Text = "Valid From";
            this.olvcValidFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcValidUntil
            // 
            this.olvcValidUntil.Text = "Valid Until";
            this.olvcValidUntil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcStatus
            // 
            this.olvcStatus.Text = "Status";
            this.olvcStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcVersion
            // 
            this.olvcVersion.Text = "Version";
            this.olvcVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcNote
            // 
            this.olvcNote.Text = "Note";
            this.olvcNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.listviewParts);
            this.Name = "frmHistory";
            this.Text = "History";
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView listviewParts;
        private BrightIdeasSoftware.OLVColumn olvcMPN;
        private BrightIdeasSoftware.OLVColumn olvcMAN;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvcCat;
        private BrightIdeasSoftware.OLVColumn olvcLocation;
        private BrightIdeasSoftware.OLVColumn olvcStock;
        private BrightIdeasSoftware.OLVColumn olvcLowStock;
        private BrightIdeasSoftware.OLVColumn olvcPrice;
        private BrightIdeasSoftware.OLVColumn olvcSupplier;
        private BrightIdeasSoftware.OLVColumn olvcSPN;
        private BrightIdeasSoftware.HighlightTextRenderer filterHighlightRenderer;
        private BrightIdeasSoftware.OLVColumn olvcValidFrom;
        private BrightIdeasSoftware.OLVColumn olvcValidUntil;
        private BrightIdeasSoftware.OLVColumn olvcStatus;
        private BrightIdeasSoftware.OLVColumn olvcVersion;
        private BrightIdeasSoftware.OLVColumn olvcNote;
    }
}