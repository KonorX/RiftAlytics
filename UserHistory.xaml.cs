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
    /// <summary>
    /// Interaction logic for UserHistory.xaml
    /// </summary>
    public partial class UserHistory : Window
    {
        public SummonerData selectedLastSummoner;


        public UserHistory()
        {
            InitializeComponent();
            LastUsersList.Items.Clear();
            LastUsersList.ItemsSource = GetUsers();
            selectedLastSummoner=new SummonerData();
            
        }


        public List<SummonerData> GetUsers()
        {
            using (var context = new SQLiteDbContext())
            {
                return context.SummonerData.ToList();
            }
        }

         

        private void Selection(object sender, SelectionChangedEventArgs e)
        {
            if (LastUsersList.SelectedIndex!=-1)
            {
                selectedLastSummoner= LastUsersList.SelectedItem as SummonerData;

                this.DialogResult = true;
            }
            
        }
    }
}
