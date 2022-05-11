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

namespace Kyrsova
{
    /// <summary>
    /// Interaction logic for Firmbook.xaml
    /// </summary>
    static class sql
    {
        static public string sqlQ1 = null;
    }
    public partial class Firmbook : Window
    {
        bool f1 = false;
        bool f2 = false;
        bool f3 = false;
        public Firmbook()
        {
            InitializeComponent();
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.StartPoint = new Point(0, 0);
            myBrush.EndPoint = new Point(0, 1);
            myBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0.3));
            myBrush.GradientStops.Add(new GradientStop(Colors.White, 1.0));
            LinearGradientBrush myBrush2 = new LinearGradientBrush();
            myBrush2.StartPoint = new Point(0, 0);
            myBrush2.EndPoint = new Point(0, 1);
            myBrush2.GradientStops.Add(new GradientStop(Colors.White, 0.1));
            myBrush2.GradientStops.Add(new GradientStop(Colors.Black, 2.0));
            infoaboutauction.Background = myBrush2;
            incomeB.Background = myBrush2;
            addauctionB.Background = myBrush2;
            MainB.Background = myBrush2;
           
            this.Background = myBrush;
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            DataControls.ShowData(FirmBookDG, sqlQ);
            sqlQ = "SELECT place FROM dbo.firmbook";
            DataControls.fillupCB(placesCB, sqlQ);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            f1 = true;
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            if (f1 || f2 || f3)
            {
                sqlQ += " WHERE";
            }
            if (f1)
            {
                sqlQ += " date >= '" + datefrom.Text + "'";

            }
            if (f2)
            {
                sqlQ += " AND date <= '" + dateto.Text + "'";
            }
            if(f3)
            {
                sqlQ += " AND place = '" + placesCB.Text + "'";
            }
            DataControls.ShowData(FirmBookDG, sqlQ);
            // MessageBox.Show(datefrom.Text);
        }

        private void dateto_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            f2 = true;
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            if (f1 || f2 || f3)
            {
                sqlQ += " WHERE";
            }
            if (f2)
            {
               
                sqlQ += " date <= '" + dateto.Text + "'";
            }
            if (f1)
            {
                sqlQ += " AND date >= '" + datefrom.Text + "'";

            }
            if (f3)
            {
                sqlQ += " AND place = '" + placesCB.Text + "'";
            }


            DataControls.ShowData(FirmBookDG, sqlQ);
        }

        private void placesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            f3 = true;
            
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            if (f1 || f2 || f3)
            {
                sqlQ += " WHERE";
            }
            if (f3)
            {
                //MessageBox.Show(placesCB.SelectedItem.ToString());
                sqlQ += " place = '" +placesCB.SelectedItem.ToString()+ "'";
            }
            if (f1)
            {
                sqlQ += " AND date >= '" + datefrom.Text + "'";

            }
            if (f2)
            {
                sqlQ += " AND date <= '" + dateto.Text + "'";
            }


            DataControls.ShowData(FirmBookDG, sqlQ);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AboutAuction w = new AboutAuction();
            this.Hide();
            w.Show();
        }

        private void incomeB_Click(object sender, RoutedEventArgs e)
        {
            income w = new income();
            this.Hide();
            w.Show();

        }

        private void addauctionB_Click(object sender, RoutedEventArgs e)
        {
            Addauction w = new Addauction();
            Hide();
            w.Show();
        }
    }
}
