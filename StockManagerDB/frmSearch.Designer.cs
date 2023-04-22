namespace StockManagerDB
{
    partial class frmSearch
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("MPN");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("SPN");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Description");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Place");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.txtboxFilter = new System.Windows.Forms.TextBox();
            this.listviewType = new System.Windows.Forms.ListView();
            this.colDummy2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listviewCategories = new System.Windows.Forms.ListView();
            this.colDummy1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtboxCategory = new System.Windows.Forms.TextBox();
            this.cbboxFilterType = new System.Windows.Forms.ComboBox();
            this.btnClearCat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtboxFilter
            // 
            this.txtboxFilter.Location = new System.Drawing.Point(80, 12);
            this.txtboxFilter.Name = "txtboxFilter";
            this.txtboxFilter.Size = new System.Drawing.Size(162, 20);
            this.txtboxFilter.TabIndex = 1;
            this.txtboxFilter.TextChanged += new System.EventHandler(this.txtboxFilter_TextChanged);
            // 
            // listviewType
            // 
            this.listviewType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listviewType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy2});
            this.listviewType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listviewType.HideSelection = false;
            this.listviewType.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listviewType.Location = new System.Drawing.Point(80, 38);
            this.listviewType.MultiSelect = false;
            this.listviewType.Name = "listviewType";
            this.listviewType.Size = new System.Drawing.Size(162, 400);
            this.listviewType.TabIndex = 2;
            this.listviewType.UseCompatibleStateImageBehavior = false;
            this.listviewType.View = System.Windows.Forms.View.Details;
            this.listviewType.SelectedIndexChanged += new System.EventHandler(this.listviewType_SelectedIndexChanged);
            // 
            // colDummy2
            // 
            this.colDummy2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search for :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search in :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filter categories :";
            // 
            // listviewCategories
            // 
            this.listviewCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listviewCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy1});
            this.listviewCategories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listviewCategories.HideSelection = false;
            this.listviewCategories.Location = new System.Drawing.Point(459, 64);
            this.listviewCategories.MultiSelect = false;
            this.listviewCategories.Name = "listviewCategories";
            this.listviewCategories.Size = new System.Drawing.Size(178, 374);
            this.listviewCategories.TabIndex = 2;
            this.listviewCategories.UseCompatibleStateImageBehavior = false;
            this.listviewCategories.View = System.Windows.Forms.View.Details;
            this.listviewCategories.SelectedIndexChanged += new System.EventHandler(this.listviewCategories_SelectedIndexChanged);
            // 
            // colDummy1
            // 
            this.colDummy1.Text = "";
            // 
            // txtboxCategory
            // 
            this.txtboxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxCategory.Location = new System.Drawing.Point(459, 11);
            this.txtboxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxCategory.Name = "txtboxCategory";
            this.txtboxCategory.Size = new System.Drawing.Size(178, 20);
            this.txtboxCategory.TabIndex = 7;
            this.txtboxCategory.TextChanged += new System.EventHandler(this.txtboxCategory_TextChanged);
            // 
            // cbboxFilterType
            // 
            this.cbboxFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxFilterType.FormattingEnabled = true;
            this.cbboxFilterType.Items.AddRange(new object[] {
            "Any text",
            "Prefix",
            "Regex"});
            this.cbboxFilterType.Location = new System.Drawing.Point(248, 11);
            this.cbboxFilterType.Name = "cbboxFilterType";
            this.cbboxFilterType.Size = new System.Drawing.Size(94, 21);
            this.cbboxFilterType.TabIndex = 8;
            this.cbboxFilterType.SelectedIndexChanged += new System.EventHandler(this.cbboxFilterType_SelectedIndexChanged);
            // 
            // btnClearCat
            // 
            this.btnClearCat.Location = new System.Drawing.Point(459, 35);
            this.btnClearCat.Name = "btnClearCat";
            this.btnClearCat.Size = new System.Drawing.Size(178, 23);
            this.btnClearCat.TabIndex = 9;
            this.btnClearCat.Text = "All";
            this.btnClearCat.UseVisualStyleBackColor = true;
            this.btnClearCat.Click += new System.EventHandler(this.btnClearCat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "\"UNDEFINED\"\r\nsearch everywhere";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClearCat);
            this.Controls.Add(this.cbboxFilterType);
            this.Controls.Add(this.txtboxCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listviewCategories);
            this.Controls.Add(this.listviewType);
            this.Controls.Add(this.txtboxFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtboxFilter;
        private System.Windows.Forms.ListView listviewType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listviewCategories;
        private System.Windows.Forms.ColumnHeader colDummy1;
        private System.Windows.Forms.ColumnHeader colDummy2;
        private System.Windows.Forms.TextBox txtboxCategory;
        private System.Windows.Forms.ComboBox cbboxFilterType;
        private System.Windows.Forms.Button btnClearCat;
        private System.Windows.Forms.Label label4;
    }
}