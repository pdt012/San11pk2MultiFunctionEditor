using kmfe.utils.bytesConverter;

namespace kmfe.s11.globalScenario;

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
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(read);
        converter.Read(out __11);
        converter.Read(out province);
        converter.Read(adjacent);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
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
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(__8);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
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
    public readonly byte[] __12 = new byte[12];     // 18
    public readonly byte[] desc = new byte[8];      // 30
    public int8 region;                             // 38
    public readonly int8[] adjacent = new int8[5];  // 39

    public const int Size = 44;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
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
        StreamConverter converter = new(array);
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
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(__6);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Write(name);
        converter.Write(__6);
    }
}

/// <summary>
/// 设施
/// </summary>
public class Facility: IBytesConvertable /*todo*/
{
    public readonly byte[] name = new byte[9];
    readonly byte[] __todo = new byte[180];

    public const int Size = 189;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// 兵器
/// </summary>
public class Weapon : IBytesConvertable /*todo*/
{
    readonly byte[] __todo = new byte[150];

    public const int Size = 150;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }

};

/// <summary>
/// 爵位
/// </summary>
public class Title : IBytesConvertable
{
    public readonly byte[] name = new byte[11];
    readonly byte[] __b = new byte[31];
    public uint16 command;

    public const int Size = 44;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(__b);
        converter.Read(out command);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Write(name);
        converter.Write(__b);
        converter.Write(command);
    }
}

/// <summary>
/// 官职
/// </summary>
public class Rank : IBytesConvertable
{
    public readonly byte[] name = new byte[9];
    public readonly byte[] read = new byte[25];
    public readonly byte[] __22 = new byte[6];
    public uint16 command;
    public uint8 stat;
    public uint8 increase;
    public uint8 salary;
    public uint8 rank;

    public const int Size = 46;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(read);
        converter.Read(__22);
        converter.Read(out command);
        converter.Read(out stat);
        converter.Read(out increase);
        converter.Read(out salary);
        converter.Read(out rank);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Write(name);
        converter.Write(read);
        converter.Write(__22);
        converter.Write(command);
        converter.Write(stat);
        converter.Write(increase);
        converter.Write(salary);
        converter.Write(rank);
    }
}

/// <summary>
/// 特技
/// </summary>
public class Skill : IBytesConvertable /*todo*/
{
    public readonly byte[] name = new byte[5];
    public readonly byte[] __todo = new byte[88];

    public const int Size = 93;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }

};

/// <summary>
/// 科技
/// </summary>
public class Technology : IBytesConvertable
{
    public readonly byte[] name = new byte[9];  // (dec) 名称
    public readonly byte[] read = new byte[33]; // 9 读音
    public readonly byte[] desc = new byte[41]; // 42 介绍
    public uint8 type;                          // 83 类型
    public uint8 level;                         // 84 等级
    public uint16 gold_cost;                    // 85 金钱消耗
    public uint16 tp_cost;                      // 87 技巧消耗
    public uint8 period;                        // 89 研究时间
    public int8 __5a;                           // 90
    public int8 necessaryech;                 // 91 必要前置科技

    public const int Size = 92;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(read);
        converter.Read(desc);
        converter.Read(out type);
        converter.Read(out level);
        converter.Read(out gold_cost);
        converter.Read(out tp_cost);
        converter.Read(out period);
        converter.Read(out __5a);
        converter.Read(out necessaryech);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Write(name);
        converter.Write(read);
        converter.Write(desc);
        converter.Write(type);
        converter.Write(level);
        converter.Write(gold_cost);
        converter.Write(tp_cost);
        converter.Write(period);
        converter.Write(__5a);
        converter.Write(necessaryech);

    }
};

/// <summary>
/// 战法
/// </summary>
public class Tactic : IBytesConvertable /*todo*/
{
    public readonly byte[] name = new byte[9];
    public readonly byte[] __todo = new byte[47];

    public const int Size = 56;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }

};

/// <summary>
/// 地形
/// </summary>
public class Terrain : IBytesConvertable /*todo*/
{
    public readonly byte[] name = new byte[5];
    public readonly byte[] read = new byte[9];
    public readonly byte[] __todo = new byte[8];
    public int8 __16;

    public const int Size = 23;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }

};

