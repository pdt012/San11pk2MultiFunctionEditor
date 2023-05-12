using kmfe.core;
using kmfe.core.globalTypes;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public partial class ArmyLevelEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        ArmyLevel? armyLevel;

        public ArmyLevelEditDialog()
        {
            InitializeComponent();
        }

        public override void Init(ScenarioData scenarioData)
        {
            base.Init(scenarioData);
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

        public override void Apply()
        {
            if (armyLevel == null) return;
            armyLevel.name = text_name.Text;
            armyLevel.exp = (int)value_exp.Value;
            armyLevel.tacticsChanceBuff = (int)value_tactic_chance.Value;
            armyLevel.unitStatRatio = (float)value_stat_ratio.Value;

            OnApply?.Invoke(new List<int>() { armyLevel.Id });
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
