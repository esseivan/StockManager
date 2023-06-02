using ApiClient.Models;
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
        /// <summary>
        /// Not yet approved modified settings
        /// </summary>
        private AppSettings notApprovedNewSettings = new AppSettings();

        /// <summary>
        /// The new app settings class
        /// </summary>
        public AppSettings NewAppSettings { get; set; } = null;

        /// <summary>
        /// Set to 'true' when a change is made by the user
        /// </summary>
        public bool ChangesMade { get; private set; } = false;

        private AppSettings _referenceNewSettings;

        /// <summary>
        /// The current app settings to sync the values shown to the user
        /// </summary>
        public AppSettings ReferenceNewSettings
        {
            get { return _referenceNewSettings; }
            set
            {
                notApprovedNewSettings = _referenceNewSettings = value;
                SyncControls();
            }
        }

        private bool syncing = false;

        public frmOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Apply the setting to the form controls
        /// </summary>
        private void SyncControls()
        {
            syncing = true;
            fontDialog1.Font = ReferenceNewSettings.AppFont;
            checkboxRecent.Checked = ReferenceNewSettings.OpenRecentOnLaunch;
            numDecimals.Value = ReferenceNewSettings.EditCellDecimalPlaces;

            txtboxClientId.Text = ApiClientSettings.GetInstance().ClientId;
            txtboxClientSecret.Text = ApiClientSettings.GetInstance().ClientSecret;
            txtboxClientSecret.UseSystemPasswordChar = true;
            txtboxRedirectUri.Text = ApiClientSettings.GetInstance().RedirectUri;
            txtboxListenUri.Text = ApiClientSettings.GetInstance().ListenUri;

            syncing = false;
        }

        /// <summary>
        /// Apply the new settings to "newAppSettings"
        /// </summary>
        private void SetNewAppSettings()
        {
            NewAppSettings = notApprovedNewSettings;

            // Apply api settings
            ApiClientSettings apiSettings = ApiClientSettings.GetInstance();
            apiSettings.ClientId = txtboxClientId.Text;
            apiSettings.ClientSecret = txtboxClientSecret.Text;
            apiSettings.RedirectUri = txtboxRedirectUri.Text;
            apiSettings.ListenUri = txtboxListenUri.Text;
            apiSettings.Save();
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
            if (syncing)
                return;

            ChangesMade = true;
            notApprovedNewSettings.OpenRecentOnLaunch = checkboxRecent.Checked;
        }

        private void numDecimals_ValueChanged(object sender, EventArgs e)
        {
            if (syncing)
                return;

            ChangesMade = true;
            notApprovedNewSettings.EditCellDecimalPlaces = (int)numDecimals.Value;
        }

        bool isClientSecretShown = false;
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            isClientSecretShown = !isClientSecretShown;
            btnShowHide.Text = isClientSecretShown ? "Hide" : "Show";
            txtboxClientSecret.UseSystemPasswordChar = !isClientSecretShown;
        }

        private void txtboxClientId_TextChanged(object sender, EventArgs e)
        {
            if (syncing) return;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Try connecting to API with GetAccess
        }
    }
}
