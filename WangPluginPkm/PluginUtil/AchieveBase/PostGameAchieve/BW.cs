using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class BW
    {
        public static List<PKM> BWSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Eevee, (int)GameVersion.B);
                pk=AchieveFunc.fun(pk);
                PKL.Add(pk);
                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Litwick, (int)GameVersion.W);
                pk = AchieveFunc.fun(pk);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Reshiram, (int)GameVersion.W2);
                pk = AchieveFunc.fun(pk);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Zekrom, (int)GameVersion.B2);
                pk = AchieveFunc.fun(pk);
                
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Kyurem, (int)GameVersion.W2);
                pk = AchieveFunc.fun(pk);
               
                PKL.Add(pk);
               

            }
            return PKL;
        }
    }
}
