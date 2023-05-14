using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.s11.enums;

namespace kmfe.editor.scenarioConfig.editDialog
{
    public partial class RankEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        Rank? rank;

        public RankEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            combo_stat_type.Items.Clear();
            combo_stat_type.Items.AddRange(Enum.GetNames<StatType>());
        }

        public void Setup(Rank rank)
        {
            this.rank = rank;
            text_id.Text = rank.Id.ToString();
            text_name.Text = rank.name;
            value_command.Value = rank.command;
            combo_stat_type.SelectedIndex = (int)rank.statType;
            value_stat_increase.Value = rank.statIncrease;
            value_salary.Value = rank.salary;
            value_rank_level.Value = rank.rankLevel;
        }

        public override bool Apply()
        {
            if (rank == null) return false;
            rank.name = text_name.Text;
            rank.command = (int)value_command.Value;
            rank.statType = (StatType)combo_stat_type.SelectedIndex;
            rank.statIncrease = (int)value_stat_increase.Value;
            rank.salary = (int)value_salary.Value;
            rank.rankLevel = (int)value_rank_level.Value;

            OnApply?.Invoke(new List<int>() { rank.Id });
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
    }
}
