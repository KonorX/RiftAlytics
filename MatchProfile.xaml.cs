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
using System.Windows.Shapes;

namespace RiftAlytics
{
      
    public partial class MatchProfile : Window
    {
        public List<PlayerStats> PlayerStats = new List<PlayerStats>();
        public RiotApiClient riotApiClient = new RiotApiClient();
        
        public MatchProfile()
        {
            InitializeComponent();
        }
        public MatchProfile(SummonerData summoner, string matchid)
        {
            InitializeComponent();
            
        }

        public async Task GetInfo(SummonerData summoner, string matchid)
        {
            PlayerStats= await riotApiClient.GetPlayersMatchInfo(matchid,summoner.Puuid);
            List<string> labelsInfo = new List<string>();
            PlayerStats customer= new PlayerStats();
            foreach (PlayerStats playerStats in PlayerStats)
            {
                if (playerStats.IsCustomer)
                {
                    customer = playerStats;
                }
                string temp= string.Empty;
                temp += $"{playerStats.championName}\n" +
                    $"{playerStats.kills}/{playerStats.deaths}/{playerStats.assists}";
                labelsInfo.Add(temp);
            }
            participant1.Content = labelsInfo[0];
            participant2.Content = labelsInfo[1];
            participant3.Content = labelsInfo[2];
            participant4.Content = labelsInfo[3];
            participant5.Content = labelsInfo[4];
            participant6.Content = labelsInfo[5];
            participant7.Content = labelsInfo[6];
            participant8.Content = labelsInfo[7];
            participant9.Content = labelsInfo[8];
            participant10.Content = labelsInfo[9];
            string kda=string.Empty;
            if (customer.kda > 1.0 && customer.kda < 2.0) { kda = "Хорошо"; }
            else if (customer.kda < 1.0) { kda = "Так себе"; }
            else if (customer.kda > 2.0){ kda = "Просто великолепно"; }
            string vision=string.Empty;
            if (customer.stealthWards > 0 && customer.controlWards > 0)
            {
                vision = "хороший";
            }
            else vision = "плохой";
                participant.Content = $"Вы сыграли за {customer.championName} {kda}\nСо счётом {customer.kills}/{customer.deaths}/{customer.assists} Ваш KDA = {Math.Round(customer.kda, 2)}\nВы были на роли {customer.role.ToLower()} и учавствовали в \n{Math.Round(customer.killParticipation, 2)*100}% убийств\nУ вас {vision} обзор вы поставили {customer.stealthWards.ToString()} скрытых и \n{customer.controlWards.ToString()} контрольных тотемов";
        }
    }
}
