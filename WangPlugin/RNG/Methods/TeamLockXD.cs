using PKHeX.Core;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WangPlugin.RNG.Methods
{
    internal static class TeamLockXD
    {
        public static bool GenPkm(uint seed, NPCClass T)
        {
            var A = XDRNG.Next(seed); // IV1
            var B = XDRNG.Next(A); // IV2
            var C = XDRNG.Next(B); // Ability?
            var D = XDRNG.Next(C); // PID
            var E = XDRNG.Next(D); // PID
            var PID = D & 0xFFFF0000 | E >> 16;
            var Gender = (PID & 0xFF) < T.Ratio ? 1 : 0;
            var Nature = (int)(PID % 25);
            if (Gender == T.Gender && Nature == T.Nature || T.Gender == 2 && Nature == T.Nature)
            {
                return true;
            }
            return false;
        }

    }
}