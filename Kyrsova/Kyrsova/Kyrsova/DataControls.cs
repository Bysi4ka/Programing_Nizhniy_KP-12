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

namespace Kyrsova
{
    class DataControls
    {

        static public SqlConnection connection = new SqlConnection();
        static public SqlCommand command;
        static public SqlDataAdapter adapter;
        static public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static public void GetAndShowData(string SQLQuery, DataGrid dataGrid)
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
        static public void ShowData(DataGrid datagrid, string sqlQ)
        {

            try
            {
                GetAndShowData(sqlQ, datagrid);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        static public DataTable GetAndShowDataTable(string SQLQuery)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            connection.Close();
            return Table;
            //dataGrid.ItemsSource = Table.DefaultView;
            
        }
        static public void fillupCB(ComboBox cb, string sqlQ)
        {
            DataTable dt = GetAndShowDataTable(sqlQ);
            for(int i =0; i<dt.Rows.Count; i++)
            {
                cb.Items.Add(dt.Rows[i][0].ToString());
            }

        }
        

    }
}
