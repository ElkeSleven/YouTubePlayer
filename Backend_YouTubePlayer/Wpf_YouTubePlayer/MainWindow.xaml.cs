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

namespace Wpf_YouTubePlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mePlayer.Play();
        }

        private void viewAllData_Click(object sender, RoutedEventArgs e)
        {
            ViewAllData w2 = new ViewAllData();
            w2.Show();
        }

        private void addData_Click(object sender, RoutedEventArgs e)
        {
            wpfAddData w2 = new wpfAddData();
            w2.Show();
        }

        private void MenuItem_Click_Afsuiten(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
