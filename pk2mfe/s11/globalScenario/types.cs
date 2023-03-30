using kmfe.utils.bytesConverter;
using System;

namespace kmfe.s11.globalScenario
{
    using int16 = Int16;
    using uint16 = UInt16;
    using int8 = SByte;
    using uint8 = Byte;


    /// <summary>
    /// 城市
    /// </summary>
    public class City : IBytesConvertable
    {
        public readonly byte[] name = new byte[5];      // (dec)
        public readonly byte[] read = new byte[11];     // 5
        int16 __11;                                     // 16
        public int8 province;                           // 18
        public readonly int8[] adjacent = new int8[6];  // 19

        public const int Size = 25;

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Read(name);
            converter.Read(read);
            converter.Read(out __11);
            converter.Read(out province);
            converter.Read(adjacent);
        }

        public void ToBytes(ref byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Write(name);
            converter.Write(read);
            converter.Write(__11);
            converter.Write(province);
            converter.Write(adjacent);
        }
    }

    /// <summary>
    /// 关隘/港口
    /// </summary>
    public class GatePort : IBytesConvertable
    {
        public readonly byte[] name = new byte[7];  // (dec)
        readonly byte[] __8 = new byte[19];         // 7

        public const int Size = 26;

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Read(name);
            converter.Read(__8);
        }

        public void ToBytes(ref byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Write(name);
            converter.Write(__8);
        }
    }

    /// <summary>
    /// 州
    /// </summary>
    public class Province : IBytesConvertable
    {
        public readonly byte[] name = new byte[5];      // (dec)
        public readonly byte[] read = new byte[13];     // 5
        public readonly byte[] __12 = new byte[12];            // 18
        public readonly byte[] desc = new byte[8];      // 30
        public int8 region;                             // 38
        public readonly int8[] adjacent = new int8[5];  // 39

        public const int Size = 44;

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Read(name);
            converter.Read(read);
            converter.Read(__12);
            converter.Read(desc);
            converter.Read(out region);
            converter.Read(adjacent);
        }

        public void ToBytes(ref byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Write(name);
            converter.Write(read);
            converter.Write(__12);
            converter.Write(desc);
            converter.Write(region);
            converter.Write(adjacent);
        }
    }

    /// <summary>
    /// 地方
    /// </summary>
    public class Region : IBytesConvertable
    {
        public readonly byte[] name = new byte[5];
        public readonly byte[] __6 = new byte[13];

        public const int Size = 18;

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Read(name);
            converter.Read(__6);
        }

        public void ToBytes(ref byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Write(name);
            converter.Write(__6);
        }
    }

    #region TODO
#if false
// 设施
struct Facility
{
    fixed byte name[9];
    fixed byte _padding[180];

};
// 兵器
struct Weapon
{
    fixed byte _padding[150];

};
// 爵位
struct Title
{
    fixed byte name[11];
    fixed byte _ip_b[31];
    uint16_t command;
};
// 官职
struct Rank
{
    fixed byte name[9];
    fixed byte read[25];
    fixed byte _ip_22[6];
    uint16_t command;
    uint8_t stat;
    uint8_t increase;
    uint8_t salary;
    uint8_t rank;
};
// 特技
struct Skill
{
    fixed byte name[5];
    fixed byte _padding[88];

};
// 科技
struct Technology
{
    fixed byte name[9];
    fixed byte read[33];
    fixed byte desc[41];
    uint8_t type;           // 类型
    uint8_t level;          // 等级
    uint16_t gold_cost;     // 金钱消耗
    uint16_t tp_cost;       // 技巧消耗
    uint8_t period;         // 研究时间
    fixed byte _ip_5a;
    int8_t necessary_tech;  // 必要前置科技
};
// 战法
struct Tactic
{
    fixed byte name[9];
    fixed byte _padding[47];

};
// 地形
struct Terrain
{
    fixed byte name[5];
    fixed byte read[9];
    fixed byte _padding[8];
    char _ip_16;

};
// 姓氏
struct Family
{
    fixed byte name[3];
    fixed byte read[7];
    uint8_t _ip_a;
};
// 能力
struct Ability
{
    fixed byte _padding[74];

};

#endif
    #endregion

    /// <summary>
    /// 全局设置 Scenario.s11
    /// </summary>
    public class GlobalScenario : IBytesConvertable
    {
        public readonly byte[] __0 = new byte[8];               // (hex) 未知
        public readonly byte[] title = new byte[16];            // 8 KOEI%SAN11
        int __18;                                               // 18 未知
        int __1c;                                               // 1c 未知
        public readonly byte[] __20 = new byte[56];             // 20 未知
        int16 __58;                                             // 58 未知
        public readonly City[] cityArray = new City[42];             // 5a 城市
        public readonly GatePort[] gatePortArray = new GatePort[45]; // 474 关隘  // 578 港口
        public readonly Province[] provinceArray = new Province[12]; // 906 州
        public readonly Region[] regionArray = new Region[6];        // b16 地方
        //public readonly Facility[] facilityArray = new Facility[64];      // b82 设施
        //public readonly Weapon[] weaponArray = new Weapon[12];          // 3ac2 兵器
        //public readonly Title[] titleArray = new Title[10];            // 41ca 爵位
        //public readonly Rank rankArray = new Rank[81];              // 4382 官职
        //public readonly Skill skillArray = new Skill[100];           // 5210 特技
        //public readonly Technology techArray = new Technology[36]; // 7664 科技
        //public readonly Tactic tacticArray = new Tactic[32];          // 8354 战法
        //public readonly Terrain terrainArray = new Terrain[32];        // 8a54 地形
        //public readonly Family familyArray = new Family[400];         // 8d34 姓氏
        //public readonly Ability abilityArray = new Ability[98];        // 9e64 能力

        public const int Size = 0xBAB8;  // 47800

        public GlobalScenario()
        {
            for (int i = 0; i < cityArray.Length; i++)
                cityArray[i] = new City();
            for (int i = 0; i < gatePortArray.Length; i++)
                gatePortArray[i] = new GatePort();
            for (int i = 0; i < provinceArray.Length; i++)
                provinceArray[i] = new Province();
            for (int i = 0; i < regionArray.Length; i++)
                regionArray[i] = new Region();
        }

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Read(__0);
            converter.Read(title);
            converter.Read(out __18);
            converter.Read(out __1c);
            converter.Read(__20);
            converter.Read(out __58);
            foreach (City city in cityArray)
            {
                converter.Read(city);
            }
            foreach (GatePort port in gatePortArray)
            {
                converter.Read(port);
            }
            foreach (Province province in provinceArray)
            {
                converter.Read(province);
            }
            foreach (Region region in regionArray)
            {
                converter.Read(region);
            }
        }

        public void ToBytes(ref byte[] array)
        {
            if (array.Length != Size) throw new IndexOutOfRangeException();
            StreamConverter converter = new StreamConverter(array);
            converter.Write(__0);
            converter.Write(title);
            converter.Write(__18);
            converter.Write(__1c);
            converter.Write(__20);
            converter.Write(__58);
            foreach (City city in cityArray)
            {
                converter.Write(city);
            }
            foreach (GatePort gate in gatePortArray)
            {
                converter.Write(gate);
            }
            foreach (Province province in provinceArray)
            {
                converter.Write(province);
            }
            foreach (Region region in regionArray)
            {
                converter.Write(region);
            }
        }
    }
}