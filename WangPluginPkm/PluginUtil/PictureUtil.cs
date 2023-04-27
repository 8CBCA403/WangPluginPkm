using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
