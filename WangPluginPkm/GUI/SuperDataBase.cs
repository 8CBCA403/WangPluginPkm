using iText.Forms.Xfdf;
using PKHeX.Core;
using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil.ModifyPKM;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using static WangPluginPkm.CheckRules;
using static WangPluginPkm.PluginUtil.PluginEnums.GUIEnums;
using System.Net;
using System.Net.Http;
using iText.IO.Image;
using System.Drawing;

namespace WangPluginPkm.GUI
{
    public partial class SuperDataBase : Form
    {
        public static GameStrings GameStringsZh = GameInfo.GetStrings("zh");
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        private static List<litePK> lp = new List<litePK>();

        public SuperDataBase(ISaveFileProvider sav, IPKMView editor)
        {
            InitializeComponent();
            BindingData();
            SAV = sav;
            Editor = editor;
        }
        public enum Filter
        {
            种类,
            文件名
        }
        private void BindingData()
        {
            var MOV1 = GameStringsZh.Move.ToArray();
            var MOV2 = GameStringsZh.Move.ToArray();
            var MOV3 = GameStringsZh.Move.ToArray();
            var MOV4 = GameStringsZh.Move.ToArray();
            var REV1 = GameStringsZh.Move.ToArray();
            var REV2 = GameStringsZh.Move.ToArray();
            var REV3 = GameStringsZh.Move.ToArray();
            var REV4 = GameStringsZh.Move.ToArray();
            SP_CB.DataSource = GameStringsZh.Species;
            SP_CB.AutoCompleteCustomSource = auto(GameStringsZh.Species.ToArray());
            NA_CB.DataSource = GameStringsZh.Natures;
            NA_CB.AutoCompleteCustomSource = auto(GameStringsZh.Natures.ToArray());
            MOV1_CB.DataSource = MOV1;
            MOV1_CB.AutoCompleteCustomSource = auto(MOV1);
            MOV2_CB.DataSource = MOV2;
            MOV2_CB.AutoCompleteCustomSource = auto(MOV2);
            MOV3_CB.DataSource = MOV3;
            MOV3_CB.AutoCompleteCustomSource = auto(MOV3);
            MOV4_CB.DataSource = MOV4;
            MOV4_CB.AutoCompleteCustomSource = auto(MOV4);
            REM1_CB.DataSource = REV1;
            REM1_CB.AutoCompleteCustomSource = auto(REV1);
            REM2_CB.DataSource = REV2;
            REM2_CB.AutoCompleteCustomSource = auto(REV2);
            REM3_CB.DataSource = REV3;
            REM3_CB.AutoCompleteCustomSource = auto(REV3);
            REM4_CB.DataSource = REV4;
            REM3_CB.AutoCompleteCustomSource = auto(REV4);
            AB_CB.DataSource = GameStringsZh.Ability;
            AB_CB.AutoCompleteCustomSource = auto(GameStringsZh.Ability.ToArray());
            IT_CB.DataSource = GameStringsZh.Item;
            IT_CB.AutoCompleteCustomSource = auto(GameStringsZh.Item.ToArray());
            BA_CB.DataSource = GameStringsZh.balllist;
            BA_CB.AutoCompleteCustomSource = auto(GameStringsZh.balllist.ToArray());
            LA_CB.DataSource = Enum.GetNames(typeof(LanguageID));
            Filter_CB.DataSource = Enum.GetValues(typeof(Filter));
        }

