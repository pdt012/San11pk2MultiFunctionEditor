using kmfe.core.globalTypes;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    internal class ArmyLevelXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "tekisei";
        const string nodeName_name = "name";
        const string nodeName_exp = "exp";
        const string nodeName_tactics_chance = "tactics_chance";
        const string nodeName_stat_ratio = "unit_stat";
        const string attrKey_value = "value";

        public override void Load(string xmlPath)
        {
            #region common
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlElement? rootEle = xmlDoc.DocumentElement;
            #endregion

            XmlNodeList? mainNodeList = rootEle?.SelectNodes(mainNodeName);
            if (mainNodeList == null) return;
            foreach (XmlNode mainNode in mainNodeList)
            {
                if (mainNode is not XmlElement) continue;

                string? str_id = mainNode.Attributes?["id"]?.Value;
                if (str_id == null) continue;
                int id = int.Parse(str_id);

                #region LoadById
                ArmyLevel armyLevel = AppEnvironment.scenarioData.armyLevelArray[id];

                string? name = mainNode.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    armyLevel.name = name;

                string? exp = mainNode.SelectSingleNode(nodeName_exp)?.Attributes?[attrKey_value]?.Value;
                if (exp != null)
                    armyLevel.exp = int.Parse(exp);

                string? tactics_chance = mainNode.SelectSingleNode(nodeName_tactics_chance)?.Attributes?[attrKey_value]?.Value;
                if (tactics_chance != null)
                    armyLevel.tacticsChanceBuff = int.Parse(tactics_chance);

                string? stat_ratio = mainNode.SelectSingleNode(nodeName_stat_ratio)?.Attributes?[attrKey_value]?.Value;
                if (stat_ratio != null)
                    armyLevel.unitStatRatio = float.Parse(stat_ratio);
                #endregion
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            XmlElement mainElement;
            XmlElement ele;
            foreach (ArmyLevel armyLevel in AppEnvironment.scenarioData.armyLevelArray)
            {
                mainElement = xmlDoc.CreateElement(mainNodeName);
                mainElement.SetAttribute("id", armyLevel.Id.ToString());

                ele = xmlDoc.CreateElement(nodeName_name);
                ele.SetAttribute(attrKey_value, armyLevel.name);
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_exp);
                ele.SetAttribute(attrKey_value, armyLevel.exp.ToString());
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_tactics_chance);
                ele.SetAttribute(attrKey_value, armyLevel.tacticsChanceBuff.ToString());
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_stat_ratio);
                ele.SetAttribute(attrKey_value, armyLevel.unitStatRatio.ToString("f2"));
                mainElement.AppendChild(ele);

                rootEle.AppendChild(mainElement);
            }

            xmlDoc.Save(xmlPath);
        }
    }
}
