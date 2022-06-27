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
    /// Interaction logic for wpfAddData.xaml
    /// </summary>
    public partial class wpfAddData : Window
    {
        public wpfAddData()
        {
            InitializeComponent();
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string src = txtSrc.Text;
            string startAtSec = txtStartAtSec.Text;

            string mess = SQLConectionAndSelectData.insertWithStartTime(title, src, startAtSec);

            MessageBox.Show(mess);
        }

        private void MenuItem_Click_Afsuiten(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_ViewData(object sender, RoutedEventArgs e)
        {
            ViewAllData w = new ViewAllData();
            w.Show();
        }
    }
}
