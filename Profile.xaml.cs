using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace RiftAlytics
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public double winrate {  get; set; }
        public List<MatchInfo> matchesInfo { get; set; }
        public SummonerData summoner { get; set; }
        public RiotApiClient riotApiClient = new RiotApiClient();

        public Profile()
        {
            InitializeComponent();
            
        }

        public Profile(SummonerData _summoner) 
        {
            InitializeComponent();
            
            summoner = _summoner;
            matchesInfo = new List<MatchInfo>();
            
        }

        private void Window_CLosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public async Task Refresh()
        {
            winrate = await riotApiClient.GetWinrateAsync(summoner.Puuid);
            winrate = Math.Round(winrate, 2);
            byte red = (byte)(255 - winrate * 2.55);
            byte green = (byte)(winrate * 2.55);
            wr.Foreground = new SolidColorBrush(Color.FromRgb(red, green, 0));
            wr.Content = winrate.ToString()+ "%";
            info.Content= $" {summoner.FullName}\n Уровень профиля {summoner.Level.ToString()}";
            await GetMatchesInfo();
            MatchesList.Items.Clear();
            MatchesList.ItemsSource = matchesInfo;
        }

        public async Task GetMatchesInfo()
        {
            
            var matches = await riotApiClient.GetMatchIdsAsync(summoner.Puuid,20);
            foreach (var match in matches)
            {
                matchesInfo.Add(await riotApiClient.GetMatchInfoAsync(summoner.Puuid,match));
            }
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Refresh();
        }

        private async void MatchProfile(object sender, SelectionChangedEventArgs e)
        {
            if (MatchesList.SelectedIndex != -1)
            {
                MatchInfo selectedMatch=MatchesList.SelectedItem as MatchInfo;

                MatchProfile match = new MatchProfile();
                await match.GetInfo(summoner,selectedMatch.MatchId);
                match.ShowDialog();
            }
        }
    }
}
