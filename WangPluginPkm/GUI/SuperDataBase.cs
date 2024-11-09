using PKHeX.Core;
using PKHeX.Core.AutoMod;
using PKHeX.Core.Enhancements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using WangPluginPkm.PluginUtil.ModifyPKM;

namespace WangPluginPkm.GUI
{
    public partial class SuperDataBase : Form
    {
        public static GameStrings GameStringsZh = GameInfo.GetStrings("zh-Hans");
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }

        private static List<litePK> lp = new List<litePK>();

        private List<string> EditType = new List<string>();

        public SuperDataBase(ISaveFileProvider sav, IPKMView editor)
        {

            InitializeComponent();
            SAV = sav;
            Editor = editor;
            BindingData();
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
            // Set DataSource once for both ComboBoxes
            SNA_CB.DataSource = GameStringsZh.Natures.ToArray();
            Tera_CB.DataSource = GameStringsZh.Types.ToArray();

            // Enable or disable based on generation
            SNA_CB.Enabled = SAV.SAV.Generation >= 8;
            Tera_CB.Enabled = SAV.SAV.Generation == 9;
            var moveComboBoxes = new[] { MOV1_CB, MOV2_CB, MOV3_CB, MOV4_CB };
            var moveDataSources = new[] { MOV1, MOV2, MOV3, MOV4 };

            for (int i = 0; i < moveComboBoxes.Length; i++)
            {
                moveComboBoxes[i].DataSource = moveDataSources[i];
                moveComboBoxes[i].AutoCompleteCustomSource = auto(moveDataSources[i]);
            }

            var remComboBoxes = new[] { REM1_CB, REM2_CB, REM3_CB, REM4_CB };
            var remDataSources = new[] { REV1, REV2, REV3, REV4 };

            for (int i = 0; i < remComboBoxes.Length; i++)
            {
                remComboBoxes[i].DataSource = remDataSources[i];
                remComboBoxes[i].AutoCompleteCustomSource = auto(remDataSources[i]);
            }

            // 设置其余 ComboBox 的数据源和自动完成源
            AB_CB.DataSource = GameStringsZh.Ability;
            AB_CB.AutoCompleteCustomSource = auto(GameStringsZh.Ability.ToArray());

            IT_CB.DataSource = GameStringsZh.Item;
            IT_CB.AutoCompleteCustomSource = auto(GameStringsZh.Item.ToArray());

            BA_CB.DataSource = GameStringsZh.balllist;
            BA_CB.AutoCompleteCustomSource = auto(GameStringsZh.balllist.ToArray());

            LA_CB.DataSource = Enum.GetNames(typeof(LanguageID));
            Filter_CB.DataSource = Enum.GetValues(typeof(Filter));

            // 初始化 EditType 列表
            EditType.AddRange(new[]
            {
        "性格", "特性", "持有物", "球种", "语言", "形态", "个体值", "努力值", "技能", "遗传技能", "等级"
    });

            // 根据世代条件添加特定项
            if (SAV.SAV.Generation >= 8)
                EditType.Add("薄荷性格");
            if (SAV.SAV.Generation == 9)
                EditType.Add("太晶属性");

            // 设置 DataSource 并选中所有项目
            RunFilter_CLB.DataSource = EditType;
            for (int i = 0; i < RunFilter_CLB.Items.Count; i++)
            {
                RunFilter_CLB.SetItemChecked(i, true);
            }
        }
            private void import_editor_BTN_Click(object sender, EventArgs e)
        {
            SP_CB.SelectedIndex = Editor.Data.Species;
            NA_CB.SelectedIndex = (int)Editor.Data.Nature;
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
            switch (SAV.SAV.Generation)
            {
                case 8:
                    SNA_CB.SelectedIndex = (int)((PK8)Editor.Data).StatNature;
                    break;
                case 9:
                    SNA_CB.SelectedIndex = (int)((PK9)Editor.Data).StatNature;
                    if ((int)((PK9)Editor.Data).TeraType == 99)
                        Tera_CB.SelectedIndex = 18;
                    else
                        Tera_CB.SelectedIndex = (int)((PK9)Editor.Data).TeraType;
                    break;
                default:
                    break;
            }
            this.Lp_LIST.DisplayMember = "Name";
            Level_NUM.Value = Editor.Data.CurrentLevel;
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
                CurrentLevel = (int)Level_NUM.Value
            };
            switch (SAV.SAV.Generation)
            {
                case 8:
                    lp.StatNature = SNA_CB.SelectedIndex;
                    break;
                case 9:
                    lp.StatNature = SNA_CB.SelectedIndex;
                    if (Tera_CB.SelectedIndex == 18)
                        lp.TeraType = 99;
                    else
                        lp.TeraType = Tera_CB.SelectedIndex;
                    break;
                default:
                    break;
            }

