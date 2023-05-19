using kmfe.S11.S11Enums;

namespace kmfe.Core.GlobalTypes
{
    public class Treasure : BaseType
    {
        public string name = "";
        public string read = "";
        public string history = "";
        public TreasureType type = 0;
        public int worth = 0;
        public int bindSkillId = -1;
        public int[] statBuff = new int[5];
        public string imagePath = "";

        public Treasure(int id) : base(id)
        {
        }

        public bool IsValid() => name.Length > 0;

        public void Reset(string name = "", string read = "", string history = "", TreasureType type = TreasureType.名马,
            int worth = 0, int bindSkillId = -1)
        {
            this.name = name;
            this.read = read;
            this.history = history;
            this.type = type;
            this.worth = worth;
            this.bindSkillId = bindSkillId;
            for (int i = 0; i < statBuff.Length; i++)
                statBuff[i] = 0;
        }
    }
}
