using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.WangUtil.DexBase
{
    internal class AlolaformDex
    {
        public static List<ushort> Alola = new List<ushort>
               { 19,20,26,27,28,37,38,50,51,
                 52,53,74,75,76,88,89,103,105
                };
        public static List<ushort> SWSH = new List<ushort>
               { 
                 26,27,28,37,38,50,51,52,53,103,105
                };
        public static List<PKM> AlolaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {

                case GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM:
                    for (int i = 0; i < Alola.Count; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, Alola[i], 30,1,true);
                        pk.CurrentLevel = 100;
                        pk.Species = Alola[i];
                        pk.Form = 1;
                        ModifyAbilityAndOT(ref pk);
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;
                case GameVersion.SW or GameVersion.SH or GameVersion.SWSH:
                    for (int i = 0; i < SWSH.Count; i++)
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, SWSH[i], 45, 1, true);
                        pk.CurrentLevel = 100;
                        pk.Species = SWSH[i];
                        pk.Form = 1;
                        ModifyAbilityAndOT(ref pk);
                        pk.ClearNickname();
                        PKL.Add(pk);
                    }
                    break;

            }
            return PKL;
        }
        public static void ModifyAbilityAndOT(ref PKM pk)
        {
            if (pk.Species == 26)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 207;
            }
            else if (pk.Species == 53)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 169;
            }
            else if (pk.Species == 103)
            {
                pk.AbilityNumber = 2;
                pk.Ability = 119;
            }
            else if (pk.Species == 105)
            {
                pk.AbilityNumber = 1;
                pk.Ability = 130;
            }
            if(pk.Species==76)
            {
                pk.OT_Name = "wang";
            }
          
        }
    }
}
