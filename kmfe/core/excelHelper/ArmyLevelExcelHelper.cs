using kmfe.core.globalTypes;
using kmfe.utils.excelReadWriteHelper;

namespace kmfe.core.excelHelper
{
    internal class ArmyLevelExcelHelper : BaseExcelHelper
    {
        public ArmyLevelExcelHelper()
        {
            ExcelHeaders = new string[] { "ID", "名称", "所需经验", "战法成功率", "能力倍率" };
        }

        protected override void FromExcelRow(XLRowReadHelper xLRowReadHelper)
        {
            int id = -1;
            xLRowReadHelper.SetAttrByHeader("ID", ref id);
            if (id == -1) return;
            ArmyLevel armyLevel = AppEnvironment.scenarioData.armyLevelArray[id];
            xLRowReadHelper.SetAttrByHeader("名称", ref armyLevel.name);
            xLRowReadHelper.SetAttrByHeader("所需经验", ref armyLevel.exp);
            xLRowReadHelper.SetAttrByHeader("战法成功率", ref armyLevel.tacticsChanceBuff);
            xLRowReadHelper.SetAttrByHeader("能力倍率", ref armyLevel.unitStatRatio);
        }

        protected override void ToExcelRow(int id, XLRowWriteHelper xLRowWriteHelper)
        {
            ArmyLevel armyLevel = AppEnvironment.scenarioData.armyLevelArray[id];
            xLRowWriteHelper.SetCellValueByHeader("ID", armyLevel.Id);
            xLRowWriteHelper.SetCellValueByHeader("名称", armyLevel.name);
            xLRowWriteHelper.SetCellValueByHeader("所需经验", armyLevel.exp);
            xLRowWriteHelper.SetCellValueByHeader("战法成功率", armyLevel.tacticsChanceBuff);
            xLRowWriteHelper.SetCellValueByHeader("能力倍率", Math.Round(armyLevel.unitStatRatio, 2));  // Round避免小数位数异常
        }
    }
}
