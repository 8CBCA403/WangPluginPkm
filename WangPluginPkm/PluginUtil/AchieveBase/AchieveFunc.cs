using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;
using PKHeX.Core.AutoMod;

namespace WangPluginPkm.PluginUtil.AchieveBase
{
    internal class AchieveFunc
    {
        public static PKM fun(PKM pk)
        {
            pk.ClearNickname();
            pk.OT_Name = "Meerkat";
            pk.TID16 = 61482;
            pk.SID16 = 5;
            pk.SetSuggestedMoves();
            pk.HealPP();
            return pk;
        }
    }
}
