using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.editor.scenarioConfig.editDialog;
using Region = kmfe.core.globalTypes.Region;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class RegionEditHelper : BaseEditorHelper
    {
        public readonly RegionEditDialog editDialog;

        public RegionEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
            baseEditDialog = editDialog;
        }

        public override int GetCount() => ScenarioData.regionCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
            listView.Columns.Add("读音", 100);
        }
        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (Region region in AppEnvironment.scenarioData.regionArray)
            {
                ListViewItem item = new()
                {
                    Tag = region,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not Region region) return;

            item.SubItems.Clear();
            item.Text = region.Id.ToString();
            item.SubItems.Add(region.name);
            item.SubItems.Add(region.read);
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not Region region) return;
            editDialog.Setup(region);
            editDialog.Execute(Form.ActiveForm);
        }
    }
}
