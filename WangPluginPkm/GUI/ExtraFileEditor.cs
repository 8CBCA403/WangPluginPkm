using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Buffers.Binary.BinaryPrimitives;

namespace WangPluginPkm.GUI
{
    partial class ExtraFileEditor : Form
    {
        private ISaveFileProvider SAV { get; }
        private IPKMView Editor { get; }
        private WC9 SWC9;
        private GP1M gp = new();
        private GP1 gpm = new();
        public static GameStrings GameStringsZh = GameInfo.GetStrings("zh-Hans");
        private const string GoFilter = "Go Park Entity |*.gp1|All Files|*.*";
        private const string PK8Filter = "SWSH/PLA pokemon file |*.pb8|*.pa8|All Files|*.*";
        private const string PA8Filter = "PLA file |*.pa8|All Files|*.*";
        private WC9[] MGDB_G9;
        private static WC9[] GetWC9DB(ReadOnlySpan<byte> bin) => Get(bin, WC9.Size, static d => new WC9(d));
        private static T[] Get<T>(ReadOnlySpan<byte> bin, int size, Func<byte[], T> ctor)
        {
            var result = new T[bin.Length / size];
            Debug.Assert(result.Length * size == bin.Length);
            for (int i = 0; i < result.Length; i++)
            {
                var offset = i * size;
                var slice = bin.Slice(offset, size).ToArray();
                result[i] = ctor(slice);
            }
            return result;
        }
        private GenderType Gtype = GenderType.None;
        enum GenderType
        {
            NULL,
            Male,
            Female,
            None,
        }
        public ExtraFileEditor(ISaveFileProvider sav, IPKMView editor)
        {
            SAV = sav;
            Editor = editor;
            InitializeComponent();
            BindingData();
        }

