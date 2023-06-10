using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core.AutoMod;

namespace WangPluginPkm.PluginUtil.LegalLogic
{
    public static class Legalize
    {
        public static int LegalizeAll(this SaveFile sav, IList<PKM> data)
        {
            int num = 0;
            for (int i = 0; i < data.Count; i++)
            {
                PKM pKM = data[i];
                if (pKM.Species > 0 && !new LegalityAnalysis(pKM).Valid)
                {
                    TrainerSettings.DefaultTID16 = pKM.TID16;
                    TrainerSettings.DefaultSID16 = pKM.SID16;
                    TrainerSettings.DefaultOT = pKM.OT_Name;
                    PKM pKM2 = sav.Legalize(pKM);
                    pKM2.Heal();
                    if (new LegalityAnalysis(pKM2).Valid)
                    {
                        data[i] = pKM2;
                        num++;
                    }
                }
            }

            return num;
        }
        public static int LegalizeBox(this SaveFile sav, int box)
        {
            if ((uint)box >= sav.BoxCount)
            {
                return -1;
            }

            PKM[] boxData = sav.GetBoxData(box);
            int num = sav.LegalizeAll(boxData);
            if (num > 0)
            {
                sav.SetBoxData(boxData, box);
            }

            return num;
        }

    }
}
