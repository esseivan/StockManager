using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ApiClient;
using ApiClient.Models;
using BrightIdeasSoftware;
using CsvHelper;
using DigikeyApiWrapper;
using ESNLib.Controls;
using ESNLib.Tools;
using ESNLib.Tools.WinForms;
using StockManagerDB.Properties;
using dhs = StockManagerDB.DataHolderSingleton;
using log = StockManagerDB.LoggerClass;

namespace StockManagerDB
{
    public partial class frmMain : Form
    {
        #region Variables

        /// <summary>
        /// filepath to the database
        /// </summary>
        private string filepath
        {
            get => _filepath;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _filepath = value;
                }
                else
                {
                    // Get the same pattern for each filepath
                    FileInfo fi = new FileInfo(value);
                    _filepath = fi.FullName;

                    if (AppSettings.Settings.RecentFiles.Contains(_filepath))
                    {
                        // Move it to #1
                        AppSettings.Settings.RecentFiles.Remove(_filepath);
                    }
                    AppSettings.Settings.RecentFiles.Insert(0, _filepath);
                    if (AppSettings.Settings.RecentFiles.Count > 5)
                    {
                        AppSettings.Settings.RecentFiles = AppSettings
                            .Settings.RecentFiles.Take(5)
                            .ToList();
                    }
                    AppSettings.Save();
                }
            }
        }
        private string _filepath = string.Empty;

        /// <summary>
        /// Manage the lists
        /// </summary>
        private dhs data => dhs.Instance;

        /// <summary>
        /// List of parts in the database
        /// </summary>
        private Dictionary<string, Part> Parts => data.Parts;

        /// <summary>
        /// Indicate if a file is loaded
        /// </summary>
        private bool IsFileLoaded => (null != data);

        /// <summary>
        /// Recent file menu item list
        /// </summary>
        private Dictionary<int, ToolStripMenuItem> RecentFileMenuItems = null;

        /// <summary>
        /// Update CheckListView when checkItemChanged
        /// </summary>
        private bool ShouldUpdateCheckedListview
        {
            get { return _updateOnCheck; }
            set
            {
                _updateOnCheck = value;
                if (_updateOnCheck)
                {
                    UpdateCheckedListviewContent();
                }
            }
        }
        private bool _updateOnCheck = true;

        private frmProjects _projectForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmProjects projectForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_projectForm == null)
                    {
                        _projectForm = new frmProjects();
                        _projectForm.FormClosed += FrmProjects_FormClosed;
                        _projectForm.OnPartEditRequested += FrmProjects_OnPartEditRequested;
                        _projectForm.OnProjectProcessRequested +=
                            FrmProjects_OnProjectProcessRequested;
                        _projectForm.OnProjectOrder += FrmProjects_OnProjectOrder;
                    }
                }
                else
                {
                    if (_projectForm != null)
                    {
                        _projectForm.Close();
                        _projectForm = null;
                    }
                }
                return _projectForm;
            }
            set
            {
                _projectForm?.Close();
                _projectForm = value;
            }
        }

        private frmHistory _historyForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmHistory historyForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_historyForm == null)
                    {
                        _historyForm = new frmHistory();
                        _historyForm.FormClosed += _historyForm_FormClosed;
                    }
                }
                else
                {
                    if (_historyForm != null)
                    {
                        _historyForm.Close();
                        _historyForm = null;
                    }
                }
                return _historyForm;
            }
            set
            {
                _historyForm?.Close();
                _historyForm = value;
            }
        }

        private frmOrder _orderForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmOrder orderForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_orderForm == null)
                    {
                        _orderForm = new frmOrder();
                        _orderForm.FormClosing += _orderForm_FormClosing;
                    }
                }
                else
                {
                    if (_orderForm != null)
                    {
                        _orderForm.Close();
                        _orderForm = null;
                    }
                }
                return _orderForm;
            }
            set
            {
                _orderForm?.Close();
                _orderForm = value;
            }
        }

        private frmSearch _searchForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmSearch searchForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_searchForm == null)
                    {
                        _searchForm = new frmSearch();
                        _searchForm.FormClosed += _searchForm_FormClosed;
                        _searchForm.OnFilterSet += FrmSearch_OnFilterSet;
                        _searchForm.Text = "Parts Advanced Filter";
                    }
                }
                else
                {
                    if (_searchForm != null)
                    {
                        _searchForm.Close();
                        _searchForm = null;
                    }
                }
                return _searchForm;
            }
            set
            {
                _searchForm?.Close();
                _searchForm = value;
            }
        }

        private frmActionProject _actionProjectForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmActionProject actionProjectForm
        {
            get
            {
                if (IsFileLoaded)
                {
                    if (_actionProjectForm == null)
                    {
                        _actionProjectForm = new frmActionProject();
                        _actionProjectForm.FormClosed += _searchForm_FormClosed;
                    }
                }
                else
                {
                    if (_actionProjectForm != null)
                    {
                        _actionProjectForm.Close();
                        _actionProjectForm = null;
                    }
                }
                return _actionProjectForm;
            }
            set
            {
                _actionProjectForm?.Close();
                _actionProjectForm = value;
            }
        }

        private frmOptions _optionsForm = null;

        /// <summary>
        /// The form that displays projects
        /// </summary>
        private frmOptions optionsForm
        {
            get
            {
                if (_optionsForm == null)
                {
                    _optionsForm = new frmOptions();
                    _optionsForm.FormClosed += _optionsForm_FormClosed;
                }
                return _optionsForm;
            }
            set
            {
                _optionsForm?.Close();
                _optionsForm = value;
            }
        }

        /// <summary>
        /// Current version of the app
        /// </summary>
        public string VersionLabel
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    Version ver = System
                        .Deployment
                        .Application
                        .ApplicationDeployment
                        .CurrentDeployment
                        .CurrentVersion;
                    return string.Format(
                        "Product Name: {4}, Version: {0}.{1}.{2}.{3}",
                        ver.Major,
                        ver.Minor,
                        ver.Build,
                        ver.Revision,
                        Assembly.GetEntryAssembly().GetName().Name
                    );
                }
                else
                {
                    var ver = Assembly.GetExecutingAssembly().GetName().Version;
                    return string.Format(
                        "Product Name: {4}, Version: {0}.{1}.{2}.{3}",
                        ver.Major,
                        ver.Minor,
                        ver.Build,
                        ver.Revision,
                        Assembly.GetEntryAssembly().GetName().Name
                    );
                }
            }
        }

        #endregion

        #region Static to export

        /// <summary>
        /// Return either cmd line arguments or Click once arguments. Click once have priority
        /// </summary>
        private static string[] GetCmdlineArgs()
        {
            string[] cmdLineArgs = Environment.GetCommandLineArgs().Skip(1).ToArray(); // Skip executable path
            string[] clickOnceArgs =
                AppDomain.CurrentDomain.SetupInformation.ActivationArguments?.ActivationData
                ?? new string[0];

            for (int i = 0; i < clickOnceArgs.Length; i++)
            {
                // Convert special characters (e.g. %20 to a space)
                clickOnceArgs[i] = System.Web.HttpUtility.UrlDecode(clickOnceArgs[i]);
            }

            string[] args = clickOnceArgs.Length > 0 ? clickOnceArgs : cmdLineArgs;

            return args;
        }

