using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WangPlugin.RNG
{
    internal class E_Reader
    {
        public static uint Next(uint seed) => XDRNG.Next(seed);
        public static bool GenPkm(ref PKM pk, uint seed, CheckRules r)
        {
            var Togepi=  new NPCClass(175, 22, 1, 031); // Togepi (F) (Sassy) -- itself!
            var Mareep = new NPCClass(179, 16, 1, 127); // Mareep (F) (Mild) -- itself!
            var Scizor = new NPCClass(212, 11, 0, 127); // Scizor (M) (Hasty) -- itself!
            int Ratio = 0;
            int Nature = 0;
            int Gender = 0;
            var D = XDRNG.Prev3(seed); // PID
            var E = XDRNG.Next(D); // PID
            pk.PID = (D & 0xFFFF0000) | (E >> 16);
            if (!r.CheckShiny(r, pk))
            {
                return false;
            }
            if (pk.Species == 175)
            {
                Ratio = Togepi.Ratio;
                Nature = Togepi.Nature;
                Gender= Togepi.Gender;
            }
            else if(pk.Species==179)
            {
                Ratio = Mareep.Ratio;
                Nature = Mareep.Nature;
                Gender = Mareep.Gender;
            }
            else if(pk.Species==212)
            {
                Ratio = Scizor.Ratio;
                Nature = Scizor.Nature;
                Gender = Scizor.Gender;
            }
            pk.Nature = (int)(pk.PID % 100 % 25);
            pk.RefreshAbility((int)(pk.PID & 1));
            pk.Gender = ((pk.PID & 0xFF) < Ratio ? 1 : 0);
            
            if (pk.Nature != Nature || pk.Gender != Gender)
            {
                return false;
            }
            for (int i = 0; i < 6; i++)
                pk.SetIV(i, 0);
            return true;
        }

    }
}
