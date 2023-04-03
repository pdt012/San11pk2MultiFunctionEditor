using kmfe.core;
using kmfe.core.types;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class CityEditHelper : BaseEditorHelper
    {
        public CityEditHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("名称", 60);
            listView.Columns.Add("相邻城市", 300);
        }

        public override void UpdateListView(ListView listView)
        {
            foreach (City city in scenarioData.cityArray)
            {
                ListViewItem item = new()
                {
                    Tag = city,
                    Text = city.id.ToString()
                };
                item.SubItems.Add(city.name);
                List<string> adjacentCityNames = scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
                listView.Items.Add(item);
            }
        }

        public override void UpdateListView(ListView listView, List<int> rows)
        {
            throw new NotImplementedException();
        }
    }
}
