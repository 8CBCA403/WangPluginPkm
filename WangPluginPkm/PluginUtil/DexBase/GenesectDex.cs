using PKHeX.Core;
using System.Collections.Generic;
namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class GenesectDex
    {
        public static List<PKM> GenesectSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            List<int> Drive = new()
            {
                116,117,118,119
            };
            switch (SAV.SAV.Version)
            {
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
                GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 649, 20);
                            pk.Form = (byte)i;
                            if (i > 0)
                            {
                                pk.HeldItem = Drive[i - 1];
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }

                    }
                    break;
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 649, 24);
                            pk.Form = (byte)i;
                            if (i > 0)
                            {
                                pk.HeldItem = Drive[i - 1];
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }

                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var pk6 = SearchDatabase.SearchPKM(SAV, Editor, 649, 24);
                            pk6.Form = (byte)i;
                          
                            if (i > 0)
                            {
                                pk6.HeldItem = Drive[i - 1];
                            }
                            pk6.ClearNickname();
                            PKL.Add(pk6);
                        }

                    }
                    break;
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 649, 45);
                            pk.Form = (byte)i;
                            if (i > 0)
                            {
                                pk.HeldItem = Drive[i - 1];
                            }
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }

                    }
                    break;
            }
            return PKL;
        }
    }
}
