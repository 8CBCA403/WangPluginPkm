using System;

namespace WangPluginPkm.PluginUtil.ModifyPKM
{
    [Serializable]
    public class litePK
    {
        public string Name { get; set; }
        public int Species { get; set; }
        public int Nature { get; set; }
        public int Ability { get; set; }
        public int HeldItem { get; set; }
        public int Ball { get; set; }
        public int Language { get; set; }
        public decimal Form { get; set; }
        public decimal AbilityNumber { get; set; }
        public int Move1 { get; set; }
        public int Move2 { get; set; }
        public int Move3 { get; set; }
        public int Move4 { get; set; }
        public int RelearnMove1 { get; set; }
        public int RelearnMove2 { get; set; }
        public int RelearnMove3 { get; set; }
        public int RelearnMove4 { get; set; }
        public int[] IVS { get; set; } = new int[6];
        public int[] EVS { get; set; } = new int[6];
        public int CurrentLevel { get; set; }

        public int StatNature { get; set; } = 0;

        public int TeraType { get; set; } = 0;
        public static string lptoSt(litePK pk)
        {
            string r = "";
            string ivst = "";
            string evst = "";
            for (int i = 0; i < 6; i++)
            {
                ivst += $"{pk.IVS[i]}" + "/";
            }
            for (int i = 0; i < 6; i++)
            {
                evst += $"{pk.EVS[i]}" + "/";
            }
            r = $"{pk.Name},{pk.Species},{pk.Nature},{pk.Ability},{pk.HeldItem},{pk.Ball},{pk.Language}," +
                $"{pk.Form},{pk.AbilityNumber},{pk.CurrentLevel}:{ivst}:{evst}:{pk.Move1},{pk.Move2},{pk.Move3},{pk.Move4}:" +
                $"{pk.RelearnMove1},{pk.RelearnMove2},{pk.RelearnMove3},{pk.RelearnMove4}:" +
                $"{pk.StatNature},{pk.TeraType}#";
            return r;
        }
    }
}
