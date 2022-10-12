using PKHeX.Core;
using System;

namespace WangPluginPkm.SortBase
{
    class Gen8_Sinnoh : SortingBase
    {

        public static Func<PKM, IComparable>[] GetSortFunctions()
        {
            return Gen4_Sinnoh.GetDPSortFunctions();
        }

    }
}
