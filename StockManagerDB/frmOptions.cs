using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public partial class frmOptions : Form
    {
        private AppSettings notApprovedNewSettings = new AppSettings();
        public AppSettings NewAppSettings { get; set; } = null;

        public bool ChangesMade { get; private set; } = false;

        private AppSettings _referenceNewSettings;
        /// <summary>
        /// The current app settings to sync the values shown to the user
        /// </summary>
        public AppSettings ReferenceNewSettings
        {
            get
            {
                return _referenceNewSettings;
            }
            set
            {
                notApprovedNewSettings = _referenceNewSettings = value;
            }
        }

        public frmOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Apply the new settings to "newAppSettings"
        /// </summary>
        private void SetNewAppSettings()
        {
            NewAppSettings = notApprovedNewSettings;
        }

        /// <summary>
        /// Accept the changes
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            SetNewAppSettings();
            this.Close();
        }

        /// <summary>
        /// Change the font
        /// </summary>
        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = ReferenceNewSettings.AppFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (ReferenceNewSettings.AppFont != fontDialog1.Font)
                {
                    ChangesMade = true;
                    notApprovedNewSettings.AppFont = fontDialog1.Font;
                }
            }
        }

        /// <summary>
        /// Cancel the changes
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reset the settings
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            notApprovedNewSettings = AppSettings.GetDefaultSettings();
        }

        private void checkboxRecent_CheckedChanged(object sender, EventArgs e)
        {
            ChangesMade = true;
            notApprovedNewSettings.OpenRecentOnLaunch = checkboxRecent.Checked;
        }
    }
}
