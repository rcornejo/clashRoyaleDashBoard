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
        public MainWindow()
        {
            InitializeComponent();
            fillMembersPanel();
            
        }
        private async void fillMembersPanel()
        {
            List<ClashClanMember> clanMembers = await ClashRoyaleHttpHelper.GetClanMembersAsync();
            Thickness margins;
            foreach(ClashClanMember member in clanMembers)
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
        private void btnGetUserStats(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(((Button)sender).Tag  );
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            List<ClashWar> reponse = await ClashRoyaleHttpHelper.GetWarLog();
            
            //dynamic WarLog = Newtonsoft.Json.JsonConvert.DeserializeObject(ClashRoyaleHttpHelper.jsonResponse);
            Console.WriteLine();
        }
    }
}