#warning Test this stuff...
        /// <summary>
        /// Return true if the string starts and ends with quotes "..."
        /// </summary>
        /// <param name="text">Trimmed string</param>
        private static bool IsStringQuoted(string text)
        {
            // Detect exact match, only in non-regex mode
            Regex regexDetectExact = new Regex("^[\"][^\"]{1,}[\"]$");
            Match result = regexDetectExact.Match(text);

            return result.Success;
        }

        /// <summary>
        /// Return the corresponding string for and exact matching filtering.
        /// </summary>
        /// <param name="baseText">Quoted text</param>
        /// <param name="isPrefix">Set to true if the match must start with the string</param>
        private static string GetRegexStringForExactFiltering(string baseText, bool isPrefix)
        {
            // Remove quotes
            string t = Regex.Escape(baseText);

            Regex regexStr;
            if (isPrefix)
            {
                regexStr = new Regex($"^{t}");
            }
            else
            {
                regexStr = new Regex($"((^)|( )){t}");
            }

            return regexStr.ToString();
        }

        #endregion

        /// <summary>
        /// Indicate initialisation in progress. Do process controls events during this
        /// </summary>
        private readonly bool initInProgress = true;

        public frmMain()
        {
            InitializeComponent();

            string[] args = GetCmdlineArgs();

            // Set production endpoints for API
            ApiClientSettings.SetProductionMode();

            // Logger config
            log.Init();
            log.Write("Application started...", Logger.LogLevels.Info);
            log.Write(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"), Logger.LogLevels.Info);
            log.Write($"Arguments : {string.Join(" ", args)}", Logger.LogLevels.Info);

            // API settings
            SettingsManager.MyPublisherName = "ESN";
            SettingsManager.MyAppName = "StockManager";
            ApiClientSettings.SetFilePath(
                SettingsManager.MyPublisherName,
                SettingsManager.MyAppName
            );
            ApiClientSettings.GetInstance();

            // App settings
            string settingsPath = SettingsManager.GetDefaultSettingFilePath(false); // Get recommended path
            log.Write($"Loading settings from {settingsPath}...");
            AppSettings.SetDefaultAppSettings(this); // Set the default settings
            if (!AppSettings.Load())
            {
                AppSettings.ResetToDefault();
            }
            ApplySettings();

            // Setup listviews
            InitialiseListviewsAndColumns();
            listviewParts.DefaultRenderer = filterHighlightRenderer;
            listviewParts.AllowCheckWithSpace = false;

            panelPartInfos.Visible = false;

            // Set default filter type
            cbboxFilterType.SelectedIndex = AppSettings.Settings.LastMatchKindUsed;

            // Set number label
            UpdateNumberOfPartsLabel();
            SetStatus("Idle...");

            // Get open arguments
            if (args.Length == 1)
            {
                string file = args[0];
                if (file.StartsWith("file:///"))
                {
                    file = file.Remove(0, 8);
                }

                // Open requested file
                SetWorkingStatus();
                bool result = OpenFile(file);
                SetSuccessStatus(result);
            }
            else
            {
                // Open most recent file
                if (AppSettings.Settings.OpenRecentOnLaunch)
                {
                    log.Write($"Openning most recent file...", Logger.LogLevels.Info);
                    if (AppSettings.Settings.RecentFiles.Count > 0)
                    {
                        SetWorkingStatus();
                        bool result = OpenFile(AppSettings.Settings.RecentFiles[0]);
                        SetSuccessStatus(result);
                    }
                }
            }

            // Indicate starting process done
            initInProgress = false;
        }

        #region Settings

        /// <summary>
        /// Apply the settings to the application
        /// </summary>
        public void ApplySettings()
        {
            /**** Font ****/
            //Font newFontNormal = new Font(newFont, FontStyle.Regular);
            if (AppSettings.Settings.AppFont == null)
            {
                AppSettings.ResetToDefault();
            }
            Font newFontNormal = AppSettings.Settings.AppFont; // If user has set bold for all, then set bold for all
            this.Font = newFontNormal;
            //this.menuStrip1.Font = this.statusStrip1.Font = newFontNormal;
            // Apply bold fonts
            Font newFontBold = new Font(
                AppSettings.Settings.AppFont,
                FontStyle.Bold | AppSettings.Settings.AppFont.Style
            ); // Add bold style
            this.label1.Font = this.label2.Font = newFontBold;

            /**** States ****/
            onlyAffectCheckedPartsToolStripMenuItem.Checked = AppSettings
                .Settings
                .ProcessActionOnCheckedOnly;

            updateFromDigikeyToolStripMenuItem.Enabled = AppSettings.Settings.IsDigikeyAPIEnabled;
        }

        #endregion

        #region Listviews and display

        #region Form Search, Advanced Filtering

        /// <summary>
        /// Clear all filtering for the parts
        /// </summary>
        private void ClearAdvancedFiltering()
        {
            olvcCat.UseFiltering = false;
            olvcCat.ValuesChosenForFiltering = null;
            // Must define to non null first to update categories
            listviewParts.AdditionalFilter = new TextMatchFilter(listviewParts);
            listviewParts.AdditionalFilter = null;
        }

        /// <summary>
        /// Advanced filter callback
        /// </summary>
        private void FrmSearch_OnFilterSet(object sender, FilterEventArgs e)
        {
            this.BringToFront();
            searchForm.BringToFront();

            // Clear filter on this form
            txtboxFilter.Clear();

            // Apply filter
            string txt = e.text;
            Part.Parameter filterIn = (Part.Parameter)e.filterIn;
            string category = e.category;
            int matchKind = e.filterType;
            ObjectListView olv = listviewParts;

            List<TextMatchFilter> filters = GetFilters(txt, (FilterMatchKind)matchKind, olv);

            // Apply the filter to the selected column
            filterHighlightRenderer.FilterInColumn = null;
            if (filters != null)
            {
                OLVColumn column = null;

                switch (filterIn)
                {
                    case Part.Parameter.MPN:
                        column = olvcMPN;
                        break;
                    case Part.Parameter.Manufacturer:
                        column = olvcMAN;
                        break;
                    case Part.Parameter.Description:
                        column = olvcDesc;
                        break;
                    case Part.Parameter.Category:
                        column = olvcCat;
                        break;
                    case Part.Parameter.Location:
                        column = olvcLocation;
                        break;
                    case Part.Parameter.Stock:
                        column = olvcStock;
                        break;
                    case Part.Parameter.LowStock:
                        column = olvcLowStock;
                        break;
                    case Part.Parameter.Price:
                        column = olvcPrice;
                        break;
                    case Part.Parameter.Supplier:
                        column = olvcSupplier;
                        break;
                    case Part.Parameter.SPN:
                        column = olvcSPN;
                        break;
                    default:
                        break;
                }

                if (column != null)
                {
                    OLVColumn[] col = new OLVColumn[] { column };
                    filters.ForEach((f) => f.Columns = col);
                }
                filterHighlightRenderer.FilterInColumn = column;
            }

            // Filter for selected category
            if (!string.IsNullOrEmpty(category))
            {
                // Apply category filter
                olvcCat.ValuesChosenForFiltering = new string[] { category };
                olvcCat.UseFiltering = true;
            }
            else
            {
                olvcCat.UseFiltering = false;
            }

            CompositeAllFilter allFilters = new CompositeAllFilter(
                filters.Cast<IModelFilter>().ToList()
            );
            olv.AdditionalFilter = allFilters;
        }

        #endregion

        /// <summary>
        /// Indicate that some parts have changed. A listview update is required
        /// </summary>
        private void NotifyPartsHaveChanged()
        {
            // Save changes and update listview
            dhs.Instance.InvokeOnPartListModified(EventArgs.Empty);
            // Save changes to file
            data.Save();
            UpdateListviewContent();

            // Update history if open
            historyForm?.UpdateList();
        }

        /// <summary>
        /// Set the title of the form
        /// </summary>
        private void UpdateFormTitle()
        {
            if (IsFileLoaded)
            {
                this.Text = $"Stock Manager - {Path.GetFileName(filepath)}";
            }
            else
            {
                this.Text = "Stock Manager";
            }
        }

        /// <summary>
        /// Update the label at the bottom that displays the number of parts
        /// </summary>
        private void UpdateNumberOfPartsLabel()
        {
            if (!IsFileLoaded)
            {
                labelCount.Text = "No database open...";
            }
            else
            {
                labelCount.Text =
                    $"{listviewParts.FilteredObjects.Cast<object>().Count()}/{Parts.Count}";
            }
        }

        /// <summary>
        /// Update the listviews contents
        /// </summary>
        /// <param name="resizeColumns">Resize the columns of the main listview</param>
        private void UpdateListviewContent(bool resizeColumns = false)
        {
            log.Write($"Updating part listview..", Logger.LogLevels.Trace);

            // If not file loaded, set the listviews as empty
            if (!IsFileLoaded)
            {
                log.Write($"No file loaded. Aborting...", Logger.LogLevels.Trace);
                listviewParts.DataSource = new List<Part>();
                btnPartAdd.Enabled = btnPartDup.Enabled = false;
                return;
            }

            // save the selected item
            Part lastItem = listviewParts.SelectedObject as Part;
            // Get eventual seleted item
            Point lastScroll = listviewParts.LowLevelScrollPosition;

            // Main list view : all parts
            listviewParts.DataSource = Parts.Values.ToList();

            // Set buttons state
            btnPartDup.Enabled = listviewParts.Items.Count != 0;
            btnPartAdd.Enabled = IsFileLoaded;

            // Resize columns if requested
            if (resizeColumns)
            {
                log.Write($"Resizing columns...", Logger.LogLevels.Trace);
                listviewParts.AutoResizeColumns();
            }

            // Set focus to main listview
            listviewParts.Focus();

            // Select the last item
            if (lastItem != null)
            {
                listviewParts.SelectObject(lastItem);
            }

            try
            {
#warning Todo : Find another way for this, maybe check DPI, maybe check vertical line scroll value ?
                const int factor = 23; // Looks like the perfect error<->correction factor is 23
                // Maybe depends of the machine ?

                int delta = lastScroll.Y - listviewParts.LowLevelScrollPosition.Y;
                Console.WriteLine($"Delta is '{delta}'. Increment {delta * factor}...");
                listviewParts.LowLevelScroll(0, delta * factor);
            }
            catch (Exception ex)
            {
                log.Write("Unable to scroll to last position : ", Logger.LogLevels.Error);
                log.Write(ex.Message, Logger.LogLevels.Error);
            }

            // Update the number label
            UpdateNumberOfPartsLabel();
            // Update the checked listview
            UpdateCheckedListviewContent();
            // Set orderForm suppliers
            orderForm.SetSuppliers(Parts.Select((x) => x.Value.Supplier).Distinct());

            log.Write($"Updating part listview finished", Logger.LogLevels.Trace);
        }

        /// <summary>
        /// Update the checked listview content
        /// </summary>
        private void UpdateCheckedListviewContent()
        {
            // Wether to update the checkedlistview or not.
            // Usefull to disable when using the CheckAll and UnCheckAll actions
            // Otherwise, it will be called a lot of times...
            if (!ShouldUpdateCheckedListview)
            {
                return;
            }
        }

        /// <summary>
        /// Initialisation of the listviews
        /// </summary>
        private void InitialiseListviewsAndColumns()
        {
            // Setup columns
            olvcMPN.AspectGetter = delegate(object x)
            {
                return ((Part)x).MPN;
            };
            olvcMAN.AspectGetter = delegate(object x)
            {
                return ((Part)x).Manufacturer;
            };
            olvcDesc.AspectGetter = delegate(object x)
            {
                return ((Part)x).Description;
            };
            olvcCat.AspectGetter = delegate(object x)
            {
                return ((Part)x).Category;
            };
            olvcLocation.AspectGetter = delegate(object x)
            {
                return ((Part)x).Location;
            };
            olvcStock.AspectGetter = delegate(object x)
            {
                return ((Part)x).Stock;
            };
            olvcLowStock.AspectGetter = delegate(object x)
            {
                return ((Part)x).LowStock;
            };
            olvcPrice.AspectGetter = delegate(object x)
            {
                return ((Part)x).Price;
            };
            olvcSupplier.AspectGetter = delegate(object x)
            {
                return ((Part)x).Supplier;
            };
            olvcSPN.AspectGetter = delegate(object x)
            {
                return ((Part)x).SPN;
            };

            // Make the decoration
            RowBorderDecoration rbd = new RowBorderDecoration
            {
                BorderPen = new Pen(Color.FromArgb(128, Color.DeepSkyBlue), 2),
                BoundsPadding = new Size(1, 1),
                CornerRounding = 4.0f,
            };

            // Put the decoration onto the hot item
            listviewParts.HotItemStyle = new HotItemStyle
            {
                BackColor = Color.Azure,
                Decoration = rbd,
            };
        }

        private void CellEditBoxModifications(object sender, CellEditEventArgs e)
        {
            if (e.Column.Index == 0)
            {
                return;
            }

            e.ListViewItem.Focused = true;

            // Float edit, apply decimal places
            if (e.Control is FloatCellEditor num)
            {
                num.DecimalPlaces = AppSettings.Settings.EditCellDecimalPlaces;
            }

            // Ensure edit box in view, scroll horizontally if required
            Rectangle columnBounds = listviewParts.CalculateColumnVisibleBounds(
                listviewParts.Bounds,
                e.Column
            );
            int maxX = listviewParts.Width - 21; // Scroll bar + edges : 21 offset
            int leftSide = columnBounds.X;
            int rightSide = leftSide + columnBounds.Width;

            int dx = 0;
            if (leftSide < 0)
            {
                // Scroll left
                dx = leftSide;
            }
            else if (rightSide > maxX)
            {
                // Scroll right
                dx = rightSide - maxX;
            }
            if (dx != 0)
            {
                Console.WriteLine($"scroll dx={dx}");
                listviewParts.PauseAnimations(true);
                listviewParts.LowLevelScroll(dx, 0);
                listviewParts.Invalidate();
                listviewParts.PauseAnimations(false);
            }
        }

        #region TextFiltering

        /// <summary>
        /// Filter a text in the main part listview
        /// </summary>
        /// <param name="txt">Text to filter</param>
        /// <param name="matchKind">Type of filter</param>
        public void Filter(string txt, FilterMatchKind matchKind)
        {
            ObjectListView olv = listviewParts;

            var filters = GetFilters(txt, matchKind, olv);

            olv.AdditionalFilter =
                (filters == null)
                    ? null
                    : new CompositeAllFilter(filters.Cast<IModelFilter>().ToList());

            // Filter will change the number of parts displayed
            UpdateNumberOfPartsLabel();
        }

        /// <summary>
        /// What kind of filtering is selected
        /// </summary>
        public enum FilterMatchKind
        {
            /// <summary>
            /// Search for anywhere in the text
            /// </summary>
            Anywhere = 0,

            /// <summary>
            /// Search at the beginning of the text
            /// </summary>
            Begninning = 1,

            /// <summary>
            /// Interpret the filter as a regex
            /// </summary>
            Regex = 2,
        }

        /// <summary>
        /// Filter a text in the main part listview
        /// </summary>
        /// <param name="txt">Text to filter</param>
        /// <param name="matchKind">Type of filtering</param>
        public List<TextMatchFilter> GetFilters(
            string txt,
            FilterMatchKind matchKind,
            ObjectListView olv
        )
        {
            // List of generated filters for the listview
            List<TextMatchFilter> filters = new List<TextMatchFilter>();

            bool isPrefix = matchKind == FilterMatchKind.Begninning;

            if (!string.IsNullOrEmpty(txt))
            {
                string[] space_separated_text;
                List<string> text_exact_list = new List<string>();

                Regex regex_quotes = new Regex("\"(([^\"]|\\\\\")+(?<!\\\\))\"");
                if (regex_quotes.IsMatch(txt) && matchKind != FilterMatchKind.Regex) // Regex use all the txt input as is
                {
                    var matches = regex_quotes.Matches(txt);

                    // Exact matching found. Add them and remove them from the input
                    foreach (Match match in matches)
                    {
                        // Only select group #1
                        Capture group = match.Groups[1];
                        string regexStr = group.Value;
                        regexStr = regexStr.Replace("\\\"", "\"");
                        regexStr = GetRegexStringForExactFiltering(regexStr, isPrefix);
                        text_exact_list.Add(regexStr);
                    }

                    txt = regex_quotes.Replace(txt, "");
                }
                space_separated_text = txt.Split(' ')
                    .Where((x) => !string.IsNullOrEmpty(x))
                    .ToArray();

                switch (matchKind)
                {
                    case FilterMatchKind.Anywhere:
                        foreach (string item in text_exact_list)
                        {
                            filters.Add(TextMatchFilter.Regex(olv, item));
                        }
                        foreach (string textEntry in space_separated_text)
                        {
                            filters.Add(TextMatchFilter.Contains(olv, textEntry));
                        }
                        break;

                    case FilterMatchKind.Begninning:
                        foreach (string item in text_exact_list)
                        {
                            filters.Add(TextMatchFilter.Regex(olv, item));
                        }
                        foreach (string textEntry in space_separated_text)
                        {
                            filters.Add(TextMatchFilter.Prefix(olv, textEntry));
                        }
                        break;

                    case FilterMatchKind.Regex:
                        // Set it as is
                        filters.Add(TextMatchFilter.Regex(olv, txt));
                        break;

                    default:
                        break;
                }
            }

            return filters;
        }

        /// <summary>
        /// Called when the filter text is changed
        /// </summary>
        private void txtboxFilter_TextChanged(object sender, EventArgs e)
        {
            Filter(txtboxFilter.Text, (FilterMatchKind)this.cbboxFilterType.SelectedIndex);
        }

        /// <summary>
        /// Called when the filter type is changed
        /// </summary>
        private void cbboxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initInProgress)
            {
                return;
            }

            Filter(txtboxFilter.Text, (FilterMatchKind)this.cbboxFilterType.SelectedIndex);

            // Save last type used
            AppSettings.Settings.LastMatchKindUsed = cbboxFilterType.SelectedIndex;
        }

        #endregion
        #endregion

        #region File management

        /// <summary>
        /// Import the specified file into a list of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Class for each row</typeparam>
        /// <param name="filename">File path</param>
        /// <param name="currentLinks">Current header to <typeparamref name="T"/> Properties (as string)</param>
        /// <returns>List of imported objects, or null if failed/canceled</returns>
        private static List<T> ImportExcelFileAsGeneric<T>(
            string filename,
            ref Dictionary<string, string> currentLinks
        )
            where T : new()
        {
            // Read file
            string data = ExcelWrapperV2.ReadSheetCSV(filename);

            // Ask the user the link between the header and the Part property
            CsvImportAs<T> importer = new CsvImportAs<T>();
            var links = importer.AskUserHeadersLinks(data, currentLinks);

            if (links == null) // User cancelled
            {
                return null;
            }

            // Convert to <string,string> in order to save to the settings
            Dictionary<string, string> converted = new Dictionary<string, string>();
            foreach (var item in links)
            {
                if (item.Value == null)
                {
                    continue;
                }
                converted.Add(item.Key, item.Value.Name);
            }
            currentLinks = converted;
            AppSettings.Save();

            // Actually import
            List<T> importedItems = importer.ImportData(data, currentLinks);

            return importedItems;
        }

        /// <summary>
        /// Import parts from excel file into the database
        /// </summary>
        private bool ImportPartsFromAnyExcel()
        {
            log.Write($"Importing Parts Excel file...");

            // A file must be loaded prior to importing.
            if (!IsFileLoaded)
            {
                log.Write("Unable to load Excel file when no Data file is loaded");
                MessageBox.Show(
                    "No file loaded ! Open one or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" }; // TODO No filter yet, maybe one day ?
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            log.Write($"File selected for Excel import : {ofd.FileName}");

            // Import the file
            Cursor = Cursors.WaitCursor;
            Dictionary<string, string> currentLinks = AppSettings.Settings.lastCsvPartsLinks;
            List<Part> importedItems = ImportExcelFileAsGeneric<Part>(
                ofd.FileName,
                ref currentLinks
            );
            AppSettings.Settings.lastCsvPartsLinks = currentLinks;
            Cursor = Cursors.Default;

            // Nothing imported
            if ((null == importedItems) || (0 == importedItems.Count))
            {
                log.Write("No part found in that file");
                return false;
            }

            log.Write($"{importedItems.Count} part(s) found in that file");

            var res = MessageBox.Show(
                $"Please confirm the additions of '{importedItems.Count}' parts to the current stock. This cannot be undone\nContinue ?",
                "Warning",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
            );
            if (res != DialogResult.Yes)
            {
                return false;
            }

            log.Write("Import confirmed by user. Processing...");
            // Add the parts to the list
            Cursor = Cursors.WaitCursor;
            foreach (Part item in importedItems)
            {
                // Part already present. Do nothing...
                if (Parts.ContainsKey(item.MPN))
                {
                    log.Write(
                        $"Duplicate part found : MPN={item.MPN}. Skipping this part...",
                        Logger.LogLevels.Warn
                    );
                }
                else
                {
                    this.data.AddPart(item, note: "Imported Excel ");
                }
            }
            Cursor = Cursors.Default;

            log.Write($"Import finished");
            NotifyPartsHaveChanged();

            return true;
        }

        /// <summary>
        /// Apply the order from excel file into the database
        /// </summary>
        private bool ApplyOrderFromExcel()
        {
            log.Write($"Importing Order Excel file...");

            // A file must be loaded prior to importing.
            if (!IsFileLoaded)
            {
                log.Write("Unable to load Excel file when no Data file is loaded");
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" }; // TODO
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            log.Write($"File selected for Excel import : {ofd.FileName}");

            // Import the file
            Cursor = Cursors.WaitCursor;
            Dictionary<string, string> currentLinks = AppSettings.Settings.lastCsvOrderLinks;
            List<OrderMaterial> importedItems = ImportExcelFileAsGeneric<OrderMaterial>(
                ofd.FileName,
                ref currentLinks
            );
            AppSettings.Settings.lastCsvPartsLinks = currentLinks;
            Cursor = Cursors.Default;

            // Nothing imported
            if ((null == importedItems) || (0 == importedItems.Count))
            {
                log.Write("No part found in that file");
                return false;
            }

            // Confirmation
            log.Write($"{importedItems.Count} part(s) found in that file");
            var res = MessageBox.Show(
                $"Please confirm the process of '{importedItems.Count}' items from the order to the current stock. This cannot be undone\nContinue ?",
                "Warning",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
            );
            if (res != DialogResult.Yes)
            {
                return false;
            }

            log.Write($"Import confirmed by user. Processing...");
            // Add the parts to the list
            Cursor = Cursors.WaitCursor;
            List<Material> processingList = importedItems.Select((x) => new Material(x)).ToList(); // Convert the list to material class
            this.ApplyInputOfMaterials(processingList, 1, "Order process from import "); // multiplier -1 to add the elements (because positive removes them)
            Cursor = Cursors.Default;

            log.Write($"Import finished");
            NotifyPartsHaveChanged();

            return true;
        }

        /// <summary>
        /// Create a new save file
        /// </summary>
        private bool CreateNewSaveFile()
        {
            log.Write($"Creating new data file");
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };
            if (fsd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            log.Write($"Filepath selected is : {fsd.FileName}");
            // Never overwrite files. Ask the user to manually delete the file...
            if (File.Exists(fsd.FileName))
            {
                log.Write($"This file already exists. Aborting...");
                MessageBox.Show(
                    "This file already exists.\nPlease select another one or manually delete that file...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            log.Write($"Creating data file at the selected path");
            // Closing current file
            if (!string.IsNullOrEmpty(filepath))
            {
                CloseFile();
            }
            // Save selectced path
            filepath = fsd.FileName;
            // Create new empty file (with template part)
            dhs.LoadNew(filepath);
            data.Save(); // Then save
            UpdateFormTitle();
            // Update listviews content + resize columns
            UpdateListviewContent(resizeColumns: true);
            log.Write($"File creation finished");

            return true;
        }

        /// <summary>
        /// Open a file that the user will choose
        /// </summary>
        private bool OpenFile()
        {
            log.Write($"Openning data file...");
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                log.Write($"Cancelled by user...");
                return false;
            }
            log.Write($"File selected : {ofd.FileName}");

            return OpenFile(ofd.FileName);
        }

        /// <summary>
        /// Open the specified file
        /// </summary>
        private bool OpenFile(string file)
        {
            if (string.IsNullOrEmpty(file) || (!File.Exists(file)))
            {
                log.Write($"Could not find file '{file}'...", Logger.LogLevels.Error);
                MessageBox.Show(
                    $"Error\nFile '{file}' not found...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Closing current file
            if (!string.IsNullOrEmpty(filepath))
            {
                CloseFile();
            }

            // Save path
            filepath = file;
            // Load the file
            log.Write($"Openning file '{filepath}'...");
            try
            {
                dhs.LoadNew(filepath);
            }
            catch (Exception)
            {
                log.Write($"Openning failed...", Logger.LogLevels.Error);
                filepath = null;
                return false;
            }

            UpdateFormTitle();
            // Update listviews content + resize columns
            UpdateListviewContent(resizeColumns: true);
            log.Write($"Open finished. {Parts.Count} part(s) found");

            UpdateRecentFileList();

            return true;
        }

        /// <summary>
        /// Close the currently open file
        /// </summary>
        private bool CloseFile()
        {
            log.Write($"Closing file : '{filepath}'", Logger.LogLevels.Info);
            _searchForm?.Close();
            _projectForm?.Close();
            _historyForm?.Close();
            _orderForm?.Close();
            _actionProjectForm?.Close();
            _optionsForm?.Close();
            data.Close();
            filepath = null;
            UpdateFormTitle();
            UpdateListviewContent();
            return true;
        }
        #endregion

        #region PartManagement

        /// <summary>
        /// Toggle the checked status for the selected part
        /// </summary>
        private void ToggleCheckedForSelectedPart()
        {
            bool state = listviewParts.IsChecked(listviewParts.SelectedObjects[0]);
            state = !state;

            // 'hack' to check selected rows but call the CheckedChanged event only once
            ShouldUpdateCheckedListview = false;
            if (state)
            {
                listviewParts.CheckObjects(listviewParts.SelectedObjects);
            }
            else
            {
                listviewParts.UncheckObjects(listviewParts.SelectedObjects);
            }
            ShouldUpdateCheckedListview = true;
        }

        /// <summary>
        /// Get all parts
        /// </summary>
        private List<Part> GetAllParts()
        {
            return Parts.Values.ToList();
        }

        /// <summary>
        /// Get the checked parts of the main listview. Note that they are also affected by filters.
        /// </summary>
        private List<Part> GetCheckedParts()
        {
            return listviewParts.CheckedObjectsEnumerable.Cast<Part>().ToList();
        }

        /// <summary>
        /// Get the checked parts of the main listview. Note that they are also affected by filters.
        /// </summary>
        private List<Part> GetSelectedParts()
        {
            return listviewParts.SelectedObjects.Cast<Part>().ToList();
        }

        /// <summary>
        /// Return parts that will be processed in the next action (according to Action only for checked parts Checkbox)
        /// </summary>
        private List<Part> GetValidPartsForActions()
        {
            // If "onlyAffectCheckedParts" is checked, get checked parts. Otherwise all parts
            if (AppSettings.Settings.ProcessActionOnCheckedOnly)
            {
                log.Write($"Action executing on checked parts only...");
                return GetCheckedParts();
            }

            return GetAllParts();
        }

        /// <summary>
        /// Create a new empty part to the part list
        /// </summary>
        private bool CreateNewEmptyPart()
        {
            log.Write($"Creating a new empty part...");
            // Ask the user for the MPN
            Dialog.ShowDialogResult result = Dialog.ShowDialog(
                "Enter the MPN (Manufacturer Product Number) for the part...",
                Title: "Enter input",
                Input: true,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );

            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                log.Write($"Operation cancelled by user. Aborting...");
                return false;
            }

            log.Write($"Creating a new part with MPN='{result.UserInput}' ...");

            if (Parts.ContainsKey(result.UserInput))
            {
                log.Write(
                    $"Unable to add the new part. The specified MPN is already present...",
                    Logger.LogLevels.Error
                );
                MessageBox.Show(
                    "Unable to add the new part. The specified MPN is already present...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Create empty part with the specified MPN
            Part pc = new Part() { MPN = result.UserInput };
            // Apply filter to display the newly created part
            cbboxFilterType.SelectedIndex = 0;
            txtboxFilter.Text = $"\"{pc.MPN}\"";

            // Add to the list
            data.AddPart(pc);
            NotifyPartsHaveChanged();
            log.Write($"Part created successfully");

            return true;
        }

        /// <summary>
        /// Delete the selected parts
        /// </summary>
        private bool DeleteSelectedParts()
        {
            log.Write($"Deletion of selected parts...");
            var selectedParts = GetSelectedParts();

            // If none checked, abort
            if (0 == selectedParts.Count)
            {
                log.Write($"No parts selected. Aborting...");
                return false;
            }

            // Ask confirmation
            var res = MessageBox.Show(
                $"Please confirm the deletion of '{selectedParts.Count}' parts. This cannot be undone !\nContinue ?",
                "Warning",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
            );

            if (res != DialogResult.Yes)
            {
                log.Write($"Confirmation denied");
                return false;
            }

            log.Write($"Deletion of {selectedParts.Count} part(s)...", Logger.LogLevels.Debug);

            // Remove them from the list
            selectedParts.ForEach((part) => data.DeletePart(part));
            log.Write($"Deletion finished");
            NotifyPartsHaveChanged();

            return true;
        }

        /// <summary>
        /// Duplicate the single selected (not checked) part
        /// </summary>
        private void DuplicateSelectedPart()
        {
            log.Write($"Duplicating selected part...");
            // Get selected part
            if (!(listviewParts.SelectedObject is Part pc))
            {
                log.Write($"No selected part. Aborting...");
                return;
            }

            // Ask the user for the new MPN
            var result = Dialog.ShowDialog(
                "Enter the new MPN (Manufacturer Product Number) for the part...",
                Title: "Enter input",
                Input: true,
                DefaultInput: pc.MPN,
                Btn1: Dialog.ButtonType.OK,
                Btn2: Dialog.ButtonType.Cancel
            );

            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                log.Write($"Operation cancelled. Aborting...");
                return;
            }

            log.Write($"Duplicating the part...");

            if (Parts.ContainsKey(result.UserInput))
            {
                log.Write(
                    $"Unable to duplicate the part. The specified MPN is already present...",
                    Logger.LogLevels.Error
                );
                MessageBox.Show(
                    "Unable to duplicate the part. The specified MPN is already present...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Clone the part and apply the new MPN
            pc = pc.Clone() as Part;
            pc.MPN = result.UserInput;

            // Add to the list
            data.AddPart(pc);
            NotifyPartsHaveChanged();
            log.Write($"Cloning finished");
        }

        /// <summary>
        /// Process an input of materials from an external source
        /// </summary>
        /// <param name="materials">List of materials</param>
        /// <param name="multiplier">Multiplier for this list</param>
        /// <param name="note">Optionnal note for history</param>
        public bool ApplyInputOfMaterials(
            IEnumerable<Material> materials,
            int multiplier,
            string note
        )
        {
            log.Write("Applying input...");
            if (materials == null || materials.Count() == 0)
            {
                log.Write("No materials in list...");
                return false;
            }

            // If processing an output, give negative multiplier
            foreach (Material material in materials)
            {
                // Get corresponding part
                if (material.PartLink == null)
                {
                    // Create the part
                    log.Write(
                        $"Part MPN='{material.MPN}' not available in present list. Creating new part..."
                    );
                    Part p = new Part()
                    {
                        MPN = material.MPN,
                        Category = "__auto_from_order",
                        Stock = material.Quantity,
                    };
                    data.AddPart(p, note);
                }
                else
                {
                    // Apply edit
                    ApplyEdit(
                        material.PartLink,
                        Part.Parameter.Stock,
                        (material.PartLink.Stock + (material.Quantity * multiplier)).ToString(),
                        note
                    );
                }
            }

            return true;
        }

        /// <summary>
        /// Process an output of materials from an external source
        /// </summary>
        /// <param name="materials">List of materials</param>
        /// <param name="multiplier">Multiplier for this list</param>
        /// <param name="note">Optionnal note for history</param>
        public bool ApplyOutputOfMaterials(
            IEnumerable<Material> materials,
            int multiplier,
            string note
        )
        {
            return ApplyInputOfMaterials(materials, -multiplier, note);
        }

        /// <summary>
        /// Edit a property of the specified part
        /// </summary>
        /// <param name="part">Part to be modified</param>
        /// <param name="editedParameter">Parameter to modify</param>
        /// <param name="newValue">New value for that parameter</param>
        /// <param name="note">Optional note for history</param>
        /// <exception cref="InvalidOperationException">When parameter is set to UNDEFINED</exception>
        private bool ApplyEdit(
            Part part,
            Part.Parameter editedParameter,
            string newValue,
            string note = ""
        )
        {
            log.Write(
                $"Cell with MPN={part.MPN} edited : Parameter={editedParameter}, Newvalue={newValue}"
            );
            if (editedParameter == Part.Parameter.UNDEFINED)
            {
                log.Write("Unable to edit parameter 'UNDEFINED'...");
                return false;
            }

            // Verify that an actual change is made
            if (
                part.Parameters.ContainsKey(editedParameter)
                && (part.Parameters[editedParameter]?.Equals(newValue) ?? false)
            )
            {
                // No changes
                log.Write("No change detected...");
                return true;
            }

            // Verify that the new MPN doesn't already exists
            if ((editedParameter == Part.Parameter.MPN) && Parts.ContainsKey(newValue))
            {
                log.Write(
                    "Unable to edit MPN value. Another part already have this MPN value.",
                    Logger.LogLevels.Error
                );
                MessageBox.Show(
                    "Unable to edit the MPN to the specified value. Another part with this MPN already exists...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            data.EditPart(part, editedParameter, newValue, note);
            NotifyPartsHaveChanged();
            return true;
        }

        #endregion
        #region Actions

        /// <summary>
        /// Make order for parts with 'stock' lower than 'lowStock'
        /// </summary>
        private bool ActionMakeLowStockOrder()
        {
            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            log.Write($"Making automated order...");
            List<Part> parts = GetValidPartsForActions();
            // Select parts with current stock lower than lowStock limit
            IEnumerable<Part> selected = parts.Where((part) => (part.Stock < part.LowStock));

            log.Write($"{selected.Count()} part(s) found for automatic order");

            string message =
                $"Confirm the process of ordering {parts.Count()} part(s) according to current stock\nContinue ?";
            if (!AskUserConfirmation(message, "Confirmation"))
            {
                return false;
            }

            orderForm.AddPartsToOrderList(selected);
            // Update order form
            orderForm.SetSuppliers(Parts.Select((x) => x.Value.Supplier).Distinct());
            ShowForm(orderForm);

            return true;
        }

        /// <summary>
        /// Ask the user if he wants to continue. Include YesNoCancel buttons
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        /// <returns>True if yes clicked</returns>
        private bool AskUserConfirmation(string message, string title)
        {
            Dialog.DialogConfig dc = new Dialog.DialogConfig(message, title)
            {
                Button1 = Dialog.ButtonType.Yes,
                Button2 = Dialog.ButtonType.No,
                Button3 = Dialog.ButtonType.Cancel,
                Icon = Dialog.DialogIcon.Question,
            };

            var result = Dialog.ShowDialog(dc);
            return result.DialogResult == Dialog.DialogResult.Yes;
        }

#warning Continue refactoring here...
        /// <summary>
        /// Add empty parts to the order form. This is so the user will then input the quantities
        /// </summary>
        /// <returns>Succes if true</returns>
        private bool ActionAddPartsToOrderList()
        {
            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            log.Write($"Adding to order...");
            List<Part> parts = GetValidPartsForActions();

            log.Write(
                $"{parts.Count()} part(s) to be added to order form...",
                Logger.LogLevels.Debug
            );

            string message =
                $"Confirm the process of adding {parts.Count()} part(s) to the order form (with 0 quantity)\nContinue ?";
            if (!AskUserConfirmation(message, "Confirmation"))
            {
                return false;
            }

            orderForm.AddCustomPartsToOrder(parts);
            // update order form
            orderForm.SetSuppliers(Parts.Select((x) => x.Value.Supplier).Distinct());
            ShowForm(orderForm);

            return true;
        }

        /// <summary>
        /// Add the selected parts to the specified project
        /// </summary>
        /// <returns>Succes if true</returns>
        private bool AddSelectionToProject()
        {
            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            log.Write($"Adding parts to order...");
            List<Part> parts = GetValidPartsForActions();

            log.Write($"{parts.Count} part(s) found to add to project", Logger.LogLevels.Debug);

            var result = ShowFormDialog(actionProjectForm);
            if (result != DialogResult.OK)
            {
                return false;
            }
            ProjectVersion pv = actionProjectForm.GetSelectedProjectVersion();
            string name = actionProjectForm.GetSelectedProjectName();

            string message =
                $"Confirm the process of adding {parts.Count()} part(s) to the selected project (with 0 quantity) : '{name}'\nContinue ?";
            if (!AskUserConfirmation(message, "Confirmation"))
            {
                return false;
            }

            // Generate material list
            List<Material> materials = parts
                .Select(
                    (x) =>
                        new Material()
                        {
                            MPN = x.MPN,
                            Quantity = 0,
                            Note = "_add_action",
                        }
                )
                .ToList();

            // Actually add to project
            pv.BOM.AddRange(materials);

            // Update projectForm
            projectForm.MaterialsHaveChanged();

            return true;
        }

        /// <summary>
        /// Process a digikey csv order file to apply part stock update
        /// </summary>
        /// <param name="processedCount">Number of processed entries</param>
        /// <returns>Succes if true</returns>
        private bool ActionImportDigikeyOrder(out int processedCount)
        {
            processedCount = 0;

            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                //Filter = "Excel xlsx (*.xlsx, *.csv)|*.xlsx;*.csv|All files (*.*)|*.*",
                Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            log.Write($"Loading Digikey order...");

            string file = ofd.FileName;
            string extension = Path.GetExtension(file);
            if (extension.Equals(".csv", StringComparison.InvariantCultureIgnoreCase))
            {
                // Read lines
                using (var reader = new StreamReader(file))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = new List<CsvPartImport>();
                        // Read header line
                        csv.Read();
                        csv.ReadHeader();

                        while (csv.Read()) // Read entries
                        {
                            // Get entry
                            var record = new CsvPartImport
                            {
                                MPN = csv.GetField("Manufacturer Part Number"),
                                Quantity = csv.GetField("Quantity"),
                            };
                            // Read the rest only if required
                            if (!Parts.ContainsKey(record.MPN))
                            {
                                // Cerating new part. Gathering more informations on part
                                record.SPN = csv.GetField("Part Number");
                                record.Description = csv.GetField("Description");
                            }

                            records.Add(record);
                        }

                        // Process entries
                        processedCount = ActionDigikeyProcessParts(records);
                    }
                }
            }
            else if (extension.Equals(".xlsx", StringComparison.InvariantCultureIgnoreCase))
            {
                // Not yet implemented
                MessageBox.Show(
                    ".xlsx files are not yet supported. Please use .csv",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask update of part list
            NotifyPartsHaveChanged();
            return true;
        }

        /// <summary>
        /// Process a list of part modification. This function is used to process a order file.
        /// </summary>
        /// <returns>Number of processed entries</returns>
        private int ActionDigikeyProcessParts(List<CsvPartImport> records)
        {
            log.Write($"{records.Count} part(s) found to process...");

            string note = $"Digikey Order ";
            int count = 0;
            foreach (CsvPartImport item in records)
            {
                if (item == null)
                {
                    // Should not happen
                    log.Write("Null row found...", Logger.LogLevels.Error);
                    continue;
                }

                if (string.IsNullOrEmpty(item.MPN))
                {
                    continue;
                }

                // Try converting quantity
                if (!float.TryParse(item.Quantity, out float quantity))
                {
                    log.Write(
                        $"Unable to parse quantity : '{item.Quantity}'",
                        Logger.LogLevels.Error
                    );
                    continue;
                }

                count++;
                if (!Parts.ContainsKey(item.MPN))
                {
                    // New part
                    log.Write(
                        $"Part '{item.MPN}' not available in present list. Creating new part..."
                    );
                    Part p = new Part()
                    {
                        MPN = item.MPN,
                        Description = item.Description,
                        Category = "__automatically_generated",
                        Supplier = "Digikey",
                        SPN = item.SPN,
                        Stock = quantity,
                    };
                    data.AddPart(p, note);
                }
                else
                {
                    // Process edit
                    Part part = Parts[item.MPN];
                    log.Write(
                        $"Changing stock of '{part.MPN}' from {part.Stock} to {part.Stock + quantity}"
                    );
                    data.EditPart(
                        part,
                        Part.Parameter.Stock,
                        (part.Stock + quantity).ToString(), // Add edit stock to current stock
                        note
                    );
                }
            }

            return count;
        }

        /// <summary>
        /// Process a csv list to add them to the part list, without changing any quantity
        /// </summary>
        /// <returns></returns>
        private bool ActionImportDigikeyList(out int processedCount)
        {
            processedCount = 0;

            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask to open the excel file
            OpenFileDialog ofd = new OpenFileDialog()
            {
                //Filter = "Excel xlsx (*.xlsx, *.csv)|*.xlsx;*.csv|All files (*.*)|*.*",
                Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            log.Write($"Loading Digikey list...");

            string file = ofd.FileName;
            string extension = Path.GetExtension(file);
            if (extension.Equals(".csv", StringComparison.InvariantCultureIgnoreCase))
            {
                // Read lines
                using (var reader = new StreamReader(file))
                {
                    // Skip first 2 lines
                    _ = reader.ReadLine();
                    _ = reader.ReadLine();

                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = new List<CsvPartImport>();
                        // Read header line
                        csv.Read();
                        csv.ReadHeader();

                        while (csv.Read())
                        {
                            // Get entry
                            var record = new CsvPartImport
                            {
                                MPN = csv.GetField("Manufacturer Part Number"),
                                Quantity = "0", // For this import, we set the quantity as 0
                            };
                            // Read the rest only if required
                            if (!Parts.ContainsKey(record.MPN))
                            {
                                // Cerating new part. Gathering more informations on part
                                record.SPN = csv.GetField("Digi-Key Part Number 1");
                                record.Description = csv.GetField("Description");
                            }

                            records.Add(record);
                        }

                        // Process entries
                        processedCount = ActionDigikeyListProcessParts(records);
                    }
                }
            }
            else if (extension.Equals(".xlsx", StringComparison.InvariantCultureIgnoreCase))
            {
                // Not yet implemented
                MessageBox.Show(
                    ".xlsx files are not yet supported. Please use .csv",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask update of part list
            NotifyPartsHaveChanged();
            return true;
        }

        /// <summary>
        /// Process the list of selected part from the list. Parts already present will have their current stock updated
        /// </summary>
        private int ActionDigikeyListProcessParts(List<CsvPartImport> records)
        {
            log.Write($"{records.Count} part(s) found to process...");

            string note = $"Digikey List Import ";
            int processedParts = 0;
            foreach (CsvPartImport item in records)
            {
                if (item == null)
                {
                    log.Write("Null row found... Should not happen", Logger.LogLevels.Error);
                    continue;
                }

                if (string.IsNullOrEmpty(item.MPN))
                {
                    continue;
                }

                // Try converting quantity
                float quantity = 0; // For this import, we just import information without the quantity. So set to 0

                processedParts++;
                if (!Parts.ContainsKey(item.MPN))
                {
                    log.Write(
                        $"Part '{item.MPN}' not available in present list. Creating new part..."
                    );
                    Part p = new Part()
                    {
                        MPN = item.MPN,
                        Description = item.Description,
                        Category = "__automatically_generated",
                        Supplier = "Digikey",
                        SPN = item.SPN,
                        Stock = quantity,
                    };
                    data.AddPart(p, note);
                }
                else
                {
                    // Process edit
                    Part part = Parts[item.MPN];
                    log.Write(
                        $"Changing stock of '{part.MPN}' from {part.Stock} to {part.Stock + quantity}"
                    );
                    data.EditPart(
                        part,
                        Part.Parameter.Stock,
                        (part.Stock + quantity).ToString(),
                        note
                    );
                }
            }

            return processedParts;
        }

        /// <summary>
        /// TODO : refactor this function
        /// </summary>
        /// <returns></returns>
        private int ActionImportClipboardDigikeyOrder()
        {
            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return -1;
            }

            string content = Clipboard.GetText();

            log.Write($"Loading Digikey order from clipboard...");

            try
            {
                // Separate by lines
                content = content.Replace("\r", "");
                string[] lines = content.Split('\n');

                if (lines.Length < 2)
                {
                    throw new InvalidOperationException("Unsufficient number of lines...");
                }

                List<CsvPartImport> records = new List<CsvPartImport>();

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] fields = line.Split('\t');
                    CsvPartImport part = new CsvPartImport()
                    {
                        MPN = fields[3],
                        Quantity = fields[1],
                        SPN = fields[2],
                        Description = fields[4],
                    };
                    records.Add(part);
                }

                int processedParts = ActionDigikeyProcessParts(records);

                // Ask update of part list
                NotifyPartsHaveChanged();

                return processedParts;
            }
            catch (Exception)
            {
                log.Write("Unable to load ordre from clipboard...", Logger.LogLevels.Error);
                MessageBox.Show(
                    "Unable to import order content from clipboard...",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return -1;
            }
        }

        /// <summary>
        /// Export parts to a new file
        /// </summary>
        /// <returns>Success if true</returns>
        public bool ActionExportParts()
        {
            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask save path
            SaveFileDialog fsd = new SaveFileDialog()
            {
                Filter = "StockManager Data|*.smd|Text file, Json|*.txt, *.json|All files|*.*",
            };
            if (fsd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            if (File.Exists(fsd.FileName))
            {
                log.Write($"Unable to export... File already exists", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "Unable to export parts. The selected file already exists...\nNo overwrite will be made, please manually delete the file if you want to overwrite it.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            var selectedFilter = fsd.FilterIndex;

            bool zipFile;
            switch (selectedFilter)
            {
                case 2: // .txt
                    zipFile = false;
                    break;

                default:
                case 1: // .smd
                    zipFile = true;
                    break;
            }

            log.Write($"Exporting parts...");
            List<Part> parts = GetValidPartsForActions();

            log.Write($"{parts.Count} part(s) found for export");

            Dictionary<string, Part> exportParts = new Dictionary<string, Part>();
            parts.ForEach((p) => exportParts.Add(p.MPN, p));

            // Export the parts
            DataExportClass dec = new DataExportClass(exportParts, null, null);
            SettingsManager.SaveTo(
                fsd.FileName,
                dec,
                backup: SettingsManager.BackupMode.None,
                indent: true,
                zipFile: zipFile
            );

            return true;
        }

        /// <summary>
        /// Import a ".smd" file
        /// </summary>
        /// <returns>Success if true</returns>
        public bool ActionImportParts()
        {
            if (!IsFileLoaded)
            {
                log.Write("Unable to process action. No file is loaded.", Logger.LogLevels.Debug);
                MessageBox.Show(
                    "No file loaded ! Open or create a new one",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            // Ask save path
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "StockManager Data|*.smd|All files|*.*",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            log.Write($"Importing parts...");

            // Load file
            DataExportClass dec = null;
            try
            {
                SettingsManager.LoadFrom(ofd.FileName, out dec, zipFile: true);
            }
            catch (Exception ex)
            {
                log.Write(
                    $"Unable to load specified file '{ofd.FileName}' : {ex.Message}",
                    Logger.LogLevels.Debug
                );
                MessageBox.Show(
                    $"Unable to load specified file '{ofd.FileName}' : {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            if ((dec == null) || (dec.Parts == null) || (dec.Parts.Count == 0))
            {
                log.Write("No data found...");
                MessageBox.Show(
                    "No data found in this file...",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            log.Write($"{dec.Parts.Count} part(s) found to import...");

            // Confirmation
            if (
                MessageBox.Show(
                    $"Please confirm the additions of '{dec.Parts.Count}' parts to the current databse. This cannot be undone\nContinue ?",
                    "Warning",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes
            )
            {
                return false;
            }

            // Add to loaded file
            int partCounter = 0;
            foreach (Part part in dec.Parts)
            {
                // Try add part, already existing one will be skipped
                if (data.AddPart(part))
                {
                    partCounter++;
                }
                else
                {
                    log.Write($"Part MPN='{part.MPN}' already present... Skipped");
                }
            }

            NotifyPartsHaveChanged();
            SetStatus($"{partCounter}/{dec.Parts.Count} part(s) imported !", Color.Blue);
            MessageBox.Show(
                $"{partCounter}/{dec.Parts.Count} part(s) imported !",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return true;
        }

        #endregion

        /// <summary>
        /// Set status of the app. Displayed at the bottom and automatically hides after a timeout
        /// </summary>
        /// <param name="status">Text</param>
        private void SetStatus(string status)
        {
            SetStatus(status, SystemColors.ControlText);
        }

        /// <summary>
        /// Set status of the app. Displayed at the bottom and automatically hides after a timeout
        /// </summary>
        /// <param name="status">Text</param>
        /// <param name="foregroundColor">Foreground color</param>
        private void SetStatus(string status, Color foregroundColor)
        {
            labelStatus.ForeColor = foregroundColor;
            labelStatus.Text = status;

            // Restart timer
            statusTimeoutTimer.Stop();
            statusTimeoutTimer.Start();
        }

        /// <summary>
        /// Indicate that the app is working
        /// </summary>
        private void SetWorkingStatus()
        {
            SetStatus("Working...");
            labelStatus.Invalidate();
        }

        /// <summary>
        /// Indicate either a success or a failure
        /// </summary>
        /// <param name="state">success (true) or failure (false)</param>
        private void SetSuccessStatus(bool state)
        {
            SetStatus(state ? "Success !" : "Failed", state ? SystemColors.ControlText : Color.Red);
        }

        /// <summary>
        /// Display a form
        /// </summary>
        /// <param name="frm">Form to display</param>
        private void ShowForm(Form frm)
        {
            // Open projects form
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            //frm.SetDesktopLocation(DesktopLocation.X + 20, DesktopLocation.Y + 20);
            frm.BringToFront();
        }

        /// <summary>
        /// Display a form and block main form
        /// </summary>
        /// <param name="frm">Form to display</param>
        private DialogResult ShowFormDialog(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            return frm.ShowDialog();
        }

        #region Misc Events

        // Form closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save settings
            AppSettings.Save();

            log.Write("Closing... Stopping logger", Logger.LogLevels.Info);
            log.logger.Dispose();
        }

        // Menu item click
        private void importFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ImportPartsFromAnyExcel();
            SetSuccessStatus(result);
        }

        // Menu item click
        private void makeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ActionMakeLowStockOrder();
            SetSuccessStatus(result);
        }

        // Menu item click
        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = CreateNewSaveFile();
            SetSuccessStatus(result);
        }

        // Menu item click
        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = OpenFile();
            SetSuccessStatus(result);
        }

        // Entry checked in listview
        private void listviewParts_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateCheckedListviewContent();
        }

        // Menu item click
        private void checkAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check all in view
            ShouldUpdateCheckedListview = false;
            listviewParts.CheckObjects(listviewParts.FilteredObjects);
            listviewParts.Focus();
            ShouldUpdateCheckedListview = true;
        }

        // Menu item click
        private void uncheckAllInViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uncheck all in view
            ShouldUpdateCheckedListview = false;
            listviewParts.UncheckObjects(listviewParts.FilteredObjects);
            listviewParts.Focus();
            ShouldUpdateCheckedListview = true;
        }

        // Menu item click
        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = CloseFile();
            SetSuccessStatus(result);
        }

        // Menu item click
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Request from project form
        private void FrmProjects_OnProjectProcessRequested(
            object sender,
            ProjectProcessRequestedEventArgs e
        )
        {
            Cursor.Current = Cursors.WaitCursor;

            string note = $"Project processed '{e.projectName}'";
            ApplyOutputOfMaterials(e.materials, e.numberOfTimes, note);

            Cursor.Current = Cursors.Default;
        }

        // Request from project form
        private void FrmProjects_OnProjectOrder(object sender, ProjectOrderRequestedEventArgs e)
        {
            // MUST clone otherwise quantities changements are reported to the BOM
            IEnumerable<Material> materials = e.materials;

            if (materials == null)
            {
                orderForm.RemoveProjectToOrder(e.projectName);
                return;
            }

            // Remove all 0 quantities
            materials = materials.Where((x) => x.Quantity > 0).ToList();

            orderForm.AddProjectToOrder(
                e.projectName,
                e.numberOfTimes,
                !e.OrderIfRequired,
                materials
            );

            // update order form
            orderForm.SetSuppliers(Parts.Values.Select((x) => x.Supplier).Distinct()); // update suppliers
            ShowForm(orderForm);
        }

        // Request from project form
        private void FrmProjects_OnPartEditRequested(object sender, PartEditEventArgs e)
        {
            string note = $"Edit from project form ";
            // Only allow edit of lowstock
            if ((e == null) || (e.part == null))
            {
                return;
            }

            switch (e.editedParamter)
            {
                case Part.Parameter.LowStock:
                case Part.Parameter.Location:
                    ApplyEdit(e.part, e.editedParamter, e.value, note);
                    break;
                default:
                    break;
            }
        }

        // Menu item click
        private void importOrderFromDigikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool success = ActionImportDigikeyOrder(out int count);
            SetSuccessStatus(success);
            MessageBox.Show(
                $"Successfully updated {count} part(s).",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Menu item click
        private void importOrderFromDigikeyFromClipboardToolStripMenuItem_Click(
            object sender,
            EventArgs e
        )
        {
            SetWorkingStatus();
            int result = ActionImportClipboardDigikeyOrder();
            SetSuccessStatus(result > 0);
            MessageBox.Show(
                $"Successfully updated {result} part(s).",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Menu item click
        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Write($"Openning project window...");
            if (!IsFileLoaded)
            {
                log.Write("Unable to open projects, no file loaded...", Logger.LogLevels.Error);
                return;
            }

            ShowForm(projectForm);
        }

        // Menu item click
        private void openHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.Write($"Openning history window...");
            if (!IsFileLoaded)
            {
                log.Write("Unable to open history, no file loaded...", Logger.LogLevels.Error);
                return;
            }

            // Open projects form
            ShowForm(historyForm);
        }

        // Child form closed
        private void FrmProjects_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the project form is closed, bring to fron the main form
            this.BringToFront();
            _projectForm = null;
        }

        // Child form closed
        private void _historyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the history form is closed, bring to fron the main form
            this.BringToFront();
            _historyForm = null;
        }

        // Child form closing
        private void _orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // When the order form is closing, bring to fron the main form
            this.BringToFront();
            _orderForm = null;
        }

        // Child form closed
        private void _searchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // When the history form is closed, bring to fron the main form
            this.BringToFront();
            _searchForm = null;
            ClearAdvancedFiltering();
        }

        // Listview keystroke
        private void listviewParts_KeyDown(object sender, KeyEventArgs e)
        {
            // 'hack' to check selected rows but call the CheckedChanged event only once
            if (e.KeyCode == Keys.Space)
            {
                ToggleCheckedForSelectedPart();
            }
        }

        // Listview right click on cell
        private void listviewParts_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            // When rightclicking a cell, copy the MPN of the corresponding row
            if (!(e.Model is Part))
            {
                return;
            }

            contextMenuStrip1.Show(Cursor.Position);
        }

        // Button click
        private void btnPartAdd_Click(object sender, EventArgs e)
        {
            _ = CreateNewEmptyPart();
            listviewParts.Focus();
        }

        // Button click
        private void btnPartDup_Click(object sender, EventArgs e)
        {
            DuplicateSelectedPart();
            listviewParts.Focus();
        }

        // Button click
        private void btnPartDel_Click(object sender, EventArgs e)
        {
            DeleteSelectedParts();
            listviewParts.Focus();
        }

        // Menu item click
        private void resizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listviewParts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        // Timer timeout
        private void statusTimeoutTimer_Tick(object sender, EventArgs e)
        {
            statusTimeoutTimer.Stop();
            labelStatus.ForeColor = SystemColors.ControlText;
            labelStatus.Text = string.Empty;
        }

        // Menu item click
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsFileLoaded)
            {
                data.Save();
            }

            AppSettings.Save();
        }

        // Menu item click
        private void exportPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Export the parts
            ActionExportParts();
        }

        // Menu item click
        private void importPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionImportParts();
        }

        // Menu item click
        private void advancedSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFileLoaded)
            {
                return;
            }

            ShowForm(searchForm);
        }

        // Listview cell edited
        private void listviewParts_CellEditFinished(object sender, CellEditEventArgs e)
        {
            // Get the unedited part version
            Part part = e.RowObject as Part;
            // Get the edited parameter and value
            Part.Parameter editedParameter = (Part.Parameter)(e.Column.Index);
            string newValue = e.NewValue.ToString();

            ApplyEdit(part, editedParameter, newValue);
        }

        // Menu item click
        private void seeBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string backupPath = SettingsManager.GetDefaultBackupPath();
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }
            Process.Start(backupPath);
        }

        // Menu item click
        private void seeLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logPath = log.logger.FileOutputPath;
            if (File.Exists(logPath))
            {
                Process.Start(Path.GetDirectoryName(logPath));
            }
        }

        // Form displayed
        private void frmMain_Shown(object sender, EventArgs e)
        {
            UpdateRecentFileList();

            try
            {
                GetApiAccess();
            }
            catch (Exception ex)
            {
                log.Write($"Unable to get API Access : {ex.Message}", Logger.LogLevels.Error);
            }
        }

        // Menu item click
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"{VersionLabel}\nMade by EsseivaN",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Menu item click
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsForm.ReferenceNewSettings = AppSettings.Settings;
            ShowForm(optionsForm);
        }

        // Child form closed
        private void _optionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.BringToFront();

            if (_optionsForm.ChangesMade && (_optionsForm.NewAppSettings != null))
            {
                AppSettings.Settings = _optionsForm.NewAppSettings;
                ApplySettings();
            }

            _optionsForm = null;
        }

        // Recent file menu item drop down opening
        private void openRecentToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            UpdateRecentFileList();
        }

        // Recent Menu item click
        private void toolStripMenuItemRecentFile_Click(object sender, EventArgs e)
        {
            // Open recent file
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string file = item.Text;

            SetWorkingStatus();
            bool result = OpenFile(file);
            SetSuccessStatus(result);
        }

        // Menu item click
        private void sourceCodeGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/esseivan/StockManager");
        }

        // Menu item click
        private void openOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(orderForm);
        }

        // Menu item click
        private void seeInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFileLoaded)
            {
                return;
            }

            string dir = Path.GetDirectoryName(filepath);
            Process.Start(dir);
        }

        // Menu item click
        private void openSupplierUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewParts.SelectedObject is Part part))
            {
                return;
            }

            part.OpenSupplierUrl();
            SetStatus("Web page openned...");
        }

        // Menu item click
        private void copyMPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewParts.SelectedObject is Part part))
            {
                return;
            }

            part.CopyMPNToClipboard();
            SetStatus("Copied to clipboard...");
        }

        // Menu item click
        private void updateFromDigikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionUpdateParts();
        }

        // Menu item click
        private void onlyAffectCheckedPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (initInProgress)
            {
                return;
            }

            AppSettings.Settings.ProcessActionOnCheckedOnly =
                onlyAffectCheckedPartsToolStripMenuItem.Checked;
            AppSettings.Save();
        }

        // Menu item click
        private void addToProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSelectionToProject();
        }

        // Custom event made to be called before determining the bounds.
        // The library is edited in order to call this event.
        // It is not present in the original library
        private void listviewParts_CellEditRequested(object sender, CellEditEventArgs e)
        {
            CellEditBoxModifications(sender, e);
        }

        // Menu item click
        private void importListFromDigikeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool success = ActionImportDigikeyList(out int count);
            SetSuccessStatus(success);
            MessageBox.Show(
                $"Successfully updated {count} part(s).",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Menu item click
        private void addPartsToOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionAddPartsToOrderList();
        }

        // Menu item click
        private void importPartsFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ImportPartsFromAnyExcel();
            SetSuccessStatus(result);
        }

        // Menu item click
        private void importOrderFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetWorkingStatus();
            bool result = ApplyOrderFromExcel();
            SetSuccessStatus(result);
        }

        // Menu item click
        private void copySPNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected part
            if (!(listviewParts.SelectedObject is Part part))
            {
                return;
            }

            part.CopySPNToClipboard();
            SetStatus("Copied to clipboard...");
        }

        #endregion

        /// <summary>
        /// Update recent file list
        /// </summary>
        private void UpdateRecentFileList()
        {
            if (RecentFileMenuItems == null)
            {
                RecentFileMenuItems = new Dictionary<int, ToolStripMenuItem>()
                {
                    { 0, toolStripMenuItem2 },
                    { 1, toolStripMenuItem3 },
                    { 2, toolStripMenuItem4 },
                    { 3, toolStripMenuItem5 },
                    { 4, toolStripMenuItem6 },
                };
            }

            // Populate recent files
            int count = AppSettings.Settings.RecentFiles.Count;
            for (int i = 0; i < RecentFileMenuItems.Count; i++)
            {
                RecentFileMenuItems[i].Click -= toolStripMenuItemRecentFile_Click;
                if (i < count)
                {
                    RecentFileMenuItems[i].Visible = true;
                    RecentFileMenuItems[i].Text = AppSettings.Settings.RecentFiles[i];
                    RecentFileMenuItems[i].Click += toolStripMenuItemRecentFile_Click;
                }
                else
                {
                    RecentFileMenuItems[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// Get authorization to Digikey API
        /// </summary>
        private async void GetApiAccess()
        {
            if (!AppSettings.Settings.IsDigikeyAPIEnabled)
            {
                return;
            }

            var client = new ApiClientWrapper();
            var result = await client.GetAccess();

            if (!result.Success) // No access
            {
                if (!MiscTools.HasAdminPrivileges())
                {
                    MessageBox.Show(
                        "Unable to get API access... Pleasy try running the app with Admin privileges.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    var res = Dialog.ShowDialog(
                        new Dialog.DialogConfig(
                            "Unable to get access token... Check the config and the logs",
                            "Error"
                        )
                        {
                            Button1 = Dialog.ButtonType.Ignore,
                            Button2 = Dialog.ButtonType.Custom1,
                            CustomButton1Text = "Open log",
                            Icon = Dialog.DialogIcon.Error,
                        }
                    );
                    if (res.DialogResult == Dialog.DialogResult.Custom1)
                    {
                        Process.Start(Logger.Instance.FileOutputPath);
                    }
                }
            }
        }

        /// <summary>
        /// Update the parts using Digikey API
        /// </summary>
        private async void ActionUpdateParts()
        {
            if (!AppSettings.Settings.IsDigikeyAPIEnabled)
            {
                return;
            }
            // Ask confirmation because overwrites will be made...

            List<Part> selectedParts = GetValidPartsForActions();

            // For safety, only update part with no supplier or Digikey as a supplier
            selectedParts = selectedParts
                .Where(
                    (p) =>
                        (
                            string.IsNullOrEmpty(p.Supplier)
                            || string.Equals(
                                "digikey",
                                p.Supplier,
                                StringComparison.InvariantCultureIgnoreCase
                            )
                        )
                )
                .ToList();

            if (selectedParts.Count == 0)
            {
                log.Write("[DigikeyUpdate] No valid parts selected...");
                return;
            }

            Dialog.DialogConfig dc = new Dialog.DialogConfig()
            {
                Message = $"Confirm the update of the selected parts ({selectedParts.Count} parts)",
                Title = "Confirmation",
                Button1 = Dialog.ButtonType.OK,
                Button2 = Dialog.ButtonType.Cancel,
                Icon = Dialog.DialogIcon.Question,
            };
            Dialog.ShowDialogResult result = Dialog.ShowDialog(dc);
            if (result.DialogResult != Dialog.DialogResult.OK)
            {
                return;
            }
            log.Write($"[DigikeyUpdate] Processing {selectedParts.Count} part(s)");

            SetWorkingStatus();
            Cursor = Cursors.WaitCursor;
            PartSearch ps = new PartSearch();
            for (int i = 0; i < selectedParts.Count; i++)
            {
                Part part = selectedParts[i];
                log.Write($"[DigikeyUpdate] Processing MPN '{part.MPN}'...");

                DigikeyPart received;
                try
                {
                    var read = await ps.ProductDetails_Essentials(part.MPN);
                    if (string.IsNullOrEmpty(read))
                    {
                        log.Write(
                            $"[DigikeyUpdate] No data found for this MPN...",
                            Logger.LogLevels.Error
                        );
                        continue;
                    }
                    received = PartSearch.DeserializeProductDetails(read);
                }
                catch (Exception)
                {
                    Cursor = Cursors.Default;
                    log.Write(
                        $"[DigikeyUpdate] Unable to retrieve data...",
                        Logger.LogLevels.Error
                    );
                    continue;
                }

                if (received == null)
                {
                    log.Write($"[DigikeyUpdate] Unable to convert data...", Logger.LogLevels.Error);
                    continue;
                }

                // Verify that the MPN is exactly the same
                if (!part.MPN.Equals(received.ManufacturerPartNumber))
                {
                    log.Write(
                        $"[DigikeyUpdate] Unable to validate MPN '{part.MPN}' expected, '{received.ManufacturerPartNumber}' received",
                        Logger.LogLevels.Info
                    );
                    continue;
                }

                log.Write(
                    $"[DigikeyUpdate] Updating MPN '{received.ManufacturerPartNumber}'...",
                    Logger.LogLevels.Info
                );
                // Update part
                Part oldPart = part.CloneForHistory();
                log.Write(
                    $"[DigikeyUpdate] OLD :\t{oldPart.ToLongString()}",
                    Logger.LogLevels.Debug
                );
                part.Supplier = "Digikey";
                part.Manufacturer = received.ManufacturerString;
                part.SPN = received.DigiKeyPartNumber;
                part.Price = received.UnitPrice;
                part.Description = received.DetailedDescription;
                log.Write($"[DigikeyUpdate] NEW :\t{part.ToLongString()}", Logger.LogLevels.Debug);

                // Add to history
                data.DigikeyUpdatePart(part, oldPart);
            }

            NotifyPartsHaveChanged();
            Cursor = Cursors.Default;
            SetSuccessStatus(true);
        }

        enum StockAdjustModes
        {
            UNDEFINED,
            ADD,
            REMOVE,
            SET,
            ROUNDDOWN,
        }

        private void AdjustStock(StockAdjustModes mode, float modification)
        {
            List<Part> selectedParts = GetSelectedParts();
            int count = selectedParts.Count;

            if (count != 1)
            {
                throw new InvalidOperationException(
                    "Unable to adjust stock when multiple parts are selected"
                );
            }

            Part part = selectedParts.First();

            switch (mode)
            {
                case StockAdjustModes.ADD:
                    part.Stock += modification;
                    break;
                case StockAdjustModes.REMOVE:
                    part.Stock -= modification;
                    break;
                case StockAdjustModes.SET:
                    part.Stock = modification;
                    break;
                case StockAdjustModes.ROUNDDOWN:
                    part.Stock = (int)Math.Floor(part.Stock);
                    break;
                case StockAdjustModes.UNDEFINED:
                default:
                    break;
            }

            NotifyPartsHaveChanged();
            txtboxPartCurrentStock.Text = part.Stock.ToString();
        }

        private void listviewParts_SelectionChanged(object sender, EventArgs e)
        {
            // Called when the selection is changed
            List<Part> selectedParts = GetSelectedParts();
            // If 1 part selected, show infos
            int count = selectedParts.Count;

            bool visible = count == 1;
            panelPartInfos.Visible = visible;

            if (visible)
            {
                Part part = selectedParts.First();

                numboxStockAdjust.DecimalPlaces = AppSettings.Settings.EditCellDecimalPlaces;
                txtboxPartCurrentStock.Text = part.Stock.ToString();
                label1.Text = $"Selected part '{part.MPN}'";

                // Update 'used in project' listview
                listView1.Items.Clear();

                // Get project lists
                List<ProjectVersion> versions = new List<ProjectVersion>();
                foreach (Project p in data.Projects.Values)
                {
                    versions.AddRange(p.Versions.Values);
                }

                // Search all versions matching this part
                IEnumerable<ProjectVersion> valid = versions.Where((x) => x.HasMaterial(part.MPN));
                Dictionary<string, List<string>> projects = new Dictionary<string, List<string>>();
                //List<string> projects = new List<string>();

                foreach (ProjectVersion v in valid)
                {
                    if (!projects.ContainsKey(v.Project))
                    {
                        projects.Add(v.Project, new List<string>());
                    }
                    projects[v.Project].Add(v.Version);
                }

                foreach (KeyValuePair<string, List<string>> pair in projects)
                {
                    string text = $"{pair.Key} - ({string.Join(", ", pair.Value)})";
                    listView1.Items.Add(text);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void btnStockRemove_Click(object sender, EventArgs e)
        {
            AdjustStock(StockAdjustModes.REMOVE, (float)numboxStockAdjust.Value);
        }

        private void btnStockAdd_Click(object sender, EventArgs e)
        {
            AdjustStock(StockAdjustModes.ADD, (float)numboxStockAdjust.Value);
        }

        private void btnStockSet_Click(object sender, EventArgs e)
        {
            AdjustStock(StockAdjustModes.SET, (float)numboxStockAdjust.Value);
        }

        private void btnStockRoundDown_Click(object sender, EventArgs e)
        {
            AdjustStock(StockAdjustModes.ROUNDDOWN, (float)numboxStockAdjust.Value);
        }

        private void btnStockOrder_Click(object sender, EventArgs e)
        {
            List<Part> selectedParts = GetSelectedParts();
            int count = selectedParts.Count;

            if (count != 1)
            {
                throw new InvalidOperationException(
                    "Unable to adjust stock when multiple parts are selected"
                );
            }

            orderForm.AddCustomPartsToOrder(selectedParts);
        }
    }
}
