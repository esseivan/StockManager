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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listviewType = new System.Windows.Forms.ListView();
            this.colDummy2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listviewCategories = new System.Windows.Forms.ListView();
            this.colDummy1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtboxCategory = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 43);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listviewType
            // 
            this.listviewType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy2});
            this.listviewType.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listviewType.HideSelection = false;
            this.listviewType.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listviewType.Location = new System.Drawing.Point(182, 83);
            this.listviewType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listviewType.MultiSelect = false;
            this.listviewType.Name = "listviewType";
            this.listviewType.Size = new System.Drawing.Size(180, 595);
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
            this.label1.Location = new System.Drawing.Point(80, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search for :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search in :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filter categories :";
            // 
            // listviewCategories
            // 
            this.listviewCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy1});
            this.listviewCategories.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listviewCategories.HideSelection = false;
            this.listviewCategories.Location = new System.Drawing.Point(552, 83);
            this.listviewCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listviewCategories.MultiSelect = false;
            this.listviewCategories.Name = "listviewCategories";
            this.listviewCategories.Size = new System.Drawing.Size(180, 595);
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
            this.txtboxCategory.Location = new System.Drawing.Point(552, 45);
            this.txtboxCategory.Name = "txtboxCategory";
            this.txtboxCategory.Size = new System.Drawing.Size(180, 26);
            this.txtboxCategory.TabIndex = 7;
            this.txtboxCategory.TextChanged += new System.EventHandler(this.txtboxCategory_TextChanged);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.txtboxCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listviewCategories);
            this.Controls.Add(this.listviewType);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listviewType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listviewCategories;
        private System.Windows.Forms.ColumnHeader colDummy1;
        private System.Windows.Forms.ColumnHeader colDummy2;
        private System.Windows.Forms.TextBox txtboxCategory;
    }
}