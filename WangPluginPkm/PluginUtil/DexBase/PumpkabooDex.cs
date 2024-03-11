using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class PumpkabooDex
    {
        public static List<PKM> PumpkabooSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
               GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 710, 24, 0, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.OriginalTrainerName = "wang";
                                pk.SetSuggestedMemories();
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }

                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {

                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 710, 30, 0, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit(pk);
                                }
                                pk.OriginalTrainerName = "wang";
                                pk.SetSuggestedMemories();
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }

                    }
                    break;
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 710, 45, 0, true);
                            pk.Form = (byte)j;
                            if (i == 1)
                            {
                                pk = Edit(pk);
                            }
                            pk.OriginalTrainerName = "wang";
                            pk.SetSuggestedMemories();
                            pk.ClearNickname();
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
            pk.Species = 711;

            return pk;
        }
    }
}
