using ApiClient;
using ApiClient.Models;
using ESNLib.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public AppSettings NewAppSettings
        {
            get
            {
                if (!ChangedAccepted)
                    return null;
                return notApprovedNewSettings;
            }
        }

        /// <summary>
        /// Set to 'true' when a change is made by the user
        /// </summary>
        public bool ChangesMade { get; private set; } = false;

        /// <summary>
        /// Are the changes accepted (is 'OK' button pressed)
        /// </summary>
        public bool ChangedAccepted { get; private set; } = false;

        private AppSettings _referenceNewSettings;

        /// <summary>
        /// The current app settings to sync the values shown to the user
        /// </summary>
        public AppSettings ReferenceNewSettings
        {
            get { return _referenceNewSettings; }
            set
            {
                ChangesMade = false;
                notApprovedNewSettings = _referenceNewSettings = value.Clone();
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

            checkBoxDigikeyAPIEnabled.Checked = AppSettings.Settings.IsDigikeyAPIEnabled;
            try
            {
                var apiclientsettings = ApiClientSettings.GetInstance();
                txtboxClientId.Text = apiclientsettings.ClientId;
                txtboxClientSecret.Text = apiclientsettings.ClientSecret;
                txtboxClientSecret.UseSystemPasswordChar = true;
                txtboxRedirectUri.Text = apiclientsettings.RedirectUri;
                txtboxListenUri.Text = apiclientsettings.ListenUri;
            }
            catch (Exception)
            {

            }

            syncing = false;
        }

        /// <summary>
        /// Apply the new settings to "newAppSettings"
        /// </summary>
        private void SetNewAppSettings()
        {
            ChangedAccepted = true;

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
            ChangesMade = true;
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

        private void UpdateApiAccessStatus(bool status)
        {
            lblApiStatus.Text = status ? "Available" : "Unavailable";
            lblApiStatus.BackColor = status ? Color.LightGreen : Color.LightCoral;
        }

        private async void GetApiAccess()
        {
            var client = new ApiClientWrapper();

            bool valid = client.HaveAccess();
            if (valid)
            {
                UpdateApiAccessStatus(valid);
                return;
            }

            ApiClientWrapper.AccessResult result;
            try
            {
                result = await client.GetAccess();
            }
            catch (Exception)
            {
                UpdateApiAccessStatus(false);
                return;
            }

            UpdateApiAccessStatus(result.Success);

            if (!result.Success)
            {
                if (!MiscTools.HasAdminPrivileges())
                {
                    MessageBox.Show("Unable to get API access... Pleasy try running the app with Admin privileges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var res = ESNLib.Controls.Dialog.ShowDialog(new ESNLib.Controls.Dialog.DialogConfig("Unable to get access token... Check the config and the logs", "Error")
                    {
                        Button1 = ESNLib.Controls.Dialog.ButtonType.Ignore,
                        Button2 = ESNLib.Controls.Dialog.ButtonType.Custom1,
                        CustomButton1Text = "Open log",
                        Icon = ESNLib.Controls.Dialog.DialogIcon.Error,
                    });
                    if (res.DialogResult == ESNLib.Controls.Dialog.DialogResult.Custom1)
                    {
                        Process.Start(Logger.Instance.FileOutputPath);
                    }
                }
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Try connecting to API with GetAccess
            GetApiAccess();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            if (AppSettings.Settings.IsDigikeyAPIEnabled)
            {
                var client = new ApiClientWrapper();
                bool valid = client.HaveAccess();
                UpdateApiAccessStatus(valid);
            }
        }

        private void btnClearDigikey_Click(object sender, EventArgs e)
        {
            ApiClientSettings.GetInstance().ClearAndSave();
        }

        private void checkBoxDigikeyAPIEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (syncing)
                return;

            ChangesMade = true;
            AppSettings.Settings.IsDigikeyAPIEnabled = checkBoxDigikeyAPIEnabled.Checked;
        }

        private void btnClearRecent_Click(object sender, EventArgs e)
        {
            ChangesMade = true;
            notApprovedNewSettings.RecentFiles.Clear();
        }
    }
}
