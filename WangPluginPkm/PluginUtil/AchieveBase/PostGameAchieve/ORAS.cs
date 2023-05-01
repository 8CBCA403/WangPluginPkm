using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class ORAS
    {
        public static List<PKM> ORASSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
          
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Groudon, (int)GameVersion.OR);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Kyogre, (int)GameVersion.AS);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Rayquaza, (int)GameVersion.OR);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Treecko, (int)GameVersion.OR);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Treecko, (int)GameVersion.AS);
                pk.CurrentLevel = 20;
                pk.Species = 253;
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Treecko, (int)GameVersion.OR);
                pk.CurrentLevel = 50;
                pk.Species = 254;
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Torchic, (int)GameVersion.OR);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Torchic, (int)GameVersion.OR);
                pk.CurrentLevel = 20;
                pk.Species = 256;
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Torchic, (int)GameVersion.OR);
                pk.CurrentLevel = 50;
                pk.Species = 257;
                pk = AchieveFunc.fun(pk,SAV); 
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Mudkip, (int)GameVersion.AS);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Mudkip, (int)GameVersion.AS);
                pk.CurrentLevel = 20;
                pk.Species = 259;
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Mudkip, (int)GameVersion.AS);
                pk.CurrentLevel = 50;
                pk.Species = 260;
                pk = AchieveFunc.fun(pk,SAV); 
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
