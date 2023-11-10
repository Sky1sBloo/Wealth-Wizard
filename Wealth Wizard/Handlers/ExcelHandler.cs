using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wealth_Wizard.Properties;
using static System.Windows.Forms.AxHost;
using Excel = Microsoft.Office.Interop.Excel;

namespace Wealth_Wizard.Handlers
{
    public static class ExcelHandler
    {
        /// <summary>
        /// Loads info to worksheet
        /// </summary>
        /// <param name="info"></param>
        /// <param name="sheetName"></param>
        /// <param name="startX">Left most part of the starting cell</param>
        /// <param name="startY">Top most part of the starting cell</param>
        /// <returns>Returns the worksheet generally used for formatting purposes</returns>
        public static Excel.Worksheet LoadInfoInExcel(System.Data.DataTable info, string sheetName,
            int startX = 0, int startY = 0)
        {
            // Initialize the worksheet
            Excel.Application application = new Excel.Application();
            application.Visible = true;
            application.DisplayAlerts = false;

            Excel.Workbook wb = application.Workbooks.Add(Type.Missing);

            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;
            sheet.Name = sheetName;

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

            return sheet;
        }

        /// <summary>
        /// Loads entries with format
        /// </summary>
        /// <param name="info"></param>
        /// <param name="sheetName"></param>
        public static void LoadEntries(System.Data.DataTable info, string sheetName)
        {
            // Defines the top left start of the data
            int startX = Settings.Default.ExcelCellFormatStartX;
            int startY = Settings.Default.ExcelCellFormatStartY;

            Excel.Worksheet sheet = LoadInfoInExcel(info, sheetName, startX, startY);

            // Makes a total sum in the bottom right of the sheet
            int rowBottomRight = info.Rows.Count + startY + 1;
            int columnRightMost = info.Columns.Count + startX - 1;

            sheet.Cells[columnRightMost][rowBottomRight].Formula =
                "=SUM(" + sheet.Cells[columnRightMost][startY + 1].Address + ":" + 
               sheet.Cells[columnRightMost][rowBottomRight - 1].Address + ")";

            // Formatting
            // Make the cell directly above the total have a double bottom border
            Excel.Border totalBorder = sheet.Cells[columnRightMost][rowBottomRight - 1].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            totalBorder.LineStyle = Excel.XlLineStyle.xlDouble;
            totalBorder.Weight = 4d;
            

            // Header bold
            Excel.Range headerRange = sheet.Range[sheet.Cells[startX, startY], sheet.Cells[startX, info.Columns.Count + startY]];
            headerRange.Font.Bold = true;

            // Autofit
            Excel.Range excelCellRange = sheet.Range[sheet.Cells[startX, startY],
                sheet.Cells[info.Rows.Count + startX, info.Columns.Count + startY]];
            excelCellRange.EntireColumn.AutoFit();
        }
    }
}
