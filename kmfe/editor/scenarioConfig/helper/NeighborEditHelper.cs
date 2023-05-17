using kmfe.core;
using kmfe.core.globalTypes;
using kmfe.editor.scenarioConfig.editDialog;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class NeighborEditHelper : BaseEditorHelper
    {
        public readonly NeighborEditDialog editDialog;

        public NeighborEditHelper(ListView listView) : base(listView)
        {
            editDialog = new();
            editDialog.OnApply += OnItemsApplyCallback;
        }

        public override int GetCount() => ScenarioData.cityLikeCount;

        public override void InitListView()
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("据点名", 80);
            listView.Columns.Add("相邻据点", 300);
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
            if (item.Tag is not CityLike cityLike) return;

            item.SubItems.Clear();
            item.Tag = cityLike;
            item.Text = cityLike.Id.ToString();
            item.SubItems.Add(cityLike.name);
            List<string> neighborNames = AppEnvironment.scenarioData.GetNeighborNames(cityLike);
            item.SubItems.Add(string.Join(", ", neighborNames));
            if (cityLike is City city)
            {
                List<string> adjacentCityNames = AppEnvironment.scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
            }
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            CityLike cityLike = (CityLike)item.Tag;
            editDialog.Init();
            editDialog.Setup(cityLike);
            editDialog.Show(parentForm);
        }

        public override void OnLoaded()
        {
            editDialog.Initialized = false;
        }
    }
}
