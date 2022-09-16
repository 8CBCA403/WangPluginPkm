using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class ZygardeDex
    {
        public static List<PKM> ZygardeSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 718, 30);
                            pk.Form = (byte)i;
                            if(i is 2 or 3)
                            {
                                pk.Ability = 211;
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
