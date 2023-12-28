using System.Drawing;

namespace WangPluginPkm.PluginUtil
{
    class Picture
    {
        public Image Image { get; set; }
        public Picture(string resource)
        {
            Image = Image.FromStream(
               typeof(Picture)
              .Assembly
              .GetManifestResourceStream(resource));
        }
    }
}
