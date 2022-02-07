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

namespace lab1
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

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Window2 w = new Window2();
            Hide();
            w.Show();
        }

        private void b2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Window4 w = new Window4();
            Hide();
            w.Show();
        }

        private void b2_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window3 w = new Window3();
            Hide();
            w.Show();
        }

        private void b2_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Window5 w = new Window5();
            Hide();
            w.Show();
        }
    }
}
