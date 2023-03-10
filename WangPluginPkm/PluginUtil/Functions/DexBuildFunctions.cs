using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using PKHeX.Core.AutoMod;

namespace WangPluginPkm.PluginUtil.Functions
{
    public static class DexBuildFunctions
    {
        public static void UnionPKM(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var a = sav.GetAllPKM();
            var pkms = sav.GenerateLivingDex().ToList();
            foreach (var item in a)
            {
                var pk = pkms.Find(x => x.Species == item.Species);
                pkms.Remove(pk);
            }
            var o = a.Union(pkms);
            o = o.OrderBySpecies();
            var bd = sav.BoxData;
            o.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public static void LivingDex(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            var pkms = sav.GenerateLivingDex();
            var bd = sav.BoxData;
            pkms.CopyTo(bd);
            sav.BoxData = bd;
            SaveFileEditor.ReloadSlots();
        }
        public static void LegalBox(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBox(sav.CurrentBox);
        }
        public static void LegalAll(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.LegalizeBoxes();
        }
        public static void ClearPKM(PKM pkm)
        {
            pkm.Species = 0;
        }
        public static void RandomPKMPID(PKM pkm)
        {
            pkm.PID = Util.Rand32();

        }
        public static void RandomPKMEC(PKM pkm)
        {
            pkm.SetRandomEC();
        }

    }
}
