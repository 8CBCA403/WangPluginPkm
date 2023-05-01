using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.PluginUtil.AchieveBase.PostGameAchieve
{
    internal class XY
    {
        public static List<PKM>XYSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
       
            if(SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk =SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Xerneas, (int)GameVersion.X);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Yveltal, (int)GameVersion.Y);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Diancie, (int)GameVersion.X);
                pk.Language = 2;
                pk.ClearNickname();
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
