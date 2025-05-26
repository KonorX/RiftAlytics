using System.Text;
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

        public string regionSelected {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            regionSelected = string.Empty;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(InputText.Text))
            {
                Output.Content = InputText.Text + $" {regionSelected}";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            if (comboBox.SelectedItem is ComboBoxItem selected && ((ComboBoxItem)comboBox.SelectedItem).Content is not null)
            {

                regionSelected = selected.Content.ToString();
            }
            else { Output.Content = "Region null"; }
        }
    }
}