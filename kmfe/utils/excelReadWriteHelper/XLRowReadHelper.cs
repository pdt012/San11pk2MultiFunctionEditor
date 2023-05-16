using ClosedXML.Excel;

namespace kmfe.utils.excelReadWriteHelper
{
    internal class XLRowReadHelper
    {
        private IXLRow xlRow;
        private Dictionary<string, int> headerToColumnDict;

        public XLRowReadHelper(IXLRow xlRow, Dictionary<string, int> headerToColumnDict)
        {
            this.xlRow = xlRow;
            this.headerToColumnDict = headerToColumnDict;
        }

        public void SetAttrByHeader(string header, ref int attr)
        {
            if (headerToColumnDict.TryGetValue(header, out int value))
                attr = (int)xlRow.Cell(value).GetDouble();
        }

        public void SetAttrByHeader(string header, ref float attr)
        {
            if (headerToColumnDict.TryGetValue(header, out int value))
                attr = (float)xlRow.Cell(value).GetDouble();
        }

        public void SetAttrByHeader(string header, ref bool attr)
        {
            if (headerToColumnDict.TryGetValue(header, out int value))
                attr = xlRow.Cell(value).GetBoolean();
        }

        public void SetAttrByHeader(string header, ref string attr)
        {
            if (headerToColumnDict.TryGetValue(header, out int value))
                attr = xlRow.Cell(value).GetText();
        }
    }
}
