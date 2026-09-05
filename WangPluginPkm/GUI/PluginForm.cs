using System;
using System.Drawing;
using System.Windows.Forms;

namespace WangPluginPkm.GUI
{
    /// <summary>Uses the host's theme without changing PKHeX's application settings.</summary>
    public class PluginForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                PluginLocalization.Apply(this);
            if (!DesignMode && Application.IsDarkModeEnabled && !SystemInformation.HighContrast)
                ApplyDarkTheme(this);
        }

        private static bool IsNeutral(Color color) =>
            color.IsSystemColor || Math.Max(color.R, Math.Max(color.G, color.B)) -
            Math.Min(color.R, Math.Min(color.G, color.B)) < 24;

        private static void ApplyDarkTheme(Control control)
        {
            // Keep semantic red/green indicators and artwork intact.
            if (control.BackColor.A != 0 && IsNeutral(control.BackColor))
                control.BackColor = control is TextBoxBase or ListControl or UpDownBase
                    ? Color.FromArgb(45, 45, 48) : Color.FromArgb(32, 32, 32);
            if (IsNeutral(control.ForeColor))
                control.ForeColor = Color.FromArgb(235, 235, 235);
            else if (control.ForeColor.ToArgb() == Color.Red.ToArgb())
                control.ForeColor = Color.FromArgb(255, 120, 120);

            if (control is TabPage page)
                page.UseVisualStyleBackColor = false;
            if (control is ComboBox combo)
                combo.FlatStyle = FlatStyle.Flat;
            if (control is TextBoxBase text)
                text.BorderStyle = BorderStyle.FixedSingle;
            if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 65);
                button.FlatAppearance.MouseDownBackColor = Color.FromArgb(75, 75, 80);
            }
            if (control is LinkLabel link)
            {
                link.LinkColor = Color.FromArgb(120, 190, 255);
                link.VisitedLinkColor = Color.FromArgb(195, 165, 255);
                link.ActiveLinkColor = Color.White;
            }

            foreach (Control child in control.Controls)
                ApplyDarkTheme(child);
            control.ControlAdded -= OnControlAdded;
            control.ControlAdded += OnControlAdded;
        }

        private static void OnControlAdded(object sender, ControlEventArgs e) => ApplyDarkTheme(e.Control);
    }
}
