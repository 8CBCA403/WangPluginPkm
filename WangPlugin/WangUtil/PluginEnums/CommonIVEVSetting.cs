using PKHeX.Core;

namespace WangPlugin
{
    internal class CommonIVEVSetting
    {
        public static void ATKIVEV(PKM pk, IPKMView Editor)
        {
            int[] iv = { 31, 31, 31, 31, 31, 31 };
            int[] ev = { 6, 252, 0, 252, 0, 0 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = 13;
            pk.StatNature = pk.Nature;
            Editor.PopulateFields(pk);
        }
        public static void SPAIVEV(PKM pk, IPKMView Editor)
        {
            int[] iv = { 31, 0, 31, 31, 31, 31 };
            int[] ev = { 6, 0, 0, 252, 252, 0 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = 10;
            pk.StatNature = pk.Nature;
            Editor.PopulateFields(pk);
        }
        public static void ATK_0SPEIVEV(PKM pk, IPKMView Editor)
        {
            int[] iv = { 31, 31, 31, 0, 31, 31 };
            int[] ev = { 252, 252, 0, 0, 0, 6 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = 2;
            pk.StatNature = pk.Nature;
            Editor.PopulateFields(pk);
        }
        public static void SPA_0SPEIVEV(PKM pk, IPKMView Editor)
        {
            int[] iv = { 31, 0, 31, 0, 31, 31 };
            int[] ev = { 252, 0, 0, 0, 252, 6 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = 17;
            pk.StatNature = pk.Nature;
            Editor.PopulateFields(pk);
        }
        public static void TANKIVEV(PKM pk,IPKMView Editor)
        {
            int[] iv = { 31, 0, 31, 0, 31, 31 };
            int[] ev = { 252, 0, 6, 0, 0, 252 };
            pk.IVs = iv;
            pk.SetEVs(ev);
            pk.Nature = 22;
            pk.StatNature = pk.Nature;
            Editor.PopulateFields(pk);
        }
    }
}
