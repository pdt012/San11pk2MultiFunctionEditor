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
        const string nodeName_type = "type";
        const string nodeName_level = "level";
        const string nodeName_bindSkills = "bind_skill";
        const string nodeName_constants = "constant";
        const string nodeName_constantDesc = "c_label";
        const string attrKey_value = "value";

        static readonly string[] colorOfLevelList = { "", "\x1b[00x", "\x1b[23x", "\x1b[19x", "\x1b[22x" };
        static readonly Regex regColorStart = new(@"(\x1b\[\d{1,2}x)");

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

                #region LoadById
                Skill skill = AppEnvironment.scenarioData.skillArray[id];

                string? name = skillNode.SelectSingleNode(nodeName_name)?.Attributes?[attrKey_value]?.Value;
                if (name != null)
                    skill.name = regColorStart.Replace(name, "");  // 去除颜色代码

                string? desc = skillNode.SelectSingleNode(nodeName_desc)?.Attributes?[attrKey_value]?.Value;
                if (desc != null)
                    skill.desc = ParseDesc(desc);  // 去除颜色代码

                string? type = skillNode.SelectSingleNode(nodeName_type)?.Attributes?[attrKey_value]?.Value;
                if (type != null)
                    skill.type = (SkillType)int.Parse(type);

                string? level = skillNode.SelectSingleNode(nodeName_level)?.Attributes?[attrKey_value]?.Value;
                if (level != null)
                    skill.level = int.Parse(level);

                XmlNode? bind_skill_node = skillNode.SelectSingleNode(nodeName_bindSkills);
                if (bind_skill_node != null)
                {
                    skill.bindSkillList.Clear();
                    for (int i = 0; i < Skill.maxSkillConstants;i++)
                    {
                        string? bind_skill_id = bind_skill_node.Attributes?[$"_{i}"]?.Value;
                        if (bind_skill_id != null && bind_skill_id.Length > 0)
                            skill.bindSkillList.Add(int.Parse(bind_skill_id));
                    }
                }

                XmlNode? constant_node = skillNode.SelectSingleNode(nodeName_constants);
                XmlNode? constant_desc_node = skillNode.SelectSingleNode(nodeName_constantDesc);
                if (constant_node != null)
                {
                    for (int i = 0; i < Skill.maxSkillConstants; i++)
                    {
                        string? constant = constant_node.Attributes?[$"_{i}"]?.Value;
                        if (constant != null && constant.Length > 0)
                        {
                            string? constant_desc = constant_desc_node?.Attributes?[$"_{i}"]?.Value??"";
                            skill.constantArray[i].Setup(constant_desc, int.Parse(constant));
                        }
                        else
                        {
                            skill.constantArray[i].Cancel();
                        }
                    }
                }
                #endregion
            }
        }

        public override void Save(string xmlPath)
        {
            XmlDocument xmlDoc = new();
            XmlElement rootEle = CreateRootElement(xmlDoc);

            foreach (Skill skill in AppEnvironment.scenarioData.skillArray)
            {
                XmlElement skillEle = xmlDoc.CreateElement(mainNodeName);
                skillEle.SetAttribute("id", skill.Id.ToString());

                XmlElement nameEle = xmlDoc.CreateElement(nodeName_name);
                nameEle.SetAttribute(attrKey_value, colorOfLevelList[skill.level] + skill.name);  // 添加等级颜色高亮
                skillEle.AppendChild(nameEle);

                XmlElement descEle = xmlDoc.CreateElement(nodeName_desc);
                descEle.SetAttribute(attrKey_value, FormatColoredDesc(skill.desc));  // 添加数值高亮
                skillEle.AppendChild(descEle);

                XmlElement typeEle = xmlDoc.CreateElement(nodeName_type);
                typeEle.SetAttribute(attrKey_value, ((int)skill.type).ToString());
                skillEle.AppendChild(typeEle);

                XmlElement levelEle = xmlDoc.CreateElement(nodeName_level);
                levelEle.SetAttribute(attrKey_value, skill.level.ToString());
                skillEle.AppendChild(levelEle);

                if (skill.bindSkillList.Count > 0)
                {
                    XmlElement bindSkillEle = xmlDoc.CreateElement(nodeName_bindSkills);
                    for (int i = 0; i < skill.bindSkillList.Count; i++)
                    {
                        int bindSkillId = skill.bindSkillList[i];
                        bindSkillEle.SetAttribute($"_{i}", bindSkillId.ToString());
                    }
                    skillEle.AppendChild(bindSkillEle);
                }

                XmlElement constantEle = xmlDoc.CreateElement(nodeName_constants);
                XmlElement constantDescEle = xmlDoc.CreateElement(nodeName_constantDesc);
                bool flagHasConstant = false;
                for (int i = 0; i < skill.constantArray.Length; i++)
                {
                    SkillConstant constant = skill.constantArray[i];
                    if (constant.available)
                    {
                        flagHasConstant = true;
                        constantEle.SetAttribute($"_{i}", constant.value.ToString());
                        constantDescEle.SetAttribute($"_{i}", constant.desc);
                    }
                }
                if (flagHasConstant)
                {
                    skillEle.AppendChild(constantEle);
                    skillEle.AppendChild(constantDescEle);
                }

                rootEle.AppendChild(skillEle);
            }

            xmlDoc.Save(xmlPath);
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
