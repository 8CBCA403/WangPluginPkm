using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class RBY
    {
        public static List<PKM> RBYSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
         
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Venusaur, (int)GameVersion.RBY);
                pk.CurrentLevel = 50;
                pk.Species = 3;
                pk = AchieveFunc.fun(pk);
                pk.SID16 = 0;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Charizard, (int)GameVersion.RBY);
                pk.CurrentLevel = 50;
                pk.Species = 6;
                pk = AchieveFunc.fun(pk);
                pk.SID16 = 0;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Blastoise, (int)GameVersion.RBY);
                pk.CurrentLevel = 50;
                pk.Species = 9;
                pk = AchieveFunc.fun(pk);
                pk.SID16 = 0;
                pk.Version = 36;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Pikachu, (int)GameVersion.RBY);
                pk = AchieveFunc.fun(pk);
                pk.SID16 = 0;
                pk.Version = 38;
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
