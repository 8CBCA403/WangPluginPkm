using System.Collections.Generic;

namespace WangPluginPkm
{
    public class RNGModClass
    {
        public string Name { get; set; }
        public string Value { get; set; }


        public static List<RNGModClass> RNGModList(bool isIV)
        {
            var L = new List<RNGModClass>();
            RNGModClass M124 = new RNGModClass
            {
                Name = "Mothed1,2,4",
                Value = "M124",
            };
            RNGModClass M3 = new RNGModClass
            {
                Name = "Mothed3",
                Value = "M3",
            };
            RNGModClass M124U = new RNGModClass
            {
                Name = "Mothed1,2,4 Unown",
                Value = "M124U",
            };
            RNGModClass M3U = new RNGModClass
            {
                Name = "Mothed3 Unown",
                Value = "M3U",
            };
            RNGModClass XDColo = new RNGModClass
            {
                Name = "XDColo",
                Value = "XDColo",
            };
            RNGModClass Overword8 = new RNGModClass
            {
                Name = "Overworld8",
                Value = "Overworld8",
            };
            RNGModClass M1 = new RNGModClass
            {
                Name = "Mothed1/U",
                Value = "M1",
            };
            RNGModClass M23 = new RNGModClass
            {
                Name = "Mothed2,3/U",
                Value = "M23",
            };
            RNGModClass M4 = new RNGModClass
            {
                Name = "Mothed4/U",
                Value = "M4",
            };
            RNGModClass Tera9 = new RNGModClass
            {
                Name = "Tera9",
                Value = "Tera9",
            };

            if (!isIV)
            {
                L.Add(M124);
                L.Add(M3);
                L.Add(M124U);
                L.Add(M3U);
                L.Add(XDColo);
                L.Add(Overword8);
                L.Add(Tera9);
            }
            else
            {
                L.Add(M1);
                L.Add(M23);
                L.Add(M4);
                L.Add(XDColo);
            }
            return L;
        }
    }
}
