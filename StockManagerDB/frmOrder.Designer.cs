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
            this.listviewMaterials = new BrightIdeasSoftware.FastDataListView();
            this.olvcSelect = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcMPN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcQuantity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcReference = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // listviewMaterials
            // 
            this.listviewMaterials.AllColumns.Add(this.olvcSelect);
            this.listviewMaterials.AllColumns.Add(this.olvcMPN);
            this.listviewMaterials.AllColumns.Add(this.olvcQuantity);
            this.listviewMaterials.AllColumns.Add(this.olvcReference);
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
            this.listviewMaterials.Location = new System.Drawing.Point(12, 12);
            this.listviewMaterials.Name = "listviewMaterials";
            this.listviewMaterials.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.listviewMaterials.ShowCommandMenuOnRightClick = true;
            this.listviewMaterials.ShowGroups = false;
            this.listviewMaterials.ShowImagesOnSubItems = true;
            this.listviewMaterials.Size = new System.Drawing.Size(680, 576);
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
            this.olvcLocation.IsEditable = false;
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(698, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(381, 576);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 600);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listviewMaterials);
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            ((System.ComponentModel.ISupportInitialize)(this.listviewMaterials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView listviewMaterials;
        private BrightIdeasSoftware.OLVColumn olvcSelect;
        private BrightIdeasSoftware.OLVColumn olvcMPN;
        private BrightIdeasSoftware.OLVColumn olvcQuantity;
        private BrightIdeasSoftware.OLVColumn olvcReference;
        private BrightIdeasSoftware.OLVColumn olvcStock;
        private BrightIdeasSoftware.OLVColumn olvcTotalQuantity;
        private BrightIdeasSoftware.OLVColumn olvcAvailable;
        private BrightIdeasSoftware.OLVColumn olvcPrice;
        private BrightIdeasSoftware.OLVColumn olvcTotalPrice;
        private BrightIdeasSoftware.OLVColumn olvcLocation;
        private BrightIdeasSoftware.OLVColumn olvcLowStock;
        private BrightIdeasSoftware.OLVColumn olvcDesc;
        private BrightIdeasSoftware.OLVColumn olvcCat;
        private BrightIdeasSoftware.OLVColumn olvcMAN;
        private BrightIdeasSoftware.OLVColumn olvcSupplier;
        private BrightIdeasSoftware.OLVColumn olvcSPN;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}