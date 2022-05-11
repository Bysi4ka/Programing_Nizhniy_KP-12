using System;
using System.Collections.Generic;
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
    /// Interaction logic for income.xaml
    /// </summary>
    public partial class income : Window
    {
        public income()
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
            MainW.Background = myBrush2;
            this.Background = myBrush;
            string sqlQ = "SELECT TOP (100) PERCENT dbo.forsale.nameofauction as [Назва аукціону], SUM(dbo.sold.prize) AS Дохід FROM dbo.forsale INNER JOIN dbo.sold ON dbo.forsale.ID = dbo.sold.ID GROUP BY dbo.forsale.nameofauction ORDER BY Дохід DESC";
            DataControls.ShowData(incomeDG, sqlQ);
        }

        private void MainW_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Hide();
            w.Show();
        }
    }
}
