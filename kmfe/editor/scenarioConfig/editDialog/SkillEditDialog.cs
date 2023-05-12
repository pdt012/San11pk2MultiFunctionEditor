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

        Skill? skill;
        int row = -1;

        public SkillEditDialog()
        {
            InitializeComponent();
        }

        public override void Init(ScenarioData scenarioData)
        {
            base.Init(scenarioData);
            text_type.Items.Clear();
            text_type.Items.AddRange(Enum.GetNames<SkillType>());
            skill_binds.Choices = GetEnabledSkillNames();
            skill_binds.MaxSelections = 8;
        }

        public void Setup(Skill skill, int row)
        {
            this.skill = skill;
            this.row = row;
            text_id.Text = skill.Id.ToString();
            text_name.Text = skill.name;
            text_type.SelectedIndex = (int)skill.type;
            value_level.Value = skill.level;
            text_desc.Text = skill.desc;
            skill_binds.SetSelected(skill.bindSkillList.ToArray());
        }

        public override bool Apply()
        {
            if (skill == null) return false;
            if (text_name.Text.Length == 0)
            {
                MessageBox.Show("名称不可以为空.");
                return false;
            }
            if (text_desc.Text.Length == 0)
            {
                MessageBox.Show("描述不可以为空.");
                return false;
            }
            skill.name = text_name.Text;
            skill.desc = text_desc.Text;
            skill.type = (SkillType)text_type.SelectedIndex;
            skill.level = (int)value_level.Value;
            skill.bindSkillList = skill_binds.GetSelected().ToList();

            OnApply?.Invoke(new List<int>() { row });
            return true;
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
            if (Apply())
                DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
