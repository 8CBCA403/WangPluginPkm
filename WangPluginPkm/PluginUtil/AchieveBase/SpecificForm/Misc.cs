﻿using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.AchieveBase.SpecificForm
{
    internal class Misc
    {
       
        public static List<PKM> SnorlaxSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 143, 32);
                        pk.Species = 143;
                        pk.CurrentLevel = 50;
                        pk.Nature = 12;
                        pk.AbilityNumber = 1;
                        pk.Ability = 17;
                        pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> MetagrossSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 376, 32);
                        pk.CurrentLevel = 60;
                        pk.Species = 376;
                        pk = AchieveFunc.fun(pk);
                        pk.SetShiny();
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> ShayminSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                       
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 492, 32);

                        //   pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                       
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> MeloettaSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                      
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 648, 32);

                        // pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                       
                    }
                    break;
            }
            return PKL;
        }
        public static List<PKM> GenesectSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            switch (SAV.SAV.Version)
            {
                case GameVersion.US or GameVersion.UM or GameVersion.USUM:
                    {
                       
                        pk = SearchDatabase.SearchPKM(SAV, Editor, 649, 23,0,false,40007);

                        // pk = AchieveFunc.fun(pk);
                        PKL.Add(pk);
                    }
                    break;
            }
            return PKL;
        }

    }
}
