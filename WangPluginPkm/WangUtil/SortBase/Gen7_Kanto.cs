using PKHeX.Core;
using System;
using System.Collections.Generic;

namespace WangPluginPkm.SortBase
{
    internal class Gen7_Kanto : Gen1_Kanto
    {

        private static readonly Dictionary<Species, int> extendedDex = new Dictionary<Species, int>(dex) {
      {Species.Meltan, 152},
      {Species.Melmetal, 153},
    };

        public static new Func<PKM, IComparable>[] GetSortFunctions()
        {
            return GenerateSortingFunctions(extendedDex);
        }

    }
}

