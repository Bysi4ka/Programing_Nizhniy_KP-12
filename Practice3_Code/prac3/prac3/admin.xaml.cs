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
    public class LogDT
    {
       public string connectionString = null;
       public SqlConnection connection = null;
       public SqlCommand command;
       public SqlDataAdapter adapter;
       private void ShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dT = Table;
            maxindex = Table.Rows.Count;
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        public DataTable dT = new DataTable();
        public int maxindex = 0;
        public int index = 0;
        public string realpasw = "";
        public void ShowDataGrid(DataGrid dataGrid)
        {
            string sqlQ = "SELECT Name, Surname, Login, Status, Restriction, Password FROM dbo.Users where Login != 'admin'";
            try
            {
                ShowData(sqlQ, dataGrid);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public DataTable ShowPas(DataTable dataTable, string log)
        {
            string sqlQ = "SELECT Password FROM dbo.Users where Login = '"+log+"'";
            try
            {
               dataTable =  ShowOneData(sqlQ, dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public DataTable ShowRow(DataTable dataTable, string log)
        {
            string sqlQ = "SELECT Password, Status, Restriction, Name, Surname FROM dbo.Users where Login = '" + log + "'";
            try
            {
                dataTable = ShowOneData(sqlQ, dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        private DataTable ShowOneData(string SQLQuery, DataTable dataTable)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            //DataTable Table = new DataTable();
            adapter.Fill(dataTable);
            //dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
            return dataTable;
        }
        public void createlist (ComboBox combobox)
        {
            DataTable dtB = new DataTable();
            dtB = ShowTable(dtB);
            combobox.Items.Clear();
            for(int i =0; i<maxindex; i++)
            {
                ListBoxItem lb = new ListBoxItem();
                lb.Content = dtB.Rows[i][2].ToString();
                combobox.Items.Add(lb);
            }
            
        }
        public DataTable ShowTable(DataTable dataTable)
        {
            string sqlQ = "SELECT Name, Surname, Login, Status, Restriction, Password FROM dbo.Users where Login != 'admin'";
            try
            {
                dataTable = ShowTable2(sqlQ, dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        private DataTable ShowTable2(string SQLQuery, DataTable dataTable)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            //DataTable Table = new DataTable();
            adapter.Fill(dataTable);
            //dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
            return dataTable;
        }


    }
    
    /// <summary>
    /// Interaction logic for admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        LogDT ld = new LogDT();

        public admin()
        {
            
            ld.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            ld.ShowDataGrid(datagridshow);
            username.Content = ld.dT.Rows[0][0].ToString();
            usersurname.Content = ld.dT.Rows[0][1].ToString();
            userlogin.Content = ld.dT.Rows[0][2].ToString();
            userstatus.Content = ld.dT.Rows[0][3].ToString();
            userrestriction.Content = ld.dT.Rows[0][4].ToString();
            ld.createlist(userslist);
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ld.index > 0)
            {
                ld.index--;
                username.Content = ld.dT.Rows[ld.index][0].ToString();
                usersurname.Content = ld.dT.Rows[ld.index][1].ToString();
                userlogin.Content = ld.dT.Rows[ld.index][2].ToString();
                userstatus.Content = ld.dT.Rows[ld.index][3].ToString();
                userrestriction.Content = ld.dT.Rows[ld.index][4].ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ld.index < ld.maxindex-1)
            {
                ld.index++;
                username.Content = ld.dT.Rows[ld.index][0].ToString();
                usersurname.Content = ld.dT.Rows[ld.index][1].ToString();
                userlogin.Content = ld.dT.Rows[ld.index][2].ToString();
                userstatus.Content = ld.dT.Rows[ld.index][3].ToString();
                userrestriction.Content = ld.dT.Rows[ld.index][4].ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            string login = "admin";
            dt = ld.ShowPas(dt, login);
            string realpas = dt.Rows[0][0].ToString();
            string pas = pascur.Text;
            string newps = newpas.Text;
            string newpsr = newpasrep.Text;
            if(realpas==pas && newps==newpsr && newps!="")
            {
                string strQ;
                SqlCommand Com;
                ld.connection = new SqlConnection(ld.connectionString);
                ld.connection.Open();
                if (ld.connection.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE Users SET Password ='" + newps + "' WHERE Login = 'admin'; ";
                    Com = new SqlCommand(strQ, ld.connection);
                    Com.ExecuteNonQuery();
                }
                ld.connection.Close();
                MessageBox.Show("Пароль змінено");
                pascur.Text = "";
                newpas.Text = "";
                newpasrep.Text = "";

            }
            else
            {
                MessageBox.Show("Некоректні данні");
                pascur.Text = "";
                newpas.Text = "";
                newpasrep.Text = "";

            }
        }

        private void adduser_Click(object sender, RoutedEventArgs e)
        {
            ld.connection = new SqlConnection(ld.connectionString);
            ld.connection.Open();
            String strQ;
            String UserLogin = newlog.Text;
            SqlCommand Com;
            try
            {
                if (ld.connection.State == System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO Users (Name, Surname, Login, Status, Restriction) values('', '', '" + UserLogin + "', 1, 0); ";
                
                    Com = new SqlCommand(strQ, ld.connection);
                    Com.ExecuteNonQuery();
                }
                ld.ShowDataGrid(datagridshow);
                username.Content = ld.dT.Rows[0][0].ToString();
                usersurname.Content = ld.dT.Rows[0][1].ToString();
                userlogin.Content = ld.dT.Rows[0][2].ToString();
                userstatus.Content = ld.dT.Rows[0][3].ToString();
                userrestriction.Content = ld.dT.Rows[0][4].ToString();
                ld.index = 0;
                ld.createlist(userslist);
                MessageBox.Show("Користувача додано!");
                newlog.Text = "";
            }
            catch
            {
                MessageBox.Show("Користувача не додано! Можливо такий в базі вже є!");
                newlog.Text = "";
            }
            ld.connection.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            logadmin w = new logadmin();
            this.Hide();
            w.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string login = userslist.Text;
            string strQ;
            SqlCommand Com;
            ld.connection = new SqlConnection(ld.connectionString);
            ld.connection.Open();
            if (ld.connection.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE Users SET Status ='" + status.IsChecked.ToString() + "' WHERE Login = '"+login+"'; ";
                Com = new SqlCommand(strQ, ld.connection);
                Com.ExecuteNonQuery();
            }
            ld.connection.Close();
            ld.ShowDataGrid(datagridshow);
            MessageBox.Show("Статус змінено");

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            string login = userslist.Text;
            string strQ;
            SqlCommand Com;
            ld.connection = new SqlConnection(ld.connectionString);
            ld.connection.Open();
            if (ld.connection.State == System.Data.ConnectionState.Open)
            {
                strQ = "UPDATE Users SET Restriction ='" + restriction.IsChecked.ToString() + "' WHERE Login = '" + login + "'; ";
                Com = new SqlCommand(strQ, ld.connection);
                Com.ExecuteNonQuery();
            }
            ld.connection.Close();
            ld.ShowDataGrid(datagridshow);
            MessageBox.Show("Статус змінено");
        }
    }
}
