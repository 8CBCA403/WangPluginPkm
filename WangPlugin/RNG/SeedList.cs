
using System.Collections.Generic;

namespace WangPlugin
{
    internal class SeedList
    {
       public static List<uint>  Roaming8_6V = new List<uint>()   
        {0x60d489e, 0xf962809, 0x1707a1bc, 0x256512ac,
        0x2b2e0bc5, 0x3e9e0489, 0x429f7bdd, 0x4fcd2b6c,
        0x5ce9aa13, 0x65aded09, 0x6707f338, 0x6b72fe4d,
        0x7171a30b, 0x733dd448, 0x7a928de5, 0x7ef34d82,
        0x874a8cd4, 0x90383581, 0x9bd65fdb, 0x9f2f499e,
        0xa01f78d8, 0xafecaffc, 0xb2b8db34, 0xc057809e,
        0xc21a8fb4, 0xcab3bc4d, 0xd970b3b2, 0xe6da6290,
        0xebf047c3, 0xf489a30c, 0xf6cf4c3b, 0xff2be493};
        public static List<uint> Roaming8_0a0s = new List<uint>()
        {0x21bbd6a, 0x630fbe9f, 0x6a84b6ed, 0x6c6d3a44,
        0x745e444f, 0xc9080389, 0xc937601d, 0xce11bee0};
        public static List<uint> Roaming8_0a = new List<uint>()
       {0xbd5a6b6, 0x1434d7a3, 0x14a4e19d, 0x16356604,
        0x258ffeb3, 0x2811e041, 0x2fbfee90, 0x4318207a,
        0x57003093, 0x6ea9022c, 0x7d5b6f50, 0x86e81468,
        0x8b2bc094, 0x91c150eb, 0x93c2fef8, 0x96e4f3e9,
        0xa3fde2ad, 0xdc52ec02, 0xdd32dc34, 0xfaea4706};
        public static List<uint> Roaming8_0s = new List<uint>()
       {0x6f865f2, 0x1eeb4ab9, 0x22c848cd, 0x2fbdd191,
        0x3d0b17be, 0x51097301, 0x558e91a4, 0x5f051ba8,
        0x61afeb5f, 0x6be08d41, 0x6e87f93c, 0x77252c8c,
        0x86138402, 0x9aeeee9b, 0xac21a413, 0xca9ded5d,
        0xd013ae00, 0xd6fc7ddd};
        public static List<uint> OverWorld8_0a = new List<uint>()
        {0x44E87F35,0x4DD86A64,0x54676DB9,0xE7CF1D3C,
         0xF7400FB0,0xFE701AE1};
        public static List<uint> OverWorld8_0s = new List<uint>()
        {
           0x857FA070
        };
        public static List<uint> OverWorld8_0a0s = new List<uint>()
        {
           0xDDF01AC6,0xD2B74A56,0xC44F1D1B,0x7ED778CF,0x200DA840
        };
        public static List<uint> OverWorld8_0spa = new List<uint>()
        {
           0x76352687,0x10379A04,0x1235A4FC,0x15960158,0x17943FA0,
           0x199114E6,0x1B932A1E,0x1C308FBA,0x1E32B142,0x21AC24AC,
           0x23AE1A54,0x240DBFF0,0x260F8108,0x280AAA4E,0x2A0894B6,
           0x2DAB3112,0x2FA90FEA,0x31B5AD93,0x33B7936B,0x341436CF,
           0x36160837,0x38132371,0x3A111D89,0x3DB2B82D,0x3FB086D5,
           0x400D3D8B,0x420F0373,0x45ACA6D7,0x47AE982F,0x49ABB369,
           0x4BA98D91,0x4C0A2835,0x4E0816CD,0x5014B4B4,0x52168A4C,
        };
        
        public static Queue<uint> EnqueueSeed(int SeedFlag)
        {
            Queue<uint> SeedQueue = new Queue<uint>();
            if (SeedFlag == 1)
            {
                for (int i = 0; i < 28; i++)
                {
                    SeedQueue.Enqueue(Roaming8_6V[i]);
                }
            }
            else if (SeedFlag == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    SeedQueue.Enqueue(Roaming8_0a0s[i]);
                }
            }
            else if (SeedFlag == 3)
            {
                for (int i = 0; i < 20; i++)
                {
                    SeedQueue.Enqueue(Roaming8_0a[i]);
                }
            }
            else if (SeedFlag == 4)
            {
                for (int i = 0; i < 18; i++)
                {
                    SeedQueue.Enqueue(Roaming8_0s[i]);
                }
            }
            else if(SeedFlag==5)
            {
                for(int i=0;i<6;i++)
                {
                    SeedQueue.Enqueue(OverWorld8_0a[i]);
                }
            }
            else if (SeedFlag == 6)
            {
                for (int i = 0; i < 1; i++)
                {
                    SeedQueue.Enqueue(OverWorld8_0s[i]);
                }
            }
            else if (SeedFlag == 7)
            {
                for (int i = 0; i < 5; i++)
                {
                    SeedQueue.Enqueue(OverWorld8_0a0s[i]);
                }
            }
            else if (SeedFlag == 8)
            {
                for (int i = 0; i < 35; i++)
                {
                    SeedQueue.Enqueue(OverWorld8_0spa[i]);
                }
            }
            return SeedQueue;
        }

    }
}
