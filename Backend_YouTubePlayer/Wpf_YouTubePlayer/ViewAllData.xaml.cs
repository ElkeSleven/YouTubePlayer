using ClassLibrary_YouTubePlayer;
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

namespace Wpf_YouTubePlayer
{
    /// <summary>
    /// Interaction logic for ViewAllData.xaml
    /// </summary>
    public partial class ViewAllData : Window
    {
        public ViewAllData()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewData.ItemsSource = SQLConectionAndSelectData.LoadDataBaseGetDefaultView();
        }

        private void MenuItem_Click_Afsuiten(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_DataToevoegen(object sender, RoutedEventArgs e)
        {
            wpfAddData w = new wpfAddData();
            w.Show();
        }
    }
}
