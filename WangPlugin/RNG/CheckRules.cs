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

        public enum IV
        {
            V0,
            V6,
            A0,
            S0,
            A0S0,
            SPA0,
            A0S0SPA0
        }

        public PkmCondition.ShinyType Shiny  { get; set; }

        public PkmCondition.MethodType Method { get; set; }
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
        public static List<uint> PreSetSeed(CheckRules r)
        {

            List<uint> Getqeueu = new List<uint>();
            if (r.Method == PkmCondition.MethodType.Roaming8b &&
               CheckIV(r,IV.V6)&&r.Shiny != PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Roaming8_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Roaming8b &&
              CheckIV(r, IV.A0S0 )&&r.Shiny != PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Roaming8_0a0s);
            }
            else if (r.Method == PkmCondition.MethodType.Roaming8b &&
                CheckIV(r, IV.A0) &&r.Shiny != PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Roaming8_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Roaming8b &&
               CheckIV(r, IV.S0) &&(r.Shiny != PkmCondition.ShinyType.None && r.Shiny != PkmCondition.ShinyType.Sqaure))
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Roaming8_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Overworld8 &&
               CheckIV(r, IV.V0) )
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.OverWorld8_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Overworld8 &&
              CheckIV(r, IV.A0S0SPA0) && r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.OverWorld8_0a0spa0s);
            }
            else if (r.Method == PkmCondition.MethodType.Overworld8 &&
               CheckIV(r, IV.A0) &&r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.OverWorld8_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Overworld8 &&
             CheckIV(r, IV.S0) &&r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.OverWorld8_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Overworld8 &&
             CheckIV(r, IV.A0S0) &&r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.OverWorld8_0a0s);
            }
            else if (r.Method == PkmCondition.MethodType.Overworld8 &&
           CheckIV(r, IV.SPA0) && r.Shiny == PkmCondition.ShinyType.Sqaure)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.OverWorld8_0spa);
            }
            else if (r.Method == PkmCondition.MethodType.Method1 &&
              CheckIV(r, IV.V0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method1 &&
               CheckIV(r, IV.V6) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method1 &&
               CheckIV(r, IV.A0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method1 &&
            CheckIV(r, IV.S0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method1 &&
           CheckIV(r, IV.A0S0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_0a0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method2 &&
           CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method2 &&
           CheckIV(r, IV.V6) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method2 &&
           CheckIV(r, IV.A0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method2 &&
            CheckIV(r, IV.S0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method2 &&
             CheckIV(r, IV.A0S0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_0a0s);
            }


            else if (r.Method == PkmCondition.MethodType.Method3 &&
          CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method3 &&
           CheckIV(r, IV.V6) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method3 &&
           CheckIV(r, IV.A0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method3 &&
            CheckIV(r, IV.S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method3 &&
             CheckIV(r, IV.A0S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_0a0s);
            }


            else if (r.Method == PkmCondition.MethodType.Method4 &&
           CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method4 &&
            CheckIV(r, IV.V6) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method4 &&
            CheckIV(r, IV.A0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method4 &&
            CheckIV(r, IV.S0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method4 &&
             CheckIV(r, IV.A0S0) &&r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_0a0s);
            }


            else if (r.Method == PkmCondition.MethodType.Method1_Unown &&
            CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_Unown_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method1_Unown &&
               CheckIV(r, IV.V6) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_Unown_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method1_Unown &&
               CheckIV(r, IV.A0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_Unown_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method1_Unown &&
            CheckIV(r, IV.S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_Unown_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method1_Unown &&
           CheckIV(r, IV.A0S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method1_Unown_0a0s);
            }


            else if (r.Method == PkmCondition.MethodType.Method2_Unown &&
           CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_Unown_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method2_Unown &&
           CheckIV(r, IV.V6) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_Unown_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method2_Unown &&
           CheckIV(r, IV.A0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_Unown_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method2_Unown &&
            CheckIV(r, IV.S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_Unown_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method2_Unown &&
             CheckIV(r, IV.A0S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method2_Unown_0a0s);
            }

            else if (r.Method == PkmCondition.MethodType.Method3_Unown &&
       CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_Unown_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method3_Unown &&
           CheckIV(r, IV.V6) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_Unown_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method3_Unown &&
           CheckIV(r, IV.A0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_Unown_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method3_Unown &&
            CheckIV(r, IV.S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_Unown_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method3_Unown &&
             CheckIV(r, IV.A0S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method3_Unown_0a0s);
            }

            else if (r.Method == PkmCondition.MethodType.Method4_Unown &&
           CheckIV(r, IV.V0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_Unown_0V);
            }
            else if (r.Method == PkmCondition.MethodType.Method4_Unown &&
            CheckIV(r, IV.V6) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_Unown_6V);
            }
            else if (r.Method == PkmCondition.MethodType.Method4_Unown &&
            CheckIV(r, IV.A0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_Unown_0a);
            }
            else if (r.Method == PkmCondition.MethodType.Method4_Unown &&
            CheckIV(r, IV.S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_Unown_0s);
            }
            else if (r.Method == PkmCondition.MethodType.Method4_Unown &&
             CheckIV(r, IV.A0S0) && r.Shiny == PkmCondition.ShinyType.None)
            {
                Getqeueu = SeedList.AddSeed(SeedList.SeedType.Method4_Unown_0a0s);
            }
            return Getqeueu;
            
        }

        public static bool CheckIV(CheckRules r,IV iv)
        {
            switch(iv)
            {
                case IV.V0:
                    if (r.minHP  == 0 &&r.minAtk == 0 &&
                        r.minDef == 0 &&r.minSpA == 0 &&
                        r.minSpD == 0 &&r.minSpe == 0 )
                        return true;
                    break;
                case IV.V6:
                    if (r.minHP == 31 && r.minAtk == 31 &&
                        r.minDef == 31 && r.minSpA == 31 &&
                        r.minSpD == 31 && r.minSpe == 31)
                        return true;
                    break;
                case IV.A0:
                    if (r.maxAtk == 0 &&r.maxSpe != 0)
                        return true;
                    break;
                case IV.S0:
                    if (r.maxAtk != 0 &&r.maxSpe == 0)
                        return true;
                    break;
                case IV.A0S0:
                    if (r.maxAtk == 0 &&r.maxSpe == 0)
                        return true;
                    break;
                case IV.SPA0:
                    if (r.maxAtk != 0 &&r.maxSpe != 0 &&r.minAtk == 31&& r.minSpA == 0)
                        return true;
                    break;
                case IV.A0S0SPA0:
                    if (r.maxAtk == 0 && r.maxSpe == 0 && r.minAtk == 0)
                        return true;
                    break;
            }
            return false;
        }
    }
}
