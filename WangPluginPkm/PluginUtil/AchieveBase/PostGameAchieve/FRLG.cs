using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class FRLG
    {
        public static List<PKM> FRLGSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Charizard, (int)GameVersion.FR);
                pk.CurrentLevel = 50;
                pk.Species = 6;
                pk=AchieveFunc.fun(pk,SAV);
                pk.Version = 4;
                PKL.Add(pk);

                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Venusaur, (int)GameVersion.LG);
                pk.CurrentLevel = 50;
                pk.Species = 3;
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 5;
                PKL.Add(pk);
              
             
            }
            return PKL;
        }
    }
}
