using kmfe.S11.S11Enums;

namespace kmfe.Core.GlobalTypes
{
    public abstract class CityLike : BaseType
    {
        public const int neighborMax = 7;

        public string name = "";
        public string read = "";
        public HashSet<Neighbor> neighborSet = new();  // 用HashSet以保证Neighbor的Id不会重复

        public CityLike(int id) : base(id)
        {
        }
    }

    public record struct Neighbor(int CityId, RouteType Route)
    {
        public override int GetHashCode()
        {
            return CityId.GetHashCode();
        }
    }
}
