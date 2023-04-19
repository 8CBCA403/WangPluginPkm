using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;
using PKHeX.Core;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas.Draw;
using PKHeX.Core.AutoMod;
using iText.IO.Image;
using System.Drawing;
using iText.Kernel.Font;
using iText.IO.Font;
using System.Globalization;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using System.IO;
using Org.BouncyCastle.Bcpg.Sig;

namespace WangPluginPkm.Plugins
{
    internal class SimpleEditorPlugin: WangPluginPkm
    {
        public override string Name => "常用功能/Simple Editor";
        public override int Priority => 11;
        public static GameStrings GameStringsZh = GameInfo.GetStrings("zh");
        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.pokeball
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "常用功能/Simple Editor";
            modmenu.DropDownItems.Add(ctrl);
            AddCheckerToList();

        }
        private void AddCheckerToList()
        {
            var menuVSD = (ContextMenuStrip)((dynamic)SaveFileEditor).menu.mnuVSD;
            var ATKIVEV = new ToolStripMenuItem("物攻手");
            var SPAIVEV = new ToolStripMenuItem("特攻手");
            var ATK_0SPEIVEV = new ToolStripMenuItem("物攻0速");
            var SPA_0SPEIVEV = new ToolStripMenuItem("特攻0速");
            var TANKIVEV = new ToolStripMenuItem("坦克");
            menuVSD.Opening += (s, e) =>
            {
                var info = GetSenderInfo(ref s!);
                var pk = info.Slot.Read(SaveFileEditor.SAV);
                var la = new LegalityAnalysis(pk);
                var result = la.Results;
                var IVEVN = new ToolStripMenuItem("快捷三维编辑器");
                var SavePDF = new ToolStripMenuItem("打印检测报告PDF");
                IVEVN.Image = Properties.Resources.Atom;
                SavePDF.Image = Properties.Resources.Report;
                menuVSD.Items.Insert(menuVSD.Items.Count, IVEVN);
                menuVSD.Items.Insert(menuVSD.Items.Count, SavePDF);
                SavePDF.Click += (s, e) => { pdf(la.Report(true),pk); };
                IVEVN.DropDownItems.Add(ATKIVEV);
                IVEVN.DropDownItems.Add(SPAIVEV);
                IVEVN.DropDownItems.Add(ATK_0SPEIVEV);
                IVEVN.DropDownItems.Add(SPA_0SPEIVEV);
                IVEVN.DropDownItems.Add(TANKIVEV);
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
                menuVSD.Closing += (s, e) => menuVSD.Items.Remove(IVEVN);
                menuVSD.Closing += (s, e) => menuVSD.Items.Remove(SavePDF);
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
        private static void pdf(string result,PKM p )
        {
           
            PdfFont f1 = PdfFontFactory.CreateFont(Properties.Resources.simkai,PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            PdfWriter writer = new PdfWriter($"超王宝可梦合法性检测报告-{GameStringsZh.Species[p.Species]}{p.EncryptionConstant:X}.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header1 = new Paragraph($"超王宝可梦合法性检测报告")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20).SetFont(f1);
            Paragraph header2 = new Paragraph($"--------{p.OT_Name}的{GameStringsZh.Species[p.Species]}")
               .SetTextAlignment(TextAlignment.RIGHT)
               .SetFontSize(20).SetFont(f1);
            Paragraph subheader = new Paragraph($"SuperWang检测时间:北京时间" +
                $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff",CultureInfo.InvariantCulture)}")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(15).SetFont(f1);
            LineSeparator ls = new LineSeparator(new SolidLine());
            Paragraph content = new Paragraph($"{result}")
                .SetTextAlignment(TextAlignment.LEFT) .SetFontSize(12).SetFont(f1);
            //Paragraph time = new Paragraph($"\n\n\n\n\n检测时间:北京时间{ DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff",
            //                   CultureInfo.InvariantCulture) }").SetTextAlignment(TextAlignment.RIGHT).SetFontSize(12).SetFont(f1);
            ImageData imageData = ImageDataFactory.Create(ImageToByte(Properties.Resources.SuperWang));
            iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData).ScaleAbsolute(100, 100).SetFixedPosition(1, 450, 45);
            document.Add(image);
            document.Add(header1);
            document.Add(header2);
            document.Add(subheader);
            document.Add(ls);
            document.Add(content);
          //document.Add(time);
            document.Close();
       /*   
            PdfDocument backgroundDocument = new PdfDocument(new PdfReader(@"OIP.pdf"));
            PdfDocument pdfDocument = new PdfDocument(new PdfReader($"temp.pdf"),
            new PdfWriter($"超王宝可梦合法性检测报告-{GameStringsZh.Species[p.Species]}.pdf"));
            PdfFormXObject backgroundXObject = backgroundDocument.GetPage(1).CopyAsFormXObject(pdfDocument);
            PdfPage page = pdfDocument.GetPage(1);
            PdfStream stream = page.NewContentStreamBefore();
            new PdfCanvas(stream, page.GetResources(), pdfDocument).AddXObjectAt(backgroundXObject, 0, 0);
            pdfDocument.Close();
            backgroundDocument.Close();
       */
            MessageBox.Show("已生成合法检测报告");
        }
   
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            var result = (byte[])converter.ConvertTo(img, typeof(byte[]));
            return result;
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
#nullable disable
       
        private void OpenForm(object sender, EventArgs e)
        {

            var form = new SimpleEditor(SaveFileEditor,PKMEditor);
            form.Show();
        }
    }
}
