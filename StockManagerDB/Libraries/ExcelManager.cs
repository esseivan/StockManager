using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockManagerDB
{
    /// <summary>
    /// Class to import Part parts from an excel worksheet
    /// </summary>
    internal class ExcelManager
    {
        /// <summary>
        /// List of parts imported
        /// </summary>
        internal List<Part> Parts = null;

        private readonly string File;


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
            string[,] output = ExcelWrapperV2.ReadSheet(File, "Articles");

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
    }
}
