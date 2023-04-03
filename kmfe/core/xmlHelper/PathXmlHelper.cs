using kmfe.core.types;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    public class PathXmlHelper
    {
        const string key_neighbor = "neighbor";
        const string attrKey_neighbor_city = "kyoten";
        const string attrKey_neighbor_route = "route";
        const string attrKey_neighbor_id = "id";
        const string key_distance = "distance";
        const string key_shortDistance = "short_distance";
        const string key_cityDistance = "city_distance";

        static readonly string[] cityKeys = { "襄平", "北平", "蓟", "南皮", "平原", "晋阳", "邺", "北海", "下邳", "小沛", "寿春", "濮阳", "陈留", "许昌", "汝南", "洛阳", "宛", "长安", "上庸", "安定", "天水", "武威", "建业", "吴", "会稽", "庐江", "柴桑", "江夏", "新野", "襄阳", "江陵", "长沙", "武陵", "桂阳", "零陵", "永安", "汉中", "梓潼", "江州", "成都", "建宁", "云南", "壶关", "虎牢关", "潼关", "函谷关", "武关", "阳平关", "剑阁", "葭萌关", "涪水关", "绵竹关", "安平港", "高唐港", "西河港", "白马港", "昌阳港", "临济港", "海陵港", "江都港", "濡须港", "顿丘港", "官渡港", "孟津港", "解县港", "新丰港", "夏阳港", "房陵港", "芜湖港", "虎林港", "曲阿港", "句章港", "皖口港", "九江港", "陆口港", "鄱阳港", "卢陵港", "夏口港", "湖阳港", "中庐港", "乌林港", "汉津港", "江津港", "罗县港", "洞庭港", "公安港", "巫县港" };
        static readonly string[] routeKeys = { "一般", "海洋", "栈道", "毒泉" };
        static readonly Dictionary<string, int> keyToCityIdDict = new();
        static readonly Dictionary<string, int> KeyToRouteDict = new();

        ScenarioData scenarioData;

        static PathXmlHelper()
        {
            for (int i = 0; i < cityKeys.Length; i++)
            {
                keyToCityIdDict.Add(cityKeys[i], i);
            }
            for (int i = 0; i < routeKeys.Length; i++)
            {
                KeyToRouteDict.Add(routeKeys[i], i);
            }
        }

        public PathXmlHelper(ScenarioData scenarioData)
        {
            this.scenarioData = scenarioData;
        }

        public static string[] GetAllRouteNames()
        {
            return routeKeys;
        }

        public static string GetCityKeyName(int cityId)
        {
            return cityKeys[cityId];
        }

        public static string GetRouteKeyName(int route)
        {
            return routeKeys[route];
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
                        distance[neighbor.CityId] = distance[curCityLike.id] + 1;
                        queue.Enqueue(scenarioData.GetCityLike(neighbor.CityId));
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
                        cityDistance[adjCityId] = cityDistance[curCity.id] + 1;
                        queue.Enqueue(scenarioData.cityArray[adjCityId]);
                    }
                }
            }
            return cityDistance;
        }

        public void Load(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlNodeList cityNodeList = xmlDoc.DocumentElement.ChildNodes;
            foreach (XmlNode cityNode in cityNodeList)
            {
                if (cityNode is not XmlElement)  // 过滤注释
                    continue;
                XmlElement cityElement = (XmlElement)cityNode;
                try
                {
                    string cityKey = cityElement.Name;
                    int cityId = keyToCityIdDict[cityKey];
                    CityLike cityLike = scenarioData.GetCityLike(cityId);
                    // neighbor
                    XmlNodeList neighborNodeList = cityElement.SelectNodes(key_neighbor);
                    cityLike.neighborSet.Clear();
                    foreach (XmlNode neighborNode in neighborNodeList)
                    {
                        string neighborCityKey = neighborNode.Attributes[attrKey_neighbor_city].Value.ToString();
                        string routeKey = neighborNode.Attributes[attrKey_neighbor_route].Value.ToString();
                        int neighborCityId = keyToCityIdDict[neighborCityKey];
                        int route = KeyToRouteDict[routeKey];
                        cityLike.neighborSet.Add(new Neighbor(neighborCityId, route));
                    }
                }
                catch (KeyNotFoundException e)
                {
                    throw;
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }
            }
        }

        public void Save(string xmlPath)
        {
            // 生成xml
            XmlDocument xmlDoc = new();
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDec);
            XmlElement rootEle = xmlDoc.CreateElement("pk");
            rootEle.SetAttribute("trace", "false");
            rootEle.SetAttribute("utf8", "true");

            rootEle.AppendChild(xmlDoc.CreateComment("AUTHOR: keehl102"));
            rootEle.AppendChild(xmlDoc.CreateComment("TOOL: pathEditor(氕氘氚)"));
            rootEle.AppendChild(xmlDoc.CreateComment($"CREATETIME: {DateTime.Now.ToString()}"));

            for (int cityLikeId = 0; cityLikeId < ScenarioData.cityLikeCount; cityLikeId++)
            {
                CityLike cityLike = scenarioData.GetCityLike(cityLikeId);
                XmlElement cityEle = xmlDoc.CreateElement(GetCityKeyName(cityLike.id));
                // neighbor
                int id = 0;
                foreach (Neighbor neighborCity in cityLike.neighborSet)
                {
                    XmlElement neighborEle = xmlDoc.CreateElement(key_neighbor);
                    neighborEle.SetAttribute(attrKey_neighbor_id, id.ToString());
                    neighborEle.SetAttribute(attrKey_neighbor_city, GetCityKeyName(neighborCity.CityId));
                    neighborEle.SetAttribute(attrKey_neighbor_route, GetRouteKeyName(neighborCity.Route));
                    neighborEle.SetAttribute("x", "-1");
                    neighborEle.SetAttribute("y", "-1");
                    cityEle.AppendChild(neighborEle);
                    id++;
                }
                for (int i = id; i < 6; i++)  // 彻底覆盖游戏原有的相邻信息
                {
                    Neighbor neighborCity = cityLike.neighborSet.First();
                    XmlElement neighborEle = xmlDoc.CreateElement(key_neighbor);
                    neighborEle.SetAttribute(attrKey_neighbor_id, i.ToString());
                    neighborEle.SetAttribute(attrKey_neighbor_city, GetCityKeyName(neighborCity.CityId));
                    neighborEle.SetAttribute(attrKey_neighbor_route, GetRouteKeyName(neighborCity.Route));
                    neighborEle.SetAttribute("x", "-1");
                    neighborEle.SetAttribute("y", "-1");
                    cityEle.AppendChild(neighborEle);
                }
                // distance & short_distance
                XmlElement distanceEle = xmlDoc.CreateElement(key_distance);
                XmlElement shortDistanceEle = xmlDoc.CreateElement(key_shortDistance);
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
                    XmlElement cityDistanceEle = xmlDoc.CreateElement(key_cityDistance);
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

            xmlDoc.AppendChild(rootEle);
            xmlDoc.Save(xmlPath);
        }
    }
}
