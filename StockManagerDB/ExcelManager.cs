using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace StockManagerDB
{
    /// <summary>
    /// Class to import Part parts from an excel worksheet
    /// </summary>
    internal class ExcelManager : IDisposable
    {
        /// <summary>
        /// Tool to read from excel
        /// </summary>
        internal ExcelWrapper reader;

        /// <summary>
        /// List of parts imported
        /// </summary>
        internal List<Part> Parts = null;

        private readonly string File;

        public event Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeCloseEventHandler OnClosing;

        /// <summary>
        /// Retrieve the parts
        /// </summary>
        /// <returns></returns>
        public List<Part> GetParts()
        {
            if (Parts == null)
            {
                Import();
            }
            return Parts;
        }

        public ExcelManager(string filename)
        {
            File = filename;
            reader = new ExcelWrapper(File);
            reader.OnClosing += Et_OnClosing;
            //et.IsVisible = true;
        }

        /// <summary>
        /// Load the file. Automatically called with the constructor
        /// </summary>
        public void Import()
        {
            if (!PopulateParts())
                MessageBox.Show(
                    "Unable to import file. Sheet not found !",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
        }

        /// <summary>
        /// Populate the part list from the file
        /// </summary>
        public bool PopulateParts()
        {
            // Read parts sheet
            if (!reader.ReadSheet("Articles", out string[,] output, false))
            {
                LoggerClass.Write("No articles sheet found");
                return false;
            }

            // Generate new parts list
            Parts = new List<Part>();

            // Get header row
            LoggerClass.Write("Headers found : ");
            Dictionary<int, Part.Parameter> header = new Dictionary<int, Part.Parameter>();
            for (int i = 0; i < output.GetLength(1); i += 1)
            {
                string headerName = output[0, i]; // Get header name
                Part.Parameter headerParam = Part.GetParameter(headerName); // Get corresponding parameter

                LoggerClass.Write($"\t{headerName} -> {headerParam}");
                header[i] = headerParam; // Add to the dictionary
            }

            // Get parts rows
            for (int i = 1; i < output.GetLength(0); i += 1)
            {
                Part pc = new Part(); // Create one part per row

                // Sweep through all columns
                for (int j = 0; j < output.GetLength(1); j += 1)
                {
                    Part.Parameter currentParameter = header[j]; // Get current header parameter
                    if (currentParameter != Part.Parameter.UNDEFINED) // If other than undefined ...
                        pc.Parameters[currentParameter] = output[i, j]; // ... Add to the part
                }

                // Save the part
                Parts.Add(pc);
            }

            return true;
        }

        // Called when workbook closed
        private void Et_OnClosing(Microsoft.Office.Interop.Excel.Workbook Wb, ref bool Cancel)
        {
            // Excel (workbook) closed
            // Call parent event
            OnClosing?.Invoke(Wb, ref Cancel);
        }

        public void Dispose()
        {
            if (reader != null)
                reader.Dispose();
        }
    }
}
