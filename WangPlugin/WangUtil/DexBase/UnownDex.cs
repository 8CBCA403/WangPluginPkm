using System.Collections.Generic;
using System.Windows.Forms;
using PKHeX.Core;
using PKHeX.Core.AutoMod;

namespace WangPlugin.WangUtil.DexBase
{
    internal class UnownDex
    {
        public static List<PKM> UnownSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.GD or GameVersion.SI or GameVersion.C or 
                GameVersion.GS or GameVersion.GSC:
                    for (int i = 0; i < 26; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 201, 53);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.S or GameVersion.E or GameVersion.R or 
                GameVersion.FR or GameVersion.LG or GameVersion.RSE or GameVersion.RS:
                    for (int i = 0; i < 28; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 201, 5);
                        pk.Form = (byte)i;
                        pk = SAV.SAV.Legalize(pk);
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.D or GameVersion.P or GameVersion.SS or GameVersion.HG or
                GameVersion.HGSS or GameVersion.DP or GameVersion.Pt or GameVersion.DPPt:
                    for (int i = 0; i < 28; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 201, 7);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.B or GameVersion.W or GameVersion.B2 or
                GameVersion.W2 or GameVersion.BW or GameVersion.B2W2:
                    for (int i = 0; i < 28; i++)
                    {
                        PK4 pk4 = (PK4)SearchDatabase.SearchPKM(SAV, Editor, 201, 7);
                        pk4.Form = (byte)i;
                        PKL.Add(pk4.ConvertToPK5());
                    }
                    break;
                case GameVersion.X or GameVersion.Y or GameVersion.OR or 
                GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    for (int i = 0; i < 28; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 201, 27);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US 
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    for (int i = 0; i < 28; i++)
                    {
                        PK6 pk6 = (PK6)SearchDatabase.SearchPKM(SAV, Editor, 201, 27);
                        pk6.Form = (byte)i;
                        pk6.OT_Name = "wang";
                        PKL.Add(pk6.ConvertToPK7());
                    }
                    break;
                case GameVersion.BD or GameVersion.SP or GameVersion.BDSP:
                    for (int i = 0; i < 28; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 201, 48,i);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.PLA:
                    for (int i = 0; i < 28; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 201, 47,i);
                        pk.Form = (byte)i;
                        PKL.Add(pk);
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
