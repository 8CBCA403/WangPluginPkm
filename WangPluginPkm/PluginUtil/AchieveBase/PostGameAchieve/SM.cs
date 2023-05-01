using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class SM
    {
        public static List<PKM> SMSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Solgaleo, (int)GameVersion.SN);
                pk.CurrentLevel = 70;
                pk.Species = 791;
                pk =AchieveFunc.fun(pk,SAV);
                pk.Ability = 230;
                PKL.Add(pk);
                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Lunala, (int)GameVersion.MN);
                pk.CurrentLevel = 70;
                pk.Species = 792;
                pk = AchieveFunc.fun(pk,SAV);
                pk.Ability = 231;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Necrozma, (int)GameVersion.US);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Cosmog, (int)GameVersion.UM);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Cosmog, (int)GameVersion.UM);
                pk.CurrentLevel = 50;
                pk.Species = 790;
                pk = AchieveFunc.fun(pk,SAV);
                pk.Move1 = 150;
                pk.Move2 = 0;
                pk.Move3 = 0;
                pk.Move4 = 0;
                pk.HealPP();
                pk.Ability = 5;
                PKL.Add(pk);
               

            }
            return PKL;
        }
    }
}
