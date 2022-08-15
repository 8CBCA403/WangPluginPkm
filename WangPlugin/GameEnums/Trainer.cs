using System;
using System.Collections.Generic;
namespace WangPlugin
{
    internal class Trainer
    {
        public string OT_Name { get; set; }
        public int Tid { get; set; }
        public int Sid { get; set; }
        public int Gender { get; set; }   
        public int Language { get; set; }

        public static Trainer ConvertToTrainer(string T)
        {
            string[] str = new string[5];
            str=T.Split(',');
            Trainer tr = new Trainer
            {
                OT_Name = str[0],
                Tid = Convert.ToInt32( str[1]),
                Sid = Convert.ToInt32(str[2]),
                Gender = Convert.ToInt32(str[3]),
                Language = Convert.ToInt32(str[4]),
            };
            return tr;
        }
        
    }
}
