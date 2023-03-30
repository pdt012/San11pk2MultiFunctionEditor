using kmfe.utils.bytesConverter;
using System;

namespace kmfe.s11.scenario
{
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
            StreamConverter converter = new StreamConverter(array);
            converter.Read(out x);
            converter.Read(out y);
        }

        public void ToBytes(ref byte[] array)
        {
            StreamConverter converter = new StreamConverter(array);
            converter.Write(x);
            converter.Write(y);
        }
    }

    public class ForceDesc : IBytesConvertable
    {
        public uint8 difficulty;
        public readonly byte[] desc = new byte[311];

        public const int Size = 312;

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            StreamConverter converter = new StreamConverter(array);
            converter.Read(out difficulty);
            converter.Read(desc);
        }

        public void ToBytes(ref byte[] array)
        {
            StreamConverter converter = new StreamConverter(array);
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
        public Pos position = new Pos();    // 坐标
        int8 __11;                          // 未知

        public const int Size = 18;

        int IBytesConvertable.Size => Size;

        public void FromBytes(byte[] array)
        {
            StreamConverter converter = new StreamConverter(array);
            converter.Read(out type);
            converter.Read(out force_id);
            converter.Read(out hp);
            converter.Read(__4);
            converter.Read(position);
            converter.Read(out __11);
        }

        public void ToBytes(ref byte[] array)
        {
            StreamConverter converter = new StreamConverter(array);
            converter.Write(type);
            converter.Write(force_id);
            converter.Write(hp);
            converter.Write(__4);
            converter.Write(position);
            converter.Write(__11);
        }
    }

    #region TODO
#if false
/// <summary>
/// 武将
/// </summary>
public class Person
{
    char family_name[5];            // 0 姓
    char given_name[5];             // 5 名
    char courtecy_name[5];          // 9 字
    char name_read[25];             // e 姓名读音
    char zi_read[13];               // 28 字读音
    int16_t picture = 100;          // 35 头像
    int8_t sex;                     // 37 性别
    uint16_t appearance;            // 38 登场年
    uint16_t birth;                 // 3a 出生年
    uint16_t death;                 // 3c 死亡年
    int8_t cause_of_death;          // 3e 死因
    int16_t ancestry;               // 3f 血缘
    int16_t father;                 // 41 父亲
    int16_t mother;                 // 43 母亲
    int8_t generation;              // 45 世代
    int16_t spouse;                 // 46 配偶
    int16_t brother;                // 48 义兄
    uint8_t xiangXing;              // 4a 相性
    int16_t liked[5];               // 4b 亲爱武将
    int16_t disliked[5];            // 55 厌恶武将
    int8_t district;                // 5f 军团
    int16_t service;                // 60 所属
    int16_t location;               // 62 所在
    int8_t identity;                // 64 身份
    int8_t rank;                    // 65 官职
    int16_t reserved_king;          // 66 预定君主
    uint8_t loyalty;                // 68 忠诚
    uint16_t merits;                // 69 功绩
    uint8_t army_level[6];          // 6b 适性
    uint8_t base_stat[5];           // 71 基础能力
    int8_t stat_aging[5];           // 76 能力成长
    int8_t birthplace;              // 7b 出生地
    uint8_t skill;                  // 7c 特技
    int8_t argue_topic;             // 7d 舌战话题
    int8_t loyal_mind;              // 7e 义理
    int8_t ambition;                // 7f 野心
    int8_t qiYong;                  // 80 起用
    int8_t character;               // 81 性格
    int8_t voice;                   // 82 声音
    int8_t tone;                    // 83 语气
    int8_t attitude_to_Han;         // 84 汉室态度
    int8_t strategic_tendency;      // 85 战略倾向
    int8_t local_affiliation;       // 86 地域执着

    int8_t skeleton;                // 87 造型骨架
    int8_t head;                    // 头部
    int8_t face;                    // 面部
    int8_t upper_body;              // 上身
    int8_t cloak;                   // 披风
    int8_t wrister;                 // 护腕
    int8_t lower_body;              // 下身
    int8_t dorlach;                 // 箭袋
    int8_t other_parts;             // 其他
    int8_t left_weapon;             // 左手武器
    int8_t right_weapon;            // 右手武器
    int8_t horse;                   // 马匹

    int8_t old_age;                 // 93 头像变更年龄
    int flag_argue_skill;           // 94 舌战特技（愤怒|镇静|无视|诡辩|大喝）
};
struct Item
{
    char name[13];
    char read[37];
    int8_t type;
    uint8_t worth;
    int8_t CG;
    int16_t owner;
    int8_t location;
    int8_t state;
};

struct Force
{
    int16_t king;
    int16_t counsellor;
    int8_t diplomacy[47];
    uint8_t title;
    int8_t guoHao;
    uint8_t color;
    int8_t policy;
    int8_t target;
    uint8_t alliance[6];
    int8_t _ip_3e[2];
    int8_t technology[5];
    int8_t _ip_45[3];
};

struct District
{
    int8_t force_id;
    int8_t number;
    int16_t governor;
    uint8_t policy;
    int8_t target;
    uint8_t plan;
    int8_t _ip_7;
};

struct City
{
    int8_t district_id;     // 军团id
    int max_troops;         // 最大兵力
    int troops;             // 兵力
    int gold;               // 金钱	
    int food;               // 兵粮

    int weapons[12];        // 装备
    uint8_t xiangChang;     // 相场
    bool merchant;          // 商人
    uint16_t gold_income;   // 金收入
    uint16_t food_income;   // 粮收入
    uint16_t max_hp;        // 最大耐久
    uint8_t energy;         // 气力
    uint8_t public_order;   // 治安
    bool speciality[6];     // 特产
};

struct Town
{
    int8_t district_id; // 军团id
    int troops;             // 兵力
    int gold;               // 金钱	
    int food;               // 兵粮
    int weapons[12];        // 装备
    uint8_t energy;         // 气力
    uint16_t max_hp;        // 最大耐久
};

struct Gate : Town
{
			;
		};

struct Port : Town
{
			;
		};

struct Country
{
    char name[5];
    char read[13];
    char desc[63];
    int8_t _ip_51;
    int8_t _ip_52;
    int8_t _ip_53;
    char _ip_54[3];
};
#endif
    #endregion

    public class Scenario
    {
        public readonly byte[] __0 = new byte[8];       // (hex) 未知
        public readonly byte[] title = new byte[16];    // 8 KOEI%SAN11
        int __18;                                       // 18 未知
        int __1c;                                       // 1c 未知
        public readonly byte[] __20 = new byte[56];     // 20 未知
        int16 __58;                                     // 58 未知

        public uint8 header_number;                     // 剧本编号
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
        public uint8 flag_age;                                      // 年龄变动
        readonly byte[] __35ac = new byte[3];                       // 35ac 未知

        public readonly Building[] buildingArray = new Building[87];    // 建筑
                                                                        //public readonly Person[] person = new Person[850];
                                                                        //public readonly Item[] item = new Item[100];
                                                                        //public readonly Force[] force = new Force[47];
                                                                        //public readonly District[] district = new District[47];
                                                                        //public readonly City[] city = new City[42];
                                                                        //public readonly Gate[] gate = new Gate[10];
                                                                        //public readonly Port[] port = new Port[35];
                                                                        //public readonly Country[] country = new Country[84];

        //readonly byte[] __tail = new byte[377];

    };
}