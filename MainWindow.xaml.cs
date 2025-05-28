using System.Security.Cryptography.X509Certificates;
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

namespace RiftAlytics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {

        public string tag {  get; set; }
        public string name { get; set; }
        public SummonerData summoner { get; set; }
        private readonly RiotApiClient riotApiClient= new RiotApiClient();
        public MainWindow()
        {
            InitializeComponent();
            tag = string.Empty;
            name = string.Empty;
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (!String.IsNullOrEmpty(InputText.Text)&& !String.IsNullOrEmpty(tagName.Text))
            {
                tag = tagName.Text;
                name= InputText.Text;
                var json = await riotApiClient.GetSummonerPuuidByNameAsync(name, tag);
                summoner = await riotApiClient.GetSummonerInfoAsync(json, name, tag);
                SummonerInfoLabel.Content = $" {summoner.FullName}\n Уровень профиля {summoner.Level.ToString()}";
            }
            start.Visibility= Visibility.Visible;   
        }

        

        private async void getName(object sender, RoutedEventArgs e)
        {
            
            

        }
    }
}