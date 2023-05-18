using kmfe.s11.enums;
using System;
using System.Text.RegularExpressions;

namespace kmfe.core.globalTypes
{
    public class Skill : BaseType
    {
        public const int maxBindSkills = 8;
        public const int maxSkillConstants = 5;

        public string name = "";
        public string desc = "";
        public SkillType type = SkillType.行军;
        public int level = 1;
        public List<int> bindSkillList = new();
        public readonly SkillConstant[] constantArray = new SkillConstant[5];

        public Skill(int id) : base(id)
        {
            for (int i = 0; i < constantArray.Length; i++)
                constantArray[i] = new SkillConstant();
        }

        public bool IsValid() => name.Length > 0;

        public void Reset(string name = "", string desc = "", SkillType type = SkillType.行军, int level = 1)
        {
            this.name = name;
            this.desc = desc;
            this.type = type;
            this.level = level;
            bindSkillList.Clear();
            for (int i = 0; i < constantArray.Length; i++)
                constantArray[i].Cancel();
        }

        public void SetBindSkillsFromString(string bindSkills)
        {
            if (bindSkills.Length > 0)
            {
                string[] temp = bindSkills.Split(",");
                bindSkillList.Clear();
                foreach (string sk in temp)
                    bindSkillList.Add(int.Parse(sk.Trim()));
            }
        }

        public string ParseDesc(string formattedDesc)
        {
            string str = formattedDesc;
            // 自动高亮部分
            str = Regex.Replace(str, @"(\x1b\[2x\S*?\x1b\[0x)", "{}");
            // 手动高亮部分
            str = str.Replace("\x1b[1x", "<");
            str = str.Replace("\x1b[0x", ">");
            return str;
        }

        public string GetFormattedDesc()
        {
            string str = desc;
            // 自动高亮部分
            for (int i = 0; i < maxSkillConstants; i++)
            {
                if (constantArray[i].available)
                    str = str.Replace($"{{{i}}}", $"{{{constantArray[i].value}}}");  // 根据对应序号填充特技数值
                else
                    str = str.Replace($"{{{i}}}", "{null}");
            }
            return str;
        }

        public string GetColorFormattedDesc()
        {
            string str = desc;
            // 手动高亮部分
            str = str.Replace("<", "\x1b[1x");  // 手动高亮用1x，自动高亮用2x以便读取时能够区分
            str = str.Replace(">", "\x1b[0x");
            // 自动高亮部分
            for (int i = 0; i < maxSkillConstants; i++)
            {
                if (constantArray[i].available)
                    str = str.Replace($"{{{i}}}", $"\x1b[2x{constantArray[i].value}\x1b[0x");  // 根据对应序号填充特技数值
                else
                    str = str.Replace($"{{{i}}}", "{null}");
            }
            return str;
        }
    }

    public class SkillConstant
    {
        public bool available;
        public string desc;
        public int value;

        public SkillConstant(bool available, string desc, int value)
        {
            this.available = available;
            this.desc = desc;
            this.value = value;
        }

        public SkillConstant()
        {
            available = false;
            desc = "";
            value = 0;
        }

        public void Setup(string desc, int value)
        {
            available = true;
            this.desc = desc;
            this.value = value;
        }

        public void Cancel()
        {
            available = false;
            desc = "";
            value = 0;
        }
    }
}
