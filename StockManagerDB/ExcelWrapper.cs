using Microsoft.Office.Interop.Excel;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace StockManagerDB
{
    /// <summary>
    /// Wrapper to easily read/write excel sheets
    /// </summary>
    public class ExcelWrapper : IDisposable
    {
        public Application xlApp;
        public Workbook wb;
        public Worksheet ws;

        public bool IsVisible
        {
            get => xlApp.Visible;
            set => xlApp.Visible = value;
        }

        /// <summary>
        /// Workbook closing event
        /// </summary>
        public event AppEvents_WorkbookBeforeCloseEventHandler OnClosing;

        public ExcelWrapper()
        {
            xlApp = new Application();
            if (xlApp == null)
                throw new ApplicationException("Excel is not properly installed !");

            xlApp.WorkbookBeforeClose += XlApp_WorkbookBeforeClose;
        }

        public ExcelWrapper(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                wb = OpenWorkbook(filePath);
            else
                wb = CreateWorkbook(filePath);
        }

        // Deconstructor
        ~ExcelWrapper()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            try
            {
                if (ws != null)
                    Marshal.FinalReleaseComObject(ws);

                if (wb != null)
                {
                    wb.Close(Type.Missing, Type.Missing, Type.Missing);
                    Marshal.FinalReleaseComObject(wb);
                }

                if (xlApp != null)
                {
                    xlApp.Quit();
                    Marshal.FinalReleaseComObject(xlApp);
                }
            }
            catch (Exception) { }

            Kill();
        }

        /// <summary>
        /// Force kill the Excel process
        /// </summary>
        public void Kill()
        {
            try
            {
                Process[] excelProcesses = Process.GetProcessesByName("excel");
                foreach (Process p in excelProcesses)
                {
                    if (string.IsNullOrEmpty(p.MainWindowTitle)) // use MainWindowTitle to distinguish this excel process with other excel processes
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception) { }
        }

        public Workbook OpenWorkbook(string filePath)
        {
            return xlApp.Workbooks.Open(filePath);
        }

        public Workbook CreateWorkbook(string filePath)
        {
            Workbook result = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            result.SaveCopyAs(filePath);
            return result;
        }

        // Manual closing
        private void XlApp_WorkbookBeforeClose(Workbook Wb, ref bool Cancel)
        {
            OnClosing?.Invoke(Wb, ref Cancel);
        }

        /// <summary>
        /// Read range values
        /// </summary>
        /// <param name="sheet">Sheet index. Starts at 0</param>
        /// <param name="startRow">Start Row index (start at 0)</param>
        /// <param name="startCol">Start Column index (start at 0)</param>
        /// <param name="endRow">End Row index (start at 0)</param>
        /// <param name="endCol">End Column index (start at 0)</param>
        /// <param name="output">Output read. Dimensions starts at 0</param>
        /// <param name="readFormulas">Whether to read values or formulas</param>
        /// <returns>Values read</returns>
        public bool ReadRange(
            int sheet,
            int startRow,
            int startCol,
            int endRow,
            int endCol,
            out string[,] output,
            bool readFormulas = false
        )
        {
            sheet++;
            startRow++;
            startCol++;
            endRow++;
            endCol++;
            output = null;
            if (wb == null)
                return false;

            if (wb.Worksheets.Count < sheet || sheet < 1)
                return false;

            if (endRow < startRow || endCol < startCol)
                return false;

            Worksheet ws = (Worksheet)wb.Sheets[sheet];
            Range range = (Range)ws.Range[ws.Cells[startRow, startCol], ws.Cells[endRow, endCol]];

            object[,] holder = readFormulas ? (object[,])range.Formula : (object[,])range.Value2;

            string[,] arr = new string[holder.GetLength(0), holder.GetLength(1)];
            for (int i = 0; i < holder.GetLength(0); ++i)
            {
                for (int j = 0; j < holder.GetLength(1); ++j)
                {
                    var obj = holder[i + 1, j + 1];
                    arr[i, j] = obj?.ToString() ?? null;
                }
            }

            output = arr;
            return true;
        }

        /// <summary>
        /// Read range values. Specify length of reading
        /// </summary>
        /// <param name="sheet">Sheet index. Starts at 0</param>
        /// <param name="startRow">Start Row index (start at 0)</param>
        /// <param name="startCol">Start Column index (start at 0)</param>
        /// <param name="rowCount">Number of rows to read</param>
        /// <param name="colCount">Number of columns to read</param>
        /// <param name="output">Output read. Dimensions starts at 0</param>
        /// <param name="readFormulas">Whether to read values or formulas</param>
        /// <returns>Values read</returns>
        public bool ReadRangeLength(
            int sheet,
            int startRow,
            int startCol,
            int rowCount,
            int colCount,
            out string[,] output,
            bool readFormulas = false
        )
        {
            return ReadRange(
                sheet,
                startRow,
                startCol,
                startRow + rowCount - 1,
                startCol + colCount - 1,
                out output,
                readFormulas
            );
        }

        /// <summary>
        /// Write in range
        /// </summary>
        /// <param name="sheet">Sheet index</param>
        /// <param name="startRow">Start Row index (start at 0)</param>
        /// <param name="startCol">Start Column index (start at 0)</param>
        /// <param name="data">Data to be written, set null in the array to preserve the cell. Dimensions starts at 0</param>
        /// <param name="writeFormula">Whether to write values or formulas</param>
        public bool WriteRange(
            int sheet,
            int startRow,
            int startCol,
            string[,] data,
            bool writeFormula = false
        )
        {
            int endRow = startRow + data.GetLength(0) - 1;
            int endCol = startCol + data.GetLength(1) - 1;
            return WriteRange(sheet, startRow, startCol, endRow, endCol, data, writeFormula);
        }

        public int GetSheetIndex(string name)
        {
            if (wb == null)
                return -1;

            try
            {
                Worksheet ws = (Worksheet)wb.Worksheets[name];
                return ws.Index;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Write in range
        /// </summary>
        /// <param name="sheet">Sheet index (start at 0)</param>
        /// <param name="startRow">Start Row index (start at 0)</param>
        /// <param name="startCol">Start Column index (start at 0)</param>
        /// <param name="endRow">End Row index (start at 0)</param>
        /// <param name="endCol">End Column index (start at 0)</param>
        /// <param name="data">Data to be written, set null in the array to preserve the cell. Dimensions starts at 0</param>
        /// <param name="writeFormula">Whether to write values or formulas</param>
        public bool WriteRange(
            int sheet,
            int startRow,
            int startCol,
            int endRow,
            int endCol,
            string[,] data,
            bool writeFormula = false
        )
        {
            sheet++;
            startRow++;
            startCol++;
            endRow++;
            endCol++;
            if (wb == null)
                return false;

            if (wb.Worksheets.Count < sheet || sheet < 1)
                return false;

            Worksheet ws = (Worksheet)wb.Sheets[sheet];
            Range range = (Range)ws.Range[ws.Cells[startRow, startCol], ws.Cells[endRow, endCol]];

            int iMax = endRow - startRow + 1;
            int jMax = endCol - startCol + 1;
            for (int i = 0; i < iMax; i++)
                for (int j = 0; j < jMax; j++)
                    if (data[i, j] != null)
                        if (writeFormula)
                            ((Range)range.Cells[i + 1, j + 1]).Formula = data[i, j];
                        else
                            ((Range)range.Cells[i + 1, j + 1]).Value2 = data[i, j];

            wb.Save();
            return true;
        }

        /// <summary>
        /// Read an entire sheet
        /// </summary>
        /// <param name="sheet">Sheet index (start at 0)</param>
        /// <param name="output">Output read. Dimensions starts at 0</param>
        /// <param name="readFormulas">Whether to read values or formulas</param>
        /// <returns>Entire sheet selected</returns>
        public bool ReadSheet(int sheet, out string[,] output, bool readFormulas = false)
        {
            sheet++;
            output = null;
            if (wb == null)
                return false;

            if (wb.Worksheets.Count < sheet || sheet < 1)
                return false;

            Worksheet ws = (Worksheet)wb.Sheets[sheet];
            int endRow = ws.UsedRange.Rows.Count - 1;
            int endCol = ws.UsedRange.Columns.Count - 1;

            sheet--;
            return ReadRange(sheet, 0, 0, endRow, endCol, out output, readFormulas);
        }

        /// <summary>
        /// Read an entire sheet
        /// </summary>
        /// <param name="name">Sheet name</param>
        /// <param name="output">Output read. Dimensions starts at 0</param>
        /// <param name="readFormulas">Whether to read values or formulas</param>
        /// <returns>Entire sheet selected</returns>
        public bool ReadSheet(string name, out string[,] output, bool readFormulas = false)
        {
            output = null;
            int index = GetSheetIndex(name);
            if (index == -1)
                return false;

            index--;

            return ReadSheet(index, out output, readFormulas);
        }
    }
}
