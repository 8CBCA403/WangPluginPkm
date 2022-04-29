using PKHeX.Core;
using System;

namespace WangPlugin
{
    internal static class NoMethod
    {
        public static bool GenPkm(ref PKM pk, bool[] shiny, bool[] IV)
        {
            pk.PID= Util.Rand32();
            pk.PID = CheckShiny(pk, shiny);
            pk.Gender = PKX.GetGenderFromPID(pk.Species, pk.PID);
            if(pk.Gen8==true)
                pk.SetRandomEC();
            pk.RefreshAbility((int)(pk.PID & 1));
            if (IV[0])
            {
                pk.IV_ATK=0;
            }
            if (IV[1])
            {
                pk.IV_SPE=0;
            }
            return true;
        }
      
        private static uint CheckShiny(PKM pk, bool[] shiny)
        {
            Random myObject = new Random();
            var r=(uint)myObject.Next(1, 8);
            if(pk.Gen8==true)
                r= (uint)myObject.Next(1, 16);
            if (shiny[0])
                return pk.PID;
            else if (shiny[1])
            {
                pk.SetShiny();
                return pk.PID;
            }
            else if (shiny[2])
            {
                return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ r) << 16) | (pk.PID & 0xFFFF);
            }
            else if (shiny[3])
            {
                return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ 0u) << 16) | (pk.PID & 0xFFFF);
            }

            else if (shiny[4])
                return (((uint)(pk.TID ^ pk.SID) ^ (pk.PID & 0xFFFF) ^ 1u) << 16) | (pk.PID & 0xFFFF);
            else
                return pk.PID;
        }
    }
}
