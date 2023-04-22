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
            this.olvcNote = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.filterHighlightRenderer = new BrightIdeasSoftware.HighlightTextRenderer();
            this.label4 = new System.Windows.Forms.Label();
            this.cbboxFilterType = new System.Windows.Forms.ComboBox();
            this.txtboxFilter = new System.Windows.Forms.TextBox();
            this.btnAdv = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.listviewParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewParts.AutoGenerateColumns = false;
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
            this.listviewParts.EmptyListMsg = "(Empty)";
            this.listviewParts.FullRowSelect = true;
            this.listviewParts.GridLines = true;
            this.listviewParts.HideSelection = false;
            this.listviewParts.Location = new System.Drawing.Point(11, 38);
            this.listviewParts.Margin = new System.Windows.Forms.Padding(2);
            this.listviewParts.Name = "listviewParts";
            this.listviewParts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewParts.ShowCommandMenuOnRightClick = true;
            this.listviewParts.ShowGroups = false;
            this.listviewParts.ShowImagesOnSubItems = true;
            this.listviewParts.Size = new System.Drawing.Size(931, 401);
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Filter";
            // 
            // cbboxFilterType
            // 
            this.cbboxFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbboxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxFilterType.FormattingEnabled = true;
            this.cbboxFilterType.Items.AddRange(new object[] {
            "Any text",
            "Prefix",
            "Regex"});
            this.cbboxFilterType.Location = new System.Drawing.Point(848, 12);
            this.cbboxFilterType.Name = "cbboxFilterType";
            this.cbboxFilterType.Size = new System.Drawing.Size(94, 21);
            this.cbboxFilterType.TabIndex = 12;
            this.cbboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbboxFilterType_SelectedIndexChanged);
            // 
            // txtboxFilter
            // 
            this.txtboxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxFilter.Location = new System.Drawing.Point(742, 13);
            this.txtboxFilter.Name = "txtboxFilter";
            this.txtboxFilter.Size = new System.Drawing.Size(100, 20);
            this.txtboxFilter.TabIndex = 11;
            this.txtboxFilter.TextChanged += new System.EventHandler(this.txtboxFilter_TextChanged);
            // 
            // btnAdv
            // 
            this.btnAdv.Location = new System.Drawing.Point(626, 10);
            this.btnAdv.Name = "btnAdv";
            this.btnAdv.Size = new System.Drawing.Size(75, 23);
            this.btnAdv.TabIndex = 14;
            this.btnAdv.Text = "Advanced";
            this.btnAdv.UseVisualStyleBackColor = true;
            this.btnAdv.Click += new System.EventHandler(this.btnAdv_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Auto resize columns";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbboxFilterType);
            this.Controls.Add(this.txtboxFilter);
            this.Controls.Add(this.listviewParts);
            this.Name = "frmHistory";
            this.Text = "History";
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbboxFilterType;
        private System.Windows.Forms.TextBox txtboxFilter;
        private System.Windows.Forms.Button btnAdv;
        private System.Windows.Forms.Button button1;
    }
}