using PKHeX.Core;
using System;
namespace WangPluginPkm
{
    internal class VersionFlag
    {
        
        public static bool Gen3Flag(int Version)
        {
            if (Version is 1 or 2 or 3 or 4 or 5)
                return true;
            else
                return false;
        }
        public static bool Gen4Flag(int Version)
        {
            if (Version is 10 or 11 or 12 or 7 or 8)
                return true;
            else
                return false;
        }
        public static bool Gen5Flag(int Version)
        {
            if (Version is 20 or 21 or 22 or 23)
                return true;
            else
                return false;
        }
        public static bool Gen6Flag(int Version)
        {
            if (Version is 24 or 25 or 26 or 27)
                return true;
            else
                return false;
        }
        public static bool Gen7Flag(int Version)
        {
            if (Version is 30 or 31 or 32 or 33 or 42 or 43)
                return true;
            else
                return false;
        }
        public static bool Gen8SWSHFlag(int Version)
        {
            if (Version is 44 or 45)
                return true;
            else
                return false;
        }
        public static bool Gen8BDSPFlag(int Version)
        {
            if (Version is 48 or 49)
                return true;
            else
                return false;
        }
        public static bool Gen8PLAFlag(int Version)
        {
            if (Version is 47)
                return true;
            else
                return false;
        }
        public static bool Gen1VCFlag(GameVersion version)
        {
            if (version is GameVersion.RBY or GameVersion.RB or GameVersion.YW or GameVersion.RD)
                return true;
            else
                return false;
        }
        public static bool Gen2VCFlag(GameVersion version)
        {
            if (version is GameVersion.GSC or GameVersion.GS or GameVersion.C)
                return true;
            else
                return false;
        }
        public static bool CXDFlag(int Version)
        {
            if (Version is 15)
                return true;
            else
                return false;
        }
        public static bool Gen9Flag(int Version)
        {
            if (Version is 50 or 51)
                return true;
            else
                return false;
        }
        public static bool ID7Flag(GameVersion version)
        {
            if (version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                 GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or
                 GameVersion.BD or GameVersion.SP or GameVersion.VL or GameVersion.SL or GameVersion.SV)
                return true;
            else
                return false;
        }

        internal static bool Gen2VCFlag(int version)
        {
            throw new NotImplementedException();
        }
    }
}
