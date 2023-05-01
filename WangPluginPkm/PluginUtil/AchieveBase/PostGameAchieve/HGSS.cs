using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class HGSS
    {
        public static List<PKM> HGSSSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.HoOh, (int)GameVersion.HG);
           
                pk=AchieveFunc.fun(pk,SAV);
                pk.Version = 7;
                PKL.Add(pk);

                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Lugia, (int)GameVersion.SS);
           
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 8;
                PKL.Add(pk);
              
             
            }
            return PKL;
        }
    }
}
