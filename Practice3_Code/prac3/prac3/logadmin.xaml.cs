using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prac3
{
    /// <summary>
    /// Interaction logic for logadmin.xaml
    /// </summary>
    public partial class logadmin : Window
    {
        public logadmin()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogDT ld = new LogDT();
            ld.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataTable dt = new DataTable();
            string login = "admin";
            dt = ld.ShowPas(dt, login);

            string realpas = dt.Rows[0][0].ToString();
            string inpas = pasw.Text;
            if(realpas==inpas)
            {
                admin w = new admin();
                this.Hide();
                w.Show();

            }
            else
            {
                MessageBox.Show("Невірний пароль");
                pasw.Text = "";
            }
            /*admin w = new admin();
            this.Hide();
            w.Show();*/


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }
    }
}
