using kmfe.core.globalTypes;
using kmfe.s11.enums;
using kmfe.utils;
using Region = kmfe.core.globalTypes.Region;

namespace kmfe.core
{
    public class ScenarioData
    {
        public const int cityCount = 42;
        public const int townCount = 45;
        public const int cityLikeCount = cityCount + townCount;
        public const int provinceCount = 12;
        public const int regionCount = 6;
        public const int facilityCount = 64;
        public const int weaponCount = 12;
        public const int titleCount = 10;
        public const int rankCount = 81;
        public const int skillCount = 2000;
        public const int techCount = 36;
        public const int tacticCount = 32;
        public const int terrainCount = 32;
        public const int familyCount = 400;
        public const int abilityCount = 98;
        public const int armyLevelCount = 14;

        public const int skillBasicBegin = 0;
        public const int skillBasicEnd = 1000;
        public const int skillCustomizeBegin = 1000;
        public const int skillCustomizeEnd = 2000;

        public readonly City[] cityArray = new City[42];
        public readonly Town[] townArray = new Town[45];
        public readonly Province[] provinceArray = new Province[12];
        public readonly Region[] regionArray = new Region[6];
        /*public readonly Facility[] facilityArray = new Facility[64];
        public readonly Weapon[] weaponArray = new Weapon[12];*/
        public readonly Title[] titleArray = new Title[10];
        public readonly Rank[] rankArray = new Rank[81];
        public readonly Skill[] skillArray = new Skill[skillCount];
        /*public readonly Technology[] techArray = new Technology[36];
        public readonly Tactic[] tacticArray = new Tactic[32];
        public readonly Terrain[] terrainArray = new Terrain[32];
        public readonly Family[] familyArray = new Family[400];
        public readonly Ability[] abilityArray = new Ability[98];*/
        public readonly ArmyLevel[] armyLevelArray = new ArmyLevel[armyLevelCount];

        public ScenarioData()
        {
            for (int id = 0; id < cityArray.Length; id++)
                cityArray[id] = new(id);
            for (int id = 0; id < townArray.Length; id++)
                townArray[id] = new(id + cityCount);
            for (int id = 0; id < provinceArray.Length; id++)
                provinceArray[id] = new(id);
            for (int id = 0; id < regionArray.Length; id++)
                regionArray[id] = new(id);
            /*for (int id = 0; id < facilityArray.Length; id++)
                facilityArray[id] = new();
            for (int id = 0; id < weaponArray.Length; id++)
                weaponArray[id] = new();*/
            for (int id = 0; id < titleArray.Length; id++)
                titleArray[id] = new(id);
            for (int id = 0; id < rankArray.Length; id++)
                rankArray[id] = new(id);
            for (int id = 0; id < skillArray.Length; id++)
                skillArray[id] = new(id);
            /*for (int id = 0; id < techArray.Length; id++)
                techArray[id] = new();
            for (int id = 0; id < tacticArray.Length; id++)
                tacticArray[id] = new();
            for (int id = 0; id < terrainArray.Length; id++)
                terrainArray[id] = new();
            for (int id = 0; id < familyArray.Length; id++)
                familyArray[id] = new();
            for (int id = 0; id < abilityArray.Length; id++)
                abilityArray[id] = new();*/
            for (int id = 0; id < armyLevelArray.Length; id++)
                armyLevelArray[id] = new(id);
        }

        public void LoadFromGlobalScenario(string scenarioPath)
        {
            byte[] data = new byte[s11.globalScenario.GlobalScenario.Size];
            FileStream fs = new(scenarioPath, FileMode.Open, FileAccess.Read);
            fs.Read(data);
            fs.Close();
            s11.globalScenario.GlobalScenario globalScenario = new();
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
            for (int id = 0; id < townCount; id++)
            {
                s11.globalScenario.GatePort s11Port = globalScenario.gatePortArray[id];
                Town town = townArray[id];
                town.name = CodeConvertHelper.Pk2Str(s11Port.name);
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
            for (int id = 0; id < titleArray.Length; id++)
            {
                s11.globalScenario.Title s11Title = globalScenario.titleArray[id];
                Title title = titleArray[id];
                title.name = CodeConvertHelper.Pk2Str(s11Title.name);
                title.command = s11Title.command;
            }
            for (int id = 0;id < rankArray.Length; id++)
            {
                s11.globalScenario.Rank s11Rank = globalScenario.rankArray[id];
                Rank rank = rankArray[id];
                rank.name = CodeConvertHelper.Pk2Str(s11Rank.name);
                rank.command = s11Rank.command;
                rank.statType = (StatType)s11Rank.stat;
                rank.statIncrease = s11Rank.increase;
                rank.salary = s11Rank.salary;
                rank.rankLevel = s11Rank.rank;
            }
        }

        public void SaveToGlobalScenario(string scenarioPath)
        {
            byte[] data = new byte[s11.globalScenario.GlobalScenario.Size];
            FileStream fs = new(scenarioPath, FileMode.Open, FileAccess.Read);
            fs.Read(data);
            fs.Close();
            s11.globalScenario.GlobalScenario globalScenario = new();
            globalScenario.FromBytes(data);

            for (int id = 0; id < cityCount; id++)
            {
                s11.globalScenario.City s11City = globalScenario.cityArray[id];
                City city = cityArray[id];
                CodeConvertHelper.Str2Pk(city.name, s11City.name);
                city.GetAdjacentArray().CopyTo(s11City.adjacent, 0);
            }
            for (int i = 0; i < townCount; i++)
            {
                s11.globalScenario.GatePort s11GatePort = globalScenario.gatePortArray[i];
                Town town = townArray[i];
                CodeConvertHelper.Str2Pk(town.name, s11GatePort.name);
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
                return townArray[id - cityCount];
            }
            throw new IndexOutOfRangeException($"Id of CityLike should in range [0-{cityCount + townCount}). Current id is {id}");
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

        public string[] GetAllTownNames()
        {
            string[] names = new string[townCount];
            for (int i = 0; i < cityCount; i++)
            {
                names[i] = townArray[i].name;
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
