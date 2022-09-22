using PKHeX.Core;

namespace WangPlugin
{
    internal static class Roaming8bRNG
    {
        private const int FlawlessIVs = 3;
        private const int UNSET = 255;
        public static uint Next(uint seed) => (uint)new Xoroshiro128Plus8b(seed).Next();
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            var xoro = new Xoroshiro128Plus8b(seed);
            var fakeTID = xoro.NextUInt();
            var pid = xoro.NextUInt();
            pid = GetRevisedPID(fakeTID, pid, pk.TID,pk.SID);
          
            var ivs = new int[6] { UNSET, UNSET, UNSET, UNSET, UNSET, UNSET };
            var determined = 0;
            while (determined < FlawlessIVs)
            {
                var idx = xoro.NextUInt(6);
                if (ivs[idx] != UNSET) continue;
                ivs[idx] = 31;
                determined++;
            }
            for (var i = 0; i < ivs.Length; i++)
            {
                if (ivs[i] == UNSET)
                {
                   
                    ivs[i] = (int)xoro.NextUInt(32);
                }
            }
           
            pk.PID = pid;
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            pk.EncryptionConstant = seed;
            pk.IV_HP = ivs[0];
            pk.IV_ATK = ivs[1];
            pk.IV_DEF = ivs[2];
            pk.IV_SPA = ivs[3];
            pk.IV_SPD = ivs[4];
            pk.IV_SPE = ivs[5];
            if (!r.CheckIV(r, pk))
            {
                return false;
            }
            // Ability
            pk.SetAbilityIndex((int)xoro.NextUInt(2));
            // Remainder
            var scale = (IScaledSize)pk;
            scale.HeightScalar = (byte)((int)xoro.NextUInt(0x81) + (int)xoro.NextUInt(0x80));
            scale.WeightScalar = (byte)((int)xoro.NextUInt(0x81) + (int)xoro.NextUInt(0x80));
            pk.RefreshChecksum();
            return true;
        }
        private static uint GetRevisedPID(uint fakeTID, uint pid, int TID, int SID)
        {
            var xor = GetShinyXor(pid, fakeTID);
            var newXor = GetShinyXor(pid, (uint)(TID | (SID << 16)));
            var fakeRare = GetRareType(xor);
            var newRare = GetRareType(newXor);
            if (fakeRare == newRare)
                return pid;
            var isShiny = xor < 16;
            if (isShiny)
                return (((uint)(TID ^ SID) ^ (pid & 0xFFFF) ^ (xor == 0 ? 0u : 1u)) << 16) | (pid & 0xFFFF); // force same shiny star type
            return pid ^ 0x1000_0000;
           
        }
        private static int GetRareType(uint xor) => xor switch
        {
            0 => 2,
            < 16 => 1,
            _ => 0,
        };
        private static uint GetShinyXor(uint pid, uint oid)
        {
            var xor = pid ^ oid;
            return (xor ^ (xor >> 16)) & 0xFFFF;
        }
      
    }
}
