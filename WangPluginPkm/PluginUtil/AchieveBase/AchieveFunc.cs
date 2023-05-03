using PKHeX.Core;
using PKHeX.Core.AutoMod;

namespace WangPluginPkm.PluginUtil.AchieveBase
{
    internal class AchieveFunc
    {
        public static PKM fun(PKM pk,ISaveFileProvider SAV)
        {
            pk.ClearNickname();
            if (pk.OT_Name == "PKHeX")
            {
                pk.OT_Name = "Meerk";
                pk.TID16 = 61482;
                pk.SID16 = 5;
            }
            else if (pk.OT_Name == "")
            {
                pk.OT_Name = "Meerk";
                pk.TID16 = 61482;
                pk.SID16 = 5;
            }
            else if (pk.TID16 == SAV.SAV.TID16&& pk.SID16 == SAV.SAV.SID16)
            {
                pk.OT_Name = "Meerk";
                pk.TID16 = 61482;
                pk.SID16 = 5;
            }
            if (pk.Version is 35 or 40 or 41 or 38 or 37 or 36 or 39)
                pk.SID16 = 0;
            pk.SetSuggestedMoves();
            pk.HealPP();
            return pk;
        }
        public static PKM evo1(PKM pk)
        {
            pk.Species++;
            pk.CurrentLevel += 25;
            pk.SetSuggestedMoves();
            pk.HealPP();
            pk.RefreshAbility(0);
            return pk;
        }
        public static PKM evo2(PKM pk)
        {
            pk.Species+= 2;
            pk.CurrentLevel += 40;
            pk.SetSuggestedMoves();
            pk.HealPP();
            pk.RefreshAbility(0);
            return pk;
        }
        public static PKM evo3(PKM pk)
        {
            pk.Species += 3;
            pk.CurrentLevel += 20;
            pk.SetSuggestedMoves();
            pk.HealPP();
            pk.RefreshAbility(0);
            return pk;
        }
        public static PKM evo4(PKM pk)
        {
            pk.Species += 4;
            pk.CurrentLevel += 40;
            pk.SetSuggestedMoves();
            pk.HealPP();
            pk.RefreshAbility(0);
            return pk;
        }
        public static PKM evo1H(PKM pk)
        {
            pk.Species++;
            pk.CurrentLevel += 25;
            pk.RefreshAbility(2);
            pk.Language = 2;
            pk.ClearNickname();
            pk.SetSuggestedMoves(true);
            pk.HealPP();
            return pk;
        }
        public static PKM evo2H(PKM pk)
        {
            pk.Species += 2;
            pk.CurrentLevel += 40;
            pk.RefreshAbility(2);
            pk.Language = 2;
            pk.ClearNickname();
            pk.SetSuggestedMoves(true);
            pk.HealPP();
            return pk;
        }
        public static PKM evo3H(PKM pk)
        {
            pk.Species += 3;
            pk.CurrentLevel += 40;
            pk.RefreshAbility(2);
            pk.Language = 2;
            pk.ClearNickname();
            pk.SetSuggestedMoves(true);
            pk.HealPP();
            return pk;
        }
       
    }
}
