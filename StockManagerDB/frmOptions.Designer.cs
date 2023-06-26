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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearDigikey = new System.Windows.Forms.Button();
            this.checkBoxDigikeyAPIEnabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblApiStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.txtboxClientSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtboxListenUri = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtboxRedirectUri = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtboxClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDecimals)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.numDecimals.Margin = new System.Windows.Forms.Padding(2);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearDigikey);
            this.groupBox1.Controls.Add(this.checkBoxDigikeyAPIEnabled);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.lblApiStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnShowHide);
            this.groupBox1.Controls.Add(this.txtboxClientSecret);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtboxListenUri);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtboxRedirectUri);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtboxClientId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(263, 207);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digikey API";
            // 
            // btnClearDigikey
            // 
            this.btnClearDigikey.Location = new System.Drawing.Point(72, 159);
            this.btnClearDigikey.Name = "btnClearDigikey";
            this.btnClearDigikey.Size = new System.Drawing.Size(75, 23);
            this.btnClearDigikey.TabIndex = 10;
            this.btnClearDigikey.Text = "Clear tokens";
            this.btnClearDigikey.UseVisualStyleBackColor = true;
            this.btnClearDigikey.Click += new System.EventHandler(this.btnClearDigikey_Click);
            // 
            // checkBoxDigikeyAPIEnabled
            // 
            this.checkBoxDigikeyAPIEnabled.AutoSize = true;
            this.checkBoxDigikeyAPIEnabled.Location = new System.Drawing.Point(4, 18);
            this.checkBoxDigikeyAPIEnabled.Name = "checkBoxDigikeyAPIEnabled";
            this.checkBoxDigikeyAPIEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxDigikeyAPIEnabled.TabIndex = 9;
            this.checkBoxDigikeyAPIEnabled.Text = "Enabled";
            this.checkBoxDigikeyAPIEnabled.UseVisualStyleBackColor = true;
            this.checkBoxDigikeyAPIEnabled.CheckedChanged += new System.EventHandler(this.checkBoxDigikeyAPIEnabled_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(5, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Warning : These informations are stored as plain text";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(135, 120);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 21);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblApiStatus
            // 
            this.lblApiStatus.AutoSize = true;
            this.lblApiStatus.Location = new System.Drawing.Point(69, 124);
            this.lblApiStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApiStatus.Name = "lblApiStatus";
            this.lblApiStatus.Size = new System.Drawing.Size(63, 13);
            this.lblApiStatus.TabIndex = 7;
            this.lblApiStatus.Text = "Unavailable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 121);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Status";
            // 
            // btnShowHide
            // 
            this.btnShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowHide.Location = new System.Drawing.Point(216, 56);
            this.btnShowHide.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(45, 21);
            this.btnShowHide.TabIndex = 7;
            this.btnShowHide.Text = "Show";
            this.btnShowHide.UseVisualStyleBackColor = true;
            this.btnShowHide.Click += new System.EventHandler(this.btnShowHide_Click);
            // 
            // txtboxClientSecret
            // 
            this.txtboxClientSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxClientSecret.Location = new System.Drawing.Point(72, 57);
            this.txtboxClientSecret.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxClientSecret.Name = "txtboxClientSecret";
            this.txtboxClientSecret.Size = new System.Drawing.Size(140, 20);
            this.txtboxClientSecret.TabIndex = 7;
            this.txtboxClientSecret.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ClientSecret";
            // 
            // txtboxListenUri
            // 
            this.txtboxListenUri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxListenUri.Location = new System.Drawing.Point(72, 99);
            this.txtboxListenUri.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxListenUri.Name = "txtboxListenUri";
            this.txtboxListenUri.Size = new System.Drawing.Size(189, 20);
            this.txtboxListenUri.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ListenUri";
            // 
            // txtboxRedirectUri
            // 
            this.txtboxRedirectUri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxRedirectUri.Location = new System.Drawing.Point(72, 78);
            this.txtboxRedirectUri.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxRedirectUri.Name = "txtboxRedirectUri";
            this.txtboxRedirectUri.Size = new System.Drawing.Size(189, 20);
            this.txtboxRedirectUri.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "RedirectUri";
            // 
            // txtboxClientId
            // 
            this.txtboxClientId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxClientId.Location = new System.Drawing.Point(72, 36);
            this.txtboxClientId.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxClientId.Name = "txtboxClientId";
            this.txtboxClientId.Size = new System.Drawing.Size(189, 20);
            this.txtboxClientId.TabIndex = 7;
            this.txtboxClientId.TextChanged += new System.EventHandler(this.txtboxClientId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ClientId";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numDecimals);
            this.Controls.Add(this.checkboxRecent);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFont);
            this.Name = "frmOptions";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDecimals)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtboxClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowHide;
        private System.Windows.Forms.TextBox txtboxClientSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtboxListenUri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtboxRedirectUri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApiStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxDigikeyAPIEnabled;
        private System.Windows.Forms.Button btnClearDigikey;
    }
}