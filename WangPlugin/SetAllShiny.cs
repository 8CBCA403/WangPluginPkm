using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;
namespace WangPlugin
{
    internal class SetAllShiny
    {
        public static void SetShiny(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetShiny);
            SaveFileEditor.ReloadSlots();
        }
        public static void SetShiny(PKM pkm)
        {
            pkm.SetShinySID();
        }
    }
}
