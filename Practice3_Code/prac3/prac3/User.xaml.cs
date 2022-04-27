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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            name.Text = UL.name;
            surname.Text = UL.surname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginuser w = new loginuser();
            this.Hide();
            w.Show();
        }

        LogDT ld = new LogDT();
        
        private void update_Click(object sender, RoutedEventArgs e)
        {
           // DataTable dt = new DataTable();
           // string login = "admin";
           // dt = ld.ShowPas(dt, login);
           // string realpas = dt.Rows[0][0].ToString();
           // string pas = pascur.Text;
            string newps = pas.Text;
            string newpsr = pas2.Text;
            bool f = UL.RestrictionFunc(newps);
            if (UL.restriction == "False") f = true;
            ld.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            if (newps == newpsr && newps != "" && f==true && name.Text!="")
            {
                string strQ;
                SqlCommand Com;
                ld.connection = new SqlConnection(ld.connectionString);
                ld.connection.Open();
                if (ld.connection.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE Users SET Password ='" + newps + "', Name ='"+name.Text+"', Surname ='"+surname.Text+"'  WHERE Login = '"+UL.ul+"'; ";
                    Com = new SqlCommand(strQ, ld.connection);
                    Com.ExecuteNonQuery();
                }
                ld.connection.Close();
                MessageBox.Show("Данні оновлено");
                //pascur.Text = "";
               // newpas.Text = "";
                //newpasrep.Text = "";

            }
            else
            {
                MessageBox.Show("Некоректні данні");
               // pascur.Text = "";
               // newpas.Text = "";
                //newpasrep.Text = "";

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }
    }
}
