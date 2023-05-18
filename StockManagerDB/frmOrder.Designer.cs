﻿namespace StockManagerDB
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
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHideMoreInfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbSuppliers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.listviewMaterials.Location = new System.Drawing.Point(8, 23);
            this.listviewMaterials.Margin = new System.Windows.Forms.Padding(2);
            this.listviewMaterials.Name = "listviewMaterials";
            this.listviewMaterials.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewMaterials.ShowCommandMenuOnRightClick = true;
            this.listviewMaterials.ShowGroups = false;
            this.listviewMaterials.ShowImagesOnSubItems = true;
            this.listviewMaterials.Size = new System.Drawing.Size(509, 360);
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
            // 
            // olvcMPN
            // 
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
            this.olvcTotalPrice.Text = "Total Price";
            this.olvcTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBulkAdd
            // 
            this.textBulkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBulkAdd.Location = new System.Drawing.Point(519, 49);
            this.textBulkAdd.Margin = new System.Windows.Forms.Padding(2);
            this.textBulkAdd.Name = "textBulkAdd";
            this.textBulkAdd.Size = new System.Drawing.Size(201, 334);
            this.textBulkAdd.TabIndex = 9;
            this.textBulkAdd.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.showHideInfosToolStripMenuItem,
            this.showHideMoreInfosToolStripMenuItem,
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
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // showHideInfosToolStripMenuItem
            // 
            this.showHideInfosToolStripMenuItem.Name = "showHideInfosToolStripMenuItem";
            this.showHideInfosToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.showHideInfosToolStripMenuItem.Text = "Show/Hide infos";
            this.showHideInfosToolStripMenuItem.Click += new System.EventHandler(this.showHideInfosToolStripMenuItem_Click);
            // 
            // showHideMoreInfosToolStripMenuItem
            // 
            this.showHideMoreInfosToolStripMenuItem.Name = "showHideMoreInfosToolStripMenuItem";
            this.showHideMoreInfosToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.showHideMoreInfosToolStripMenuItem.Text = "Show/Hide more infos";
            this.showHideMoreInfosToolStripMenuItem.Click += new System.EventHandler(this.showHideMoreInfosToolStripMenuItem_Click);
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
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSuppliers);
            this.Controls.Add(this.textBulkAdd);
            this.Controls.Add(this.listviewMaterials);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmOrder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem showHideInfosToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvcCat;
        private System.Windows.Forms.ToolStripMenuItem showHideMoreInfosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbSuppliers;
        private System.Windows.Forms.Label label1;
    }
}