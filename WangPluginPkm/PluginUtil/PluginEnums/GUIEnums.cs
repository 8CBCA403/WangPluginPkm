using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.PluginEnums
{
    internal class GUIEnums
    {
        public enum RNGFormGender
        {
            只能公,
            一公七母,
            一公三母,
            一公一母,
            三公一母,
            七公一母,
            只能母,
            无性别
        }
        public enum RNGFormAbility
        {
            有梦特,
            无梦特,
            只能特性一,
         
        }
        public enum DexFormLanguage5
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
        }
        public enum DexFormLanguage7
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
            KOR,
            CHS,
            CHT,
        }
        public enum DexFormOTGender
        {
            Male,
            Female,
        }
       
        public enum DisFormIVEV
        {
            物攻,
            特攻,
            物攻0速,
            特攻0速,
            肉盾

        }
        public enum DisFormClone
        {
            复制一箱,
            竖向复制5只
        }
        public enum DisFormTrainer
        {
            覆盖一箱,
            覆盖面板
        }
        public enum MainHomeAchieve
        {
            地区图鉴,
            属性,
            精灵球,
            性格,
            最初的伙伴,
            历代游戏宝可梦,
            特定形态或数量要求,
            其他宝可梦成就
        }
        public enum PostGenAchieve
        {
            需要来自红宝石蓝宝石绿宝石的宝可梦,
            需要来自火红叶绿的宝可梦,
            需要来自钻石珍珠白金的宝可梦,
            需要来自心金魂银的宝可梦,
            需要来自黑白黑２白２的宝可梦,
            需要来自ＸＹ的宝可梦,
            需要来自欧米加红宝石阿尔法蓝宝石的宝可梦,
            需要来自太阳月亮究极之日究极之月的宝可梦,
            需要来自红绿蓝皮卡丘虚拟主机版的宝可梦,
            需要来自金银水晶版虚拟主机版的宝可梦,
            需要来自LetsGo皮卡丘LetsGo伊布的宝可梦,
            需要来自剑盾的宝可梦,
            需要来自晶灿钻石明亮珍珠的宝可梦,
            需要来自传说阿尔宙斯的宝可梦
        }
        public enum SpecificForm
        {
            已添加18种彩粉蝶的花纹,
            已添加100种栖息在阿罗拉地区的宝可梦,
            已添加20种从化石复原的宝可梦,
            已添加28种未知图腾的样子,
            已添加4种花舞鸟的形态,
            已添加5种究极异兽,
            已添加6种洛托姆的形态,
            已添加7种小陨星的样子,
            已添加9种伊布和伊布的进化形,
            已添加四季鹿春天的样子和萌芽鹿春天的样子,	
            已添加四季鹿夏天的样子和萌芽鹿夏天的样子,		
            已添加四季鹿秋天的样子和萌芽鹿秋天的样子,		
            已添加四季鹿冬天的样子和萌芽鹿冬天的样子,
            已添加认真起来的卡比兽,
            已添加异色的巨金怪,
            已添加谢米,
            已添加美洛耶塔,
            已添加异色的盖诺赛克特,
            已添加阿罗拉的守护神,
            已添加戴着帽子的皮卡丘,
            已寄放30只皮卡丘,
            已寄放30只百变怪
        }
        public enum PostGenAchieve2
        {
            
            其他宝可梦成就
        }
        public static int GetLanguageBox7(DexFormLanguage7 type7)
        {
            var T = 1;
            switch (type7)
            {
                case DexFormLanguage7.JPN:
                    T = 1;
                    break;
                case DexFormLanguage7.ENG:
                    T = 2;
                    break;
                case DexFormLanguage7.FRE:
                    T = 3;
                    break;
                case DexFormLanguage7.ITA:
                    T = 4;
                    break;
                case DexFormLanguage7.GRE:
                    T = 5;
                    break;
                case DexFormLanguage7.ESP:
                    T = 7;
                    break;
                case DexFormLanguage7.KOR:
                    T = 8;
                    break;
                case DexFormLanguage7.CHS:
                    T = 9;
                    break;
                case DexFormLanguage7.CHT:
                    T = 10;
                    break;
            }
            return T;
        }
        public static int GetLanguageBox5(DexFormLanguage5 type5)
        {
            var T = 1;
            switch (type5)
            {
                case DexFormLanguage5.JPN:
                    T = 1;
                    break;
                case DexFormLanguage5.ENG:
                    T = 2;
                    break;
                case DexFormLanguage5.FRE:
                    T = 3;
                    break;
                case DexFormLanguage5.ITA:
                    T = 4;
                    break;
                case DexFormLanguage5.GRE:
                    T = 5;
                    break;
                case DexFormLanguage5.ESP:
                    T = 7;
                    break;
            }
            return T;
        }
        public static int GetGender(DexFormOTGender typeG)
        {
            var T = 0;
            switch (typeG)
            {
                case DexFormOTGender.Male:
                    T = 0;
                    break;
                case DexFormOTGender.Female:
                    T = 1;
                    break;
            }
            return T;
        }

    }
}
