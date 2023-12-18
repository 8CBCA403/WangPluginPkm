namespace WangPluginPkm
{
    internal class MythicalFlag
    {
        public static bool MFlag(int Species)
        {
            if (Species is 151 or 251 or 385 or 489 or 490 or 492 or 493 or
                 494 or 648 or 649 or 719 or 720 or 721 or 801 or
                 802 or 808 or 386 or 491 or 647 or 807 or 809 or 892 or
                 893 or 888 or 889 or 890 or 896 or 897 or 898)
                return true;
            else
                return false;
        }
    }
}
