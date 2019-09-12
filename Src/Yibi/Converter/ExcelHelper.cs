using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;

namespace Yibi.Converter
{
    public class ExcelHelper
    {
        private SheetHeader _sheetHeader;

        public IEnumerable<T> Import<T>(Stream source) where T : class, new()
        {
            var wb = CreateWorkbook(source);
            var sheet = wb.GetSheetAt(0);
            _sheetHeader = new SheetHeader(sheet);

            return GetSheetDatas<T>(sheet, _sheetHeader.RowIndex + 1, sheet.LastRowNum);
        }

        public IEnumerable<T> GetSheetDatas<T>(ISheet sheet, int startRowIndex, int endRowIndex) where T : class, new()
        {
            if (startRowIndex < sheet.FirstRowNum || endRowIndex > sheet.LastRowNum) throw new ArgumentException("startRowIndex or endRowIndex invalid error!");

            var sheetDatas = new List<T>();

            for (var rowIndex = startRowIndex; rowIndex <= endRowIndex; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);

                sheetDatas.Add(GetRowValues<T>(row));
            }

            return sheetDatas;
        }

        public T GetRowValues<T>(IRow row) where T:class,new()
        {
            var rowValues = new List<T>();
            var json = new JObject();

            for (var cellIndex = _sheetHeader.FirstCellNum; cellIndex < _sheetHeader.LastCellNum; cellIndex++)
            {
                var cell = row.GetCell(cellIndex);
                var cellValue = GetCellValue(cell);

                json.Add(_sheetHeader.ValueItems[cellIndex], cellValue);
            }

            return json.ToObject<T>();
        }

        public IWorkbook CreateWorkbook(Stream source, bool isclear = false)
        {
            if (!isclear)
            {
                return WorkbookFactory.Create(source);
            }

            using (var stream = new MemoryStream())
            {
                source.CopyTo(stream);
                source.SetLength(0);

                return WorkbookFactory.Create(stream);
            }
        }

        public string GetCellValue(ICell cell)
        {
            return cell?.ToString().Trim();
        }
    }
}
