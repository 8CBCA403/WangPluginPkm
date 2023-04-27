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
       
        public enum RegionDex
        {
            填满LetsGo皮卡丘LetsGo伊布的关都图鉴,  
            填满劍盾的伽勒尔图鉴,
            填满劍盾的铠岛图鉴,
            填满劍盾的王冠雪原图鉴,
            填满晶燦鑽石明亮珍珠的神奥图鉴,
            填满传说阿尔宙斯的洗翠图鉴,
        }
        public enum HomeType
        {
            添加一般属性的宝可梦吧,
            添加火属性的宝可梦吧,
            添加水属性的宝可梦吧,
            添加电属性的宝可梦吧,
            添加草属性的宝可梦吧,
            添加冰属性的宝可梦吧,
            添加格斗属性的宝可梦吧,
            添加毒属性的宝可梦吧,
            添加地面属性的宝可梦吧,
            添加飞行属性的宝可梦吧,
            添加超能力属性的宝可梦吧,
            添加虫属性的宝可梦吧,
            添加岩石属性的宝可梦吧,
            添加幽灵属性的宝可梦吧,
            添加龙属性的宝可梦吧,
            添加恶属性的宝可梦吧,
            添加钢属性的宝可梦吧,
            添加妖精属性的宝可梦吧,
        }
        public enum HomeBall
        {
            寄放精灵球里的宝可梦,
            寄放超级球里的宝可梦,
            寄放高级球里的宝可梦,
            寄放狩猎球里的宝可梦,
            寄放等级球里的宝可梦,
            寄放诱饵球里的宝可梦,
            寄放月亮球里的宝可梦,
            寄放友友球里的宝可梦,
            寄放甜蜜球里的宝可梦,
            寄放沉重球里的宝可梦,
            寄放速度球里的宝可梦,
            寄放纪念球里的宝可梦,
            寄放重复球里的宝可梦,
            寄放计时球里的宝可梦,
            寄放巢穴球里的宝可梦,
            寄放捕网球里的宝可梦,
            寄放潜水球里的宝可梦,
            寄放豪华球里的宝可梦,
            寄放治愈球里的宝可梦,
            寄放先机球里的宝可梦,
            寄放黑暗球里的宝可梦,
            寄放竞赛球里的宝可梦,
            寄放梦境球里的宝可梦,
            寄放究极球里的宝可梦,
            寄放洗翠地区的精灵球里的宝可梦,
            寄放洗翠地区的超级球里的宝可梦,
            寄放洗翠地区的高级球里的宝可梦,
            寄放洗翠地区的沉重球里的宝可梦,
            寄放巨重球里的宝可梦,
            寄放超重球里的宝可梦,
            寄放飞羽球里的宝可梦,
            寄放飞梭球里的宝可梦,
            寄放飞翼球里的宝可梦,
            寄放大师球里的宝可梦,
            寄放贵重球里的宝可梦,
        }
        public enum HomeNature
        {
            已寄放10只性格天真的宝可梦,
            已寄放10只性格自大的宝可梦,
            已寄放10只性格温顺的宝可梦,
            已寄放10只性格温和的宝可梦,
            已寄放10只性格马虎的宝可梦,
            已寄放10只性格害羞的宝可梦,
            已寄放10只性格冷静的宝可梦,
            已寄放10只性格慢吞吞的宝可梦,
            已寄放10只性格内敛的宝可梦,
            已寄放10只性格爽朗的宝可梦,
            已寄放10只性格认真的宝可梦,
            已寄放10只性格急躁的宝可梦,
            已寄放10只性格胆小的宝可梦,
            已寄放10只性格乐天的宝可梦,
            已寄放10只性格淘气的宝可梦,
            已寄放10只性格悠闲的宝可梦,
            已寄放10只性格坦率的宝可梦,
            已寄放10只性格大胆的宝可梦,
            已寄放10只性格顽皮的宝可梦,
            已寄放10只性格慎重的宝可梦,
            已寄放10只性格固执的宝可梦,
            已寄放10只性格浮躁的宝可梦,
            已寄放10只性格勇敢的宝可梦,
            已寄放10只性格勤奋的宝可梦,
            已寄放10只性格怕寂寞的宝可梦,
        }
        public enum Firstpartner
        {
            已添加全部最初的伙伴成就,
            已添加在关都地区一开始可选择的3只宝可梦,
            已添加在城都地区一开始可选择的3只宝可梦,
            已添加在丰缘地区一开始可选择的3只宝可梦,
            已添加在神奥地区一开始可选择的3只宝可梦,
            已添加在合众地区一开始可选择的3只宝可梦,
            已添加在卡洛斯地区一开始可选择的3只宝可梦,
            已添加在阿罗拉地区一开始可选择的3只宝可梦,
            已添加在伽勒尔地区一开始可选择的3只宝可梦
        }
        public enum PostGenAchieve
        {
            添加全部历代游戏宝可梦成就,
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
            添加全部特定形态或数量要求成就,
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
        public enum OtherPokemonachievements
        {
            寄放宝可梦吧,
            寄放异色的宝可梦吧,
            添加特性吧,
            添加物理招式吧,
            添加特殊招式吧,
            添加变化招式吧,
            寄放奋斗等级全都达到最高的宝可梦,
            添加头目宝可梦,
            寄放光泽达到最棒的宝可梦,
            寄放帅气达到最棒的宝可梦,
            寄放美丽达到最棒的宝可梦,
            寄放可爱达到最棒的宝可梦,
            寄放聪明达到最棒的宝可梦,
            寄放强壮达到最棒的宝可梦,
            添加持有闪亮之星奖章的宝可梦,
            添加霜奶仙的样子吧
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
