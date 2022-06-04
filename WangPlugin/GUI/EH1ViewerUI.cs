using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PKHeX.Core;
using System.Windows.Forms;

namespace WangPlugin.GUI
{
    internal class EH1ViewerUI:Form
    {
        private OpenFileDialog OpenFile_Dialog;
        private TextBox BOX_TextBox;
        private Label BOX_Label;
        private Button LoadEH1_BTN;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public EH1ViewerUI(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EH1ViewerUI));
            this.LoadEH1_BTN = new System.Windows.Forms.Button();
            this.OpenFile_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.BOX_TextBox = new System.Windows.Forms.TextBox();
            this.BOX_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadEH1_BTN
            // 
            this.LoadEH1_BTN.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadEH1_BTN.Location = new System.Drawing.Point(162, 17);
            this.LoadEH1_BTN.Name = "LoadEH1_BTN";
            this.LoadEH1_BTN.Size = new System.Drawing.Size(119, 25);
            this.LoadEH1_BTN.TabIndex = 0;
            this.LoadEH1_BTN.Text = "LoadEH1";
            this.LoadEH1_BTN.UseVisualStyleBackColor = true;
            this.LoadEH1_BTN.Click += new System.EventHandler(this.LoadEH1_BTN_Click);
            // 
            // OpenFile_Dialog
            // 
            this.OpenFile_Dialog.Filter = "PokemonHomefile (*.eh1)|*.eh1|All files (*.*)|*.*";
            this.OpenFile_Dialog.Multiselect = true;
            // 
            // BOX_TextBox
            // 
            this.BOX_TextBox.Location = new System.Drawing.Point(72, 17);
            this.BOX_TextBox.Name = "BOX_TextBox";
            this.BOX_TextBox.Size = new System.Drawing.Size(84, 25);
            this.BOX_TextBox.TabIndex = 1;
            this.BOX_TextBox.Text = "1";
            // 
            // BOX_Label
            // 
            this.BOX_Label.AutoSize = true;
            this.BOX_Label.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BOX_Label.Location = new System.Drawing.Point(31, 20);
            this.BOX_Label.Name = "BOX_Label";
            this.BOX_Label.Size = new System.Drawing.Size(35, 17);
            this.BOX_Label.TabIndex = 2;
            this.BOX_Label.Text = "BOX";
            // 
            // EH1ViewerUI
            // 
            this.ClientSize = new System.Drawing.Size(293, 56);
            this.Controls.Add(this.BOX_Label);
            this.Controls.Add(this.BOX_TextBox);
            this.Controls.Add(this.LoadEH1_BTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EH1ViewerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperWang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadEH1_BTN_Click(object sender, EventArgs e)
        {
            List<PKM> PK = new();
            var i = 0;
            DialogResult dr = this.OpenFile_Dialog.ShowDialog();
            int BOX=Int16.Parse(BOX_TextBox.Text)-1;
            if (dr == DialogResult.OK)
            {
                foreach (String file in OpenFile_Dialog.FileNames)
                {
                    ConvertPKM(file, OpenFile_Dialog.FileNames.Length, ref PK);
                    i++;
                    if (i == OpenFile_Dialog.SafeFileNames.Length)
                    {
                        break;
                    }
                }
                MessageBox.Show($"选取了{PK.Count}只宝可梦");
                for (i = 0; i < PK.Count; i++)
                {
                    SAV.SAV.SetBoxSlotAtIndex(PK[i], BOX, i);
                    SAV.ReloadSlots();
                }
            }
        }
        private void ConvertPKM(string file,int n,ref List<PKM> p)
        {
            var data = File.ReadAllBytes(file);
            PKM pk;
           
            var pkh = DecryptEH1(data);
            if (SAV.SAV.Version is GameVersion.SH or GameVersion.SW)
            {
                pk = pkh.ConvertToPK8();
                p.Add(pk);
                
            }
            else if (SAV.SAV.Version is GameVersion.PLA)
            {
                pk = pkh.ConvertToPA8();
                p.Add(pk);
            }
            else if (SAV.SAV.Version is GameVersion.BD or GameVersion.SP)
            {
                pk = pkh.ConvertToPB8();
                p.Add(pk);
            }
            else
                MessageBox.Show("ERROR");

        }
        private PKH DecryptEH1(byte[] ek1)
        {
            if (ek1 != null)
            {
                if (HomeCrypto.GetIsEncrypted1(ek1))
                    return new PKH(ek1);
            }
            return null;
        }

       
    }
}
