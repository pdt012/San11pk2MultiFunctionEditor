using kmfe.common;
using System.Xml;

namespace kmfe.core.xmlHelper
{
    public abstract class BaseXmlHelper
    {

        public BaseXmlHelper()
        {
        }

        public abstract void Load(string xmlPath);

        public abstract void Save(string xmlPath);

        protected static XmlElement CreateRootElement(XmlDocument xmlDoc)
        {
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDec);
            XmlElement rootEle = xmlDoc.CreateElement("pk");
            xmlDoc.AppendChild(rootEle);
            rootEle.SetAttribute("trace", "false");
            rootEle.SetAttribute("utf8", "true");

            rootEle.AppendChild(xmlDoc.CreateComment("AUTHOR: keehl102"));
            rootEle.AppendChild(xmlDoc.CreateComment($"TOOL: {AppInfo.shortNameVersion}(by {AppInfo.author})"));
            rootEle.AppendChild(xmlDoc.CreateComment($"CREATETIME: {DateTime.Now.ToString()}"));

            return rootEle;
        }
    }
}
