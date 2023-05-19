using kmfe.Core.GlobalTypes;
using kmfe.Utils.ExcelReadWriteHelper;

namespace kmfe.Core.ExcelHelper
{
    internal class RankExcelHelper : BaseExcelHelper
    {
        public RankExcelHelper()
        {
            ExcelHeaders = new string[] { "ID", "名称", "最大指挥", "能力", "上升值", "俸禄", "品阶", "所需功绩" };
        }

        protected override void FromExcelRow(XLRowReadHelper xLRowReadHelper)
        {
            int id = -1;
            xLRowReadHelper.SetAttrByHeader("ID", ref id);
            if (id == -1) return;
            Rank rank = AppEnvironment.scenarioData.rankArray[id];
            xLRowReadHelper.SetAttrByHeader("名称", ref rank.name);
            xLRowReadHelper.SetAttrByHeader("最大指挥", ref rank.command);
            xLRowReadHelper.SetEnumAttrByHeader("能力", ref rank.statType);
            xLRowReadHelper.SetAttrByHeader("上升值", ref rank.statIncrease);
            xLRowReadHelper.SetAttrByHeader("俸禄", ref rank.salary);
            xLRowReadHelper.SetAttrByHeader("品阶", ref rank.rankLevel);
            xLRowReadHelper.SetAttrByHeader("所需功绩", ref rank.merit);
        }

        protected override void ToExcelRow(int id, XLRowWriteHelper xLRowWriteHelper)
        {
            Rank rank = AppEnvironment.scenarioData.rankArray[id];
            xLRowWriteHelper.SetCellValueByHeader("ID", rank.Id);
            xLRowWriteHelper.SetCellValueByHeader("名称", rank.name);
            xLRowWriteHelper.SetCellValueByHeader("最大指挥", rank.command);
            xLRowWriteHelper.SetCellValueByHeader("能力", Enum.GetName(rank.statType));
            xLRowWriteHelper.SetCellValueByHeader("上升值", rank.statIncrease);
            xLRowWriteHelper.SetCellValueByHeader("俸禄", rank.salary);
            xLRowWriteHelper.SetCellValueByHeader("品阶", rank.rankLevel);
            xLRowWriteHelper.SetCellValueByHeader("所需功绩", rank.merit);
        }
    }
}
