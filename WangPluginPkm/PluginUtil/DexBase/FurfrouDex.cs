using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class FurfrouDex
    {
        public static List<PKM> FurfrouSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
               GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        
                            for (int j = 0; j < 10; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor, 676, 24, 0, false);
                                pk.Form = (byte)j;
                                pk.ClearNickname();
                                PKL.Add(pk);
                            }
                        
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                     
                            for (int j = 0; j < 10; j++)
                            {
                                pk = SearchDatabase.SearchPKM(SAV, Editor,676, 30, 0, true);
                                pk.Form = (byte)j;
                             
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
