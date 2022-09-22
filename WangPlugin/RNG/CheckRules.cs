using System;
using PKHeX.Core;
using System.Collections.Generic;
using WangPlugin.GUI;
using System.Security.Cryptography;
using static WangPlugin.GUI.RNGForm;

namespace WangPlugin
{
    public partial class CheckRules
    {
        public uint minHP { get; set; }
        public uint maxHP { get; set; } = 31;
        //
        public uint minAtk { get; set; }
        public uint maxAtk { get; set; } = 31;
        //
        public uint minDef { get; set; }
        public uint maxDef { get; set; } = 31;
        //
        public uint minSpA { get; set; }
        public uint maxSpA { get; set; } = 31;
        //
        public uint minSpD { get; set; }
        public uint maxSpD { get; set; } = 31;
        //
        public uint minSpe { get; set; }
        public uint maxSpe { get; set; } = 31;

        public PkmCondition.ShinyType Shiny  { get; set; }

        public RNGForm.MethodType Method { get; set; }
        public bool CheckIV(CheckRules r, PKM pk)
        {
            if (pk.IV_HP < r.minHP || pk.IV_HP > r.maxHP)
                return false;
            if (pk.IV_ATK < r.minAtk || pk.IV_ATK > r.maxAtk)
                return false;
            if (pk.IV_DEF < r.minDef || pk.IV_DEF > r.maxDef)
                return false;
            if (pk.IV_SPA < r.minSpA || pk.IV_SPA > r.maxSpA)
                return false;
            if (pk.IV_SPD < r.minSpD || pk.IV_SPD > r.maxSpD)
                return false;
            if (pk.IV_SPE < r.minSpe || pk.IV_SPE > r.maxSpe)
                return false;
            return true;
        }
        public bool CheckShiny(CheckRules r, PKM pk)
        {
            var s = (uint)(pk.TID ^ pk.SID) ^ ((pk.PID >> 16) ^ (pk.PID & 0xFFFF));
            if (r.Shiny== PkmCondition.ShinyType.None)
                return true;
            else if (r.Shiny == PkmCondition.ShinyType.Shiny && s < 8)
                return true;
            else if (r.Shiny == PkmCondition.ShinyType.Star && s < 8 && s != 0)
                return true;
            else if (r.Shiny == PkmCondition.ShinyType.Sqaure && s == 0)
                return true;
            else if (r.Shiny == PkmCondition.ShinyType.ForceStar && s == 1)
                return true;
            else
                return false;
        }
        public static Queue<uint> PreSetSeed(CheckRules r)
        {

            Queue<uint> Getqeueu = new Queue<uint>();
            if (r.Method == MethodType.Roaming8b &&
                r.minHP==31&&
                r.minAtk == 31 &&
                r.minDef==31&&
                r.minSpA==31&&
                r.minSpD==31&&
                r.minSpe==31&&
                r.Shiny != PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(1);
            }
            else if (r.Method == MethodType.Roaming8b &&
                r.maxAtk == 0 &&
                r.maxSpe == 0 &&
                r.Shiny != PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(2);
            }
            else if (r.Method == MethodType.Roaming8b &&
                r.maxAtk == 0 &&
                r.maxSpe != 0 &&
                r.Shiny != PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(3);
            }
            else if (r.Method == MethodType.Roaming8b &&
                r.maxAtk != 0 &&
                r.maxSpe == 0 &&
                (r.Shiny != PkmCondition.ShinyType.None && r.Shiny != PkmCondition.ShinyType.Sqaure))
            {
                Getqeueu = SeedList.EnqueueSeed(4);
            }
            else if (r.Method == MethodType.Overworld8 &&
              r.maxAtk == 0 &&
                r.maxSpe != 0 &&
               r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(5);
            }
            else if (r.Method == MethodType.Overworld8 &&
              r.maxAtk != 0 &&
               r.maxSpe == 0 &&
              r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(6);
            }
            else if (r.Method == MethodType.Overworld8 &&
             r.maxAtk == 0 &&
              r.maxSpe == 0 &&
             r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(7);
            }
            else if (r.Method == MethodType.Overworld8 &&
             r.maxAtk!=0 &&
             r.maxSpe!=0 &&
             r.minAtk==31 &&
             r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(8);
            }
            return Getqeueu;
        }
    }
}
