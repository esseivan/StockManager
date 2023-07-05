using ESNLib.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerDB
{
    public class AppSettings
    {
        #region Settings

        /// <summary>
        /// The font used for the app
        /// </summary>
        [JsonIgnore]
        public Font AppFont
        {
            get
            {
                if (_appFont == null)
                {
                    return null;
                }

                return new Font(_appFont.FontFamily, _appFont.Size, _appFont.Style, _appFont.Unit);
            }
            set => _appFont = new SerializableFont(value);
        }

        public SerializableFont _appFont { get; set; }

        /// <summary>
        /// Recent files, where the index 0 is the most recent
        /// </summary>
        public List<string> RecentFiles { get; set; } = new List<string>();

        /// <summary>
        /// Open the most recent file on launch of the app
        /// </summary>
        public bool OpenRecentOnLaunch { get; set; } = false;

        /// <summary>
        /// Number of decimal places when editing a floating point value
        /// </summary>
        public int EditCellDecimalPlaces { get; set; } = 3;

        /// <summary>
        /// The last match kind used (contains, prefix, regix)
        /// </summary>
        public int LastMatchKindUsed { get; set; } = 0;

        /// <summary>
        /// Are Infos columns shown in order form
        /// </summary>
        public bool Order_ShowInfos { get; set; } = false;

        /// <summary>
        /// Are More Infos columns shown in order form
        /// </summary>
        public bool Order_ShowMoreInfos { get; set; } = true;

        /// <summary>
        /// Are actions processed on only checked parts
        /// </summary>
        public bool ProcessActionOnCheckedOnly { get; set; } = true;

        /// <summary>
        /// Is Digikey API enabled
        /// </summary>
        public bool IsDigikeyAPIEnabled { get; set; } = false;

        /// <summary>
        /// Are More Infos columns shown in order form
        /// </summary>
        public bool OrderDoNotExceedLowStock { get; set; } = true;

        /// <summary>
        /// Are More Infos columns shown in order form
        /// </summary>
        public bool OrderMoreUntilLowStockMinimum { get; set; } = false;

        public AppSettings Clone()
        {
            AppSettings cloned = new AppSettings
            {
                _appFont = new SerializableFont(AppFont),
                RecentFiles = new List<string>(this.RecentFiles),
                OpenRecentOnLaunch = this.OpenRecentOnLaunch,
                EditCellDecimalPlaces = this.EditCellDecimalPlaces,
                LastMatchKindUsed = this.LastMatchKindUsed,
                Order_ShowInfos = this.Order_ShowInfos,
                Order_ShowMoreInfos = this.Order_ShowMoreInfos,
                ProcessActionOnCheckedOnly = this.ProcessActionOnCheckedOnly,
                IsDigikeyAPIEnabled = this.IsDigikeyAPIEnabled,
                OrderDoNotExceedLowStock = this.OrderDoNotExceedLowStock,
                OrderMoreUntilLowStockMinimum = this.OrderMoreUntilLowStockMinimum,
            };

            return cloned;
        }

        #endregion

        /// <summary>
        /// Empty settings
        /// </summary>
        public AppSettings()
        {

        }

        /// <summary>
        /// Default settings creation
        /// </summary>
        public AppSettings(Form form)
        {
            AppFont = form.Font;
        }

        private static AppSettings _defaultSettings = null;
        private static AppSettings _settings = null;
        /// <summary>
        /// The current app settings
        /// </summary>
        [JsonIgnore]
        public static AppSettings Settings
        {
            get => _settings;
            set
            {
                UpdateSettings(value);
            }
        }

        public static AppSettings SetDefaultAppSettings(Form frmMain)
        {
            _defaultSettings = new AppSettings(frmMain);
            return _defaultSettings;
        }

        public static bool Load()
        {
            SettingsManager.LoadFromDefault(out AppSettings loadedSettings, zipFile: false);
            if (loadedSettings == null)
            {
                return false;
            }

            _settings = loadedSettings;
            return true;
        }

        public static void Save()
        {
            SettingsManager.SaveToDefault(Settings, SettingsManager.BackupMode.dotBak, indent: true, hide: false, zipFile: false);
        }

        public static void UpdateSettings(AppSettings newSettings)
        {
            _settings = newSettings;
            Save();
        }

        public static AppSettings GetDefaultSettings()
        {
            return _defaultSettings;
        }

        public static void ResetToDefault()
        {
            UpdateSettings(_defaultSettings);
        }
    }

    /// <summary>
    /// Font that can be serialized
    /// </summary>
    public class SerializableFont
    {
        public string FontFamily { get; set; }
        public FontStyle Style { get; set; }
        public float Size { get; set; }
        public GraphicsUnit Unit { get; set; }

        public SerializableFont()
        {

        }

        public SerializableFont(Font font)
        {
            FontFamily = font.FontFamily.Name;
            Style = font.Style;
            Size = font.Size;
            Unit = font.Unit;
        }
    }
}
