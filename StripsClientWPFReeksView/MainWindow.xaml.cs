//using StripsClientWPFReeksView.Model;
using StripsClientWPFReeksView.ModelOutput;
using StripsClientWPFReeksView.Services;
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

namespace StripsClientWPFReeksView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private string path;
        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient();
        }

        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            ReeksRESToutputDTO reeks = null;
            path = "api/Strips/Reeks/" + ReeksIdTextBox.Text;
            reeks = await stripService.GetReeksAsync(path);
            if (reeks != null)
            {
                NaamTextBox.Text = reeks.Naam;
                AantalTextBox.Text = Convert.ToString(reeks.AantalStrips);
                StripsDataGrid.ItemsSource = reeks.Strips;
            }
            else
            {
                MessageBox.Show("Reeks niet gevonden");
            }


        }
    }
}
