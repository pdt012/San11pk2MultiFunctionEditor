using kmfe.core.globalTypes;
using kmfe.s11.enums;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    internal class RankXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "rank";
        const string nodeName_name = "name";
        const string nodeName_command = "command";
        const string nodeName_stat_type = "stat";
        const string nodeName_stat_increase = "inc";
        const string nodeName_salary = "pay";
        const string nodeName_rank_level = "level";
        const string nodeName_merit = "kouseki";
        const string attrKey_value = "value";

        public RankXmlHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void Load(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlElement? rootEle = xmlDoc.DocumentElement;

            XmlNodeList? mainNodeList = rootEle?.SelectNodes(mainNodeName);
            if (mainNodeList == null) return;
            foreach (XmlNode mainNode in mainNodeList)
            {
                if (mainNode is not XmlElement) continue;
                string? str_id = mainNode.Attributes?["id"]?.Value;
                if (str_id == null) continue;
                int id = int.Parse(str_id);

                #region LoadById
                Rank rank = scenarioData.rankArray[id];

                /*string? name = mainNode.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    rank.name = name;

                string? command = mainNode.SelectSingleNode(nodeName_command)?.Attributes?[attrKey_value]?.Value;
                if (command != null)
                    rank.command = int.Parse(command);

                string? statType = mainNode.SelectSingleNode(nodeName_stat_type)?.Attributes?[attrKey_value]?.Value;
                if (statType != null)
                    rank.statType = (StatType)int.Parse(statType);

                string? statIncrease = mainNode.SelectSingleNode(nodeName_stat_increase)?.Attributes?[attrKey_value]?.Value;
                if (statIncrease != null)
                    rank.statIncrease = int.Parse(statIncrease);

                string? salary = mainNode.SelectSingleNode(nodeName_salary)?.Attributes?[attrKey_value]?.Value;
                if (salary != null)
                    rank.salary = int.Parse(salary);

                string? rankLevel = mainNode.SelectSingleNode(nodeName_rank_level)?.Attributes?[attrKey_value]?.Value;
                if (rankLevel != null)
                    rank.rankLevel = int.Parse(rankLevel);*/

                string? merit = mainNode.SelectSingleNode(nodeName_merit)?.Attributes?[attrKey_value]?.Value;
                if (merit != null)
                    rank.merit = int.Parse(merit);
                #endregion
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            XmlElement nodeElement;
            XmlElement ele;
            foreach (Rank rank in scenarioData.rankArray)
            {
                nodeElement = xmlDoc.CreateElement(mainNodeName);
                nodeElement.SetAttribute("id", rank.Id.ToString());

                /*ele = xmlDoc.CreateElement(nodeName_name);
                ele.SetAttribute(attrKey_value, rank.name);
                nodeElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_command);
                ele.SetAttribute(attrKey_value, rank.command.ToString());
                nodeElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_stat_type);
                ele.SetAttribute(attrKey_value, Enum.GetName(rank.statType));
                nodeElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_stat_increase);
                ele.SetAttribute(attrKey_value, rank.statIncrease.ToString());
                nodeElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_salary);
                ele.SetAttribute(attrKey_value, rank.salary.ToString());
                nodeElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_rank_level);
                ele.SetAttribute(attrKey_value, rank.rankLevel.ToString());
                nodeElement.AppendChild(ele);*/

                ele = xmlDoc.CreateElement(nodeName_merit);
                ele.SetAttribute(attrKey_value, rank.merit.ToString());
                nodeElement.AppendChild(ele);

                rootEle.AppendChild(nodeElement);
            }

            xmlDoc.Save(xmlPath);
        }
    }
}
