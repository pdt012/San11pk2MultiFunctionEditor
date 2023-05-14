using kmfe.core.globalTypes;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    internal class TitleXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "title";
        const string nodeName_name = "name";
        const string nodeName_command = "command";
        const string attrKey_value = "value";

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
                Title title = AppEnvironment.scenarioData.titleArray[id];

                /*string? name = mainNode.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    title.name = name;

                string? command = mainNode.SelectSingleNode(nodeName_command)?.Attributes?[attrKey_value]?.Value;
                if (command != null)
                    title.command = int.Parse(command);*/
                #endregion
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            XmlElement mainElement;
            XmlElement ele;
            foreach (Title title in AppEnvironment.scenarioData.titleArray)
            {
                mainElement = xmlDoc.CreateElement(mainNodeName);
                mainElement.SetAttribute("id", title.Id.ToString());

                /*ele = xmlDoc.CreateElement(nodeName_name);
                ele.SetAttribute(attrKey_value, title.name);
                mainElement.AppendChild(ele);

                ele = xmlDoc.CreateElement(nodeName_command);
                ele.SetAttribute(attrKey_value, title.command.ToString());
                mainElement.AppendChild(ele);*/

                rootEle.AppendChild(mainElement);
            }

            xmlDoc.Save(xmlPath);
        }
    }
}
