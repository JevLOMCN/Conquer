using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer;

public class Settings
{
    public static Settings Default = new Settings();

    private static readonly JsonSerializerSettings JsonSettings;

    static Settings()
    {
        JsonSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };
    }


    [JsonIgnore]
    public const string SettingFile = "!Settings.txt";

    [JsonIgnore]
    public int CurrentVersion = 10;

    public bool SendPacketsAsync = true;

    public string 系统公告内容 = string.Empty;
    public string GameDataPath = "..\\Database";
    public string DataBackupPath = ".\\Backup";
    public string UserConnectionIP = "127.0.0.1";
    public ushort UserConnectionPort = 8701;
    public ushort TicketReceivePort = 6678;
    public ushort StatusPort = 3000;
    public ushort PacketLimit = 100;
    public ushort AbnormalBlockTime = 5;
    public ushort DisconnectTime = 5;
    public ushort StatusPortDisconnectTime = 10;
    public byte MaxUserLevel = 40;
    public byte NoobSupportLevel = 0;
    public decimal SpecialRepairDiscount = 1;
    public decimal ItemDropRate = 0;
    public decimal MonsterExperienceMultiplier = 1;
    public ushort 减收益等级差 = 10;
    public decimal 收益减少比率 = 0.1M;
    public ushort 怪物诱惑时长 = 120;
    public ushort 物品归属时间 = 3;
    public ushort ItemDisappearTime = 5;
    public ushort AutoSaveInterval = 30;
    public ushort 自动保存日志 = 45;
    public byte 武斗场时间一 = 13;
    public byte 武斗场时间二 = 19;
    public int 武斗场经验小 = 10_000;
    public int 武斗场经验大 = 50_000;
    public byte 沙巴克开启 = 20;
    public byte 沙巴克结束 = 21;
    public int 沃玛分解元宝 = 100;
    public int 祖玛分解元宝 = 200;
    public int 赤月分解元宝 = 300;
    public int 魔龙分解元宝 = 400;
    public int 苍月分解元宝 = 500;
    public int 星王分解元宝 = 600;
    public int 城主分解元宝 = 700;
    public int 神秘分解元宝 = 800;
    public int 屠魔组队人数 = 2;
    public int 屠魔令回收经验 = 1_000_000;
    public int 屠魔副本次数 = 2;
    public int 屠魔爆率开关 = 0;
    public int 祝福油幸运1机率 = 80;
    public int 祝福油幸运2机率 = 15;
    public int 祝福油幸运3机率 = 10;
    public int 祝福油幸运4机率 = 8;
    public int 祝福油幸运5机率 = 5;
    public int 祝福油幸运6机率 = 3;
    public int 祝福油幸运7机率 = 1;
    public int PKYellowNamePoint = 100;
    public int PKRedNamePoint = 300;
    public int PKCrimsonNamePoint = 800;
    public int 锻造成功倍数 = 1;
    public float 死亡掉落背包几率 = 0.01F;
    public float 死亡掉落身上几率 = 0.01F;
    public int PK死亡幸运开关 = 1;

    public int[] UserUpgradeXP = new int[100]
    {
        100,
        200,
        300,
        400,
        600,
        900,
        1_200,
        1_700,
        2_500,
        6_000,
        8_000,
        10_000,
        15_000,
        30_000,
        40_000,
        50_000,
        70_000,
        100_000,
        120_000,
        140_000,
        250_000,
        300_000,
        350_000,
        400_000,
        500_000,
        700_000,
        1_000_000,
        1_400_000,
        1_800_000,
        2_000_000,
        2_400_000,
        2_800_000,
        3_200_000,
        3_600_000,
        4_000_000,
        4_800_000,
        5_600_000,
        8_200_000,
        9_000_000,
        12_000_000,
        16_000_000,
        30_000_000,
        50_000_000,
        80_000_000,
        120_000_000,
        280_000_000,
        360_000_000,
        400_000_000,
        420_000_000,
        430_000_000,
        440_000_000,
        460_000_000,
        480_000_000,
        500_000_000,
        520_000_000,
        550_000_000,
        600_000_000,
        700_000_000,
        800_000_000,
        900_000_000,
        1_200_000_000,
        1_200_000_000,
        1_200_000_000,
        1_200_000_000,
        1_200_000_000,
        1_800_000_000,
        1_800_000_000,
        1_800_000_000,
        1_800_000_000,
        1_800_000_000,
        2_000_000_000,
        2_000_000_000,
        2_000_000_000,
        2_000_000_000,
        2_000_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000,
        2_100_000_000
    };

    public int 高级祝福油幸运机率 = 80;
    public int 雕爷使用物品 = 90235;
    public int 雕爷使用金币 = 10000;
    public int 称号范围拾取判断 = 131;
    public int TitleRangePickUpDistance = 10;
    public int 行会申请人数限制 = 20;
    public int 疗伤药HP = 110;
    public int 疗伤药MP = 160;
    public int 万年雪霜HP = 75;
    public int 万年雪霜MP = 110;
    public int 元宝金币回收设定 = 0;
    public int 元宝金币传送设定 = 0;
    public int 快捷传送一编号 = 101;
    public int 快捷传送一货币 = 100_000;
    public int 快捷传送一等级 = 1;
    public int 快捷传送二编号 = 101;
    public int 快捷传送二货币 = 100_000;
    public int 快捷传送二等级 = 1;
    public int 快捷传送三编号 = 101;
    public int 快捷传送三货币 = 100_000;
    public int 快捷传送三等级 = 1;
    public int 快捷传送四编号 = 101;
    public int 快捷传送四货币 = 100_000;
    public int 快捷传送四等级 = 1;
    public int 快捷传送五编号 = 101;
    public int 快捷传送五货币 = 100_000;
    public int 快捷传送五等级 = 1;
    public int 狂暴货币格式 = 1;
    public byte 狂暴称号格式 = 135;
    public int 狂暴开启物品名称 = 91730;
    public int 狂暴开启物品数量 = 20;
    public int 狂暴杀死物品数量 = 10;
    public int 狂暴开启元宝数量 = 100_000;
    public int 狂暴杀死元宝数量 = 50_000;
    public int 狂暴开启金币数量 = 100_000;
    public int 狂暴杀死金币数量 = 50_000;
    public string 狂暴名称 = "龍纹兑换石";
    public int 装备技能开关 = 0;
    public int 御兽属性开启 = 0;
    public int 可摆摊地图编号 = 147;
    public int 可摆摊地图坐标X = 935;
    public int 可摆摊地图坐标Y = 522;
    public int 可摆摊地图范围 = 10;
    public int 可摆摊货币选择 = 0;
    public int 可摆摊等级 = 7;
    public int ReviveInterval = 60;
    public float 自定义麻痹几率 = 0.01F;
    public ushort[] PetUpgradeXP =
    {
        5, 10, 15, 20, 25, 30, 35, 40, 45
    };
    public int 下马击落机率 = 100;
    public int AllowRaceWarrior = 1;
    public int AllowRaceWizard = 1;
    public int AllowRaceTaoist = 1;
    public int AllowRaceArcher = 1;
    public int AllowRaceAssassin = 1;
    public int AllowRaceDragonLance = 1;
    public int 泡点等级开关 = 0;
    public int 泡点当前经验 = 1000;
    public int 泡点限制等级 = 40;
    public int 泡点秒数控制 = 1;
    public int 杀人PK红名开关 = 0;
    public int MaxAwakeningExp = 2_100_000_000;
    public string 自定义物品内容一 = "自定义物品一";
    public string 自定义物品内容二 = "自定义物品二";
    public string 自定义物品内容三 = "自定义物品三";
    public string 自定义物品内容四 = "自定义物品四";
    public string 自定义物品内容五 = "自定义物品五";
    public int 自定义物品数量一 = 10;
    public int 自定义物品数量二 = 10;
    public int 自定义物品数量三 = 10;
    public int 自定义物品数量四 = 10;
    public int 自定义物品数量五 = 10;
    public byte 自定义称号内容一 = 101;
    public byte 自定义称号内容二 = 101;
    public byte 自定义称号内容三 = 101;
    public byte 自定义称号内容四 = 101;
    public byte 自定义称号内容五 = 101;
    public int 元宝金币传送设定2 = 0;
    public int 快捷传送一编号2 = 101;
    public int 快捷传送一货币2 = 100_000;
    public int 快捷传送一等级2 = 1;
    public int 快捷传送二编号2 = 101;
    public int 快捷传送二货币2 = 100_000;
    public int 快捷传送二等级2 = 1;
    public int 快捷传送三编号2 = 101;
    public int 快捷传送三货币2 = 100_000;
    public int 快捷传送三等级2 = 1;
    public int 快捷传送四编号2 = 101;
    public int 快捷传送四货币2 = 100_000;
    public int 快捷传送四等级2 = 1;
    public int 快捷传送五编号2 = 101;
    public int 快捷传送五货币2 = 100_000;
    public int 快捷传送五等级2 = 1;
    public int 快捷传送六编号2 = 101;
    public int 快捷传送六货币2 = 100_000;
    public int 快捷传送六等级2 = 1;
    public int 未知暗点副本价格 = 100_000;
    public int 未知暗点副本等级 = 45;
    public int 未知暗点二层价格 = 100_000;
    public int 未知暗点二层等级 = 45;
    public int 幽冥海副本价格 = 100_000;
    public int 幽冥海副本等级 = 45;
    public int 武斗场次数限制 = 1;
    public int AutoPickUpInventorySpace = 6;
    public int BOSS刷新提示开关 = 0;
    public int 自动整理背包计时 = 1;
    public int 自动整理背包开关 = 0;
    public int 称号叠加开关 = 0;
    public byte 称号叠加模块一 = 0;
    public byte 称号叠加模块二 = 0;
    public byte 称号叠加模块三 = 0;
    public byte 称号叠加模块四 = 0;
    public byte 称号叠加模块五 = 0;
    public byte 称号叠加模块六 = 0;
    public byte 称号叠加模块七 = 0;
    public byte 称号叠加模块八 = 0;
    public int 沙城传送货币开关 = 0;
    public int 沙城快捷货币一 = 100_000;
    public int 沙城快捷等级一 = 45;
    public int 沙城快捷货币二 = 100_000;
    public int 沙城快捷等级二 = 45;
    public int 沙城快捷货币三 = 100_000;
    public int 沙城快捷等级三 = 45;
    public int 沙城快捷货币四 = 100_000;
    public int 沙城快捷等级四 = 45;
    public byte 猎魔暗使称号一 = 99;
    public int 猎魔暗使材料一 = 111023;
    public int 猎魔暗使数量一 = 500;
    public byte 猎魔暗使称号二 = 102;
    public int 猎魔暗使材料二 = 111025;
    public int 猎魔暗使数量二 = 500;
    public byte 猎魔暗使称号三 = 107;
    public int 猎魔暗使材料三 = 111027;
    public int 猎魔暗使数量三 = 500;
    public byte 猎魔暗使称号四 = 59;
    public int 猎魔暗使材料四 = 90220;
    public int 猎魔暗使数量四 = 500;
    public byte 猎魔暗使称号五 = 138;
    public int 猎魔暗使材料五 = 90228;
    public int 猎魔暗使数量五 = 500;
    public byte 猎魔暗使称号六 = 60;
    public int 猎魔暗使材料六 = 90236;
    public int 猎魔暗使数量六 = 500;
    public int 怪物掉落广播开关 = 1;
    public int 怪物掉落窗口开关 = 0;
    public int 珍宝阁提示开关 = 1;
    public string 祖玛分解物品一 = "屠魔令";
    public string 祖玛分解物品二 = "天书残页";
    public string 祖玛分解物品三 = "装备碎片";
    public string 祖玛分解物品四 = "龍纹兑换石";
    public int 祖玛分解几率一 = 70;
    public int 祖玛分解几率二 = 85;
    public int 祖玛分解几率三 = 95;
    public int 祖玛分解几率四 = 100;
    public int 祖玛分解数量一 = 1;
    public int 祖玛分解数量二 = 1;
    public int 祖玛分解数量三 = 1;
    public int 祖玛分解数量四 = 1;
    public int 祖玛分解开关 = 3;
    public string 赤月分解物品一 = "屠魔令";
    public string 赤月分解物品二 = "天书残页";
    public string 赤月分解物品三 = "装备碎片";
    public string 赤月分解物品四 = "龍纹兑换石";
    public int 赤月分解几率一 = 70;
    public int 赤月分解几率二 = 85;
    public int 赤月分解几率三 = 95;
    public int 赤月分解几率四 = 100;
    public int 赤月分解数量一 = 1;
    public int 赤月分解数量二 = 1;
    public int 赤月分解数量三 = 1;
    public int 赤月分解数量四 = 1;
    public int 赤月分解开关 = 3;
    public string 魔龙分解物品一 = "屠魔令";
    public string 魔龙分解物品二 = "天书残页";
    public string 魔龙分解物品三 = "装备碎片";
    public string 魔龙分解物品四 = "龍纹兑换石";
    public int 魔龙分解几率一 = 70;
    public int 魔龙分解几率二 = 85;
    public int 魔龙分解几率三 = 95;
    public int 魔龙分解几率四 = 100;
    public int 魔龙分解数量一 = 1;
    public int 魔龙分解数量二 = 1;
    public int 魔龙分解数量三 = 1;
    public int 魔龙分解数量四 = 1;
    public int 魔龙分解开关 = 3;
    public string 苍月分解物品一 = "屠魔令";
    public string 苍月分解物品二 = "天书残页";
    public string 苍月分解物品三 = "装备碎片";
    public string 苍月分解物品四 = "龍纹兑换石";
    public int 苍月分解几率一 = 70;
    public int 苍月分解几率二 = 85;
    public int 苍月分解几率三 = 95;
    public int 苍月分解几率四 = 100;
    public int 苍月分解数量一 = 1;
    public int 苍月分解数量二 = 1;
    public int 苍月分解数量三 = 1;
    public int 苍月分解数量四 = 1;
    public int 苍月分解开关 = 3;
    public string 星王分解物品一 = "屠魔令";
    public string 星王分解物品二 = "天书残页";
    public string 星王分解物品三 = "装备碎片";
    public string 星王分解物品四 = "龍纹兑换石";
    public int 星王分解几率一 = 70;
    public int 星王分解几率二 = 85;
    public int 星王分解几率三 = 95;
    public int 星王分解几率四 = 100;
    public int 星王分解数量一 = 1;
    public int 星王分解数量二 = 1;
    public int 星王分解数量三 = 1;
    public int 星王分解数量四 = 1;
    public int 星王分解开关 = 3;
    public string 城主分解物品一 = "屠魔令";
    public string 城主分解物品二 = "天书残页";
    public string 城主分解物品三 = "装备碎片";
    public string 城主分解物品四 = "龍纹兑换石";
    public int 城主分解几率一 = 70;
    public int 城主分解几率二 = 85;
    public int 城主分解几率三 = 95;
    public int 城主分解几率四 = 100;
    public int 城主分解数量一 = 1;
    public int 城主分解数量二 = 1;
    public int 城主分解数量三 = 1;
    public int 城主分解数量四 = 1;
    public int 城主分解开关 = 3;
    public string 沃玛分解物品一 = "屠魔令";
    public string 沃玛分解物品二 = "天书残页";
    public string 沃玛分解物品三 = "装备碎片";
    public string 沃玛分解物品四 = "龍纹兑换石";
    public int 沃玛分解几率一 = 70;
    public int 沃玛分解几率二 = 85;
    public int 沃玛分解几率三 = 95;
    public int 沃玛分解几率四 = 100;
    public int 沃玛分解数量一 = 1;
    public int 沃玛分解数量二 = 1;
    public int 沃玛分解数量三 = 1;
    public int 沃玛分解数量四 = 1;
    public int 沃玛分解开关 = 3;
    public string 其他分解物品一 = "屠魔令";
    public string 其他分解物品二 = "天书残页";
    public string 其他分解物品三 = "装备碎片";
    public string 其他分解物品四 = "龍纹兑换石";
    public int 其他分解几率一 = 70;
    public int 其他分解几率二 = 85;
    public int 其他分解几率三 = 95;
    public int 其他分解几率四 = 100;
    public int 其他分解数量一 = 1;
    public int 其他分解数量二 = 1;
    public int 其他分解数量三 = 1;
    public int 其他分解数量四 = 1;
    public int 其他分解开关 = 3;
    public string BOSS卷轴怪物一 = "牛魔王";
    public string BOSS卷轴怪物二 = "黄泉教主";
    public string BOSS卷轴怪物三 = "魔龙教主";
    public string BOSS卷轴怪物四 = "血手";
    public string BOSS卷轴怪物五 = "魔火龙";
    public string BOSS卷轴怪物六 = "赤月恶魔";
    public int BOSS卷轴地图编号 = 147;
    public int BOSS卷轴地图开关 = 0;
    public int 资源包开关 = 0;
    public byte StartingLevel = 1;
    public string BOSS卷轴怪物七 = "牛魔王";
    public string BOSS卷轴怪物八 = "牛魔王";
    public string BOSS卷轴怪物九 = "牛魔王";
    public string BOSS卷轴怪物十 = "牛魔王";
    public string BOSS卷轴怪物11 = "牛魔王";
    public string BOSS卷轴怪物12 = "牛魔王";
    public string BOSS卷轴怪物13 = "牛魔王";
    public string BOSS卷轴怪物14 = "牛魔王";
    public string BOSS卷轴怪物15 = "牛魔王";
    public string BOSS卷轴怪物16 = "牛魔王";
    public int 掉落贵重物品颜色 = 0;
    public int 掉落沃玛物品颜色 = 0;
    public int 掉落祖玛物品颜色 = 0;
    public int 掉落赤月物品颜色 = 0;
    public int 掉落魔龙物品颜色 = 0;
    public int 掉落苍月物品颜色 = 0;
    public int 掉落星王物品颜色 = 0;
    public int 掉落城主物品颜色 = 0;
    public int 掉落书籍物品颜色 = 0;
    public int DropPlayerNameColor = 0;
    public int 狂暴击杀玩家颜色 = 0;
    public int 狂暴被杀玩家颜色 = 0;
    public int 祖玛战装备佩戴数量 = 5;
    public int 祖玛法装备佩戴数量 = 5;
    public int 祖玛道装备佩戴数量 = 5;
    public int 祖玛弓装备佩戴数量 = 5;
    public int 祖玛刺装备佩戴数量 = 5;
    public int 祖玛枪装备佩戴数量 = 5;
    public int 赤月战装备佩戴数量 = 5;
    public int 赤月法装备佩戴数量 = 5;
    public int 赤月道装备佩戴数量 = 5;
    public int 赤月弓装备佩戴数量 = 5;
    public int 赤月刺装备佩戴数量 = 5;
    public int 赤月枪装备佩戴数量 = 5;
    public int 魔龙战装备佩戴数量 = 5;
    public int 魔龙法装备佩戴数量 = 5;
    public int 魔龙道装备佩戴数量 = 5;
    public int 魔龙弓装备佩戴数量 = 5;
    public int 魔龙刺装备佩戴数量 = 5;
    public int 魔龙枪装备佩戴数量 = 5;
    public int 苍月战装备佩戴数量 = 5;
    public int 苍月法装备佩戴数量 = 5;
    public int 苍月道装备佩戴数量 = 5;
    public int 苍月弓装备佩戴数量 = 5;
    public int 苍月刺装备佩戴数量 = 5;
    public int 苍月枪装备佩戴数量 = 5;
    public int 星王战装备佩戴数量 = 5;
    public int 星王法装备佩戴数量 = 5;
    public int 星王道装备佩戴数量 = 5;
    public int 星王弓装备佩戴数量 = 5;
    public int 星王刺装备佩戴数量 = 5;
    public int 星王枪装备佩戴数量 = 5;
    public int 特殊1战装备佩戴数量 = 5;
    public int 特殊1法装备佩戴数量 = 5;
    public int 特殊1道装备佩戴数量 = 5;
    public int 特殊1弓装备佩戴数量 = 5;
    public int 特殊1刺装备佩戴数量 = 5;
    public int 特殊1枪装备佩戴数量 = 5;
    public int 特殊2战装备佩戴数量 = 5;
    public int 特殊2法装备佩戴数量 = 5;
    public int 特殊2道装备佩戴数量 = 5;
    public int 特殊2弓装备佩戴数量 = 5;
    public int 特殊2刺装备佩戴数量 = 5;
    public int 特殊2枪装备佩戴数量 = 5;
    public int 特殊3战装备佩戴数量 = 5;
    public int 特殊3法装备佩戴数量 = 5;
    public int 特殊3道装备佩戴数量 = 5;
    public int 特殊3弓装备佩戴数量 = 5;
    public int 特殊3刺装备佩戴数量 = 5;
    public int 特殊3枪装备佩戴数量 = 5;
    public int 每周特惠一物品1 = 165000;
    public int 每周特惠一物品2 = 500000;
    public int 每周特惠一物品3 = 1500230;
    public int 每周特惠一物品4 = 80203;
    public int 每周特惠一物品5 = 80007;
    public int 每周特惠二物品1 = 875000;
    public int 每周特惠二物品2 = 2750000;
    public int 每周特惠二物品3 = 1500130;
    public int 每周特惠二物品4 = 91156;
    public int 每周特惠二物品5 = 80200;
    public int 新手出售货币值 = 0;
    public byte 挂机称号选项 = 0;
    public byte 分解称号选项 = 0;
    //public int 场景卡BUG清理;
    public int 法阵卡BUG清理 = 0;
    public int 随机宝箱一物品1 = 100;
    public int 随机宝箱一物品2 = 100;
    public int 随机宝箱一物品3 = 100;
    public int 随机宝箱一物品4 = 100;
    public int 随机宝箱一物品5 = 100;
    public int 随机宝箱一物品6 = 100;
    public int 随机宝箱一物品7 = 100;
    public int 随机宝箱一物品8 = 100;
    public int 随机宝箱二物品1 = 100;
    public int 随机宝箱二物品2 = 100;
    public int 随机宝箱二物品3 = 100;
    public int 随机宝箱二物品4 = 100;
    public int 随机宝箱二物品5 = 100;
    public int 随机宝箱二物品6 = 100;
    public int 随机宝箱二物品7 = 100;
    public int 随机宝箱二物品8 = 100;
    public int 随机宝箱三物品1 = 100;
    public int 随机宝箱三物品2 = 100;
    public int 随机宝箱三物品3 = 100;
    public int 随机宝箱三物品4 = 100;
    public int 随机宝箱三物品5 = 100;
    public int 随机宝箱三物品6 = 100;
    public int 随机宝箱三物品7 = 100;
    public int 随机宝箱三物品8 = 100;
    public int 随机宝箱一几率1 = 100;
    public int 随机宝箱一几率2 = 100;
    public int 随机宝箱一几率3 = 100;
    public int 随机宝箱一几率4 = 100;
    public int 随机宝箱一几率5 = 100;
    public int 随机宝箱一几率6 = 100;
    public int 随机宝箱一几率7 = 100;
    public int 随机宝箱一几率8 = 100;
    public int 随机宝箱二几率1 = 100;
    public int 随机宝箱二几率2 = 100;
    public int 随机宝箱二几率3 = 100;
    public int 随机宝箱二几率4 = 100;
    public int 随机宝箱二几率5 = 100;
    public int 随机宝箱二几率6 = 100;
    public int 随机宝箱二几率7 = 100;
    public int 随机宝箱二几率8 = 100;
    public int 随机宝箱三几率1 = 100;
    public int 随机宝箱三几率2 = 100;
    public int 随机宝箱三几率3 = 100;
    public int 随机宝箱三几率4 = 100;
    public int 随机宝箱三几率5 = 100;
    public int 随机宝箱三几率6 = 100;
    public int 随机宝箱三几率7 = 100;
    public int 随机宝箱三几率8 = 100;
    public int 随机宝箱一数量1 = 1;
    public int 随机宝箱一数量2 = 1;
    public int 随机宝箱一数量3 = 1;
    public int 随机宝箱一数量4 = 1;
    public int 随机宝箱一数量5 = 1;
    public int 随机宝箱一数量6 = 1;
    public int 随机宝箱一数量7 = 1;
    public int 随机宝箱一数量8 = 1;
    public int 随机宝箱二数量1 = 1;
    public int 随机宝箱二数量2 = 1;
    public int 随机宝箱二数量3 = 1;
    public int 随机宝箱二数量4 = 1;
    public int 随机宝箱二数量5 = 1;
    public int 随机宝箱二数量6 = 1;
    public int 随机宝箱二数量7 = 1;
    public int 随机宝箱二数量8 = 1;
    public int 随机宝箱三数量1 = 1;
    public int 随机宝箱三数量2 = 1;
    public int 随机宝箱三数量3 = 1;
    public int 随机宝箱三数量4 = 1;
    public int 随机宝箱三数量5 = 1;
    public int 随机宝箱三数量6 = 1;
    public int 随机宝箱三数量7 = 1;
    public int 随机宝箱三数量8 = 1;
    public int NoobProtectionLevel = 15;
    public int 沙城地图保护 = 45;
    public int 新手地图保护1 = 147;
    public int 新手地图保护2 = 147;
    public int 新手地图保护3 = 147;
    public int 新手地图保护4 = 147;
    public int 新手地图保护5 = 147;
    public int 新手地图保护6 = 147;
    public int 新手地图保护7 = 147;
    public int 新手地图保护8 = 147;
    public int 新手地图保护9 = 147;
    public int 新手地图保护10 = 147;
    public int 沙巴克停止开关 = 0;
    public byte 沙巴克城主称号 = 144;
    public byte 沙巴克成员称号 = 145;
    public int 沙巴克称号领取开关 = 0;
    public int 通用1装备佩戴数量 = 5;
    public int 通用2装备佩戴数量 = 5;
    public int 通用3装备佩戴数量 = 5;
    public int 通用4装备佩戴数量 = 5;
    public int 通用5装备佩戴数量 = 5;
    public int 通用6装备佩戴数量 = 5;
    public int 重置屠魔副本时间 = 23;
    public int 屠魔令回收数量 = 1000;
    public string 平台接入目录 = "..\\文件";
    public int 新手上线赠送开关 = 0;
    public int 新手上线赠送物品1 = 0;
    public int 新手上线赠送物品2 = 0;
    public int 新手上线赠送物品3 = 0;
    public int 新手上线赠送物品4 = 0;
    public int 新手上线赠送物品5 = 0;
    public int 新手上线赠送物品6 = 0;
    public int 新手上线赠送称号1 = 147;
    public int 元宝袋新创数量1 = 500000;
    public int 元宝袋新创数量2 = 1000000;
    public int 元宝袋新创数量3 = 5000000;
    public int 元宝袋新创数量4 = 10000000;
    public int 元宝袋新创数量5 = 50000000;
    public int 初级赞助礼包1 = 0;
    public int 初级赞助礼包2 = 0;
    public int 初级赞助礼包3 = 0;
    public int 初级赞助礼包4 = 0;
    public int 初级赞助礼包5 = 0;
    public int 初级赞助礼包6 = 0;
    public int 初级赞助礼包7 = 0;
    public int 初级赞助礼包8 = 0;
    public int 初级赞助称号1 = 147;
    public int 中级赞助礼包1 = 0;
    public int 中级赞助礼包2 = 0;
    public int 中级赞助礼包3 = 0;
    public int 中级赞助礼包4 = 0;
    public int 中级赞助礼包5 = 0;
    public int 中级赞助礼包6 = 0;
    public int 中级赞助礼包7 = 0;
    public int 中级赞助礼包8 = 0;
    public int 中级赞助称号1 = 147;
    public int 高级赞助礼包1 = 0;
    public int 高级赞助礼包2 = 0;
    public int 高级赞助礼包3 = 0;
    public int 高级赞助礼包4 = 0;
    public int 高级赞助礼包5 = 0;
    public int 高级赞助礼包6 = 0;
    public int 高级赞助礼包7 = 0;
    public int 高级赞助礼包8 = 0;
    public int 高级赞助称号1 = 147;
    public int 平台开关模式 = 0;
    public int 平台元宝充值模块 = 100;
    public int 平台金币充值模块 = 10000;
    public string 九层妖塔BOSS1 = "牛魔王";
    public string 九层妖塔BOSS2 = "牛魔王";
    public string 九层妖塔BOSS3 = "牛魔王";
    public string 九层妖塔BOSS4 = "牛魔王";
    public string 九层妖塔BOSS5 = "牛魔王";
    public string 九层妖塔BOSS6 = "牛魔王";
    public string 九层妖塔BOSS7 = "牛魔王";
    public string 九层妖塔BOSS8 = "牛魔王";
    public string 九层妖塔BOSS9 = "牛魔王";
    public string 九层妖塔精英1 = "白野猪";
    public string 九层妖塔精英2 = "白野猪";
    public string 九层妖塔精英3 = "白野猪";
    public string 九层妖塔精英4 = "白野猪";
    public string 九层妖塔精英5 = "白野猪";
    public string 九层妖塔精英6 = "白野猪";
    public string 九层妖塔精英7 = "白野猪";
    public string 九层妖塔精英8 = "白野猪";
    public string 九层妖塔精英9 = "白野猪";
    public int 九层妖塔数量1 = 1;
    public int 九层妖塔数量2 = 1;
    public int 九层妖塔数量3 = 1;
    public int 九层妖塔数量4 = 1;
    public int 九层妖塔数量5 = 1;
    public int 九层妖塔数量6 = 1;
    public int 九层妖塔数量7 = 1;
    public int 九层妖塔数量8 = 1;
    public int 九层妖塔数量9 = 1;
    public int 九层妖塔副本次数 = 1;
    public int 九层妖塔副本等级 = 40;
    public int 九层妖塔副本物品 = 0;
    public int 九层妖塔副本数量 = 100000;
    public int 九层妖塔副本时间小 = 2;
    public int 九层妖塔副本时间大 = 23;
    public byte AutoBattleLevel = 25;
    public byte 禁止背包铭文洗练 = 0;
    public byte 沙巴克禁止随机 = 1;
    public int 冥想丹自定义经验 = 1000000;
    public byte 沙巴克爆装备开关 = 0;
    public int 铭文战士1挡1次数 = 1000;
    public int 铭文战士1挡2次数 = 2000;
    public int 铭文战士1挡3次数 = 2000;
    public int 铭文战士1挡1概率 = 2;
    public int 铭文战士1挡2概率 = 10;
    public int 铭文战士1挡3概率 = 99;
    public int 铭文战士1挡技能编号 = 1000;
    public int 铭文战士1挡技能铭文 = 1;
    public int 铭文战士2挡1次数 = 1000;
    public int 铭文战士2挡2次数 = 2000;
    public int 铭文战士2挡3次数 = 2000;
    public int 铭文战士2挡1概率 = 2;
    public int 铭文战士2挡2概率 = 10;
    public int 铭文战士2挡3概率 = 99;
    public int 铭文战士2挡技能编号 = 1000;
    public int 铭文战士2挡技能铭文 = 1;
    public int 铭文战士3挡1次数 = 1000;
    public int 铭文战士3挡2次数 = 2000;
    public int 铭文战士3挡3次数 = 2000;
    public int 铭文战士3挡1概率 = 2;
    public int 铭文战士3挡2概率 = 10;
    public int 铭文战士3挡3概率 = 99;
    public int 铭文战士3挡技能编号 = 1000;
    public int 铭文战士3挡技能铭文 = 1;
    public int 铭文法师1挡1次数 = 1000;
    public int 铭文法师1挡2次数 = 2000;
    public int 铭文法师1挡3次数 = 2000;
    public int 铭文法师1挡1概率 = 2;
    public int 铭文法师1挡2概率 = 10;
    public int 铭文法师1挡3概率 = 99;
    public int 铭文法师1挡技能编号 = 1000;
    public int 铭文法师1挡技能铭文 = 1;
    public int 铭文法师2挡1次数 = 1000;
    public int 铭文法师2挡2次数 = 2000;
    public int 铭文法师2挡3次数 = 2000;
    public int 铭文法师2挡1概率 = 2;
    public int 铭文法师2挡2概率 = 10;
    public int 铭文法师2挡3概率 = 99;
    public int 铭文法师2挡技能编号 = 1000;
    public int 铭文法师2挡技能铭文 = 1;
    public int 铭文法师3挡1次数 = 1000;
    public int 铭文法师3挡2次数 = 2000;
    public int 铭文法师3挡3次数 = 2000;
    public int 铭文法师3挡1概率 = 2;
    public int 铭文法师3挡2概率 = 10;
    public int 铭文法师3挡3概率 = 99;
    public int 铭文法师3挡技能编号 = 1000;
    public int 铭文法师3挡技能铭文 = 1;
    public int 铭文道士1挡1次数 = 1000;
    public int 铭文道士1挡2次数 = 2000;
    public int 铭文道士1挡3次数 = 2000;
    public int 铭文道士1挡1概率 = 2;
    public int 铭文道士1挡2概率 = 10;
    public int 铭文道士1挡3概率 = 99;
    public int 铭文道士1挡技能编号 = 1000;
    public int 铭文道士1挡技能铭文 = 1;
    public int 铭文道士2挡1次数 = 1000;
    public int 铭文道士2挡2次数 = 2000;
    public int 铭文道士2挡3次数 = 2000;
    public int 铭文道士2挡1概率 = 2;
    public int 铭文道士2挡2概率 = 10;
    public int 铭文道士2挡3概率 = 99;
    public int 铭文道士2挡技能编号 = 1000;
    public int 铭文道士2挡技能铭文 = 1;
    public int 铭文道士3挡1次数 = 1000;
    public int 铭文道士3挡2次数 = 2000;
    public int 铭文道士3挡3次数 = 2000;
    public int 铭文道士3挡1概率 = 2;
    public int 铭文道士3挡2概率 = 10;
    public int 铭文道士3挡3概率 = 99;
    public int 铭文道士3挡技能编号 = 1000;
    public int 铭文道士3挡技能铭文 = 1;
    public int 铭文刺客1挡1次数 = 1000;
    public int 铭文刺客1挡2次数 = 2000;
    public int 铭文刺客1挡3次数 = 2000;
    public int 铭文刺客1挡1概率 = 2;
    public int 铭文刺客1挡2概率 = 10;
    public int 铭文刺客1挡3概率 = 99;
    public int 铭文刺客1挡技能编号 = 1000;
    public int 铭文刺客1挡技能铭文 = 1;
    public int 铭文刺客2挡1次数 = 1000;
    public int 铭文刺客2挡2次数 = 2000;
    public int 铭文刺客2挡3次数 = 2000;
    public int 铭文刺客2挡1概率 = 2;
    public int 铭文刺客2挡2概率 = 10;
    public int 铭文刺客2挡3概率 = 99;
    public int 铭文刺客2挡技能编号 = 1000;
    public int 铭文刺客2挡技能铭文 = 1;
    public int 铭文刺客3挡1次数 = 1000;
    public int 铭文刺客3挡2次数 = 2000;
    public int 铭文刺客3挡3次数 = 2000;
    public int 铭文刺客3挡1概率 = 2;
    public int 铭文刺客3挡2概率 = 10;
    public int 铭文刺客3挡3概率 = 99;
    public int 铭文刺客3挡技能编号 = 1000;
    public int 铭文刺客3挡技能铭文 = 1;
    public int 铭文弓手1挡1次数 = 1000;
    public int 铭文弓手1挡2次数 = 2000;
    public int 铭文弓手1挡3次数 = 2000;
    public int 铭文弓手1挡1概率 = 2;
    public int 铭文弓手1挡2概率 = 10;
    public int 铭文弓手1挡3概率 = 99;
    public int 铭文弓手1挡技能编号 = 1000;
    public int 铭文弓手1挡技能铭文 = 1;
    public int 铭文弓手2挡1次数 = 1000;
    public int 铭文弓手2挡2次数 = 2000;
    public int 铭文弓手2挡3次数 = 2000;
    public int 铭文弓手2挡1概率 = 2;
    public int 铭文弓手2挡2概率 = 10;
    public int 铭文弓手2挡3概率 = 99;
    public int 铭文弓手2挡技能编号 = 1000;
    public int 铭文弓手2挡技能铭文 = 1;
    public int 铭文弓手3挡1次数 = 1000;
    public int 铭文弓手3挡2次数 = 2000;
    public int 铭文弓手3挡3次数 = 2000;
    public int 铭文弓手3挡1概率 = 2;
    public int 铭文弓手3挡2概率 = 10;
    public int 铭文弓手3挡3概率 = 99;
    public int 铭文弓手3挡技能编号 = 1000;
    public int 铭文弓手3挡技能铭文 = 1;
    public int 铭文龙枪1挡1次数 = 1000;
    public int 铭文龙枪1挡2次数 = 2000;
    public int 铭文龙枪1挡3次数 = 2000;
    public int 铭文龙枪1挡1概率 = 2;
    public int 铭文龙枪1挡2概率 = 10;
    public int 铭文龙枪1挡3概率 = 99;
    public int 铭文龙枪1挡技能编号 = 1000;
    public int 铭文龙枪1挡技能铭文 = 1;
    public int 铭文龙枪2挡1次数 = 1000;
    public int 铭文龙枪2挡2次数 = 2000;
    public int 铭文龙枪2挡3次数 = 2000;
    public int 铭文龙枪2挡1概率 = 2;
    public int 铭文龙枪2挡2概率 = 10;
    public int 铭文龙枪2挡3概率 = 99;
    public int 铭文龙枪2挡技能编号 = 1000;
    public int 铭文龙枪2挡技能铭文 = 1;
    public int 铭文龙枪3挡1次数 = 1000;
    public int 铭文龙枪3挡2次数 = 2000;
    public int 铭文龙枪3挡3次数 = 2000;
    public int 铭文龙枪3挡1概率 = 2;
    public int 铭文龙枪3挡2概率 = 10;
    public int 铭文龙枪3挡3概率 = 99;
    public int 铭文龙枪3挡技能编号 = 1000;
    public int 铭文龙枪3挡技能铭文 = 1;
    public int 铭文战士保底开关 = 0;
    public int 铭文法师保底开关 = 0;
    public int 铭文道士保底开关 = 0;
    public int 铭文刺客保底开关 = 0;
    public int 铭文弓手保底开关 = 0;
    public int 铭文龙枪保底开关 = 0;
    public int 魔虫窟副本次数 = 1;
    public int 魔虫窟副本等级 = 40;
    public int 魔虫窟副本物品 = 1;
    public int 魔虫窟副本数量 = 10000;
    public int 魔虫窟副本时间小 = 12;
    public int 魔虫窟副本时间大 = 12;
    public string 书店商贩物品 = "天书残页";
    public int 幸运额外1值 = 12;
    public int 幸运额外2值 = 15;
    public int 幸运额外3值 = 18;
    public int 幸运额外4值 = 20;
    public int 幸运额外5值 = 999;
    public float 幸运额外1伤害 = 1.1F;
    public float 幸运额外2伤害 = 1.3F;
    public float 幸运额外3伤害 = 1.5F;
    public float 幸运额外4伤害 = 1.8F;
    public float 幸运额外5伤害 = 2.2F;
    public int 幸运洗练次数保底 = 1000;
    public int 幸运洗练点数 = 2;
    public int 武器强化消耗货币值 = 100000;
    public int 武器强化消耗货币开关 = 0;
    public int 武器强化取回时间 = 1;
    public int 暗之门地图1 = 100;
    public int 暗之门地图2 = 100;
    public int 暗之门地图3 = 100;
    public int 暗之门地图4 = 100;
    public int 暗之门时间 = 60;
    public int 暗之门全服提示 = 1;
    public int 暗之门杀怪触发 = 100;
    public string 暗之门地图1BOSS = "尸王";
    public string 暗之门地图2BOSS = "黄泉教主";
    public string 暗之门地图3BOSS = "牛魔王";
    public string 暗之门地图4BOSS = "魔火龙";
    public int 暗之门地图1X = 1401;
    public int 暗之门地图1Y = 554;
    public int 暗之门地图2X = 1401;
    public int 暗之门地图2Y = 554;
    public int 暗之门地图3X = 1401;
    public int 暗之门地图3Y = 554;
    public int 暗之门地图4X = 1401;
    public int 暗之门地图4Y = 554;
    public int 暗之门开关 = 0;
    public int 监狱货币 = 100000;
    public int 监狱货币类型 = 0;
    public int 魔虫窟分钟限制 = 1;
    public int 自定义元宝兑换01 = 999999;
    public int 自定义元宝兑换02 = 999999;
    public int 自定义元宝兑换03 = 999999;
    public int 自定义元宝兑换04 = 999999;
    public int 自定义元宝兑换05 = 999999;
    public int 直升等级1 = 15;
    public int 直升等级2 = 20;
    public int 直升等级3 = 25;
    public int 直升等级4 = 30;
    public int 直升等级5 = 35;
    public int 直升等级6 = 40;
    public int 直升等级7 = 45;
    public int 直升等级8 = 50;
    public int 直升等级9 = 55;
    public int 直升经验1 = 100000;
    public int 直升经验2 = 100000;
    public int 直升经验3 = 100000;
    public int 直升经验4 = 100000;
    public int 直升经验5 = 100000;
    public int 直升经验6 = 100000;
    public int 直升经验7 = 100000;
    public int 直升经验8 = 100000;
    public int 直升经验9 = 100000;
    public int 直升物品1 = 999999;
    public int 直升物品2 = 999999;
    public int 直升物品3 = 999999;
    public int 直升物品4 = 999999;
    public int 直升物品5 = 999999;
    public int 直升物品6 = 999999;
    public int 直升物品7 = 999999;
    public int 直升物品8 = 999999;
    public int 直升物品9 = 999999;
    public int RechargeSystemFormat = 0;
    public int DefaultSkillLevel = 0;
    public int AutoPickUpMap1 = 0;
    public int AutoPickUpMap2 = 0;
    public int AutoPickUpMap3 = 0;
    public int AutoPickUpMap4 = 0;
    public int AutoPickUpMap5 = 0;
    public int AutoPickUpMap6 = 0;
    public int AutoPickUpMap7 = 0;
    public int AutoPickUpMap8 = 0;
    public int 沙城捐献货币类型 = 1;
    public int 沙城捐献支付数量 = 1000000;
    public int 沙城捐献获得物品1 = 999999;
    public int 沙城捐献获得物品2 = 999999;
    public int 沙城捐献获得物品3 = 999999;
    public int 沙城捐献物品数量1 = 1;
    public int 沙城捐献物品数量2 = 1;
    public int 沙城捐献物品数量3 = 1;
    public int 沙城捐献赞助人数 = 0;
    public int 沙城捐献赞助金额 = 0;
    public int 雕爷激活灵符需求 = 6000;
    public int 雕爷1号位灵符 = 1000;
    public int 雕爷1号位铭文石 = 5;
    public int 雕爷2号位灵符 = 2000;
    public int 雕爷2号位铭文石 = 5;
    public int 雕爷3号位灵符 = 3000;
    public int 雕爷3号位铭文石 = 5;
    public int 称号范围拾取判断1 = 131;
    public int 九层妖塔统计开关 = 1;
    public int 沙巴克每周攻沙时间 = 0;
    public int 沙巴克皇宫传送等级 = 40;
    public int 沙巴克皇宫传送物品 = 0;
    public int 沙巴克皇宫传送数量 = 1;
    public int 系统窗口发送 = 0;
    public int 龙卫效果提示 = 0;
    public int AllowRecharge = 0;
    public int 全服红包等级 = 30;
    public int 全服红包时间 = 19;
    public int GlobalBonusCurrencyType = 3;
    public int 全服红包货币数量 = 10000;
    public int 龙卫蓝色词条概率 = 85;
    public int 龙卫紫色词条概率 = 10;
    public int 龙卫橙色词条概率 = 1;
    public int 自定义初始货币类型 = 1;
    public bool 自动回收设置 = false;
    public bool 购买狂暴之力 = false;
    public bool 会员满血设置 = false;
    public bool AutoPickUpAllVisible = false;
    public bool 打开随时仓库 = false;
    public int 会员物品对接 = 999999;
    public int 变性等级 = 40;
    public int 变性货币类型 = 0;
    public int 变性货币值 = 1000000;
    public int 变性物品ID = 999999;
    public int 变性物品数量 = 10;
    public byte 称号叠加模块9 = 0;
    public byte 称号叠加模块10 = 0;
    public byte 称号叠加模块11 = 0;
    public byte 称号叠加模块12 = 0;
    public byte 称号叠加模块13 = 0;
    public byte 称号叠加模块14 = 0;
    public byte 称号叠加模块15 = 0;
    public byte 称号叠加模块16 = 0;
    public bool 幸运保底开关 = false;
    public bool 红包开关 = false;
    public int 龙卫焰焚烈火剑法 = 0;
    public bool 安全区收刀开关 = false;
    public int 屠魔殿等级限制 = 25;
    public int 职业等级 = 40;
    public int RaceChangeCurrencyType = 0;
    public int RaceChangeCurrencyValue = 1000000;
    public int RaceChangeItemID = 999999;
    public int RaceChangeItemQuantity = 10;
    public bool 武斗场杀人开关 = false;
    public int 武斗场杀人经验 = 100000;
    public int MaxUserConnections = 500;
    public int WorldBossMapID = 74;
    public int WorldBossMapPosX = 1043;
    public int WorldBossMapPosY = 176;
    public byte WorldBossTimeHour = 19;
    public byte WorldBossTimeMinute = 30;
    public int 秘宝广场元宝 = 20000;
    public string WorldBossName = "魔火龙";
    public string 战将特权礼包 = "战将特权礼包";
    public string 豪杰特权礼包 = "豪杰特权礼包";
    public int 每周特惠礼包一元宝 = 600;
    public int 每周特惠礼包二元宝 = 3000;
    public int 特权玛法名俊元宝 = 12800;
    public int 特权玛法豪杰元宝 = 28800;
    public int 特权玛法战将元宝 = 28800;
    public int 御兽切换开关 = 0;
    public int 沙巴克重置系统 = 0;
    //public int 免费全功能;
    public int 新手领取选项 = 0;
    public int DropRateModifier = 0;
    public string 转职内容控件 = "输入密码";
    public string 变性内容控件 = "输入密码";
    public string 挂机权限选项 = "输入密码";
    public string 合成模块控件 = "输入密码";

    public bool GuardKillWillDrop = false;

    public string GoldStoneName = "GoldOre";
    public string SilverStoneName = "SilverOre";
    public string IronStoneName = "IronOre";
    public string CopperStoneName = "CopperOre";
    public string BlackIronStoneName = "BlackIronOre";
    public string Gem1StoneName = "RubyGem";
    public string Gem2StoneName = "AmethystGem";
    public string Gem3StoneName = "NephriteGem";
    public string Gem4StoneName = "PlatinumGem";


    public List<StarterItem> StarterItems = new List<StarterItem>()
    {
        new StarterItem { ItemName = "柴刀", RequiredGender = GameObjectGender.Any, RequiredRace = GameObjectRace.Assassin },
        new StarterItem { ItemName = "木剑", RequiredGender = GameObjectGender.Any, RequiredRace = GameObjectRace.Any, BlockedRace = GameObjectRace.Assassin },

        new StarterItem { ItemName = "布衣(男)", RequiredGender = GameObjectGender.Man, RequiredRace = GameObjectRace.Any },
        new StarterItem { ItemName = "布衣(女)", RequiredGender = GameObjectGender.Woman, RequiredRace = GameObjectRace.Any }
    };


    public int DBMethod = 1; // 0: Default (JSON/TXT), 1: SQL, 2: CSV

    public void Load()
    {
        if (!File.Exists(SettingFile))
            return;

        var json = File.ReadAllText(SettingFile);
        Default = JsonConvert.DeserializeObject<Settings>(json, JsonSettings);
    }

    public void Save()
    {
        var json = JsonConvert.SerializeObject(Default, JsonSettings);
        File.WriteAllText(SettingFile, json);
    }
}
