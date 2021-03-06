﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleDashBoard
{
    class ClashPlayer
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public ClashArena Arena { get; set; }
        public int BestTrophies { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int BattleCount { get; set; }
        public int ThreeCrownWins { get; set; }
        public int ChallengeCardsWon { get; set; }
        public int ChallengeMaxWins { get; set; }
        public int TournamentCardsWon { get; set; }
        public int TournamentBattleCount { get; set; }
        public string Role { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
        public int TotalDonations { get; set; }
        public int WarDayWins { get; set; }
        public int ClanCardsCollected { get; set; }
        public ClashClan Clan { get; set; }
        public ClashLeagueStatistics LeagueStatistics { get; set; }
        public Achivement[] Achivements { get; set; }
        public ClashCard[] Cards { get; set; }
        public ClashCurrentFavouriteCard CurrentFavouriteCard { get; set; }
        

    }
}