            return lp;
        }
        private List<litePK> savpklist(string s)
        {
            List<litePK> lt = new();
            int[] mov = new int[4];
            int[] remov = new int[4];
            var STarray = "";
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
                if (lpsarray.Length > 5)
                {
                    STarray = lpsarray[5];
                    var st = STarray.Split(',');
                    switch (SAV.SAV.Generation)
                    {
                        case 8:
                            lp.StatNature = Int32.Parse(st[0]);
                            break;
                        case 9:
                            lp.StatNature = Int32.Parse(st[0]);
                            lp.TeraType = Int32.Parse(st[1]);
                            break;
                        default:
                            break;
                    }
                }
                if (baselps.Length < 10)
                    lp.CurrentLevel = 1;
                else
                {
                    lp.CurrentLevel = Int32.Parse(baselps[9]);
                }
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
                Level_NUM.Value = ((litePK)lp).CurrentLevel;
                switch (SAV.SAV.Generation)
                {
                    case 8:
                        SNA_CB.SelectedIndex = ((litePK)lp).StatNature;
                        break;
                    case 9:
                        SNA_CB.SelectedIndex = ((litePK)lp).StatNature;
                        if (((litePK)lp).TeraType == 99)
                            Tera_CB.SelectedIndex = 18;
                        else
                            Tera_CB.SelectedIndex = ((litePK)lp).TeraType;
                        break;
                    default:
                        break;
                }
                var config = PluginConfig.LoadConfig();
                string baseuri = $"{config.PokemonPicUrl}" + $"{((litePK)lp).Species.ToString().PadLeft(4, '0')}" + ".png";
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
            ModifyBoxes(mod, SAV.SAV.Generation, (int)StartBox_NUM.Value - 1, (int)Start_NUM.Value - 1, (int)EndBox_NUM.Value - 1, (int)End_NUM.Value - 1);
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
                if (pk.Species == litePKs[i].Species && pk.Form == litePKs[i].Form)
                {
                    for (int j = 0; j < RunFilter_CLB.Items.Count; j++)
                    {
                        if (RunFilter_CLB.GetItemChecked(j))
                            switch (j)
                            {
                                case 0:
                                    {
                                        pk.Nature = (Nature)litePKs[i].Nature;
                                    }
                                    break;
                                case 1:
                                    {
                                        pk.Ability = litePKs[i].Ability;
                                        pk.AbilityNumber = (int)litePKs[i].AbilityNumber;
                                    }
                                    break;
                                case 2:
                                    {
                                        pk.HeldItem = litePKs[i].HeldItem;
                                    }
                                    break;
                                case 3:
                                    {
                                        pk.Ball = (byte)litePKs[i].Ball;
                                    }
                                    break;
                                case 4:
                                    {
                                        pk.Language = litePKs[i].Language;
                                        pk.ClearNickname();
                                    }
                                    break;
                                case 5:
                                    {
                                        pk.Form = (byte)litePKs[i].Form;
                                    }
                                    break;
                                case 6:
                                    {
                                        pk.IV_HP = litePKs[i].IVS[0];
                                        pk.IV_ATK = litePKs[i].IVS[1];
                                        pk.IV_DEF = litePKs[i].IVS[2];
                                        pk.IV_SPA = litePKs[i].IVS[3];
                                        pk.IV_SPD = litePKs[i].IVS[4];
                                        pk.IV_SPE = litePKs[i].IVS[5];
                                    }
                                    break;
                                case 7:
                                    {
                                        pk.EV_HP = litePKs[i].EVS[0];
                                        pk.EV_ATK = litePKs[i].EVS[1];
                                        pk.EV_DEF = litePKs[i].EVS[2];
                                        pk.EV_SPA = litePKs[i].EVS[3];
                                        pk.EV_SPD = litePKs[i].EVS[4];
                                        pk.EV_SPE = litePKs[i].EVS[5];
                                    }
                                    break;
                                case 8:
                                    {
                                        pk.Move1 = (ushort)litePKs[i].Move1;
                                        pk.Move2 = (ushort)litePKs[i].Move2;
                                        pk.Move3 = (ushort)litePKs[i].Move3;
                                        pk.Move4 = (ushort)litePKs[i].Move4;
                                        pk.HealPP();
                                    }
                                    break;
                                case 9:
                                    {
                                        if (pk.WasEgg)
                                        {
                                            pk.RelearnMove1 = (ushort)litePKs[i].RelearnMove1;
                                            pk.RelearnMove2 = (ushort)litePKs[i].RelearnMove2;
                                            pk.RelearnMove3 = (ushort)litePKs[i].RelearnMove3;
                                            pk.RelearnMove4 = (ushort)litePKs[i].RelearnMove4;
                                        }
                                    }
                                    break;
                                case 10:
                                    {
                                        pk.CurrentLevel = (byte)litePKs[i].CurrentLevel;

                                    }
                                    break;
                                case 11:
                                    {

                                        pk.StatNature = (Nature)litePKs[i].StatNature;
                                    }
                                    break;
                                case 12:
                                    {
                                        ((PK9)pk).TeraTypeOverride = (MoveType)litePKs[i].TeraType;
                                    }
                                    break;

                                default:
                                    break;
                            }
                    }
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
            pk.CurrentLevel = (int)Level_NUM.Value;
            switch (SAV.SAV.Generation)
            {
                case 8:
                    pk.StatNature = SNA_CB.SelectedIndex;
                    break;
                case 9:
                    pk.StatNature = SNA_CB.SelectedIndex;
                    if (Tera_CB.SelectedIndex == 18)
                        pk.TeraType = 99;
                    else
                        pk.TeraType = Tera_CB.SelectedIndex;
                    break;
                default:
                    break;
            }
            Lp_LIST.SetItemChecked(index, true);
            MessageBox.Show("修改完成！");
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
        public int ModifyBoxes(Action<PKM> action, int gen, int BoxStart = 0, int slotStart = 0, int BoxEnd = -1, int slotEnd = -1)
        {
            if ((uint)BoxEnd >= SAV.SAV.BoxCount)
            {
                BoxEnd = SAV.SAV.BoxCount - 1;
            }

            Span<byte> boxBuffer = GetInfo(gen);
            int num = 0;
            for (int i = BoxStart; i <= BoxEnd; i++)
            {
                for (int j = slotStart; j <= slotEnd; j++)
                {
                    if (!SAV.SAV.IsBoxSlotOverwriteProtected(i, j))
                    {
                        int boxSlotOffset = SAV.SAV.GetBoxSlotOffset(i, j);
                        int num2 = boxSlotOffset;
                        Span<byte> span = boxBuffer.Slice(num2, boxBuffer.Length - num2);
                        if (SAV.SAV.IsPKMPresent(span))
                        {
                            PKM boxSlotAtIndex = SAV.SAV.GetBoxSlotAtIndex(i, j);
                            action(boxSlotAtIndex);
                            num++;
                            SAV.SAV.SetBoxSlot(boxSlotAtIndex, span, PKMImportSetting.Skip, PKMImportSetting.Skip);
                        }
                    }
                }
            }

            return num;
        }
       private  void Muticonvert(int startBox, int startSlot, int endBox, int endSlot)
        {
            for (int box = startBox; box <= endBox; box++)
            {
                int start = (box == startBox) ? startSlot : 0;
                int end = (box == endBox) ? endSlot : 29;

                for (int slot = start; slot <= end; slot++)
                {
                    Lp_LIST.Items.Add(convertpktolpk(SAV.SAV.GetBoxSlotAtIndex(box,slot)), true);
                    this.Lp_LIST.DisplayMember = "Name";
                }
            }
            Lp_LIST.Refresh();
        }
        public Span<byte> GetInfo(int gen)
        {
            Span<byte> boxbuffer = SAV.SAV.Data;
            switch (gen)
            {
                case 3:
                    boxbuffer = ((SAV3)SAV.SAV).Storage;
                    break;
                case 4:
                    boxbuffer = ((SAV4)SAV.SAV).Storage;
                    break;
                case 8:
                    boxbuffer = ((SAV8SWSH)SAV.SAV).BoxInfo.Data;
                    if (SAV.SAV.Version == GameVersion.PLA)
                        boxbuffer = ((SAV8LA)SAV.SAV).BoxInfo.Data;
                    break;
                case 9:
                    boxbuffer = ((SAV9SV)SAV.SAV).BoxInfo.Data;
                    break;
                default:
                    break;
            }
            return boxbuffer;
        }

        private void Load_PS_BTN_Click(object sender, EventArgs e)
        {
            Import(PS_Box.Text);

        }
        public void Import(string source)
        {
            if (ShowdownUtil.IsTeamBackup(source))
            {
                var teams = ShowdownTeamSet.GetTeams(source);
                var names = teams.Select(z => z.Summary);
                Import(teams.SelectMany(z => z.Team).ToList());
                return;
            }
            var sets = ShowdownUtil.ShowdownSets(source);
            Import(sets);
        }
        public void Import(IEnumerable<string> sets)
        {
            var entries = sets.Select(z => new ShowdownSet(z)).ToList();
            Import(entries);
        }
        public void Import(IReadOnlyList<ShowdownSet> sets, bool skipDialog = false)
        {
            int i = 0;
            if (sets.Count == 1)
            {
                var lp = ImportSetToTabs(sets[0], skipDialog);
                lp.Name = GameStringsZh.Species[lp.Species];
                Lp_LIST.Items.Add(lp, true);
                Lp_LIST.DisplayMember = "Name";
                Lp_LIST.Refresh();
            }
            else
            {
                var lpo = ImportToExisting(SAV.SAV, sets);
                foreach (var lp in lpo)
                {
                    i++;
                    lp.Name = GameStringsZh.Species[lp.Species] + $"{i}";
                    Lp_LIST.Items.Add(lp, true);
                    Lp_LIST.DisplayMember = "Name";
                }
                Lp_LIST.Refresh();
            }

        }
        private litePK ImportSetToTabs(ShowdownSet set, bool skipDialog = false)
        {
            var regen = new RegenTemplate(set, SAV.SAV.Generation);
            var sav = SAV.SAV;
            var legal = sav.GetLegalFromSet(regen).Created;
            return convertpktolpk(legal);

        }

        public List<litePK> ImportToExisting(SaveFile tr, IReadOnlyList<ShowdownSet> sets)
        {
            int num = 0;
            List<litePK> lp = new();
            for (int i = 0; i < sets.Count; i++)
            {
                ShowdownSet showdownSet = sets[i];
                RegenTemplate regenTemplate = new RegenTemplate(showdownSet, tr.Generation);
                PKM legalFromSet = tr.GetLegalFromSet(regenTemplate).Created;
                legalFromSet.ResetPartyStats();
                legalFromSet.SetBoxForm();
                num++;
                lp.Add(convertpktolpk(legalFromSet));
            }
            return lp;
        }
        public litePK convertpktolpk(PKM pk)
        {
            int[] iv = new int[6];
            iv[0] = pk.IV_HP;
            iv[1] = pk.IV_ATK;
            iv[2] = pk.IV_DEF;
            iv[3] = pk.IV_SPA;
            iv[4] = pk.IV_SPD;
            iv[5] = pk.IV_SPE;
            int[] ev = new int[6];
            ev[0] = pk.EV_HP;
            ev[1] = pk.EV_ATK;
            ev[2] = pk.EV_DEF;
            ev[3] = pk.EV_SPA;
            ev[4] = pk.EV_SPD;
            ev[5] = pk.EV_SPE;
            litePK lp = new()
            {
                Name = GameStringsZh.Species.ToArray()[pk.Species],
                Species = pk.Species,
                Nature = (int)pk.Nature,
                Ability = pk.Ability,
                AbilityNumber = pk.AbilityNumber,
                HeldItem = pk.HeldItem,
                Ball = pk.Ball,
                Language = pk.Language,
                Form = pk.Form,
                Move1 = pk.Move1,
                Move2 = pk.Move2,
                Move3 = pk.Move3,
                Move4 = pk.Move4,
                RelearnMove1 = pk.RelearnMove1,
                RelearnMove2 = pk.RelearnMove2,
                RelearnMove3 = pk.RelearnMove3,
                RelearnMove4 = pk.RelearnMove4,
                IVS = iv,
                EVS = ev,
                CurrentLevel = pk.CurrentLevel

            };
            switch (SAV.SAV.Generation)
            {
                case 8:
                    lp.StatNature = (int)((PK8)pk).StatNature;
                    break;
                case 9:
                    lp.StatNature = (int)((PK9)pk).StatNature;
                    lp.TeraType = (int)((PK9)pk).TeraType;
                    break;
                default:
                    break;
            }
            return lp;
        }

        private void PopulateFilteredDataSources(ITrainerInfo sav, bool force = false)
        {
            var source = GameInfo.FilteredSources;
            SetIfDifferentCount(source.Languages, LA_CB, force);

            if (sav.Generation >= 2)
            {
                var game = (GameVersion)sav.Version;
                SetIfDifferentCount(source.Items, IT_CB, force);
            }

            if (sav.Generation >= 3)
            {
                SetIfDifferentCount(source.Balls, BA_CB, force);
            }

            if (sav.Generation >= 4)
                SetIfDifferentCount(source.Abilities, AB_CB, force);


            SetIfDifferentCount(source.Species, SP_CB, force);

            // Set the Move ComboBoxes too.
            /*  LegalMoveSource.ChangeMoveSource(source.Moves);
              foreach (var cb in Relearn)
                  SetIfDifferentCount(source.Relearn, cb, force);
              foreach (var cb in Moves)
                  SetIfDifferentCount(source.Moves, cb.CB_Move, force);*/

        }
        private static void SetIfDifferentCount(IReadOnlyCollection<ComboItem> update, ComboBox exist, bool force = false)
        {
            if (!force && exist.DataSource is BindingSource b && b.Count == update.Count)
                return;
            exist.DataSource = new BindingSource(update, null);
            exist.DisplayMember = "Text";
        }

        private void SP_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            File_TB.Text = GameStringsZh.Species[SP_CB.SelectedIndex];
        }

        private void Pktopl_BTN_Click(object sender, EventArgs e)
        {

            Muticonvert((int)StartBox_NUM.Value - 1, (int)Start_NUM.Value - 1, (int)EndBox_NUM.Value - 1, (int)End_NUM.Value - 1);
            Lp_LIST.Refresh();
            MessageBox.Show($"{Lp_LIST.Items.Count}转换完成！");
        }
    }
}
