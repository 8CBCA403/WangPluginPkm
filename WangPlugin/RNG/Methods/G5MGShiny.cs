using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.RNG.Methods
{
    internal class G5MGShiny
    {
        public static uint Next(uint seed) => WangRandUtil.NextRand(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            var gv = seed >> 24;
            var av = seed & 1; // arbitrary choice
            pk.PID = GetMG5ShinyPID(gv, av, pk.TID, pk.SID);
            pk.SetRandomIVs();
            return true;
        }
        public static uint GetMG5ShinyPID(uint gval, uint av, int TID, int SID)
        {
            uint PID = (uint)((TID ^ SID ^ gval) << 16 | gval);
            if ((PID & 0x10000) != av << 16)
                PID ^= 0x10000;
            return PID;
        }

    }
}
