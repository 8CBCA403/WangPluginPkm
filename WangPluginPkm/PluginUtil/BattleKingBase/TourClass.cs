using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPluginPkm.PluginUtil.BattleKingBase
{
    class Tournament
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string Source { get; set; }
        public int Players { get; set; }
        public int TopCut { get; set; }
    }
    class TUrl
    {
       public string Number { get; set; }

       public string Url { get; set; }
    }
    class TournamentSub
    {
        public int Id { get;set; }
        public string Author { get; set; }
        public string Country { get; set; }
        public int Standing { get; set; }
        public string Paste { get; set; }
        public int TournamentId { get; set; }
    }
}
