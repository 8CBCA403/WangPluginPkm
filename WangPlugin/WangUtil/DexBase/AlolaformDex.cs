using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class AlolaformDex
    {
        public static List<ushort> a = new List<ushort>
               { 19,20,26,27,28,37,38,50,51,
                 52,53,74,75,76,88,89,103,105
                };
        public static List<PKM> AlolaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {

                case GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM:
                    for (int i = 0; i < a.Count; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, a[i], 30,1,true);
                        pk.CurrentLevel = 100;
                        pk.Species = a[i];
                        pk.Form = 1;
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;

            }
            return PKL;
        }
    }
}
