namespace BotAgent.Ifrit.DataExporter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Office.Interop.Excel;
    using System.Threading;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;

    public class Excel
    {
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private Application _excelApp;
        private Workbook _excelWorkBook;
        private Worksheet _excelSheet;

        public List<List<string>> Rows = new List<List<string>>();

        private void InitExcelApp()
        {
            _excelApp = new Application();
            _excelWorkBook = _excelApp.Workbooks.Add();
            _excelSheet = (Worksheet)_excelWorkBook.Sheets[1];
        }

        /// <summary>
        /// I know that this is wrong way to do like this, 
        /// but this is really most easy way to fix non-killing Excel process issue
        /// </summary>
        private void CloseExcelApp()
        {
            int hWnd = _excelApp.Application.Hwnd;
            uint processID;

            GetWindowThreadProcessId((IntPtr)hWnd, out processID);
            Process.GetProcessById((int)processID).Kill();

            _excelWorkBook = null;
            _excelApp = null;
            _excelSheet = null;
        }

        public void FileOpen(string path)
        {
            Stopwatch st = new Stopwatch();

            InitExcelApp();

            Rows.Clear();

            _excelWorkBook = _excelApp.Workbooks.Open(path);
            _excelSheet = (Worksheet)_excelWorkBook.Sheets[1];

            //Fix for empty cells that excel see as not empty
            _excelSheet.Columns.ClearFormats();
            _excelSheet.Rows.ClearFormats();

            int lastRow = _excelSheet.UsedRange.Rows.Count;
            int lastCell = _excelSheet.UsedRange.Columns.Count;

            st.Start();

            //SLOW!!!!!!
            for (int i = 1; i <= lastRow; i++)
            {
                Rows.Add(new List<string>());

                for (int j = 1; j <= lastCell; j++)
                {
                    var tmp = (_excelSheet.Cells[i, j]).Formula;
                    var value = (tmp != null) ? tmp.ToString() : string.Empty;

                    Rows[Rows.Count - 1].Add(value);
                }
            }
            //SLOW!!!!!!


            Console.WriteLine("3rd block take " + st.Elapsed);
            st.Restart();

            RemoveGarbageFromRows(lastRow, lastCell);

            CloseExcelApp();

        }

        private void RemoveGarbageFromRows(int lastRow, int lastCell)
        {
            for (int i = 0; i < lastRow; i++)
            {
                for (int j = lastCell - 1; j > 0; j--)
                {
                    if (Rows[i][j] == "") Rows[i].RemoveAt(j);
                    else { j = 0; }
                }
            }
        }

        public void FileSave(string path, bool hideExcelPopupsAndAlerts = true)
        {
            InitExcelApp();

            CreateDirIfNotExist(path, true);

            MoveRowsToExcelRows();

            _excelApp.DisplayAlerts = !hideExcelPopupsAndAlerts;

            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    _excelWorkBook.SaveAs(path, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                        false, false, XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    i = 4;
                }
                catch (Exception e)
                {
                    Thread.Sleep(500);
                }
            }

            CloseExcelApp();
        }

        public void AddRow(params string[] cells)
        {
            Rows.Add(cells.ToList());
        }

        private void MoveRowsToExcelRows()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Rows[i].Count; j++)
                {
                    _excelSheet.Cells[i + 1, j + 1] = Rows[i][j];
                }
            }
        }

        private void CreateDirIfNotExist(string dirPath, bool removeFilename = false)
        {
            if (removeFilename)
            {
                dirPath = Directory.GetParent(dirPath).FullName;
            }

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

    }
}