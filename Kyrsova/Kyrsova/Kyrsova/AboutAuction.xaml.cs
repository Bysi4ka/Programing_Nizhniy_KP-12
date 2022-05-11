using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AboutAuction.xaml
    /// </summary>
    public partial class AboutAuction : Window
    {
        public AboutAuction()
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
            changeB.Background = myBrush2;
            MainW.Background = myBrush2;
            deleteB.Background = myBrush2;
            this.Background = myBrush;
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            DataControls.ShowData(FirmBookDG, sqlQ);
            sqlQ = "SELECT nameofauction FROM dbo.firmbook";
            DataControls.fillupCB(namesCB, sqlQ);
        }

        private void namesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(FirmBookDG.SelectedItem.ToString());
            if (namesCB.SelectedIndex == -1) return;
            string sqlQ = "SELECT date, place, time, specification FROM dbo.firmbook WHERE nameofauction = '"+namesCB.SelectedItem.ToString()+"'";
            DataTable dt = DataControls.GetAndShowDataTable(sqlQ);
            string date = dt.Rows[0][0].ToString();
            string place = dt.Rows[0][1].ToString();
            string time = dt.Rows[0][2].ToString();
            string spec = dt.Rows[0][3].ToString();
            datee.SelectedDate = Convert.ToDateTime(date);
            placee.Text = place;
            timee.Text = time;
            description.Text = spec;
            namee.Text = namesCB.SelectedItem.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(DataControls.connectionString);
            connection.Open();
            string strQ = "UPDATE firmbook SET nameofauction ='" + namee.Text + "', date = '"+ datee.Text +"', place = '"+ placee.Text +"', time = '"+timee.Text+"', specification = '"+ description.Text +"' WHERE nameofauction = '" + namesCB.SelectedItem.ToString() + "'; ";
            SqlCommand Com = new SqlCommand(strQ, connection);
            try 
            {
                namee.Text = namee.Text.Replace(" ", "");
                datee.Text = datee.Text.Replace(" ", "");
                placee.Text = placee.Text.Replace(" ", "");
                timee.Text = timee.Text.Replace(" ", "");
                if (!string.IsNullOrEmpty(namee.Text) && !string.IsNullOrEmpty(datee.Text)&& !string.IsNullOrEmpty(placee.Text)&& !string.IsNullOrEmpty(timee.Text))
                {
                    Com.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Некоректнi даннi");
                    connection.Close();
                    return;
                }
                
                MessageBox.Show("Даннi змінено");
            }
            catch
            {
                MessageBox.Show("Некоректнi даннi");
                return;
                    
            }
            
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            DataControls.ShowData(FirmBookDG, sqlQ);
            sqlQ = "SELECT nameofauction FROM dbo.firmbook";
            namesCB.Items.Clear();
            namesCB.SelectedIndex = -1;
            DataControls.fillupCB(namesCB, sqlQ);
             datee.Text=string.Empty;
            placee.Text = "";
            timee.Text = "";
            description.Text = "";
            namee.Text = "";
            connection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }

        private void deleteB_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection(DataControls.connectionString);
            connection.Open();
            string strQ = "DELETE FROM firmbook WHERE nameofauction = '" + namesCB.SelectedItem.ToString() + "'; ";
            SqlCommand Com = new SqlCommand(strQ, connection);
            try
            {
                string strQ2 = "SELECT sellerID FROM dbo.forsale WHERE nameofauction = '" + namesCB.SelectedItem.ToString() + "'";
                DataTable dt = DataControls.GetAndShowDataTable(strQ2);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Не можливо видалити аукціон, так як він є задіяним");
                    connection.Close();
                    return;
                }
                Com.ExecuteNonQuery();
                MessageBox.Show("Аукціон видалено");

            }
            catch
            {
                MessageBox.Show("Аукціон не вибрано");
            }
            strQ = "SELECT nameofauction FROM dbo.firmbook";
            namesCB.Items.Clear();
            namesCB.SelectedIndex = -1;
            DataControls.fillupCB(namesCB, strQ);
            datee.Text = string.Empty;
            placee.Text = "";
            timee.Text = "";
            description.Text = "";
            namee.Text = "";
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            DataControls.ShowData(FirmBookDG, sqlQ);
            connection.Close();
        }
    }
}
