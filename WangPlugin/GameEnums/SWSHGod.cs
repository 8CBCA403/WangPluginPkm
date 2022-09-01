
using System.Collections.Generic;


namespace WangPlugin
{
    internal class SWSHGod
    {
        public ushort Species { get; set; }
        public int[] IVs { get; set; }
        public int[] EVs{ get; set; }
        public int Nature { get; set; }
        public static List<int> a = new List<int>
               { 144 , 145 , 146 ,150 , 243  ,244 , 245 
                 ,249,  250  ,380,  381 , 382 , 383  ,384 ,
                 480  ,481,  482 , 483,  484 , 485 , 487 ,
                 488 , 641 , 642,  643 , 644 , 645 , 646 ,
                 716,  717,  718,  785 , 786,  787 , 788 ,
                 791  ,792 , 793,  794 , 795  ,796 , 797 ,
                 798 , 799 , 800 , 805 ,806 
                };
        public static List<SWSHGod> CreateList()
        {
            int[] Atkiv = { 31, 31, 31, 31, 31, 31 };
            int[] Atkev = { 6, 252, 0, 252, 0, 0 };
            int[] Spaiv = { 31, 0, 31, 31, 31, 31 };
            int[] Spaev = { 6, 0, 0, 252, 252, 0 };
            int[] Tankiv = { 31, 0, 31, 31, 31, 31 };
            int[] Tankev = { 252, 0, 252, 0, 0, 6};
            List<SWSHGod> a = new();
            SWSHGod Articuno = new SWSHGod
            {
                Species = 144,
                IVs = Spaiv,
                EVs= Spaev,
                Nature=10,
            };
            SWSHGod Zapdos = new SWSHGod
            {
                Species = 145,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Moltres = new SWSHGod
            {
                Species = 146,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Mewtwo = new SWSHGod
            {
                Species = 150,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Raikou = new SWSHGod
            {
                Species = 243,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Entei = new SWSHGod
            {
                Species = 244,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Suicune = new SWSHGod
            {
                Species = 245,
                IVs = Tankiv,
                EVs = Tankev,
                Nature = 5,
            };
            SWSHGod Lugia = new SWSHGod
            {
                Species = 249,
                IVs = Tankiv,
                EVs = Tankev,
                Nature = 5,
            };
            SWSHGod HoOh = new SWSHGod
            {
                Species = 250,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Latias = new SWSHGod
            {
                Species = 380,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Latios = new SWSHGod
            {
                Species = 381,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Kyogre = new SWSHGod
            {
                Species = 382,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Groudon = new SWSHGod
            {
                Species = 383,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Rayquaza = new SWSHGod
            {
                Species = 384,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Uxie = new SWSHGod
            {
                Species = 480,
                IVs = Tankiv,
                EVs = Tankev,
                Nature = 5,
            };
            SWSHGod Mesprit = new SWSHGod
            {
                Species = 481,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Azelf = new SWSHGod
            {
                Species = 482,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Dialga = new SWSHGod
            {
                Species = 483,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Palkia = new SWSHGod
            {
                Species = 484,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Heatran = new SWSHGod
            {
                Species = 485,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Giratina = new SWSHGod
            {
                Species = 487,
                IVs = Tankiv,
                EVs = Tankev,
                Nature = 5,
            };
            SWSHGod Cresselia = new SWSHGod
            {
                Species = 488,
                IVs = Tankiv,
                EVs = Tankev,
                Nature = 5,
            };
            SWSHGod Tornadus = new SWSHGod
            {
                Species = 641,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Thundurus = new SWSHGod
            {
                Species = 642,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Reshiram = new SWSHGod
            {
                Species = 643,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Zekrom = new SWSHGod
            {
                Species = 644,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Landorus = new SWSHGod
            {
                Species = 645,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Kyurem = new SWSHGod
            {
                Species = 646,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Xerneas = new SWSHGod
            {
                Species = 716,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Yveltal = new SWSHGod
            {
                Species = 717,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Zygarde = new SWSHGod
            {
                Species = 718,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Tapu_Koko = new SWSHGod
            {
                Species = 785,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Tapu_Lele = new SWSHGod
            {
                Species = 786,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Tapu_Bulu = new SWSHGod
            {
                Species = 787,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Tapu_Fini = new SWSHGod
            {
                Species = 788,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Solgaleo = new SWSHGod
            {
                Species = 791,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Lunala = new SWSHGod
            {
                Species = 792,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Nihilego = new SWSHGod
            {
                Species = 793,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Buzzwole = new SWSHGod
            {
                Species = 794,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Pheromosa = new SWSHGod
            {
                Species = 795,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Xurkitree = new SWSHGod
            {
                Species = 796,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Celesteela = new SWSHGod
            {
                Species = 797,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Kartana = new SWSHGod
            {
                Species = 798,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Guzzlord = new SWSHGod
            {
                Species = 799,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Necrozma = new SWSHGod
            {
                Species = 800,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            SWSHGod Stakataka = new SWSHGod
            {
                Species = 805,
                IVs = Atkiv,
                EVs = Atkev,
                Nature = 13,
            };
            SWSHGod Blacephalon = new SWSHGod
            {
                Species = 806,
                IVs = Spaiv,
                EVs = Spaev,
                Nature = 10,
            };
            a.Add(Articuno);
            a.Add(Zapdos);
            a.Add(Moltres);
            a.Add(Mewtwo);
            a.Add(Raikou);
            a.Add(Entei);
            a.Add(Suicune);
            a.Add(Lugia);
            a.Add(HoOh);
            a.Add(Latias);
            a.Add(Latios);
            a.Add(Kyogre);
            a.Add(Groudon);
            a.Add(Rayquaza);
            a.Add(Uxie);
            a.Add(Mesprit);
            a.Add(Azelf);
            a.Add(Dialga);
            a.Add(Palkia);
            a.Add(Heatran);
            a.Add(Giratina);
            a.Add(Cresselia);
            a.Add(Tornadus);
            a.Add(Thundurus);
            a.Add(Reshiram);
            a.Add(Zekrom);
            a.Add(Landorus);
            a.Add(Kyurem);
            a.Add(Xerneas);
            a.Add(Yveltal);
            a.Add(Zygarde);
            a.Add(Tapu_Koko);
            a.Add(Tapu_Lele);
            a.Add(Tapu_Bulu);
            a.Add(Tapu_Fini);
            a.Add(Solgaleo);
            a.Add(Lunala);
            a.Add(Nihilego);
            a.Add(Buzzwole);
            a.Add(Pheromosa);
            a.Add(Xurkitree);
            a.Add(Celesteela);
            a.Add(Kartana);
            a.Add(Guzzlord);
            a.Add(Necrozma);
            a.Add(Stakataka);
            a.Add(Blacephalon);

            return a;
        }
    }
}
