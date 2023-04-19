namespace StockManagerDB
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOrderFromDigikeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyAffectCheckedPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.makeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllInViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllInViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbboxFilterType = new System.Windows.Forms.ComboBox();
            this.txtboxFilter = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPartAdd = new System.Windows.Forms.Button();
            this.btnPartDup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnCheckedPartDel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.filterHighlightRenderer = new BrightIdeasSoftware.HighlightTextRenderer();
            this.statusTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
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
            this.selectionToolStripMenuItem,
            this.projectsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.closeDatabaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.newDatabaseToolStripMenuItem.Text = "New database";
            this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // closeDatabaseToolStripMenuItem
            // 
            this.closeDatabaseToolStripMenuItem.Name = "closeDatabaseToolStripMenuItem";
            this.closeDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.closeDatabaseToolStripMenuItem.Text = "Close database";
            this.closeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.closeDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(195, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromExcelToolStripMenuItem,
            this.importOrderFromDigikeyToolStripMenuItem,
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.databaseToolStripMenuItem.Text = "Imports";
            // 
            // importFromExcelToolStripMenuItem
            // 
            this.importFromExcelToolStripMenuItem.Name = "importFromExcelToolStripMenuItem";
            this.importFromExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.importFromExcelToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importFromExcelToolStripMenuItem.Text = "Import from Excel";
            this.importFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importFromExcelToolStripMenuItem_Click);
            // 
            // importOrderFromDigikeyToolStripMenuItem
            // 
            this.importOrderFromDigikeyToolStripMenuItem.Name = "importOrderFromDigikeyToolStripMenuItem";
            this.importOrderFromDigikeyToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importOrderFromDigikeyToolStripMenuItem.Text = "Import order from Digikey";
            this.importOrderFromDigikeyToolStripMenuItem.Click += new System.EventHandler(this.importOrderFromDigikeyToolStripMenuItem_Click);
            // 
            // importOrderFromDigikeyFromClipboardToolStripMenuItem
            // 
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Name = "importOrderFromDigikeyFromClipboardToolStripMenuItem";
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Text = "Import order from Digikey from Clipboard";
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.importOrderFromDigikeyFromClipboardToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyAffectCheckedPartsToolStripMenuItem,
            this.toolStripSeparator1,
            this.makeOrderToolStripMenuItem});
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
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllInViewToolStripMenuItem,
            this.uncheckAllInViewToolStripMenuItem});
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // checkAllInViewToolStripMenuItem
            // 
            this.checkAllInViewToolStripMenuItem.Name = "checkAllInViewToolStripMenuItem";
            this.checkAllInViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.checkAllInViewToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.checkAllInViewToolStripMenuItem.Text = "Check all in view";
            this.checkAllInViewToolStripMenuItem.Click += new System.EventHandler(this.checkAllInViewToolStripMenuItem_Click);
            // 
            // uncheckAllInViewToolStripMenuItem
            // 
            this.uncheckAllInViewToolStripMenuItem.Name = "uncheckAllInViewToolStripMenuItem";
            this.uncheckAllInViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.uncheckAllInViewToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.uncheckAllInViewToolStripMenuItem.Text = "Uncheck all in view";
            this.uncheckAllInViewToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllInViewToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.projectsToolStripMenuItem.Text = "Open Projects";
            this.projectsToolStripMenuItem.Click += new System.EventHandler(this.projectsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeColumnsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // resizeColumnsToolStripMenuItem
            // 
            this.resizeColumnsToolStripMenuItem.Name = "resizeColumnsToolStripMenuItem";
            this.resizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.resizeColumnsToolStripMenuItem.Text = "Resize columns";
            this.resizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.resizeColumnsToolStripMenuItem_Click);
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
            this.cbboxFilterType.Location = new System.Drawing.Point(766, 6);
            this.cbboxFilterType.Name = "cbboxFilterType";
            this.cbboxFilterType.Size = new System.Drawing.Size(94, 21);
            this.cbboxFilterType.TabIndex = 1;
            this.cbboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbboxFilterType_SelectedIndexChanged);
            // 
            // txtboxFilter
            // 
            this.txtboxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxFilter.Location = new System.Drawing.Point(660, 7);
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
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnPartAdd);
            this.splitContainer1.Panel1.Controls.Add(this.btnPartDup);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.cbboxFilterType);
            this.splitContainer1.Panel1.Controls.Add(this.txtboxFilter);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.listviewParts);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel1MinSize = 125;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCheckedPartDel);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.listviewChecked);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel2MinSize = 125;
            this.splitContainer1.Size = new System.Drawing.Size(866, 466);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 40;
            // 
            // btnPartAdd
            // 
            this.btnPartAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPartAdd.BackgroundImage = global::StockManagerDB.Properties.Resources.add;
            this.btnPartAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPartAdd.Location = new System.Drawing.Point(6, 19);
            this.btnPartAdd.Name = "btnPartAdd";
            this.btnPartAdd.Size = new System.Drawing.Size(23, 23);
            this.btnPartAdd.TabIndex = 11;
            this.btnPartAdd.UseVisualStyleBackColor = true;
            this.btnPartAdd.Click += new System.EventHandler(this.btnPartAdd_Click);
            // 
            // btnPartDup
            // 
            this.btnPartDup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPartDup.BackgroundImage = global::StockManagerDB.Properties.Resources.dup;
            this.btnPartDup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPartDup.Location = new System.Drawing.Point(35, 19);
            this.btnPartDup.Name = "btnPartDup";
            this.btnPartDup.Size = new System.Drawing.Size(23, 23);
            this.btnPartDup.TabIndex = 13;
            this.btnPartDup.UseVisualStyleBackColor = true;
            this.btnPartDup.Click += new System.EventHandler(this.btnPartDup_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "All parts";
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
            this.listviewParts.AllowCheckWithSpace = true;
            this.listviewParts.AllowColumnReorder = true;
            this.listviewParts.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewParts.AutoGenerateColumns = false;
            this.listviewParts.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
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
            this.listviewParts.EmptyListMsg = "(Empty)";
            this.listviewParts.FullRowSelect = true;
            this.listviewParts.GridLines = true;
            this.listviewParts.HideSelection = false;
            this.listviewParts.Location = new System.Drawing.Point(3, 47);
            this.listviewParts.Margin = new System.Windows.Forms.Padding(2);
            this.listviewParts.Name = "listviewParts";
            this.listviewParts.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewParts.ShowCommandMenuOnRightClick = true;
            this.listviewParts.ShowGroups = false;
            this.listviewParts.ShowImagesOnSubItems = true;
            this.listviewParts.Size = new System.Drawing.Size(858, 222);
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
            this.listviewParts.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.listviewParts_CellEditStarting);
            this.listviewParts.CellEditRequested += new BrightIdeasSoftware.CellEditEventHandler(this.listviewParts_CellEditRequested);
            this.listviewParts.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listviewParts_CellRightClick);
            this.listviewParts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listviewParts_ItemChecked);
            this.listviewParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listviewParts_KeyDown);
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
            // btnCheckedPartDel
            // 
            this.btnCheckedPartDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckedPartDel.BackgroundImage = global::StockManagerDB.Properties.Resources.del;
            this.btnCheckedPartDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCheckedPartDel.Location = new System.Drawing.Point(6, 19);
            this.btnCheckedPartDel.Name = "btnCheckedPartDel";
            this.btnCheckedPartDel.Size = new System.Drawing.Size(23, 23);
            this.btnCheckedPartDel.TabIndex = 14;
            this.btnCheckedPartDel.UseVisualStyleBackColor = true;
            this.btnCheckedPartDel.Click += new System.EventHandler(this.btnCheckedPartDel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Checked parts";
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
            this.listviewChecked.AllowCheckWithSpace = true;
            this.listviewChecked.AllowColumnReorder = true;
            this.listviewChecked.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.listviewChecked.EmptyListMsg = "(Empty)";
            this.listviewChecked.FullRowSelect = true;
            this.listviewChecked.GridLines = true;
            this.listviewChecked.HideSelection = false;
            this.listviewChecked.Location = new System.Drawing.Point(3, 47);
            this.listviewChecked.Margin = new System.Windows.Forms.Padding(2);
            this.listviewChecked.Name = "listviewChecked";
            this.listviewChecked.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewChecked.ShowCommandMenuOnRightClick = true;
            this.listviewChecked.ShowGroups = false;
            this.listviewChecked.ShowImagesOnSubItems = true;
            this.listviewChecked.Size = new System.Drawing.Size(858, 138);
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
            this.labelCount,
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelCount
            // 
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(24, 17);
            this.labelCount.Text = "0/0";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(66, 17);
            this.labelStatus.Text = "statusLabel";
            // 
            // statusTimeoutTimer
            // 
            this.statusTimeoutTimer.Enabled = true;
            this.statusTimeoutTimer.Interval = 2500;
            this.statusTimeoutTimer.Tick += new System.EventHandler(this.statusTimeoutTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 518);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 320);
            this.Name = "frmMain";
            this.Text = "Stock Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllInViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllInViewToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelCount;
        private System.Windows.Forms.ToolStripMenuItem closeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importOrderFromDigikeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BrightIdeasSoftware.HighlightTextRenderer filterHighlightRenderer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPartAdd;
        private System.Windows.Forms.Button btnPartDup;
        private System.Windows.Forms.Button btnCheckedPartDel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importOrderFromDigikeyFromClipboardToolStripMenuItem;
        private System.Windows.Forms.Timer statusTimeoutTimer;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
    }
}

