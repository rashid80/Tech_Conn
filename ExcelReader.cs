using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Excel = Microsoft.Office.Interop.Excel;

namespace Tech_Conn
{
    static class ExcelReader
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        private static Process GetExcelProcess(Excel.Application excelApp)
        {
            GetWindowThreadProcessId(excelApp.Hwnd, out int id);
            return Process.GetProcessById(id);
        }


        private static string getStringFromExcelCell(Excel.Worksheet sheet, int numRow, int numCol)
        {
            var range2 = (Excel.Range)sheet.Cells[numRow, numCol];
            return range2.Text.ToString();
        }

        public static Tuple<Mass1, Mass2> getMassfromFile(string fileName)
        {

            Excel.Application excelApp = new Excel.Application(); //создаём приложение Excel
            excelApp.Visible = false;

            Process appProcess = GetExcelProcess(excelApp);

            var workBook = excelApp.Workbooks.Open(fileName);
            var sheet = (Excel.Worksheet)workBook.Sheets[1];

            var lastCell = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//1 ячейку
            int lastRow = (int)lastCell.Row;

            var mass1 = new Mass1();
            var mass2 = new Mass2();

            string errText = "";
            try
            {

                for (int currRow = 3; currRow <= lastRow; currRow++)
                {
                    string var1 = getStringFromExcelCell(sheet, currRow, 1);
                    if (!String.IsNullOrEmpty(var1))
                    {
                        var massInfoLine1 = new MassInfoLine1();

                        massInfoLine1.var1 = var1;
                        massInfoLine1.var2 = getStringFromExcelCell(sheet, currRow, 2);
                        massInfoLine1.var3 = getStringFromExcelCell(sheet, currRow, 3);
                        massInfoLine1.var4 = getStringFromExcelCell(sheet, currRow, 4);
                        massInfoLine1.var5 = getStringFromExcelCell(sheet, currRow, 5);

                        mass1.dataList.Add(massInfoLine1);
                    }

                    string var6 = getStringFromExcelCell(sheet, currRow, 6);
                    if (!String.IsNullOrEmpty(var6))
                    {
                        var massInfoLine2 = new MassInfoLine2();

                        massInfoLine2.var6 = var6;
                        massInfoLine2.var7 = getStringFromExcelCell(sheet, currRow, 7);
                        massInfoLine2.var8 = getStringFromExcelCell(sheet, currRow, 8);
                        massInfoLine2.var9 = getStringFromExcelCell(sheet, currRow, 9);
                        massInfoLine2.var10 = getStringFromExcelCell(sheet, currRow, 10);

                        mass2.dataList.Add(massInfoLine2);
                    }
                }

                workBook.Close(true);
                excelApp.Quit();
            }

            catch (Exception e)
            {
                errText = e.ToString();
            }

            sheet = null;
            workBook = null;
            excelApp = null;

            try
            {
                appProcess.Kill(); //Иначе Excel не закроется
            }
            catch
            {

            }

            if (!String.IsNullOrEmpty(errText))
            {
                throw new Exception(errText);
            }

            return new Tuple<Mass1, Mass2>(mass1, mass2);

        }

    }



}


