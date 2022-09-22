using PKHeX.Core;
using System;
using WangPlugin.GUI;

namespace WangPlugin
{
    internal static class NoMethod
    {
        public static bool GenPkm(ref PKM pk, CheckRules r)
        {
            pk.PID= Util.Rand32();
            pk.PID = CheckShiny(pk, r.Shiny);
            pk.Gender = GenderApplicator.GetSaneGender(pk);
            if(pk.Gen8==true)
                pk.SetRandomEC();
            pk.RefreshAbility((int)(pk.PID & 1));
            pk.IV_HP =(int) r.minHP;
            pk.IV_ATK = (int)r.minAtk;
            pk.IV_DEF = (int)r.minDef;
            pk.IV_SPA = (int)r.minSpA;
            pk.IV_SPD = (int)r.minSpD;
            pk.IV_SPE = (int)r.minSpe;
            return true;
        }
        private static uint CheckShiny(PKM pk, PkmCondition.ShinyType S)
        {
            Random myObject = new Random();
            var r=(uint)myObject.Next(1, 8);
            if(pk.Gen8==true)
                r= (uint)myObject.Next(1, 16);
            if (S == PkmCondition.ShinyType.None)
                return pk.PID;
            else if (S == PkmCondition.ShinyType.Shiny)
            {
                pk.SetShiny();
                return pk.PID;
            }
            else if (S == PkmCondition.ShinyType.Star)
            {
                return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ r) << 16) | (pk.PID & 0xFFFF);
            }
            else if (S == PkmCondition.ShinyType.Sqaure)
            {
                return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ 0u) << 16) | (pk.PID & 0xFFFF);
            }

            else if (S == PkmCondition.ShinyType.Star)
                return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ 1u) << 16) | (pk.PID & 0xFFFF);
            else
                return pk.PID;
        }
    }
}
