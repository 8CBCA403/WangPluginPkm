using PKHeX.Core;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Deerling
    {
        public static List<PKM> SpringSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 30, 0, true);
                            {
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                            }
                            pk.Form = (byte)0;
                            pk.ClearNickname();
                            pk = AchieveFunc.fun(pk, SAV);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> SummerSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 30, 1, true);
                            {
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                            }
                            pk.Form = (byte)1;
                            pk.ClearNickname();
                            pk = AchieveFunc.fun(pk, SAV);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> AutumnSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 30, 2, true);
                            {
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                            }
                            pk.Form = (byte)2;
                            pk.ClearNickname();
                            pk = AchieveFunc.fun(pk, SAV);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> WinterSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 585, 30, 3, true);
                            {
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                            }
                            pk.Form = (byte)3;
                            pk.ClearNickname();
                            pk = AchieveFunc.fun(pk, SAV);
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static PKM Edit(PKM pk)
        {
            pk.CurrentLevel = 50;
            pk.Species = 586;
            return pk;
        }
    }
}
