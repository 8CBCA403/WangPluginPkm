using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class PikachuDex
    {
        public static List<PKM> PikachuSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            var pk = Editor.Data;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SN or GameVersion.MN:
                    for (int i = 0; i < 7; i++)
                    {
                        pk = SearchDatabase.MytheryPK(SAV, Editor, 25, 7, i);
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.US or GameVersion.UM:
                    for (int i = 0; i < 8; i++)
                    {
                        pk = SearchDatabase.MytheryPK(SAV, Editor, 25, 7, i);
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SW or GameVersion.SH:
                    for (int i = 0; i < 8; i++)
                    {
                        pk = SearchDatabase.MytheryPK(SAV, Editor, 25,8, i);
                        PKL.Add(pk);
                    }
                    pk = SearchDatabase.MytheryPK(SAV, Editor, 25, 8, 9);
                    PKL.Add(pk);
                    break;

            }
            return PKL;
        }
    }
}
