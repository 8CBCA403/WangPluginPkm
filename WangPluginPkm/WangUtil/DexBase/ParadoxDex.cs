using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.WangUtil.DexBase
{
    internal class ParadoxDex
    {
        public static List<PKM> ParadoxSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.SL or GameVersion.VL or GameVersion.SV:
               
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 978, 50);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 979, 50);
                        pk.ClearNickname();
                        PKL.Add(pk);
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(981+i), 50);
                            pk.ClearNickname();
                            PKL.Add(pk);
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, (ushort)(988 + i), 50);
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
