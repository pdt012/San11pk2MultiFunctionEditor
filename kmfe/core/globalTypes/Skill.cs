using kmfe.s11.enums;

namespace kmfe.core.globalTypes
{
    public class Skill : BaseType
    {
        public string name = "";
        public string desc = "";
        public SkillType type = SkillType.行军;
        public int level;
        public List<int> bindSkillList = new();

        public Skill(int id) : base(id)
        {
        }

        public bool IsValid() => name.Length > 0;

        public void Reset(string name = "", string desc = "", SkillType type = SkillType.行军, int level = 1)
        {
            this.name = name;
            this.desc = desc;
            this.type = type;
            this.level = level;
            this.bindSkillList.Clear();
        }

        public void SetBindSkillsFromString(string bindSkills)
        {
            if (bindSkills.Length > 0)
            {
                string[] temp = bindSkills.Split(",");
                foreach (string sk in temp)
                    bindSkillList.Add(int.Parse(sk.Trim()));
            }
        }

        
    }
}
