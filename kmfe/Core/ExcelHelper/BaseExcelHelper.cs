using ClosedXML.Excel;
using kmfe.Utils.ExcelReadWriteHelper;

namespace kmfe.Core.ExcelHelper
{
    internal abstract class BaseExcelHelper
    {
        /// <summary>
        /// 全部表头数组
        /// </summary>
        public string[] ExcelHeaders { init; get; } = Array.Empty<string>();

        /// <summary>
        /// 写入excel一行数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="xLRowWriteHelper"></param>
        protected abstract void ToExcelRow(int id, XLRowWriteHelper xLRowWriteHelper);

        /// <summary>
        /// 从excel一行读入数据
        /// </summary>
        /// <param name="xLRowReadHelper"></param>
        protected abstract void FromExcelRow(XLRowReadHelper xLRowReadHelper);

        /// <summary>
        /// 写入excel文件
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="headers">需要写入的表头</param>
        /// <param name="rowCount">数据行数</param>
        public void WriteExcelSheet(IXLWorksheet worksheet, string[] headers, int rowCount)
        {
            // 写入第一行表头
            int column = 1;
            foreach (string header in headers)
            {
                worksheet.Cell(1, column).Value = header;
                column++;
            }
            // 写入数据
            for (int id = 0; id < rowCount; id++)
            {
                int row = id + 2;
                XLRowWriteHelper xLRowWriteHelper = new(worksheet.Row(row), headers);
                ToExcelRow(id, xLRowWriteHelper);
            }
        }

        /// <summary>
        /// 从excel文件读取
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="headers">需要读取的表头</param>
        public void ReadExcelSheet(IXLWorksheet worksheet, string[] headers)
        {
            // 读取第一行表头，生成表头-列字典
            Dictionary<string, int> headerToColumnDict = new();
            IXLRow firstRow = worksheet.Row(1);
            for (int column = 1; column <= worksheet.LastColumnUsed().ColumnNumber(); column++)
            {
                string header = firstRow.Cell(column).Value.GetText();
                if (headers.Contains(header))
                {
                    headerToColumnDict.Add(header, column);
                }
            }
            // 读取数据
            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
            {
                XLRowReadHelper xLRowReadHelper = new(worksheet.Row(row), headerToColumnDict);
                FromExcelRow(xLRowReadHelper);
            }
        }

        /// <summary>
        /// 获取excel表的全部表头
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        public string[] ReadExcelSheetHeaders(IXLWorksheet worksheet)
        {
            List<string> headers = new();
            IXLRow firstRow = worksheet.Row(1);
            for (int column = 1; column <= worksheet.LastColumnUsed().ColumnNumber(); column++)
            {
                string header = firstRow.Cell(column).Value.GetText();
                headers.Add(header);
            }
            return headers.ToArray();
        }
    }
}
