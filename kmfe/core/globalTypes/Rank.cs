﻿using kmfe.s11.enums;

namespace kmfe.core.globalTypes
{
    public class Rank : BaseType
    {
        public string name = "";
        public int command = 0;
        public StatType statType = StatType.统率;
        public int statIncrease = 0;
        public int salary = 0;
        public int rankLevel = 0;
        public int merit = 0;

        public Rank(int id) : base(id)
        {
        }
    }
}
