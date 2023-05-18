using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;

namespace kmfe.Editor.ScenarioConfig.EditHelper
{
    internal class TownEditHelper : BaseEditorHelper
    {
        public readonly TownEditDialog editDialog;

        public TownEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
        }

        public override int GetCount() => ScenarioData.townCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 80);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Town town in AppEnvironment.scenarioData.townArray)
            {
                ListViewItem item = new()
                {
                    Tag = town,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Town town) return;
            item.SubItems.Clear();
            item.Text = town.Id.ToString();
            item.SubItems.Add(town.name);
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not Town town) return;
            editDialog.Setup(town);
            editDialog.Execute(Form.ActiveForm);
        }
    }
}
