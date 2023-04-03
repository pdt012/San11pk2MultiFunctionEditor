using kmfe.core;
using kmfe.core.types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace kmfe.editor.scenarioConfig.helper
{
    internal class CityLikeNeighborHelper : BaseEditorHelper
    {
        public CityLikeNeighborHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void InitListView(ListView listView)
        {
            listView.Columns.Add("ID", 40);
            listView.Columns.Add("据点名", 80);
            listView.Columns.Add("相邻据点", 300);
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
                List<string> neighborNames = scenarioData.GetNeighborNames(city);
                item.SubItems.Add(string.Join(", ", neighborNames));
                List<string> adjacentCityNames = scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
                listView.Items.Add(item);
            }
            foreach (GatePort gatePort in scenarioData.gatePortArray)
            {
                ListViewItem item = new()
                {
                    Tag = gatePort,
                    Text = gatePort.id.ToString()
                };
                item.SubItems.Add(gatePort.name);
                List<string> neighborNames = scenarioData.GetNeighborNames(gatePort);
                item.SubItems.Add(string.Join(", ", neighborNames));
                listView.Items.Add(item);
            }
        }

        public override void UpdateListView(ListView listView, List<int> rows)
        {
            foreach (int id in rows)
            {
                CityLike cityLike = scenarioData.GetCityLike(id);
                ListViewItem item = listView.Items[id];
                item.SubItems.Clear();
                item.Tag = cityLike;
                item.Text = cityLike.id.ToString();
                item.SubItems.Add(cityLike.name);
                List<string> neighborNames = scenarioData.GetNeighborNames(cityLike);
                item.SubItems.Add(string.Join(", ", neighborNames));
                if (cityLike is City city)
                {
                    List<string> adjacentCityNames = scenarioData.GetAdjacentCityNames(city);
                    item.SubItems.Add(string.Join(", ", adjacentCityNames));
                }
            }
        }
    }
}
