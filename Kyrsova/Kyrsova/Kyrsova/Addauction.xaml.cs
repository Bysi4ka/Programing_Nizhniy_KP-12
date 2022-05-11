using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Addauction.xaml
    /// </summary>
    public partial class Addauction : Window
    {
        public Addauction()
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
            this.Background = myBrush;
            add.Background = myBrush2;
            mv.Background = myBrush2;
            nameT.Text = "";
            dateT.Text = "";
            placeT.Text = "";
            timeT.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sqlQ = "INSERT INTO firmbook (nameofauction, date, place, time, specification) values('"+nameT.Text+"', '"+dateT.Text+"', '" + placeT.Text + "', '"+timeT.Text+"', '"+desT.Text+"'); ";
            SqlConnection s = new SqlConnection(DataControls.connectionString);
            s.Open();
            SqlCommand c = new SqlCommand(sqlQ, s);
            try
            {
                nameT.Text = nameT.Text.Replace(" ", "");
                dateT.Text = dateT.Text.Replace(" ", "");
                placeT.Text = placeT.Text.Replace(" ", "");
                timeT.Text = timeT.Text.Replace(" ", "");
                string nameText = nameT.Text;
                if (nameText == "" || dateT.Text == "" || placeT.Text == "" || timeT.Text == "")
                {
                    MessageBox.Show("Присутні пусті поля");
                    s.Close();
                    return;
                }
                c.ExecuteNonQuery();
                MessageBox.Show("Аукцiон добавлено!");
                nameT.Text = "";
                dateT.Text = "";
                placeT.Text = "";
                timeT.Text = "";
                desT.Text = "";
            }
            catch
            {
                MessageBox.Show("Некоректнi даннi, або аукціон з заданим iм'ям вже iснує");
            }
            s.Close();
            
        }

        private void mv_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }
    }
}
