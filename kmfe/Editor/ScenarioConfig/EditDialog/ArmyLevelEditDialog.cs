﻿using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;

namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public partial class ArmyLevelEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        ArmyLevel? armyLevel;

        public ArmyLevelEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            value_exp.Minimum = 0;
            value_exp.Maximum = ArmyLevel.UnreachableExp;
        }

        public void Setup(ArmyLevel armyLevel)
        {
            this.armyLevel = armyLevel;
            text_id.Text = armyLevel.Id.ToString();
            text_name.Text = armyLevel.name;
            check_reachable.Checked = armyLevel.IsReachable();
            value_exp.Enabled = armyLevel.IsReachable();
            value_exp.Value = armyLevel.exp;
            value_tactic_chance.Value = armyLevel.tacticsChanceBuff;
            value_stat_ratio.Value = (decimal)armyLevel.unitStatRatio;
        }

        public override bool Apply()
        {
            if (armyLevel == null) return false;
            armyLevel.name = text_name.Text;
            armyLevel.exp = (int)value_exp.Value;
            armyLevel.tacticsChanceBuff = (int)value_tactic_chance.Value;
            armyLevel.unitStatRatio = (float)value_stat_ratio.Value;

            OnApply?.Invoke(new List<int>() { armyLevel.Id });
            return true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void value_exp_ValueChanged(object sender, EventArgs e)
        {
            if (value_exp.Value == ArmyLevel.UnreachableExp)
            {
                check_reachable.Checked = false;
                value_exp.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_reachable.Checked)
            {
                value_exp.Enabled = true;
                value_exp.Value = 0;
            }
            else
            {
                value_exp.Enabled = false;
                value_exp.Value = ArmyLevel.UnreachableExp;
            }
        }
    }
}