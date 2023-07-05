namespace StockManagerDB
{
    partial class frmProjects
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjects));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsOnCheckedPartsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.orderTheSelectedProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderMissingForTheSelectedProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listviewMaterials = new BrightIdeasSoftware.FastDataListView();
            this.olvcSelect = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcMPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcReference = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcNote = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcStock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcTotalQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcAvailable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcTotalPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLowStock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCat = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcMAN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSupplier = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.comboboxProjects = new System.Windows.Forms.ComboBox();
            this.comboboxVersions = new System.Windows.Forms.ComboBox();
            this.btnMatDup = new System.Windows.Forms.Button();
            this.btnMatDel = new System.Windows.Forms.Button();
            this.btnMatAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProAdd = new System.Windows.Forms.Button();
            this.btnProDel = new System.Windows.Forms.Button();
            this.btnProDup = new System.Windows.Forms.Button();
            this.btnProRen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerAdd = new System.Windows.Forms.Button();
            this.btnVerDel = new System.Windows.Forms.Button();
            this.btnVerDup = new System.Windows.Forms.Button();
            this.btnVerRen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnImportDigikeyList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numMult = new System.Windows.Forms.NumericUpDown();
            this.statusTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.tooltip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMPNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSupplierUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 466);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(995, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(66, 17);
            this.labelStatus.Text = "statusLabel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importProjectsToolStripMenuItem,
            this.exportAllProjectsToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importProjectsToolStripMenuItem
            // 
            this.importProjectsToolStripMenuItem.Name = "importProjectsToolStripMenuItem";
            this.importProjectsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.importProjectsToolStripMenuItem.Text = "Import projects";
            this.importProjectsToolStripMenuItem.ToolTipText = "Import the projects from a \'.smd\' stock file";
            this.importProjectsToolStripMenuItem.Click += new System.EventHandler(this.importProjectsToolStripMenuItem_Click);
            // 
            // exportAllProjectsToolStripMenuItem
            // 
            this.exportAllProjectsToolStripMenuItem.Name = "exportAllProjectsToolStripMenuItem";
            this.exportAllProjectsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exportAllProjectsToolStripMenuItem.Text = "Export all projects";
            this.exportAllProjectsToolStripMenuItem.ToolTipText = "Export all the projects into a \'.smd\' file";
            this.exportAllProjectsToolStripMenuItem.Click += new System.EventHandler(this.exportAllProjectsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.quitToolStripMenuItem.Text = "Close";
            this.quitToolStripMenuItem.ToolTipText = "Close this project window only";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsOnCheckedPartsOnlyToolStripMenuItem,
            this.toolStripSeparator3,
            this.orderTheSelectedProjectToolStripMenuItem,
            this.orderMissingForTheSelectedProjectToolStripMenuItem,
            this.processProjectToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // actionsOnCheckedPartsOnlyToolStripMenuItem
            // 
            this.actionsOnCheckedPartsOnlyToolStripMenuItem.Checked = true;
            this.actionsOnCheckedPartsOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.actionsOnCheckedPartsOnlyToolStripMenuItem.Enabled = false;
            this.actionsOnCheckedPartsOnlyToolStripMenuItem.Name = "actionsOnCheckedPartsOnlyToolStripMenuItem";
            this.actionsOnCheckedPartsOnlyToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.actionsOnCheckedPartsOnlyToolStripMenuItem.Text = "Actions on Checked parts only";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(232, 6);
            // 
            // orderTheSelectedProjectToolStripMenuItem
            // 
            this.orderTheSelectedProjectToolStripMenuItem.Name = "orderTheSelectedProjectToolStripMenuItem";
            this.orderTheSelectedProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.orderTheSelectedProjectToolStripMenuItem.Text = "Order exact";
            this.orderTheSelectedProjectToolStripMenuItem.ToolTipText = "Add the BOM to the order form with the exact quantities that are listed.\r\nYou wil" +
    "l be asked for a multiplier.";
            this.orderTheSelectedProjectToolStripMenuItem.Click += new System.EventHandler(this.orderTheSelectedProjectToolStripMenuItem_Click);
            // 
            // orderMissingForTheSelectedProjectToolStripMenuItem
            // 
            this.orderMissingForTheSelectedProjectToolStripMenuItem.Name = "orderMissingForTheSelectedProjectToolStripMenuItem";
            this.orderMissingForTheSelectedProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.orderMissingForTheSelectedProjectToolStripMenuItem.Text = "Order missing materials";
            this.orderMissingForTheSelectedProjectToolStripMenuItem.ToolTipText = "Add the missing materials from the BOM to the order form.\r\nThis will be compared " +
    "to current stock. \r\nMore options are available in the Option form.\r\nYou will be " +
    "asked for a multiplier.\r\n";
            this.orderMissingForTheSelectedProjectToolStripMenuItem.Click += new System.EventHandler(this.orderMissingForTheSelectedProjectToolStripMenuItem_Click);
            // 
            // processProjectToolStripMenuItem
            // 
            this.processProjectToolStripMenuItem.Name = "processProjectToolStripMenuItem";
            this.processProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.processProjectToolStripMenuItem.Text = "Deduct BOM from part list";
            this.processProjectToolStripMenuItem.ToolTipText = "Remove the BOM from the current stock.\r\nYou will be asked for a multiplier.";
            this.processProjectToolStripMenuItem.Click += new System.EventHandler(this.processProjectToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeColumnsToolStripMenuItem,
            this.toolStripSeparator2,
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // resizeColumnsToolStripMenuItem
            // 
            this.resizeColumnsToolStripMenuItem.Name = "resizeColumnsToolStripMenuItem";
            this.resizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.resizeColumnsToolStripMenuItem.Text = "Resize columns";
            this.resizeColumnsToolStripMenuItem.ToolTipText = "Resize the columns on the BOM list";
            this.resizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.resizeColumnsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.checkAllToolStripMenuItem.Text = "Check all";
            this.checkAllToolStripMenuItem.ToolTipText = "Check all the parts in the BOM";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // uncheckAllToolStripMenuItem
            // 
            this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.uncheckAllToolStripMenuItem.Text = "Uncheck all";
            this.uncheckAllToolStripMenuItem.ToolTipText = "Uncheck all the parts in the BOM";
            this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
            // 
            // listviewMaterials
            // 
            this.listviewMaterials.AllColumns.Add(this.olvcSelect);
            this.listviewMaterials.AllColumns.Add(this.olvcMPN);
            this.listviewMaterials.AllColumns.Add(this.olvcQuantity);
            this.listviewMaterials.AllColumns.Add(this.olvcReference);
            this.listviewMaterials.AllColumns.Add(this.olvcNote);
            this.listviewMaterials.AllColumns.Add(this.olvcStock);
            this.listviewMaterials.AllColumns.Add(this.olvcTotalQuantity);
            this.listviewMaterials.AllColumns.Add(this.olvcAvailable);
            this.listviewMaterials.AllColumns.Add(this.olvcPrice);
            this.listviewMaterials.AllColumns.Add(this.olvcTotalPrice);
            this.listviewMaterials.AllColumns.Add(this.olvcLocation);
            this.listviewMaterials.AllColumns.Add(this.olvcLowStock);
            this.listviewMaterials.AllColumns.Add(this.olvcDesc);
            this.listviewMaterials.AllColumns.Add(this.olvcCat);
            this.listviewMaterials.AllColumns.Add(this.olvcMAN);
            this.listviewMaterials.AllColumns.Add(this.olvcSupplier);
            this.listviewMaterials.AllColumns.Add(this.olvcSPN);
            this.listviewMaterials.AllowCheckWithSpace = true;
            this.listviewMaterials.AllowColumnReorder = true;
            this.listviewMaterials.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewMaterials.AutoGenerateColumns = false;
            this.listviewMaterials.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.listviewMaterials.CheckBoxes = true;
            this.listviewMaterials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcSelect,
            this.olvcMPN,
            this.olvcQuantity,
            this.olvcReference,
            this.olvcNote,
            this.olvcStock,
            this.olvcTotalQuantity,
            this.olvcAvailable,
            this.olvcPrice,
            this.olvcTotalPrice,
            this.olvcLocation,
            this.olvcLowStock,
            this.olvcDesc,
            this.olvcCat,
            this.olvcMAN,
            this.olvcSupplier,
            this.olvcSPN});
            this.listviewMaterials.Cursor = System.Windows.Forms.Cursors.Default;
            this.listviewMaterials.DataSource = null;
            this.listviewMaterials.EmptyListMsg = "(Empty)";
            this.listviewMaterials.FullRowSelect = true;
            this.listviewMaterials.GridLines = true;
            this.listviewMaterials.HideSelection = false;
            this.listviewMaterials.Location = new System.Drawing.Point(5, 47);
            this.listviewMaterials.Margin = new System.Windows.Forms.Padding(2);
            this.listviewMaterials.Name = "listviewMaterials";
            this.listviewMaterials.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewMaterials.ShowCommandMenuOnRightClick = true;
            this.listviewMaterials.ShowGroups = false;
            this.listviewMaterials.ShowImagesOnSubItems = true;
            this.listviewMaterials.Size = new System.Drawing.Size(818, 384);
            this.listviewMaterials.SortGroupItemsByPrimaryColumn = false;
            this.listviewMaterials.TabIndex = 7;
            this.listviewMaterials.TintSortColumn = true;
            this.listviewMaterials.UseAlternatingBackColors = true;
            this.listviewMaterials.UseCompatibleStateImageBehavior = false;
            this.listviewMaterials.UseFilterIndicator = true;
            this.listviewMaterials.UseFiltering = true;
            this.listviewMaterials.UseHotItem = true;
            this.listviewMaterials.UseHyperlinks = true;
            this.listviewMaterials.UseTranslucentHotItem = true;
            this.listviewMaterials.View = System.Windows.Forms.View.Details;
            this.listviewMaterials.VirtualMode = true;
            this.listviewMaterials.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.listviewComponents_CellEditFinished);
            this.listviewMaterials.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listviewMaterials_CellRightClick);
            // 
            // olvcSelect
            // 
            this.olvcSelect.IsEditable = false;
            this.olvcSelect.Text = "";
            this.olvcSelect.Width = 30;
            // 
            // olvcMPN
            // 
            this.olvcMPN.Text = "Manufacturer PN";
            this.olvcMPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcQuantity
            // 
            this.olvcQuantity.Text = "Quantity";
            this.olvcQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcReference
            // 
            this.olvcReference.Text = "Reference";
            this.olvcReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcNote
            // 
            this.olvcNote.Text = "Note";
            this.olvcNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcStock
            // 
            this.olvcStock.IsEditable = false;
            this.olvcStock.MinimumWidth = 75;
            this.olvcStock.Text = "Stock";
            this.olvcStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcStock.Width = 75;
            // 
            // olvcTotalQuantity
            // 
            this.olvcTotalQuantity.IsEditable = false;
            this.olvcTotalQuantity.Text = "Total Quantity";
            this.olvcTotalQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcAvailable
            // 
            this.olvcAvailable.IsEditable = false;
            this.olvcAvailable.Text = "Available";
            this.olvcAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcPrice
            // 
            this.olvcPrice.IsEditable = false;
            this.olvcPrice.MinimumWidth = 75;
            this.olvcPrice.Text = "Price";
            this.olvcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcPrice.Width = 75;
            // 
            // olvcTotalPrice
            // 
            this.olvcTotalPrice.IsEditable = false;
            this.olvcTotalPrice.Text = "Total Price";
            this.olvcTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcLocation
            // 
            this.olvcLocation.Text = "Location";
            this.olvcLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcLowStock
            // 
            this.olvcLowStock.MinimumWidth = 75;
            this.olvcLowStock.Text = "LowStock";
            this.olvcLowStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcLowStock.Width = 75;
            // 
            // olvcDesc
            // 
            this.olvcDesc.IsEditable = false;
            this.olvcDesc.Text = "Description";
            this.olvcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcCat
            // 
            this.olvcCat.IsEditable = false;
            this.olvcCat.Text = "Category";
            this.olvcCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcMAN
            // 
            this.olvcMAN.IsEditable = false;
            this.olvcMAN.Text = "Manufacturer";
            this.olvcMAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcSupplier
            // 
            this.olvcSupplier.IsEditable = false;
            this.olvcSupplier.Text = "Supplier";
            this.olvcSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcSPN
            // 
            this.olvcSPN.IsEditable = false;
            this.olvcSPN.Text = "SPN";
            this.olvcSPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboboxProjects
            // 
            this.comboboxProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboboxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboboxProjects.FormattingEnabled = true;
            this.comboboxProjects.Location = new System.Drawing.Point(3, 19);
            this.comboboxProjects.Name = "comboboxProjects";
            this.comboboxProjects.Size = new System.Drawing.Size(153, 237);
            this.comboboxProjects.TabIndex = 8;
            this.comboboxProjects.SelectedIndexChanged += new System.EventHandler(this.comboboxProjects_SelectedIndexChanged);
            // 
            // comboboxVersions
            // 
            this.comboboxVersions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboboxVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboboxVersions.FormattingEnabled = true;
            this.comboboxVersions.Location = new System.Drawing.Point(3, 19);
            this.comboboxVersions.Name = "comboboxVersions";
            this.comboboxVersions.Size = new System.Drawing.Size(153, 98);
            this.comboboxVersions.TabIndex = 8;
            this.comboboxVersions.SelectedIndexChanged += new System.EventHandler(this.comboboxVersions_SelectedIndexChanged);
            // 
            // btnMatDup
            // 
            this.btnMatDup.BackgroundImage = global::StockManagerDB.Properties.Resources.dup;
            this.btnMatDup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatDup.Location = new System.Drawing.Point(64, 19);
            this.btnMatDup.Name = "btnMatDup";
            this.btnMatDup.Size = new System.Drawing.Size(23, 23);
            this.btnMatDup.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnMatDup, "Duplicate the selected item (only one must be selected)");
            this.btnMatDup.UseVisualStyleBackColor = true;
            this.btnMatDup.Click += new System.EventHandler(this.btnMatDup_Click);
            // 
            // btnMatDel
            // 
            this.btnMatDel.BackgroundImage = global::StockManagerDB.Properties.Resources.del;
            this.btnMatDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatDel.Location = new System.Drawing.Point(35, 19);
            this.btnMatDel.Name = "btnMatDel";
            this.btnMatDel.Size = new System.Drawing.Size(23, 23);
            this.btnMatDel.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnMatDel, "Delete the selected item (only one must be selected)");
            this.btnMatDel.UseVisualStyleBackColor = true;
            this.btnMatDel.Click += new System.EventHandler(this.btnMatDel_Click);
            // 
            // btnMatAdd
            // 
            this.btnMatAdd.BackgroundImage = global::StockManagerDB.Properties.Resources.add;
            this.btnMatAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMatAdd.Location = new System.Drawing.Point(6, 19);
            this.btnMatAdd.Name = "btnMatAdd";
            this.btnMatAdd.Size = new System.Drawing.Size(23, 23);
            this.btnMatAdd.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnMatAdd, "Create a new item");
            this.btnMatAdd.UseVisualStyleBackColor = true;
            this.btnMatAdd.Click += new System.EventHandler(this.btnMatAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnProAdd);
            this.groupBox1.Controls.Add(this.btnProDel);
            this.groupBox1.Controls.Add(this.btnProDup);
            this.groupBox1.Controls.Add(this.btnProRen);
            this.groupBox1.Controls.Add(this.comboboxProjects);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 283);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // btnProAdd
            // 
            this.btnProAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProAdd.BackgroundImage = global::StockManagerDB.Properties.Resources.add;
            this.btnProAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProAdd.Location = new System.Drawing.Point(6, 256);
            this.btnProAdd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnProAdd.Name = "btnProAdd";
            this.btnProAdd.Size = new System.Drawing.Size(23, 23);
            this.btnProAdd.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnProAdd, "Add a new project");
            this.btnProAdd.UseVisualStyleBackColor = true;
            this.btnProAdd.Click += new System.EventHandler(this.btnProAdd_Click);
            // 
            // btnProDel
            // 
            this.btnProDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProDel.BackgroundImage = global::StockManagerDB.Properties.Resources.del;
            this.btnProDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProDel.Location = new System.Drawing.Point(35, 256);
            this.btnProDel.Name = "btnProDel";
            this.btnProDel.Size = new System.Drawing.Size(23, 23);
            this.btnProDel.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnProDel, "Delete the selected project");
            this.btnProDel.UseVisualStyleBackColor = true;
            this.btnProDel.Click += new System.EventHandler(this.btnProDel_Click);
            // 
            // btnProDup
            // 
            this.btnProDup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProDup.BackgroundImage = global::StockManagerDB.Properties.Resources.dup;
            this.btnProDup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProDup.Location = new System.Drawing.Point(64, 256);
            this.btnProDup.Name = "btnProDup";
            this.btnProDup.Size = new System.Drawing.Size(23, 23);
            this.btnProDup.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnProDup, "Duplicate the selected project");
            this.btnProDup.UseVisualStyleBackColor = true;
            this.btnProDup.Click += new System.EventHandler(this.btnProDup_Click);
            // 
            // btnProRen
            // 
            this.btnProRen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProRen.BackgroundImage = global::StockManagerDB.Properties.Resources.ren;
            this.btnProRen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProRen.Location = new System.Drawing.Point(93, 256);
            this.btnProRen.Name = "btnProRen";
            this.btnProRen.Size = new System.Drawing.Size(23, 23);
            this.btnProRen.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnProRen, "Rename the selected project");
            this.btnProRen.UseVisualStyleBackColor = true;
            this.btnProRen.Click += new System.EventHandler(this.btnProRen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnVerAdd);
            this.groupBox2.Controls.Add(this.btnVerDel);
            this.groupBox2.Controls.Add(this.comboboxVersions);
            this.groupBox2.Controls.Add(this.btnVerDup);
            this.groupBox2.Controls.Add(this.btnVerRen);
            this.groupBox2.Location = new System.Drawing.Point(2, 314);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 149);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Versions";
            // 
            // btnVerAdd
            // 
            this.btnVerAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerAdd.BackgroundImage = global::StockManagerDB.Properties.Resources.add;
            this.btnVerAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerAdd.Location = new System.Drawing.Point(6, 121);
            this.btnVerAdd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnVerAdd.Name = "btnVerAdd";
            this.btnVerAdd.Size = new System.Drawing.Size(23, 23);
            this.btnVerAdd.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnVerAdd, "Add a new version");
            this.btnVerAdd.UseVisualStyleBackColor = true;
            this.btnVerAdd.Click += new System.EventHandler(this.btnVerAdd_Click);
            // 
            // btnVerDel
            // 
            this.btnVerDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerDel.BackgroundImage = global::StockManagerDB.Properties.Resources.del;
            this.btnVerDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerDel.Location = new System.Drawing.Point(35, 121);
            this.btnVerDel.Name = "btnVerDel";
            this.btnVerDel.Size = new System.Drawing.Size(23, 23);
            this.btnVerDel.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnVerDel, "Delete the selected version");
            this.btnVerDel.UseVisualStyleBackColor = true;
            this.btnVerDel.Click += new System.EventHandler(this.btnVerDel_Click);
            // 
            // btnVerDup
            // 
            this.btnVerDup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerDup.BackgroundImage = global::StockManagerDB.Properties.Resources.dup;
            this.btnVerDup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerDup.Location = new System.Drawing.Point(64, 121);
            this.btnVerDup.Name = "btnVerDup";
            this.btnVerDup.Size = new System.Drawing.Size(23, 23);
            this.btnVerDup.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnVerDup, "Duplicate the selected version");
            this.btnVerDup.UseVisualStyleBackColor = true;
            this.btnVerDup.Click += new System.EventHandler(this.btnVerDup_Click);
            // 
            // btnVerRen
            // 
            this.btnVerRen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVerRen.BackgroundImage = global::StockManagerDB.Properties.Resources.ren;
            this.btnVerRen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVerRen.Location = new System.Drawing.Point(93, 121);
            this.btnVerRen.Name = "btnVerRen";
            this.btnVerRen.Size = new System.Drawing.Size(23, 23);
            this.btnVerRen.TabIndex = 10;
            this.tooltip1.SetToolTip(this.btnVerRen, "Rename the selected version");
            this.btnVerRen.UseVisualStyleBackColor = true;
            this.btnVerRen.Click += new System.EventHandler(this.btnVerRen_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnImportDigikeyList);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numMult);
            this.groupBox3.Controls.Add(this.btnMatAdd);
            this.groupBox3.Controls.Add(this.btnMatDel);
            this.groupBox3.Controls.Add(this.listviewMaterials);
            this.groupBox3.Controls.Add(this.btnMatDup);
            this.groupBox3.Location = new System.Drawing.Point(167, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(828, 436);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill Of Materials";
            // 
            // btnImportDigikeyList
            // 
            this.btnImportDigikeyList.Location = new System.Drawing.Point(93, 19);
            this.btnImportDigikeyList.Name = "btnImportDigikeyList";
            this.btnImportDigikeyList.Size = new System.Drawing.Size(75, 23);
            this.btnImportDigikeyList.TabIndex = 13;
            this.btnImportDigikeyList.Text = "Import List";
            this.tooltip1.SetToolTip(this.btnImportDigikeyList, "Import a BOM List from Digikey into this selected version\'s BOM");
            this.btnImportDigikeyList.UseVisualStyleBackColor = true;
            this.btnImportDigikeyList.Click += new System.EventHandler(this.btnImportDigikeyList_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(647, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Multiplier";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numMult
            // 
            this.numMult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMult.Location = new System.Drawing.Point(745, 19);
            this.numMult.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMult.Name = "numMult";
            this.numMult.Size = new System.Drawing.Size(78, 20);
            this.numMult.TabIndex = 11;
            this.tooltip1.SetToolTip(this.numMult, "Global multiplier for the BOM (Total Quantity, Available, Total Price).\r\nNo actio" +
        "n will use this multiplier.");
            this.numMult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMult.ValueChanged += new System.EventHandler(this.numMult_ValueChanged);
            // 
            // statusTimeoutTimer
            // 
            this.statusTimeoutTimer.Enabled = true;
            this.statusTimeoutTimer.Interval = 2500;
            this.statusTimeoutTimer.Tick += new System.EventHandler(this.statusTimeoutTimer_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMPNToolStripMenuItem,
            this.openSupplierUrlToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 48);
            // 
            // copyMPNToolStripMenuItem
            // 
            this.copyMPNToolStripMenuItem.Name = "copyMPNToolStripMenuItem";
            this.copyMPNToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.copyMPNToolStripMenuItem.Text = "Copy MPN";
            this.copyMPNToolStripMenuItem.Click += new System.EventHandler(this.copyMPNToolStripMenuItem_Click);
            // 
            // openSupplierUrlToolStripMenuItem
            // 
            this.openSupplierUrlToolStripMenuItem.Name = "openSupplierUrlToolStripMenuItem";
            this.openSupplierUrlToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openSupplierUrlToolStripMenuItem.Text = "Open Supplier url...";
            this.openSupplierUrlToolStripMenuItem.Click += new System.EventHandler(this.openSupplierUrlToolStripMenuItem_Click);
            // 
            // frmProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 488);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(398, 394);
            this.Name = "frmProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projects";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private BrightIdeasSoftware.FastDataListView listviewMaterials;
        private BrightIdeasSoftware.OLVColumn olvcSelect;
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
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboboxProjects;
        private BrightIdeasSoftware.OLVColumn olvcQuantity;
        private BrightIdeasSoftware.OLVColumn olvcReference;
        private System.Windows.Forms.ComboBox comboboxVersions;
        private System.Windows.Forms.Button btnMatAdd;
        private System.Windows.Forms.Button btnMatDel;
        private System.Windows.Forms.Button btnMatDup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnProAdd;
        private System.Windows.Forms.Button btnProDel;
        private System.Windows.Forms.Button btnProDup;
        private System.Windows.Forms.Button btnProRen;
        private System.Windows.Forms.Button btnVerAdd;
        private System.Windows.Forms.Button btnVerDel;
        private System.Windows.Forms.Button btnVerDup;
        private System.Windows.Forms.Button btnVerRen;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeColumnsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMult;
        private BrightIdeasSoftware.OLVColumn olvcTotalQuantity;
        private BrightIdeasSoftware.OLVColumn olvcTotalPrice;
        private BrightIdeasSoftware.OLVColumn olvcAvailable;
        private System.Windows.Forms.ToolStripMenuItem exportAllProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importProjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.Timer statusTimeoutTimer;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderTheSelectedProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processProjectToolStripMenuItem;
        private System.Windows.Forms.ToolTip tooltip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvcNote;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyMPNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSupplierUrlToolStripMenuItem;
        private System.Windows.Forms.Button btnImportDigikeyList;
        private System.Windows.Forms.ToolStripMenuItem actionsOnCheckedPartsOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem orderMissingForTheSelectedProjectToolStripMenuItem;
    }
}