using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPluginPkm.PluginUtil.AchieveBase;

namespace WangPluginPkm.PluginUtil.MeerkatBase
{
    internal class MytheryPK
    {
        public static List<PKM> ESets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Mew, (int)GameVersion.E);
                pk = AchieveFunc.fun(pk,SAV);
                pk.OT_Name = "Meerk";
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Deoxys, (int)GameVersion.E);
                pk = AchieveFunc.fun(pk, SAV);
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
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Meloetta, (int)GameVersion.W2,0,false,40001);
                pk.Language = 2;
                pk.ClearNickname();
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 649, 23, 0, false, 40007);
                pk.Language = 2;
                pk.ClearNickname();
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 647, 23, 0, false, 40001);
                pk.Language = 2;
                pk.ClearNickname();
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 647, 23, 0, false, 40001);
                pk.Language = 2;
                pk.ClearNickname();
                pk.Form = 1;
                PKL.Add(pk);
            }
            return PKL;
        }
        public static List<PKM> ORASSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)Species.Beldum, (int)GameVersion.OR, 0, false, 40048);
                pk.Language = 2;
                pk.ClearNickname();
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor,719, 27, 0);
                pk.Language = 2;
                pk.ClearNickname();
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
                pk = SearchDatabase.SearchPKM(SAV, Editor, 446, (int)GameVersion.SN, 0, false, 40051);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 658, (int)GameVersion.SN, 0,false,30010);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 801, (int)GameVersion.SN, 0, false, 40001);
                PKL.Add(pk);
            }
            return PKL;
        }
        public static List<PKM> USUMSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            if (SAV.SAV.Version is GameVersion.US or GameVersion.UM or GameVersion.USUM)
            {
                pk = SearchDatabase.SearchPKM(SAV, Editor, 791, (int)GameVersion.US, 0, false, 40001);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 792, (int)GameVersion.UM, 0, false, 40001);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 800, (int)GameVersion.US, 0, false, 40001);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 803, (int)GameVersion.US, 0, false, 40001);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 785, (int)GameVersion.US, 0, false, 40052);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 786, (int)GameVersion.UM, 0, false, 40052);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 787, (int)GameVersion.US, 0, false, 40052);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 788, (int)GameVersion.US, 0, false, 40052);
                PKL.Add(pk);
                pk = SearchDatabase.SearchPKM(SAV, Editor, 718, (int)GameVersion.US, 0, false, 40001);
                PKL.Add(pk);
            }
            return PKL;
        }
    }
}
