using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PKHeX.Core;
using System.Windows.Forms;

namespace WangPlugin
{
    internal class HomeViewer:Form
    {
        private Button button2;
        private OpenFileDialog OpenFile_Dialog;
        private Button LoadEH1_BTN;
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        public HomeViewer(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.LoadEH1_BTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OpenFile_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LoadEH1_BTN
            // 
            this.LoadEH1_BTN.Location = new System.Drawing.Point(37, 40);
            this.LoadEH1_BTN.Name = "LoadEH1_BTN";
            this.LoadEH1_BTN.Size = new System.Drawing.Size(94, 30);
            this.LoadEH1_BTN.TabIndex = 0;
            this.LoadEH1_BTN.Text = "LoadEH1";
            this.LoadEH1_BTN.UseVisualStyleBackColor = true;
            this.LoadEH1_BTN.Click += new System.EventHandler(this.LoadEH1_BTN_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // OpenFile_Dialog
            // 
            this.OpenFile_Dialog.Filter =
        "PokemonHomefile (*.eh1)|*.eh1|" +
        "All files (*.*)|*.*";
            this.OpenFile_Dialog.Multiselect = true;
            // 
            // HomeViewer
            // 
            this.ClientSize = new System.Drawing.Size(282, 105);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LoadEH1_BTN);
            this.Name = "HomeViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        private void LoadEH1_BTN_Click(object sender, EventArgs e)
        {
            List<PKM> PK = new();
            var i = 0;
            DialogResult dr = this.OpenFile_Dialog.ShowDialog();
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
                MessageBox.Show($"{PK.Count}");
                for (i = 0; i < PK.Count; i++)
                {
                    SAV.SAV.SetBoxSlotAtIndex(PK[i], 0, i);
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
