using kmfe.core.globalTypes;
using kmfe.s11.globalScenario;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    public class ArmyLevelXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "tekisei";
        const string nodeName_name = "name";
        const string nodeName_exp = "exp";
        const string nodeName_tactics_chance = "tactics_chance";
        const string nodeName_stat_ratio = "unit_stat";
        const string attrKey_value = "value";

        public ArmyLevelXmlHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void Load(string xmlPath)
        {
            #region common
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlElement? rootEle = xmlDoc.DocumentElement;
            #endregion

            XmlNodeList? levelNodeList = rootEle?.SelectNodes(mainNodeName);
            if (levelNodeList == null) return;
            foreach (XmlNode levelNode in levelNodeList)
            {
                if (levelNode is not XmlElement) continue;

                string? str_id = levelNode.Attributes?["id"]?.Value;
                if (str_id == null) continue;
                int id = int.Parse(str_id);
                ArmyLevel armyLevel = scenarioData.armyLevelArray[id];

                string? name = levelNode.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    armyLevel.name = name;

                string? exp = levelNode.SelectSingleNode(nodeName_exp)?.Attributes?[attrKey_value]?.Value;
                if (exp != null)
                    armyLevel.exp = int.Parse(exp);

                string? tactics_chance = levelNode.SelectSingleNode(nodeName_tactics_chance)?.Attributes?[attrKey_value]?.Value;
                if (tactics_chance != null)
                    armyLevel.tacticsChanceBuff = int.Parse(tactics_chance);

                string? stat_ratio = levelNode.SelectSingleNode(nodeName_stat_ratio)?.Attributes?[attrKey_value]?.Value;
                if (stat_ratio != null)
                    armyLevel.unitStatRatio = float.Parse(stat_ratio);
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            foreach (ArmyLevel armyLevel in scenarioData.armyLevelArray)
            {
                XmlElement armyLevelEle = xmlDoc.CreateElement(mainNodeName);
                armyLevelEle.SetAttribute("id", armyLevel.Id.ToString());

                XmlElement nameEle = xmlDoc.CreateElement(nodeName_name);
                nameEle.SetAttribute(attrKey_value, armyLevel.name);
                armyLevelEle.AppendChild(nameEle);

                XmlElement expEle = xmlDoc.CreateElement(nodeName_exp);
                expEle.SetAttribute(attrKey_value, armyLevel.exp.ToString());
                armyLevelEle.AppendChild(expEle);

                XmlElement tacticsChanceEle = xmlDoc.CreateElement(nodeName_tactics_chance);
                tacticsChanceEle.SetAttribute(attrKey_value, armyLevel.tacticsChanceBuff.ToString());
                armyLevelEle.AppendChild(tacticsChanceEle);

                XmlElement statRatioEle = xmlDoc.CreateElement(nodeName_stat_ratio);
                statRatioEle.SetAttribute(attrKey_value, armyLevel.unitStatRatio.ToString("f2"));
                armyLevelEle.AppendChild(statRatioEle);

                rootEle.AppendChild(armyLevelEle);
            }

            xmlDoc.Save(xmlPath);
        }
    }
}
