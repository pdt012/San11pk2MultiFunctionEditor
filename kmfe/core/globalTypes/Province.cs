namespace kmfe.core.globalTypes
{
    public class Province : BaseType
    {
        public const int adjacentProvinceMax = 5;

        public string name = "";
        public string read = "";
        public string __12 = "";
        public string desc = "";
        public int regionId = 0;
        public HashSet<int> adjacentProvinceIdSet = new();

        public Province(int id) : base(id)
        {
        }

        public sbyte[] GetAdjacentArray()
        {
            sbyte[] adjacent = new sbyte[adjacentProvinceMax];
            int count = 0;
            foreach (int adj in adjacentProvinceIdSet)
            {
                adjacent[count] = (sbyte)adj;
                count++;
            }
            for (int a = count; a < adjacent.Length; a++)  // 其余设为-1
            {
                adjacent[a] = -1;
            }
            return adjacent;
        }
    }
}
