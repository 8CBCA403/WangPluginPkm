using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class GDSI
    {
        public static List<PKM> GDSISets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.HoOh, (int)GameVersion.GD);
           
                pk=AchieveFunc.fun(pk);
                pk.Version = 39;
                pk.SID16 = 0;
                PKL.Add(pk);

                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Lugia, (int)GameVersion.SI);
           
                pk = AchieveFunc.fun(pk);
                pk.Version = 40;
                pk.SID16 = 0;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Suicune, (int)GameVersion.C);

                pk = AchieveFunc.fun(pk);
                pk.Version = 41;
                pk.SID16 = 0;
                PKL.Add(pk);


            }
            return PKL;
        }
    }
}
