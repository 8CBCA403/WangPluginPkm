using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.DisBase
{
    internal class PerfectDitto
    {

        public static List<PKM> SearchDitto(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SL or GameVersion.VL or GameVersion.SV:
                    {
                        for (int i = 0; i < 30; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Ditto, 50, 0, false, 28);
                            pk = EditPKM(pk, i);
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static PKM EditPKM(PKM pk, int n)
        {
            int[] Atkiv = { 31, 31, 31, 31, 31, 31 };
            int[] Spaiv = { 31, 0, 31, 31, 31, 31 };
            int[] Tankiv = { 31, 0, 31, 0, 31, 31 };
            int[] Tiv = { 31, 31, 31, 0, 31, 31 };
            switch (n)
            {
                case 0:
                    pk.Nature = (int)Nature.Bold;
                    pk.IVs = Atkiv;
                    break;
                case 1:
                    pk.Nature = (int)Nature.Timid;
                    pk.IVs = Spaiv;
                    break;
                case 2:
                    pk.Nature = (int)Nature.Adamant;
                    pk.IVs = Atkiv;
                    break;
                case 3:
                    pk.Nature = (int)Nature.Hasty;
                    pk.IVs = Atkiv;
                    break;
                case 4:
                    pk.Nature = (int)Nature.Lax;
                    pk.IVs = Atkiv;
                    break;
                case 5:
                    pk.Nature = (int)Nature.Quiet;
                    pk.IVs = Tankiv;
                    break;
                case 6:
                    pk.Nature = (int)Nature.Rash;
                    pk.IVs = Atkiv;
                    break;
                case 7:
                    pk.Nature = (int)Nature.Mild;
                    pk.IVs = Atkiv;
                    break;
                case 8:
                    pk.Nature = (int)Nature.Modest;
                    pk.IVs = Spaiv;
                    break;
                case 9:
                    pk.Nature = (int)Nature.Lonely;
                    pk.IVs = Atkiv;
                    break;
                case 10:
                    pk.Nature = (int)Nature.Careful;
                    pk.IVs = Atkiv;
                    break;
                case 11:
                    pk.Nature = (int)Nature.Jolly;
                    pk.IVs = Atkiv;
                    break;
                case 12:
                    pk.Nature = (int)Nature.Impish;
                    pk.IVs = Atkiv;
                    break;
                case 13:
                    pk.Nature = (int)Nature.Naive;
                    pk.IVs = Atkiv;
                    break;
                case 14:
                    pk.Nature = (int)Nature.Naughty;
                    pk.IVs = Atkiv;
                    break;
                case 15:
                    pk.Nature = (int)Nature.Calm;
                    pk.IVs = Atkiv;
                    break;
                case 16:
                    pk.Nature = (int)Nature.Gentle;
                    pk.IVs = Atkiv;
                    break;
                case 17:
                    pk.Nature = (int)Nature.Brave;
                    pk.IVs = Tiv;
                    break;
                case 18:
                    pk.Nature = (int)Nature.Relaxed;
                    pk.IVs = Atkiv;
                    break;
                case 19:
                    pk.Nature = (int)Nature.Sassy;
                    pk.IVs = Atkiv;
                    break;
                case 20:
                    pk.Nature = (int)Nature.Relaxed;
                    pk.IVs = Tankiv;
                    break;
                case 21:
                    pk.Nature = (int)Nature.Sassy;
                    pk.IVs = Tankiv;
                    break;
                case 22:
                    pk.Nature = (int)Nature.Calm;
                    pk.IVs = Spaiv;
                    break;
                case 23:
                    pk.Nature = (int)Nature.Sassy;
                    pk.IVs = Tiv;
                    break;
                case 24:
                    pk.Nature = (int)Nature.Relaxed;
                    pk.IVs = Tiv;
                    break;
                case 25:
                    pk.Nature = (int)Nature.Brave;
                    pk.IVs = Atkiv;
                    break;
                case 26:
                    pk.Nature = (int)Nature.Bold;
                    pk.IVs = Spaiv;
                    break;
                case 27:
                    pk.Nature = (int)Nature.Quiet;
                    pk.IVs = Tiv;
                    break;
                case 28:
                    pk.Nature = (int)Nature.Quiet;
                    pk.IVs = Atkiv;
                    break;
                case 29:
                    pk.Nature = (int)Nature.Timid;
                    pk.IVs = Atkiv;
                    break;


            }
            pk.StatNature = pk.Nature;
            return pk;
        }

    }
}
