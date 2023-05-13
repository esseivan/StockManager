namespace StockManagerDB
{
    partial class frmOptions
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.checkboxRecent = new System.Windows.Forms.CheckBox();
            this.numDecimals = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDecimals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(12, 12);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(75, 23);
            this.btnFont.TabIndex = 0;
            this.btnFont.Text = "Change font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(632, 415);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(713, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 415);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // checkboxRecent
            // 
            this.checkboxRecent.AutoSize = true;
            this.checkboxRecent.Location = new System.Drawing.Point(12, 41);
            this.checkboxRecent.Name = "checkboxRecent";
            this.checkboxRecent.Size = new System.Drawing.Size(189, 17);
            this.checkboxRecent.TabIndex = 3;
            this.checkboxRecent.Text = "Automatically open most recent file";
            this.checkboxRecent.UseVisualStyleBackColor = true;
            this.checkboxRecent.CheckedChanged += new System.EventHandler(this.checkboxRecent_CheckedChanged);
            // 
            // numDecimals
            // 
            this.numDecimals.Location = new System.Drawing.Point(159, 64);
            this.numDecimals.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numDecimals.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numDecimals.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDecimals.Name = "numDecimals";
            this.numDecimals.Size = new System.Drawing.Size(41, 20);
            this.numDecimals.TabIndex = 4;
            this.numDecimals.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDecimals.ValueChanged += new System.EventHandler(this.numDecimals_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cell edit decimals";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numDecimals);
            this.Controls.Add(this.checkboxRecent);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFont);
            this.Name = "frmOptions";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numDecimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox checkboxRecent;
        private System.Windows.Forms.NumericUpDown numDecimals;
        private System.Windows.Forms.Label label1;
    }
}