using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.editor.scenarioConfig.editDialog;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class CityEditHelper : BaseEditorHelper
    {
        public readonly CityEditDialog editDialog;

        public CityEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
            baseEditDialog = editDialog;
        }

        public override int GetCount() => ScenarioData.cityCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
            listView.Columns.Add("相邻城市", 300);
        }

        public override void UpdateListView()
        {
            listView.Items.Clear();
            foreach (City city in AppEnvironment.scenarioData.cityArray)
            {
                ListViewItem item = new()
                {
                    Tag = city,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not City city) return;
            item.SubItems.Clear();
            item.Text = city.Id.ToString();
            item.SubItems.Add(city.name);
            List<string> adjacentCityNames = AppEnvironment.scenarioData.GetAdjacentCityNames(city);
            item.SubItems.Add(string.Join(", ", adjacentCityNames));
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            if (item.Tag is not City city) return;
            editDialog.Setup(city);
            editDialog.Execute(parentForm);
        }
    }
}
