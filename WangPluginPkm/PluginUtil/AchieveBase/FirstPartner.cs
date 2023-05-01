using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase
{
    internal class FirstPartner
    {
        public static List<PKM> FRLGSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 4, (int)GameVersion.FR);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 4;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 1, (int)GameVersion.LG);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 5;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 7, (int)GameVersion.LG);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 4;
                PKL.Add(pk);

            }
            return PKL;
        }
        public static List<PKM> HGSSSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 152, (int)GameVersion.HG);

                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 7;
                PKL.Add(pk);

                pk = SearchDatabase.SearchPKM(SAV, Editor, 155, (int)GameVersion.SS);

                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 8;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 158, (int)GameVersion.HG);

                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 7;
                PKL.Add(pk);

            }
            return PKL;
        }
        public static List<PKM> RSESets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 252, (int)GameVersion.R);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 255, (int)GameVersion.S);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 258, (int)GameVersion.E);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 3;
                PKL.Add(pk);
            }
            return PKL;
        }
        public static List<PKM> DPPTSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Turtwig, (int)GameVersion.D);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 10;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Chimchar, (int)GameVersion.P);
                pk = AchieveFunc.fun(pk,SAV);
                pk.Version = 11;
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Piplup, (int)GameVersion.Pt);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);

            }
            return PKL;
        }
        public static List<PKM> BWSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 495, (int)GameVersion.B);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 498, (int)GameVersion.W);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 501, (int)GameVersion.W2);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
            }
            return PKL;
        }
        public static List<PKM> XYSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;

            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 650, (int)GameVersion.X);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 653, (int)GameVersion.Y);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 656, (int)GameVersion.X);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
            }
            return PKL;
        }
        public static List<PKM> SMSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 722, (int)GameVersion.SN);             
                pk = AchieveFunc.fun(pk,SAV);              
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 725, (int)GameVersion.MN);             
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 728, (int)GameVersion.US);
                pk = AchieveFunc.fun(pk,SAV);
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
