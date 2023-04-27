using kmfe.core.globalTypes;
using kmfe.core;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class SkillEditHelper : BaseEditorHelper
    {
        public SkillEditHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 80);
            listView.Columns.Add("描述", 400);
            listView.Columns.Add("类型", 60);
            listView.Columns.Add("等级", 60);
            listView.Columns.Add("组合特技", 160);
        }

        public override void UpdateListView(ListView listView)
        {
            foreach (Skill skill in scenarioData.skillArray)
            {
                if (!skill.IsValid()) continue;
                ListViewItem item = new()
                {
                    Tag = skill,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Skill skill) return;

            item.SubItems.Clear();
            item.Tag = skill;
            item.Text = skill.Id.ToString();
            item.SubItems.Add(skill.name);
            item.SubItems.Add(skill.desc);
            item.SubItems.Add(Enum.GetName(skill.type));
            item.SubItems.Add(skill.level.ToString());
            item.SubItems.Add(GetBindSkillsNameString(skill));
        }

        private string GetBindSkillsNameString(Skill skill)
        {
            List<string> nameList = new();
            foreach (int skillId in skill.bindSkillList)
            {
                nameList.Add(scenarioData.skillArray[skillId].name);
            }
            return string.Join(", ", nameList);
        }
    }
}
