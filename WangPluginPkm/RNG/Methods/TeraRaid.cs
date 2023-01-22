using Microsoft.CodeAnalysis.Differencing;
using PKHeX.Core;
using System;
using System.Collections.Generic;
using WangPluginPkm.WangUtil.ModifyPKM;
using WangPluginPkm.WangUtil.PluginEnums;
using System.Windows.Forms;
using WangPluginPkm.WangUtil.TeraRaid;
#nullable enable
namespace WangPluginPkm.RNG.Methods
{
    internal class TeraRaid
    {
        public static uint GetOriginalSeed(PKM pk)
        {
            var enc = pk.EncryptionConstant;
            const uint TwoSeedsEC = 0xF8572EBE;
            if (enc != TwoSeedsEC)
                return enc - unchecked((uint)Xoroshiro128Plus.XOROSHIRO_CONST);
            const uint Seed_1 = 0xD5B9C463; // First rand()
            const uint Seed_2 = 0xDD6295A4; // First rand() is uint.MaxValue, rolls again.
            const uint PID_1 = 0xC9E69326; // 0xD68E8499 for PID_2
            return pk.PID == PID_1 ? Seed_1 : Seed_2; // don't care if the PID != second's case. Other validation will check.
        }
        public static uint? CalcResult(ulong Seed,int TID167,int SID167, GameProgress progress, GameVersion G, uint calc)
        {
            var seed = (uint)(Seed & 0xFFFFFFFF);
        
            var encounter = TeraUtil.GetTeraEncounter(seed, G, TeraUtil.GetStars(seed, progress), TeraUtil.GetAllTeraEncounters());
            
            if (encounter is null)
            {
                MessageBox.Show("空2");
                return null;
            }
            //TeraUtil.CalcRNG(seed, TID167, SID167, encounter, calc);
            return encounter.Species;
        }
    }
}
