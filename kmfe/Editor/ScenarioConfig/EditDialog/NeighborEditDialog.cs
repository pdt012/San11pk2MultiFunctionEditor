using kmfe.Core;
using kmfe.Core.GlobalTypes;
using kmfe.Editor.ScenarioConfig.EditDialog;
using kmfe.S11.S11Enums;

namespace kmfe.Editor.ScenarioConfig.EditDialog
{
    public partial class NeighborEditDialog : BaseEditDialog
    {
        public event ApplyHandle? OnApply;

        ComboBox[] neighbors = Array.Empty<ComboBox>();
        ComboBox[] routes = Array.Empty<ComboBox>();
        ComboBox[] adjacentCities = Array.Empty<ComboBox>();

        CityLike? cityLike;

        public NeighborEditDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            neighbors = new ComboBox[] { neighbor0, neighbor1, neighbor2, neighbor3, neighbor4, neighbor5, neighbor6 };
            foreach (ComboBox combo in neighbors)
            {
                combo.Items.Clear();
                combo.Items.AddRange(AppEnvironment.scenarioData.GetAllCityLikeNames());
                combo.Items.Add("--");
            }
            routes = new ComboBox[] { route0, route1, route2, route3, route4, route5, route6 };
            foreach (ComboBox combo in routes)
            {
                combo.Items.Clear();
                combo.Items.AddRange(Enum.GetNames<RouteType>());
            }
            adjacentCities = new ComboBox[] { neiCity0, neiCity1, neiCity2, neiCity3, neiCity4, neiCity5 };
            foreach (ComboBox combo in adjacentCities)
            {
                combo.Items.Clear();
                combo.Items.AddRange(AppEnvironment.scenarioData.GetAllCityNames());
                combo.Items.Add("--");
            }
        }

        public void Setup(CityLike cityLike)
        {
            this.cityLike = cityLike;
            cityName.Text = cityLike.name;
            // 相邻据点
            int count = 0;
            foreach (Neighbor neighbor in cityLike.neighborSet)
            {
                neighbors[count].SelectedIndex = neighbor.CityId;
                routes[count].SelectedIndex = (int)neighbor.Route;
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
                    combo.Visible = true;
                }
                label_adjCity.Visible = true;
            }
            else
            {
                foreach (ComboBox combo in adjacentCities)
                {
                    combo.Visible = false;
                }
                label_adjCity.Visible = false;
            }
        }

        public override bool Apply()
        {
            if (cityLike == null) return false;
            // 读取界面数据
            HashSet<Neighbor> neighborSet = new();
            for (int i = 0; i < CityLike.neighborMax; i++)
            {
                if (neighbors[i].SelectedIndex == neighbors[i].Items.Count - 1)
                    continue;
                neighborSet.Add(new Neighbor(neighbors[i].SelectedIndex, (RouteType)routes[i].SelectedIndex));
            }
            HashSet<int> adjacentCityIdSet = new();
            for (int i = 0; i < City.adjacentCityMax; i++)
            {
                if (adjacentCities[i].SelectedIndex == adjacentCities[i].Items.Count - 1)
                    continue;
                adjacentCityIdSet.Add(adjacentCities[i].SelectedIndex);
            }
            List<int> updatedIdList = new();
            updatedIdList.Add(cityLike.Id);
            // 相邻据点检验
            // 新增的相邻据点
            var neighborAdd = neighborSet.Except(cityLike.neighborSet);
            foreach (Neighbor neighbor in neighborAdd)
            {
                CityLike neighborCityLike = AppEnvironment.scenarioData.GetCityLike(neighbor.CityId);
                // 相邻的据点也添加相邻关系
                if (neighborCityLike.neighborSet.Count < CityLike.neighborMax)
                {
                    neighborCityLike.neighborSet.Add(new Neighbor(cityLike.Id, neighbor.Route));
                    updatedIdList.Add(neighborCityLike.Id);
                }
                else
                {
                    // 如果超过上限，则添加失败
                    AppFormUtils.WarningBox($"[{neighborCityLike.name}]相邻据点超出上限,修改失败!", "错误");
                    DialogResult = DialogResult.Cancel;
                    return false;
                }
            }
            // 去除的相邻据点
            var neighborRemove = cityLike.neighborSet.Except(neighborSet);
            foreach (Neighbor neighbor in neighborRemove)
            {
                // 相邻关系被取消，则该相邻据点也取消相邻关系
                CityLike neighborCityLike = AppEnvironment.scenarioData.GetCityLike(neighbor.CityId);
                neighborCityLike.neighborSet.Remove(new Neighbor(cityLike.Id, neighbor.Route));
                updatedIdList.Add(neighborCityLike.Id);
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
                    City adjCity = AppEnvironment.scenarioData.cityArray[cityId];
                    // 相邻的城市也添加相邻关系
                    if (adjCity.adjacentCityIdSet.Count < City.adjacentCityMax)
                    {
                        adjCity.adjacentCityIdSet.Add(city.Id);
                        updatedIdList.Add(cityId);
                    }
                    else
                    {
                        // 如果超过上限，则添加失败
                        AppFormUtils.WarningBox($"[{adjCity.name}]相邻城市超出上限,修改失败!", "修改失败");
                        DialogResult = DialogResult.Cancel;
                        return false;
                    }

                }
                // 去除的相邻城市
                var adjacentCityRemove = city.adjacentCityIdSet.Except(adjacentCityIdSet);
                foreach (int cityId in adjacentCityRemove)
                {
                    // 相邻关系被取消，则该相邻城市也取消相邻关系
                    City adjCity = AppEnvironment.scenarioData.cityArray[cityId];
                    adjCity.adjacentCityIdSet.Remove(city.Id);
                    updatedIdList.Add(cityId);
                }
                // 保存
                city.adjacentCityIdSet = adjacentCityIdSet;
            }

            OnApply?.Invoke(updatedIdList);
            return true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
