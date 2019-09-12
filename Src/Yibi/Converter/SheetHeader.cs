using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;

namespace Yibi.Converter
{
    public class SheetHeader
    {
        public SheetHeader(ISheet sheet)
        {
            RowIndex = sheet.FirstRowNum;
            var row = sheet.GetRow(sheet.FirstRowNum);
            if (row == null) return;

            FirstCellNum = row.FirstCellNum;
            LastCellNum = row.LastCellNum;
            CellCount = row.Cells.Count;
            ValueItems = GetValueItems(row);
        }

        public int FirstCellNum { get; set; }
        public int LastCellNum { get; set; }
        public int CellCount { get; set; }
        public int RowIndex { get; set; }
        public Dictionary<int, string> ValueItems { get; set; }

        private Dictionary<int, string> GetValueItems(IRow row)
        {
            var dic = new Dictionary<int, string>();

            for (var cellIndex = row.FirstCellNum; cellIndex < row.LastCellNum; cellIndex++)
            {
                var cell = row.GetCell(cellIndex);
                var cellValue = cell == null ? string.Empty : cell.ToString().Trim();

                dic.Add(cellIndex,cellValue);
            }

            return dic;
        }
    }
}
