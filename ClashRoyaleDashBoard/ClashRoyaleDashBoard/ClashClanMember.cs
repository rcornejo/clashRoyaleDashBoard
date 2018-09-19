using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleDashBoard
{
    class ClashClanMember
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public ClashArena Arena { get; set; }
        public string Role { get; set; }
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
        public int ClanChestPoints { get; set; }
        public float DonationsRatio { get; set; }
        public int SkippedWars { get; set; }
        public int ParticipatedWars { get; set; }
        public int WastedWarAttacks { get; set; }
        public float WarAtackRatio { get; set; }
    }
}
