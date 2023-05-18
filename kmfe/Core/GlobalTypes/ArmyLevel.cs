namespace kmfe.Core.GlobalTypes
{
    public class ArmyLevel : BaseType
    {
        public const int UnreachableExp = 256;

        public string name = "";
        public int exp = 0;
        public int tacticsChanceBuff = 0;
        public float unitStatRatio = 1f;

        public ArmyLevel(int id) : base(id)
        {
        }

        public bool IsReachable()
        {
            return exp < UnreachableExp;
        }
    }
}
