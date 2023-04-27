using kmfe.core;
using kmfe.core.globalTypes;
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
#if true
            foreach (City city in scenarioData.cityArray)
            {
                ListViewItem item = new()
                {
                    Tag = city,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
            foreach (Town town in scenarioData.townArray)
            {
                ListViewItem item = new()
                {
                    Tag = town,
                };
                UpdateRow(item);
                listView.Items.Add(item);
            }
#else
            foreach (City city in scenarioData.cityArray)
            {
                ListViewItem item = new()
                {
                    Tag = city,
                    Text = city.Id.ToString()
                };
                item.SubItems.Add(city.name);
                List<string> neighborNames = scenarioData.GetNeighborNames(city);
                item.SubItems.Add(string.Join(", ", neighborNames));
                List<string> adjacentCityNames = scenarioData.GetAdjacentCityNames(city);
                item.SubItems.Add(string.Join(", ", adjacentCityNames));
                listView.Items.Add(item);
            }
            foreach (Town town in scenarioData.townArray)
            {
                ListViewItem item = new()
                {
                    Tag = town,
                    Text = town.Id.ToString()
                };
                item.SubItems.Add(town.name);
                List<string> neighborNames = scenarioData.GetNeighborNames(town);
                item.SubItems.Add(string.Join(", ", neighborNames));
                listView.Items.Add(item);
            }
#endif
        }

        public override void UpdateRow(ListViewItem item)
        {
            if (item.Tag is not CityLike cityLike) return;

            item.SubItems.Clear();
            item.Tag = cityLike;
            item.Text = cityLike.Id.ToString();
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
