using System;
using System.Collections.Generic;

namespace WangPluginPkm.PluginUtil.BattleKingBase
{
    class RootObject
    {
        public PageProps PageProps { get; set; }
    }

    class PageProps
    {
        public List<DataItem> Pastes { get; set; }
    }

    class DataItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Format { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RentalCode { get; set; }
        public bool HasEVs { get; set; }
        public List<string> Species { get; set; }

        public string PS { get; set; }
    }
}
