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


    }
}
