using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class FlabébéDex
    {
        public static List<PKM> FlabébéSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
               GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(669 + i), 24, j, false);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit1(pk);
                                }
                                else if(i==2)
                                {
                                    pk = Edit2(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(669 + i), 30, j, true);
                                pk.Form = (byte)j;
                                if (i == 1)
                                {
                                    pk = Edit1(pk);
                                }
                                else if (i == 2)
                                {
                                    pk = Edit2(pk);
                                }
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        }
                    }
                    break;
            }
            return PKL;
        }
        public static PKM Edit1(PKM pk)
        {
            pk.CurrentLevel = 50;
            pk.Species = 670;

            return pk;
        }
        public static PKM Edit2(PKM pk)
        {
            pk.CurrentLevel = 100;
            pk.Species = 671;

            return pk;
        }
    }
}
