using kmfe.common;
using kmfe.core.globalTypes;
using kmfe.s11.enums;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    public class PathXmlHelper : BaseXmlHelper
    {
        const string key_neighbor = "neighbor";
        const string attrKey_neighborIndex = "id";
        const string attrKey_neighborBase = "kyoten";
        const string attrKey_neighborRoute = "route";
        const string nodeName_distance = "distance";
        const string nodeName_shortDistance = "short_distance";
        const string nodeName_cityDistance = "city_distance";

        static readonly string[] cityKeys = { "襄平", "北平", "蓟", "南皮", "平原", "晋阳", "邺", "北海", "下邳", "小沛", "寿春", "濮阳", "陈留", "许昌", "汝南", "洛阳", "宛", "长安", "上庸", "安定", "天水", "武威", "建业", "吴", "会稽", "庐江", "柴桑", "江夏", "新野", "襄阳", "江陵", "长沙", "武陵", "桂阳", "零陵", "永安", "汉中", "梓潼", "江州", "成都", "建宁", "云南", "壶关", "虎牢关", "潼关", "函谷关", "武关", "阳平关", "剑阁", "葭萌关", "涪水关", "绵竹关", "安平港", "高唐港", "西河港", "白马港", "昌阳港", "临济港", "海陵港", "江都港", "濡须港", "顿丘港", "官渡港", "孟津港", "解县港", "新丰港", "夏阳港", "房陵港", "芜湖港", "虎林港", "曲阿港", "句章港", "皖口港", "九江港", "陆口港", "鄱阳港", "卢陵港", "夏口港", "湖阳港", "中庐港", "乌林港", "汉津港", "江津港", "罗县港", "洞庭港", "公安港", "巫县港" };
        static readonly Dictionary<string, int> keyToCityIdDict = new();
        static readonly Dictionary<string, RouteType> KeyToRouteDict = new();
        static readonly Dictionary<RouteType, string> RouteToKeyDict = new();

        static PathXmlHelper()
        {
            for (int i = 0; i < cityKeys.Length; i++)
            {
                keyToCityIdDict.Add(cityKeys[i], i);
            }
            foreach (RouteType route in Enum.GetValues<RouteType>())
            {
                KeyToRouteDict.Add(Enum.GetName(route), route);
                RouteToKeyDict.Add(route, Enum.GetName(route));
            }
        }

        static string GetCityKeyName(int cityId)
        {
            return cityKeys[cityId];
        }

        static string GetRouteKeyName(RouteType route)
        {
            return RouteToKeyDict[route];
        }

        public override void Load(string xmlPath)
        {
            #region common
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlElement? rootEle = xmlDoc.DocumentElement;
            #endregion

            XmlNodeList? cityNodeList = rootEle?.ChildNodes;
            if (cityNodeList == null) return;
            foreach (XmlNode cityNode in cityNodeList)
            {
                if (cityNode is not XmlElement) continue;

                try
                {
                    string cityKey = cityNode.Name;
                    int cityId = keyToCityIdDict[cityKey];
                    CityLike cityLike = AppEnvironment.scenarioData.GetCityLike(cityId);
                    // neighbor
                    XmlNodeList? neighborNodeList = cityNode.SelectNodes(key_neighbor);
                    cityLike.neighborSet.Clear();
                    if (neighborNodeList == null) continue;
                    foreach (XmlNode neighborNode in neighborNodeList)
                    {
                        string? neighborCityKey = neighborNode.Attributes?[attrKey_neighborBase]?.Value;
                        if (neighborCityKey == null) continue;
                        string? routeKey = neighborNode.Attributes?[attrKey_neighborRoute]?.Value;
                        if (routeKey == null) continue;
                        int neighborCityId = keyToCityIdDict[neighborCityKey];
                        RouteType route = KeyToRouteDict[routeKey];
                        cityLike.neighborSet.Add(new Neighbor(neighborCityId, route));
                    }
                }
                catch (ArgumentException)
                {
                    throw;
                }
                catch (KeyNotFoundException)
                {
                    throw;
                }
                catch (IndexOutOfRangeException)
                {
                    throw;
                }
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            for (int cityLikeId = 0; cityLikeId < ScenarioData.cityLikeCount; cityLikeId++)
            {
                CityLike cityLike = AppEnvironment.scenarioData.GetCityLike(cityLikeId);
                XmlElement cityEle = xmlDoc.CreateElement(GetCityKeyName(cityLike.Id));
                // neighbor
                int id = 0;
                foreach (Neighbor neighborCity in cityLike.neighborSet)
                {
                    XmlElement neighborEle = xmlDoc.CreateElement(key_neighbor);
                    neighborEle.SetAttribute(attrKey_neighborIndex, id.ToString());
                    neighborEle.SetAttribute(attrKey_neighborBase, GetCityKeyName(neighborCity.CityId));
                    neighborEle.SetAttribute(attrKey_neighborRoute, GetRouteKeyName(neighborCity.Route));
                    neighborEle.SetAttribute("x", "-1");
                    neighborEle.SetAttribute("y", "-1");
                    cityEle.AppendChild(neighborEle);
                    id++;
                }
                for (int i = id; i < 6; i++)  // 彻底覆盖游戏原有的相邻信息
                {
                    Neighbor neighborCity = cityLike.neighborSet.First();
                    XmlElement neighborEle = xmlDoc.CreateElement(key_neighbor);
                    neighborEle.SetAttribute(attrKey_neighborIndex, i.ToString());
                    neighborEle.SetAttribute(attrKey_neighborBase, GetCityKeyName(neighborCity.CityId));
                    neighborEle.SetAttribute(attrKey_neighborRoute, GetRouteKeyName(neighborCity.Route));
                    neighborEle.SetAttribute("x", "-1");
                    neighborEle.SetAttribute("y", "-1");
                    cityEle.AppendChild(neighborEle);
                }
                // distance & short_distance
                XmlElement distanceEle = xmlDoc.CreateElement(nodeName_distance);
                XmlElement shortDistanceEle = xmlDoc.CreateElement(nodeName_shortDistance);
                int[] distance = GetDistance(cityLike);
                for (int i = 0; i < ScenarioData.cityLikeCount; i++)
                {
                    distanceEle.SetAttribute(GetCityKeyName(i), distance[i].ToString());
                    shortDistanceEle.SetAttribute(GetCityKeyName(i), distance[i].ToString());
                }
                cityEle.AppendChild(distanceEle);
                cityEle.AppendChild(shortDistanceEle);
                // city_distance
                if (cityLike is City city)
                {
                    XmlElement cityDistanceEle = xmlDoc.CreateElement(nodeName_cityDistance);
                    int[] cityDistance = GetCityDistance(city);
                    for (int i = 0; i < ScenarioData.cityCount; i++)
                    {
                        cityDistanceEle.SetAttribute(GetCityKeyName(i), cityDistance[i].ToString());
                    }
                    cityEle.AppendChild(cityDistanceEle);
                }
                // unit_distance
                float[] modulus = new float[5] { 4, 4, 4, 3, 5 };
                for (int u = 0; u < 5; u++)
                {
                    XmlElement unitEle = xmlDoc.CreateElement($"unit_distance_{u}");
                    for (int i = 0; i < ScenarioData.cityLikeCount; i++)
                    {
                        int turns = (int)(distance[i] * modulus[u]);
                        unitEle.SetAttribute(GetCityKeyName(i), turns.ToString());
                    }
                    cityEle.AppendChild(unitEle);
                }
                rootEle.AppendChild(cityEle);
            }

            xmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 计算据点距离
        /// </summary>
        public int[] GetDistance(CityLike baseCityLike)
        {
            int[] distance = new int[ScenarioData.cityLikeCount];
            bool[] visited = new bool[ScenarioData.cityLikeCount];  // 已访问节点
            Queue<CityLike> queue = new();
            queue.Enqueue(baseCityLike);
            while (queue.Count > 0)
            {
                CityLike curCityLike = queue.Dequeue();  // 当前节点
                foreach (Neighbor neighbor in curCityLike.neighborSet)  // 当前节点的邻接节点
                {
                    if (!visited[neighbor.CityId])
                    {
                        visited[neighbor.CityId] = true;
                        distance[neighbor.CityId] = distance[curCityLike.Id] + 1;
                        queue.Enqueue(AppEnvironment.scenarioData.GetCityLike(neighbor.CityId));
                    }
                }
            }
            return distance;
        }

        /// <summary>
        /// 计算城市距离
        /// </summary>
        public int[] GetCityDistance(City baseCity)
        {
            int[] cityDistance = new int[ScenarioData.cityCount];
            bool[] visited = new bool[ScenarioData.cityCount];  // 已访问节点
            Queue<City> queue = new();
            queue.Enqueue(baseCity);
            while (queue.Count > 0)
            {
                City curCity = queue.Dequeue();  // 当前节点
                foreach (int adjCityId in curCity.adjacentCityIdSet)  // 当前节点的邻接节点
                {
                    if (!visited[adjCityId])
                    {
                        visited[adjCityId] = true;
                        cityDistance[adjCityId] = cityDistance[curCity.Id] + 1;
                        queue.Enqueue(AppEnvironment.scenarioData.cityArray[adjCityId]);
                    }
                }
            }
            return cityDistance;
        }
    }
}
