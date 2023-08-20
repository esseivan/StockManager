namespace StockManagerDB
{
    partial class frmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.listviewMaterials = new BrightIdeasSoftware.FastDataListView();
            this.olvcMPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSupplier = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcSPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcMAN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcCat = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcStock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcLowStock = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcTotalPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.textBulkAdd = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMoreInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbSuppliers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMPNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySPNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSupplierUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.textboxProjects = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkboxUseMpn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listviewMaterials
            // 
            this.listviewMaterials.AllColumns.Add(this.olvcMPN);
            this.listviewMaterials.AllColumns.Add(this.olvcSupplier);
            this.listviewMaterials.AllColumns.Add(this.olvcSPN);
            this.listviewMaterials.AllColumns.Add(this.olvcMAN);
            this.listviewMaterials.AllColumns.Add(this.olvcLocation);
            this.listviewMaterials.AllColumns.Add(this.olvcCat);
            this.listviewMaterials.AllColumns.Add(this.olvcDesc);
            this.listviewMaterials.AllColumns.Add(this.olvcStock);
            this.listviewMaterials.AllColumns.Add(this.olvcLowStock);
            this.listviewMaterials.AllColumns.Add(this.olvcPrice);
            this.listviewMaterials.AllColumns.Add(this.olvcQuantity);
            this.listviewMaterials.AllColumns.Add(this.olvcTotalPrice);
            this.listviewMaterials.AllowCheckWithSpace = true;
            this.listviewMaterials.AllowColumnReorder = true;
            this.listviewMaterials.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewMaterials.AutoGenerateColumns = false;
            this.listviewMaterials.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.listviewMaterials.CellEditEnterChangesRows = true;
            this.listviewMaterials.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcMPN,
            this.olvcSupplier,
            this.olvcSPN,
            this.olvcMAN,
            this.olvcLocation,
            this.olvcCat,
            this.olvcDesc,
            this.olvcStock,
            this.olvcLowStock,
            this.olvcPrice,
            this.olvcQuantity,
            this.olvcTotalPrice});
            this.listviewMaterials.Cursor = System.Windows.Forms.Cursors.Default;
            this.listviewMaterials.DataSource = null;
            this.listviewMaterials.EmptyListMsg = "(Empty)";
            this.listviewMaterials.FullRowSelect = true;
            this.listviewMaterials.GridLines = true;
            this.listviewMaterials.HideSelection = false;
            this.listviewMaterials.Location = new System.Drawing.Point(127, 49);
            this.listviewMaterials.Margin = new System.Windows.Forms.Padding(2);
            this.listviewMaterials.Name = "listviewMaterials";
            this.listviewMaterials.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewMaterials.ShowCommandMenuOnRightClick = true;
            this.listviewMaterials.ShowGroups = false;
            this.listviewMaterials.ShowImagesOnSubItems = true;
            this.listviewMaterials.Size = new System.Drawing.Size(394, 334);
            this.listviewMaterials.SortGroupItemsByPrimaryColumn = false;
            this.listviewMaterials.TabIndex = 8;
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
            this.listviewMaterials.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.listviewMaterials_CellEditFinished);
            this.listviewMaterials.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.listviewMaterials_CellRightClick);
            // 
            // olvcMPN
            // 
            this.olvcMPN.IsEditable = false;
            this.olvcMPN.Text = "Manufacturer PN";
            this.olvcMPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // olvcMAN
            // 
            this.olvcMAN.IsEditable = false;
            this.olvcMAN.Text = "Manufacturer";
            this.olvcMAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcLocation
            // 
            this.olvcLocation.IsEditable = false;
            this.olvcLocation.Text = "Location";
            this.olvcLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcCat
            // 
            this.olvcCat.IsEditable = false;
            this.olvcCat.Text = "Category";
            this.olvcCat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcDesc
            // 
            this.olvcDesc.IsEditable = false;
            this.olvcDesc.Text = "Description";
            this.olvcDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcStock
            // 
            this.olvcStock.IsEditable = false;
            this.olvcStock.MinimumWidth = 75;
            this.olvcStock.Text = "Stock";
            this.olvcStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcStock.Width = 75;
            // 
            // olvcLowStock
            // 
            this.olvcLowStock.IsEditable = false;
            this.olvcLowStock.MinimumWidth = 75;
            this.olvcLowStock.Text = "LowStock";
            this.olvcLowStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcLowStock.Width = 75;
            // 
            // olvcPrice
            // 
            this.olvcPrice.IsEditable = false;
            this.olvcPrice.MinimumWidth = 75;
            this.olvcPrice.Text = "Price";
            this.olvcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcPrice.Width = 75;
            // 
            // olvcQuantity
            // 
            this.olvcQuantity.Text = "Quantity";
            this.olvcQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvcTotalPrice
            // 
            this.olvcTotalPrice.IsEditable = false;
            this.olvcTotalPrice.Text = "Total Price";
            this.olvcTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBulkAdd
            // 
            this.textBulkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBulkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBulkAdd.Location = new System.Drawing.Point(525, 66);
            this.textBulkAdd.Margin = new System.Windows.Forms.Padding(2);
            this.textBulkAdd.Name = "textBulkAdd";
            this.textBulkAdd.Size = new System.Drawing.Size(195, 284);
            this.textBulkAdd.TabIndex = 9;
            this.textBulkAdd.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.viweToolStripMenuItem,
            this.deleteSelectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // viweToolStripMenuItem
            // 
            this.viweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfosToolStripMenuItem,
            this.showMoreInfosToolStripMenuItem,
            this.toolStripSeparator1,
            this.resizeColumnsToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshToolStripMenuItem1});
            this.viweToolStripMenuItem.Name = "viweToolStripMenuItem";
            this.viweToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viweToolStripMenuItem.Text = "View";
            // 
            // showInfosToolStripMenuItem
            // 
            this.showInfosToolStripMenuItem.CheckOnClick = true;
            this.showInfosToolStripMenuItem.Name = "showInfosToolStripMenuItem";
            this.showInfosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.showInfosToolStripMenuItem.Text = "Show infos";
            this.showInfosToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showInfosToolStripMenuItem_CheckedChanged);
            // 
            // showMoreInfosToolStripMenuItem
            // 
            this.showMoreInfosToolStripMenuItem.CheckOnClick = true;
            this.showMoreInfosToolStripMenuItem.Name = "showMoreInfosToolStripMenuItem";
            this.showMoreInfosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.showMoreInfosToolStripMenuItem.Text = "Show more infos";
            this.showMoreInfosToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showMoreInfosToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // resizeColumnsToolStripMenuItem
            // 
            this.resizeColumnsToolStripMenuItem.Name = "resizeColumnsToolStripMenuItem";
            this.resizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.resizeColumnsToolStripMenuItem.Text = "Resize columns";
            this.resizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.resizeColumnsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // deleteSelectionToolStripMenuItem
            // 
            this.deleteSelectionToolStripMenuItem.Name = "deleteSelectionToolStripMenuItem";
            this.deleteSelectionToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.deleteSelectionToolStripMenuItem.Text = "Delete selection";
            this.deleteSelectionToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectionToolStripMenuItem_Click);
            // 
            // cbbSuppliers
            // 
            this.cbbSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSuppliers.FormattingEnabled = true;
            this.cbbSuppliers.Location = new System.Drawing.Point(579, 23);
            this.cbbSuppliers.Name = "cbbSuppliers";
            this.cbbSuppliers.Size = new System.Drawing.Size(141, 21);
            this.cbbSuppliers.TabIndex = 11;
            this.cbbSuppliers.SelectedIndexChanged += new System.EventHandler(this.cbbSuppliers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Supplier :";
            // 
            // contextMenuStrip1
            // 
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
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(640, 355);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Success";
            // 
            // statusTimeoutTimer
            // 
            this.statusTimeoutTimer.Enabled = true;
            this.statusTimeoutTimer.Interval = 2500;
            this.statusTimeoutTimer.Tick += new System.EventHandler(this.statusTimeoutTimer_Tick);
            // 
            // textboxProjects
            // 
            this.textboxProjects.Location = new System.Drawing.Point(12, 49);
            this.textboxProjects.Name = "textboxProjects";
            this.textboxProjects.ReadOnly = true;
            this.textboxProjects.Size = new System.Drawing.Size(110, 334);
            this.textboxProjects.TabIndex = 15;
            this.textboxProjects.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Project list";
            // 
            // checkboxUseMpn
            // 
            this.checkboxUseMpn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkboxUseMpn.AutoSize = true;
            this.checkboxUseMpn.Location = new System.Drawing.Point(526, 49);
            this.checkboxUseMpn.Name = "checkboxUseMpn";
            this.checkboxUseMpn.Size = new System.Drawing.Size(72, 17);
            this.checkboxUseMpn.TabIndex = 17;
            this.checkboxUseMpn.Text = "Use MPN";
            this.checkboxUseMpn.UseVisualStyleBackColor = true;
            this.checkboxUseMpn.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 390);
            this.Controls.Add(this.checkboxUseMpn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textboxProjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSuppliers);
            this.Controls.Add(this.textBulkAdd);
            this.Controls.Add(this.listviewMaterials);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView listviewMaterials;
        private BrightIdeasSoftware.OLVColumn olvcMPN;
        private BrightIdeasSoftware.OLVColumn olvcQuantity;
        private BrightIdeasSoftware.OLVColumn olvcStock;
        private BrightIdeasSoftware.OLVColumn olvcPrice;
        private BrightIdeasSoftware.OLVColumn olvcLocation;
        private BrightIdeasSoftware.OLVColumn olvcLowStock;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvcMAN;
        private BrightIdeasSoftware.OLVColumn olvcSupplier;
        private BrightIdeasSoftware.OLVColumn olvcSPN;
        private System.Windows.Forms.RichTextBox textBulkAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvcTotalPrice;
        private BrightIdeasSoftware.OLVColumn olvcCat;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectionToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbSuppliers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyMPNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSupplierUrlToolStripMenuItem;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer statusTimeoutTimer;
        private System.Windows.Forms.ToolStripMenuItem viweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMoreInfosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.RichTextBox textboxProjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkboxUseMpn;
        private System.Windows.Forms.ToolStripMenuItem copySPNToolStripMenuItem;
    }
}