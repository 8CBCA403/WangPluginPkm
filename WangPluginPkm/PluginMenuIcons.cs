using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WangPluginPkm
{
    internal static class PluginMenuIcons
    {
        private static readonly Font BadgeFont = new("Segoe UI Symbol", 10, FontStyle.Bold, GraphicsUnit.Pixel);
        private const string IconMarker = "WangPluginPkm.MenuIcon";

        public static void Apply(ToolStripMenuItem root)
        {
            if (!Equals(root.Image?.Tag, IconMarker))
                root.Image = CreateBadge(Color.FromArgb(236, 154, 41), "W");
            foreach (ToolStripItem entry in root.DropDownItems)
            {
                if (entry is not ToolStripMenuItem item)
                    continue;
                if (Equals(item.Image?.Tag, IconMarker))
                    continue;
                var key = item.Name.Length == 0 ? item.Text : item.Name;
                item.Image = key switch
                {
                    var x when x.Contains("RNG", StringComparison.OrdinalIgnoreCase) => CreateRng(),
                    var x when x.Contains("Shiny", StringComparison.OrdinalIgnoreCase) || x.Contains("闪光") => CreateSparkle(),
                    var x when x.Contains("Egg", StringComparison.OrdinalIgnoreCase) || x.Contains("变蛋") => CreateEgg(),
                    var x when x.Contains("Distribution", StringComparison.OrdinalIgnoreCase) || x.Contains("派送") => CreatePlane(),
                    var x when x.Contains("Dex", StringComparison.OrdinalIgnoreCase) || x.Contains("图鉴") => CreateBook(),
                    var x when x.Contains("DataBase", StringComparison.OrdinalIgnoreCase) || x.Contains("数据库") => CreateDatabase(),
                    var x when x.Contains("Battle", StringComparison.OrdinalIgnoreCase) || x.Contains("对战") => CreateBattle(),
                    var x when x.Contains("Extra", StringComparison.OrdinalIgnoreCase) || x.Contains("文件") => CreateFile(),
                    var x when x.Contains("Calc", StringComparison.OrdinalIgnoreCase) || x.Contains("计算") => CreateCalculator(),
                    var x when x.Contains("About", StringComparison.OrdinalIgnoreCase) || x.Contains("关于") => CreateBadge(Color.FromArgb(105, 120, 145), "i"),
                    _ => item.Image,
                };
            }
        }

        private static Bitmap Canvas(out Graphics graphics)
        {
            var image = new Bitmap(20, 20);
            image.SetResolution(96, 96);
            image.Tag = IconMarker;
            graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            return image;
        }

        private static Bitmap CreateBadge(Color color, string glyph)
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(color))
            using (var text = new SolidBrush(Color.White))
            using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.DrawString(glyph, BadgeFont, text, new RectangleF(1, 0, 18, 19), format);
            }
            return image;
        }

        private static Bitmap CreateRng()
        {
            var image = Canvas(out var g);
            using (g)
            using (var pen = new Pen(Color.White, 1.7f))
            using (var fill = new SolidBrush(Color.FromArgb(120, 94, 190)))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.DrawEllipse(pen, 5, 5, 10, 10);
                g.DrawLine(pen, 10, 2, 10, 7);
                g.DrawLine(pen, 10, 13, 10, 18);
                g.DrawLine(pen, 2, 10, 7, 10);
                g.DrawLine(pen, 13, 10, 18, 10);
            }
            return image;
        }

        private static Bitmap CreateSparkle()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(242, 177, 45)))
            using (var star = new SolidBrush(Color.White))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.FillPolygon(star, [new(10, 3), new(12, 8), new(17, 10), new(12, 12), new(10, 17), new(8, 12), new(3, 10), new(8, 8)]);
            }
            return image;
        }

        private static Bitmap CreateEgg()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(62, 159, 140)))
            using (var egg = new SolidBrush(Color.White))
            using (var pen = new Pen(Color.FromArgb(62, 159, 140), 1.3f))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.FillEllipse(egg, 6, 3, 9, 14);
                g.DrawLines(pen, [new(7, 10), new(10, 8), new(12, 11), new(14, 9)]);
            }
            return image;
        }

        private static Bitmap CreatePlane()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(50, 135, 205)))
            using (var glyph = new SolidBrush(Color.White))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.FillPolygon(glyph, [new(4, 5), new(17, 3), new(12, 17), new(9, 11), new(4, 9)]);
            }
            return image;
        }

        private static Bitmap CreateBook()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(48, 151, 174)))
            using (var pen = new Pen(Color.White, 1.5f))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.DrawRectangle(pen, 4, 5, 12, 10);
                g.DrawLine(pen, 10, 5, 10, 15);
            }
            return image;
        }

        private static Bitmap CreateDatabase()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(135, 100, 190)))
            using (var pen = new Pen(Color.White, 1.4f))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.DrawEllipse(pen, 5, 4, 10, 4);
                g.DrawLine(pen, 5, 6, 5, 14);
                g.DrawLine(pen, 15, 6, 15, 14);
                g.DrawArc(pen, 5, 10, 10, 6, 0, 180);
                g.DrawArc(pen, 5, 6, 10, 6, 0, 180);
            }
            return image;
        }

        private static Bitmap CreateFile()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(63, 155, 91)))
            using (var glyph = new SolidBrush(Color.White))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.FillPolygon(glyph, [new(6, 4), new(12, 4), new(16, 8), new(16, 16), new(6, 16)]);
            }
            return image;
        }

        private static Bitmap CreateBattle()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(210, 72, 72)))
            using (var pen = new Pen(Color.White, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.DrawLine(pen, 6, 5, 14, 15);
                g.DrawLine(pen, 14, 5, 6, 15);
                g.DrawLine(pen, 4, 6, 7, 3);
                g.DrawLine(pen, 13, 3, 16, 6);
            }
            return image;
        }

        private static Bitmap CreateCalculator()
        {
            var image = Canvas(out var g);
            using (g)
            using (var fill = new SolidBrush(Color.FromArgb(55, 121, 190)))
            using (var pen = new Pen(Color.White, 1.4f))
            {
                g.FillEllipse(fill, 1, 1, 18, 18);
                g.DrawRectangle(pen, 6, 4, 8, 12);
                g.DrawLine(pen, 7, 8, 13, 8);
                g.DrawLine(pen, 10, 9, 10, 15);
                g.DrawLine(pen, 7, 12, 13, 12);
            }
            return image;
        }
    }
}