        private void import_editor_BTN_Click(object sender, EventArgs e)
        {
            SP_CB.SelectedIndex = Editor.Data.Species;
            NA_CB.SelectedIndex = Editor.Data.Nature;
            AB_CB.SelectedIndex = Editor.Data.Ability;
            IT_CB.SelectedIndex = Editor.Data.HeldItem;
            BA_CB.SelectedIndex = Editor.Data.Ball;
            LA_CB.SelectedIndex = Editor.Data.Language;
            FO_NU.Value = Editor.Data.Form;
            ABN_NU.Value = Editor.Data.AbilityNumber;
            MOV1_CB.SelectedIndex = Editor.Data.Move1;
            MOV2_CB.SelectedIndex = Editor.Data.Move2;
            MOV3_CB.SelectedIndex = Editor.Data.Move3;
            MOV4_CB.SelectedIndex = Editor.Data.Move4;
            REM1_CB.SelectedIndex = Editor.Data.RelearnMove1;
            REM2_CB.SelectedIndex = Editor.Data.RelearnMove2;
            REM3_CB.SelectedIndex = Editor.Data.RelearnMove3;
            REM4_CB.SelectedIndex = Editor.Data.RelearnMove4;
            IV_TB.Text = $"{Editor.Data.IV_HP}/{Editor.Data.IV_ATK}/{Editor.Data.IV_DEF}/{Editor.Data.IV_SPA}/{Editor.Data.IV_SPD}/{Editor.Data.IV_SPE}";
            EV_TB.Text = $"{Editor.Data.EV_HP}/{Editor.Data.EV_ATK}/{Editor.Data.EV_DEF}/{Editor.Data.EV_SPA}/{Editor.Data.EV_SPD}/{Editor.Data.EV_SPE}";
            this.Lp_LIST.DisplayMember = "Name";
            MessageBox.Show("导入了面板！");
        }
        private AutoCompleteStringCollection auto(string[] array)
        {
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(array);
            return autoComplete;
        }
        private void Export_BTN_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "spd files (*.spd)|*.spd|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, StringToByteArray(savlist()));
                    MessageBox.Show("导出了文件！");
                }
                else
                {
                    MessageBox.Show("您未选择文件");
                    return;
                }
            }
        }
        private void Import_BTN_Click(object sender, EventArgs e)
        {
            string r = "";
            using (var sfd = new OpenFileDialog())
            {
                sfd.Filter = "spd files (*.spd)|*.spd|All files (*.*)|*.*";
                sfd.FilterIndex = 2;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    r = ByteArrayToString(File.ReadAllBytes(sfd.FileName));
                    MessageBox.Show("导入了文件！");
                }
                else
                {
                    MessageBox.Show("您未选择文件");
                    return;
                }
            }
            if (savpklist(r).Count != 0)
            {
                Lp_LIST.Items.Clear();
                foreach (var lp in savpklist(r))
                {
                    Lp_LIST.Items.Add(lp, CheckState.Checked);
                    this.Lp_LIST.DisplayMember = "Name";
                }
            }
            else
            {
                MessageBox.Show("列表里没有文件");
            }
        }
        public static byte[] StringToByteArray(string str)
        {
            if (str == null)
                return null;

            return Encoding.UTF8.GetBytes(str);
        }
        public static string ByteArrayToString(byte[] bt)
        {
            if (bt == null)
                return null;

            return Encoding.UTF8.GetString(bt);
        }
        private void Sav_BTN_Click(object sender, EventArgs e)
        {
            Lp_LIST.Items.Add(savlp(), CheckState.Checked);
            this.Lp_LIST.DisplayMember = "Name";
        }
        private string savlist()
        {
            string r = "";
            string re = "";
            foreach (var lp in Lp_LIST.CheckedItems)
            {
                if (lp is litePK)

                    re = litePK.lptoSt((litePK)lp);
                r += re;
            }
            return r;
        }
        private litePK savlp()
        {
            string[] iv = IV_TB.Text.Split('/');
            int[] ivs = new int[6];
            for (int i = 0; i < 6; i++)
            {
                ivs[i] = int.Parse(iv[i]);
            }
            string[] ev = EV_TB.Text.Split('/');
            int[] evs = new int[6];
            for (int i = 0; i < 6; i++)
            {
                evs[i] = int.Parse(ev[i]);
            }
            litePK lp = new()
            {
                Name = File_TB.Text,
                Species = SP_CB.SelectedIndex,
                Nature = NA_CB.SelectedIndex,
                Ability = AB_CB.SelectedIndex,
                AbilityNumber = ABN_NU.Value,
                HeldItem = IT_CB.SelectedIndex,
                Ball = BA_CB.SelectedIndex,
                Language = LA_CB.SelectedIndex,
                Form = FO_NU.Value,
                Move1 = MOV1_CB.SelectedIndex,
                Move2 = MOV2_CB.SelectedIndex,
                Move3 = MOV3_CB.SelectedIndex,
                Move4 = MOV4_CB.SelectedIndex,
                RelearnMove1 = REM1_CB.SelectedIndex,
                RelearnMove2 = REM2_CB.SelectedIndex,
                RelearnMove3 = REM3_CB.SelectedIndex,
                RelearnMove4 = REM4_CB.SelectedIndex,
                IVS = ivs,
                EVS = evs,
            };

            return lp;
        }
        private List<litePK> savpklist(string s)
        {
            List<litePK> lt = new();
            int[] mov = new int[4];
            int[] remov = new int[4];

            var ss = s.Split("#");
            for (int j = 0; j < ss.Length - 1; j++)
            {
                litePK lp = new();
                var lps = ss[j];
                var lpsarray = lps.Split(":");
                var baselpsarray = lpsarray[0];
                var ivlpsarray = lpsarray[1];
                var evlpsarray = lpsarray[2];
                var movlpsarray = lpsarray[3];
                var removlpsarray = lpsarray[4];
                var baselps = baselpsarray.Split(",");
                lp.Name = baselps[0];
                lp.Species = Int32.Parse(baselps[1]);
                lp.Nature = Int32.Parse(baselps[2]);
                lp.Ability = Int32.Parse(baselps[3]);
                lp.HeldItem = Int32.Parse(baselps[4]);
                lp.Ball = Int32.Parse(baselps[5]);
                lp.Language = Int32.Parse(baselps[6]);
                lp.Form = Int32.Parse(baselps[7]);
                lp.AbilityNumber = Int32.Parse(baselps[8]);
                var ivlps = ivlpsarray.Split("/");
                for (int i = 0; i < 6; i++)
                {
                    lp.IVS[i] = Int32.Parse(ivlps[i]);

                }
                var evlps = evlpsarray.Split("/");
                for (int i = 0; i < 6; i++)
                {
                    lp.EVS[i] = Int32.Parse(evlps[i]);
                }

                var movlps = movlpsarray.Split(",");
                for (int i = 0; i < 4; i++)
                {
                    mov[i] = Int32.Parse(movlps[i]);

                }
                lp.Move1 = mov[0];
                lp.Move2 = mov[1];
                lp.Move3 = mov[2];
                lp.Move4 = mov[3];

                var removlps = removlpsarray.Split(",");
                for (int i = 0; i < 4; i++)
                {
                    remov[i] = Int32.Parse(removlps[i]);

                }
                lp.RelearnMove1 = remov[0];
                lp.RelearnMove2 = remov[1];
                lp.RelearnMove3 = remov[2];
                lp.RelearnMove4 = remov[3];

                lt.Add(lp);
            }
            return lt;
        }
        private async void Lp_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {

            var lp = Lp_LIST.SelectedItem;
            if (lp is litePK)
            {
                File_TB.Text = ((litePK)lp).Name;
                SP_CB.SelectedIndex = ((litePK)lp).Species;
                NA_CB.SelectedIndex = ((litePK)lp).Nature;
                AB_CB.SelectedIndex = ((litePK)lp).Ability;
                IT_CB.SelectedIndex = ((litePK)lp).HeldItem;
                BA_CB.SelectedIndex = ((litePK)lp).Ball;
                LA_CB.SelectedIndex = ((litePK)lp).Language;
                FO_NU.Value = ((litePK)lp).Form;
                ABN_NU.Value = ((litePK)lp).AbilityNumber;
                MOV1_CB.SelectedIndex = ((litePK)lp).Move1;
                MOV2_CB.SelectedIndex = ((litePK)lp).Move2;
                MOV3_CB.SelectedIndex = ((litePK)lp).Move3;
                MOV4_CB.SelectedIndex = ((litePK)lp).Move4;
                REM1_CB.SelectedIndex = ((litePK)lp).RelearnMove1;
                REM2_CB.SelectedIndex = ((litePK)lp).RelearnMove2;
                REM3_CB.SelectedIndex = ((litePK)lp).RelearnMove3;
                REM4_CB.SelectedIndex = ((litePK)lp).RelearnMove4;
                IV_TB.Text = $"{((litePK)lp).IVS[0]}/{((litePK)lp).IVS[1]}/{((litePK)lp).IVS[2]}/{((litePK)lp).IVS[3]}/{((litePK)lp).IVS[4]}/{((litePK)lp).IVS[5]}";
                EV_TB.Text = $"{((litePK)lp).EVS[0]}/{((litePK)lp).EVS[1]}/{((litePK)lp).EVS[2]}/{((litePK)lp).EVS[3]}/{((litePK)lp).EVS[4]}/{((litePK)lp).EVS[5]}";
                string baseuri = "https://raw.githubusercontent.com/8CBCA403/pokepic/main/Normal/poke_capture_" + $"{((litePK)lp).Species.ToString().PadLeft(4, '0')}" + "_000_00000000_f_n.png";
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        byte[] Imdata = await client.GetByteArrayAsync(baseuri);
                        using (var ms = new MemoryStream(Imdata))
                        {
                            Image image = Image.FromStream(ms);
                            float ratioX = (float)PKBox.Width / (float)image.Width;
                            float ratioY = (float)PKBox.Height / (float)image.Height;
                            float ratio = Math.Min(ratioX, ratioY);
                            int newWidth = (int)(image.Width * ratio);
                            int newHeight = (int)(image.Height * ratio);
                            Image newImage = new Bitmap(newWidth, newHeight);
                            using (Graphics g = Graphics.FromImage(newImage))
                            {
                                g.DrawImage(image, 0, 0, newWidth, newHeight);
                            }
                            PKBox.Image = newImage;
                        }
                    }
                }
                catch (Exception)
                {
                    PKBox.Image = Properties.Resources.Home;
                }
            }
        }
        private void Search_BTN_Click(object sender, EventArgs e)
        {
            switch (Filter_CB.SelectedIndex)
            {
                case 0:
                    FilterItemsByProperty("Species", GetNo(Search_Tb.Text));
                    break;
                case 1:
                    FilterItemsByProperty("Name", Search_Tb.Text);
                    break;
            }
        }

        private void RUN_BTN_Click(object sender, EventArgs e)
        {
            SAV.SAV.ModifyBoxes(mod, (int)StartBox_NUM.Value, (int)EndBox_NUM.Value);
            SAV.ReloadSlots();
            MessageBox.Show("覆写完成！");
        }
        private void mod(PKM pk)
        {
            List<litePK> litePKs = new List<litePK>();
            foreach (var pl in Lp_LIST.CheckedItems)
            {
                var p = (litePK)pl;
                litePKs.Add(p);
            }
            for (int i = 0; i < litePKs.Count; i++)
            {
                if (pk.Species == litePKs[i].Species)
                {
                    pk.Nature = litePKs[i].Nature;
                    pk.Ability = litePKs[i].Ability;
                    pk.AbilityNumber = (int)litePKs[i].AbilityNumber;
                    pk.HeldItem = litePKs[i].HeldItem;
                    pk.Ball = litePKs[i].Ball;
                    pk.Language = litePKs[i].Language;
                    pk.Form = (byte)litePKs[i].Form;
                    pk.IV_HP = litePKs[i].IVS[0];
                    pk.IV_ATK = litePKs[i].IVS[1];
                    pk.IV_DEF = litePKs[i].IVS[2];
                    pk.IV_SPA = litePKs[i].IVS[3];
                    pk.IV_SPD = litePKs[i].IVS[4];
                    pk.IV_SPE = litePKs[i].IVS[5];
                    pk.EV_HP = litePKs[i].EVS[0];
                    pk.EV_ATK = litePKs[i].EVS[1];
                    pk.EV_DEF = litePKs[i].EVS[2];
                    pk.EV_SPA = litePKs[i].EVS[3];
                    pk.EV_SPD = litePKs[i].EVS[4];
                    pk.EV_SPE = litePKs[i].EVS[5];
                    pk.Move1 = (ushort)litePKs[i].Move1;
                    pk.Move2 = (ushort)litePKs[i].Move2;
                    pk.Move3 = (ushort)litePKs[i].Move3;
                    pk.Move4 = (ushort)litePKs[i].Move4;
                    pk.HealPP();
                    pk.RelearnMove1 = (ushort)litePKs[i].RelearnMove1;
                    pk.RelearnMove2 = (ushort)litePKs[i].RelearnMove2;
                    pk.RelearnMove3 = (ushort)litePKs[i].RelearnMove3;
                    pk.RelearnMove4 = (ushort)litePKs[i].RelearnMove4;
                }

            }
        }
        public static IReadOnlyList<PKM> GetAllPKM(SaveFile sav)
        {
            List<PKM> list = new List<PKM>();
            if (sav.HasBox)
            {
                list.AddRange(sav.BoxData);
            }
            PKM[] extraPKM = sav.GetExtraPKM();
            list.AddRange(extraPKM);
            list.RemoveAll((PKM z) => z.Species == 0);
            return list;
        }

        private void Delet_BTN_Click(object sender, EventArgs e)
        {
            for (int i = Lp_LIST.CheckedItems.Count - 1; i >= 0; i--)
            {
                int index = Lp_LIST.Items.IndexOf(Lp_LIST.CheckedItems[i]);
                Lp_LIST.Items.RemoveAt(index);

            }
            Lp_LIST.Refresh();
        }

        private void SeletAll_BTN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lp_LIST.Items.Count; i++)
            {
                Lp_LIST.SetItemChecked(i, true);
            }
            Lp_LIST.Refresh();
        }

        private void DeSelect_BTN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lp_LIST.Items.Count; i++)
            {
                Lp_LIST.SetItemChecked(i, !Lp_LIST.GetItemChecked(i));
            }
            Lp_LIST.Refresh();
        }

        private void Edit_BTN_Click(object sender, EventArgs e)
        {
            var it = Lp_LIST.SelectedItem;
            int index = Lp_LIST.Items.IndexOf(it);
            litePK pk = (litePK)Lp_LIST.Items[index];
            string[] iv = IV_TB.Text.Split('/');
            int[] ivs = new int[6];
            for (int i = 0; i < 6; i++)
            {
                ivs[i] = int.Parse(iv[i]);
            }
            string[] ev = EV_TB.Text.Split('/');
            int[] evs = new int[6];
            for (int i = 0; i < 6; i++)
            {
                evs[i] = int.Parse(ev[i]);
            }

            pk.Name = File_TB.Text;
            pk.Species = SP_CB.SelectedIndex;
            pk.Nature = NA_CB.SelectedIndex;
            pk.Ability = AB_CB.SelectedIndex;
            pk.AbilityNumber = ABN_NU.Value;
            pk.HeldItem = IT_CB.SelectedIndex;
            pk.Ball = BA_CB.SelectedIndex;
            pk.Language = LA_CB.SelectedIndex;
            pk.Form = FO_NU.Value;
            pk.Move1 = MOV1_CB.SelectedIndex;
            pk.Move2 = MOV2_CB.SelectedIndex;
            pk.Move3 = MOV3_CB.SelectedIndex;
            pk.Move4 = MOV4_CB.SelectedIndex;
            pk.RelearnMove1 = REM1_CB.SelectedIndex;
            pk.RelearnMove2 = REM2_CB.SelectedIndex;
            pk.RelearnMove3 = REM3_CB.SelectedIndex;
            pk.RelearnMove4 = REM4_CB.SelectedIndex;
            pk.IVS = ivs;
            pk.EVS = evs;
            Lp_LIST.SetItemChecked(index, true);
        }
        private void FilterItemsByProperty(string name, object value)
        {
            var re = from litePK obj in Lp_LIST.Items select obj;
            lp = re.ToList();
            var fo = from litePK obj in Lp_LIST.Items
                     where obj.GetType().GetProperty(name).GetValue(obj, null).Equals(value)
                     select obj;
            var f = fo.ToList();

            Lp_LIST.Items.Clear();
            for (int i = 0; i < f.Count; i++)
            {
                Lp_LIST.Items.Add(f[i], true);
            }

            Lp_LIST.Refresh();
        }
        private int GetNo(string zh)
        {
            int specieNo = GameStringsZh.Species.Skip(1).
                 Select((s, index) => new { Species = s, Index = index + 1 })
                .Where(s => zh.Contains(s.Species)).
                OrderByDescending(s => s.Species.Length).
                FirstOrDefault()?.Index ?? -1;
            return specieNo;
        }

        private void Recover_BTN_Click(object sender, EventArgs e)
        {
            if (lp.Count == 0)
            {
                MessageBox.Show("没有可复原列表！");
                return;
            }
            Lp_LIST.Items.Clear();
            for (int i = 0; i < lp.Count; i++)
            {
                Lp_LIST.Items.Add(lp[i], true);
            }
            Lp_LIST.Refresh();
        }
    }
}
