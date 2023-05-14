using kmfe.common;
using kmfe.core.globalTypes;
using kmfe.s11.enums;
using System.Text.RegularExpressions;
using System.Xml;

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
                    skill.desc = skill.ParseDesc(desc);  // 去除颜色格式化

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
                descEle.SetAttribute(attrKey_value, skill.GetColorFormattedDesc());  // 添加颜色格式化
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
    }
}
