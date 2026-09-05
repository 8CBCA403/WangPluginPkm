using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using PKHeX.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    public class SimpleEditorPlugin : WangPluginPkm
    {
        private static readonly HttpClient HttpClient = new();
        public override string Name => "常用功能/Simple Editor";
        public override int Priority => 13;
        public static GameStrings GameStringsZh = GameInfo.GetStrings(PluginLocalization.Language);
        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            AddCheckerToList();
        }
        private void OpenForm(object sender, EventArgs e)
        {

            var form = new SimpleEditor(SaveFileEditor, PKMEditor);
            form.Show();
        }
        private void AddCheckerToList()
        {
            var menuVSD = (ContextMenuStrip)((dynamic)SaveFileEditor).menu.mnuVSD;
            menuVSD.Opening += (s, e) =>
            {
                for (int i = menuVSD.Items.Count - 1; i >= 0; i--)
                {
                    if (!menuVSD.Items[i].Name.StartsWith("WangPluginPkm.", StringComparison.Ordinal))
                        continue;
                    var stale = menuVSD.Items[i];
                    menuVSD.Items.RemoveAt(i);
                    stale.Dispose();
                }
                var info = GetSenderInfo(ref s!);
                if ( info.ReadCurrent().Species != (int)Species.None && info.CanWriteTo())
                {
                    ToolStripMenuItem insertSlotButton = new ToolStripMenuItem(PluginLocalization.Translate("在此处插空"));
                    insertSlotButton.Image = Properties.Resources.Down;
                    menuVSD.Items.Add(insertSlotButton);
                    insertSlotButton.Click += (s, e) =>
                         InsertSlot(SaveFileEditor.CurrentBox, info.Slot.Slot);
                    var pk = info.Slot.Read(SaveFileEditor.SAV);
                    var la = new LegalityAnalysis(pk);
                    var ATKIVEV = new ToolStripMenuItem(PluginLocalization.Translate("物攻手"));
                    var SPAIVEV = new ToolStripMenuItem(PluginLocalization.Translate("特攻手"));
                    var ATK_0SPEIVEV = new ToolStripMenuItem(PluginLocalization.Translate("物攻0速"));
                    var SPA_0SPEIVEV = new ToolStripMenuItem(PluginLocalization.Translate("特攻0速"));
                    var TANKIVEV = new ToolStripMenuItem(PluginLocalization.Translate("坦克"));
                    var IVEVN = new ToolStripMenuItem(PluginLocalization.Translate("快捷三维编辑器"));
                    var SavePDF = new ToolStripMenuItem(PluginLocalization.Translate("打印检测报告PDF"));
                    var clearnick = new ToolStripMenuItem(PluginLocalization.Translate("清除昵称垃圾字节"));
                    var changeid = new ToolStripMenuItem(PluginLocalization.Translate("把id由PKHeX改成存档id(仅适用于SV)"));
                    insertSlotButton.Name = "WangPluginPkm.InsertSlot";
                    IVEVN.Name = "WangPluginPkm.QuickStats";
                    SavePDF.Name = "WangPluginPkm.LegalityPdf";
                    clearnick.Name = "WangPluginPkm.ClearNicknameTrash";
                    changeid.Name = "WangPluginPkm.ApplySaveId";
                    IVEVN.Image = Properties.Resources.Atom;
                    SavePDF.Image = Properties.Resources.Report;
                    clearnick.Image = Properties.Resources.TrashCan;
                    if (SaveFileEditor.SAV.Version is GameVersion.SL or GameVersion.VL)
                        changeid.Image = Properties.Resources.Transfer;
                    menuVSD.Items.Insert(menuVSD.Items.Count, IVEVN);
                    menuVSD.Items.Insert(menuVSD.Items.Count, SavePDF);
                    menuVSD.Items.Insert(menuVSD.Items.Count, clearnick);
                    if (SaveFileEditor.SAV.Version is GameVersion.SL or GameVersion.VL)
                        menuVSD.Items.Insert(menuVSD.Items.Count, changeid);
                    IVEVN.DropDownItems.Add(ATKIVEV);
                    IVEVN.DropDownItems.Add(SPAIVEV);
                    IVEVN.DropDownItems.Add(ATK_0SPEIVEV);
                    IVEVN.DropDownItems.Add(SPA_0SPEIVEV);
                    IVEVN.DropDownItems.Add(TANKIVEV);
                    SavePDF.Click += async (s, e) =>
                    {
                        try
                        {
                            await CreatePdfAsync(la.Report(true), pk);
                            global::WangPluginPkm.PluginMessageBox.Show("已生成合法检测报告");
                        }
                        catch (Exception ex)
                        {
                            global::WangPluginPkm.PluginMessageBox.Show($"生成检测报告失败：{ex.Message}");
                        }
                    };
                    clearnick.Click += (s, e) =>
                    {
                        info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.Clearnike(pk));
                    };
                    if (SaveFileEditor.SAV.Version is GameVersion.SL or GameVersion.VL)
                        changeid.Click += (s, e) =>
                        {
                            info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.cid((PK9)pk, SaveFileEditor));
                        };
                    ATKIVEV.Click += (s, e) =>
                    {
                        info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.ATKIVEV(pk));
                    };
                    SPAIVEV.Click += (s, e) =>
                    {
                        info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.SPAIVEV(pk));
                    };
                    ATK_0SPEIVEV.Click += (s, e) =>
                    {
                        info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.ATK_0SPEIVEV(pk));
                    };
                    SPA_0SPEIVEV.Click += (s, e) =>
                    {
                        info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.SPA_0SPEIVEV(pk));
                    };
                    TANKIVEV.Click += (s, e) =>
                    {
                        info.Slot.WriteTo(SaveFileEditor.SAV, CommonIVEVSetting.TANKIVEV(pk));
                    };
                    ToolStripItem[] transientItems = [insertSlotButton, IVEVN, SavePDF, clearnick, changeid];
                    void Cleanup(object _, ToolStripDropDownClosingEventArgs __)
                    {
                        foreach (var item in transientItems)
                            menuVSD.Items.Remove(item);
                        menuVSD.Closing -= Cleanup;
                    }
                    menuVSD.Closing += Cleanup;
                }
            };
        }

