using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace WangPlugin.GUI
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
        private CheckBox VCheck;
        private CheckBox LockIV;
        private Label label1;
        private CheckBox SpaCheck;
        private CheckBox UsePreSeed;
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
            this.VCheck = new System.Windows.Forms.CheckBox();
            this.LockIV = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpaCheck = new System.Windows.Forms.CheckBox();
            this.UsePreSeed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // methodTypeBox
            // 
            this.methodTypeBox.FormattingEnabled = true;
            this.methodTypeBox.Location = new System.Drawing.Point(91, 17);
            this.methodTypeBox.Name = "methodTypeBox";
            this.methodTypeBox.Size = new System.Drawing.Size(124, 25);
            this.methodTypeBox.TabIndex = 8;

            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(36, 145);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(124, 25);
            this.Search.TabIndex = 9;
            this.Search.Text = "开始查找";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Condition
            // 
            this.Condition.Location = new System.Drawing.Point(221, 17);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(124, 25);
            this.Condition.TabIndex = 10;
            this.Condition.Text = "无事可做";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(184, 145);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(124, 25);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "停止";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ShinyTypeBox
            // 
            this.ShinyTypeBox.FormattingEnabled = true;
            this.ShinyTypeBox.Location = new System.Drawing.Point(91, 56);
            this.ShinyTypeBox.Name = "ShinyTypeBox";
            this.ShinyTypeBox.Size = new System.Drawing.Size(124, 25);
            this.ShinyTypeBox.TabIndex = 13;
            // 
            // ShinyTypeLabel
            // 
            this.ShinyTypeLabel.AutoSize = true;
            this.ShinyTypeLabel.Location = new System.Drawing.Point(12, 59);
            this.ShinyTypeLabel.Name = "ShinyTypeLabel";
            this.ShinyTypeLabel.Size = new System.Drawing.Size(72, 17);
            this.ShinyTypeLabel.TabIndex = 14;
            this.ShinyTypeLabel.Text = "闪光种类";
            // 
            // SeedText
            // 
            this.SeedText.Location = new System.Drawing.Point(221, 56);
            this.SeedText.Name = "SeedText";
            this.SeedText.Size = new System.Drawing.Size(124, 25);
            this.SeedText.TabIndex = 15;
            this.SeedText.Text = "没有seed";
            // 
            // AtkCheck
            // 
            this.AtkCheck.AutoSize = true;
            this.AtkCheck.Location = new System.Drawing.Point(14, 91);
            this.AtkCheck.Name = "AtkCheck";
            this.AtkCheck.Size = new System.Drawing.Size(70, 21);
            this.AtkCheck.TabIndex = 16;
            this.AtkCheck.Text = "0物攻";
            this.AtkCheck.UseVisualStyleBackColor = true;
            // 
            // SpeCheck
            // 
            this.SpeCheck.AutoSize = true;
            this.SpeCheck.Location = new System.Drawing.Point(81, 91);
            this.SpeCheck.Name = "SpeCheck";
            this.SpeCheck.Size = new System.Drawing.Size(70, 21);
            this.SpeCheck.TabIndex = 17;
            this.SpeCheck.Text = "0速度";
            this.SpeCheck.UseVisualStyleBackColor = true;
            // 
            // VCheck
            // 
            this.VCheck.AutoSize = true;
            this.VCheck.Enabled = false;
            this.VCheck.Location = new System.Drawing.Point(221, 91);
            this.VCheck.Name = "VCheck";
            this.VCheck.Size = new System.Drawing.Size(47, 21);
            this.VCheck.TabIndex = 18;
            this.VCheck.Text = "6V";
            this.VCheck.UseVisualStyleBackColor = true;
            // 
            // LockIV
            // 
            this.LockIV.AutoSize = true;
            this.LockIV.Enabled = false;
            this.LockIV.Location = new System.Drawing.Point(282, 91);
            this.LockIV.Name = "LockIV";
            this.LockIV.Size = new System.Drawing.Size(63, 21);
            this.LockIV.TabIndex = 19;
            this.LockIV.Text = "锁3V";
            this.LockIV.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "RNG类型";
            // 
            // SpaCheck
            // 
            this.SpaCheck.AutoSize = true;
            this.SpaCheck.Enabled = true;
            this.SpaCheck.Location = new System.Drawing.Point(145, 91);
            this.SpaCheck.Name = "SpaCheck";
            this.SpaCheck.Size = new System.Drawing.Size(70, 21);
            this.SpaCheck.TabIndex = 21;
            this.SpaCheck.Text = "随机特攻";
            this.SpaCheck.UseVisualStyleBackColor = true;
            // 
            // UsePreSeed
            // 
            this.UsePreSeed.AutoSize = true;
            this.UsePreSeed.Enabled = true;
            this.UsePreSeed.Location = new System.Drawing.Point(14, 118);
            this.UsePreSeed.Name = "UsePreSeed";
            this.UsePreSeed.Size = new System.Drawing.Size(126, 21);
            this.UsePreSeed.TabIndex = 22;
            this.UsePreSeed.Text = "使用预设种子";
            this.UsePreSeed.UseVisualStyleBackColor = true;
            // 
            // RNGForm
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(355, 177);
            this.Controls.Add(this.UsePreSeed);
            this.Controls.Add(this.SpaCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LockIV);
            this.Controls.Add(this.VCheck);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
                if (methodTypeBox.SelectedItem == methodTypeBox.Items[9]|| 
                methodTypeBox.SelectedItem == methodTypeBox.Items[1]|| 
                methodTypeBox.SelectedItem == methodTypeBox.Items[7])
                {
                    LockIV.Enabled = true;
                    LockIV.Checked = false;
                    VCheck.Enabled = false;
                }
                else if (methodTypeBox.SelectedItem == methodTypeBox.Items[10])
                {
                    LockIV.Enabled = false;
                    LockIV.Checked = true;
                    VCheck.Enabled = true;
                    this.VCheck.CheckedChanged += (_, __) =>
                    {
                        if (VCheck.Checked == true)
                        {
                            AtkCheck.Enabled = false;
                            SpeCheck.Enabled = false;
                            AtkCheck.Checked = false;
                            SpeCheck.Checked = false;
                        }
                        else
                        {
                            AtkCheck.Enabled = true;
                            SpeCheck.Enabled = true;
                        }

                    };
                    this.AtkCheck.CheckedChanged += (_, __) =>
                    {
                        if (AtkCheck.Checked == true)
                        {
                            VCheck.Checked = false;
                            VCheck.Enabled = false;
                        }
                        else
                        {
                            VCheck.Enabled = true;
                        }
                    };
                    this.SpeCheck.CheckedChanged += (_, __) =>
                    {
                        if (SpeCheck.Checked == true)
                        {
                            VCheck.Checked = false;
                            VCheck.Enabled = false;
                        }
                        else
                        {
                            VCheck.Enabled = true;
                        }
                    };
                }
                else
                {
                    LockIV.Enabled = false;
                    LockIV.Checked = false;
                    VCheck.Enabled = false;
                }
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
            var shinytype = new bool[6] { false, false, false, false, false,false };
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
            var IV = new bool[3] { false, false,false};
            if (AtkCheck.Checked)
                IV[0] = true;
            if (SpeCheck.Checked)
                IV[1] = true;
            if (LockIV.Checked)
            {
                IV[2] = true;
            }
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
        private Queue<uint> PreSetSeed()
        {

            Queue<uint> Getqeueu = new Queue<uint>();
            if (RNGMethod == MethodType.Roaming8b &&
                VCheck.Checked &&
                Stype != ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(1);
            }
            else if (RNGMethod == MethodType.Roaming8b&& 
                AtkCheck.Checked&&
                SpeCheck.Checked&&
                Stype!=ShinyType.None)
            {
                Getqeueu = SeedList.EnqueueSeed(2);
            }
            else if (RNGMethod == MethodType.Roaming8b &&
                AtkCheck.Checked &&
                !SpeCheck.Checked &&
                Stype != ShinyType.None)
                {
                Getqeueu = SeedList.EnqueueSeed(3);
            }
            else if(RNGMethod==MethodType.Roaming8b&&
                !AtkCheck.Checked&&
                SpeCheck.Checked &&
                (Stype != ShinyType.None&&Stype!=ShinyType.Sqaure))
            {
                Getqeueu = SeedList.EnqueueSeed(4);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
               AtkCheck.Checked &&
               !SpeCheck.Checked &&
               Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(5);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
              !AtkCheck.Checked &&
              SpeCheck.Checked &&
              Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(6);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
             AtkCheck.Checked &&
             SpeCheck.Checked &&
             Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(7);
            }
            else if (RNGMethod == MethodType.Overworld8 &&
             !AtkCheck.Checked &&
             !SpeCheck.Checked &&
             SpaCheck.Checked &&
             Stype == ShinyType.Sqaure)
            {
                Getqeueu = SeedList.EnqueueSeed(8);
            }
            return Getqeueu;
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
            uint seed = 0;
            Queue<uint> SeedQueue = new Queue<uint>();
            var j = 0;
            if (UsePreSeed.Checked == true)
            {
                SeedQueue = PreSetSeed();
                MessageBox.Show($"预设种子数量:{SeedQueue.Count}");
            }
            tokenSource = new();
            if (UsePreSeed.Checked == true)
            {
                Random rd = new Random();
                if (SeedQueue.Count >1)
                    j = rd.Next(0, SeedQueue.Count);
                else
                    j = 1;
            }
            Task.Factory.StartNew(
                () =>
                {
                    seed = Util.Rand32();
                    var pk = Editor.Data;
                    while (true)
                    {
                        if (tokenSource.IsCancellationRequested)
                        {
                            Condition.Text = "Stop";
                            return;
                        }
                        for (int i = 0; i < j; i++)
                        {
                            if (SeedQueue.Count != 0)
                            {
                                seed = SeedQueue.Dequeue();
                            }
                            else
                                break;
                        }
                       
                        if (GenPkm(ref pk, seed))
                            {
                           
                            this.Invoke(() =>
                                {
                                    MessageBox.Show($"Success！");
                                    Editor.PopulateFields(pk, false);
                                    SAV.ReloadSlots();
                                    SeedText.Text = $"{Convert.ToString(seed, 16)}";
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
