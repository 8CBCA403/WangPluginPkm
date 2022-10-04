using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class DreamRadarDex
    {
        public static List<PKM> DreamRadarSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk1;
            PKM pk2;
            PKM pk3;
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 120, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 137, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 174, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 175, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 213, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 238, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 280, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 333, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 425, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 436, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 442, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 447, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 479, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 517, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 561, 22, 0, false, 30015));
            if (SAV.SAV.Version is GameVersion.B or GameVersion.W or GameVersion.BW)
            {
                pk1 = SearchDatabase.SearchPKM(SAV, Editor, 641, 22, 0, false, 30015);
                pk2 = SearchDatabase.SearchPKM(SAV, Editor, 642, 22, 0, false, 30015);
                pk3 = SearchDatabase.SearchPKM(SAV, Editor, 645, 22, 0, false, 30015);
                pk1.Form = 0;
                pk2.Form = 0;
                pk3.Form = 0;
                pk1.Ability = 128;
                pk2.Ability = 128;
                pk3.Ability = 125;
                PKL.Add(pk1);
                PKL.Add(pk2);
                PKL.Add(pk3);
            }
            else
            {
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 641, 22, 0, false, 30015));
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 642, 22, 0, false, 30015));
                PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 645, 22, 0, false, 30015));
            }

            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 249, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 250, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 483, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 484, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 487, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 374, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 79, 22, 0, false, 30015));
            PKL.Add(SearchDatabase.SearchPKM(SAV, Editor, 163, 22, 0, false, 30015));
            return PKL;
        }
    }
}
