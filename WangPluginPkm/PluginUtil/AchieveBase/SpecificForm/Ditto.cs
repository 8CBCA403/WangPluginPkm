using PKHeX.Core;
using System;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Ditto
    {
        public static List<PKM> DittoSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        var pl = SearchDatabase.SearchPKMList(SAV, Editor, 132, 32);
                        for (int i = 0; i < 30; i++)
                        {
                            Random rnd = new Random();
                            var j = rnd.Next(0, pl.Count);
                            pk = pl[j];
                            pk.SetRandomEC();
                            pk.PID = WangRandUtil.NextRand(0);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
