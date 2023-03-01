using System;
using System.Collections.Generic;
using System.Globalization;
using WangPluginPkm.GUI;
using PKHeX.Core;
using WangPluginPkm.WangUtil.PluginEnums;
namespace WangPluginPkm
{
    internal class Gen8DenMax
    {
        public static string FindFirstSeed(IEnumerable<ulong> potential_seeds, int[] ivs)
        {
            foreach (ulong seed in potential_seeds)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (!BruteForceSearch.IsMatch(seed, ivs, i))
                        continue;
                    return $"{seed:X16}";
                }
            }
            return "没找到Seed";
        }
        public static string Raidfinder(string s, PKM pk,int MinIV, int A, int G)
        {
            string T1;
            string T2;
            string T3;
            string C1;
            string C2;
            string C3;
            string T;
            if (string.IsNullOrEmpty(s))
            {
                return "None";
            }
            ulong seed = ulong.Parse(s, NumberStyles.HexNumber);
            Xoroshiro128Plus xoroshiro128Plus = new Xoroshiro128Plus(seed);
            var EC = (uint)xoroshiro128Plus.NextInt(4294967295uL);
            var TID16 = (uint)xoroshiro128Plus.NextInt(4294967295uL);
            var PID = (uint)xoroshiro128Plus.NextInt(4294967295uL);
            short num = Convert.ToInt16(MinIV);
            int[] array = new int[6] { -1, -1, -1, -1, -1, -1 };
            for (short num1 = 0; num1 < num; num1 = (short)(num1 + 1))
            {
                int num3;
                do
                {
                    num3 = (int)xoroshiro128Plus.NextInt(6uL);
                }
                while (array[num3] != -1);
                array[num3] = 31;
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == -1)
                {
                    array[i] = (int)xoroshiro128Plus.NextInt(32uL);
                }
            }
            int ability = 0;
            switch (A)
            {
                case 0:
                    ability = (int)xoroshiro128Plus.NextInt(2uL);
                    break;
                case 1:
                    ability = (int)xoroshiro128Plus.NextInt(3uL);
                    break;
                case 2:
                    ability = 1;
                    break;
            }
            int num5 = 0;
            int num6;
            switch (G)
            {
                case 0:
                    num5 = 0;
                    break;
                case 1:
                    num5 = 31;
                    break;
                case 2:
                    num5 = 63;
                    break;
                case 3:
                    num5 = 127;
                    break;
                case 4:
                    num5 = 191;
                    break;
                case 5:
                    num5 = 22;
                    break;
                case 6:
                    num5 = 254;
                    break;
                case 7:
                    num5 = 255;
                    break;
            }
            num6 = num5 switch
            {
                255 => 2,
                254 => 1,
                0 => 0,
                _ => ((int)xoroshiro128Plus.NextInt(253uL) + 1 < num5) ? 1 : 0,
            };
            var num7 = (int)xoroshiro128Plus.NextInt(129uL) + (int)xoroshiro128Plus.NextInt(128uL);
            var num8 = (int)xoroshiro128Plus.NextInt(129uL) + (int)xoroshiro128Plus.NextInt(128uL);
            var IV = array[0] + "/" + array[1] + "/" + array[2] + "/" + array[3] + "/" + array[4] + "/" + array[5];
            if (EC == pk.EncryptionConstant && 
                PID == pk.PID && 
                pk.IV_HP == array[0] &&
                pk.IV_ATK == array[1] &&
                pk.IV_DEF == array[2] &&
                pk.IV_SPA == array[3] &&
                pk.IV_SPD == array[4] &&
                pk.IV_SPE == array[5])
            {
                T1 = "通过PID/EC/IV检测";
                C1 = "Green";
            }
            else
            {
                T1 = "PID/EC/IV有改动";
                C1 = "Orange";
            }
            if (pk.Met_Location == 244 && Gen8MaxLairGodPool.MaxLairGodFlag(pk.Species))
            {
                num6 = 2;
                ability = 0;
            }
            string Gen = "无";
            string Ab = "特性";
            if (num6 == 0)
            {
                Gen = "公";
            }
            else if (num6 == 1)
            {
                Gen = "母";
            }
            else if (num6 == 2)
            {
                Gen = "无性别";
            }
            if (ability == 0)
            {
                Ab = "特性一";
            }
            else if (ability == 1)
            {
                Ab = "特性二";
            }
            else if (ability == 2)
            {
                Ab = "梦特";
            }
            T2 = $"{Ab},{Gen}";
            T3 = $"身高/体重:{num7}/{num8}";
            if (ability == 2)
                ability = 3;
            if (num6 == pk.Gender && ability == pk.AbilityNumber - 1)
            {
                C2="Green";
            }
            else
            {
                C2="Orange";
            }
            var scale = (IScaledSize)pk;
            if (scale.HeightScalar == num7 && scale.WeightScalar == num8)
            {
               C3="Green";
            }
            else
            {
                C3="Orange";
            }
            T=T1+"\n"+C1+"\n"+T2+"\n"+C2+"\n"+T3+"\n"+C3;
            return T;
            #region 
            /*   ulong initialseedvalue = ulong.Parse(Seed_Box.Text, NumberStyles.HexNumber) & 0xFFFFFFFFFFFFFFFFuL;
                 ulong finalcount = ulong.MaxValue - initialseedvalue;
                 for (ulong num2 = 0uL; num2 < finalcount; num2++)
            {
                uint num14 = (TID16 >> 16) ^ (TID16 & 0xFFFFu);
                uint num15 = num14 / 16u;
                uint num16 = (PID >> 16) ^ (PID & 0xFFFFu);
                uint num17 = num16 / 16u;
                uint num18 = 0u;
                uint num19 = 0u;
                string text3 = Editor.Data.TrainerID7.ToString();
                string text4 = Editor.Data.TrainerSID167.ToString();
                ulong num20 = Convert.ToUInt64(text4.PadLeft(4, '0') + text3.PadLeft(6, '0'));
                string text5 = $"{num20:X}".ToUpper().PadLeft(8, '0');
                string s1 = text5.Substring(4, 4);
                string s2 = text5.Substring(0, 4);
                num18 = uint.Parse(s1, NumberStyles.HexNumber) ^ uint.Parse(s2, NumberStyles.HexNumber);
                num19 = num18 / 16u;
                bool squaretest = false;
                bool startest = false;
                if (num19 == num15 && num19 == num17)
                {
                    if (num14 == num16)
                    {

                        squaretest = true;
                    }
                    else
                    {

                        startest = true;
                       
                        break;
                    }
                }
                else if (num17 == num15 && num19 != num17)
                {
                    if (num14 == num16)
                    {
                        squaretest = true;
                        uint num21 = PID & 0xFFFFu;
                        uint num22 = num18 ^ num21;
                        TID16 = (num22 << 16) + num21;

                    }
                    else
                    {
                        for (int l = 0; l <= 1; l++)
                        {
                            uint num23 = PID & 0xFFFFu;
                            uint num24 = num18 ^ num23;
                            uint num25 = 0u;
                            uint num26 = 0u;
                            switch (l)
                            {
                                case 0:
                                    num25 = num24 + 1;
                                    PID = (num25 << 16) + num23;
                                    num26 = num18 ^ num23 ^ num25;
                                    break;
                                case 1:
                                    num25 = num24 - 1;
                                    PID = (num25 << 16) + num23;
                                    num26 = num18 ^ num23 ^ num25;
                                    break;
                            }
                            if (num26 == 1)
                            {

                                break;
                            }
                        }
                        startest = true;
                       
                    }
                }
              
            }*/
            #endregion 
            //有点蛋疼
        }
    }
}
