using System.Collections.Generic;

namespace kmfe.core.types
{
    public abstract class CityLike
    {
        public const int neighborMax = 7;

        public int id;
        public string name = "";
        public string read = "";
        public HashSet<Neighbor> neighborSet = new HashSet<Neighbor>();  // 用HashSet以保证Neighbor的Id不会重复


        public CityLike(int id)
        {
            this.id = id;
        }
    }

    public struct Neighbor
    {
        public int CityId;
        public int Route;
        public Neighbor(int CityId, int Route)
        {
            this.CityId = CityId;
            this.Route = Route;
        }
        public override int GetHashCode()
        {
            return CityId.GetHashCode();
        }
    }
}
