using PKHeX.Core;
using System;
using System.Windows.Forms;
using WangPluginPkm.GUI;

namespace WangPluginPkm.Plugins
{
    internal class DistributionPlugin: WangPluginPkm
    {
        public override string Name => "派送器/Distribution Tools";
        public override int Priority => 3;

        protected override void AddPluginControl(ToolStripDropDownItem modmenu)
        {
            var ctrl = new ToolStripMenuItem(Name)
            {
                Image = Properties.Resources.Distribution
            };
            ctrl.Click += OpenForm;
            ctrl.Name = "派送器/Distribution Tools";
            modmenu.DropDownItems.Add(ctrl);
            AddCheckerToList();
        }
        private void AddCheckerToList()
        {
            var menuVSD = (ContextMenuStrip)((dynamic)SaveFileEditor).menu.mnuVSD;
            var menuVS = (ContextMenuStrip)((dynamic)SaveFileEditor);
            var ATKIVEV = new ToolStripMenuItem("物攻手");
            var SPAIVEV = new ToolStripMenuItem("特攻手");
            var ATK_0SPEIVEV=new ToolStripMenuItem("物攻0速");
            var SPA_0SPEIVEV = new ToolStripMenuItem("特攻0速");
            var TANKIVEV = new ToolStripMenuItem("坦克");
            menuVSD.Opening += (s, e) =>
            {
                var info = GetSenderInfo(ref s!);
                var pk = info.Slot.Read(SaveFileEditor.SAV);
                var IVEVN = new ToolStripMenuItem("快捷三维编辑器");
                IVEVN.Image = Properties.Resources.Atom;
                menuVSD.Items.Insert(menuVSD.Items.Count, IVEVN);
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

            };
           
        }
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
        private void OpenForm(object sender, EventArgs e)
        {

            var form = new DistributionUI(SaveFileEditor, PKMEditor);
            form.Show();
        }
    }
}
