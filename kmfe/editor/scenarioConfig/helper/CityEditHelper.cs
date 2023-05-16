using kmfe.core;
using kmfe.core.globalTypes;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class CityEditHelper : BaseEditorHelper
    {
        public CityEditHelper(ListView listView) : base(listView)
        {
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
                    Text = city.Id.ToString()
                };
                item.SubItems.Add(city.name);
                List<string> adjacentCityNames = AppEnvironment.scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
                listView.Items.Add(item);
            }
        }

        public override void UpdateRow(ListViewItem item)
        {
            throw new NotImplementedException();
        }

        public override void OnDoubleClicked(Form parentForm, ListViewItem item)
        {
            ;
        }

        public override void OnRightClicked(Form parentForm, ListViewItem item)
        {
            ;
        }

        public override void OnLoaded()
        {
            ;
        }

        public override void OnSaved()
        {
            ;
        }
    }
}
