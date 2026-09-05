using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WangPluginPkm
{
    internal static class PluginMessageBox
    {
        private static readonly IReadOnlyDictionary<string, string> Prefixes = new Dictionary<string, string>
        {
            ["设置保存失败："] = "Failed to save settings: ",
            ["搞定啦！用时："] = "Completed in ",
            ["已处理"] = "Processed ",
            ["导入失败："] = "Import failed: ",
            ["导出了"] = "Exported ",
            ["经过时间"] = "Elapsed time: ",
            ["读取 Google 表格失败："] = "Failed to read the Google Sheet: ",
            ["读取 Google 表格目录失败："] = "Failed to read the Google Sheet directory: ",
            ["找到匹配项: "] = "Match found: ",
            ["选取了"] = "Selected ",
            ["文件读取出错："] = "File read error: ",
            ["文件格式不正确："] = "Invalid file format: ",
            ["发生未知错误："] = "Unexpected error: ",
            ["预设种子数量:"] = "Preset seed count: ",
            ["生成检测报告失败："] = "Failed to create the legality report: ",
            ["读取或反序列化JSON文件时发生错误: "] = "Failed to read or deserialize the JSON file: ",
            ["出错了！可能是输入了错误的网址，获得正确网址请联系老吴"] = "The URL could not be read. Verify the URL and try again.",
        };

        private static string Localize(string text)
        {
            var exact = PluginLocalization.Translate(text);
            if (PluginLocalization.IsChinese || exact != text)
                return exact;
            foreach (var pair in Prefixes)
            {
                if (text.StartsWith(pair.Key, StringComparison.Ordinal))
                    return pair.Value + TranslateSuffix(text[pair.Key.Length..]);
            }
            if (text.EndsWith("转换完成！", StringComparison.Ordinal))
                return text[..^5] + " conversions completed.";
            return text;
        }

        private static string TranslateSuffix(string value) => value
            .Replace("毫秒", " ms", StringComparison.Ordinal)
            .Replace("秒", " s", StringComparison.Ordinal)
            .Replace("个队伍链接，请以编辑器和盒子中的结果为准。", " team URLs. Check the editor and boxes for results.", StringComparison.Ordinal)
            .Replace("只宝可梦", " Pokémon", StringComparison.Ordinal)
            .Replace("只", " Pokémon", StringComparison.Ordinal)
            .Replace("转换完成！", " conversions completed.", StringComparison.Ordinal);

        public static DialogResult Show(string text) => MessageBox.Show(Localize(text));
        public static DialogResult Show(string text, string caption) => MessageBox.Show(Localize(text), Localize(caption));
        public static DialogResult Show(IWin32Window owner, string text) => MessageBox.Show(owner, Localize(text));
        public static DialogResult Show(IWin32Window owner, string text, string caption) => MessageBox.Show(owner, Localize(text), Localize(caption));
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) =>
            MessageBox.Show(Localize(text), Localize(caption), buttons, icon);
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) =>
            MessageBox.Show(owner, Localize(text), Localize(caption), buttons, icon);
    }
}
