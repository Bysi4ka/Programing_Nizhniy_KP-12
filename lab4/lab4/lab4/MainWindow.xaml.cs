
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public MainWindow()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            InitializeComponent();
            firmbookData();
            forsaleData();
            soldData();
            byerData();
            sellerData();
           // string con = "Data Source=IOANPC\MSSQLSERVER1;Initial Catalog=AuctionDB;Integrated Security=True";

        }
        private void GetAndDhowData(string SQLQuery, DataGrid dataGrid)
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
        private void firmbookData()
        {
            string sqlQ = "SELECT nameofauction as Назва, date as Дата, place as Мiсце, time as Час, specification as Опис FROM dbo.firmbook";
            try
            {
                GetAndDhowData(sqlQ, firmbook);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void forsaleData()
        {
            string sqlQ = "SELECT dbo.forsale.nameofauction as [Назва аукцiону], dbo.forsale.numberoflot as [Номер лота], dbo.forsale.startprize as [Стартова цiна], dbo.seller.name as [Iм'я продавця], dbo.seller.surname as [Прiзвище продавця], dbo.forsale.description as [Опис]" + "FROM dbo.forsale " + "INNER JOIN dbo.seller ON dbo.forsale.sellerID = dbo.seller.ID";
            try
            {
                GetAndDhowData(sqlQ, forsale);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void soldData()
        {
            string sqlQ = "SELECT dbo.byer.name as [Ім'я покупця], dbo.byer.surname as [Прізвище покупця], dbo.sold.prize as [Ціна продажі], dbo.forsale.description as Опис FROM dbo.sold INNER JOIN dbo.byer ON dbo.sold.byerID = dbo.byer.ID INNER JOIN dbo.forsale ON dbo.sold.ID = dbo.forsale.ID";
            try
            {
                GetAndDhowData(sqlQ, sold);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void byerData()
        {
            string sqlQ = "SELECT name as [Ім'я покупця], surname as [Прізвище покупця] FROM dbo.byer";
            try
            {
                GetAndDhowData(sqlQ, byer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void sellerData()
        {
            string sqlQ = "SELECT name as [Ім'я продавця], surname as [Прізвище продавця] FROM dbo.seller";
            try
            {
                GetAndDhowData(sqlQ, seller);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