        private void BindingData()
        {
            this.GenderBox.DataSource = Enum.GetNames(typeof(GenderType));
            this.GenderBox.SelectedIndexChanged += (_, __) =>
            {
                Gtype = (GenderType)Enum.Parse(typeof(GenderType), this.GenderBox.SelectedItem.ToString(), false);
            };
            this.GenderBox.SelectedIndex = 0;
        }
        private void ImportGP1From(string path)
        {
            var data = File.ReadAllBytes(path);
            if (data.Length != GP1.SIZE)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);
                return;
            }
            var gp1 = new GP1M();
            data.CopyTo(gp1.Data, 0);
            data.CopyTo(gpm.Data.ToArray(), 0);
            gp = gp1;
        }
        private void EditGP(GP1M pk)
        {
            byte a = 0;
            byte b = 0;
            SpeciesName.TryGetSpecies(SpeciesBox.Text, 9, out ushort s);
            pk.Species = s;
            gp.Username1 = OriginalTrainerName.Text;
            ushort Move1 = (ushort)Array.IndexOf(GameInfo.Strings.movelist, Move1_TextBox.Text);
            ushort Move2 = (ushort)Array.IndexOf(GameInfo.Strings.movelist, Move2_TextBox.Text);
            //gp.Username2 = OName.Text;
            gp.Nickname = NickNameBox.Text;
            gp.IV_HP = Convert.ToInt16(HP_TextBox.Text);
            gp.IV_ATK = Convert.ToInt16(Atk_TextBox.Text);
            gp.IV_DEF = Convert.ToInt16(Def_TextBox.Text);
            gp.Gender = GenderBox.SelectedIndex;
            gp.Move1 = Move1;
            gp.Move2 = Move2;
            gp.CP = Convert.ToInt16(CP_TextBox.Text);
            gp.Date = Convert.ToInt32(MetDate_TextBox.Text);
            if (ShinyCheck.Checked)
                a = 1;
            gp.IsShiny = a;
            if (AlolaForm_Check.Checked)
                b = 1;
            gp.Form = b;
            gp = pk;

        }
        private void ImportGP_BTN_Click(object sender, EventArgs e)
        {

            using var sfd = new OpenFileDialog
            {
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            // Export
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            ImportGP1From(path);
            var Name = SpeciesName.GetSpeciesName(gp.Species, 9);
            var Move1 = ParseSettings.GetMoveName(gp.Move1);
            var Move2 = ParseSettings.GetMoveName(gp.Move2);
            SpeciesBox.Text = Name;
            NickNameBox.Text = gp.Nickname;
            OriginalTrainerName.Text = gp.Username1;
            //OName.Text = gp.Username2;
            HP_TextBox.Text = gp.IV_HP.ToString();
            Atk_TextBox.Text = gp.IV_ATK.ToString();
            Def_TextBox.Text = gp.IV_DEF.ToString();
            Move1_TextBox.Text = Move1;
            Move2_TextBox.Text = Move2;
            CP_TextBox.Text = gp.CP.ToString();
            GenderBox.SelectedIndex = gp.Gender % 4;
            MetDate_TextBox.Text = gp.Date.ToString();
            GeoName_TextBox.Text = gp.GeoCityName;
            if (gp.IsShiny == 1)
                ShinyCheck.Checked = true;
            else
                ShinyCheck.Checked = false;
            if (gp.Form == 1)
                AlolaForm_Check.Checked = true;
            else
                AlolaForm_Check.Checked = false;
        }

        private void ExportGP_BTN_Click(object sender, EventArgs e)
        {
            var data = gp;
            using var sfd = new SaveFileDialog
            {
                FileName = data.FileName,
                Filter = GoFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes(sfd.FileName, data.Data);
        }

        private void Edit_GP_Click(object sender, EventArgs e)
        {
            EditGP(gp);
        }

        private void CovertToPB7_Click(object sender, EventArgs e)
        {
            PB7 pkm;
            pkm = gpm.ConvertToPKM(SAV.SAV);
            Editor.PopulateFields(pkm, false);
            SAV.ReloadSlots();
        }

        private void CovertToPK8_Click(object sender, EventArgs e)
        {
            using var sfd = new OpenFileDialog
            {
                Filter = PK8Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string path = sfd.FileName;
            var pk = ImportPKFrom(path);
            Editor.PopulateFields(pk, false);
            SAV.ReloadSlots();
        }
        private PKM ImportPKFrom(string path)
        {
            PKM pkm = Editor.Data;
            var data = File.ReadAllBytes(path);
            string extension = Path.GetExtension(path);
            if (data.Length != 344 || data.Length != 376)
            {
                MessageBox.Show(MessageStrings.MsgFileLoadIncompatible);

            }
            switch (extension)
            {
                case "pk8":
                    pkm = new PK8(data);
                    break;
                case "pb8":
                    pkm = new PB8(data);
                    break;
                case "pa8":
                    pkm = new PA8(data);
                    break;
            }
            return pkm;
        }

        private void LoadEH1_BTN_Click(object sender, EventArgs e)
        {
            List<PKM> PK = new();
            var i = 0;
            DialogResult dr = this.OpenFile_Dialog.ShowDialog();
            int BOX = Int16.Parse(BOX_TextBox.Text) - 1;
            if (dr == DialogResult.OK)
            {
                foreach (System.String file in OpenFile_Dialog.FileNames)
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
        private void ConvertPKM(string file, int n, ref List<PKM> p)
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
                if (HomeCrypto.GetIsEncrypted(ek1, 1))
                    return new PKH(ek1);
            }
            return null;
        }

        private void LoadPA8_BTN_Click(object sender, EventArgs e)
        {
            using var sfd = new OpenFileDialog
            {
                Filter = PA8Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };
            // Export
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;
            var data = File.ReadAllBytes(path);

            var chs = CalculateChecksum(data);
            WriteUInt16LittleEndian(data.AsSpan(0x06), chs);
            var pk = PokeCrypto.EncryptArray8A(data);

            using var sfds = new SaveFileDialog
            {
                FileName = "test",
                Filter = PA8Filter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes("test.pa8", pk);
        }
        private ushort CalculateChecksum(byte[] Data)
        {
            ushort chk = 0;
            for (int i = 8; i < 360; i += 2)
                chk += ReadUInt16LittleEndian(Data.AsSpan(i));
            return chk;
        }
        public static byte[] GetBinary(FileStream resource)
        {

            if (resource is null)
                return [];

            var buffer = new byte[resource.Length];
            resource.ReadExactly(buffer);
            return buffer;
        }
        private void import_BTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "选择文件",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "pkl文件|*.pkl|单个wc9文件|*.wc9|所有文件|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;

                try
                {
                    using (FileStream resource = File.OpenRead(selectedFileName))
                    {
                        byte[] rawDB = GetBinary(resource);
                        if (rawDB != null && rawDB.Length > 0)
                        {
                            if (selectedFileName.EndsWith(".pkl", StringComparison.OrdinalIgnoreCase))
                            {
                                // 处理为 WC9 集合
                                MGDB_G9 = GetWC9DB(rawDB); // 将 byte[] 转换为 WC9 对象列表
                                if (MGDB_G9 != null && MGDB_G9.Length > 0)
                                {
                                    PKL_CLB.DataSource = MGDB_G9;
                                    PKL_CLB.DisplayMember = "CardID";
                                    PKL_CLB.ValueMember = "CardID";
                                }
                                else
                                {
                                    MessageBox.Show("无法解析所选文件，请检查文件内容是否正确！");
                                }
                            }
                            else if (selectedFileName.EndsWith(".wc9", StringComparison.OrdinalIgnoreCase))
                            {
                                // 处理为单个 WC9 文件
                                WC9 singleWC9 = new(rawDB); // 假设 ParseSingleWC9 方法用于解析单个 WC9 文件
                                SWC9 = singleWC9;
                                if (singleWC9 != null)
                                {
                                    // 将单个对象放入列表中，以便于显示
                                    M_ID.Text = singleWC9.CardTitleIndex.ToString();
                                    Header_TB.Text = singleWC9.CardHeader.ToString();
                                    Tittle_TB.Text = singleWC9.CardTitle.ToString();
                                    OT_TB.Text = singleWC9.GetOT(SAV.SAV.Language).ToString();
                                    SP_TB.Text = GameStringsZh.Species[singleWC9.Species];
                                }
                                else
                                {
                                    MessageBox.Show("无法解析所选文件，请检查文件内容是否正确！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("不支持的文件类型！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("所选文件为空或无法读取，请确认文件是否损坏！");
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("无法访问文件，请确保你有足够的权限读取该文件。");
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"文件读取出错：{ex.Message}");
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"文件格式不正确：{ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"发生未知错误：{ex.Message}");
                }
            }
        }

        private void PKL_CLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            M_ID.Text = MGDB_G9[PKL_CLB.SelectedIndex].CardTitleIndex.ToString();
            Header_TB.Text = MGDB_G9[PKL_CLB.SelectedIndex].CardHeader.ToString();
            Tittle_TB.Text = MGDB_G9[PKL_CLB.SelectedIndex].CardTitle.ToString();
            OT_TB.Text = MGDB_G9[PKL_CLB.SelectedIndex].GetOT(SAV.SAV.Language).ToString();
            SP_TB.Text = GameStringsZh.Species[MGDB_G9[PKL_CLB.SelectedIndex].Species];

        }

        private void ADD_BTN_Click(object sender, EventArgs e)
        {

        }

    }
}
