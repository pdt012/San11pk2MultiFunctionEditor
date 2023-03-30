using kmfe.core;
using kmfe.core.types;

namespace kmfe.editor
{
    public partial class CityLikeNeighborEdit : Form
    {
        ComboBox[] neighbors = Array.Empty<ComboBox>();
        ComboBox[] routes = Array.Empty<ComboBox>();
        ComboBox[] adjacentCities = Array.Empty<ComboBox>();

        ScenarioData? scenarioData;

        public CityLikeNeighborEdit()
        {
            InitializeComponent();
        }

        public void Init(ScenarioData scenarioData)
        {
            this.scenarioData = scenarioData;

            neighbors = new ComboBox[] { neighbor0, neighbor1, neighbor2, neighbor3, neighbor4, neighbor5, neighbor6 };
            foreach (ComboBox combo in neighbors)
            {
                combo.Items.Clear();
                combo.Items.AddRange(scenarioData.GetAllCityLikeNames());
                combo.Items.Add("--");
            }
            routes = new ComboBox[] { route0, route1, route2, route3, route4, route5, route6 };
            foreach (ComboBox combo in routes)
            {
                combo.Items.Clear();
                combo.Items.AddRange(PathXmlHelper.GetAllRouteNames());
            }
            adjacentCities = new ComboBox[] { neiCity0, neiCity1, neiCity2, neiCity3, neiCity4, neiCity5 };
            foreach (ComboBox combo in adjacentCities)
            {
                combo.Items.Clear();
                combo.Items.AddRange(scenarioData.GetAllCityNames());
                combo.Items.Add("--");
            }
        }

        public void Setup(CityLike cityLike)
        {
            cityName.Text = cityLike.name;
            // 相邻据点
            int count = 0;
            foreach (Neighbor neighbor in cityLike.neighborSet)
            {
                neighbors[count].SelectedIndex = neighbor.CityId;
                routes[count].SelectedIndex = neighbor.Route;
                count++;
            }
            for (int i = count; i < CityLike.neighborMax; i++)  // 其余设为空
            {
                neighbors[i].SelectedIndex = neighbors[i].Items.Count - 1;  // 最后一项
                routes[i].SelectedIndex = 0;
            }
            // 相邻城市
            if (cityLike is City city)
            {
                count = 0;
                foreach (int adjacentCityId in city.adjacentCityIdSet)
                {
                    adjacentCities[count].SelectedIndex = adjacentCityId;
                    count++;
                }
                for (int i = count; i < City.adjacentCityMax; i++)  // 其余设为空
                {
                    adjacentCities[i].SelectedIndex = adjacentCities[i].Items.Count - 1;  // 最后一项
                }
                foreach (ComboBox combo in adjacentCities)
                {
                    combo.Enabled = true;
                }
            }
            else
            {
                foreach (ComboBox combo in adjacentCities)
                {
                    combo.Enabled = false;
                }
            }
        }

        public void Save(CityLike cityLike)
        {
            if (scenarioData == null) return;
            // 读取界面数据
            HashSet<Neighbor> neighborSet = new();
            for (int i = 0; i < CityLike.neighborMax; i++)
            {
                if (neighbors[i].SelectedIndex == neighbors[i].Items.Count - 1)
                    continue;
                neighborSet.Add(new Neighbor(neighbors[i].SelectedIndex, routes[i].SelectedIndex));
            }
            HashSet<int> adjacentCityIdSet = new();
            for (int i = 0; i < City.adjacentCityMax; i++)
            {
                if (adjacentCities[i].SelectedIndex == adjacentCities[i].Items.Count - 1)
                    continue;
                adjacentCityIdSet.Add(adjacentCities[i].SelectedIndex);
            }
            // 相邻据点检验
            // 新增的相邻据点
            var neighborAdd = neighborSet.Except(cityLike.neighborSet);
            foreach (Neighbor neighbor in neighborAdd)
            {
                CityLike neighborCityLike = scenarioData.GetCityLike(neighbor.CityId);
                // 相邻的据点也添加相邻关系
                if (neighborCityLike.neighborSet.Count < CityLike.neighborMax)
                {
                    neighborCityLike.neighborSet.Add(new Neighbor(cityLike.id, neighbor.Route));
                }
                else
                {
                    // 如果超过上限，则添加失败
                    MessageBox.Show($"[{neighborCityLike.name}]相邻据点超出上限,修改失败!", "错误");
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            // 去除的相邻据点
            var neighborRemove = cityLike.neighborSet.Except(neighborSet);
            foreach (Neighbor neighbor in neighborRemove)
            {
                // 相邻关系被取消，则该相邻据点也取消相邻关系
                CityLike neighborCityLike = scenarioData.GetCityLike(neighbor.CityId);
                neighborCityLike.neighborSet.Remove(new Neighbor(cityLike.id, neighbor.Route));
            }
            // 保存
            cityLike.neighborSet = neighborSet;

            // 相邻城市检验
            if (cityLike is City city)
            {
                // 新增的相邻城市
                var adjacentCityAdd = adjacentCityIdSet.Except(city.adjacentCityIdSet);
                foreach (int cityId in adjacentCityAdd)
                {
                    City adjCity = scenarioData.cityArray[cityId];
                    // 相邻的城市也添加相邻关系
                    if (adjCity.adjacentCityIdSet.Count < City.adjacentCityMax)
                    {
                        adjCity.adjacentCityIdSet.Add(city.id);
                    }
                    else
                    {
                        // 如果超过上限，则添加失败
                        MessageBox.Show($"[{adjCity.name}]相邻城市超出上限,修改失败!", "错误");
                        DialogResult = DialogResult.Cancel;
                        return;
                    }

                }
                // 去除的相邻城市
                var adjacentCityRemove = city.adjacentCityIdSet.Except(adjacentCityIdSet);
                foreach (int cityId in adjacentCityRemove)
                {
                    // 相邻关系被取消，则该相邻城市也取消相邻关系
                    City adjCity = scenarioData.cityArray[cityId];
                    adjCity.adjacentCityIdSet.Remove(city.id);
                }
                // 保存
                city.adjacentCityIdSet = adjacentCityIdSet;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
