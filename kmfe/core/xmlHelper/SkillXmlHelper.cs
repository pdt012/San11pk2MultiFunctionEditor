using kmfe.common;
using kmfe.core.globalTypes;
using kmfe.s11.enums;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace kmfe.core.xmlHelper
{
    public class SkillXmlHelper : BaseXmlHelper
    {
        const string mainNodeName = "skill";
        const string nodeName_name = "name";
        const string nodeName_desc = "desc";
        const string nodeNameype = "type";
        const string nodeName_level = "level";
        const string nodeName_bindSkills = "bind_skill";
        const string attrKey_value = "value";

        static readonly string[] colorOfLevelList = { "", "\x1b[00x", "\x1b[23x", "\x1b[19x", "\x1b[22x" };
        static readonly Regex regColorStart = new(@"(\x1b\[\d{1,2}x)");

        public SkillXmlHelper(ScenarioData scenarioData) : base(scenarioData)
        {
        }

        public override void Load(string xmlPath)
        {
            #region common
            XmlDocument xmlDoc = new();
            xmlDoc.Load(xmlPath);
            XmlElement? rootEle = xmlDoc.DocumentElement;
            #endregion

            XmlNodeList? skillNodeList = rootEle?.SelectNodes(mainNodeName);
            if (skillNodeList == null) return;
            foreach (XmlNode skillNode in skillNodeList)
            {
                if (skillNode is not XmlElement) continue;

                string? str_id = skillNode.Attributes?["id"]?.Value;
                if (str_id == null) continue;
                int id = int.Parse(str_id);
                Skill skill = scenarioData.skillArray[id];

                string? name = skillNode.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    skill.name = regColorStart.Replace(name, "");  // 去除颜色代码

                string? desc = skillNode.SelectSingleNode(nodeName_desc)?.Attributes?[attrKey_value]?.Value;
                if (desc != null)
                    skill.desc = ParseDesc(desc);  // 去除颜色代码

                string? type = skillNode.SelectSingleNode(nodeNameype)?.Attributes?[attrKey_value]?.Value;
                if (type != null)
                    skill.type = (SkillType)int.Parse(type);

                string? level = skillNode.SelectSingleNode(nodeName_level)?.Attributes?[attrKey_value]?.Value;
                if (level != null)
                    skill.level = int.Parse(level);

                string? bind_skill = skillNode.SelectSingleNode(nodeName_bindSkills)?.Attributes?[attrKey_value]?.Value;
                if (bind_skill != null)
                {
                    string[] bindArray = bind_skill.Split(",");
                    skill.bindSkillList.Clear();
                    foreach (string bindSkill in bindArray)
                    {
                        if (bindSkill.Trim().Length > 0)
                            skill.bindSkillList.Add(int.Parse(bindSkill.Trim()));
                    }
                }
            }
        }

        public override void Save(string xmlPath)
        {
            #region common
            XmlDocument xmlDoc = new();
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDec);
            XmlElement rootEle = xmlDoc.CreateElement("pk");
            rootEle.SetAttribute("trace", "false");
            rootEle.SetAttribute("utf8", "true");

            rootEle.AppendChild(xmlDoc.CreateComment("AUTHOR: keehl102"));
            rootEle.AppendChild(xmlDoc.CreateComment($"TOOL: {AppInfo.shortNameVersion}(by {AppInfo.author})"));
            rootEle.AppendChild(xmlDoc.CreateComment($"CREATETIME: {DateTime.Now.ToString()}"));
            #endregion

            foreach (Skill skill in scenarioData.skillArray)
            {
                XmlElement skillEle = xmlDoc.CreateElement(mainNodeName);
                skillEle.SetAttribute("id", skill.Id.ToString());

                XmlElement nameEle = xmlDoc.CreateElement(nodeName_name);
                nameEle.SetAttribute(attrKey_value, colorOfLevelList[skill.level] + skill.name);  // 添加等级颜色高亮
                skillEle.AppendChild(nameEle);

                XmlElement descEle = xmlDoc.CreateElement(nodeName_desc);
                descEle.SetAttribute(attrKey_value, FormatColoredDesc(skill.desc));  // 添加数值高亮
                skillEle.AppendChild(descEle);

                XmlElement typeEle = xmlDoc.CreateElement(nodeNameype);
                typeEle.SetAttribute(attrKey_value, ((int)skill.type).ToString());
                skillEle.AppendChild(typeEle);

                XmlElement levelEle = xmlDoc.CreateElement(nodeName_level);
                levelEle.SetAttribute(attrKey_value, skill.level.ToString());
                skillEle.AppendChild(levelEle);

                XmlElement bindSkillEle = xmlDoc.CreateElement(nodeName_bindSkills);
                List<string> bindSkillStrList = new();
                foreach (int bindSkill in skill.bindSkillList)
                {
                    bindSkillStrList.Add(bindSkill.ToString());
                }
                bindSkillEle.SetAttribute(attrKey_value, string.Join(",", bindSkillStrList));
                skillEle.AppendChild(bindSkillEle);

                rootEle.AppendChild(skillEle);
            }

            #region common
            xmlDoc.AppendChild(rootEle);
            xmlDoc.Save(xmlPath);
            #endregion
        }

        string ParseDesc(string desc)
        {
            string str = desc;
            // 自动高亮部分
            str = Regex.Replace(str, @"(\x1b\[2x\S*?\x1b\[0x)", "{}");
            // 手动高亮部分
            str = str.Replace("\x1b[1x", "<");
            str = str.Replace("\x1b[0x", ">");
            return str;
        }

        string FormatColoredDesc(string desc)
        {
            /*EditData* data_ = EditData::current();
            if (data_ == NULL)
                throw KRE_Error("EditData未初始化");
            StringList constants = data_->getSkillConstants(this->id);*/

            string str = desc;
            // 手动高亮部分
            str = str.Replace("<", "\x1b[1x");  // 手动高亮用1x，自动高亮用2x以便读取时能够区分
            str = str.Replace(">", "\x1b[0x");
            // 自动高亮部分
            str = str.Replace("{}", "\x1b[2x{%}\x1b[0x");  // 自定义的替换符 {%}
            /*for (int i = 0; i < constants.size(); i++)
            {   // 以特技数值constants逐个填充
                int index = str.indexOf("{%}");
                if (index >= 0)
                    str.replace(index, 3, constants[i]);
            }*/
            str = str.Replace("{%}", "O");   // TODO: 目前没有导入特技数值，所以先留空
            return str;
        }

        string FormatDesc(string desc)
        {
            string str = desc;
            // 自动高亮部分
            str = str.Replace("{}", "{{%}}");  // 自定义的替换符 {%}
            str = str.Replace("{%}", "O");   // TODO: 目前没有导入特技数值，所以先全部留空
            return str;
        }
    }
}
