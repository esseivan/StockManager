﻿namespace StockManagerDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.seeInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPartsFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOrderFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.importListFromDigikeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOrderFromDigikeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyAffectCheckedPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.makeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPartsToOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFromDigikeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.checkAllInViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllInViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeGithubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbboxFilterType = new System.Windows.Forms.ComboBox();
            this.txtboxFilter = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnPartDel = new System.Windows.Forms.Button();
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
            this.olvcSubstitute = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcObsolete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelPartInfos = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numboxStockOrder = new StockManagerDB.Libraries.NumericUpDownFix();
            this.btnStockOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStockAdd = new System.Windows.Forms.Button();
            this.numboxStockAdjust = new StockManagerDB.Libraries.NumericUpDownFix();
            this.btnStockRoundDown = new System.Windows.Forms.Button();
            this.txtboxPartCurrentStock = new System.Windows.Forms.TextBox();
            this.btnStockRemove = new System.Windows.Forms.Button();
            this.btnStockSet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMPNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySPNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSupplierUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterHighlightRenderer = new BrightIdeasSoftware.HighlightTextRenderer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).BeginInit();
            this.panelPartInfos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numboxStockOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numboxStockAdjust)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.projectsToolStripMenuItem,
            this.openHistoryToolStripMenuItem,
            this.openOrderToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.seeInExplorerToolStripMenuItem,
            this.closeDatabaseToolStripMenuItem,
            this.toolStripSeparator4,
            this.saveToolStripMenuItem,
            this.importsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newDatabaseToolStripMenuItem.Text = "New";
            this.newDatabaseToolStripMenuItem.ToolTipText = "Create a empty new \'.smd\' stock";
            this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open";
            this.openDatabaseToolStripMenuItem.ToolTipText = "Open a \'.smd\' stock file";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openRecentToolStripMenuItem.Text = "Open recent...";
            this.openRecentToolStripMenuItem.DropDownOpening += new System.EventHandler(this.openRecentToolStripMenuItem_DropDownOpening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItemRecentFile_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem4.Text = "3";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem5.Text = "4";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem6.Text = "5";
            // 
            // seeInExplorerToolStripMenuItem
            // 
            this.seeInExplorerToolStripMenuItem.Name = "seeInExplorerToolStripMenuItem";
            this.seeInExplorerToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.seeInExplorerToolStripMenuItem.Text = "See in explorer";
            this.seeInExplorerToolStripMenuItem.ToolTipText = "Open the directory of the current stock file";
            this.seeInExplorerToolStripMenuItem.Click += new System.EventHandler(this.seeInExplorerToolStripMenuItem_Click);
            // 
            // closeDatabaseToolStripMenuItem
            // 
            this.closeDatabaseToolStripMenuItem.Name = "closeDatabaseToolStripMenuItem";
            this.closeDatabaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeDatabaseToolStripMenuItem.Text = "Close";
            this.closeDatabaseToolStripMenuItem.ToolTipText = "Close the current stock file";
            this.closeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.closeDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Save the changes made. Note that the save is automatic for almost every change yo" +
    "u make. This is just to force a new save.";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importsToolStripMenuItem
            // 
            this.importsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPartsFromExcelToolStripMenuItem,
            this.importOrderFromExcelToolStripMenuItem,
            this.toolStripSeparator7,
            this.importListFromDigikeyToolStripMenuItem,
            this.importOrderFromDigikeyToolStripMenuItem,
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem});
            this.importsToolStripMenuItem.Name = "importsToolStripMenuItem";
            this.importsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.importsToolStripMenuItem.Text = "Import...";
            this.importsToolStripMenuItem.ToolTipText = "Import from various locations.";
            // 
            // importPartsFromExcelToolStripMenuItem
            // 
            this.importPartsFromExcelToolStripMenuItem.Name = "importPartsFromExcelToolStripMenuItem";
            this.importPartsFromExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.importPartsFromExcelToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importPartsFromExcelToolStripMenuItem.Text = "Import parts from Excel";
            this.importPartsFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importPartsFromExcelToolStripMenuItem_Click);
            // 
            // importOrderFromExcelToolStripMenuItem
            // 
            this.importOrderFromExcelToolStripMenuItem.Name = "importOrderFromExcelToolStripMenuItem";
            this.importOrderFromExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.importOrderFromExcelToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importOrderFromExcelToolStripMenuItem.Text = "Import order from Excel";
            this.importOrderFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importOrderFromExcelToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(293, 6);
            // 
            // importListFromDigikeyToolStripMenuItem
            // 
            this.importListFromDigikeyToolStripMenuItem.Name = "importListFromDigikeyToolStripMenuItem";
            this.importListFromDigikeyToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importListFromDigikeyToolStripMenuItem.Text = "Import List as parts from Digikey";
            this.importListFromDigikeyToolStripMenuItem.ToolTipText = "Import a BOM List from Digikey. This is used to populate your part list easily. N" +
    "ote that no project is created with this import, you have a specific import in t" +
    "he project window for that matter.";
            this.importListFromDigikeyToolStripMenuItem.Click += new System.EventHandler(this.importListFromDigikeyToolStripMenuItem_Click);
            // 
            // importOrderFromDigikeyToolStripMenuItem
            // 
            this.importOrderFromDigikeyToolStripMenuItem.Name = "importOrderFromDigikeyToolStripMenuItem";
            this.importOrderFromDigikeyToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importOrderFromDigikeyToolStripMenuItem.Text = "Import order from Digikey";
            this.importOrderFromDigikeyToolStripMenuItem.ToolTipText = "Process a Digikey \'.csv\' order file. The corresponding parts in your stock will b" +
    "e updated. If a part is not present in your stock, it will be created.";
            this.importOrderFromDigikeyToolStripMenuItem.Click += new System.EventHandler(this.importOrderFromDigikeyToolStripMenuItem_Click);
            // 
            // importOrderFromDigikeyFromClipboardToolStripMenuItem
            // 
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Name = "importOrderFromDigikeyFromClipboardToolStripMenuItem";
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Text = "Import order from Digikey from Clipboard";
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.ToolTipText = "Process a Digikey order file contained in your clipboard. The corresponding parts" +
    " in your stock will be updated. If a part is not present in your stock, it will " +
    "be created.";
            this.importOrderFromDigikeyFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.importOrderFromDigikeyFromClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.ToolTipText = "This will close all sub-windows";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlyAffectCheckedPartsToolStripMenuItem,
            this.toolStripSeparator1,
            this.makeOrderToolStripMenuItem,
            this.addPartsToOrderToolStripMenuItem,
            this.updateFromDigikeyToolStripMenuItem,
            this.addToProjectToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportPartsToolStripMenuItem,
            this.importPartsToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // onlyAffectCheckedPartsToolStripMenuItem
            // 
            this.onlyAffectCheckedPartsToolStripMenuItem.Checked = true;
            this.onlyAffectCheckedPartsToolStripMenuItem.CheckOnClick = true;
            this.onlyAffectCheckedPartsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlyAffectCheckedPartsToolStripMenuItem.Name = "onlyAffectCheckedPartsToolStripMenuItem";
            this.onlyAffectCheckedPartsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.onlyAffectCheckedPartsToolStripMenuItem.Text = "Only affect checked parts";
            this.onlyAffectCheckedPartsToolStripMenuItem.ToolTipText = "If checked, the actions will only target the checked parts (the list at the botto" +
    "m).\r\nIf unchecked, the actions will target ALL the parts (the list at the top).";
            this.onlyAffectCheckedPartsToolStripMenuItem.Click += new System.EventHandler(this.onlyAffectCheckedPartsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // makeOrderToolStripMenuItem
            // 
            this.makeOrderToolStripMenuItem.Name = "makeOrderToolStripMenuItem";
            this.makeOrderToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.makeOrderToolStripMenuItem.Text = "Make LowStock Order";
            this.makeOrderToolStripMenuItem.ToolTipText = "Make automatic order according to the LowStock parameters for the parts. The diff" +
    "erence between the actual stock and the low stock will be added to the order for" +
    "m.";
            this.makeOrderToolStripMenuItem.Click += new System.EventHandler(this.makeOrderToolStripMenuItem_Click);
            // 
            // addPartsToOrderToolStripMenuItem
            // 
            this.addPartsToOrderToolStripMenuItem.Name = "addPartsToOrderToolStripMenuItem";
            this.addPartsToOrderToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.addPartsToOrderToolStripMenuItem.Text = "Add parts to order (for user edit)";
            this.addPartsToOrderToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addPartsToOrderToolStripMenuItem.ToolTipText = "Add the parts to the order form with a quantity of 0.";
            this.addPartsToOrderToolStripMenuItem.Click += new System.EventHandler(this.addPartsToOrderToolStripMenuItem_Click);
            // 
            // updateFromDigikeyToolStripMenuItem
            // 
            this.updateFromDigikeyToolStripMenuItem.Name = "updateFromDigikeyToolStripMenuItem";
            this.updateFromDigikeyToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.updateFromDigikeyToolStripMenuItem.Text = "Update from Digikey";
            this.updateFromDigikeyToolStripMenuItem.ToolTipText = "Update the parts using the Digikey API. (Manufacturer, Description, Price, Suppli" +
    "er and SPN will be updated)";
            this.updateFromDigikeyToolStripMenuItem.Click += new System.EventHandler(this.updateFromDigikeyToolStripMenuItem_Click);
            // 
            // addToProjectToolStripMenuItem
            // 
            this.addToProjectToolStripMenuItem.Name = "addToProjectToolStripMenuItem";
            this.addToProjectToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.addToProjectToolStripMenuItem.Text = "Add to project...";
            this.addToProjectToolStripMenuItem.ToolTipText = "Add the parts to a project that you will select";
            this.addToProjectToolStripMenuItem.Click += new System.EventHandler(this.addToProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // exportPartsToolStripMenuItem
            // 
            this.exportPartsToolStripMenuItem.Name = "exportPartsToolStripMenuItem";
            this.exportPartsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.exportPartsToolStripMenuItem.Text = "Export parts";
            this.exportPartsToolStripMenuItem.ToolTipText = "Export the parts to a \'.smd\' file. You can then use or share this file.\r\n";
            this.exportPartsToolStripMenuItem.Click += new System.EventHandler(this.exportPartsToolStripMenuItem_Click);
            // 
            // importPartsToolStripMenuItem
            // 
            this.importPartsToolStripMenuItem.Name = "importPartsToolStripMenuItem";
            this.importPartsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.importPartsToolStripMenuItem.Text = "Import parts";
            this.importPartsToolStripMenuItem.ToolTipText = "Import all the parts from a \'.smd\' file.";
            this.importPartsToolStripMenuItem.Click += new System.EventHandler(this.importPartsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeColumnsToolStripMenuItem,
            this.toolStripSeparator5,
            this.checkAllInViewToolStripMenuItem,
            this.uncheckAllInViewToolStripMenuItem,
            this.toolStripSeparator6,
            this.advancedSearchToolStripMenuItem,
            this.standardSearchToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // resizeColumnsToolStripMenuItem
            // 
            this.resizeColumnsToolStripMenuItem.Name = "resizeColumnsToolStripMenuItem";
            this.resizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.resizeColumnsToolStripMenuItem.Text = "Resize columns";
            this.resizeColumnsToolStripMenuItem.ToolTipText = "Resize the columns on both lists";
            this.resizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.resizeColumnsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // checkAllInViewToolStripMenuItem
            // 
            this.checkAllInViewToolStripMenuItem.Name = "checkAllInViewToolStripMenuItem";
            this.checkAllInViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.checkAllInViewToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.checkAllInViewToolStripMenuItem.Text = "Check all in view";
            this.checkAllInViewToolStripMenuItem.ToolTipText = "Check all the parts in the view (currently in the top list)";
            this.checkAllInViewToolStripMenuItem.Click += new System.EventHandler(this.checkAllInViewToolStripMenuItem_Click);
            // 
            // uncheckAllInViewToolStripMenuItem
            // 
            this.uncheckAllInViewToolStripMenuItem.Name = "uncheckAllInViewToolStripMenuItem";
            this.uncheckAllInViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.uncheckAllInViewToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.uncheckAllInViewToolStripMenuItem.Text = "Uncheck all in view";
            this.uncheckAllInViewToolStripMenuItem.ToolTipText = "Unchek all the part in the view (currently in the top list)";
            this.uncheckAllInViewToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllInViewToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(246, 6);
            // 
            // advancedSearchToolStripMenuItem
            // 
            this.advancedSearchToolStripMenuItem.Name = "advancedSearchToolStripMenuItem";
            this.advancedSearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.advancedSearchToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.advancedSearchToolStripMenuItem.Text = "Advanced search";
            this.advancedSearchToolStripMenuItem.ToolTipText = "Open the advanced search window.\r\nThe current filters will be overwritten.";
            this.advancedSearchToolStripMenuItem.Click += new System.EventHandler(this.advancedSearchToolStripMenuItem_Click);
            // 
            // standardSearchToolStripMenuItem
            // 
            this.standardSearchToolStripMenuItem.Name = "standardSearchToolStripMenuItem";
            this.standardSearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.standardSearchToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.standardSearchToolStripMenuItem.Text = "Standard search";
            this.standardSearchToolStripMenuItem.Click += new System.EventHandler(this.standardSearchToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.ToolTipText = "Open the options.";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.projectsToolStripMenuItem.Text = "Open Projects";
            this.projectsToolStripMenuItem.ToolTipText = "Open the project window";
            this.projectsToolStripMenuItem.Click += new System.EventHandler(this.projectsToolStripMenuItem_Click);
            // 
            // openHistoryToolStripMenuItem
            // 
            this.openHistoryToolStripMenuItem.Name = "openHistoryToolStripMenuItem";
            this.openHistoryToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.openHistoryToolStripMenuItem.Text = "Open History";
            this.openHistoryToolStripMenuItem.ToolTipText = "Open the history window";
            this.openHistoryToolStripMenuItem.Click += new System.EventHandler(this.openHistoryToolStripMenuItem_Click);
            // 
            // openOrderToolStripMenuItem
            // 
            this.openOrderToolStripMenuItem.Name = "openOrderToolStripMenuItem";
            this.openOrderToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.openOrderToolStripMenuItem.Text = "Open Order";
            this.openOrderToolStripMenuItem.ToolTipText = "Open the order window";
            this.openOrderToolStripMenuItem.Click += new System.EventHandler(this.openOrderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seeBackupsToolStripMenuItem,
            this.seeLogsToolStripMenuItem,
            this.sourceCodeGithubToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // seeBackupsToolStripMenuItem
            // 
            this.seeBackupsToolStripMenuItem.Name = "seeBackupsToolStripMenuItem";
            this.seeBackupsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.seeBackupsToolStripMenuItem.Text = "See backups...";
            this.seeBackupsToolStripMenuItem.ToolTipText = "Open the backup directory";
            this.seeBackupsToolStripMenuItem.Click += new System.EventHandler(this.seeBackupsToolStripMenuItem_Click);
            // 
            // seeLogsToolStripMenuItem
            // 
            this.seeLogsToolStripMenuItem.Name = "seeLogsToolStripMenuItem";
            this.seeLogsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.seeLogsToolStripMenuItem.Text = "See logs...";
            this.seeLogsToolStripMenuItem.ToolTipText = "Open the log directory";
            this.seeLogsToolStripMenuItem.Click += new System.EventHandler(this.seeLogsToolStripMenuItem_Click);
            // 
            // sourceCodeGithubToolStripMenuItem
            // 
            this.sourceCodeGithubToolStripMenuItem.Name = "sourceCodeGithubToolStripMenuItem";
            this.sourceCodeGithubToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.sourceCodeGithubToolStripMenuItem.Text = "Source Code (Github)...";
            this.sourceCodeGithubToolStripMenuItem.ToolTipText = "Visit the Github project page";
            this.sourceCodeGithubToolStripMenuItem.Click += new System.EventHandler(this.sourceCodeGithubToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.ToolTipText = "About the app and this build";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.cbboxFilterType.Location = new System.Drawing.Point(763, 6);
            this.cbboxFilterType.Name = "cbboxFilterType";
            this.cbboxFilterType.Size = new System.Drawing.Size(94, 21);
            this.cbboxFilterType.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbboxFilterType, resources.GetString("cbboxFilterType.ToolTip"));
            this.cbboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbboxFilterType_SelectedIndexChanged);
            // 
            // txtboxFilter
            // 
            this.txtboxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxFilter.Location = new System.Drawing.Point(657, 7);
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
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnPartDel);
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
            this.splitContainer1.Panel2.Controls.Add(this.panelPartInfos);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel2MinSize = 125;
            this.splitContainer1.Size = new System.Drawing.Size(866, 466);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 40;
            // 
            // btnPartDel
            // 
            this.btnPartDel.BackgroundImage = global::StockManagerDB.Properties.Resources.del;
            this.btnPartDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPartDel.Location = new System.Drawing.Point(64, 19);
            this.btnPartDel.Name = "btnPartDel";
            this.btnPartDel.Size = new System.Drawing.Size(23, 23);
            this.btnPartDel.TabIndex = 14;
            this.btnPartDel.UseVisualStyleBackColor = true;
            this.btnPartDel.Click += new System.EventHandler(this.btnPartDel_Click);
            // 
            // btnPartAdd
            // 
            this.btnPartAdd.BackgroundImage = global::StockManagerDB.Properties.Resources.add;
            this.btnPartAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPartAdd.Location = new System.Drawing.Point(6, 19);
            this.btnPartAdd.Name = "btnPartAdd";
            this.btnPartAdd.Size = new System.Drawing.Size(23, 23);
            this.btnPartAdd.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnPartAdd, "Add new part");
            this.btnPartAdd.UseVisualStyleBackColor = true;
            this.btnPartAdd.Click += new System.EventHandler(this.btnPartAdd_Click);
            // 
            // btnPartDup
            // 
            this.btnPartDup.BackgroundImage = global::StockManagerDB.Properties.Resources.dup;
            this.btnPartDup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPartDup.Location = new System.Drawing.Point(35, 19);
            this.btnPartDup.Name = "btnPartDup";
            this.btnPartDup.Size = new System.Drawing.Size(23, 23);
            this.btnPartDup.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnPartDup, "Duplicate selected part (only one must be selected)");
            this.btnPartDup.UseVisualStyleBackColor = true;
            this.btnPartDup.Click += new System.EventHandler(this.btnPartDup_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(580, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filter";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.listviewParts.AllColumns.Add(this.olvcSubstitute);
            this.listviewParts.AllColumns.Add(this.olvcObsolete);
            this.listviewParts.AllowCheckWithSpace = true;
            this.listviewParts.AllowColumnReorder = true;
            this.listviewParts.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewParts.AutoGenerateColumns = false;
            this.listviewParts.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
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
            this.olvcSPN,
            this.olvcSubstitute,
            this.olvcObsolete});
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
            this.listviewParts.Size = new System.Drawing.Size(854, 69);
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
            this.listviewParts.CellEditRequested += new BrightIdeasSoftware.CellEditEventHandler(this.listviewParts_CellEditRequested);
            this.listviewParts.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listviewParts_CellRightClick);
            this.listviewParts.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.listviewParts_SubItemChecking);
            this.listviewParts.SelectionChanged += new System.EventHandler(this.listviewParts_SelectionChanged);
            this.listviewParts.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listviewParts_ItemChecked);
            this.listviewParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listviewParts_KeyDown);
            // 
            // olvcSelect
            // 
            this.olvcSelect.IsEditable = false;
            this.olvcSelect.MaximumWidth = 22;
            this.olvcSelect.MinimumWidth = 22;
            this.olvcSelect.Text = "";
            this.olvcSelect.Width = 22;
            // 
            // olvcMPN
            // 
            this.olvcMPN.MinimumWidth = 20;
            this.olvcMPN.Text = "Manufacturer PN";
            this.olvcMPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcMAN
            // 
            this.olvcMAN.MinimumWidth = 20;
            this.olvcMAN.Text = "Manufacturer";
            this.olvcMAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcDesc
            // 
            this.olvcDesc.MinimumWidth = 20;
            this.olvcDesc.Text = "Description";
            this.olvcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcCat
            // 
            this.olvcCat.MinimumWidth = 20;
            this.olvcCat.Text = "Category";
            this.olvcCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcLocation
            // 
            this.olvcLocation.MinimumWidth = 20;
            this.olvcLocation.Text = "Location";
            this.olvcLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcStock
            // 
            this.olvcStock.MinimumWidth = 20;
            this.olvcStock.Text = "Stock";
            this.olvcStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcStock.Width = 75;
            // 
            // olvcLowStock
            // 
            this.olvcLowStock.MinimumWidth = 20;
            this.olvcLowStock.Text = "LowStock";
            this.olvcLowStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcLowStock.Width = 75;
            // 
            // olvcPrice
            // 
            this.olvcPrice.MinimumWidth = 20;
            this.olvcPrice.Text = "Price";
            this.olvcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcPrice.Width = 75;
            // 
            // olvcSupplier
            // 
            this.olvcSupplier.MinimumWidth = 20;
            this.olvcSupplier.Text = "Supplier";
            this.olvcSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcSPN
            // 
            this.olvcSPN.MinimumWidth = 20;
            this.olvcSPN.Text = "SPN";
            this.olvcSPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcSubstitute
            // 
            this.olvcSubstitute.MinimumWidth = 20;
            this.olvcSubstitute.Text = "Substitute";
            this.olvcSubstitute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcObsolete
            // 
            this.olvcObsolete.AspectName = "Obsolete";
            this.olvcObsolete.CheckBoxes = true;
            this.olvcObsolete.MinimumWidth = 22;
            this.olvcObsolete.Text = "Obsolete";
            this.olvcObsolete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelPartInfos
            // 
            this.panelPartInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPartInfos.Controls.Add(this.groupBox2);
            this.panelPartInfos.Controls.Add(this.groupBox1);
            this.panelPartInfos.Controls.Add(this.label6);
            this.panelPartInfos.Controls.Add(this.listView1);
            this.panelPartInfos.Controls.Add(this.label1);
            this.panelPartInfos.Location = new System.Drawing.Point(6, 6);
            this.panelPartInfos.Name = "panelPartInfos";
            this.panelPartInfos.Size = new System.Drawing.Size(851, 308);
            this.panelPartInfos.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.numboxStockOrder);
            this.groupBox2.Controls.Add(this.btnStockOrder);
            this.groupBox2.Location = new System.Drawing.Point(6, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 185);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order";
            // 
            // numboxStockOrder
            // 
            this.numboxStockOrder.Location = new System.Drawing.Point(130, 22);
            this.numboxStockOrder.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numboxStockOrder.Name = "numboxStockOrder";
            this.numboxStockOrder.Size = new System.Drawing.Size(97, 20);
            this.numboxStockOrder.TabIndex = 9;
            // 
            // btnStockOrder
            // 
            this.btnStockOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStockOrder.Location = new System.Drawing.Point(233, 18);
            this.btnStockOrder.Name = "btnStockOrder";
            this.btnStockOrder.Size = new System.Drawing.Size(51, 23);
            this.btnStockOrder.TabIndex = 14;
            this.btnStockOrder.Text = "Order";
            this.btnStockOrder.UseVisualStyleBackColor = true;
            this.btnStockOrder.Click += new System.EventHandler(this.btnStockOrder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnStockAdd);
            this.groupBox1.Controls.Add(this.numboxStockAdjust);
            this.groupBox1.Controls.Add(this.btnStockRoundDown);
            this.groupBox1.Controls.Add(this.txtboxPartCurrentStock);
            this.groupBox1.Controls.Add(this.btnStockRemove);
            this.groupBox1.Controls.Add(this.btnStockSet);
            this.groupBox1.Location = new System.Drawing.Point(6, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 94);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stock";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Adjust";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStockAdd
            // 
            this.btnStockAdd.BackgroundImage = global::StockManagerDB.Properties.Resources.add;
            this.btnStockAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStockAdd.Location = new System.Drawing.Point(112, 65);
            this.btnStockAdd.Name = "btnStockAdd";
            this.btnStockAdd.Size = new System.Drawing.Size(23, 23);
            this.btnStockAdd.TabIndex = 11;
            this.btnStockAdd.UseVisualStyleBackColor = true;
            this.btnStockAdd.Click += new System.EventHandler(this.btnStockAdd_Click);
            // 
            // numboxStockAdjust
            // 
            this.numboxStockAdjust.Location = new System.Drawing.Point(112, 39);
            this.numboxStockAdjust.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numboxStockAdjust.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.numboxStockAdjust.Name = "numboxStockAdjust";
            this.numboxStockAdjust.Size = new System.Drawing.Size(172, 20);
            this.numboxStockAdjust.TabIndex = 9;
            // 
            // btnStockRoundDown
            // 
            this.btnStockRoundDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStockRoundDown.Location = new System.Drawing.Point(208, 65);
            this.btnStockRoundDown.Name = "btnStockRoundDown";
            this.btnStockRoundDown.Size = new System.Drawing.Size(76, 23);
            this.btnStockRoundDown.TabIndex = 14;
            this.btnStockRoundDown.Text = "Round down";
            this.btnStockRoundDown.UseVisualStyleBackColor = true;
            this.btnStockRoundDown.Click += new System.EventHandler(this.btnStockRoundDown_Click);
            // 
            // txtboxPartCurrentStock
            // 
            this.txtboxPartCurrentStock.Location = new System.Drawing.Point(112, 13);
            this.txtboxPartCurrentStock.Name = "txtboxPartCurrentStock";
            this.txtboxPartCurrentStock.ReadOnly = true;
            this.txtboxPartCurrentStock.Size = new System.Drawing.Size(172, 20);
            this.txtboxPartCurrentStock.TabIndex = 11;
            // 
            // btnStockRemove
            // 
            this.btnStockRemove.BackgroundImage = global::StockManagerDB.Properties.Resources.del;
            this.btnStockRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStockRemove.Location = new System.Drawing.Point(141, 65);
            this.btnStockRemove.Name = "btnStockRemove";
            this.btnStockRemove.Size = new System.Drawing.Size(23, 23);
            this.btnStockRemove.TabIndex = 14;
            this.btnStockRemove.UseVisualStyleBackColor = true;
            this.btnStockRemove.Click += new System.EventHandler(this.btnStockRemove_Click);
            // 
            // btnStockSet
            // 
            this.btnStockSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStockSet.Location = new System.Drawing.Point(170, 65);
            this.btnStockSet.Name = "btnStockSet";
            this.btnStockSet.Size = new System.Drawing.Size(32, 23);
            this.btnStockSet.TabIndex = 14;
            this.btnStockSet.Text = "Set";
            this.btnStockSet.UseVisualStyleBackColor = true;
            this.btnStockSet.Click += new System.EventHandler(this.btnStockSet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Used in projects :";
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(303, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(547, 277);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selected part";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMPNToolStripMenuItem,
            this.copySPNToolStripMenuItem,
            this.openSupplierUrlToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 70);
            // 
            // copyMPNToolStripMenuItem
            // 
            this.copyMPNToolStripMenuItem.Name = "copyMPNToolStripMenuItem";
            this.copyMPNToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.copyMPNToolStripMenuItem.Text = "Copy MPN";
            this.copyMPNToolStripMenuItem.Click += new System.EventHandler(this.copyMPNToolStripMenuItem_Click);
            // 
            // copySPNToolStripMenuItem
            // 
            this.copySPNToolStripMenuItem.Name = "copySPNToolStripMenuItem";
            this.copySPNToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.copySPNToolStripMenuItem.Text = "Copy SPN";
            this.copySPNToolStripMenuItem.Click += new System.EventHandler(this.copySPNToolStripMenuItem_Click);
            // 
            // openSupplierUrlToolStripMenuItem
            // 
            this.openSupplierUrlToolStripMenuItem.Name = "openSupplierUrlToolStripMenuItem";
            this.openSupplierUrlToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openSupplierUrlToolStripMenuItem.Text = "Open Supplier url...";
            this.openSupplierUrlToolStripMenuItem.Click += new System.EventHandler(this.openSupplierUrlToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 518);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(385, 275);
            this.Name = "frmMain";
            this.Text = "Stock Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listviewParts)).EndInit();
            this.panelPartInfos.ResumeLayout(false);
            this.panelPartInfos.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numboxStockOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numboxStockAdjust)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cbboxFilterType;
        private System.Windows.Forms.TextBox txtboxFilter;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyAffectCheckedPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem makeOrderToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelCount;
        private System.Windows.Forms.ToolStripMenuItem closeDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BrightIdeasSoftware.HighlightTextRenderer filterHighlightRenderer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPartAdd;
        private System.Windows.Forms.Button btnPartDup;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeColumnsToolStripMenuItem;
        private System.Windows.Forms.Timer statusTimeoutTimer;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripMenuItem openHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem importPartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importOrderFromDigikeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importOrderFromDigikeyFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem checkAllInViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllInViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem advancedSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeBackupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeInExplorerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyMPNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSupplierUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateFromDigikeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromDigikeyToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem addPartsToOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySPNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPartsFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importOrderFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.Button btnPartDel;
		private System.Windows.Forms.TextBox txtboxPartCurrentStock;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private Libraries.NumericUpDownFix numboxStockAdjust;
		private System.Windows.Forms.Button btnStockRemove;
		private System.Windows.Forms.Button btnStockAdd;
		private System.Windows.Forms.Panel panelPartInfos;
		private System.Windows.Forms.Button btnStockSet;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnStockRoundDown;
		private System.Windows.Forms.Button btnStockOrder;
		private Libraries.NumericUpDownFix numboxStockOrder;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripMenuItem standardSearchToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvcSubstitute;
        private BrightIdeasSoftware.OLVColumn olvcObsolete;
    }
}

