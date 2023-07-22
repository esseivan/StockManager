using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace StockManagerDB
{
    public abstract class ExcelWrapperV2
    {
        public static string[,] ReadSheet(string filePath, string sheetName)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    if (!result.Tables.Contains(sheetName))
                    {
                        throw new InvalidOperationException("Sheet not found...");
                    }

                    // Select sheet
                    var sheet = result.Tables[sheetName];

                    var headerRow = sheet.Rows[0];

                    string[,] table = new string[sheet.Rows.Count, sheet.Columns.Count];

                    for (int y = 0; y < sheet.Rows.Count; y++)
                    {
                        for (int x = 0; x < sheet.Columns.Count; x++)
                        {
                            table[y, x] = sheet.Rows[y][x].ToString();
                        }
                    }

                    return table;
                }
            }
        }

        /// <summary>
        /// Read the first sheet of the file
        /// </summary>
        public static string[,] ReadSheet(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    if (result.Tables.Count == 0)
                    {
                        return null;
                    }

                    // Select first sheet
                    var sheet = result.Tables[0];

                    var headerRow = sheet.Rows[0];

                    string[,] table = new string[sheet.Rows.Count, sheet.Columns.Count];

                    for (int y = 0; y < sheet.Rows.Count; y++)
                    {
                        for (int x = 0; x < sheet.Columns.Count; x++)
                        {
                            table[y, x] = sheet.Rows[y][x].ToString();
                        }
                    }

                    return table;
                }
            }
        }

        /// <summary>
        /// Read the first sheet of the file
        /// </summary>
        public static string ReadSheetCSV(string filePath, string separator = ",")
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    if (result.Tables.Count == 0)
                    {
                        return null;
                    }

                    // Select first sheet
                    var sheet = result.Tables[0];

                    var headerRow = sheet.Rows[0];
                    int colCount = sheet.Columns.Count;

                    StringBuilder csv = new StringBuilder();

                    for (int y = 0; y < sheet.Rows.Count; y++)
                    {
                        string[] tempStr = new string[colCount];
                        for (int x = 0; x < sheet.Columns.Count; x++)
                        {
                            tempStr[x] = StringToCSVCell(sheet.Rows[y][x].ToString());
                        }
                        csv.AppendLine(string.Join(separator, tempStr));
                    }

                    return csv.ToString();
                }
            }
        }

        /// <summary>
        /// Turn a string into a CSV cell output
        /// </summary>
        /// <param name="str">String to output</param>
        /// <returns>The CSV cell formatted string</returns>
        public static string StringToCSVCell(string str)
        {
            bool mustQuote = (
                str.Contains(",")
                || str.Contains("\"")
                || str.Contains("\r")
                || str.Contains("\n")
                || str.Contains(";")
            );
            if (mustQuote)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");
                foreach (char nextChar in str)
                {
                    if (nextChar == ';')
                    {
                        sb.Append(',');
                    }
                    else
                    {
                        sb.Append(nextChar);

                        if (nextChar == '"')
                            sb.Append("\"");
                    }
                }
                sb.Append("\"");
                return sb.ToString();
            }

            return str;
        }
    }
}
