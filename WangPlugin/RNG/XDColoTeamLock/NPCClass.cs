using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin
{
    public class NPCClass
    {
        public ushort Species { get; set; }

        public int Nature { get; set; }

        public int Gender { get; set; }    

        public int Ratio { get; set; } 

        public NPCClass(ushort species, int nature, int gender, int ratio)
        {
            Species = species;
            Nature = nature;
            Gender = gender;
            Ratio = ratio;
        }
    }
}
