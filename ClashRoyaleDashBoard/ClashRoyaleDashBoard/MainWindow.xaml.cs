using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClashRoyaleDashBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ClashClanMember> clanMembers = null;
        List<ClashWar> warLogs = null;
        public MainWindow()
        {
            InitializeComponent();
            
            fillMembersPanel();
            

        }
        private async void fillMembersPanel()
        {
            clanMembers = await loadClashClanMembers();
            warLogs = await ClashRoyaleHttpHelper.GetWarLog();
            Thickness margins;
            if (clanMembers == null)//TODO:add error message
                return;

            List<ClashClanMember> clanMembersOrdered = clanMembers.OrderByDescending(o => o.DonationsRatio).ToList();

            foreach (ClashClanMember member in clanMembersOrdered)
            {
                Button newButton = new Button();
                newButton.Content = member.Name;

                margins = newButton.Margin;
                margins.Top = 2;
                margins.Bottom = 2;

                newButton.Margin = margins;
                newButton.Tag = member.Tag;
                newButton.Click += btnGetUserStats;
                

                panelMembers.Children.Add(newButton);
            }
        }
        private async void calculateWarRatio()
        {
            if (warLogs == null)
                return;
            if (clanMembers == null)
                return;

            //ClashClanMember member =null;
            await Task.Run(() =>
            {
                foreach (ClashClanMember member in clanMembers)
                {

                    int wastedAttacks = 0;
                    int skipedWars = 0;
                    int participatedWars = 0;

                    foreach (ClashWar log in warLogs)
                    {
                        ClashWarParticipant clanWarParticipant = null;
                        clanWarParticipant = log.Participants.Find(warMember => warMember.Tag == member.Tag);
                        if (clanWarParticipant != null)
                        {
                            participatedWars++;
                            if (clanWarParticipant.BattlesPlayed == 0)
                                wastedAttacks++;
                        }
                        else
                            skipedWars++;
                    }
                    member.SkippedWars = skipedWars;
                    member.WastedWarAttacks = wastedAttacks;
                    member.WarAtackRatio = (participatedWars==0)? 0 : (participatedWars - wastedAttacks) / participatedWars;
                    member.ParticipatedWars = participatedWars;
                }
            });
        }
        private void btnGetUserStats(object sender, RoutedEventArgs e)
        {            
            Console.WriteLine(((Button)sender).Tag);
            string tag = ((Button)sender).Tag.ToString();
            ClashClanMember detailMember = clanMembers.Find(member => member.Tag == tag);
            if (detailMember != null)
            {
                lblMemberName.Content = detailMember.Name;
                lblClanMemberArenaValue.Content = detailMember.Arena.Name;
                lblClanMemberChestPointsValue.Content = detailMember.ClanChestPoints;
                lblClanMemberDonationsRatioValue.Content = detailMember.DonationsRatio;
                lblClanMemberDonationsReceivedValue.Content = detailMember.DonationsReceived;
                lblClanMemberDonationsValue.Content = detailMember.Donations;
                lblClanMemberExpLevelValue.Content = detailMember.ExpLevel;
                lblClanMemberPreviousRankValue.Content = detailMember.PreviousClanRank;
                lblClanMemberRankValue.Content = detailMember.ClanRank;
                lblClanMemberRoleValue.Content = detailMember.Role;
                lblClanMemberTrophiesValue.Content = detailMember.Trophies;

                int cardsEarned = 0;
                int battlesPlayed = 0;
                int wins = 0;
                int wastedAttacks = 0;
                int skipedWars = 0;
                foreach(ClashWar log in warLogs)
                {
                    ClashWarParticipant clanWarParticipant = null;
                    clanWarParticipant = log.Participants.Find(member => member.Tag == tag);
                    if (clanWarParticipant != null)
                    {
                        cardsEarned += clanWarParticipant.CardsEarned;
                        wins += clanWarParticipant.Wins;
                        if (clanWarParticipant.BattlesPlayed > 0)
                            battlesPlayed += clanWarParticipant.BattlesPlayed;
                        else
                            wastedAttacks++;
                    }
                    else
                        skipedWars++;                
                }
                lblClanMemberBattlesPlayedValue.Content = battlesPlayed;
                lblClanMemberCardsEarnedValue.Content = cardsEarned;
                lblClanMemberWinsValue.Content = wins;
                lblClanMemberWastedAtacksValue.Content = wastedAttacks;
                lblNumberOfWarsValue.Content = warLogs.Count;
                lblClanMemberSkippedWarsValue.Content = skipedWars;    
            }
        }
        private async Task<List<ClashClanMember>> loadClashClanMembers()
        {            
            try
            {
                clanMembers = await ClashRoyaleHttpHelper.GetClanMembersAsync();
                foreach(ClashClanMember member in clanMembers){
                    member.DonationsRatio = (float) member.Donations / member.DonationsReceived;                    
                }
            }
            catch (Exception ex){
            }
            return clanMembers;
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 //warLogs = await ClashRoyaleHttpHelper.GetWarLog();
            }
            catch (Exception)
            {
                //TODO: Display error
            }
            
            string token = FileReader.readToken();
            //dynamic WarLog = Newtonsoft.Json.JsonConvert.DeserializeObject(ClashRoyaleHttpHelper.jsonResponse);
            Console.WriteLine();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                calculateWarRatio();
            });

        }
    }
}
