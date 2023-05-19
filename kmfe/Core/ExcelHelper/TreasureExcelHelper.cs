using kmfe.Core.GlobalTypes;
using kmfe.S11.S11Enums;
using kmfe.Utils.ExcelReadWriteHelper;

namespace kmfe.Core.ExcelHelper
{
    internal class TreasureExcelHelper : BaseExcelHelper
    {
        public TreasureExcelHelper()
        {
            ExcelHeaders = new string[] { "ID", "名称", "读音", "类型", "价值", "特技",
                "统率", "武力", "智力", "政治", "魅力", "列传", "图片" };
        }

        protected override void FromExcelRow(XLRowReadHelper xLRowReadHelper)
        {
            int id = -1;
            xLRowReadHelper.SetAttrByHeader("ID", ref id);
            if (id == -1) return;
            Treasure treasure = AppEnvironment.scenarioData.treasureArray[id];
            xLRowReadHelper.SetAttrByHeader("名称", ref treasure.name);
            if (treasure.name.Length == 0) return;  // 名称为空则跳过
            xLRowReadHelper.SetAttrByHeader("读音", ref treasure.read);
            xLRowReadHelper.SetEnumAttrByHeader("类型", ref treasure.type);
            xLRowReadHelper.SetAttrByHeader("价值", ref treasure.worth);
            xLRowReadHelper.SetAttrByHeader("特技", ref treasure.bindSkillId, -1);
            for (int i = 0; i < 5; i++)
            {
                xLRowReadHelper.SetAttrByHeader(Enum.GetName((StatType)i), ref treasure.statBuff[i], 0);
            }
            xLRowReadHelper.SetAttrByHeader("列传", ref treasure.history);
            xLRowReadHelper.SetAttrByHeader("图片", ref treasure.imagePath);
        }

        protected override void ToExcelRow(int id, XLRowWriteHelper xLRowWriteHelper)
        {
            Treasure treasure = AppEnvironment.scenarioData.treasureArray[id];
            xLRowWriteHelper.SetCellValueByHeader("ID", treasure.Id);
            xLRowWriteHelper.SetCellValueByHeader("名称", treasure.name);
            xLRowWriteHelper.SetCellValueByHeader("读音", treasure.read);
            xLRowWriteHelper.SetCellValueByHeader("类型", Enum.GetName(treasure.type));
            xLRowWriteHelper.SetCellValueByHeader("价值", treasure.worth);
            if (treasure.bindSkillId >= 0)
                xLRowWriteHelper.SetCellValueByHeader("特技", treasure.bindSkillId);
            for (int i = 0; i < 5; i++)
            {
                if (treasure.statBuff[i] != 0)
                    xLRowWriteHelper.SetCellValueByHeader(Enum.GetName((StatType)i), treasure.statBuff[i]);
            }
            xLRowWriteHelper.SetCellValueByHeader("列传", treasure.history);
            xLRowWriteHelper.SetCellValueByHeader("图片", treasure.imagePath);
        }
    }
}
