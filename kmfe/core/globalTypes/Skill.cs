using kmfe.s11.enums;

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
                foreach (string sk in temp)
                    bindSkillList.Add(int.Parse(sk.Trim()));
            }
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
