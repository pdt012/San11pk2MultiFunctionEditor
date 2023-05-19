﻿using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Forms;
using kmfe.S11.S11Enums;

namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public partial class SkillEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Skill? skill;
        int row = -1;
        readonly List<SkillContantUI> skillContantUIList;

        public SkillEditDialog()
        {
            InitializeComponent();
            skillContantUIList = new()
            {
                new SkillContantUI(checkBox1, textBox1, numericUpDown1),
                new SkillContantUI(checkBox2, textBox2, numericUpDown2),
                new SkillContantUI(checkBox3, textBox3, numericUpDown3),
                new SkillContantUI(checkBox4, textBox4, numericUpDown4),
                new SkillContantUI(checkBox5, textBox5, numericUpDown5),
            };
            foreach (SkillContantUI skillContantUI in skillContantUIList)
            {
                skillContantUI.Value.Minimum = -1000000;
                skillContantUI.Value.Maximum = 1000000;
                skillContantUI.Available.CheckedChanged += (object? sender, EventArgs e) =>
                {
                    skillContantUI.Desc.Enabled = skillContantUI.Available.Checked;
                    skillContantUI.Value.Enabled = skillContantUI.Available.Checked;
                };
            }
        }

        public override void Init()
        {
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
            for (int i = 0; i < skill.constantArray.Length; i++)
            {
                SkillConstant constant = skill.constantArray[i];
                SkillContantUI skillContantUI = skillContantUIList[i];
                if (constant.available)
                {
                    skillContantUI.Available.Checked = true;
                    skillContantUI.Desc.Enabled = true;
                    skillContantUI.Value.Enabled = true;
                    skillContantUI.Desc.Text = constant.desc;
                    skillContantUI.Value.Value = constant.value;
                }
                else
                {
                    skillContantUI.Available.Checked = false;
                    skillContantUI.Desc.Enabled = false;
                    skillContantUI.Value.Enabled = false;
                    skillContantUI.Desc.Text = "";
                    skillContantUI.Value.Value = 0;
                }
            }
        }

        public override bool Apply()
        {
            if (skill == null) return false;
            if (text_name.Text.Length == 0)
            {
                AppFormUtils.WarningBox("名称不可以为空！", "修改失败");
                return false;
            }
            if (text_desc.Text.Length == 0)
            {
                AppFormUtils.WarningBox("描述不可以为空！", "修改失败");
                return false;
            }
            skill.name = text_name.Text;
            skill.desc = text_desc.Text;
            skill.type = (SkillType)text_type.SelectedIndex;
            skill.level = (int)value_level.Value;
            // 组合特技
            skill.bindSkillList = skill_binds.GetSelected().ToList();
            // 特技参数
            for (int i = 0; i < skill.constantArray.Length; i++)
            {
                SkillConstant constant = skill.constantArray[i];
                SkillContantUI skillContantUI = skillContantUIList[i];
                if (skillContantUI.Available.Checked)
                    constant.Setup(skillContantUI.Desc.Text, (int)skillContantUI.Value.Value);
                else
                    constant.Cancel();
            }

            OnApply?.Invoke(new List<int>() { row });
            return true;
        }

        private List<IntString> GetEnabledSkillNames()
        {
            List<IntString> names = new();
            for (int id = ScenarioData.skillBasicBegin; id < ScenarioData.skillBasicEnd; id++)
            {
                Skill skill = AppEnvironment.scenarioData.skillArray[id];
                if (skill.IsValid())
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

    record SkillContantUI(CheckBox Available, TextBox Desc, NumericUpDown Value);
}
