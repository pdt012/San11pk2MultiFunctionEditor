using kmfe.utils.bytesConverter;

namespace kmfe.s11.scenario;

using int16 = Int16;
using uint16 = UInt16;
using int8 = SByte;
using uint8 = Byte;


public class Pos : IBytesConvertable
{
    public uint16 x;
    public uint16 y;

    public const int Size = 4;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Read(out x);
        converter.Read(out y);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Write(x);
        converter.Write(y);
    }
}

/// <summary>
/// 势力介绍
/// </summary>
public class ForceDesc : IBytesConvertable
{
    public uint8 difficulty;
    public readonly byte[] desc = new byte[311];

    public const int Size = 312;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Read(out difficulty);
        converter.Read(desc);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Write(difficulty);
        converter.Write(desc);
    }
}

/// <summary>
/// 建筑
/// </summary>
public class Building : IBytesConvertable
{
    public uint8 type;                  // 类型
    public int8 force_id;               // 势力id
    public uint16 hp;                   // 耐久
    readonly byte[] __4 = new byte[9];  // 未知
    public Pos position = new();        // 坐标
    int8 __11;                          // 未知

    public const int Size = 18;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Read(out type);
        converter.Read(out force_id);
        converter.Read(out hp);
        converter.Read(__4);
        converter.Read(position);
        converter.Read(out __11);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Write(type);
        converter.Write(force_id);
        converter.Write(hp);
        converter.Write(__4);
        converter.Write(position);
        converter.Write(__11);
    }
}

/// <summary>
/// 武将
/// </summary>
public class Person : IBytesConvertable
{
    public readonly byte[] family_name = new byte[5];   // 0 姓
    public readonly byte[] given_name = new byte[5];    // 5 名
    public readonly byte[] courtecy_name = new byte[5]; // 9 字
    public readonly byte[] name_read = new byte[25];    // e 姓名读音
    public readonly byte[] zi_read = new byte[13];      // 28 字读音
    public int16 picture = 100;         // 35 头像
    public int8 gender;                    // 37 性别
    public uint16 appearance;           // 38 登场年
    public uint16 birth;                // 3a 出生年
    public uint16 death;                // 3c 死亡年
    public int8 cause_of_death;         // 3e 死因
    public int16 ancestry;              // 3f 血缘
    public int16 father;                // 41 父亲
    public int16 mother;                // 43 母亲
    public int8 generation;             // 45 世代
    public int16 spouse;                // 46 配偶
    public int16 brother;               // 48 义兄
    public uint8 xiangXing;             // 4a 相性
    public readonly int16[] liked = new int16[5];       // 4b 亲爱武将
    public readonly int16[] disliked = new int16[5];    // 55 厌恶武将
    public int8 district;               // 5f 军团
    public int16 service;               // 60 所属
    public int16 location;              // 62 所在
    public int8 identity;               // 64 身份
    public int8 rank;                   // 65 官职
    public int16 reserved_king;         // 66 预定君主
    public uint8 loyalty;               // 68 忠诚
    public uint16 merits;               // 69 功绩
    public readonly uint8[] army_level = new uint8[6];  // 6b 适性
    public readonly uint8[] base_stat = new uint8[5];   // 71 基础能力
    public readonly int8[] stat_aging = new int8[5];    // 76 能力成长
    public int8 birthplace;             // 7b 出生地
    public int8 skill;                  // 7c 特技
    public int8 argue_topic;              // 7d 舌战话题
    public int8 loyal_mind;             // 7e 义理
    public int8 ambition;               // 7f 野心
    public int8 qiYong;                 // 80 起用
    public int8 character;              // 81 性格
    public int8 voice;                  // 82 声音
    public int8 tone;                   // 83 语气
    public int8 attitude_to_Han;          // 84 汉室态度
    public int8 strategic_tendency;       // 85 战略倾向
    public int8 local_affiliation;      // 86 地域执着
    public readonly int8[] model = new int8[12];        // 87 模型
    public int8 old_age;                // 93 头像变更年龄
    public int flag_argue_skill;        // 94 舌战特技（愤怒|镇静|无视|诡辩|大喝）

