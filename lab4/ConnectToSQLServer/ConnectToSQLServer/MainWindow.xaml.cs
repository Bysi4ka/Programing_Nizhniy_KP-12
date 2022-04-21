using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace ConnectToSQLServer
{
    public partial class MainWindow : Window
    {
        string connectionString = null;        
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //MessageBox.Show(connectionString);
            GetStudentsData();
            GetSubjectsData();
            GetGroupsData();
            GetAllMarks();
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

        private void GetStudentsData()
        {
            string sqlQ = "SELECT IDStudent as [№], " +
                       "StudentSurname as Прізвище, " +
                       "StudentName as [ім'я], " +
                       "StudentSecondName as [по батькові] " +
                    "FROM Students;";
            try
            {
                GetAndDhowData(sqlQ, StudentsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetSubjectsData()
        {
            string sqlQ = "SELECT IDSubject as [№], " +
                       "SubjectName as [Назва дисципліни] " +                       
                    "FROM Subjects;";
            try
            {
                GetAndDhowData(sqlQ, SubjectsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetGroupsData()
        {
            string sqlQ = "SELECT IDGroup as [№], " +
                       "GroupName as Назва " +                       
                    "FROM Groups;";
            try
            {
                GetAndDhowData(sqlQ, GroupsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetAllMarks()
        {
            string sqlQ = "SELECT dbo.Students.StudentSurname AS Прізвище, " +
                "dbo.Students.StudentName AS [Ім'я], " +
                "dbo.Groups.GroupName AS Група, " +
                "dbo.Subjects.SubjectName AS [Назва предмету], " +
                "dbo.Marks.Mark AS Оцінка " +
                "FROM dbo.Students INNER JOIN " +
                "dbo.Marks ON dbo.Students.IDStudent = dbo.Marks.IDStudent INNER JOIN " +
                "dbo.StudentsInGroups ON dbo.Students.IDStudent = dbo.StudentsInGroups.IDStudent INNER JOIN " +
                "dbo.Groups ON dbo.StudentsInGroups.IDGroup = dbo.Groups.IDGroup INNER JOIN " +
                "dbo.Subjects ON dbo.Marks.IDSubject = dbo.Subjects.IDSubject " +
             "ORDER BY Група, Прізвище, [Ім'я]";
            try
            {
                GetAndDhowData(sqlQ, MarksDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}