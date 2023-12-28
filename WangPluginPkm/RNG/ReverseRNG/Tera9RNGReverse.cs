namespace WangPluginPkm.RNG.ReverseRNG
{
    internal class Tera9RNGReverse
    {
        public static uint GetOriginalSeed(uint EC, uint pid)
        {
            uint encryptionConstant = EC;
            if (encryptionConstant != 4166463166u)
            {
                return encryptionConstant - 580741723;
            }

            if (pid != 3387331366u)
            {
                return 3714225572u;
            }

            return 3585721443u;
        }
    }
}
