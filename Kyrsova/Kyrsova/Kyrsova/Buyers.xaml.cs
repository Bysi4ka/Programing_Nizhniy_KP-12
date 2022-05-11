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
    /// Interaction logic for Buyers.xaml
    /// </summary>
    public partial class Buyers : Window
    {
        public Buyers()
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
            Background = myBrush;
            addB.Background = myBrush2;
            mw.Background = myBrush2;
            changeB.Background = myBrush2;
            deleteB.Background = myBrush2;
            nameT.Text = "";
            surnameT.Text = "";
            string sqlQ = "SELECT ID FROM dbo.buyer";
            DataControls.fillupCB(CB, sqlQ);
        }
        private void mw_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }

        private void addB_Click(object sender, RoutedEventArgs e)
        {
            string sqlQ = "INSERT INTO buyer (name, surname) values('" + nameT.Text + "', '" + surnameT.Text + "'); ";
            SqlConnection s = new SqlConnection(DataControls.connectionString);
            s.Open();
            SqlCommand c = new SqlCommand(sqlQ, s);
            try
            {
                nameT.Text = nameT.Text.Replace(" ", "");
                surnameT.Text = surnameT.Text.Replace(" ", "");
                if (nameT.Text == "" || surnameT.Text == "")
                {
                    MessageBox.Show("Присутні пусті поля");
                    s.Close();
                    return;
                }
                MessageBox.Show(nameT.Text, surnameT.Text);
                c.ExecuteNonQuery();
                MessageBox.Show("Покупця добавлено!");
                nameT.Text = "";
                surnameT.Text = "";
                sqlQ = "SELECT ID FROM dbo.buyer";
                DataControls.fillupCB(CB, sqlQ);
            }
            catch
            {
                MessageBox.Show("Некоректнi даннi");
            }
            s.Close();
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(FirmBookDG.SelectedItem.ToString());
            if (CB.SelectedIndex == -1) return;
            string sqlQ = "SELECT name, surname FROM dbo.buyer WHERE ID = '" + CB.SelectedItem.ToString() + "'";
            DataTable dt = DataControls.GetAndShowDataTable(sqlQ);
            string name = dt.Rows[0][0].ToString();
            string surname = dt.Rows[0][1].ToString();
            nameT2.Text = name;
            surnameT2.Text = surname;
        }

        private void changeB_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(DataControls.connectionString);
            connection.Open();
            string strQ = "UPDATE buyer SET name ='" + nameT2.Text + "', surname = '" + surnameT2.Text + "' WHERE ID = '" + CB.SelectedItem.ToString() + "'; ";
            SqlCommand Com = new SqlCommand(strQ, connection);
            try
            {
                nameT2.Text = nameT2.Text.Replace(" ", "");
                surnameT2.Text = surnameT2.Text.Replace(" ", "");

                if (!string.IsNullOrEmpty(nameT2.Text) && !string.IsNullOrEmpty(surnameT2.Text))
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

            strQ = "SELECT ID FROM dbo.buyer";
            CB.Items.Clear();
            CB.SelectedIndex = -1;
            DataControls.fillupCB(CB, strQ);
            surnameT2.Text = "";
            nameT2.Text = "";
            connection.Close();
        }

        private void deleteB_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(DataControls.connectionString);
            connection.Open();
            string strQ = "DELETE FROM buyer WHERE ID = '" + CB.SelectedItem.ToString() + "'; ";
            SqlCommand Com = new SqlCommand(strQ, connection);
            try
            {
                string strQ2 = "SELECT prize FROM dbo.sold WHERE buyerID = '" + CB.SelectedItem.ToString() + "'";
                DataTable dt = DataControls.GetAndShowDataTable(strQ2);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Не можливо видалити покупця, так як він задіяний на аукціоні");
                    connection.Close();
                    return;
                }
                Com.ExecuteNonQuery();
                MessageBox.Show("Покупця видалено");

            }
            catch
            {
                MessageBox.Show("Покупця не вибрано");
            }
            strQ = "SELECT ID FROM dbo.buyer";
            CB.Items.Clear();
            CB.SelectedIndex = -1;
            DataControls.fillupCB(CB, strQ);
            surnameT2.Text = "";
            nameT2.Text = "";
            connection.Close();
        }
    }
}
