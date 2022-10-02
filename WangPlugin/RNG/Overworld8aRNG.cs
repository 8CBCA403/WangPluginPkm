using PKHeX.Core;
using System;
namespace WangPlugin
{
    internal class Overworld8aRNG
    {
        private const int MaxRollCount = 7;
        private const int UNSET = 255;
        private static uint GetShinyPID(int tid, int sid, uint pid, int type)
        {
            return (uint)(((tid ^ sid ^ (pid & 0xFFFF) ^ type) << 16) | (pid & 0xFFFF));
        }

        private static bool GetIsShiny(int tid, int sid, uint pid)
        {
            return GetShinyXor(tid, sid, pid) < 16;
        }

        private static uint GetShinyXor(int tid, int sid, uint pid)
        {
            return GetShinyXor(pid, (uint)((sid << 16) | tid));
        }

        private static uint GetShinyXor(uint pid, uint oid)
        {
            var xor = pid ^ oid;
            return (xor ^ (xor >> 16)) & 0xFFFF;
        }
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            int FlawlessIVs = 0;
            var rand = new Xoroshiro128Plus(seed);

            // Encryption Constant
            pk.EncryptionConstant = (uint)rand.NextInt();

            // PID
            var fakeTID = (uint)rand.NextInt();
            uint pid = (uint)rand.NextInt();
            bool isShiny = false;
            if (r.Shiny == GUI.PkmCondition.ShinyType.Shiny) // let's decide if it's shiny or not!
            {
                for (int i = 1; i < 12; i++)
                {
                    isShiny = GetShinyXor(pid, fakeTID) < 16;
                    if (isShiny)
                        break;
                    pid = (uint)rand.NextInt();
                }
            }
            else
            {
                // no need to calculate a fake trainer
                isShiny = true;
            }

            ForceShinyState(pk, isShiny, ref pid);

            var xor = GetShinyXor(pk.TID, pk.SID, pid);
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            pk.PID = pid;

            Span<int> ivs = stackalloc[] { UNSET, UNSET, UNSET, UNSET, UNSET, UNSET };
            const int MAX = 31;
            for (int i = 0; i < FlawlessIVs; i++)
            {
                int index;
                do { index = (int)rand.NextInt(6); }
                while (ivs[index] != UNSET);

                ivs[index] = MAX;
            }

            for (int i = 0; i < ivs.Length; i++)
            {
                if (ivs[i] == UNSET)
                    ivs[i] = (int)rand.NextInt(32);
            }
            pk.IV_HP = ivs[0];
            pk.IV_ATK = ivs[1];
            pk.IV_DEF = ivs[2];
            pk.IV_SPA = ivs[3];
            pk.IV_SPD = ivs[4];
            pk.IV_SPE = ivs[5];
            pk.RefreshAbility((int)rand.NextInt(2));
            pk.Gender = GenderApplicator.GetSaneGender(pk);
            int nature = (int)rand.NextInt(25);
            pk.StatNature = pk.Nature = nature;
            PA8 pa = (PA8)pk;
            var (height, weight) = pa.IsAlpha
                ? (byte.MaxValue, byte.MaxValue)
                : ((byte)((int)rand.NextInt(0x81) + (int)rand.NextInt(0x80)),
                   (byte)((int)rand.NextInt(0x81) + (int)rand.NextInt(0x80)));

            if (pk is IScaledSize s)
            {
                s.HeightScalar = height;
                s.WeightScalar = weight;
                if (pk is IScaledSizeValue a)
                {
                    a.ResetHeight();
                    a.ResetWeight();
                }
            }

            return true;
        }

        public static void ForceShinyState(PKM pk, bool isShiny, ref uint pid)
        {
            if (isShiny)
            {
                if (!GetIsShiny(pk.TID, pk.SID, pid))
                    pid = GetShinyPID(pk.TID, pk.SID, pid, 0);
            }
            else
            {
                if (GetIsShiny(pk.TID, pk.SID, pid))
                    pid ^= 0x1000_0000;
            }
        }
        private static byte GetRollCount(SlotType type) => (byte)(MaxRollCount + type switch
        {
            SlotType.OverworldMMO => 12,
            SlotType.OverworldMass => 25,
            _ => 0,
        });
    }
}
