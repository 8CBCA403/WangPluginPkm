using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangPlugin;

namespace WangPlugin.WangUtil.DexBase
{
    internal class SilvallyDex
    {
        public static List<PKM> SilvallySets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int j = 0; j < 18; j++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 772, 30, 0, false);
                            pk.Species = 773;
                            pk.CurrentFriendship = 255;
                            pk.CurrentLevel = 70;
                            pk.Form = (byte)j;
                            pk.Ability = 225;
                            if (j > 0)
                                pk.HeldItem = 903 + j;
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                    }
                    break;
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    {
                        for (int j = 0; j < 18; j++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 772, 45, 0, false);
                            pk.Species = 773;
                            pk.CurrentFriendship = 255;
                            pk.CurrentLevel = 70;
                            pk.Form = (byte)j;
                            pk.Ability = 225;
                            if (j > 0)
                                pk.HeldItem = 903 + j;
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
