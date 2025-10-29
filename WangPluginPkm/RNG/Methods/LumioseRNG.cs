using PKHeX.Core;
using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace WangPluginPkm.RNG.Methods;

public static class LumioseRNG
{
    private const int UNSET = -1;
    private const int MAX = 31;

    public static bool Verify(PKM pk, in GenerateParam9a enc, ulong seed) => IsMatch(pk, enc, seed);

    /// <summary>
    /// Sets the <see cref="pk"/> with random data based on the <see cref="enc"/> and <see cref="criteria"/>.
    /// </summary>
    /// <returns>True if the generated data matches the <see cref="criteria"/>.</returns>
    public static bool TryApply64<TEnc>(this TEnc enc, PA9 pk, in ulong init, in GenerateParam9a param, in EncounterCriteria criteria)
        where TEnc : ISpeciesForm
    {
        var rand = new Xoroshiro128Plus(init);
        const int maxCtr = 100_000;
        for (int ctr = 0; ctr < maxCtr; ctr++)
        {
            ulong seed = rand.Next(); // fake cryptosecure
            if (!GenerateData(pk, param, criteria, seed))
                continue;
            return true; // done.
        }
        return false;
    }

    /// <summary>
    /// Fills out an entity with details from the provided encounter template.
    /// </summary>
    /// <returns>False if the seed cannot generate data matching the criteria.</returns>
    public static bool GenerateData(PA9 pk, in GenerateParam9a enc, in EncounterCriteria criteria, in ulong seed)
    {
        var rand = new Xoroshiro128Plus(seed);
        pk.EncryptionConstant = (uint)rand.NextInt(uint.MaxValue);
        pk.PID = GetAdaptedPID(ref rand, pk, enc);

        if (enc.Shiny is Shiny.Random && criteria.Shiny.IsShiny() != pk.IsShiny)
            return false;

        Span<int> ivs = [UNSET, UNSET, UNSET, UNSET, UNSET, UNSET];
        if (enc.IVs.IsSpecified)
        {
            enc.IVs.CopyToSpeedLast(ivs);
        }
        else if (enc.Correlation is LumioseCorrelation.PreApplyIVs)
        {
            if (enc.FlawlessIVs != 0)
                GenerouslyPreApplyIVs(criteria, ivs, enc.FlawlessIVs);
        }
        else
        {
            for (int i = 0; i < enc.FlawlessIVs; i++)
            {
                int index;
                do { index = (int)rand.NextInt(6); }
                while (ivs[index] != UNSET);
                ivs[index] = MAX;
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (ivs[i] == UNSET)
                ivs[i] = (int)rand.NextInt(MAX + 1);
        }

        if (enc.Correlation == LumioseCorrelation.ReApplyIVs)
        {
            criteria.SetRandomIVs(pk, flawless: enc.FlawlessIVs);
        }
        else
        {
            if (!criteria.IsIVsCompatibleSpeedLast(ivs))
                return false;
            pk.IV32 = (uint)ivs[0] |
                      (uint)(ivs[1] << 05) |
                      (uint)(ivs[2] << 10) |
                      (uint)(ivs[5] << 15) | // speed is last in the array, but in the middle of the 32bit value
                      (uint)(ivs[3] << 20) |
                      (uint)(ivs[4] << 25);
        }

        int ability = enc.Ability switch
        {
            AbilityPermission.Any12H => (int)rand.NextInt(3) << 1,
            AbilityPermission.Any12 => (int)rand.NextInt(2) << 1,
            _ => (int)enc.Ability,
        };
        pk.RefreshAbility(ability >> 1);

        var gender_ratio = enc.GenderRatio;
        byte gender = gender_ratio switch
        {
            PersonalInfo.RatioMagicGenderless => 2,
            PersonalInfo.RatioMagicFemale => 1,
            PersonalInfo.RatioMagicMale => 0,
            _ => GetGender(gender_ratio, rand.NextInt(100)),
        };
        if (criteria.IsSpecifiedGender() && !criteria.IsSatisfiedGender(gender))
            return false;
        pk.Gender = gender;

        var nature = enc.Nature != Nature.Random ? enc.Nature
            : (Nature)rand.NextInt(25);

        // Compromise on Nature -- some are fixed, some are random. If the request wants a specific nature, just mint it.
        if (criteria.IsSpecifiedNature() && !criteria.IsSatisfiedNature(nature))
            return false;
        pk.Nature = pk.StatNature = nature;

        pk.Scale = enc.SizeType.GetSizeValue(enc.Scale, ref rand);
        return true;
    }

    /// <summary>
    /// Gives a quantity of flawless IVs based on the criteria, unrelated to an RNG correlation.
    /// </summary>
    private static void GenerouslyPreApplyIVs(in EncounterCriteria criteria, Span<int> ivs, byte encFlawlessIVs)
    {
        // Try to give a perfect IV where it's wanted first
        for (int i = 0; i < ivs.Length; i++)
        {
            if (ivs[i] != UNSET)
                continue;
            var desire = criteria.GetIV(i);
            if (desire is not MAX)
                continue;

            ivs[i] = MAX;
            encFlawlessIVs--;
            if (encFlawlessIVs == 0)
                return;
        }

        // Then try to give a perfect IV where it's allowed
        for (int i = 0; i < ivs.Length; i++)
        {
            if (ivs[i] != UNSET)
                continue;
            var desire = criteria.GetIV(i);
            if (desire >= 0)
                continue;

            ivs[i] = MAX;
            encFlawlessIVs--;
            if (encFlawlessIVs == 0)
                return;
        }

        // Apply remaining flawless IVs if not <= 1
        for (int i = 0; i < ivs.Length; i++)
        {
            if (ivs[i] != UNSET)
                continue;
            var desire = criteria.GetIV(i);
            if (desire is 0 or 1)
                continue;

            ivs[i] = MAX;
            encFlawlessIVs--;
            if (encFlawlessIVs == 0)
                return;
        }

        // If we reach here... we couldn't satisfy the flawless IV count requested. Probably the encounter isn't what the user expected/wanted.
        for (int i = 0; i < ivs.Length; i++)
        {
            if (ivs[i] == UNSET)
                ivs[i] = MAX;
        }
    }

    public static bool IsMatch(PKM pk, in GenerateParam9a enc, in ulong seed)
    {
        // same as above method
        var rand = new Xoroshiro128Plus(seed);
        if (pk.EncryptionConstant != (uint)rand.NextInt(uint.MaxValue))
            return false;

        var pid = GetAdaptedPID(ref rand, pk, enc);
        if (pk.PID != pid)
            return false;

        if (enc.Correlation is LumioseCorrelation.PreApplyIVs)
            return IsMatchUnknownPreFillIVs(pk, in enc, rand);
        return IsMatchIVsAndFollowing(pk, enc, rand);
    }

    private static bool IsMatchIVsAndFollowing(PKM pk, in GenerateParam9a enc, Xoroshiro128Plus rand)
    {
        Span<int> ivs = [UNSET, UNSET, UNSET, UNSET, UNSET, UNSET];
        if (enc.IVs.IsSpecified)
            enc.IVs.CopyToSpeedLast(ivs);
        for (int i = 0; i < enc.FlawlessIVs; i++)
        {
            int index;
            do { index = (int)rand.NextInt(6); }
            while (ivs[index] != UNSET);
            ivs[index] = MAX;
        }
        return IsMatchIVsAndFollowing(pk, in enc, rand, ivs);
    }

    private static bool IsMatchIVsAndFollowing(PKM pk, in GenerateParam9a enc, Xoroshiro128Plus rand, Span<int> ivs)
    {
        for (int i = 0; i < 6; i++)
        {
            if (ivs[i] == UNSET)
                ivs[i] = (int)rand.NextInt(32);
        }

        if (enc.Correlation is not LumioseCorrelation.ReApplyIVs)
        {
            if (pk.IV_HP != ivs[0])
                return false;
            if (pk.IV_ATK != ivs[1])
                return false;
            if (pk.IV_DEF != ivs[2])
                return false;
            if (pk.IV_SPA != ivs[3])
                return false;
            if (pk.IV_SPD != ivs[4])
                return false;
            if (pk.IV_SPE != ivs[5])
                return false;
        }

        // No way to change abilities. Index must match.
        int ability = enc.Ability switch
        {
            AbilityPermission.Any12H => 1 << (int)rand.NextInt(3),
            AbilityPermission.Any12 => 1 << (int)rand.NextInt(2),
            _ => (int)enc.Ability,
        };
        if (pk.AbilityNumber != ability)
            return false;

        var gender_ratio = enc.GenderRatio;
        byte gender = gender_ratio switch
        {
            PersonalInfo.RatioMagicGenderless => 2,
            PersonalInfo.RatioMagicFemale => 1,
            PersonalInfo.RatioMagicMale => 0,
            _ => GetGender(gender_ratio, rand.NextInt(100)),
        };
        if (pk.Gender != gender)
            return false;

        var nature = enc.Nature != Nature.Random ? enc.Nature
            : (Nature)rand.NextInt(25);
        if (pk.Nature != nature)
            return false;

        // Scale
        {
            var value = enc.SizeType.GetSizeValue(enc.Scale, ref rand);
            if (pk is IScaledSize3 s)
            {
                if (s.Scale != value)
                    return false;
            }
        }
        return true;
    }

    private static uint GetAdaptedPID(ref Xoroshiro128Plus rand, PKM pk, in GenerateParam9a enc)
    {
        var fakeTID = enc.Correlation is LumioseCorrelation.SkipTrainer ? pk.ID32 : (uint)rand.NextInt();
        uint pid = (uint)rand.NextInt();
        if (enc.Shiny == Shiny.Random) // let's decide if it's shiny or not!
        {
            int i = 1;
            bool isShiny;
            uint xor;
            while (true)
            {
                xor = ShinyUtil.GetShinyXor(pid, fakeTID);
                isShiny = xor < 16;
                if (isShiny)
                {
                    if (xor != 0)
                        xor = 1;
                    break;
                }
                if (i >= enc.RollCount)
                    break;
                pid = (uint)rand.NextInt();
                i++;
            }
            ShinyUtil.ForceShinyState(isShiny, ref pid, pk.ID32, xor);
        }
        else if (enc.Shiny == Shiny.Always)
        {
            var tid = (ushort)fakeTID;
            var sid = (ushort)(fakeTID >> 16);
            if (!ShinyUtil.GetIsShiny6(fakeTID, pid)) // battled
                pid = ShinyUtil.GetShinyPID(tid, sid, pid, 0);
            if (!ShinyUtil.GetIsShiny6(pk.ID32, pid)) // captured
                pid = ShinyUtil.GetShinyPID(pk.TID16, pk.SID16, pid, ShinyUtil.GetShinyXor(pid, fakeTID) == 0 ? 0u : 1u);
        }
        else // Never
        {
            if (ShinyUtil.GetIsShiny6(fakeTID, pid)) // battled
                pid ^= 0x1000_0000;
            if (ShinyUtil.GetIsShiny6(pk.ID32, pid)) // captured
                pid ^= 0x1000_0000;
        }
        return pid;
    }

    private static bool IsMatchUnknownPreFillIVs(PKM pk, in GenerateParam9a enc, Xoroshiro128Plus rand)
    {
        int k = enc.FlawlessIVs;
        if (k == 0)
            return IsMatchIVsAndFollowing(pk, in enc, rand, 0); // none
        if (k == 6)
            return IsMatchIVsAndFollowing(pk, in enc, rand, (1 << 6) - 1); // all

        // Treat flawless IVs as a combination problem: choose k flawless IVs from 6 stats.
        // Since we don't know the IVs that were filled before entering FixInitSpec, we must guess every combination.
        // We can do this efficiently using Gosper's hack to iterate combinations.
        // https://rosettacode.org/wiki/Gosper%27s_hack
        // Each bit set in our combination represents a flawless IV.

        // Usually, only k flawless IVs will be present in the result entity.
        // Only a small subset of combinations will be valid based on the flawless IVs we can observe from the result entity.
        // This will allow us to skip checking the majority of combinations.
        var permit = GetBitmaskFlawlessIVs(pk);
        if (System.Numerics.BitOperations.PopCount((uint)permit) == k)
            return IsMatchIVsAndFollowing(pk, in enc, rand, permit); // only one possible combination

        const int limit = 1 << 6;
        var comb = (1 << k) - 1; // initial combination: k low bits set

        while (true)
        {
            // If the combination sets a flawless IV that is not flawless in the entity, skip it.
            // comb is a valid number with k bits set
            if ((comb & permit) == comb)
            {
                if (IsMatchIVsAndFollowing(pk, in enc, rand, comb))
                    return true;
            }

            // Gosper's hack to get the next combination with same popcount
            int c = comb;
            int u = c & -c;
            int v = c + u;
            if (v is >= limit or 0)
                break; // no further n-bit combinations
            comb = v + (((v ^ c) / u) >> 2);
        }

        return false;
    }

    private static int GetBitmaskFlawlessIVs(PKM pk)
    {
        int result = 0;
        if (pk.IV_HP == MAX)
            result |= 1 << 0;
        if (pk.IV_ATK == MAX)
            result |= 1 << 1;
        if (pk.IV_DEF == MAX)
            result |= 1 << 2;
        if (pk.IV_SPA == MAX)
            result |= 1 << 3;
        if (pk.IV_SPD == MAX)
            result |= 1 << 4;
        if (pk.IV_SPE == MAX)
            result |= 1 << 5;
        return result;
    }

    private static bool IsMatchIVsAndFollowing(PKM pk, in GenerateParam9a enc, Xoroshiro128Plus rand, int flawlessBits)
    {
        Span<int> ivs = [UNSET, UNSET, UNSET, UNSET, UNSET, UNSET];
        for (int i = 0; i < 6; i++)
        {
            if ((flawlessBits & (1 << i)) != 0)
                ivs[i] = MAX;
        }

        return IsMatchIVsAndFollowing(pk, in enc, rand, ivs);
    }

    public static byte GetGender(in byte ratio, in ulong rand100) => ratio switch
    {
        EntityGender.VM => rand100 < 12 ? (byte)1 : (byte)0, // 12.5%
        EntityGender.MM => rand100 < 25 ? (byte)1 : (byte)0, // 25%
        EntityGender.HH => rand100 < 50 ? (byte)1 : (byte)0, // 50%
        EntityGender.MF => rand100 < 75 ? (byte)1 : (byte)0, // 75%
        EntityGender.VF => rand100 < 89 ? (byte)1 : (byte)0, // 87.5%

        _ => throw new ArgumentOutOfRangeException(nameof(ratio), ratio, null),
    };
    // 从 PA9 的物种/形态获取个人资料（ZA 目前复用 SV 表；如你工程有 ZA 专表，替换下面这一行）
    private static PersonalInfo GetPersonal(PA9 pk) =>
        PersonalTable.SV.GetFormEntry(pk.Species, pk.Form);

    /// <summary>
    /// 适配 ZA（PA9）的生成器：给定 seed 与规则，尝试生成一只满足规则的个体。
    /// </summary>
    /// <param name="pk">输入：带 Species/AltForm/训练家ID；输出：生成后的个体</param>
    /// <param name="seed">64-bit 种子</param>
    /// <param name="r">你的 CheckRules（仅演示用 IV 区间，其他可自行扩展）</param>
    /// <param name="flawless">遭遇的保底V个数（按场景填写；默认 0）</param>
    /// <param name="requireShiny">是否强制闪（null=随缘；true=必须闪；false=必须不闪）</param>
    /// <param name="desiredNature">如果要固定性格，传入 Nature；否则 null</param>
    /// <param name="desiredGender">若要固定性别：0=♂,1=♀,2=无性别；否则 null</param>
    /// <param name="allowHA">是否允许梦特参与随机（物种有HA才生效）</param>
    public static bool GenPkm(
        ref PKM pk,
        ulong seed,
        CheckRules r,
        byte flawless = 0,
        bool? requireShiny = null,
        Nature? desiredNature = null,
        byte? desiredGender = null)
    {
        // 1) 构造 enc：用物种事实（性别比/HA可用性/保底V数…）
        var pi = GetPersonal((PA9)pk);
        var enc = new GenerateParam9a
        {
            GenderRatio = pi.Gender, // 生成时按该比例抽性别并回写 pk.Gender
            FlawlessIVs = flawless,
            Nature = desiredNature ?? Nature.Random,
            Shiny = requireShiny == null ? Shiny.Random : (requireShiny.Value ? Shiny.Always : Shiny.Never),
            Correlation = LumioseCorrelation.Normal, // 如需以训练家ID影响PID，可改为 SkipTrainer
        };
        if (pk is PA9 p)
        {
            GData(p, seed);
            if (!CheckIV(r, pk))
                return false;
            if (!CheckShiny(r, pk))
                return false;
            return true;
            // 如果你希望在非 ZA 直接失败：
          
        }
        return false;
        // 或者抛异常：
        // throw new NotSupportedException("LumioseRNG 仅支持 PA9（ZA）个体。");
    }

    // 直接复用你现有的区间校验写法（示意；你已实现）
    private static bool CheckIV(CheckRules r, PKM pk)
    {
        if (pk.IV_HP < r.minHP || pk.IV_HP > r.maxHP) return false;
        if (pk.IV_ATK < r.minAtk || pk.IV_ATK > r.maxAtk) return false;
        if (pk.IV_DEF < r.minDef || pk.IV_DEF > r.maxDef) return false;
        if (pk.IV_SPA < r.minSpA || pk.IV_SPA > r.maxSpA) return false;
        if (pk.IV_SPD < r.minSpD || pk.IV_SPD > r.maxSpD) return false;
        if (pk.IV_SPE < r.minSpe || pk.IV_SPE > r.maxSpe) return false;
        return true;
    }
    public static bool CheckShiny(CheckRules r, PKM pk)
    {
        var s = (uint)(pk.TID16 ^ pk.SID16) ^ ((pk.PID >> 16) ^ (pk.PID & 0xFFFF));
        if (r.Shiny == RNGForm.ShinyType.None)
            return true;
        else if (r.Shiny == RNGForm.ShinyType.Shiny && s < 8)
            return true;
        else if (r.Shiny == RNGForm.ShinyType.Star && s < 8 && s != 0)
            return true;
        else if (r.Shiny == RNGForm.ShinyType.Sqaure && s == 0)
            return true;
        else if (r.Shiny == RNGForm.ShinyType.ForceStar && s == 1)
            return true;
        else
            return false;
    }
    public static uint Next(uint seed)
    {
        // 将 32-bit 扩展成 64-bit 作为初始状态
        var rng = new Xoroshiro128Plus(seed);
        return (uint)rng.Next(); // 输出一个随机 uint
    }
    public static PKM GData(PA9 pk, in ulong seed)
    {
        var criteria = new EncounterCriteria();             // 或 EncounterCriteria.Unrestricted

        var g = PersonalTable.SV.GetFormEntry(pk.Species, pk.Form).Gender;
        var enc = new GenerateParam9a(
            GenderRatio: g,  
            FlawlessIVs: 0,     // 无保底V
            RollCount: 1        // 单次闪光 roll
        );
        var rand = new Xoroshiro128Plus(seed);
        pk.EncryptionConstant = (uint)rand.NextInt(uint.MaxValue);
        pk.PID = GetAdaptedPID(ref rand, pk, enc);

        if (enc.Shiny is Shiny.Random && criteria.Shiny.IsShiny() != pk.IsShiny)
            return pk;

        Span<int> ivs = [UNSET, UNSET, UNSET, UNSET, UNSET, UNSET];
        if (enc.IVs.IsSpecified)
        {
            enc.IVs.CopyToSpeedLast(ivs);
        }
        else if (enc.Correlation is LumioseCorrelation.PreApplyIVs)
        {
            if (enc.FlawlessIVs != 0)
                GenerouslyPreApplyIVs(criteria, ivs, enc.FlawlessIVs);
        }
        else
        {
            for (int i = 0; i < enc.FlawlessIVs; i++)
            {
                int index;
                do { index = (int)rand.NextInt(6); }
                while (ivs[index] != UNSET);
                ivs[index] = MAX;
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (ivs[i] == UNSET)
                ivs[i] = (int)rand.NextInt(MAX + 1);
        }

        if (enc.Correlation == LumioseCorrelation.ReApplyIVs)
        {
            criteria.SetRandomIVs(pk, flawless: enc.FlawlessIVs);
        }
        else
        {
            if (!criteria.IsIVsCompatibleSpeedLast(ivs))
                return pk;
            pk.IV32 = (uint)ivs[0] |
                      (uint)(ivs[1] << 05) |
                      (uint)(ivs[2] << 10) |
                      (uint)(ivs[5] << 15) | // speed is last in the array, but in the middle of the 32bit value
                      (uint)(ivs[3] << 20) |
                      (uint)(ivs[4] << 25);
        }

        int ability = enc.Ability switch
        {
            AbilityPermission.Any12H => (int)rand.NextInt(3) << 1,
            AbilityPermission.Any12 => (int)rand.NextInt(2) << 1,
            _ => (int)enc.Ability,
        };
        pk.RefreshAbility(ability >> 1);

        var gender_ratio = enc.GenderRatio;
        byte gender = gender_ratio switch
        {
            PersonalInfo.RatioMagicGenderless => 2,
            PersonalInfo.RatioMagicFemale => 1,
            PersonalInfo.RatioMagicMale => 0,
            _ => GetGender(gender_ratio, rand.NextInt(100)),
        };
        if (criteria.IsSpecifiedGender() && !criteria.IsSatisfiedGender(gender))
            return pk;
        pk.Gender = gender;

        var nature = enc.Nature != Nature.Random ? enc.Nature
            : (Nature)rand.NextInt(25);

        // Compromise on Nature -- some are fixed, some are random. If the request wants a specific nature, just mint it.
        if (criteria.IsSpecifiedNature() && !criteria.IsSatisfiedNature(nature))
            return pk;
        pk.Nature = pk.StatNature = nature;

        pk.Scale = enc.SizeType.GetSizeValue(enc.Scale, ref rand);
        return pk;
    }

}
