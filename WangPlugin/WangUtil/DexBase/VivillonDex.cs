using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPlugin.WangUtil.DexBase
{
    internal class VivillonDex
    {
        public static byte CountryToRegionCountry(byte country) 
        {
            if (country is 1)
                return 0;
            else if (country is (>= 8 and <= 52) or 153 or 156 or 168 or 174 or 186)
                return 1;
            else if (country is (>= 64 and <= 127) or 169 or 184 or 185)
                return 2;
            else if (country is 144 or 160)
                return 4;
            else if (country is 136)
                return 5;
            else if (country is 144 or 128)
                return 6;
            return 0;
        }
        /// <summary>
        /// List of valid countries for each Vivillon form.
        /// </summary>
        private static readonly byte[][] VivillonCountryTable =
        {
        /* 0 Icy Snow    */ new byte[] {018,076,096,100,107},
        /* 1 Polar       */ new byte[] {010,018,020,049,076,096,100,107,160},
        /* 2 Tundra      */ new byte[] {001,074,081,096},
        /* 3 Continental */ new byte[] {001,010,067,073,074,075,077,078,084,087,094,096,097,100,107,128,136,144,160,169},
        /* 4 Garden      */ new byte[] {065,082,095,110,125},
        /* 5 Elegant     */ new byte[] {001},
        /* 6 Meadow      */ new byte[] {066,077,078,083,086,088,105,108,122,127},
        /* 7 Modern      */ new byte[] {018,049,186},
        /* 8 Marine      */ new byte[] {020,064,066,068,070,071,073,077,078,079,080,083,089,090,091,098,099,100,101,102,103,105,109,123,124,126,184,185},
        /* 9 Archipelago */ new byte[] {008,009,011,012,013,017,021,023,024,028,029,032,034,035,036,037,038,043,044,045,047,048,049,051,052,077,085,104},
        /*10 High Plains */ new byte[] {018,036,049,100,109,113,160},
        /*11 Sandstorm   */ new byte[] {072,109,118,119,120,121,168,174},
        /*12 River       */ new byte[] {065,069,085,093,104,105,114,115,116,117},
        /*13 Monsoon     */ new byte[] {001,128,160,169},
        /*14 Savanna     */ new byte[] {010,015,016,041,042,050},
        /*15 Sun         */ new byte[] {014,019,026,030,033,036,039,065,085,092,104,106,111,112},
        /*16 Ocean       */ new byte[] {049,077},
        /*17 Jungle      */ new byte[] {016,021,022,025,027,031,040,042,046,052,077,153,156,169},
    };
       
        public static List<PKM> VivillonSets(ISaveFileProvider SAV, IPKMView Editor)
        {
            List<PKM> PKL = new();
            PKM pk;
            Random r = new();
            switch (SAV.SAV.Version)
            {
                case GameVersion.X or GameVersion.Y or GameVersion.OR or
               GameVersion.AS or GameVersion.XY or GameVersion.ORAS:
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 666, 26,0,true);
                            pk.CurrentLevel = 50;
                            pk.Species = 666;
                            pk.ClearNickname();
                            pk.Form = (byte)i;
                            PK6 pk6 = (PK6)pk;
                            switch (i)
                            {
                                case 0:
                                    var a = r.Next(0, VivillonCountryTable[0].Length);
                                    var c = VivillonCountryTable[0][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 1:
                                     a = r.Next(0, VivillonCountryTable[1].Length);
                                    c = VivillonCountryTable[1][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 2:
                                    a = r.Next(0, VivillonCountryTable[2].Length);
                                    c = VivillonCountryTable[2][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 3:
                                    a = r.Next(0, VivillonCountryTable[3].Length);
                                    c = VivillonCountryTable[3][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 4:
                                    a = r.Next(0, VivillonCountryTable[4].Length);
                                    c = VivillonCountryTable[4][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 5:
                                    a = r.Next(0, VivillonCountryTable[5].Length);
                                    c = VivillonCountryTable[5][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 6:
                                    a = r.Next(0, VivillonCountryTable[6].Length);
                                    c = VivillonCountryTable[6][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 7:
                                    a = r.Next(0, VivillonCountryTable[7].Length);
                                    c = VivillonCountryTable[7][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 8:
                                    a = r.Next(0, VivillonCountryTable[8].Length);
                                    c = VivillonCountryTable[8][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 9:
                                    a = r.Next(0, VivillonCountryTable[9].Length);
                                    c = VivillonCountryTable[9][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 10:
                                    a = r.Next(0, VivillonCountryTable[10].Length);
                                    c = VivillonCountryTable[10][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 11:
                                    a = r.Next(0, VivillonCountryTable[11].Length);
                                    c = VivillonCountryTable[11][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 12:
                                    a = r.Next(0, VivillonCountryTable[12].Length);
                                    c = VivillonCountryTable[12][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 13:
                                    a = r.Next(0, VivillonCountryTable[13].Length);
                                    c = VivillonCountryTable[13][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 14:
                                    a = r.Next(0, VivillonCountryTable[14].Length);
                                    c = VivillonCountryTable[14][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 15:
                                    a = r.Next(0, VivillonCountryTable[15].Length);
                                    c = VivillonCountryTable[15][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 16:
                                    a = r.Next(0, VivillonCountryTable[16].Length);
                                    c = VivillonCountryTable[16][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 17:
                                    a = r.Next(0, VivillonCountryTable[17].Length);
                                    c = VivillonCountryTable[17][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 18:
                                    var p = SearchDatabase.MytheryPK(SAV,Editor,666,6,18);
                                    
                                    PKL.Add(p);
                                    break;
                                case 19:
                                    p = SearchDatabase.MytheryPK(SAV, Editor, 666, 6, 19);
                              
                                    PKL.Add(p);
                                    break;
                            }
                           
                        }
                    }
                    break;
                case GameVersion.SN or GameVersion.MN or GameVersion.US
                or GameVersion.UM or GameVersion.SM or GameVersion.USUM:
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            pk = SearchDatabase.SearchPKM(SAV, Editor, 666, 30, 0, true);
                            pk.CurrentLevel = 50;
                            pk.Species = 666;
                            pk.ClearNickname();
                            pk.Form = (byte)i;
                            PK7 pk6 = (PK7)pk;
                            switch (i)
                            {
                                case 0:
                                    var a = r.Next(0, VivillonCountryTable[0].Length);
                                    var c = VivillonCountryTable[0][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 1:
                                    a = r.Next(0, VivillonCountryTable[1].Length);
                                    c = VivillonCountryTable[1][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 2:
                                    a = r.Next(0, VivillonCountryTable[2].Length);
                                    c = VivillonCountryTable[2][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 3:
                                    a = r.Next(0, VivillonCountryTable[3].Length);
                                    c = VivillonCountryTable[3][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 4:
                                    a = r.Next(0, VivillonCountryTable[4].Length);
                                    c = VivillonCountryTable[4][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 5:
                                    a = r.Next(0, VivillonCountryTable[5].Length);
                                    c = VivillonCountryTable[5][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 6:
                                    a = r.Next(0, VivillonCountryTable[6].Length);
                                    c = VivillonCountryTable[6][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 7:
                                    a = r.Next(0, VivillonCountryTable[7].Length);
                                    c = VivillonCountryTable[7][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 8:
                                    a = r.Next(0, VivillonCountryTable[8].Length);
                                    c = VivillonCountryTable[8][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 9:
                                    a = r.Next(0, VivillonCountryTable[9].Length);
                                    c = VivillonCountryTable[9][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 10:
                                    a = r.Next(0, VivillonCountryTable[10].Length);
                                    c = VivillonCountryTable[10][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 11:
                                    a = r.Next(0, VivillonCountryTable[11].Length);
                                    c = VivillonCountryTable[11][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 12:
                                    a = r.Next(0, VivillonCountryTable[12].Length);
                                    c = VivillonCountryTable[12][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 13:
                                    a = r.Next(0, VivillonCountryTable[13].Length);
                                    c = VivillonCountryTable[13][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 14:
                                    a = r.Next(0, VivillonCountryTable[14].Length);
                                    c = VivillonCountryTable[14][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 15:
                                    a = r.Next(0, VivillonCountryTable[15].Length);
                                    c = VivillonCountryTable[15][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 16:
                                    a = r.Next(0, VivillonCountryTable[16].Length);
                                    c = VivillonCountryTable[16][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 17:
                                    a = r.Next(0, VivillonCountryTable[17].Length);
                                    c = VivillonCountryTable[17][a];
                                    pk6.Country = c;
                                    pk6.ConsoleRegion = CountryToRegionCountry(c);
                                    pk = pk6;
                                    PKL.Add(pk);
                                    break;
                                case 18:
                                    var p =(PK6)SearchDatabase.MytheryPK(SAV, Editor, 666, 6, 18);
                                    p.Language = 2;
                                    p.ClearNickname();
                                    PKL.Add(p.ConvertToPK7());
                                    break;
                                case 19:
                                    p = (PK6)SearchDatabase.MytheryPK(SAV, Editor, 666, 6, 19);
                                    p.Language = 1;
                                    p.ClearNickname();
                                    PKL.Add(p.ConvertToPK7());
                                    break;
                            }

                        }
                    }
                    break;
            }
            return PKL;
        }
    }
}
