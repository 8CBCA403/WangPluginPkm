using PKHeX.Core;
using System;
using System.Windows.Forms;

namespace WangPlugin
{
    internal class RNGForm : Form
    {
        private ComboBox methodTypeBox;
        private Button Search;

        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        enum MethodType
        {
            Method1,
            H1_BACD_R,
            Method1Roaming,
            Method2,
            Method4,
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
            this.methodTypeBox = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // methodTypeBox
            // 
            this.methodTypeBox.FormattingEnabled = true;
            this.methodTypeBox.Location = new System.Drawing.Point(12, 22);
            this.methodTypeBox.Name = "methodTypeBox";
            this.methodTypeBox.Size = new System.Drawing.Size(129, 23);
            this.methodTypeBox.TabIndex = 8;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(162, 22);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(92, 23);
            this.Search.TabIndex = 9;
            this.Search.Text = "StartRNG";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // RNGForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(278, 59);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.methodTypeBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RNGForm";
            this.ResumeLayout(false);

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
        private PKM GenPkm(uint seed)
        {

            //MessageBox.Show($"{((ITrainerID)SAV.SAV).SID}, {((ITrainerID)SAV.SAV).TID}");
            return RNGMethod switch
            {
                MethodType.Method1 => Method1RNG.GenPkm(Editor.Data, seed),
                MethodType.Method2 => Method2RNG.GenPkm(Editor.Data, seed),
                MethodType.Method4 => Method4RNG.GenPkm(Editor.Data, seed),
                MethodType.XDColo => XDColoRNG.GenPkm(Editor.Data, seed),
                MethodType.Overworld8 => Overworld8RNG.GenPkm(Editor.Data, seed, Editor.Data.TID, Editor.Data.SID),
                MethodType.Roaming8b => Roaming8bRNG.GenPkm(Editor.Data, seed, Editor.Data.TID, Editor.Data.SID),
                MethodType.H1_BACD_R=> H1_BACD_R.GenPkm(Editor.Data, seed & 0xFFFF, Editor.Data.SID, Editor.Data.TID),
                MethodType.Method1Roaming=> Method1Roaming.GenPkm(Editor.Data, seed),
                MethodType.Colo=>ColoRNG.GenPkm(Editor.Data, seed),
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
                _ => throw new NotSupportedException(),
            };
        }
        private int TypeXor()
        {
            return RNGMethod switch
            {
                MethodType.Method1 => 8,
                MethodType.Method2 => 8,
                MethodType.Method4 => 8,
                MethodType.XDColo => 8,
                MethodType.H1_BACD_R =>8,
                MethodType.Method1Roaming =>8,
                MethodType.Colo =>8,
                MethodType.Overworld8 => 16,
                MethodType.Roaming8b => 16,
                _ => throw new NotSupportedException(),
            };
        }
        

        private void Search_Click(object sender, EventArgs e)
        {
            var seed = Util.Rand32();
        
                
            while (true)
            {
                var pkm = GenPkm(seed);
                var la = new LegalityAnalysis(pkm);
                pkm.RefreshAbility((int)(pkm.PID & 1));
                if (GetShinyXor(pkm.PID, pkm.TID, pkm.SID) < TypeXor()&& la.Info.PIDIVMatches)
                {
                        MessageBox.Show($"过啦！");
                        Editor.PopulateFields(pkm, false);
                        SAV.ReloadSlots();
                        break;
                }
                seed = NextSeed(seed);
            }
        }
        private static uint GetShinyXor(uint pid, int TID, int SID)
        {
            return ((uint)(TID ^ SID) ^ ((pid >> 16) ^ (pid & 0xFFFF)));
        }
    }
}
