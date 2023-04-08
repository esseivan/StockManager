namespace StockManagerDB
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyAffectCheckedPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.makeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllInViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllInViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dELETECheckedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbboxFilterType = new System.Windows.Forms.ComboBox();
            this.txtboxFilter = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listviewParts = new BrightIdeasSoftware.FastDataListView();
            this.olvcSelect = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.listviewChecked = new BrightIdeasSoftware.FastDataListView();
            this.olvcMPN2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcMAN2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCat2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLocation2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcStock2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLowStock2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcPrice2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSupplier2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSPN2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listviewChecked)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.selectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newDatabaseToolStripMenuItem.Text = "New database";
            this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromExcelToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // importFromExcelToolStripMenuItem
            // 
            this.importFromExcelToolStripMenuItem.Name = "importFromExcelToolStripMenuItem";
            this.importFromExcelToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importFromExcelToolStripMenuItem.Text = "Import from Excel";
            this.importFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importFromExcelToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyAffectCheckedPartsToolStripMenuItem,
            this.toolStripSeparator1,
            this.makeOrderToolStripMenuItem,
            this.toolStripSeparator2});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // onlyAffectCheckedPartsToolStripMenuItem
            // 
            this.onlyAffectCheckedPartsToolStripMenuItem.CheckOnClick = true;
            this.onlyAffectCheckedPartsToolStripMenuItem.Name = "onlyAffectCheckedPartsToolStripMenuItem";
            this.onlyAffectCheckedPartsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.onlyAffectCheckedPartsToolStripMenuItem.Text = "Only affect checked parts";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // makeOrderToolStripMenuItem
            // 
            this.makeOrderToolStripMenuItem.Name = "makeOrderToolStripMenuItem";
            this.makeOrderToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.makeOrderToolStripMenuItem.Text = "Make Order";
            this.makeOrderToolStripMenuItem.Click += new System.EventHandler(this.makeOrderToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllInViewToolStripMenuItem,
            this.uncheckAllInViewToolStripMenuItem,
            this.toolStripSeparator3,
            this.dELETECheckedToolStripMenuItem});
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // checkAllInViewToolStripMenuItem
            // 
            this.checkAllInViewToolStripMenuItem.Name = "checkAllInViewToolStripMenuItem";
            this.checkAllInViewToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.checkAllInViewToolStripMenuItem.Text = "Check all in view";
            this.checkAllInViewToolStripMenuItem.Click += new System.EventHandler(this.checkAllInViewToolStripMenuItem_Click);
            // 
            // uncheckAllInViewToolStripMenuItem
            // 
            this.uncheckAllInViewToolStripMenuItem.Name = "uncheckAllInViewToolStripMenuItem";
            this.uncheckAllInViewToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.uncheckAllInViewToolStripMenuItem.Text = "Uncheck all in view";
            this.uncheckAllInViewToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllInViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // dELETECheckedToolStripMenuItem
            // 
            this.dELETECheckedToolStripMenuItem.Name = "dELETECheckedToolStripMenuItem";
            this.dELETECheckedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.dELETECheckedToolStripMenuItem.Text = "DELETE ALL CHECKED";
            this.dELETECheckedToolStripMenuItem.Click += new System.EventHandler(this.DELETECheckedToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cbboxFilterType);
            this.groupBox3.Controls.Add(this.txtboxFilter);
            this.groupBox3.Location = new System.Drawing.Point(503, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 44);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // cbboxFilterType
            // 
            this.cbboxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxFilterType.FormattingEnabled = true;
            this.cbboxFilterType.Items.AddRange(new object[] {
            "Any text",
            "Prefix",
            "Regex"});
            this.cbboxFilterType.Location = new System.Drawing.Point(114, 18);
            this.cbboxFilterType.Name = "cbboxFilterType";
            this.cbboxFilterType.Size = new System.Drawing.Size(94, 21);
            this.cbboxFilterType.TabIndex = 1;
            this.cbboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbboxFilterType_SelectedIndexChanged);
            // 
            // txtboxFilter
            // 
            this.txtboxFilter.Location = new System.Drawing.Point(7, 18);
            this.txtboxFilter.Name = "txtboxFilter";
            this.txtboxFilter.Size = new System.Drawing.Size(100, 20);
            this.txtboxFilter.TabIndex = 0;
            this.txtboxFilter.TextChanged += new System.EventHandler(this.txtboxFilter_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 77);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listviewParts);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listviewChecked);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(728, 407);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 40;
            // 
            // listviewParts
            // 
            this.listviewParts.AllColumns.Add(this.olvcSelect);
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
            this.listviewParts.AllowColumnReorder = true;
            this.listviewParts.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewParts.AutoGenerateColumns = false;
            this.listviewParts.CellEditUseWholeCell = false;
            this.listviewParts.CheckBoxes = true;
            this.listviewParts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcSelect,
            this.olvcMPN,
            this.olvcMAN,
            this.olvcDesc,
            this.olvcCat,
            this.olvcLocation,
            this.olvcStock,
            this.olvcLowStock,
            this.olvcPrice,
            this.olvcSupplier,
            this.olvcSPN});
            this.listviewParts.Cursor = System.Windows.Forms.Cursors.Default;
            this.listviewParts.DataSource = null;
            this.listviewParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listviewParts.EmptyListMsg = "(Empty)";
            this.listviewParts.HideSelection = false;
            this.listviewParts.Location = new System.Drawing.Point(3, 3);
            this.listviewParts.Margin = new System.Windows.Forms.Padding(2);
            this.listviewParts.Name = "listviewParts";
            this.listviewParts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewParts.ShowCommandMenuOnRightClick = true;
            this.listviewParts.ShowGroups = false;
            this.listviewParts.ShowImagesOnSubItems = true;
            this.listviewParts.Size = new System.Drawing.Size(722, 282);
            this.listviewParts.SortGroupItemsByPrimaryColumn = false;
            this.listviewParts.TabIndex = 6;
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
            this.listviewParts.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.listviewParts_CellEditFinished);
            this.listviewParts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listviewParts_ItemChecked);
            // 
            // olvcSelect
            // 
            this.olvcSelect.Text = "Select";
            this.olvcSelect.Width = 30;
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
            // listviewChecked
            // 
            this.listviewChecked.AllColumns.Add(this.olvcMPN2);
            this.listviewChecked.AllColumns.Add(this.olvcMAN2);
            this.listviewChecked.AllColumns.Add(this.olvcDesc2);
            this.listviewChecked.AllColumns.Add(this.olvcCat2);
            this.listviewChecked.AllColumns.Add(this.olvcLocation2);
            this.listviewChecked.AllColumns.Add(this.olvcStock2);
            this.listviewChecked.AllColumns.Add(this.olvcLowStock2);
            this.listviewChecked.AllColumns.Add(this.olvcPrice2);
            this.listviewChecked.AllColumns.Add(this.olvcSupplier2);
            this.listviewChecked.AllColumns.Add(this.olvcSPN2);
            this.listviewChecked.AllowColumnReorder = true;
            this.listviewChecked.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewChecked.AutoGenerateColumns = false;
            this.listviewChecked.CellEditUseWholeCell = false;
            this.listviewChecked.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcMPN2,
            this.olvcMAN2,
            this.olvcDesc2,
            this.olvcCat2,
            this.olvcLocation2,
            this.olvcStock2,
            this.olvcLowStock2,
            this.olvcPrice2,
            this.olvcSupplier2,
            this.olvcSPN2});
            this.listviewChecked.Cursor = System.Windows.Forms.Cursors.Default;
            this.listviewChecked.DataSource = null;
            this.listviewChecked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listviewChecked.EmptyListMsg = "(Empty)";
            this.listviewChecked.HideSelection = false;
            this.listviewChecked.Location = new System.Drawing.Point(3, 3);
            this.listviewChecked.Margin = new System.Windows.Forms.Padding(2);
            this.listviewChecked.Name = "listviewChecked";
            this.listviewChecked.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewChecked.ShowCommandMenuOnRightClick = true;
            this.listviewChecked.ShowGroups = false;
            this.listviewChecked.ShowImagesOnSubItems = true;
            this.listviewChecked.Size = new System.Drawing.Size(722, 109);
            this.listviewChecked.SortGroupItemsByPrimaryColumn = false;
            this.listviewChecked.TabIndex = 7;
            this.listviewChecked.TintSortColumn = true;
            this.listviewChecked.UseAlternatingBackColors = true;
            this.listviewChecked.UseCompatibleStateImageBehavior = false;
            this.listviewChecked.UseFilterIndicator = true;
            this.listviewChecked.UseFiltering = true;
            this.listviewChecked.UseHotItem = true;
            this.listviewChecked.UseHyperlinks = true;
            this.listviewChecked.UseTranslucentHotItem = true;
            this.listviewChecked.View = System.Windows.Forms.View.Details;
            this.listviewChecked.VirtualMode = true;
            // 
            // olvcMPN2
            // 
            this.olvcMPN2.Text = "Manufacturer PN";
            this.olvcMPN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcMAN2
            // 
            this.olvcMAN2.Text = "Manufacturer";
            this.olvcMAN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcDesc2
            // 
            this.olvcDesc2.Text = "Description";
            this.olvcDesc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcCat2
            // 
            this.olvcCat2.Text = "Category";
            this.olvcCat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcLocation2
            // 
            this.olvcLocation2.Text = "Location";
            this.olvcLocation2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcStock2
            // 
            this.olvcStock2.MinimumWidth = 75;
            this.olvcStock2.Text = "Stock";
            this.olvcStock2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcStock2.Width = 75;
            // 
            // olvcLowStock2
            // 
            this.olvcLowStock2.MinimumWidth = 75;
            this.olvcLowStock2.Text = "LowStock";
            this.olvcLowStock2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcLowStock2.Width = 75;
            // 
            // olvcPrice2
            // 
            this.olvcPrice2.MinimumWidth = 75;
            this.olvcPrice2.Text = "Price";
            this.olvcPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcPrice2.Width = 75;
            // 
            // olvcSupplier2
            // 
            this.olvcSupplier2.Text = "Supplier";
            this.olvcSupplier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcSPN2
            // 
            this.olvcSPN2.Text = "SPN";
            this.olvcSPN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(728, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelCount
            // 
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 509);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listviewChecked)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BrightIdeasSoftware.FastDataListView listviewParts;
        private BrightIdeasSoftware.OLVColumn olvcMAN;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvcCat;
        private BrightIdeasSoftware.OLVColumn olvcMPN;
        private BrightIdeasSoftware.OLVColumn olvcLocation;
        private BrightIdeasSoftware.OLVColumn olvcStock;
        private BrightIdeasSoftware.OLVColumn olvcLowStock;
        private BrightIdeasSoftware.OLVColumn olvcPrice;
        private BrightIdeasSoftware.OLVColumn olvcSupplier;
        private BrightIdeasSoftware.OLVColumn olvcSPN;
        private BrightIdeasSoftware.OLVColumn olvcSelect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromExcelToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbboxFilterType;
        private System.Windows.Forms.TextBox txtboxFilter;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyAffectCheckedPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem makeOrderToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.FastDataListView listviewChecked;
        private BrightIdeasSoftware.OLVColumn olvcMPN2;
        private BrightIdeasSoftware.OLVColumn olvcMAN2;
        private BrightIdeasSoftware.OLVColumn olvcDesc2;
        private BrightIdeasSoftware.OLVColumn olvcCat2;
        private BrightIdeasSoftware.OLVColumn olvcLocation2;
        private BrightIdeasSoftware.OLVColumn olvcStock2;
        private BrightIdeasSoftware.OLVColumn olvcLowStock2;
        private BrightIdeasSoftware.OLVColumn olvcPrice2;
        private BrightIdeasSoftware.OLVColumn olvcSupplier2;
        private BrightIdeasSoftware.OLVColumn olvcSPN2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllInViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllInViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem dELETECheckedToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelCount;
    }
}

