using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;
using PKHeX.Core.AutoMod;
namespace WangPlugin
{
    internal class SortPokemon
    {
        public static void Sort(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            List<PKM> PokeList = new();
            var PokeArray = new PKM[30];
            int i;
            for (i = 0; i < 30; i++)
            {
                PKM pk = sav.GetBoxSlotAtIndex(sav.CurrentBox, i);
                if (pk.Species == 0)
                    break;
                PokeList.Add(pk);
            }
            var count = PokeList.Count;
            List<PKM> sorted = PokeList.OrderBy(c => c.Species).ToList();
            for (i = 0; i < count; i++)
            {
                sav.SetBoxSlotAtIndex(sorted[i], sav.CurrentBox, i);
            }
            sav.LegalizeBox(sav.CurrentBox);
        }
    }
}
