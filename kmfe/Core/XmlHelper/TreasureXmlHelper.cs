using kmfe.Core.GlobalTypes;
using kmfe.S11.S11Enums;
using System.Xml;

namespace kmfe.Core.XmlHelper
{
    internal class TreasureXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "item";
        const string nodeName_name = "name";
        const string nodeName_read = "name_read";
        const string nodeName_history = "history";
        const string nodeName_type = "type";
        const string nodeName_worth = "value";
        const string nodeName_skillId = "skill_id";
        const string nodeName_statBuff = "stat";
        const string nodeName_model = "model";
        const string attrKey_value = "value";

        public override void Load(string xmlPath)
        {
            #region common
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlElement? rootEle = xmlDoc.DocumentElement;
            #endregion

            XmlNodeList? nodeList = rootEle?.SelectNodes(mainNodeName);
            if (nodeList == null) return;

            // 先重置
            foreach (Treasure treasure in AppEnvironment.scenarioData.treasureArray)
            {
                treasure.Reset();
            }

            foreach (XmlNode node in nodeList)
            {
                if (node is not XmlElement) continue;

                string? str_id = node.Attributes?["id"]?.Value;
                if (str_id == null) continue;
                int id = int.Parse(str_id);

                #region LoadById
                Treasure treasure = AppEnvironment.scenarioData.treasureArray[id];

                string? name = node.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    treasure.name = name;

                string? read = node.SelectSingleNode(nodeName_read)?.Attributes?[attrKey_value]?.Value;
                if (read != null)
                    treasure.read = read;

                string? history = node.SelectSingleNode(nodeName_history)?.Attributes?[attrKey_value]?.Value;
                if (history != null)
                    treasure.history = history;

                string? type = node.SelectSingleNode(nodeName_type)?.Attributes?[attrKey_value]?.Value;
                if (type != null && type.Length > 0)
                    treasure.type = (TreasureType)int.Parse(type);

                string? worth = node.SelectSingleNode(nodeName_worth)?.Attributes?[attrKey_value]?.Value;
                if (worth != null && worth.Length > 0)
                    treasure.worth = int.Parse(worth);

                string? bindSkillId = node.SelectSingleNode(nodeName_skillId)?.Attributes?[attrKey_value]?.Value;
                if (bindSkillId != null && bindSkillId.Length > 0)
                        treasure.bindSkillId = int.Parse(bindSkillId);

                // 能力加成
                XmlNode? stat_node = node.SelectSingleNode(nodeName_statBuff);
                if (stat_node != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        string? stat = stat_node.Attributes?[Enum.GetName((StatType)i)]?.Value;
                        if (stat != null && stat.Length > 0)
                            treasure.statBuff[i] = (int.Parse(stat));
                    }
                }
                #endregion
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            XmlElement mainElement;
            XmlElement ele;
            foreach (Treasure treasure in AppEnvironment.scenarioData.treasureArray)
            {
                if (!treasure.IsValid()) continue;

                mainElement = xmlDoc.CreateElement(mainNodeName);
                mainElement.SetAttribute("id", treasure.Id.ToString());

                ele = xmlDoc.CreateElement(nodeName_name);
                ele.SetAttribute(attrKey_value, treasure.name);
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_read);
                ele.SetAttribute(attrKey_value, treasure.read);
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_history);
                ele.SetAttribute(attrKey_value, treasure.history);
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_type);
                ele.SetAttribute(attrKey_value, ((int)treasure.type).ToString());
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_worth);
                ele.SetAttribute(attrKey_value, treasure.worth.ToString());
                mainElement.AppendChild(ele);

                if (treasure.bindSkillId >= 0)
                {
                    ele = xmlDoc.CreateElement(nodeName_skillId);
                    ele.SetAttribute(attrKey_value, treasure.bindSkillId.ToString());
                    mainElement.AppendChild(ele);
                }

                // 能力加成
                ele = xmlDoc.CreateElement(nodeName_statBuff);
                for (int i = 0; i < 5; i++)
                {
                    int statBuff = treasure.statBuff[i];
                    if (statBuff != 0)
                    {
                        ele.SetAttribute(Enum.GetName((StatType)i), statBuff.ToString());
                    }
                }
                mainElement.AppendChild(ele);

                // 模型
                ele = xmlDoc.CreateElement(nodeName_model);
                ele.SetAttribute(attrKey_value, TreasureModelXmlHelper.modelIdPrefix + treasure.Id.ToString("d3"));
                mainElement.AppendChild(ele);

                rootEle.AppendChild(mainElement);
            }

            xmlDoc.Save(xmlPath);
        }
    }
}
