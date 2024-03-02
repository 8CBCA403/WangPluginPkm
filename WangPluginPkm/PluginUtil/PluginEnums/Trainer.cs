using System;
namespace WangPluginPkm
{
    internal class Trainer
    {
        public string OriginalTrainerName { get; set; }
        public uint TID16 { get; set; }
        public uint SID16 { get; set; }
        public int Gender { get; set; }
        public int Language { get; set; }

        public static Trainer ConvertToTrainer(string T)
        {
            string[] str = new string[5];
            str = T.Split(',');
            Trainer tr = new Trainer
            {
                OriginalTrainerName = str[0],
                TID16 = Convert.ToUInt32(str[1]),
                SID16 = Convert.ToUInt32(str[2]),
                Gender = Convert.ToInt32(str[3]),
                Language = Convert.ToInt32(str[4]),
            };
            return tr;
        }

    }
}
