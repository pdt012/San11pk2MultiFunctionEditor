using kmfe.Core.GlobalTypes;
using kmfe.Utils.ExcelReadWriteHelper;

namespace kmfe.Core.ExcelHelper
{
    internal class SkillExcelHelper : BaseExcelHelper
    {
        public SkillExcelHelper()
        {
            ExcelHeaders = new string[] { "ID", "名称", "描述", "类型", "等级", "组合特技",
                "参数0", "值0", "参数1", "值1", "参数2", "值2", "参数3", "值3", "参数4", "值4" };
        }

        protected override void FromExcelRow(XLRowReadHelper xLRowReadHelper)
        {
            int id = -1;
            xLRowReadHelper.SetAttrByHeader("ID", ref id);
            if (id == -1) return;
            Skill skill = AppEnvironment.scenarioData.skillArray[id];
            xLRowReadHelper.SetAttrByHeader("名称", ref skill.name);
            if (skill.name.Length == 0) return;  // 名称为空则跳过
            xLRowReadHelper.SetAttrByHeader("描述", ref skill.desc);
            xLRowReadHelper.SetEnumAttrByHeader("类型", ref skill.type);
            xLRowReadHelper.SetAttrByHeader("等级", ref skill.level);
            // 组合特技
            string bindSkillsStr = "";
            xLRowReadHelper.SetAttrByHeader("组合特技", ref bindSkillsStr);
            skill.SetBindSkillsFromString(bindSkillsStr);
            // 特技参数
            for (int i = 0; i < 5; i++)
            {
                if (!xLRowReadHelper.IsCellEmpty($"值{i}"))
                {
                    string constantDesc = "";
                    int constantValue = 0;
                    xLRowReadHelper.SetAttrByHeader($"参数{i}", ref constantDesc);
                    xLRowReadHelper.SetAttrByHeader($"值{i}", ref constantValue);
                    skill.constantArray[i].Setup(constantDesc, constantValue);
                }
                else
                {
                    skill.constantArray[i].Cancel();
                }
            }
        }

        protected override void ToExcelRow(int id, XLRowWriteHelper xLRowWriteHelper)
        {
            Skill skill = AppEnvironment.scenarioData.skillArray[id];
            xLRowWriteHelper.SetCellValueByHeader("ID", skill.Id);
            xLRowWriteHelper.SetCellValueByHeader("名称", skill.name);
            xLRowWriteHelper.SetCellValueByHeader("描述", skill.desc);
            xLRowWriteHelper.SetCellValueByHeader("类型", Enum.GetName(skill.type) ?? "");
            xLRowWriteHelper.SetCellValueByHeader("等级", skill.level);
            xLRowWriteHelper.SetCellValueByHeader("组合特技", skill.GetBindSkillsString());
            // 特技参数
            for (int i = 0; i < 5; i++)
            {
                SkillConstant constant = skill.constantArray[i];
                if (constant.available)
                {
                    xLRowWriteHelper.SetCellValueByHeader($"参数{i}", constant.desc);
                    xLRowWriteHelper.SetCellValueByHeader($"值{i}", constant.value);
                }
            }
        }
    }
}
