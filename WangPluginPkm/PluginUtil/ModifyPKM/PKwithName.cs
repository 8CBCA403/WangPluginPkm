using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKHeX.Core;

namespace WangPluginPkm.PluginUtil.ModifyPKM
{
    public class PKwithName
    {
        public PKM OriginalItem { get; set; } // 原始对象
        public string DisplayText { get; set; } // 用于显示的文本

        public PKwithName(PKM originalItem)
        {
            OriginalItem = originalItem;
            DisplayText = $"PID: {originalItem.PID.ToString("X8")}"; // 将PID转换为十六进制格式并设置显示文本
        }

        // 重写ToString方法以定义在CheckedListBox中显示的文本
        public override string ToString()
        {
            return DisplayText;
        }
    }
}
