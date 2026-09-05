using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WangPluginPkm
{
    /// <summary>Localizes plugin UI using the language selected by PKHeX.</summary>
    public static class PluginLocalization
    {
        public static string Language => GameInfo.CurrentLanguage;
        public static bool IsChinese => Language.StartsWith("zh", StringComparison.OrdinalIgnoreCase);

        private static readonly IReadOnlyDictionary<string, string> English =
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["超王插件PKM"] = "Wang PKM Plugin",
                ["超王插件"] = "Wang PKM Plugin",
                ["关于和设置"] = "About and Settings",
                ["对战王"] = "Battle Tools",
                ["图鉴制作器"] = "Dex Builder",
                ["派送器"] = "Distribution Tools",
                ["变蛋器"] = "Egg Generator",
                ["额外文件编辑器"] = "Extra File Editor",
                ["多功能计算器"] = "Multi Calculator",
                ["RNG面板"] = "RNG Tools",
                ["闪光器"] = "Shiny Maker",
                ["超级数据库"] = "Super Database",
                ["常用功能"] = "Common Tools",
                ["设置"] = "Settings",
                ["关于"] = "About",
                ["超王插件 · 设置与关于"] = "Wang PKM Plugin · Settings and About",
                ["播放启动声音"] = "Play startup sound",
                ["是否播放启动声音"] = "Play startup sound",
                ["界面颜色跟随 PKHeX 的深色／浅色模式。"] = "Colors follow PKHeX's dark or light theme.",
                ["保存设置"] = "Save Settings",
                ["Google 应用名称"] = "Google Application Name",
                ["宝可梦图片地址前缀"] = "Pokémon Image URL Prefix",
                ["插键设置"] = "Plugin Settings",
                ["使用说明"] = "Help",
                ["RNG面板使用说明\r\n1.本工具查找功能对象为PKHeX左侧面板精灵，使用前先将需要查找的精灵拖拽至左侧面板\r\n2.请使用本世代存档进行操作（如：现需要查找Method1类型Gen3小火龙则需要打开火红/叶绿存档进行操作，而不应打开如日月存档跨世代操作，可能出现卡死）\r\n3.如需特殊IV请使用预制种子，详情见下表。\r\n4.XDColo队锁只限于XDColo部分精灵,详情见下表"] = "RNG Tools Help\r\n1. Drag the Pokémon to search into PKHeX's editor panel before starting.\r\n2. Use a save from the same generation as the target Pokémon to avoid invalid or excessively long searches.\r\n3. Use preset seeds when specific IV spreads are required; see the table below.\r\n4. XD/Colosseum team locks apply only to supported encounters; see the table below.",
                ["常规查找"] = "Standard Search",
                ["终极解决方案"] = "Advanced Search",
                ["RNG类型"] = "RNG Method",
                ["闪光种类"] = "Shiny Type",
                ["状态"] = "Status",
                ["最小值"] = "Minimum",
                ["最大值"] = "Maximum",
                ["血量"] = "HP",
                ["物攻"] = "Attack",
                ["物防"] = "Defense",
                ["特攻"] = "Sp. Atk",
                ["特防"] = "Sp. Def",
                ["速度"] = "Speed",
                ["使用预设种子"] = "Use Preset Seed",
                ["严格帧合法检测"] = "Strict Frame Legality",
                ["从指定Seed开始"] = "Start from Specified Seed",
                ["极速模式"] = "Fast Mode",
                ["遍历模式"] = "Traversal Mode",
                ["开始查找"] = "Start Search",
                ["开始速配"] = "Start Quick Build",
                ["停止查找"] = "Stop Search",
                ["检测"] = "Checks",
                ["CXD使用队锁"] = "Use CXD Team Lock",
                ["Seed逆推"] = "Seed Reversal",
                ["剑盾Raid检测"] = "Sword/Shield Raid Check",
                ["朱紫太晶坑检测"] = "Scarlet/Violet Tera Raid Check",
                ["模式选择"] = "Method",
                ["使用PID反推"] = "Reverse from PID",
                ["使用IV反推"] = "Reverse from IVs",
                ["Seed计算IV"] = "Calculate IVs from Seed",
                ["慢速检测"] = "Thorough Check",
                ["快速检测(依赖Z3)"] = "Fast Check (requires Z3)",
                ["修正大冒险seed"] = "Fix Adventure Seed",
                ["修正PID"] = "Fix PID",
                ["锁IV"] = "Lock IVs",
                ["没有seed"] = "No Seed",
                ["直接无限roll相遇库直到找到！"] = "Keep rolling the encounter database until found",
                ["相遇库里的序号"] = "Encounter Database Index",
                ["常用派送"] = "Common Distribution",
                ["速配器"] = "Quick Builder",
                ["速配过滤器"] = "Quick Builder Filters",
                ["速配努力值"] = "Recommend EVs",
                ["速配推荐努力值完成！"] = "EV recommendations completed.",
                ["当前箱子刷新完毕！"] = "Current box refreshed.",
                ["速配完成！"] = "Quick build completed.",
                ["目前只支持剑盾！"] = "Only Sword and Shield are currently supported.",
                ["生成蛋"] = "Generate Egg",
                ["保持地区形态"] = "Keep Regional Form",
                ["保持性别"] = "Keep Gender",
                ["保持特性"] = "Keep Ability",
                ["保持技能回忆"] = "Keep Relearn Moves",
                ["随机孵蛋日"] = "Random Hatch Date",
                ["随机相遇日"] = "Random Encounter Date",
                ["闪光"] = "Shiny",
                ["相遇时间"] = "Encounter Date",
                ["开始日期"] = "Start Date",
                ["结束日期"] = "End Date",
                ["生成"] = "Generate",
                ["制作"] = "Build",
                ["生成全图鉴"] = "Build Full Dex",
                ["生成逼真图鉴"] = "Build Realistic Dex",
                ["生成形态"] = "Generate Forms",
                ["补齐图鉴"] = "Complete Dex",
                ["一箱神兽"] = "Legendary Box",
                ["一键闪光"] = "Make All Shiny",
                ["一键大个子"] = "Make All Jumbo",
                ["一键小不点"] = "Make All Teensy",
                ["开始排序"] = "Start Sorting",
                ["删除箱子"] = "Clear Box",
                ["图鉴制作器"] = "Dex Builder",
                ["Home成就制作器"] = "HOME Achievement Builder",
                ["统计"] = "Statistics",
                ["杂项编辑"] = "Miscellaneous Editor",
                ["训练师卡片"] = "Trainer Card",
                ["ID编辑器"] = "ID Editor",
                ["ID检索器"] = "ID Search",
                ["检查ID"] = "Check ID",
                ["开始覆盖ID"] = "Apply ID",
                ["Home查分器"] = "HOME Score Checker",
                ["分数"] = "Score",
                ["个体"] = "IVs",
                ["努力值"] = "EVs",
                ["性格"] = "Nature",
                ["原始性格"] = "Original Nature",
                ["薄荷性格"] = "Mint Nature",
                ["特性"] = "Ability",
                ["特性序号"] = "Ability Slot",
                ["持有物"] = "Held Item",
                ["球种"] = "Ball",
                ["语言"] = "Language",
                ["语言/性别"] = "Language / Gender",
                ["性别"] = "Gender",
                ["公母"] = "Gender",
                ["公母比"] = "Gender Ratio",
                ["形态"] = "Form",
                ["昵称"] = "Nickname",
                ["初训家"] = "Original Trainer",
                ["初训家名字"] = "Original Trainer Name",
                ["名字"] = "Name",
                ["招式"] = "Moves",
                ["全部技能"] = "All Moves",
                ["技能1"] = "Move 1",
                ["技能2"] = "Move 2",
                ["回忆招式"] = "Relearn Moves",
                ["钛晶属性"] = "Tera Type",
                ["当前等级"] = "Current Level",
                ["等级最大"] = "Maximum Level",
                ["随机PID"] = "Random PID",
                ["随机EC"] = "Random EC",
                ["随机SID16闪光"] = "Random Shiny SID16",
                ["强制方块"] = "Force Square Shiny",
                ["强制星星"] = "Force Star Shiny",
                ["指定Xor闪光"] = "Specified XOR Shiny",
                ["Xor闪光PID计算"] = "Shiny PID from XOR",
                ["XOR值"] = "XOR Value",
                ["保存"] = "Save",
                ["导入"] = "Import",
                ["导出PS"] = "Export Showdown",
                ["导入GP1"] = "Import GP1",
                ["导出GP1"] = "Export GP1",
                ["读取EH1"] = "Read EH1",
                ["EH1查看器"] = "EH1 Viewer",
                ["从文件导入smogon策略"] = "Import Smogon Sets from File",
                ["从Showdown批量导入"] = "Batch Import from Showdown",
                ["从网址批量导入"] = "Batch Import from URLs",
                ["<-从PS导入模板"] = "<- Import Template from Showdown",
                ["保存模板->"] = "Save Template ->",
                ["导入模板"] = "Import Template",
                ["导出模板"] = "Export Template",
                ["导入面板"] = "Import Editor",
                ["读面板"] = "Read Editor",
                ["编辑面板"] = "Edit Editor",
                ["复制器（复制面板）"] = "Cloner (Copy Editor)",
                ["开始复制"] = "Start Cloning",
                ["编辑当前箱子"] = "Edit Current Box",
                ["开始覆写"] = "Start Overwrite",
                ["开始转换"] = "Start Conversion",
                ["覆盖三维"] = "Apply IVs/EVs/Nature",
                ["覆写条件"] = "Overwrite Fields",
                ["过滤"] = "Filter",
                ["过滤条件"] = "Filter Fields",
                ["复原过滤"] = "Restore Filter",
                ["搜索"] = "Search",
                ["查找"] = "Find",
                ["种类"] = "Species",
                ["文件名"] = "File Name",
                ["箱子"] = "Box",
                ["槽位"] = "Slot",
                ["开始箱子"] = "Start Box",
                ["结束箱子"] = "End Box",
                ["开始槽位"] = "Start Slot",
                ["结束槽位"] = "End Slot",
                ["全选"] = "Select All",
                ["反选"] = "Invert Selection",
                ["删除全部"] = "Delete Selected",
                ["修改"] = "Edit",
                ["转换"] = "Convert",
                ["全段带"] = "All Ribbons",
                ["合法化全部"] = "Legalize All",
                ["合法化箱子"] = "Legalize Box",
                ["删除垃圾字节"] = "Clear Trash Bytes",
                ["插空"] = "Insert Empty Slot",
                ["在此处插空"] = "Insert Empty Slot Here",
                ["物攻手"] = "Physical Attacker",
                ["特攻手"] = "Special Attacker",
                ["物攻0速"] = "Physical Attacker (0 Spe)",
                ["特攻0速"] = "Special Attacker (0 Spe)",
                ["坦克"] = "Defensive",
                ["快捷三维编辑器"] = "Quick IV / EV / Nature Editor",
                ["打印检测报告PDF"] = "Export Legality Report as PDF",
                ["清除昵称垃圾字节"] = "Clear Nickname Trash Bytes",
                ["把id由PKHeX改成存档id(仅适用于SV)"] = "Replace PKHeX ID with Save ID (SV only)",
                ["将现有WC9写入PKL"] = "Add Current WC9 to PKL",
                ["地理位置"] = "Location",
                ["身高:"] = "Height:",
                ["体重:"] = "Weight:",
                ["大小:"] = "Scale:",
                ["个体:"] = "IVs:",
                ["性格:"] = "Nature:",
                ["导入训练家"] = "Import Trainer",
                ["指定训练家"] = "Use Specified Trainer",
                ["应用训练家"] = "Apply Trainer",
                ["随机训练家"] = "Random Trainer",
                ["随机训练家名字"] = "Random Trainer Name",
                ["新配置"] = "New Profile",
                ["删除配置"] = "Delete Profile",
                ["训练家"] = "Trainer",
                ["阿罗拉形态"] = "Alolan Form",
                ["土龙一家鼠"] = "Dudunsparce / Maushold",
                ["转为PB7"] = "Convert to PB7",
                ["特殊计算"] = "Special Calculations",
                ["通用计算器"] = "General Calculator",
                ["计算"] = "Calculate",
                ["10进制转16进制"] = "Decimal to Hex",
                ["16进制转10进制"] = "Hex to Decimal",
                ["5位ID转7位ID"] = "5-digit ID to 7-digit ID",
                ["7位ID转5位ID"] = "7-digit ID to 5-digit ID",
                ["Gen3未知图腾形态"] = "Gen 3 Unown Form",
                ["通过PID算性格"] = "Calculate Nature from PID",
                ["PS指令模式"] = "Showdown Text Mode",
                ["中文指令"] = "Chinese Input",
                ["网址模式"] = "URL Mode",
                ["策略爬取"] = "Strategy Import",
                ["神偷-VGCPaste"] = "VGC Paste Import",
                ["神偷-阵列兵"] = "Falinks Import",
                ["启动VGCPastes"] = "Load VGC Pastes",
                ["同步网页信息"] = "Sync Web Data",
                ["同步表格信息"] = "Sync Sheet Data",
                ["VGC队伍检测"] = "VGC Team Check",
                ["请将有6只精灵的bin文件拖入下方"] = "Drop a BIN file containing six Pokémon below",
                ["开偷！"] = "Import",
                ["开始！"] = "Start",
                ["清屏"] = "Clear",
                ["清除全部盒子"] = "Clear All Boxes",
                ["获取排名"] = "Get Ranking",
                ["获取赛季信息"] = "Get Season Info",
                ["赛季信息"] = "Season Information",
                ["赛季名称"] = "Season Name",
                ["排名"] = "Rank",
                ["表"] = "Sheet",
                ["表ID"] = "Sheet ID",
                ["里"] = "League",
                ["里ID"] = "League ID",
                ["停止"] = "Stop",
                ["关闭"] = "Close",
                ["无事可做"] = "Idle",
                ["刷新当前箱子"] = "Refresh Current Box",
                ["RNG Form"] = "RNG Tools",
                ["Super DataBase"] = "Super Database",
                ["BattleKing"] = "Battle Tools",
                ["ExtraFileEditor"] = "Extra File Editor",
                ["Muti Calculator"] = "Multi Calculator",
                ["About and Setting"] = "About and Settings",
                ["提示"] = "Notice",
                ["搜索结果"] = "Search Results",
                ["设置已保存。"] = "Settings saved.",
                ["搞定了！"] = "Completed.",
                ["搞定啦"] = "Completed.",
                ["排序完成"] = "Sorting completed.",
                ["版本不对！"] = "This feature is not available for the current game version.",
                ["本功能只适用于究极日月！"] = "This feature is only available for Ultra Sun and Ultra Moon.",
                ["版本不对！请使用晶灿钻石或明亮珍珠版本"] = "Please use a Brilliant Diamond or Shining Pearl save.",
                ["太棒啦全对！"] = "All checks passed.",
                ["目前VGC版本为朱紫！"] = "The current VGC format is Scarlet and Violet.",
                ["队伍不足6只，无法检测！"] = "A team must contain six Pokémon.",
                ["导入了网页！"] = "Web data imported.",
                ["CID 不能为空！"] = "CID is required.",
                ["RST 不能为空！"] = "RST is required.",
                ["TS1 不能为空！"] = "TS1 is required.",
                ["请输入图像的URL"] = "Enter an image URL.",
                ["请输入搜索关键词！"] = "Enter a search term.",
                ["未找到匹配的项！"] = "No matching item was found.",
                ["无法解析所选文件，请检查文件内容是否正确！"] = "The selected file could not be parsed. Check its contents.",
                ["不支持的文件类型！"] = "Unsupported file type.",
                ["所选文件为空或无法读取，请确认文件是否损坏！"] = "The selected file is empty or unreadable. Check whether it is damaged.",
                ["无法访问文件，请确保你有足够的权限读取该文件。"] = "The file cannot be accessed. Check your read permissions.",
                ["遍历完成或已取消"] = "Traversal completed or canceled.",
                ["没有匹配！"] = "No match found.",
                ["已生成合法检测报告"] = "Legality report created.",
                ["没有空间！"] = "There is no available space.",
                ["请确保本身全部精灵合法！\n不是100%准确，使用前请备份存档！"] = "Make sure all Pokémon are legal. Results are not guaranteed; back up the save before continuing.",
                ["该存档版本不支持变蛋器功能。"] = "The Egg Generator does not support this save version.",
                ["只适用于阿尔宙斯！"] = "This feature is only available for Pokémon Legends: Arceus.",
                ["当前编辑器没有宝可梦数据"] = "The editor does not contain Pokémon data.",
                ["导入了面板！"] = "Editor data imported.",
                ["导出了文件！"] = "File exported.",
                ["导入了文件！"] = "File imported.",
                ["您未选择文件"] = "No file was selected.",
                ["列表里没有文件"] = "The list contains no files.",
                ["覆写完成！"] = "Overwrite completed.",
                ["修改完成！"] = "Changes applied.",
                ["没有可复原列表！"] = "There is no list to restore.",
                ["本作无法获得！"] = "This Pokémon cannot be obtained in the current game.",
                ["正在查找..."] = "Searching...",
                ["正在检测基本合法性"] = "Checking basic legality",
                ["正在反推Seed"] = "Reversing seed",
                ["正在检测PID/EC/IV"] = "Checking PID / EC / IVs",
                ["正在检测特性，性别"] = "Checking ability and gender",
                ["正在检测身高体重"] = "Checking height and weight",
                ["合法性检测通过！"] = "Legality check passed.",
                ["逆推失败!没找到Seed"] = "Seed reversal failed: no seed found.",
                ["无法检测PID/EC/IV"] = "PID / EC / IVs could not be checked.",
                ["无法检测性格性别"] = "Nature and gender could not be checked.",
                ["无法检测身高体重"] = "Height and weight could not be checked.",
                ["逆推成功!"] = "Seed reversal succeeded.",
                ["基本合法性检测通过！"] = "Basic legality check passed.",
                ["无需寻找Seed"] = "No seed search required.",
                ["无需检测PID/EC/IV"] = "No PID / EC / IV check required.",
                ["无需检测性格性别"] = "No nature or gender check required.",
                ["无需检测身高体重"] = "No height or weight check required.",
                ["基本合法性检测未通过！"] = "Basic legality check failed.",
            };

        public static string Translate(string text)
        {
            if (string.IsNullOrEmpty(text) || IsChinese)
                return SelectBilingual(text, chinese: true);
            var bilingual = SelectBilingual(text, chinese: false);
            if (English.TryGetValue(bilingual, out var translated))
                return translated;
            return bilingual.EndsWith(" 分钟", StringComparison.Ordinal) &&
                   int.TryParse(bilingual[..^3], out var minutes)
                ? $"{minutes} min"
                : bilingual;
        }

        private static string SelectBilingual(string text, bool chinese)
        {
            int slash = text.IndexOf('/');
            if (slash <= 0 || slash == text.Length - 1 || text.Contains("://", StringComparison.Ordinal))
                return text;
            var left = text[..slash].Trim();
            var right = text[(slash + 1)..].Trim();
            bool hasChineseLeft = false;
            foreach (char value in left)
                hasChineseLeft |= value is >= '\u3400' and <= '\u9fff';
            bool looksLikeBilingualMenu = hasChineseLeft &&
                (right.Contains(' ') || right is "BattleKing" or "ExtraFileEditor" or "Sort");
            return looksLikeBilingualMenu ? (chinese ? left : right) : text;
        }

        public static void Apply(Control root)
        {
            TranslateControl(root);
            root.ControlAdded -= OnControlAdded;
            root.ControlAdded += OnControlAdded;
        }

        private static void TranslateControl(Control control)
        {
            bool localizableText = control is not TextBoxBase && control is not ComboBox && control is not ListControl;
            if (localizableText)
            {
                control.Text = Translate(control.Text);
                control.TextChanged -= OnTextChanged;
                control.TextChanged += OnTextChanged;
            }
            if (control.ContextMenuStrip is { } context)
                Apply(context.Items);
            if (control is ToolStrip strip)
                Apply(strip.Items);
            foreach (Control child in control.Controls)
                TranslateControl(child);
            control.ControlAdded -= OnControlAdded;
            control.ControlAdded += OnControlAdded;
        }

        private static void OnControlAdded(object sender, ControlEventArgs e) => TranslateControl(e.Control);

        private static void OnTextChanged(object sender, EventArgs e)
        {
            if (sender is not Control control)
                return;
            var translated = Translate(control.Text);
            if (translated != control.Text)
                control.Text = translated;
        }

        public static void Apply(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                item.Text = Translate(item.Text);
                if (item is ToolStripDropDownItem dropdown)
                    Apply(dropdown.DropDownItems);
            }
        }
    }
}