    public const int Size = 152;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Read(family_name);
        converter.Read(given_name);
        converter.Read(courtecy_name);
        converter.Read(name_read);
        converter.Read(zi_read);
        converter.Read(out picture);
        converter.Read(out gender);
        converter.Read(out appearance);
        converter.Read(out birth);
        converter.Read(out death);
        converter.Read(out cause_of_death);
        converter.Read(out ancestry);
        converter.Read(out father);
        converter.Read(out mother);
        converter.Read(out generation);
        converter.Read(out spouse);
        converter.Read(out brother);
        converter.Read(out xiangXing);
        for (int i = 0; i < liked.Length; i++)
        {
            converter.Read(out liked[i]);
        }
        for (int i = 0; i < disliked.Length; i++)
        {
            converter.Read(out disliked[i]);
        }
        converter.Read(out district);
        converter.Read(out service);
        converter.Read(out location);
        converter.Read(out identity);
        converter.Read(out rank);
        converter.Read(out reserved_king);
        converter.Read(out loyalty);
        converter.Read(out merits);
        converter.Read(army_level);
        converter.Read(base_stat);
        converter.Read(stat_aging);
        converter.Read(out birthplace);
        converter.Read(out skill);
        converter.Read(out argue_topic);
        converter.Read(out loyal_mind);
        converter.Read(out ambition);
        converter.Read(out qiYong);
        converter.Read(out character);
        converter.Read(out voice);
        converter.Read(out tone);
        converter.Read(out attitude_to_Han);
        converter.Read(out strategic_tendency);
        converter.Read(out local_affiliation);
        converter.Read(model);
        converter.Read(out old_age);
        converter.Read(out flag_argue_skill);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array); converter.Write(family_name);
        converter.Write(given_name);
        converter.Write(courtecy_name);
        converter.Write(name_read);
        converter.Write(zi_read);
        converter.Write(picture);
        converter.Write(gender);
        converter.Write(appearance);
        converter.Write(birth);
        converter.Write(death);
        converter.Write(cause_of_death);
        converter.Write(ancestry);
        converter.Write(father);
        converter.Write(mother);
        converter.Write(generation);
        converter.Write(spouse);
        converter.Write(brother);
        converter.Write(xiangXing);
        for (int i = 0; i < liked.Length; i++)
        {
            converter.Write(liked[i]);
        }
        for (int i = 0; i < disliked.Length; i++)
        {
            converter.Write(disliked[i]);
        }
        converter.Write(district);
        converter.Write(service);
        converter.Write(location);
        converter.Write(identity);
        converter.Write(rank);
        converter.Write(reserved_king);
        converter.Write(loyalty);
        converter.Write(merits);
        converter.Write(army_level);
        converter.Write(base_stat);
        converter.Write(stat_aging);
        converter.Write(birthplace);
        converter.Write(skill);
        converter.Write(argue_topic);
        converter.Write(loyal_mind);
        converter.Write(ambition);
        converter.Write(qiYong);
        converter.Write(character);
        converter.Write(voice);
        converter.Write(tone);
        converter.Write(attitude_to_Han);
        converter.Write(strategic_tendency);
        converter.Write(local_affiliation);
        converter.Write(model);
        converter.Write(old_age);
        converter.Write(flag_argue_skill);
    }
};

/// <summary>
/// 宝物
/// </summary>
public class Treasure : IBytesConvertable
{
    public readonly byte[] name = new byte[13];
    public readonly byte[] read = new byte[37];
    public int8 type;
    public uint8 worth;
    public int8 image;
    public int16 owner;
    public int8 location;
    public uint8 state;

    public const int Size = 57;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Read(name);
        converter.Read(read);
        converter.Read(out type);
        converter.Read(out worth);
        converter.Read(out image);
        converter.Read(out owner);
        converter.Read(out location);
        converter.Read(out state);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Write(name);
        converter.Write(read);
        converter.Write(type);
        converter.Write(worth);
        converter.Write(image);
        converter.Write(owner);
        converter.Write(location);
        converter.Write(state);
    }
};

/// <summary>
/// 势力
/// </summary>
public class Force : IBytesConvertable
{
    public int16 king;
    public int16 counsellor;
    public readonly int8[] diplomacy = new int8[47];
    public uint8 title;
    public int8 guoHao;
    public uint8 color;
    public int8 policy;
    public int8 target;
    public readonly uint8[] alliance = new uint8[6];
    readonly byte[] __3e = new byte[2];
    public readonly int8[] technology = new int8[5];
    readonly byte[] __45 = new byte[3];

    public const int Size = 72;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
    }
};

/// <summary>
/// 军团
/// </summary>
public class District : IBytesConvertable
{
    public int8 force_id;
    public int8 number;
    public int16 governor;
    public uint8 policy;
    public int8 target;
    public uint8 plan;
    public int8 __7;

    public const int Size = 8;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
    }
};

/// <summary>
/// 城市
/// </summary>
public class City : IBytesConvertable
{
    public int8 district_id;        // 军团id
    public int maxroops;            // 最大兵力
    public int troops;              // 兵力
    public int gold;                // 金钱	
    public int food;                // 兵粮

