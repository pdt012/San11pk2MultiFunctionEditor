using kmfe.Common;
using kmfe.Core.XmlHelper;

namespace kmfe.Core
{
    internal static class AppEnvironment
    {
        public static readonly ScenarioData scenarioData = new();

        public static readonly Dictionary<DataXmlName, string> xmlFileNameDict = new()
        {
            { DataXmlName.path, "01 path.xml" },
            { DataXmlName.armyLevel, "07 tekisei.xml" },
            { DataXmlName.title, "11 title.xml" },
            { DataXmlName.rank, "12 rank.xml" },
            { DataXmlName.skill, "19 skill.xml" },
        };

        public static readonly Dictionary<DataXmlName, BaseXmlHelper> xmlHelperDict = new()
        {
            { DataXmlName.path, new PathXmlHelper() },
            { DataXmlName.armyLevel, new ArmyLevelXmlHelper() },
            { DataXmlName.title, new TitleXmlHelper() },
            { DataXmlName.rank, new RankXmlHelper() },
            { DataXmlName.skill, new SkillXmlHelper() },
        };

        public static string GetGlobalScenarioPath()
        {
            return Path.Combine(Settings.PkPath, "Media/scenario/scenario.s11");
        }

        public static string GetDataXmlPath(DataXmlName dataXmlName)
        {
            return Path.Combine(Settings.Pk2Path, "data", xmlFileNameDict[dataXmlName]);
        }

    }
}
