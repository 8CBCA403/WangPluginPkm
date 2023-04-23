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
