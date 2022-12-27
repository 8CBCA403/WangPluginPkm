﻿using PKHeX.Core;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WangPluginPkm.WangUtil.FlatBuffer;
using static System.Buffers.Binary.BinaryPrimitives;
#nullable enable
namespace WangPluginPkm.WangUtil.TeraRaidBase
{
    public class TeraDistribution : ITeraRaid
    {
        public readonly EncounterStatic Entity; // Raw data
        public readonly ulong DropTableFix;
        public readonly ulong DropTableRandom;
        public readonly ushort[] ExtraMoves;
        public ushort Species => Entity.Species;
        public byte Form => Entity.Form;
        public sbyte Gender => Entity.Gender;
        public AbilityPermission Ability => Entity.Ability;
        public byte FlawlessIVCount => Entity.FlawlessIVCount;
        public Shiny Shiny => Entity.Shiny;
        public byte Level => Entity.Level;
        public ushort Move1 => Entity.Moves.Move1;
        public ushort Move2 => Entity.Moves.Move2;
        public ushort Move3 => Entity.Moves.Move3;
        public ushort Move4 => Entity.Moves.Move4;

        public readonly sbyte DeliveryGroupID;
        public byte Stars => Entity is ITeraRaid9 t9 ? t9.Stars : (byte)0;
        public byte RandRate => Entity is ITeraRaid9 t9 ? t9.RandRate : (byte)0;
        ushort[] ITeraRaid.ExtraMoves => ExtraMoves;
        public TeraDistribution(EncounterStatic enc, ulong fixedrewards, ulong lotteryrewards, ushort[] extras, sbyte group)
        {
            Entity = enc;
            DropTableFix = fixedrewards;
            DropTableRandom = lotteryrewards;
            ExtraMoves = extras.Where(z => z != 0 && !Entity.Moves.Contains(z)).Distinct().ToArray();
            DeliveryGroupID = group;
            if (ExtraMoves.Length > 4)
                Debug.WriteLine(ExtraMoves);
        }

