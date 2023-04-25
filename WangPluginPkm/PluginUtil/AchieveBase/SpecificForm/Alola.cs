using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Alola
    {
        public static List<PKM> AlolaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 722; i < 808; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)i, 32);
                            pk.CurrentLevel = 100;
                            pk.Species = (ushort)i;
                            pk.ClearNickname();
                            pk = AchieveFunc.fun(pk);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
