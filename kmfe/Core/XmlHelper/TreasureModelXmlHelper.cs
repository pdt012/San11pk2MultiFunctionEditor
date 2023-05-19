using kmfe.Core.GlobalTypes;
using System.Xml;

namespace kmfe.Core.XmlHelper
{
    internal class TreasureModelXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "item_model";
        const string attrKey_id = "id";
        const string nodeName_image = "image";
        const string attrKey_value = "value";
        public const string modelIdPrefix = "item_";

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
                treasure.imagePath = "";
            }

            foreach (XmlNode node in nodeList)
            {
                if (node is not XmlElement) continue;

                string? str_id = node.Attributes?[attrKey_id]?.Value;
                if (str_id == null) continue;
                str_id = str_id.Replace(modelIdPrefix, "");
                int treasureId = int.Parse(str_id);

                #region LoadById
                Treasure treasure = AppEnvironment.scenarioData.treasureArray[treasureId];

                string? image = node.SelectSingleNode(nodeName_image)?.Attributes?[attrKey_value]?.Value;
                if (image != null)
                    treasure.imagePath = image;
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
                mainElement.SetAttribute(attrKey_id, modelIdPrefix + treasure.Id.ToString("d3"));

                ele = xmlDoc.CreateElement(nodeName_image);
                ele.SetAttribute(attrKey_value, treasure.imagePath);
                mainElement.AppendChild(ele);

                rootEle.AppendChild(mainElement);
            }

            xmlDoc.Save(xmlPath);
        }
    }
}
