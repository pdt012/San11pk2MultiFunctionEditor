using kmfe.Core.GlobalTypes;
using kmfe.Utils.ExcelReadWriteHelper;

namespace kmfe.Core.ExcelHelper
{
    internal class TitleExcelHelper : BaseExcelHelper
    {
        public TitleExcelHelper()
        {
            ExcelHeaders = new string[] { "ID", "名称", "最大指挥" };
        }

        protected override void FromExcelRow(XLRowReadHelper xLRowReadHelper)
        {
            int id = -1;
            xLRowReadHelper.SetAttrByHeader("ID", ref id);
            if (id == -1) return;
            Title title = AppEnvironment.scenarioData.titleArray[id];
            xLRowReadHelper.SetAttrByHeader("名称", ref title.name);
            xLRowReadHelper.SetAttrByHeader("最大指挥", ref title.command);
        }

        protected override void ToExcelRow(int id, XLRowWriteHelper xLRowWriteHelper)
        {
            Title title = AppEnvironment.scenarioData.titleArray[id];
            xLRowWriteHelper.SetCellValueByHeader("ID", title.Id);
            xLRowWriteHelper.SetCellValueByHeader("名称", title.name);
            xLRowWriteHelper.SetCellValueByHeader("最大指挥", title.command);
        }
    }
}
