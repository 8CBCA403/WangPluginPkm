using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
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
        private Label TIDLabel;
        private Label SIDLabel;
        private Label OTLabel;
        private Label LGLabel;
        private OT_Gender typeG = OT_Gender.Male;
        private ISaveFileProvider SAV { get; }
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
        public DexBuildForm(ISaveFileProvider sav)

        {
            SAV = sav;
       
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
            this.TIDLabel = new System.Windows.Forms.Label();
            this.SIDLabel = new System.Windows.Forms.Label();
            this.OTLabel = new System.Windows.Forms.Label();
            this.LGLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Sort_BTN
            // 
            this.Sort_BTN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sort_BTN.Location = new System.Drawing.Point(79, 83);
            this.Sort_BTN.Name = "Sort_BTN";
            this.Sort_BTN.Size = new System.Drawing.Size(102, 25);
            this.Sort_BTN.TabIndex = 0;
            this.Sort_BTN.Text = "Sort";
            this.Sort_BTN.UseVisualStyleBackColor = true;
            this.Sort_BTN.Click += new System.EventHandler(this.Sort_BTN_Click);
            // 
            // Gen_BTN
            // 
            this.Gen_BTN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gen_BTN.Location = new System.Drawing.Point(187, 83);
            this.Gen_BTN.Name = "Gen_BTN";
            this.Gen_BTN.Size = new System.Drawing.Size(117, 24);
            this.Gen_BTN.TabIndex = 1;
            this.Gen_BTN.Text = "Start";
            this.Gen_BTN.UseVisualStyleBackColor = true;
            this.Gen_BTN.Click += new System.EventHandler(this.Gen_BTN_Click);
            // 
            // TIDBox
            // 
            this.TIDBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIDBox.Location = new System.Drawing.Point(58, 24);
            this.TIDBox.Name = "TIDBox";
            this.TIDBox.Size = new System.Drawing.Size(102, 27);
            this.TIDBox.TabIndex = 2;
            this.TIDBox.Text = "10101";
            // 
            // SIDBox
            // 
            this.SIDBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SIDBox.Location = new System.Drawing.Point(58, 55);
            this.SIDBox.Name = "SIDBox";
            this.SIDBox.Size = new System.Drawing.Size(102, 27);
            this.SIDBox.TabIndex = 3;
            this.SIDBox.Text = "01010";
            // 
            // OT_Name
            // 
            this.OT_Name.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OT_Name.Location = new System.Drawing.Point(216, 24);
            this.OT_Name.Name = "OT_Name";
            this.OT_Name.Size = new System.Drawing.Size(115, 27);
            this.OT_Name.TabIndex = 4;
            this.OT_Name.Text = "Wang";
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Location = new System.Drawing.Point(216, 55);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(45, 25);
            this.LanguageBox.TabIndex = 5;
            // 
            // GenderBox
            // 
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Location = new System.Drawing.Point(261, 55);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(70, 25);
            this.GenderBox.TabIndex = 6;
            // 
            // TIDLabel
            // 
            this.TIDLabel.AutoSize = true;
            this.TIDLabel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIDLabel.Location = new System.Drawing.Point(1, 20);
            this.TIDLabel.Name = "TIDLabel";
            this.TIDLabel.Size = new System.Drawing.Size(51, 29);
            this.TIDLabel.TabIndex = 7;
            this.TIDLabel.Text = "TID";
            // 
            // SIDLabel
            // 
            this.SIDLabel.AutoSize = true;
            this.SIDLabel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SIDLabel.Location = new System.Drawing.Point(1, 49);
            this.SIDLabel.Name = "SIDLabel";
            this.SIDLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SIDLabel.Size = new System.Drawing.Size(50, 29);
            this.SIDLabel.TabIndex = 8;
            this.SIDLabel.Text = "SID";
            // 
            // OTLabel
            // 
            this.OTLabel.AutoSize = true;
            this.OTLabel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTLabel.Location = new System.Drawing.Point(166, 22);
            this.OTLabel.Name = "OTLabel";
            this.OTLabel.Size = new System.Drawing.Size(44, 29);
            this.OTLabel.TabIndex = 9;
            this.OTLabel.Text = "OT";
            // 
            // LGLabel
            // 
            this.LGLabel.AutoSize = true;
            this.LGLabel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGLabel.Location = new System.Drawing.Point(167, 51);
            this.LGLabel.Name = "LGLabel";
            this.LGLabel.Size = new System.Drawing.Size(43, 29);
            this.LGLabel.TabIndex = 10;
            this.LGLabel.Text = "LG";
            // 
            // DexBuildForm
            // 
            this.ClientSize = new System.Drawing.Size(359, 126);
            this.Controls.Add(this.LGLabel);
            this.Controls.Add(this.OTLabel);
            this.Controls.Add(this.SIDLabel);
            this.Controls.Add(this.TIDLabel);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.LanguageBox);
            this.Controls.Add(this.OT_Name);
            this.Controls.Add(this.SIDBox);
            this.Controls.Add(this.TIDBox);
            this.Controls.Add(this.Gen_BTN);
            this.Controls.Add(this.Sort_BTN);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
