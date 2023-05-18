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

        public bool IsCellEmpty(string header)
        {
            if (headerToColumnDict.TryGetValue(header, out int value))
                return xlRow.Cell(value).IsEmpty();
            return true;
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
            {
                XLCellValue cellValue = xlRow.Cell(value).Value;
                if (cellValue.IsBlank)  // 单元格为空时返回空字符串
                    attr = "";
                else
                    attr = cellValue.GetText();
            }
        }

        public void SetEnumAttrByHeader<E>(string header, ref E attr)
        {
            if (headerToColumnDict.TryGetValue(header, out int value))
            {
                XLCellValue cellValue = xlRow.Cell(value).Value;
                if (cellValue.IsNumber)
                {
                    object enumObj = Enum.ToObject(typeof(E), (int)cellValue.GetNumber());
                    if (Enum.IsDefined(typeof(E), enumObj))
                    {
                        attr = (E)enumObj;
                    }
                }
                else if (cellValue.IsText)
                {
                    if (Enum.TryParse(typeof(E), cellValue.GetText(), out object? enumObj))
                    {
                        attr = (E)enumObj;
                    }
                }
            }
        }
    }
}
