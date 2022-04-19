using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin
{
   

    public record IVs
    {
        public uint hp;
        public uint atk;
        public uint def;
        public uint spa;
        public uint spd;
        public uint spe;
    }
    public class Frame
    {
        public uint seed;
        public int number;
        public uint rngValue;
        public uint pid;
        public uint TID;
        public uint SID;
        public IVs ivs;
        
    }

    public static class FrameUtil
    {

        public static IVs dvsToIVs(uint dvUpper, uint dvLower)
        {
            return new IVs
            {
                hp = dvLower & 0x1f,
                atk = (dvLower & 0x3E0) >> 5,
                def = (dvLower & 0x7C00) >> 10,
                spe = dvUpper & 0x1f,
                spa = (dvUpper & 0x3E0) >> 5,
                spd = (dvUpper & 0x7C00) >> 10
            };
        }
    }

}

