using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wealth_Wizard.Properties;
using Excel = Microsoft.Office.Interop.Excel;

namespace Wealth_Wizard.Handlers
{
    public static class ExcelHandler
    {
        // Just a test
        public static void LoadInfoInExcel(System.Data.DataTable info)
        {
            // Initialize the worksheet
            Excel.Application application = new Excel.Application();
            application.Visible = true;
            application.DisplayAlerts = false;

            Excel.Workbook wb = application.Workbooks.Add(Type.Missing);

            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
            sheet.Name = "Test";

            // Defines the top left start of the data
            int startX = Settings.Default.ExcelCellFormatStartX;
            int startY = Settings.Default.ExcelCellFormatStartY;

            // Create the title headers
            for (int iCol = 0; iCol < info.Columns.Count; iCol++)
            {
                sheet.Cells[iCol + startX][startY] = info.Columns[iCol].ColumnName;  
            }
            
            // List all the values
            for (int iRow = 0; iRow < info.Rows.Count; iRow++) 
            {
                DataRow row = info.Rows[iRow];

                for (int iCol = 0; iCol < info.Columns.Count; iCol++)
                {
                    // Added + 1 to row since the first row is already filled
                    sheet.Cells[iCol + startX][iRow + startY + 1] = row[iCol];
                }
            }

            Excel.Range excelCellRange = sheet.Range[sheet.Cells[1, 1],
                sheet.Cells[info.Rows.Count, info.Columns.Count]];
            excelCellRange.EntireColumn.AutoFit();
        }
    }
}
