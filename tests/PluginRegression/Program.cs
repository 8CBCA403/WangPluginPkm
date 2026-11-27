using System.Reflection;
using System.Text.RegularExpressions;
using PKHeX.Core;
using WangPluginPkm;
using WangPluginPkm.GUI;
using WangPluginPkm.Plugins;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetColorMode(args.Length == 0 || args.Contains("--dark") ? SystemColorMode.Dark : SystemColorMode.Classic);
        Control.CheckForIllegalCrossThreadCalls = true;
        GameInfo.CurrentLanguage = args.Contains("--zh") ? "zh-Hans" : "en";

        if (args.Length == 0 || args.Contains("--preview"))
        {
            var type = typeof(PluginForm).Assembly.GetType("WangPluginPkm.GUI.AboutandSettingUI")!;
            using var preview = (Form)Activator.CreateInstance(type, nonPublic: true)!;
            Application.Run(preview);
            return;
        }

        Assert(PluginLocalization.Translate("闪光器/Shiny Maker") ==
            (args.Contains("--zh") ? "闪光器" : "Shiny Maker"), "Bilingual menu selection");
        Assert(PluginLocalization.Translate("多功能计算器/Muti Calculator") ==
            (args.Contains("--zh") ? "多功能计算器" : "Multi Calculator"), "Legacy English menu spelling normalized");
        Assert(PluginLocalization.Translate("开始查找") ==
            (args.Contains("--zh") ? "开始查找" : "Start Search"), "Localized control text");
        Assert(PluginLocalization.Translate("正在检测PID/EC/IV") ==
            (args.Contains("--zh") ? "正在检测PID/EC/IV" : "Checking PID / EC / IVs"), "Technical slashes are preserved");
        using (var localizedRoot = new Panel())
        {
            var label = new Label { Text = "保存设置" };
            var input = new TextBox { Text = "用户输入" };
            localizedRoot.Controls.Add(label);
            localizedRoot.Controls.Add(input);
            PluginLocalization.Apply(localizedRoot);
            Assert(label.Text == (args.Contains("--zh") ? "保存设置" : "Save Settings"), "Control tree localization");
            Assert(input.Text == "用户输入", "User input is not translated");
        }
        if (!args.Contains("--zh"))
        {
            var gui = Path.GetFullPath("../../../../../WangPluginPkm/GUI", AppContext.BaseDirectory);
            var untranslated = Directory.EnumerateFiles(gui, "*.Designer.cs")
                .SelectMany(File.ReadLines)
                .Select(line => Regex.Unescape(Regex.Match(line, "\\.Text = \\\"([^\\\"]*)\\\"").Groups[1].Value))
                .Where(text => Regex.IsMatch(text, @"\p{IsCJKUnifiedIdeographs}") && PluginLocalization.Translate(text) == text)
                .Distinct().Order().ToArray();
            Assert(untranslated.Length == 0, $"Designer localization coverage: {string.Join(" | ", untranslated)}");
        }

        foreach (var (save, entity) in new (SaveFile, PKM)[]
        {
            (new SAV8SWSH(), new PK8()),
            (new SAV8BS(), new PB8()),
            (new SAV8LA(), new PA8()),
        })
        {
            entity.Species = 25;
            entity.StatAlignment = Nature.Adamant;
            var provider = Stub.Create<ISaveFileProvider>("get_SAV", () => save);
            var editor = Stub.Create<IPKMView>("get_Data", () => entity);
            using var database = new SuperDataBase(provider, editor);
            database.BindingContext = new BindingContext();
            foreach (string prefix in new[] { "MOV", "REM" })
            {
                var boxes = Enumerable.Range(1, 4)
                    .Select(i => (ComboBox)database.Controls.Find($"{prefix}{i}_CB", true).Single()).ToArray();
                for (int i = 0; i < boxes.Length; i++)
                    boxes[i].SelectedIndex = i + 10;
                Assert(boxes.Select(b => b.SelectedIndex).SequenceEqual(new[] { 10, 11, 12, 13 }),
                    $"Independent {prefix} selection for {entity.GetType().Name}");
            }
            var converted = database.convertpktolpk(entity);
            Assert(converted.StatAlignment == (int)Nature.Adamant,
                $"Stat alignment conversion for {entity.GetType().Name}");
        }

        CheckSaveFeatures();
        CheckDatabaseOverwrite();

        using var theme = new ThemeProbe();
        theme.TestLoad();
        bool dark = args.Contains("--dark");
        Assert((theme.Page.BackColor.GetBrightness() < 0.3) == dark, "Tab background follows host theme");
        Assert(theme.Indicator.BackColor == Color.Green, "Semantic indicator color preserved");
        if (dark)
        {
            Assert(theme.Input.ForeColor.GetBrightness() > 0.8, "Readable input text");
            var dynamicInput = new TextBox();
            theme.Page.Controls.Add(dynamicInput);
            Assert(dynamicInput.BackColor.GetBrightness() < 0.3, "Dynamically added controls themed");
        }
        Console.WriteLine("All regression checks passed.");
    }

    private static void CheckSaveFeatures()
    {
        var save = BlankSaveFile.Get(GameVersion.GP, "Test");
        var provider = Stub.Create<ISaveFileProvider>("get_SAV", () => save);
        var eevee = new PK8 { Species = (ushort)Species.Eevee, Version = GameVersion.SW, Language = 2, Ball = 4 };
        var editor = Stub.Create<IPKMView>("get_Data", () => eevee);
        using var menu = new MenuStrip();
        menu.Items.Add(new ToolStripMenuItem("Tools") { Name = "Menu_Tools" });
        var sort = new SortPlugin();
        sort.Initialize(provider, editor, menu);
        var sortEntry = (ToolStripMenuItem)menu.Items.Find(sort.Name, true).Single();
        Assert(sortEntry.DropDownItems.Count == 1, "Let's Go exposes its Kanto sort");

        save = BlankSaveFile.Get(GameVersion.SW, "Test");
        sort.NotifySaveLoaded();
        var galar = sortEntry.DropDownItems.Cast<ToolStripMenuItem>().Single(item =>
            item.Text == PluginLocalization.Translate("伽勒尔图鉴（本篇）/Galar (Base Game)"));
        save.SetBoxSlotAtIndex(new PK8 { Species = (ushort)Species.Pikachu, Version = GameVersion.SW }, 0);
        save.SetBoxSlotAtIndex(new PK8 { Species = (ushort)Species.Grookey, Version = GameVersion.SW }, 1);
        galar.PerformClick();
        Assert(save.GetBoxSlotAtIndex(0).Species == (ushort)Species.Grookey &&
               save.GetBoxSlotAtIndex(1).Species == (ushort)Species.Pikachu, "Galar sort follows the loaded save");

        save.ID32 = 2_123_456;
        var eggFormType = typeof(PluginForm).Assembly.GetType("WangPluginPkm.GUI.EggGeneratorUI")!;
        using var eggForm = (Form)Activator.CreateInstance(eggFormType, provider, editor)!;
        var egg = (PKM)eggFormType.GetMethod("Egg")!.Invoke(eggForm, [eevee, provider])!;
        Assert(egg.IsEgg && egg.Species == (ushort)Species.Eevee && egg.ID32 == save.ID32,
            "Generated egg preserves the full trainer ID");
    }

    private static void Assert(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
        Console.WriteLine($"PASS: {message}");
    }

    private static void CheckDatabaseOverwrite()
    {
        foreach (var version in new[] { GameVersion.SW, GameVersion.BD, GameVersion.PLA })
        {
            var save = BlankSaveFile.Get(version, "Test");
            var entity = save.BlankPKM;
            entity.Species = (ushort)Species.Pikachu;
            entity.CurrentLevel = 8;
            save.SetBoxSlotAtIndex(entity, 0, 0);
            save.SetBoxSlotAtIndex(entity, 0, 1);
            var provider = Stub.Create<ISaveFileProvider>("get_SAV", () => save);
            var editor = Stub.Create<IPKMView>("get_Data", () => entity);
            using var database = new SuperDataBase(provider, editor);
            int count = database.ModifyBoxes(pk => pk.CurrentLevel = 42, save.Generation, 0, 1, 0, 2);
            Assert(count == 1 && save.GetBoxSlotAtIndex(0, 0).CurrentLevel == 8 &&
                   save.GetBoxSlotAtIndex(0, 1).CurrentLevel == 42 && save.GetBoxSlotAtIndex(0, 2).Species == 0,
                $"Database overwrites only selected occupied slots in {version}");
        }
    }
}

public class Stub : DispatchProxy
{
    private string getter;
    private Func<object> value;
    public static T Create<T>(string getter, Func<object> value) where T : class
    {
        var result = Create<T, Stub>();
        var stub = (Stub)(object)result;
        stub.getter = getter;
        stub.value = value;
        return result;
    }
    protected override object Invoke(MethodInfo method, object[] args) => method.Name == getter
        ? value() : method.ReturnType == typeof(void) ? null
        : method.ReturnType.IsValueType ? Activator.CreateInstance(method.ReturnType) : null;
}

internal sealed class ThemeProbe : PluginForm
{
    public TabPage Page = new() { BackColor = Color.WhiteSmoke };
    public TextBox Input = new();
    public Label Indicator = new() { BackColor = Color.Green };
    public ThemeProbe()
    {
        var tabs = new TabControl();
        tabs.TabPages.Add(Page);
        Controls.Add(tabs);
        Page.Controls.Add(Input);
        Page.Controls.Add(Indicator);
    }
    public void TestLoad() => OnLoad(EventArgs.Empty);
}
