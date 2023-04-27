using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class ParadoxDex
    {
        public static List<PKM> ParadoxSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SL or GameVersion.VL or GameVersion.SV:
               
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.RoaringMoon, 50);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.IronValiant, 51);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        for (ushort i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(Species.GreatTusk+i), 50);
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (ushort i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(Species.IronTreads+i), 51);
                        pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
