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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSelectedProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateSelectedProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETESelectedProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.listviewComponents = new BrightIdeasSoftware.FastDataListView();
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.olvcQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcReference = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listviewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.renameSelectedProjectToolStripMenuItem,
            this.duplicateSelectedProjectToolStripMenuItem,
            this.dELETESelectedProjectToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // renameSelectedProjectToolStripMenuItem
            // 
            this.renameSelectedProjectToolStripMenuItem.Name = "renameSelectedProjectToolStripMenuItem";
            this.renameSelectedProjectToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.renameSelectedProjectToolStripMenuItem.Text = "Rename selected project";
            this.renameSelectedProjectToolStripMenuItem.Click += new System.EventHandler(this.renameSelectedProjectToolStripMenuItem_Click);
            // 
            // duplicateSelectedProjectToolStripMenuItem
            // 
            this.duplicateSelectedProjectToolStripMenuItem.Name = "duplicateSelectedProjectToolStripMenuItem";
            this.duplicateSelectedProjectToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.duplicateSelectedProjectToolStripMenuItem.Text = "Duplicate selected project";
            this.duplicateSelectedProjectToolStripMenuItem.Click += new System.EventHandler(this.duplicateSelectedProjectToolStripMenuItem_Click);
            // 
            // dELETESelectedProjectToolStripMenuItem
            // 
            this.dELETESelectedProjectToolStripMenuItem.Name = "dELETESelectedProjectToolStripMenuItem";
            this.dELETESelectedProjectToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.dELETESelectedProjectToolStripMenuItem.Text = "DELETE selected project";
            this.dELETESelectedProjectToolStripMenuItem.Click += new System.EventHandler(this.DELETESelectedProjectToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Projects";
            // 
            // listviewComponents
            // 
            this.listviewComponents.AllColumns.Add(this.olvcSelect);
            this.listviewComponents.AllColumns.Add(this.olvcMPN);
            this.listviewComponents.AllColumns.Add(this.olvcQuantity);
            this.listviewComponents.AllColumns.Add(this.olvcReference);
            this.listviewComponents.AllColumns.Add(this.olvcMAN);
            this.listviewComponents.AllColumns.Add(this.olvcDesc);
            this.listviewComponents.AllColumns.Add(this.olvcCat);
            this.listviewComponents.AllColumns.Add(this.olvcLocation);
            this.listviewComponents.AllColumns.Add(this.olvcStock);
            this.listviewComponents.AllColumns.Add(this.olvcLowStock);
            this.listviewComponents.AllColumns.Add(this.olvcPrice);
            this.listviewComponents.AllColumns.Add(this.olvcSupplier);
            this.listviewComponents.AllColumns.Add(this.olvcSPN);
            this.listviewComponents.AllowColumnReorder = true;
            this.listviewComponents.AlternateRowBackColor = System.Drawing.Color.LightBlue;
            this.listviewComponents.AutoGenerateColumns = false;
            this.listviewComponents.CellEditUseWholeCell = false;
            this.listviewComponents.CheckBoxes = true;
            this.listviewComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcSelect,
            this.olvcMPN,
            this.olvcQuantity,
            this.olvcReference,
            this.olvcMAN,
            this.olvcDesc,
            this.olvcCat,
            this.olvcLocation,
            this.olvcStock,
            this.olvcLowStock,
            this.olvcPrice,
            this.olvcSupplier,
            this.olvcSPN});
            this.listviewComponents.Cursor = System.Windows.Forms.Cursors.Default;
            this.listviewComponents.DataSource = null;
            this.listviewComponents.EmptyListMsg = "(Empty)";
            this.listviewComponents.HideSelection = false;
            this.listviewComponents.Location = new System.Drawing.Point(166, 94);
            this.listviewComponents.Margin = new System.Windows.Forms.Padding(2);
            this.listviewComponents.Name = "listviewComponents";
            this.listviewComponents.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewComponents.ShowCommandMenuOnRightClick = true;
            this.listviewComponents.ShowGroups = false;
            this.listviewComponents.ShowImagesOnSubItems = true;
            this.listviewComponents.Size = new System.Drawing.Size(623, 345);
            this.listviewComponents.SortGroupItemsByPrimaryColumn = false;
            this.listviewComponents.TabIndex = 7;
            this.listviewComponents.TintSortColumn = true;
            this.listviewComponents.UseAlternatingBackColors = true;
            this.listviewComponents.UseCompatibleStateImageBehavior = false;
            this.listviewComponents.UseFilterIndicator = true;
            this.listviewComponents.UseFiltering = true;
            this.listviewComponents.UseHotItem = true;
            this.listviewComponents.UseHyperlinks = true;
            this.listviewComponents.UseTranslucentHotItem = true;
            this.listviewComponents.View = System.Windows.Forms.View.Details;
            this.listviewComponents.VirtualMode = true;
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 332);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // olvcQuantity
            // 
            this.olvcQuantity.Text = "Quantity";
            // 
            // olvcReference
            // 
            this.olvcReference.Text = "Reference";
            // 
            // frmProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listviewComponents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmProjects";
            this.Text = "Projects";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listviewComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.FastDataListView listviewComponents;
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSelectedProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateSelectedProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dELETESelectedProjectToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvcQuantity;
        private BrightIdeasSoftware.OLVColumn olvcReference;
    }
}