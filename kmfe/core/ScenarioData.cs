using kmfe.core.types;
using kmfe.s11.globalScenario;
using kmfe.utils;
using System.Xml.Linq;
using City = kmfe.core.types.City;
using GatePort = kmfe.core.types.GatePort;
using Province = kmfe.core.types.Province;
using Region = kmfe.core.types.Region;

namespace kmfe.core
{
    public class ScenarioData
    {
        public const int cityCount = 42;
        public const int gatePortCount = 45;
        public const int cityLikeCount = cityCount + gatePortCount;
        public const int provinceCount = 12;
        public const int regionCount = 6;

        public readonly City[] cityArray = new City[42];
        public readonly GatePort[] gatePortArray = new GatePort[45];
        public readonly Province[] provinceArray = new Province[12];
        public readonly Region[] regionArray = new Region[6];

        public ScenarioData()
        {
            for (int id = 0; id < cityArray.Length; id++)
                cityArray[id] = new(id);
            for (int id = 0; id < gatePortArray.Length; id++)
                gatePortArray[id] = new(id + cityCount);
            for (int id = 0; id < provinceArray.Length; id++)
                provinceArray[id] = new(id);
            for (int id = 0; id < regionArray.Length; id++)
                regionArray[id] = new(id);
        }

        public void LoadFromGlobalScenario(string scenarioPath)
        {
            byte[] data = new byte[GlobalScenario.Size];
            FileStream fs = new(scenarioPath, FileMode.Open, FileAccess.Read);
            fs.Read(data);
            fs.Close();
            GlobalScenario globalScenario = new();
            globalScenario.FromBytes(data);

            for (int id = 0; id < cityCount; id++)
            {
                s11.globalScenario.City s11City = globalScenario.cityArray[id];
                City city = cityArray[id];
                city.name = CodeConvertHelper.Pk2Str(s11City.name);
                foreach (sbyte adj in s11City.adjacent)
                {
                    if (adj >= 0)
                        city.adjacentCityIdSet.Add(adj);
                }
            }
            for (int id = 0; id < gatePortCount; id++)
            {
                s11.globalScenario.GatePort s11Port = globalScenario.gatePortArray[id];
                GatePort gatePort = gatePortArray[id];
                gatePort.name = CodeConvertHelper.Pk2Str(s11Port.name);
            }
            for (int id = 0; id < provinceCount; id++)
            {
                s11.globalScenario.Province s11Province = globalScenario.provinceArray[id];
                Province province = provinceArray[id];
                province.name = CodeConvertHelper.Pk2Str(s11Province.name);
                province.read = CodeConvertHelper.Pk2Str(s11Province.read);
                province.__12 = CodeConvertHelper.Pk2Str(s11Province.__12);
                province.desc = CodeConvertHelper.Pk2Str(s11Province.desc);
                province.regionId = s11Province.region;
                foreach (sbyte adj in s11Province.adjacent)
                {
                    if (adj >= 0)
                        province.adjacentProvinceIdSet.Add(adj);
                }
            }
            for (int id = 0; id < regionArray.Length; id++)
            {
                s11.globalScenario.Region s11Region = globalScenario.regionArray[id];
                Region region = regionArray[id];
                region.name = CodeConvertHelper.Pk2Str(s11Region.name);
            }
        }

        public void SaveToGlobalScenario(string scenarioPath)
        {
            byte[] data = new byte[GlobalScenario.Size];
            FileStream fs = new(scenarioPath, FileMode.Open, FileAccess.Read);
            fs.Read(data);
            fs.Close();
            GlobalScenario globalScenario = new();
            globalScenario.FromBytes(data);

            for (int id = 0; id < cityCount; id++)
            {
                s11.globalScenario.City s11City = globalScenario.cityArray[id];
                City city = cityArray[id];
                CodeConvertHelper.Str2Pk(city.name, s11City.name);
                city.GetAdjacentArray().CopyTo(s11City.adjacent, 0);
            }
            for (int i = 0; i < gatePortCount; i++)
            {
                s11.globalScenario.GatePort s11GatePort = globalScenario.gatePortArray[i];
                GatePort gatePort = gatePortArray[i];
                CodeConvertHelper.Str2Pk(gatePort.name, s11GatePort.name);
            }
            for (int id = 0; id < provinceCount; id++)
            {
                s11.globalScenario.Province s11Province = globalScenario.provinceArray[id];
                Province province = provinceArray[id];
                CodeConvertHelper.Str2Pk(province.name, s11Province.name);
                CodeConvertHelper.Str2Pk(province.read, s11Province.read);
                //CodeConvertHelper.Str2Pk(province.__12, s11Province.__12);
                CodeConvertHelper.Str2Pk(province.desc, s11Province.desc);
                s11Province.region = (sbyte)province.regionId;
                province.GetAdjacentArray().CopyTo(s11Province.adjacent, 0);
            }
            for (int id = 0; id < regionArray.Length; id++)
            {
                s11.globalScenario.Region s11Region = globalScenario.regionArray[id];
                Region region = regionArray[id];
                CodeConvertHelper.Str2Pk(region.name, s11Region.name);
            }

            globalScenario.ToBytes(ref data);
            FileStream fout = new(scenarioPath, FileMode.Open, FileAccess.Write);
            fout.Write(data);
            fout.Close();
        }

        public CityLike GetCityLike(int id)
        {
            if (id >= 0 && id < cityCount)
            {
                return cityArray[id];
            }
            else if (id >= 0 && id < cityLikeCount)
            {
                return gatePortArray[id - cityCount];
            }
            throw new IndexOutOfRangeException($"Id of CityLike should in range [0-{cityCount + gatePortCount}). Current id is {id}");
        }

        public string[] GetAllCityLikeNames()
        {
            string[] names = new string[cityLikeCount];
            for (int i = 0; i < cityLikeCount; i++)
            {
                names[i] = GetCityLike(i).name;
            }
            return names;
        }

        public string[] GetAllCityNames()
        {
            string[] names = new string[cityCount];
            for (int i = 0; i < cityCount; i++)
            {
                names[i] = cityArray[i].name;
            }
            return names;
        }

        public string[] GetAllGatePortNames()
        {
            string[] names = new string[gatePortCount];
            for (int i = 0; i < cityCount; i++)
            {
                names[i] = gatePortArray[i].name;
            }
            return names;
        }

        public List<string> GetNeighborNames(CityLike cityLike)
        {
            List<string> nameList = new();
            foreach (Neighbor n in cityLike.neighborSet)
            {
                nameList.Add(GetCityLike(n.CityId).name);
            }
            return nameList;
        }

        public List<string> GetAdjacentCityNames(City city)
        {
            List<string> nameList = new();
            foreach (int adj in city.adjacentCityIdSet)
            {
                nameList.Add(cityArray[adj].name);
            }
            return nameList;
        }

        public List<string> GetAdjacentProvinceNames(Province province)
        {
            List<string> nameList = new();
            foreach (int adj in province.adjacentProvinceIdSet)
            {
                nameList.Add(provinceArray[adj].name);
            }
            return nameList;
        }
    }
}
