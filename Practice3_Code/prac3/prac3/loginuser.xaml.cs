using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

static class UL
{
    static public string ul = "";
    static public string name = "";
    static public string surname = "";
    static public string restriction = "";
    static public bool RestrictionFunc(String Pass)
    {
        Byte Count1, Count2, Count3;
        Byte LenPass = (Byte)Pass.Length;
        Count1 = Count2 = Count3 = 0;
        for (Byte i = 0; i < LenPass; i++)
        {
            if ((Convert.ToInt32(Pass[i]) >= 65) &&

            (Convert.ToInt32(Pass[i]) <= 65 + 25))

                Count1++;
            if ((Convert.ToInt32(Pass[i]) >= 97) &&

            (Convert.ToInt32(Pass[i]) <= 97 + 25))

                Count2++;
            if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') ||

            (Pass[i] == '/'))

                Count3++;
        }
        return (Count1 * Count2 * Count3 != 0);
    }
}
namespace prac3
{
    /// <summary>
    /// Interaction logic for loginuser.xaml
    /// </summary>
    public partial class loginuser : Window
    {
        public loginuser()
        {
            InitializeComponent();
        }
        int k = 0;

        private void cont_Click(object sender, RoutedEventArgs e)
        {

            LogDT ld = new LogDT();
            ld.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataTable dt = new DataTable();
            string login = log.Text;
            string realpas;
            try
            {
                dt = ld.ShowRow(dt, login);
                realpas = dt.Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("Користувача не знайдено");
                log.Text = "";
                pasw.Text = "";
                return;
            }
           // MessageBox.Show(dt.Rows[0][1].ToString());
            if(dt.Rows[0][1].ToString() == "False")
            {
                MessageBox.Show("Користувач деактивований");
                pasw.Text = "";
                log.Text = "";
                return;
            }
            
            string inpas = pasw.Text;
            if (realpas == inpas && login!="admin")
            {
                UL.ul = login;
                UL.name = dt.Rows[0][3].ToString();
                UL.surname = dt.Rows[0][4].ToString();
                UL.restriction = dt.Rows[0][2].ToString();
                User ww = new User();
                this.Hide();
                ww.Show();
            }
            else
            {
                k++;
                MessageBox.Show("Некоректні данні");
                pasw.Text = "";
                log.Text = "";
                if (k == 3) Application.Current.Shutdown();
            }
            /*admin w = new admin();
            this.Hide();
            w.Show();*/

            /*User w = new User();
            this.Hide();
            w.Show();*/
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }

        private void cont_Copy_Click(object sender, RoutedEventArgs e)
        {
            registration w = new registration();
            this.Hide();
            w.Show();
        }
    }
}
