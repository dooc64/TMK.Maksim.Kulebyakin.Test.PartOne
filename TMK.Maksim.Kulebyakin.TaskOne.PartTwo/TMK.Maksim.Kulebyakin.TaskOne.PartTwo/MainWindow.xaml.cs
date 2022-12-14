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

namespace TMK.Maksim.Kulebyakin.TaskOne.PartTwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseHandler dataBase;

        public MainWindow()
        {
            dataBase = new DataBaseHandler();
            InitializeComponent();
            Top = 0;
            Left = 0;
        }

        private async void GetFirms(object sender, RoutedEventArgs e)
        {
            var window = new FilteredFirmsWindow();

            string firmName = FirmNameInput.Text;
            string jurCityName = JurCityInput.Text;
            string postCityName = PostCityInput.Text;

            window.FirmTable.Items.Clear();
            window.FirmTable.ItemsSource = await dataBase.GetFilteredFirms(firmName, jurCityName, postCityName);

            window.Show();
        }

        private async void GetDocuments(object sender, RoutedEventArgs e)
        {
            int firmId = int.Parse(FirmIdInput.Text);
            var window = new FilteredDocumentsByIdWindow(firmId);

            window.Show();
        }
    }
}