#nullable enable
        private static SlotViewInfo<PictureBox> GetSenderInfo(ref object sender)
        {
            var pb = GetUnderlyingControl<PictureBox>(sender);
            if (pb == null)
                throw new InvalidCastException("Unable to find PictureBox");
            var view = FindFirstControlOfType<ISlotViewer<PictureBox>>(pb);
            if (view == null)
                throw new InvalidCastException("Unable to find View Parent");
            var loc = view.GetSlotData(pb);
            sender = pb;
            return new SlotViewInfo<PictureBox>(loc, view);
        }
        public static T? GetUnderlyingControl<T>(object sender) where T : class
        {
            while (true)
            {
                switch (sender)
                {
                    case T p:
                        return p;
                    case ToolStripItem { Owner: { } o }:
                        sender = o;
                        continue;
                    case ContextMenuStrip { SourceControl: { } s }:
                        sender = s;
                        continue;
                    default:
                        return default;
                }
            }
        }
        public static T? FindFirstControlOfType<T>(Control aParent) where T : class
        {
            while (true)
            {
                if (aParent is T t)
                    return t;

                if (aParent.Parent != null)
                    aParent = aParent.Parent;
                else
                    return null;
            }
        }
        private void InsertSlot(int boxNum, int slotNum)
        {
            int startIndex = boxNum * SaveFileEditor.SAV.BoxSlotCount + slotNum;
            int boxIndex = startIndex + 1;
            PKM currMon, nextMon;
            while (boxIndex < SaveFileEditor.SAV.SlotCount)
            {
                currMon = SaveFileEditor.SAV.GetBoxSlotAtIndex(boxIndex);
                if (currMon.Species == (int)Species.None) break;
                boxIndex++;
            }
            if (boxIndex == SaveFileEditor.SAV.SlotCount)
            {
                global::WangPluginPkm.PluginMessageBox.Show("没有空间！");
                return;
            }
            currMon = SaveFileEditor.SAV.GetBoxSlotAtIndex(startIndex);
            SaveFileEditor.SAV.SetBoxSlotAtIndex(SaveFileEditor.SAV.BlankPKM, startIndex);
            for (int index = startIndex + 1; index <= boxIndex; index++)
            {
                StorageSlotSource slotSource = SaveFileEditor.SAV.GetBoxSlotFlags(index);
                if (slotSource.IsOverwriteProtected()) continue;
                nextMon = SaveFileEditor.SAV.GetBoxSlotAtIndex(index);
                SaveFileEditor.SAV.SetBoxSlotAtIndex(currMon, index, EntityImportSettings.None);
                currMon = nextMon;
            }
            SaveFileEditor.ReloadSlots();
        }

        private static async Task CreatePdfAsync(string result, PKM p)
        {
            var config = PluginConfig.LoadConfig();
            string sp = p.Species.ToString().PadLeft(4, '0');
            string baseuri = $"{config.PokemonPicUrl}{sp}.png";
            Uri siteUri = new Uri(baseuri);
            string pluginDirectory = Path.Combine(AppContext.BaseDirectory, "Plugins", "WangPluginPkm");
            string reportsDirectory = Path.Combine(pluginDirectory, "Reports");
            Directory.CreateDirectory(reportsDirectory);
            string reportPath = Path.Combine(reportsDirectory, $"超王宝可梦合法性检测报告-{GameStringsZh.Species[p.Species]}{p.EncryptionConstant:X}.pdf");
            PdfFont f1 = PdfFontFactory.CreateFont(Path.Combine(pluginDirectory, "simkai.ttf"));
            using PdfWriter writer = new(reportPath);
            using PdfDocument pdf = new(writer);
            using Document document = new(pdf);
            Paragraph header1 = new Paragraph($"超王宝可梦合法性检测报告")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20).SetFont(f1);
            Paragraph header2 = new Paragraph($"--------{p.OriginalTrainerName}的{GameStringsZh.Species[p.Species]}")
               .SetTextAlignment(TextAlignment.RIGHT)
               .SetFontSize(20).SetFont(f1);
            Paragraph subheader = new Paragraph($"SuperWang检测时间:北京时间" +
                $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture)}")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(15).SetFont(f1);
            LineSeparator ls = new LineSeparator(new SolidLine());
            Paragraph content = new Paragraph($"{result}")
                .SetTextAlignment(TextAlignment.LEFT).SetFontSize(12).SetFont(f1);
            ImageData imageData = ImageDataFactory.Create(ImageToByte(Properties.Resources.SuperWang));
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData).ScaleAbsolute(100, 100).SetFixedPosition(1, 450, 45);
            ImageData imageData1 = ImageDataFactory.Create(ImageToByte(await LoadImage(siteUri)));
            iText.Layout.Element.Image image1 = new iText.Layout.Element.Image(imageData1).ScaleAbsolute(200, 200).SetFixedPosition(1, 380, 485);
            document.Add(image1);
            document.Add(image);
            document.Add(header1);
            document.Add(header2);
            document.Add(subheader);
            document.Add(ls);
            document.Add(content);
        }
        public static byte[]? ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            var result = converter.ConvertTo(img, typeof(byte[])) as byte[];
            return result;
        }
        public static async Task<Bitmap> LoadImage(Uri uri)
        {
            Bitmap bitmapImage = new(Properties.Resources.SuperWang);
            try
            {
                using var response = await HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                using Bitmap downloaded = new(responseStream);
                return new Bitmap(downloaded);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("下载图片失败: {0}", ex.Message);
            }
            return bitmapImage;
        }

#nullable disable



    }
}
