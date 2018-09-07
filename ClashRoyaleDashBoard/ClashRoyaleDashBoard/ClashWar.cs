using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClashRoyaleDashBoard
{
    
    class ClashWar
    {
        public int SeasonId { get; set; }
        public string CreatedDate { get; set; }
        public List<ClashWarParticipant> Participants { get; set; }
        public List<ClashWarStandings> Standings { get; set; }

    }
}
