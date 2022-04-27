using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
            ld.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        LogDT ld = new LogDT();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginuser w = new loginuser();
            this.Hide();
            w.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            ld.connection = new SqlConnection(ld.connectionString);
            ld.connection.Open();
            String strQ;
            String UserLogin = login.Text;
            SqlCommand Com;
            try
            {
                bool f = UL.RestrictionFunc(pas.Text);
                if(f==false)
                {
                    MessageBox.Show("Невірний формат паролю");
                    pas.Text = "";
                    pas2.Text = "";
                    return;
                }
                if(pas.Text!=pas2.Text)
                {
                    MessageBox.Show("паролі не співпадають");
                }
                if (ld.connection.State == System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO Users (Name, Surname, Login, Status, Restriction, Password) values('"+name.Text+"', '"+surname.Text+"', '" + UserLogin + "', 1, 1, '"+pas.Text+"'); ";

                    Com = new SqlCommand(strQ, ld.connection);
                    Com.ExecuteNonQuery();
                }
                //ld.ShowDataGrid(datagridshow);
                //username.Content = ld.dT.Rows[0][0].ToString();
               // usersurname.Content = ld.dT.Rows[0][1].ToString();
                //userlogin.Content = ld.dT.Rows[0][2].ToString();
                //userstatus.Content = ld.dT.Rows[0][3].ToString();
               // userrestriction.Content = ld.dT.Rows[0][4].ToString();
               // ld.index = 0;
                //ld.createlist(userslist);
                MessageBox.Show("Користувача додано!");
                //newlog.Text = "";
            }
            catch
            {
                MessageBox.Show("Користувача не додано! Можливо такий в базі вже є!");
                login.Text = "";
            }
            ld.connection.Close();
        }
    }
}
