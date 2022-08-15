using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKHeX.Core;
using System.Text.RegularExpressions;

namespace WangPlugin
{
    internal class PSTranslator<T> where T : PKM
    {
            public static GameStrings GameStrings = GameInfo.GetStrings("zh");
            public static GameStrings GameStringsEn = GameInfo.GetStrings("en");
            public static string Chinese2Showdown(string zh)
            {
                string result = "";
                int candidateSpecieNo = 0;
                int candidateSpecieStringLength = 0;
                string[] itmeflag = new string[] { "携带" };
                string[] moveflag = new string[] { "\n-" };
                string[] split = null;
                string[] item = null;
                string[] move = null;
                if (zh.Split(moveflag, StringSplitOptions.None) != null)
                {
                    move = zh.Split(moveflag, StringSplitOptions.None);
                }
                if (move != null)
                    zh = move[0];
                if (zh.Split('\n') != null)
                {
                    split = zh.Split('\n');
                }
                if (split != null)
                    zh = split[0];
                if (zh.Split(itmeflag, StringSplitOptions.None) != null)
                {
                    item = zh.Split(itmeflag, StringSplitOptions.None);
                }
                if (item != null)
                    zh = item[0];


                if (zh.StartsWith("蛋") || zh.StartsWith(" 蛋") || zh.StartsWith("  蛋"))
                {
                    result += "Egg ";
                    if (zh.StartsWith("蛋"))
                    {
                        zh = zh.Replace("蛋", "");
                    }
                    else if (zh.StartsWith(" 蛋"))
                    {
                        zh = zh.Replace(" 蛋", "");
                    }
                    else if (zh.StartsWith("  蛋"))
                    {
                        zh = zh.Replace("  蛋", "");
                    }
                    for (int i = 0; i < GameStrings.Species.Count; i++)
                    {
                        if (zh.Contains(GameStrings.Species[i]) && GameStrings.Species[i].Length > candidateSpecieStringLength)
                        {
                            candidateSpecieNo = i;
                            candidateSpecieStringLength = GameStrings.Species[i].Length;
                        }
                    }

                    if (candidateSpecieNo > 0 && candidateSpecieNo != 29 && candidateSpecieNo != 32)
                    {
                        result += $"({GameStringsEn.Species[candidateSpecieNo]})";
                        zh = zh.Replace(GameStrings.Species[candidateSpecieNo], "");
                    }
                    else if (zh.Contains("尼多朗"))
                    {
                        result += "(Nidoran-M)";
                        zh = zh.Replace("尼多朗", "");
                    }
                    else if (zh.Contains("尼多兰"))
                    {
                        result += "(Nidoran-F)";
                        zh = zh.Replace("尼多兰", "");
                    }
                    else
                    {
                        return result;
                    }
                    if (Regex.IsMatch(zh, "[A-Z?!？！]形态"))
                    {
                        string formsUnown = Regex.Match(zh, "([A-Z?!？！])形态").Groups?[1]?.Value ?? "";
                        if (formsUnown == "？") formsUnown = "?";
                        else if (formsUnown == "！") formsUnown = "!";
                        result += $"-{formsUnown}";
                        zh = Regex.Replace(zh, "[A-Z?!？！]形态", "");
                    }

                    for (int i = 0; i < GameStrings.forms.Length; i++)
                    {
                        if (GameStrings.forms[i].Length == 0) continue;
                        if (!zh.Contains(GameStrings.forms[i] + "形态")) continue;
                        result += $"-{GameStringsEn.forms[i]}";
                        zh = zh.Replace(GameStrings.forms[i] + "形态", "");
                        break;
                    }
                    if (zh.Contains("公"))
                    {
                        result += " (M)";
                        zh = zh.Replace("公", "");
                    }
                    else if (zh.Contains("母"))
                    {
                        result += " (F)";
                        zh = zh.Replace("母", "");
                    }
                    if (zh.Contains("异色"))
                    {
                        result += "\nShiny: Yes";
                        zh = zh.Replace("异色", "");
                    }
                    else if (zh.Contains("闪光"))
                    {
                        result += "\nShiny: Yes";
                        zh = zh.Replace("闪光", "");
                    }
                    else if (zh.Contains("方块闪"))
                    {
                        result += "\nShiny: Square";
                        zh = zh.Replace("方块闪", "");
                    }
                    else if (zh.Contains("星星闪"))
                    {
                        result += "\nShiny: Star";
                        zh = zh.Replace("星星闪", "");
                    }
                    result += $"\nLevel: 1";
                    for (int i = 0; i < GameStrings.Natures.Count; i++)
                    {
                        if (zh.Contains(GameStrings.Natures[i]))
                        {
                            result += $"\n{GameStringsEn.Natures[i]} Nature";
                            zh = zh.Replace(GameStrings.Natures[i], "");
                            break;
                        }
                    }
                    for (int i = 0; i < GameStrings.abilitylist.Length; i++)
                    {
                        if (GameStrings.abilitylist[i].Length == 0) continue;
                        if (!zh.Contains(GameStrings.abilitylist[i] + "特性")) continue;
                        var AbilityStr = GameStringsEn.abilitylist[i];
                        result += $"\nAbility: {AbilityStr}";
                        zh = zh.Replace(GameStrings.abilitylist[i] + "特性", "");
                        break;
                    }
                    for (int i = 0; i < GameStrings.balllist.Length; i++)
                    {
                        if (GameStrings.balllist[i].Length == 0) continue;
                        if (!zh.Contains(GameStrings.balllist[i])) continue;
                        var ballStr = GameStringsEn.balllist[i];
                        if (typeof(T) == typeof(PA8) && ballStr is "Poké Ball" or "Great Ball" or "Ultra Ball") ballStr = "LA" + ballStr;
                        result += $"\nBall: {ballStr}";
                        zh = zh.Replace(GameStrings.balllist[i], "");
                        break;
                    }
                    if (zh.Contains("6v"))
                    {
                        result += "\nIVs: 31 HP / 31 Atk / 31 Def / 31 SpA / 31 SpD / 31 Spe";
                        zh = zh.Replace("6v", "");
                    }
                    else if (zh.Contains("4v0a0s"))
                    {
                        result += "\nIVs: 31 HP / 0 Atk / 31 Def / 31 SpA / 31 SpD / 0 Spe";
                        zh = zh.Replace("4v0a0s", "");
                    }
                    else if (zh.Contains("5v0a"))
                    {
                        result += "\nIVs: 31 HP / 0 Atk / 31 Def / 31 SpA / 31 SpD / 31 Spe";
                        zh = zh.Replace("5v0a", "");
                    }
                    else if (zh.Contains("5v0s"))
                    {
                        result += "\nIVs: 31 HP / 31 Atk / 31 Def / 31 SpA / 31 SpD / 0 Spe";
                        zh = zh.Replace("5v0s", "");
                    }
                    else if (split != null)
                    {
                        if (split.Length == 2)
                        {
                            if (split[1].StartsWith("个体") && (Encoding.Default.GetByteCount(split[1]) > 6))
                            {
                                result += "\nIVs: ";
                                split[1] = split[1].Replace("个体", "");
                                result += IVEV(split[1]);
                            }
                            else
                            {
                                result = "你写错了";
                            }
                        }
                    }
                    if (move != null)
                    {
                        int n = move.Length;
                        for (int i = 1; i < n; i++)
                        {
                            for (int j = 0; j < GameStrings.movelist.Length; j++)
                            {
                                if (GameStrings.movelist[j].Length == 0) continue;
                                if (!move[i].Contains(GameStrings.movelist[j])) continue;
                                var MoveStr = GameStringsEn.movelist[j];
                                result += $"\n-{MoveStr}";
                                move[i] = move[i].Replace(GameStrings.movelist[j], "");
                                break;
                            }
                        }
                    }
                    return result;
                }
                else
                {
                    for (int i = 0; i < GameStrings.Species.Count; i++)
                    {
                        if (zh.Contains(GameStrings.Species[i]) && GameStrings.Species[i].Length > candidateSpecieStringLength)
                        {
                            candidateSpecieNo = i;
                            candidateSpecieStringLength = GameStrings.Species[i].Length;
                        }
                    }

                    if (candidateSpecieNo > 0 && candidateSpecieNo != 29 && candidateSpecieNo != 32)
                    {
                        result += GameStringsEn.Species[candidateSpecieNo];
                        zh = zh.Replace(GameStrings.Species[candidateSpecieNo], "");
                    }
                    else if (zh.Contains("尼多朗"))
                    {
                        result += "Nidoran-M";
                        zh = zh.Replace("尼多朗", "");
                    }
                    else if (zh.Contains("尼多兰"))
                    {
                        result += "Nidoran-F";
                        zh = zh.Replace("尼多兰", "");
                    }
                    else
                    {
                        return result;
                    }

                    if (Regex.IsMatch(zh, "[A-Z?!？！]形态"))
                    {
                        string formsUnown = Regex.Match(zh, "([A-Z?!？！])形态").Groups?[1]?.Value ?? "";
                        if (formsUnown == "？") formsUnown = "?";
                        else if (formsUnown == "！") formsUnown = "!";
                        result += $"-{formsUnown}";
                        zh = Regex.Replace(zh, "[A-Z?!？！]形态", "");
                    }

                    for (int i = 0; i < GameStrings.forms.Length; i++)
                    {
                        if (GameStrings.forms[i].Length == 0) continue;
                        if (!zh.Contains(GameStrings.forms[i] + "形态")) continue;
                        result += $"-{GameStringsEn.forms[i]}";
                        zh = zh.Replace(GameStrings.forms[i] + "形态", "");
                        break;
                    }

                    if (zh.Contains("公"))
                    {
                        result += " (M)";
                        zh = zh.Replace("公", "");
                    }
                    else if (zh.Contains("母"))
                    {
                        result += " (F)";
                        zh = zh.Replace("母", "");
                    }
                    if (item != null)
                    {
                        if (item.Length == 2 && (item[1] != ""))
                        {
                            for (int i = 0; i < GameStrings.itemlist.Length; i++)
                            {
                                if (GameStrings.itemlist[i].Length == 0) continue;
                                if (!item[1].Contains(GameStrings.itemlist[i])) continue;
                                var ItemStr = GameStringsEn.itemlist[i];
                                result += $" @ {ItemStr}";
                                zh = zh.Replace(GameStrings.itemlist[i], "");
                                break;
                            }
                        }
                    }
                    if (Regex.IsMatch(zh, "\\d{1,3}级"))
                    {
                        string level = Regex.Match(zh, "(\\d{1,3})级").Groups?[1]?.Value ?? "100";
                        result += $"\nLevel: {level}";
                        zh = Regex.Replace(zh, "\\d{1,3}级", "");
                    }
                    if (zh.Contains("异色"))
                    {
                        result += "\nShiny: Yes";
                        zh = zh.Replace("异色", "");
                    }
                    else if (zh.Contains("闪光"))
                    {
                        result += "\nShiny: Yes";
                        zh = zh.Replace("闪光", "");
                    }
                    else if (zh.Contains("方块闪"))
                    {
                        result += "\nShiny: Square";
                        zh = zh.Replace("方块闪", "");
                    }
                    else if (zh.Contains("星星闪"))
                    {
                        result += "\nShiny: Star";
                        zh = zh.Replace("星星闪", "");
                    }
                    else if (zh.Contains("方闪"))
                    {
                        result += "\nShiny: Square";
                        zh = zh.Replace("方闪", "");
                    }
                    else if (zh.Contains("星闪"))
                    {
                        result += "\nShiny: Star";
                        zh = zh.Replace("星闪", "");
                    }
                    if (zh.Contains("头目"))
                    {
                        result += "\nAlpha: Yes";
                        zh = zh.Replace("头目", "");
                    }
                    if (zh.Contains("极巨化"))
                    {
                        result += "\nGigantamax: Yes";
                        zh = zh.Replace("极巨化", "");
                    }
                    if (zh.Contains("满亲密度"))
                    {
                        result += "\nHappiness: 255";
                        zh = zh.Replace("满亲密度", "");
                    }
                    for (int i = 0; i < GameStrings.Natures.Count; i++)
                    {
                        if (zh.Contains(GameStrings.Natures[i]))
                        {
                            result += $"\n{GameStringsEn.Natures[i]} Nature";
                            zh = zh.Replace(GameStrings.Natures[i], "");
                            break;
                        }
                    }
                    for (int i = 0; i < GameStrings.abilitylist.Length; i++)
                    {
                        if (GameStrings.abilitylist[i].Length == 0) continue;
                        if (!zh.Contains(GameStrings.abilitylist[i] + "特性")) continue;
                        var AbilityStr = GameStringsEn.abilitylist[i];
                        result += $"\nAbility: {AbilityStr}";
                        zh = zh.Replace(GameStrings.abilitylist[i] + "特性", "");
                        break;
                    }
                    for (int i = 0; i < GameStrings.balllist.Length; i++)
                    {
                        if (GameStrings.balllist[i].Length == 0) continue;
                        if (!zh.Contains(GameStrings.balllist[i])) continue;
                        var ballStr = GameStringsEn.balllist[i];
                        if (typeof(T) == typeof(PA8) && ballStr is "Poké Ball" or "Great Ball" or "Ultra Ball") ballStr = "LA" + ballStr;
                        result += $"\nBall: {ballStr}";
                        zh = zh.Replace(GameStrings.balllist[i], "");
                        break;
                    }
                    if (zh.Contains("6v"))
                    {
                        result += "\nIVs: 31 HP / 31 Atk / 31 Def / 31 SpA / 31 SpD / 31 Spe";
                        zh = zh.Replace("6v", "");
                    }
                    else if (zh.Contains("4v0a0s"))
                    {
                        result += "\nIVs: 31 HP / 0 Atk / 31 Def / 31 SpA / 31 SpD / 0 Spe";
                        zh = zh.Replace("4v0a0s", "");
                    }
                    else if (zh.Contains("5v0a"))
                    {
                        result += "\nIVs: 31 HP / 0 Atk / 31 Def / 31 SpA / 31 SpD / 31 Spe";
                        zh = zh.Replace("5v0a", "");
                    }
                    else if (zh.Contains("5v0s"))
                    {
                        result += "\nIVs: 31 HP / 31 Atk / 31 Def / 31 SpA / 31 SpD / 0 Spe";
                        zh = zh.Replace("5v0s", "");
                    }
                    else if (split != null)
                    {
                        if (split.Length == 2)
                        {
                            if (split[1].StartsWith("个体") && (Encoding.Default.GetByteCount(split[1]) > 6))
                            {
                                result += "\nIVs: ";
                                split[1] = split[1].Replace("个体", "");
                                result += IVEV(split[1]);
                            }

                            else if (split[1].StartsWith("努力") && (Encoding.Default.GetByteCount(split[1]) > 6))
                            {
                                result += "\nEVs: ";
                                split[1] = split[1].Replace("努力", "");
                                result += IVEV(split[1]);
                            }
                            else
                            {
                                result = "你写错了";
                            }
                        }
                        else if (split.Length == 3)
                        {
                            if (split[1].StartsWith("个体") && (Encoding.Default.GetByteCount(split[1]) > 6))
                            {
                                result += "\nIVs: ";
                                split[1] = split[1].Replace("个体", "");
                                result += IVEV(split[1]);

                            }

                            else if (split[1].StartsWith("努力") && (Encoding.Default.GetByteCount(split[1]) > 6))
                            {
                                result += "\nEVs: ";
                                split[1] = split[1].Replace("努力", "");
                                result += IVEV(split[1]);

                            }

                            if (split[2].StartsWith("个体") && (Encoding.Default.GetByteCount(split[2]) > 6))
                            {
                                result += "\nIVs: ";
                                split[2] = split[2].Replace("个体", "");
                                result += IVEV(split[2]);

                            }

                            else if (split[2].StartsWith("努力") && (Encoding.Default.GetByteCount(split[2]) > 6))
                            {
                                result += "\nEVs: ";
                                split[2] = split[2].Replace("努力", "");
                                result += IVEV(split[2]);

                            }
                            if (!(split[1].StartsWith("努力") || split[1].StartsWith("个体")) &&
                               (split[2].StartsWith("努力") || split[2].StartsWith("个体")))
                            {
                                result = "你写错了";
                            }
                            else if ((Encoding.Default.GetByteCount(split[1]) <= 6) || (Encoding.Default.GetByteCount(split[2]) <= 6))
                            {
                                result = "你写错了";
                            }
                        }
                    }

                    if (move != null)
                    {
                        int n = move.Length;
                        for (int i = 1; i < n; i++)
                        {
                            for (int j = 0; j < GameStrings.movelist.Length; j++)
                            {
                                if (GameStrings.movelist[j].Length == 0) continue;
                                if (!move[i].Contains(GameStrings.movelist[j])) continue;
                                var MoveStr = GameStringsEn.movelist[j];
                                result += $"\n-{MoveStr}";
                                move[i] = move[i].Replace(GameStrings.movelist[j], "");
                                break;
                            }
                        }
                    }
                    return result;
                }
            }
            static string IVEV(string split)
            {
                string result = "";
                if (Regex.IsMatch(split, "\\d{1,3}血量"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})血量").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} HP / ";
                    split = Regex.Replace(split, "\\d{1,3}血量", "");
                }
                if (Regex.IsMatch(split, "\\d{1,3}物攻"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})物攻").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} Atk / ";
                    split = Regex.Replace(split, "\\d{1,3}物攻", "");
                }
                if (Regex.IsMatch(split, "\\d{1,3}攻击"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})攻击").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} Atk /";
                    split = Regex.Replace(split, "\\d{1,3}攻击", "");
                }
                if (Regex.IsMatch(split, "\\d{1,3}物防"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})物防").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} Def / ";
                    split = Regex.Replace(split, "\\d{1,3}物防", "");
                }
                if (Regex.IsMatch(split, "\\d{1,3}特攻"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})特攻").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} SpA / ";
                    split = Regex.Replace(split, "\\d{1,3}特攻", "");
                }
                if (Regex.IsMatch(split, "\\d{1,3}特防"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})特防").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} SpD / ";
                    split = Regex.Replace(split, "\\d{1,3}特防", "");
                }
                if (Regex.IsMatch(split, "\\d{1,3}速度"))
                {
                    string EVhp = Regex.Match(split, "(\\d{1,3})速度").Groups?[1]?.Value ?? "0";
                    result += $"{EVhp} Spe ";
                    split = Regex.Replace(split, "\\d{1,3}速度", "");
                }
                result = result.TrimEnd('/');
                return result;
            }

        }
    }

