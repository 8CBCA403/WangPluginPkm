using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Pika
    {
        public static List<PKM> PikaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                       var pl= SearchDatabase.SearchPKMList(SAV, Editor, 25, 32);
                        for(int i=0;i<30;i++)
                        {
                            Random rnd = new Random();
                            var j=rnd.Next(0, pl.Count);
                            pk = pl[j];
                            pl.Remove(pk);
                            if (pk.Species==172)
                            {
                                pk.CurrentLevel = 50;
                                pk.Species = 25;
                                pk.ClearNickname();
                            }
                           
                            PKL.Add(pk);
                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