    public readonly int[] weapons = new int[12];        // 装备
    public uint8 xiangChang;        // 相场
    public bool merchant;           // 商人
    public uint16 gold_income;      // 金收入
    public uint16 food_income;      // 粮收入
    public uint16 max_hp;           // 最大耐久
    public uint8 energy;            // 气力
    public uint8 public_order;      // 治安
    public readonly bool[] speciality = new bool[6];    // 特产

    public const int Size = 81;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
    }
};

/// <summary>
/// 港关
/// </summary>
public class GatePort : IBytesConvertable
{
    public int8 district_id;        // 军团id
    public int troops;              // 兵力
    public int gold;                // 金钱	
    public int food;                // 兵粮
    public readonly int[] weapons = new int[12];    // 装备
    public uint8 energy;            // 气力
    public uint16 max_hp;           // 最大耐久

    public const int Size = 64;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
    }
};

/// <summary>
/// 国
/// </summary>
public class Country : IBytesConvertable
{
    public readonly byte[] name = new byte[5];
    public readonly byte[] read = new byte[13];
    public readonly byte[] desc = new byte[63];
    public int8 __51;
    public int8 __52;
    public int8 __53;
    readonly byte[] __54 = new byte[3];

    public const int Size = 87;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
    }
};

/// <summary>
/// 剧本
/// </summary>
public class Scenario : IBytesConvertable
{
    readonly byte[] __0 = new byte[8];              // (hex) 未知
    readonly byte[] __title = new byte[16];         // 8 KOEI%SAN11
    int __18;                                       // 18 未知
    int __1c;                                       // 1c 未知
    readonly byte[] __20 = new byte[56];            // 20 未知
    int16 __58;                                     // 58 未知
    public uint8 header_scenario_number;            // 剧本编号
    public uint16 header_start_year;                // 开始年
    public uint8 header_start_month;                // 开始月
    public uint8 header_start_day;                  // 开始日

    public readonly byte[] scenario_name = new byte[17];        // 剧本名称
    public readonly byte[] scenario_desc = new byte[306];       // 剧本介绍
    public readonly uint8[] city_force_color = new uint8[42];   // 城市势力色
    public readonly Pos[] city_init_pos = new Pos[42];          // 剧本页城市坐标
    public readonly ForceDesc[] force_desc = new ForceDesc[42]; // 势力介绍
    public uint8 scenario_number;                               // 剧本编号
    public uint16 start_year;                                   // 开始年
    public uint8 start_month;                                   // 开始月
    public uint8 start_day;                                     // 开始日
    public int16 emperor;                                       // 皇帝
    public bool flag_age;                                       // 年龄变动
    readonly byte[] __35ac = new byte[3];                       // 35ac 未知

    public readonly Building[] buildingArray = new Building[87];    // 建筑
    public readonly Person[] personArray = new Person[850];         // 武将
    public readonly Treasure[] treasureArray = new Treasure[100];   // 宝物
    public readonly Force[] forceArray = new Force[47];             // 势力
    public readonly District[] districtArray = new District[47];    // 军团
    public readonly City[] cityArray = new City[42];                // 城市
    public readonly GatePort[] gatePortArray = new GatePort[45];    // 港关
    public readonly Country[] countryArray = new Country[84];       // 国

    public const int Size = 167559;

    int IBytesConvertable.Size => Size;

    public void FromBytes(byte[] array)
    {
        StreamConverter converter = new(array);
        converter.Read(__0);
        converter.Read(__title);
        converter.Read(out __18);
        converter.Read(out __1c);
        converter.Read(__20);
        converter.Read(out __58);
        converter.Read(out header_scenario_number);
        converter.Read(out header_start_year);
        converter.Read(out header_start_month);
        converter.Read(out header_start_day);

        converter.Read(scenario_name);
        converter.Read(scenario_desc);
        converter.Read(city_force_color);
        converter.Read(city_init_pos);
        converter.Read(force_desc);
        converter.Read(out scenario_number);
        converter.Read(out start_year);
        converter.Read(out start_month);
        converter.Read(out start_day);
        converter.Read(out emperor);
        converter.Read(out flag_age);
        converter.Read(__35ac);

        converter.Read(buildingArray);
        converter.Read(personArray);
        converter.Read(treasureArray);
        converter.Read(forceArray);
        converter.Read(districtArray);
        converter.Read(cityArray);
        converter.Read(gatePortArray);
        converter.Read(countryArray);
    }

    public void ToBytes(ref byte[] array)
    {
        StreamConverter converter = new(array);
    }

};
