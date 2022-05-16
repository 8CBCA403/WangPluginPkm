using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PKHeX.Core.Searching;
using PKHeX.Core;
using PKHeX.Core.AutoMod;

namespace WangPlugin
{
    internal class DexBuildForm : Form
    {
        private Button Sort_BTN;
        private Button Gen_BTN;
        private TextBox TIDBox;
        private TextBox SIDBox;
        private ComboBox LanguageBox;
        private TextBox OT_Name;
        private LanguageBoxSelect7 type7 = LanguageBoxSelect7.ENG;
        private ComboBox GenderBox;
        private LanguageBoxSelect type = LanguageBoxSelect.ENG;
        private OT_Gender typeG = OT_Gender.Male;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        enum LanguageBoxSelect
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
           
        }
        enum LanguageBoxSelect7
        {
            JPN,
            ENG,
            FRE,
            ITA,
            GRE,
            ESP,
            KOR,
            CHS,
            CHT,
        }
        enum OT_Gender
        {
            Male,
            Female,
        }
        public DexBuildForm(ISaveFileProvider sav, IPKMView editor)

        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            if (sav.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
                BindingData7();
            else
                BindingData();
        }
        private void BindingData7()
        {
           
            this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect7));
            this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));

            this.LanguageBox.SelectedIndexChanged += (_, __) =>
            {
                type7 = (LanguageBoxSelect7)Enum.Parse(typeof(LanguageBoxSelect7), this.LanguageBox.SelectedItem.ToString(), false);
            };
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (OT_Gender)Enum.Parse(typeof(OT_Gender), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.LanguageBox.SelectedIndex = 0;
            this.GenderBox.SelectedIndex = 0;

        }
        private void BindingData()
        {

            this.LanguageBox.DataSource = Enum.GetNames(typeof(LanguageBoxSelect));
            this.GenderBox.DataSource = Enum.GetNames(typeof(OT_Gender));

            this.LanguageBox.SelectedIndexChanged += (_, __) =>
            {
                type = (LanguageBoxSelect)Enum.Parse(typeof(LanguageBoxSelect), this.LanguageBox.SelectedItem.ToString(), false);
            };
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                typeG = (OT_Gender)Enum.Parse(typeof(OT_Gender), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.LanguageBox.SelectedIndex = 0;
            this.GenderBox.SelectedIndex = 0;


        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DexBuildForm));
            this.Sort_BTN = new System.Windows.Forms.Button();
            this.Gen_BTN = new System.Windows.Forms.Button();
            this.TIDBox = new System.Windows.Forms.TextBox();
            this.SIDBox = new System.Windows.Forms.TextBox();
            this.OT_Name = new System.Windows.Forms.TextBox();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Sort_BTN
            // 
            this.Sort_BTN.Location = new System.Drawing.Point(18, 84);
            this.Sort_BTN.Name = "Sort_BTN";
            this.Sort_BTN.Size = new System.Drawing.Size(102, 25);
            this.Sort_BTN.TabIndex = 0;
            this.Sort_BTN.Text = "Sort";
            this.Sort_BTN.UseVisualStyleBackColor = true;
            this.Sort_BTN.Click += new System.EventHandler(this.Sort_BTN_Click);
            // 
            // Gen_BTN
            // 
            this.Gen_BTN.Location = new System.Drawing.Point(126, 84);
            this.Gen_BTN.Name = "Gen_BTN";
            this.Gen_BTN.Size = new System.Drawing.Size(117, 24);
            this.Gen_BTN.TabIndex = 1;
            this.Gen_BTN.Text = "Start";
            this.Gen_BTN.UseVisualStyleBackColor = true;
            this.Gen_BTN.Click += new System.EventHandler(this.Gen_BTN_Click);
            // 
            // TIDBox
            // 
            this.TIDBox.Location = new System.Drawing.Point(18, 22);
            this.TIDBox.Name = "TIDBox";
            this.TIDBox.Size = new System.Drawing.Size(102, 25);
            this.TIDBox.TabIndex = 2;
            this.TIDBox.Text = "10101";
            // 
            // SIDBox
            // 
            this.SIDBox.Location = new System.Drawing.Point(18, 53);
            this.SIDBox.Name = "SIDBox";
            this.SIDBox.Size = new System.Drawing.Size(102, 25);
            this.SIDBox.TabIndex = 3;
            this.SIDBox.Text = "01010";
            // 
            // OT_Name
            // 
            this.OT_Name.Location = new System.Drawing.Point(126, 22);
            this.OT_Name.Name = "OT_Name";
            this.OT_Name.Size = new System.Drawing.Size(115, 25);
            this.OT_Name.TabIndex = 4;
            this.OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(126, 55);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(45, 23);
            this.LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Location = new System.Drawing.Point(171, 55);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(70, 23);
            this.GenderBox.TabIndex = 6;
            // 
            // DexBuildForm
            // 
            this.ClientSize = new System.Drawing.Size(258, 126);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.LanguageBox);
            this.Controls.Add(this.OT_Name);
            this.Controls.Add(this.SIDBox);
            this.Controls.Add(this.TIDBox);
            this.Controls.Add(this.Gen_BTN);
            this.Controls.Add(this.Sort_BTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DexBuildForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Wang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public static void Sort(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            List<PKM> PokeList = new();
            int i;
            for (i = 0; i < 30; i++)
            {
                PKM pk = sav.GetBoxSlotAtIndex(sav.CurrentBox, i);
                if (pk.Species == 0)
                    break;
                PokeList.Add(pk);
            }
            var count = PokeList.Count;
            List<PKM> sorted = PokeList.OrderBy(c => c.Species).ToList();
            for (i = 0; i < count; i++)
            {
                sav.SetBoxSlotAtIndex(sorted[i], sav.CurrentBox, i);
            }
            sav.LegalizeBox(sav.CurrentBox);
        }
        private int GetLanguageBox7()
        {
            var T = 1;
            switch (type7)
            {
                case LanguageBoxSelect7.JPN:
                    T=1;
                    break;
                case LanguageBoxSelect7.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect7.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect7.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect7.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect7.ESP:
                    T = 7;
                    break;
                case LanguageBoxSelect7.KOR:
                    T = 8;
                    break;
                case LanguageBoxSelect7.CHS:
                    T = 9;
                    break;
                case LanguageBoxSelect7.CHT:
                    T = 10;
                    break;
            }
            return T;
        }
        private int GetLanguageBox()
        {
            var T = 1;
            switch (type)
            {
                case LanguageBoxSelect.JPN:
                    T = 1;
                    break;
                case LanguageBoxSelect.ENG:
                    T = 2;
                    break;
                case LanguageBoxSelect.FRE:
                    T = 3;
                    break;
                case LanguageBoxSelect.ITA:
                    T = 4;
                    break;
                case LanguageBoxSelect.GRE:
                    T = 5;
                    break;
                case LanguageBoxSelect.ESP:
                    T = 7;
                    break;
            }
            return T;
        }
        private int GetGender()
        {
            var T = 0;
            switch (typeG)
            {
                case OT_Gender.Male:
                    T = 0;
                    break;
                case OT_Gender.Female:
                    T = 1;
                    break;
            }
            return T;
        }
        public void Gen(ISaveFileProvider SaveFileEditor)
        {
            var sav = SaveFileEditor.SAV;
            sav.ModifyBoxes(SetID);
            SaveFileEditor.ReloadSlots();
        }
        public void SetID(PKM pkm)
        {
            var TID = Int32.Parse(TIDBox.Text);
            var SID = Int32.Parse(SIDBox.Text);
            var Name = OT_Name.Text;
            
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
                 GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
                pkm.Language=GetLanguageBox7();
            else
                pkm.Language = GetLanguageBox();
            pkm.OT_Name = Name;
            if (SAV.SAV.Version is GameVersion.SN or GameVersion.MN or GameVersion.US or GameVersion.UM or
               GameVersion.GP or GameVersion.GE or GameVersion.SW or GameVersion.SH or GameVersion.PLA or GameVersion.BD or GameVersion.SP)
            {
                pkm.TrainerID7 = TID;
                pkm.TrainerSID7 = SID;
            }
            else
            {
                pkm.TID = TID;
                pkm.SID = SID;
                
            }
            pkm.OT_Gender = GetGender();
            pkm.ClearNickname();
        }
        private void Sort_BTN_Click(object sender, EventArgs e)
        {
            Sort(SAV);
            MessageBox.Show("搞定了！");
        }

        private void Gen_BTN_Click(object sender, EventArgs e)
        {
            Gen(SAV);
            MessageBox.Show("搞定了！");
        }

    }
}
