using PKHeX.Core;
using System;
using System.Collections.Generic;

namespace WangPluginPkm.SortBase
{
    internal class SortingBase
    {
        private static int SortBetweenDexes(Dictionary<Species, int>[] dexes, PKM pkm)
        {
            for (int i = 0; i < dexes.Length; i++)
            {
                if (dexes[i].ContainsKey((Species)pkm.Species))
                    return i;
            }
            return dexes.Length;
        }

        private static int SortWithinDex(Dictionary<Species, int>[] dexes, PKM pkm)
        {
            for (int i = 0; i < dexes.Length; i++)
            {
                if (dexes[i].ContainsKey((Species)pkm.Species))
                    return dexes[i][(Species)pkm.Species];
            }
            return pkm.Species;
        }

        protected static Func<PKM, IComparable>[] GenerateSortingFunctions(Dictionary<Species, int>[] dexes)
        {
            Func<PKM, IComparable>[] sortFunctions = new Func<PKM, IComparable>[] {
        (p) => SortBetweenDexes(dexes, p),
        (p) => SortWithinDex(dexes, p),
      };
            return sortFunctions;
        }

        protected static Func<PKM, IComparable>[] GenerateSortingFunctions(Dictionary<Species, int> dex)
        {
            return GenerateSortingFunctions(new Dictionary<Species, int>[] { dex });
        }

    }
}

