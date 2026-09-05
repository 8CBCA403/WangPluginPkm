using System.Reflection;
using PKHeX.Core;
using WangPluginPkm.GUI;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetColorMode(args.Length == 0 || args.Contains("--dark") ? SystemColorMode.Dark : SystemColorMode.Classic);
        Control.CheckForIllegalCrossThreadCalls = true;

        if (args.Length == 0 || args.Contains("--preview"))
        {
            var type = typeof(PluginForm).Assembly.GetType("WangPluginPkm.GUI.AboutandSettingUI")!;
            using var preview = (Form)Activator.CreateInstance(type, nonPublic: true)!;
            Application.Run(preview);
            return;
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
            var provider = Stub.Create<ISaveFileProvider>("get_SAV", save);
            var editor = Stub.Create<IPKMView>("get_Data", entity);
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

    private static void Assert(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
        Console.WriteLine($"PASS: {message}");
    }
}

public class Stub : DispatchProxy
{
    private string getter;
    private object value;
    public static T Create<T>(string getter, object value) where T : class
    {
        var result = Create<T, Stub>();
        var stub = (Stub)(object)result;
        stub.getter = getter;
        stub.value = value;
        return result;
    }
    protected override object Invoke(MethodInfo method, object[] args) => method.Name == getter
        ? value : method.ReturnType == typeof(void) ? null
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