/// <summary>
/// 姓氏
/// </summary>
public class Family : IBytesConvertable /*todo*/
{
    public readonly byte[] name = new byte[3];
    public readonly byte[] read = new byte[7];
    public uint8 __a;

    public const int Size = 11;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }
};

/// <summary>
/// 能力
/// </summary>
public class Ability : IBytesConvertable /*todo*/
{
    public readonly byte[] __todo = new byte[74];

    public const int Size = 74;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        throw new NotImplementedException();
    }

    public void ToBytes(ref byte[] array)
    {
        throw new NotImplementedException();
    }

};


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
    public readonly City[] cityArray = new City[42];                // 5a 城市
    public readonly GatePort[] gatePortArray = new GatePort[45];    // 474 关隘  // 578 港口
    public readonly Province[] provinceArray = new Province[12];    // 906 州
    public readonly Region[] regionArray = new Region[6];           // b16 地方
    public readonly Facility[] facilityArray = new Facility[64];    // b82 设施
    public readonly Weapon[] weaponArray = new Weapon[12];          // 3ac2 兵器
    public readonly Title[] titleArray = new Title[10];             // 41ca 爵位
    public readonly Rank[] rankArray = new Rank[81];                // 4382 官职
    public readonly Skill[] skillArray = new Skill[100];            // 5210 特技
    public readonly Technology[] techArray = new Technology[36];    // 7664 科技
    public readonly Tactic[] tacticArray = new Tactic[32];          // 8354 战法
    public readonly Terrain[] terrainArray = new Terrain[32];       // 8a54 地形
    public readonly Family[] familyArray = new Family[400];         // 8d34 姓氏
    public readonly Ability[] abilityArray = new Ability[98];       // 9e64 能力

    public const int Size = 0xBAB8;  // 47800

    public GlobalScenario()
    {
        for (int i = 0; i < cityArray.Length; i++)
            cityArray[i] = new();
        for (int i = 0; i < gatePortArray.Length; i++)
            gatePortArray[i] = new();
        for (int i = 0; i < provinceArray.Length; i++)
            provinceArray[i] = new();
        for (int i = 0; i < regionArray.Length; i++)
            regionArray[i] = new();
        for (int i = 0; i < facilityArray.Length; i++)
            facilityArray[i] = new();
        for (int i = 0; i < weaponArray.Length; i++)
            weaponArray[i] = new();
        for (int i = 0; i < titleArray.Length; i++)
            titleArray[i] = new();
        for (int i = 0; i < rankArray.Length; i++)
            rankArray[i] = new();
        for (int i = 0; i < skillArray.Length; i++)
            skillArray[i] = new();
        for (int i = 0; i < techArray.Length; i++)
            techArray[i] = new();
        for (int i = 0; i < tacticArray.Length; i++)
            tacticArray[i] = new();
        for (int i = 0; i < terrainArray.Length; i++)
            terrainArray[i] = new();
        for (int i = 0; i < familyArray.Length; i++)
            familyArray[i] = new();
        for (int i = 0; i < abilityArray.Length; i++)
            abilityArray[i] = new();
    }

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Read(__0);
        converter.Read(title);
        converter.Read(out __18);
        converter.Read(out __1c);
        converter.Read(__20);
        converter.Read(out __58);

        converter.Read(cityArray);
        converter.Read(gatePortArray);
        converter.Read(provinceArray);
        converter.Read(regionArray);

        converter.Seek(0x41ca, SeekOrigin.Begin);
        converter.Read(titleArray);
        converter.Read(rankArray);

        converter.Seek(0x7664, SeekOrigin.Begin);
        converter.Read(techArray);
    }

    public void ToBytes(ref byte[] array)
    {
        if (array.Length != Size) throw new IndexOutOfRangeException();
        StreamConverter converter = new(array);
        converter.Write(__0);
        converter.Write(title);
        converter.Write(__18);
        converter.Write(__1c);
        converter.Write(__20);
        converter.Write(__58);

        converter.Write(cityArray);
        converter.Write(gatePortArray);
        converter.Write(provinceArray);
        converter.Write(regionArray);

        converter.Seek(0x41ca, SeekOrigin.Begin);
        converter.Write(titleArray);
        converter.Write(rankArray);

        converter.Seek(0x7664, SeekOrigin.Begin);
        converter.Write(techArray);
    }
}
