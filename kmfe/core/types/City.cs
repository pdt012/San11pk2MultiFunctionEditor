using kmfe.utils;

namespace kmfe.core.types
{
    public class City : CityLike
    {
        public const int adjacentCityMax = 6;

        public HashSet<int> adjacentCityIdSet = new();

        public City(int id) : base(id)
        {
        }

        public sbyte[] GetAdjacentArray()
        {
            sbyte[] adjacent = new sbyte[adjacentCityMax];
            int count = 0;
            foreach (int adj in adjacentCityIdSet)
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
