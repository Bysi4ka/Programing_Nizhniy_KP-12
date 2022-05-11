using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kyrsova
{
    /*static class DataB
    {
        static public SqlConnection connection = new SqlConnection();
        static public SqlCommand command;
        static public SqlDataAdapter adapter;
        static public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static public void GetAndDhowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        static public void firmbookData(DataGrid datagrid, string sqlQ)
        {
           
            try
            {
                GetAndDhowData(sqlQ, datagrid);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }*/
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
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
            gotofirmbo.Background = myBrush2;
            gotosellers.Background = myBrush2;
            gotobuyers.Background = myBrush2;
            this.Background = myBrush;
        }


        private void gotofirmbo_Click(object sender, RoutedEventArgs e)
        {
            Firmbook w = new Firmbook();
            this.Hide();
            w.Show();
        }

        private void gotosellers_Click(object sender, RoutedEventArgs e)
        {
            sellers w = new sellers();
            Hide();
            w.Show();
        }

        private void gotosellers_Copy_Click(object sender, RoutedEventArgs e)
        {
            Buyers w = new Buyers();
            Hide();
            w.Show();
        }
    }
}
