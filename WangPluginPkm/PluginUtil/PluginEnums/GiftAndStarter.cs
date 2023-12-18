

namespace WangPluginPkm
{
    internal class GiftAndStarter
    {
        public static bool XDCGFFlag(int Species)
        {
            if (Species is 311 or 196 or 197)
                return true;
            else
                return false;
        }
    }
}
