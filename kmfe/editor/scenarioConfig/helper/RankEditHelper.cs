using kmfe.core.globalTypes;
using kmfe.core;
using kmfe.editor.scenarioConfig.editDialog;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class RankEditHelper : BaseEditorHelper
    {
        public readonly RankEditDialog editDialog;

        public RankEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
        }

        public override int GetCount() => ScenarioData.rankCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 100);
            listView.Columns.Add("最大指挥", 100);
            listView.Columns.Add("能力", 60);
            listView.Columns.Add("上升值", 60);
            listView.Columns.Add("俸禄", 60);
            listView.Columns.Add("品阶", 60);
            listView.Columns.Add("所需功绩", 100);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Rank rank in AppEnvironment.scenarioData.rankArray)
            {
                ListViewItem item = new()
                {
                    Tag = rank,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Rank rank) return;
            item.SubItems.Clear();
            item.Tag = rank;
            item.Text = rank.Id.ToString();
            item.SubItems.Add(rank.name);
            item.SubItems.Add(rank.command.ToString());
            item.SubItems.Add(Enum.GetName(rank.statType));
            item.SubItems.Add(rank.statIncrease.ToString());
            item.SubItems.Add(rank.salary.ToString());
            item.SubItems.Add(rank.rankLevel.ToString());
            item.SubItems.Add(rank.merit.ToString());
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not Rank rank) return;
            editDialog.Init();
            editDialog.Setup(rank);
            editDialog.Show(Form.ActiveForm);
        }

        public override void OnLoaded()
        {
            editDialog.Initialized = false;
        }
    }
}
