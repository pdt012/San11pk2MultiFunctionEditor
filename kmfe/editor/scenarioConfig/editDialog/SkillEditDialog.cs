using kmfe.common;
using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.forms;
using kmfe.s11.enums;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public partial class SkillEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        public SkillEditDialog()
        {
            InitializeComponent();
        }

        public override void Init(ScenarioData scenarioData)
        {
            base.Init(scenarioData);
            skillType.Items.Clear();
            skillType.Items.AddRange(Enum.GetNames<SkillType>());
            skillBinds.SetChoices(GetEnabledSkillNames(), 8);
        }

        public void Setup(Skill skill)
        {
            skillId.Text = skill.Id.ToString();
            skillName.Text = skill.name;
            skillType.SelectedIndex = (int)skill.type;
            skillLevel.Value = skill.level;
            skillDesc.Text = skill.desc;
            skillBinds.SetSelected(skill.bindSkillList);
        }

        public override void Apply()
        {

        }

        private List<IntString> GetEnabledSkillNames()
        {
            List<IntString> names = new();
            foreach (Skill skill in scenarioData.skillArray)
            {
                if (skill.Id < Constants.SKILL_CUSTOMIZE_BEGIN)
                    names.Add(new IntString(skill.Id, string.Format("{0}-{1}", skill.Id, skill.name)));
            }
            return names;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