        public static ITeraRaid[] GetAllEncounters(string resource)
        {
            var all = FlatbufferDumper.DumpDistributionRaids(resource);
            var type2 = EncounterDist9.GetArray(all[0]);
            var type3 = EncounterMight9.GetArray(all[1]);
            var rewards2 = GetRewardTables(all[2]);
            var rewards3 = GetRewardTables(all[3]);
            var extra2 = all[4];
            var extra3 = all[5];
            var group2 = all[6];
            var group3 = all[7];
            var result = new TeraDistribution[type2.Length + type3.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = i < type2.Length ? new TeraDistribution(type2[i], rewards2[i].Item1, rewards2[i].Item2, GetExtraMoves(extra2[(12 * i)..]), (sbyte)group2[i])
                                             : new TeraDistribution(type3[i - type2.Length], rewards3[i - type2.Length].Item1, rewards3[i - type2.Length].Item2,
           GetExtraMoves(extra3[(12 * (i - type2.Length))..]), (sbyte)group3[i - type2.Length]);
            return result;
        }
        public static (ulong, ulong)[] GetRewardTables(byte[] rewards)
        {
            var count = rewards.Length / 0x10;
            var result = new (ulong, ulong)[count];
            for (int i = 0; i < result.Length; i++)
                result[i] = (ReadUInt64LittleEndian(rewards[(0x10 * i)..]), ReadUInt64LittleEndian(rewards[(0x10 * i + 0x8)..]));
            return result;
        }
        public static ushort[] GetExtraMoves(byte[] extra)
        {
            var result = new ushort[6];
            for (int i = 0; i < result.Length; i++)
                result[i] = ReadUInt16LittleEndian(extra[(0x2 * i)..]);
            return result;
        }
        public static List<(int, int, int)>? GetRewards(TeraDistribution enc, uint seed, List<DeliveryRaidFixedRewardItem>? fixed_rewards, List<DeliveryRaidLotteryRewardItem>? lottery_rewards, int boost)
        {
            if (lottery_rewards == null)
                return null;
            if (fixed_rewards == null)
                return null;

            var fixed_table = fixed_rewards.Where(z => z.TableName == enc.DropTableFix).First();
            if (fixed_table == null)
                return null;

            var lottery_table = lottery_rewards.Where(z => z.TableName == enc.DropTableRandom).First();
            if (lottery_table == null)
                return null;

            List<(int, int, int)> result = new();

            // fixed reward
            for (int i = 0; i < DeliveryRaidFixedRewardItem.Count; i++)
            {
                var item = fixed_table.GetReward(i);
                if (item.Category == 0 && item.ItemID == 0)
                    continue;
                result.Add((item.ItemID == 0 ? item.Category * 10000 : item.ItemID, item.Num, item.SubjectType));
            }

            // lottery reward
            var total = 0;
            for (int i = 0; i < DeliveryRaidLotteryRewardItem.RewardItemCount; i++)
                total += lottery_table.GetRewardItem(i).Rate;
            var rand = new Xoroshiro128Plus(seed);
            var count = (int)rand.NextInt(100); // sandwich = extra rolls? how does this work? is this even 100?
            count = Rewards.GetRewardCount(count, enc.Stars) + boost;
            for (int i = 0; i < count; i++)
            {
                var roll = (int)rand.NextInt((ulong)total);
                for (int j = 0; j < DeliveryRaidLotteryRewardItem.RewardItemCount; j++)
                {
                    var item = lottery_table.GetRewardItem(j);
                    if (roll < item.Rate)
                    {
                        if (item.Category == 0) result.Add((item.ItemID, item.Num, 0));
                        else if (item.Category == 1) result.Add(item.ItemID == 0 ? (10000, item.Num, 0) : (item.ItemID, item.Num, 0));
                        else result.Add(item.ItemID == 0 ? (20000, item.Num, 0) : (item.ItemID, item.Num, 0));
                        break;
                    }
                    roll -= item.Rate;
                }
            }
            return result;
        }
        public static ITeraRaid? GetEncounter(uint Seed, int stage, bool isFixed)
        {
            if (stage < 0)
                return null;
            if (!isFixed)
            {
                if (TeraRaid.DistTeraRaids != null)
                {
                    foreach (TeraDistribution enc in TeraRaid.DistTeraRaids)
                    {
                        if (enc.Entity is not EncounterDist9 encd)
                            continue;
                        var total = TeraRaid.Game == "Scarlet" ? encd.GetRandRateTotalScarlet(stage) : encd.GetRandRateTotalViolet(stage);
                        if (total != 0 || isFixed)
                        {
                            if (isFixed)
                                return enc;
                            var rand = new Xoroshiro128Plus(Seed);
                            _ = rand.NextInt(100);
                            var val = rand.NextInt(total);
                            var min = TeraRaid.Game == "Scarlet" ? encd.GetRandRateMinScarlet(stage) : encd.GetRandRateMinViolet(stage);
                            if ((uint)((int)val - min) < enc.RandRate)
                                return enc;
                        }
                    }
                }
            }
            else
            {
                if (TeraRaid.DistTeraRaids != null)
                {
                    foreach (TeraDistribution enc in TeraRaid.DistTeraRaids)
                    {
                        if (enc.Entity is not EncounterMight9 encm)
                            continue;
                        var total = TeraRaid.Game == "Scarlet" ? encm.GetRandRateTotalScarlet(stage) : encm.GetRandRateTotalViolet(stage);
                        if (total != 0 || isFixed)
                        {
                            if (isFixed)
                                return enc;
                            var rand = new Xoroshiro128Plus(Seed);
                            _ = rand.NextInt(100);
                            var val = rand.NextInt(total);
                            var min = TeraRaid.Game == "Scarlet" ? encm.GetRandRateMinScarlet(stage) : encm.GetRandRateMinViolet(stage);
                            if ((uint)((int)val - min) < enc.RandRate)
                                return enc;
                        }
                    }
                }
            }
            return null;
        }
    }
}
