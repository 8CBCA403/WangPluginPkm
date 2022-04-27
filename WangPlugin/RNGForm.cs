using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace WangPlugin
{
    internal class RNGForm : Form
    {
        private ComboBox methodTypeBox;
        private Button Search;
        private CancellationTokenSource tokenSource = new();
        private TextBox Condition;
        private Button Cancel;
        private CheckBox ShinyCheck;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum MethodType
        {
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
        private MethodType RNGMethod = MethodType.Method1;
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public RNGForm(ISaveFileProvider sav, IPKMView editor)
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RNGForm));
            this.methodTypeBox = new ComboBox();
            this.Search = new Button();
            this.Condition = new TextBox();
            this.Cancel = new Button();
            this.ShinyCheck = new CheckBox();
            this.SuspendLayout();
            // 
            // methodTypeBox
            // 
            this.methodTypeBox.FormattingEnabled = true;
            this.methodTypeBox.Location = new System.Drawing.Point(12, 22);
            this.methodTypeBox.Name = "methodTypeBox";
            this.methodTypeBox.Size = new System.Drawing.Size(140, 23);
            this.methodTypeBox.TabIndex = 8;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(175, 22);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(92, 23);
            this.Search.TabIndex = 9;
            this.Search.Text = "StartRNG";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Condition
            // 
            this.Condition.Location = new System.Drawing.Point(12, 76);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(140, 25);
            this.Condition.TabIndex = 10;
            this.Condition.Text = "Nothing to check";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(175, 76);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(92, 25);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ShinyCheck
            // 
            this.ShinyCheck.AutoSize = true;
            this.ShinyCheck.Location = new System.Drawing.Point(12, 51);
            this.ShinyCheck.Name = "ShinyCheck";
            this.ShinyCheck.Size = new System.Drawing.Size(69, 19);
            this.ShinyCheck.TabIndex = 12;
            this.ShinyCheck.Text = "Shiny";
            this.ShinyCheck.UseVisualStyleBackColor = true;
            // 
            // RNGForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(285, 112);
            this.Controls.Add(this.ShinyCheck);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Condition);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.methodTypeBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RNGForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void BindingData()
        {
            this.methodTypeBox.DataSource = Enum.GetNames(typeof(MethodType));
            this.methodTypeBox.SelectedIndexChanged += (_, __) =>
            {
                RNGMethod = (MethodType)Enum.Parse(typeof(MethodType), this.methodTypeBox.SelectedItem.ToString(), false);
            };
            this.methodTypeBox.SelectedIndex = 0;

        }
        private bool GenPkm(ref PKM pk,uint seed)
        {
            //MessageBox.Show($"{((ITrainerID)SAV.SAV).SID}, {((ITrainerID)SAV.SAV).TID}");
            return RNGMethod switch
            {
                MethodType.Method1 => Method1RNG.GenPkm(ref pk, seed, ShinyCheck.Checked),
                MethodType.Method2 => Method2RNG.GenPkm(ref pk, seed, ShinyCheck.Checked),
                MethodType.Method4 => Method4RNG.GenPkm(ref pk, seed, ShinyCheck.Checked),
                MethodType.XDColo => XDColoRNG.GenPkm(ref pk, seed, ShinyCheck.Checked),
                MethodType.Overworld8 => Overworld8RNG.GenPkm(ref pk, seed, Editor.Data.TID, Editor.Data.SID, ShinyCheck.Checked),
                MethodType.Roaming8b => Roaming8bRNG.GenPkm(ref pk, seed, Editor.Data.TID, Editor.Data.SID, ShinyCheck.Checked),
                MethodType.H1_BACD_R => H1_BACD_R.GenPkm(ref pk, seed & 0xFFFF, Editor.Data.SID, Editor.Data.TID, ShinyCheck.Checked),
                MethodType.Method1Roaming => Method1Roaming.GenPkm(ref pk, seed, ShinyCheck.Checked),
                MethodType.Colo => ColoRNG.GenPkm(ref pk, seed,ShinyCheck.Checked),
                MethodType.ChainShiny => ChainShiny.GenPkm(ref pk, seed),
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
            Cancel.Visible = running;
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
                                    MessageBox.Show($"过啦！");
                                    Editor.PopulateFields(pk, false);
                                    SAV.ReloadSlots();
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
