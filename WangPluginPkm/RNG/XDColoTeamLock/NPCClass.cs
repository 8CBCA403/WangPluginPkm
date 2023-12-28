namespace WangPluginPkm
{
    public class NPCClass
    {
        public ushort Species { get; set; }

        public int Nature { get; set; }

        public int Gender { get; set; }

        public int Ratio { get; set; }

        public NPCClass(ushort species, int nature, int gender, int ratio)
        {
            Species = species;
            Nature = nature;
            Gender = gender;
            Ratio = ratio;
        }
    }
}
