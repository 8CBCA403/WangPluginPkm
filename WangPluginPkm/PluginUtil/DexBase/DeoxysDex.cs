using PKHeX.Core;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WangPluginPkm.PluginUtil.DexBase
{
    internal class DeoxysDex
    {
        public static List<PKM> DeoxysSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.D or GameVersion.P or GameVersion.SS or GameVersion.HG or
                GameVersion.HGSS or GameVersion.DP or GameVersion.Pt or GameVersion.DPPt:
                    for (int i = 0; i < 4; i++)
                    {
                        PK3 pk3 = (PK3)SearchDatabase.SearchPKM(SAV, Editor, 386, 3);
                        pk = pk3.ConvertToPK4();
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
                GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    for (int i = 0; i < 4; i++)
                    {
                        PK3 pk3 = (PK3)SearchDatabase.SearchPKM(SAV, Editor, 386, 3);
                        PK4 pk4 = pk3.ConvertToPK4();
                        pk = pk4.ConvertToPK5();
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    for (int i = 0; i < 4; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 386, 27, 0, false, 316);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    for (int i = 0; i < 4; i++)
                    {
                        PK6 pk6 = (PK6)SearchDatabase.SearchPKM(SAV, Editor, 386, 27, 0, false, 316);
                        pk6.Form = (byte)i;
                        pk6.OT_Name = "wang";
                        PKL.Add(pk6.ConvertToPK7());
                    }
                    break;
                default:
                    MessageBox.Show("本作无法获得！");
                    break;

            }
            return PKL;
        }
    }
}
