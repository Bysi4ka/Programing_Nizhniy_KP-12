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

namespace prac3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            logadmin w = new logadmin();
            this.Hide();
            w.Show();
            
            
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
            About w = new About();
            this.Hide();
            w.Show();
        }

        private void UserMode_Click(object sender, RoutedEventArgs e)
        {
            loginuser w = new loginuser();
            this.Hide();
            w.Show();
        }
    }
}
