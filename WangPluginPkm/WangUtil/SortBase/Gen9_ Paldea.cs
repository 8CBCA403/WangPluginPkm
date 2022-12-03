﻿using PKHeX.Core;
using System;
using System.Collections.Generic;


namespace WangPluginPkm.SortBase
{
    internal class Gen9__Paldea : SortingBase
    {
        private static readonly Dictionary<Species, int> dex = new Dictionary<Species, int>()
        {
            {Species.Sprigatito, 1},
            {Species.Floragato, 2},
            {Species.Meowscarada, 3},
            {Species.Fuecoco, 4},
            {Species.Crocalor, 5},
            {Species.Skeledirge, 6},
            {Species.Quaxly, 7},
            {Species.Quaxwell, 8},
            {Species.Quaquaval, 9},
            {Species.Lechonk, 10},
            {Species.Oinkologne, 11},
            {Species.Tarountula, 12},
            {Species.Spidops, 13},
            {Species.Nymble, 14},
            {Species.Lokix, 15},
            {Species.Hoppip, 16},
            {Species.Skiploom, 17},
            {Species.Jumpluff, 18},
            {Species.Fletchling, 19},
            {Species.Fletchinder, 20},
            {Species.Talonflame, 21},
            {Species.Pawmi, 22},
            {Species.Pawmo, 23},
            {Species.Pawmot, 24},
            {Species.Houndour, 25},
            {Species.Houndoom, 26},
            {Species.Yungoos, 27},
            {Species.Gumshoos, 28},
            {Species.Skwovet, 29},
            {Species.Greedent, 30},
          {Species.Sunkern, 31},
          {Species.Sunflora, 32},
          {Species.Kricketot, 33},
          {Species.Kricketune, 34},
          {Species.Scatterbug, 35},
          {Species.Spewpa, 36},
          {Species.Vivillon, 37},
          {Species.Combee, 38},
          {Species.Vespiquen, 39},
          {Species.Rookidee, 40},
          {Species.Corvisquire, 41},
          {Species.Corviknight, 42},
          {Species.Happiny, 43},
          {Species.Chansey, 44},
          {Species.Blissey, 45},
          {Species.Azurill, 46},
          {Species.Marill, 47},
          {Species.Azumarill, 48},
          {Species.Surskit, 49},
          {Species.Masquerain, 50},
          {Species.Buizel, 51},
          {Species.Floatzel, 52},
          {Species.Wooper, 53},
          {Species.Clodsire, 54},
          {Species.Psyduck, 55},
          {Species.Golduck, 56},
          {Species.Chewtle, 57},
          {Species.Drednaw, 58},
          {Species.Igglybuff, 59},
          {Species.Jigglypuff, 60},
          {Species.Wigglytuff, 61},
          {Species.Ralts, 62},
          {Species.Kirlia, 63},
          {Species.Gardevoir, 64},
          {Species.Gallade, 65},
          {Species.Drowzee, 66},
          {Species.Hypno, 67},
          {Species.Gastly, 68},
          {Species.Haunter, 69},
          {Species.Gengar, 70},
          {Species.Tandemaus, 71},
          {Species.Maushold, 72},
          {Species.Pichu, 73},
          {Species.Pikachu, 74},
          {Species.Raichu, 75},
          {Species.Fidough, 76},
          {Species.Dachsbun, 77},
          {Species.Slakoth, 78},
          {Species.Vigoroth, 79},
          {Species.Slaking, 80},
          {Species.Bounsweet, 81},
          {Species.Steenee, 82},
          {Species.Tsareena, 83},
          {Species.Smoliv, 84},
          {Species.Dolliv, 85},
          {Species.Arboliva, 86},
          {Species.Bonsly, 87},
          {Species.Sudowoodo, 88},
          {Species.Rockruff, 89},
          {Species.Lycanroc, 90},
          {Species.Rolycoly, 91},
          {Species.Carkol, 92},
          {Species.Coalossal, 93},
          {Species.Shinx, 94},
          {Species.Luxio, 95},
          {Species.Luxray, 96},
          {Species.Starly, 97},
          {Species.Staravia, 98},
          {Species.Staraptor, 99},
          {Species.Oricorio, 100},
          {Species.Mareep, 101},
          {Species.Flaaffy, 102},
          {Species.Ampharos, 103},
          {Species.Petilil, 104},
          {Species.Lilligant, 105},
          {Species.Shroomish, 106},
          {Species.Breloom, 107},
          {Species.Applin, 108},
          {Species.Flapple, 109},
          {Species.Appletun, 110},
          {Species.Spoink, 111},
          {Species.Grumpig, 112},
          {Species.Squawkabilly, 113},
          {Species.Misdreavus, 114},
          {Species.Mismagius, 115},
          {Species.Makuhita, 116},
          {Species.Hariyama, 117},
          {Species.Crabrawler, 118},
          {Species.Crabominable, 119},
          {Species.Salandit, 120},
          {Species.Salazzle, 121},
          {Species.Phanpy, 122},
          {Species.Donphan, 123},
          {Species.Cufant, 124},
          {Species.Copperajah, 125},
          {Species.Gible, 126},
          {Species.Gabite, 127},
          {Species.Garchomp, 128},
          {Species.Nacli, 129},
          {Species.Naclstack, 130},
          {Species.Garganacl, 131},
          {Species.Wingull, 132},
          {Species.Pelipper, 133},
          {Species.Magikarp, 134},
          {Species.Gyarados, 135},
          {Species.Arrokuda, 136},
          {Species.Barraskewda, 137},
          {Species.Basculin, 138},
          {Species.Gulpin, 139},
          {Species.Swalot, 140},
          {Species.Meowth, 141},
          {Species.Persian, 142},
          {Species.Drifloon, 143},
          {Species.Drifblim, 144},
          {Species.Flabébé, 145},
          {Species.Floette, 146},
          {Species.Florges, 147},
          {Species.Diglett, 148},
          {Species.Dugtrio, 149},
          {Species.Torkoal, 150},
          {Species.Numel, 151},
          {Species.Camerupt, 152},
          {Species.Bronzor, 153},
          {Species.Bronzong, 154},
          {Species.Axew, 155},
          {Species.Fraxure, 156},
          {Species.Haxorus, 157},
          {Species.Mankey, 158},
          {Species.Primeape, 159},
          {Species.Annihilape, 160},
          {Species.Meditite, 161},
          {Species.Medicham, 162},
          {Species.Riolu, 163},
          {Species.Lucario, 164},
          {Species.Charcadet, 165},
          {Species.Armarouge, 166},
          {Species.Ceruledge, 167},
          {Species.Barboach, 168},
          {Species.Whiscash, 169},
          {Species.Tadbulb, 170},
          {Species.Bellibolt, 171},
          {Species.Goomy, 172},
          {Species.Sliggoo, 173},
          {Species.Goodra, 174},
          {Species.Croagunk, 175},
          {Species.Toxicroak, 176},
          {Species.Wattrel, 177},
          {Species.Kilowattrel, 178},
          {Species.Eevee, 179},
          {Species.Vaporeon, 180},
          {Species.Jolteon, 181},
          {Species.Flareon, 182},
          {Species.Espeon, 183},
          {Species.Umbreon, 184},
          {Species.Leafeon, 185},
          {Species.Glaceon, 186},
          {Species.Sylveon, 187},
          {Species.Dunsparce, 188},
          {Species.Dudunsparce, 189},
          {Species.Deerling, 190},
          {Species.Sawsbuck, 191},
          {Species.Girafarig, 192},
          {Species.Farigiraf, 193},
          {Species.Grimer, 194},
          {Species.Muk, 195},
          {Species.Maschiff, 196},
          {Species.Mabosstiff, 197},
          {Species.Toxel, 198},
          {Species.Toxtricity, 199},
          {Species.Dedenne, 200},
          {Species.Pachirisu, 201},
          {Species.Shroodle, 202},
          {Species.Grafaiai, 203},
          {Species.Stantler, 204},
          {Species.Foongus, 205},
          {Species.Amoonguss, 206},
          {Species.Voltorb, 207},
          {Species.Electrode, 208},
          {Species.Magnemite, 209},
          {Species.Magneton, 210},
          {Species.Magnezone, 211},
          {Species.Ditto, 212},
          {Species.Growlithe, 213},
          {Species.Arcanine, 214},
          {Species.Teddiursa, 215},
          {Species.Ursaring, 216},
          {Species.Zangoose, 217},
          {Species.Seviper, 218},
          {Species.Swablu, 219},
          {Species.Altaria, 220},
          {Species.Skiddo, 221},
          {Species.Gogoat, 222},
          {Species.Tauros, 223},
          {Species.Litleo, 224},
          {Species.Pyroar, 225},
          {Species.Stunky, 226},
          {Species.Skuntank, 227},
          {Species.Zorua, 228},
          {Species.Zoroark, 229},
          {Species.Sneasel, 230},
          {Species.Weavile, 231},
          {Species.Murkrow, 232},
          {Species.Honchkrow, 233},
          {Species.Gothita, 234},
          {Species.Gothorita, 235},
          {Species.Gothitelle, 236},
          {Species.Sinistea, 237},
          {Species.Polteageist, 238},
          {Species.Mimikyu, 239},
          {Species.Klefki, 240},
          {Species.Indeedee, 241},
          {Species.Bramblin, 242},
          {Species.Brambleghast, 243},
          {Species.Toedscool, 244},
          {Species.Toedscruel, 245},
          {Species.Tropius, 246},
          {Species.Fomantis, 247},
          {Species.Lurantis, 248},
          {Species.Klawf, 249},
          {Species.Capsakid, 250},
          {Species.Scovillain, 251},
          {Species.Cacnea, 252},
          {Species.Cacturne, 253},
          {Species.Rellor, 254},
          {Species.Rabsca, 255},
          {Species.Venonat, 256},
          {Species.Venomoth, 257},
          {Species.Pineco, 258},
          {Species.Forretress, 259},
          {Species.Scyther, 260},
          {Species.Scizor, 261},
          {Species.Heracross, 262},
          {Species.Flittle, 263},
          {Species.Espathra, 264},
          {Species.Hippopotas, 265},
          {Species.Hippowdon, 266},
          {Species.Sandile, 267},
          {Species.Krokorok, 268},
          {Species.Krookodile, 269},
          {Species.Silicobra, 270},
          {Species.Sandaconda, 271},
          {Species.Mudbray, 272},
          {Species.Mudsdale, 273},
          {Species.Larvesta, 274},
          {Species.Volcarona, 275},
          {Species.Bagon, 276},
          {Species.Shelgon, 277},
          {Species.Salamence, 278},
          {Species.Tinkatink, 279},
          {Species.Tinkatuff, 280},
          {Species.Tinkaton, 281},
          {Species.Hatenna, 282},
          {Species.Hattrem, 283},
          {Species.Hatterene, 284},
          {Species.Impidimp, 285},
          {Species.Morgrem, 286},
          {Species.Grimmsnarl, 287},
          {Species.Wiglett, 288},
          {Species.Wugtrio, 289},
          {Species.Bombirdier, 290},
          {Species.Finizen, 291},
          {Species.Palafin, 292},
          {Species.Varoom, 293},
          {Species.Revavroom, 294},
          {Species.Cyclizar, 295},
          {Species.Orthworm, 296},
          {Species.Sableye, 297},
          {Species.Shuppet, 298},
          {Species.Banette, 299},
          {Species.Falinks, 300},
          {Species.Hawlucha, 301},
          {Species.Spiritomb, 302},
          {Species.Noibat, 303},
          {Species.Noivern, 304},
          {Species.Dreepy, 305},
          {Species.Drakloak, 306},
          {Species.Dragapult, 307},
          {Species.Glimmet, 308},
          {Species.Glimmora, 309},
          {Species.Rotom, 310},
          {Species.Greavard, 311},
          {Species.Houndstone, 312},
          {Species.Oranguru, 313},
          {Species.Passimian, 314},
          {Species.Komala, 315},
          {Species.Larvitar, 316},
          {Species.Pupitar, 317},
          {Species.Tyranitar, 318},
          {Species.Stonjourner, 319},
          {Species.Eiscue, 320},
          {Species.Pincurchin, 321},
          {Species.Sandygast, 322},
          {Species.Palossand, 323},
          {Species.Slowpoke, 324},
          {Species.Slowbro, 325},
          {Species.Slowking, 326},
          {Species.Shellos, 327},
          {Species.Gastrodon, 328},
          {Species.Shellder, 329},
          {Species.Cloyster, 330},
          {Species.Qwilfish, 331},
          {Species.Luvdisc, 332},
          {Species.Finneon, 333},
          {Species.Lumineon, 334},
          {Species.Bruxish, 335},
          {Species.Alomomola, 336},
          {Species.Skrelp, 337},
          {Species.Dragalge, 338},
          {Species.Clauncher, 339},
          {Species.Clawitzer, 340},
          {Species.Tynamo, 341},
          {Species.Eelektrik, 342},
          {Species.Eelektross, 343},
          {Species.Mareanie, 344},
          {Species.Toxapex, 345},
          {Species.Flamigo, 346},
          {Species.Dratini, 347},
          {Species.Dragonair, 348},
          {Species.Dragonite, 349},
          {Species.Snom, 350},
          {Species.Frosmoth, 351},
          {Species.Snover, 352},
          {Species.Abomasnow, 353},
          {Species.Delibird, 354},
          {Species.Cubchoo, 355},
          {Species.Beartic, 356},
          {Species.Snorunt, 357},
          {Species.Glalie, 358},
          {Species.Froslass, 359},
          {Species.Cryogonal, 360},
          {Species.Cetoddle, 361},
          {Species.Cetitan, 362},
          {Species.Bergmite, 363},
          {Species.Avalugg, 364},
          {Species.Rufflet, 365},
          {Species.Braviary, 366},
          {Species.Pawniard, 367},
          {Species.Bisharp, 368},
          {Species.Kingambit, 369},
          {Species.Deino, 370},
          {Species.Zweilous, 371},
          {Species.Hydreigon, 372},
          {Species.Veluza, 373},
          {Species.Dondozo, 374},
          {Species.Tatsugiri, 375},
          {Species.GreatTusk, 376},
          {Species.ScreamTail, 377},
          {Species.BruteBonnet, 378},
          {Species.FlutterMane, 379},
          {Species.SlitherWing, 380},
          {Species.SandyShocks, 381},
          {Species.IronTreads, 382},
          {Species.IronBundle, 383},
          {Species.IronHands, 384},
          {Species.IronJugulis, 385},
          {Species.IronMoth, 386},
          {Species.IronThorns, 387},
          {Species.Frigibax, 388},
          {Species.Arctibax, 389},
          {Species.Baxcalibur, 390},
          {Species.Gimmighoul, 391},
          {Species.Gholdengo, 392},
          {Species.WoChien, 393},
          {Species.ChienPao, 394},
          {Species.TingLu, 395},
          {Species.ChiYu, 396},
          {Species.RoaringMoon, 397},
          {Species.IronValiant, 398},
          {Species.Koraidon, 399},
          {Species.Miraidon, 400}
        };
        public static Func<PKM, IComparable>[] GetSortFunctions()
        {
            return GenerateSortingFunctions(dex);
        }
    }
}
