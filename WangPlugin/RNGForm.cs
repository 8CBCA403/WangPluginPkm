using PKHeX.Core;
using PKHeX.Core.AutoMod;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
namespace WangPlugin
{
    internal class RNGForm : Form
    {
        private ComboBox methodTypeBox;
        private Button Search;
        private CancellationTokenSource tokenSource = new();
        private TextBox Condition;
        private Button Cancel;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum MethodType
        {
            None,
            Method1,
            H1_BACD_R,
            Method1Roaming,
            Method2,
            Method4,
            ChainShiny,
            XDColo,
            Colo,
            Overworld8,
            Roaming8b,
        }
        enum ShinyType
        {
            None,
            Shiny,
            Star,
            Sqaure,
            ForceStar,
        }
        private MethodType RNGMethod = MethodType.None;
        private ComboBox ShinyTypeBox;
        private Label ShinyTypeLabel;
        private TextBox SeedText;
        private CheckBox AtkCheck;
        private CheckBox SpeCheck;
        private CheckBox SetRibbon;
        private ShinyType Stype = ShinyType.None;
        public RNGForm(ISaveFileProvider sav, IPKMView editor)

        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGForm));
            this.methodTypeBox = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.Button();
            this.Condition = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.ShinyTypeBox = new System.Windows.Forms.ComboBox();
            this.ShinyTypeLabel = new System.Windows.Forms.Label();
            this.SeedText = new System.Windows.Forms.TextBox();
            this.AtkCheck = new System.Windows.Forms.CheckBox();
            this.SpeCheck = new System.Windows.Forms.CheckBox();
            this.SetRibbon = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // methodTypeBox
            // 
            this.methodTypeBox.FormattingEnabled = true;
            this.methodTypeBox.Location = new System.Drawing.Point(12, 12);
            this.methodTypeBox.Name = "methodTypeBox";
            this.methodTypeBox.Size = new System.Drawing.Size(124, 25);
            this.methodTypeBox.TabIndex = 8;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(156, 101);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(124, 25);
            this.Search.TabIndex = 9;
            this.Search.Text = "RNG Start";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Condition
            // 
            this.Condition.Location = new System.Drawing.Point(156, 12);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(124, 25);
            this.Condition.TabIndex = 10;
            this.Condition.Text = "Nothing to check";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(156, 132);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(124, 25);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Stop";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ShinyTypeBox
            // 
            this.ShinyTypeBox.FormattingEnabled = true;
            this.ShinyTypeBox.Location = new System.Drawing.Point(62, 56);
            this.ShinyTypeBox.Name = "ShinyTypeBox";
            this.ShinyTypeBox.Size = new System.Drawing.Size(74, 25);
            this.ShinyTypeBox.TabIndex = 13;
            // 
            // ShinyTypeLabel
            // 
            this.ShinyTypeLabel.AutoSize = true;
            this.ShinyTypeLabel.Location = new System.Drawing.Point(12, 59);
            this.ShinyTypeLabel.Name = "ShinyTypeLabel";
            this.ShinyTypeLabel.Size = new System.Drawing.Size(44, 17);
            this.ShinyTypeLabel.TabIndex = 14;
            this.ShinyTypeLabel.Text = "Shiny";
            // 
            // SeedText
            // 
            this.SeedText.Location = new System.Drawing.Point(156, 56);
            this.SeedText.Name = "SeedText";
            this.SeedText.Size = new System.Drawing.Size(124, 25);
            this.SeedText.TabIndex = 15;
            this.SeedText.Text = "No Seed";
            // 
            // AtkCheck
            // 
            this.AtkCheck.AutoSize = true;
            this.AtkCheck.Location = new System.Drawing.Point(15, 108);
            this.AtkCheck.Name = "AtkCheck";
            this.AtkCheck.Size = new System.Drawing.Size(58, 21);
            this.AtkCheck.TabIndex = 16;
            this.AtkCheck.Text = "0Atk";
            this.AtkCheck.UseVisualStyleBackColor = true;
            // 
            // SpeCheck
            // 
            this.SpeCheck.AutoSize = true;
            this.SpeCheck.Location = new System.Drawing.Point(15, 135);
            this.SpeCheck.Name = "SpeCheck";
            this.SpeCheck.Size = new System.Drawing.Size(64, 21);
            this.SpeCheck.TabIndex = 17;
            this.SpeCheck.Text = "0Spe";
            this.SpeCheck.UseVisualStyleBackColor = true;
            // 
            // SetRibbon
            // 
            this.SetRibbon.AutoSize = true;
            this.SetRibbon.Location = new System.Drawing.Point(79, 108);
            this.SetRibbon.Name = "SetRibbon";
            this.SetRibbon.Size = new System.Drawing.Size(76, 21);
            this.SetRibbon.TabIndex = 18;
            this.SetRibbon.Text = "Ribbon";
            this.SetRibbon.UseVisualStyleBackColor = true;
            // 
            // RNGForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(292, 177);
            this.Controls.Add(this.SetRibbon);
            this.Controls.Add(this.SpeCheck);
            this.Controls.Add(this.AtkCheck);
            this.Controls.Add(this.SeedText);
            this.Controls.Add(this.ShinyTypeLabel);
            this.Controls.Add(this.ShinyTypeBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Condition);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.methodTypeBox);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RNGForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void BindingData()
        {
            this.methodTypeBox.DataSource = Enum.GetNames(typeof(MethodType));
            this.ShinyTypeBox.DataSource = Enum.GetNames(typeof(ShinyType));
            this.methodTypeBox.SelectedIndexChanged += (_, __) =>
            {
                RNGMethod = (MethodType)Enum.Parse(typeof(MethodType), this.methodTypeBox.SelectedItem.ToString(), false);
            };
            this.methodTypeBox.SelectedIndex = 0;
            this.ShinyTypeBox.SelectedIndexChanged += (_, __) =>
            {
                Stype = (ShinyType)Enum.Parse(typeof(ShinyType), this.ShinyTypeBox.SelectedItem.ToString(), false);
            };
            this.ShinyTypeBox.SelectedIndex = 0;
        }
        private bool[] GetShinyType()
        {
            var shinytype = new bool[5] { false, false, false, false, false };
            switch (Stype)
            {
                case ShinyType.None:
                    shinytype[0] = true;
                    break;
                case ShinyType.Shiny:
                    shinytype[1] = true;
                    break;
                case ShinyType.Star:
                    shinytype[2] = true;
                    break;
                case ShinyType.Sqaure:
                    shinytype[3] = true;
                    break;
                case ShinyType.ForceStar:
                    shinytype[4] = true;
                    break;
            }
            return shinytype;
        }
        private bool[] CheckIV()
        {
            var IV = new bool[2] { false, false};
            if (AtkCheck.Checked)
                IV[0] = true;
            if (SpeCheck.Checked)
                IV[1] = true;
            return IV;
        }
        private bool GenPkm(ref PKM pk,uint seed)
        {
            return RNGMethod switch
            {
                MethodType.None=>NoMethod.GenPkm(ref pk, GetShinyType(), CheckIV()),
                MethodType.Method1 => Method1RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Method2 => Method2RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Method4 => Method4RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.XDColo => XDColoRNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Overworld8 => Overworld8RNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Roaming8b => Roaming8bRNG.GenPkm(ref pk, seed, Editor.Data.TID, Editor.Data.SID, GetShinyType(), CheckIV()),
                MethodType.H1_BACD_R => H1_BACD_R.GenPkm(ref pk, seed & 0xFFFF, Editor.Data.SID, Editor.Data.TID, GetShinyType(), CheckIV()),
                MethodType.Method1Roaming => Method1Roaming.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.Colo => ColoRNG.GenPkm(ref pk, seed, GetShinyType(), CheckIV()),
                MethodType.ChainShiny => ChainShiny.GenPkm(ref pk, seed, CheckIV()),
                _ => throw new NotSupportedException(),
            };
        }
        private uint NextSeed(uint seed)
        {
            return RNGMethod switch
            {
                MethodType.Method1 => Method1RNG.Next(seed),
                MethodType.Method2 => Method2RNG.Next(seed),
                MethodType.Method4 => Method4RNG.Next(seed),
                MethodType.XDColo => XDColoRNG.Next(seed),
                MethodType.Overworld8 => Overworld8RNG.Next(seed),
                MethodType.Roaming8b => Roaming8bRNG.Next(seed),
                MethodType.H1_BACD_R => H1_BACD_R.Next(seed),
                MethodType.Method1Roaming => Method1Roaming.Next(seed),
                MethodType.Colo => ColoRNG.Next(seed),
                MethodType.ChainShiny => ChainShiny.Next(seed),
                _ => throw new NotSupportedException(),
            };
        }
        private void IsRunning(bool running)
        {
            Search.Enabled = !running;
            Cancel.Enabled = running;
        }
        private void Search_Click(object sender, EventArgs e)
        {
            IsRunning(true);
            Condition.Text = "searching...";
            tokenSource = new();
            Task.Factory.StartNew(
                () =>
                {
                    var seed = Util.Rand32();
                    var pk = Editor.Data;
                    while (true)
                    {
                        pk.RefreshAbility((int)(pk.PID & 1));
                        if (tokenSource.IsCancellationRequested)
                        {
                            Condition.Text = "Stop";
                            return;
                        }
                            if (GenPkm(ref pk, seed))
                            {
                                this.Invoke(() =>
                                {
                                    if(SetRibbon.Checked)
                                    {
                                        RibbonApplicator.SetAllValidRibbons(pk);
                                    }
                                    MessageBox.Show($"Success！");
                                    Editor.PopulateFields(pk, false);
                                    SAV.ReloadSlots();
                                    SeedText.Text = $"{Convert.ToString(seed,16)}";
                                });
                                break;
                            }
                        seed = NextSeed(seed);
                    }
                    this.Invoke(() =>
                    {
                        IsRunning(false);
                        Condition.Text = "Nothing to check";
                    });
                },
                tokenSource.Token);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            IsRunning(false);
        }

    
    }
}
