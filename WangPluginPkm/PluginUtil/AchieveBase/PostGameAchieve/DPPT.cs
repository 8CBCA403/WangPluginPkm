using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class DPPT
    {
        public static List<PKM> DPPTSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Dialga, (int)GameVersion.D);
                pk=AchieveFunc.fun(pk);
                PKL.Add(pk);
                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Palkia, (int)GameVersion.P);
                pk = AchieveFunc.fun(pk);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Giratina, (int)GameVersion.Pt);
                pk = AchieveFunc.fun(pk);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Turtwig, (int)GameVersion.D);
                pk = AchieveFunc.fun(pk);
                pk.Version = 10;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Chimchar, (int)GameVersion.P);
                pk = AchieveFunc.fun(pk);
                pk.Version = 11;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Piplup, (int)GameVersion.Pt);
                pk = AchieveFunc.fun(pk);
                PKL.Add(pk);

            }
            return PKL;
        }
    }
}
