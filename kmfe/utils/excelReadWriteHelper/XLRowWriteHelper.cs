using ClosedXML.Excel;

namespace kmfe.utils.excelReadWriteHelper
{
    internal class XLRowWriteHelper
    {
        private IXLRow xlRow;
        private Dictionary<string, int> headerToColumnDict = new();

        public XLRowWriteHelper(IXLRow xlRow, string[] headers)
        {
            this.xlRow = xlRow;
            int col = 1;
            foreach (string header in headers)
            {
                headerToColumnDict.Add(header, col);
                col++;
            }
        }

        public void SetCellValueByHeader(string header, int value)
        {
            if (headerToColumnDict.TryGetValue(header, out int v))
                xlRow.Cell(v).Value = value;
        }

        public void SetCellValueByHeader(string header, double value)
        {
            if (headerToColumnDict.TryGetValue(header, out int v))
                xlRow.Cell(v).Value = value;
        }

        public void SetCellValueByHeader(string header, bool value)
        {
            if (headerToColumnDict.TryGetValue(header, out int v))
                xlRow.Cell(v).Value = value;
        }

        public void SetCellValueByHeader(string header, string value)
        {
            if (headerToColumnDict.TryGetValue(header, out int v))
                xlRow.Cell(v).Value = value;
        }
    }
}
