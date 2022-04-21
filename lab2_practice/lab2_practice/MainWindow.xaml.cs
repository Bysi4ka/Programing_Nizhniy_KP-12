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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2_practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int M = 2;
        static int N = 1;
        public MainWindow()
        {
            InitializeComponent();
            initControls();
        }
        private void initControls()
        {
                this.Title = "New Test Windows and Controls";
                this.ResizeMode = ResizeMode.NoResize;
                Grid myGrid = new Grid();
                myGrid.Width = this.Width-10;
                myGrid.Height = this.Height -10;
                myGrid.HorizontalAlignment = HorizontalAlignment.Center;
                myGrid.VerticalAlignment = VerticalAlignment.Center;
                myGrid.ShowGridLines = true;
                /*Button nextW = new Button();
                nextW.Height = 50;
                nextW.Width = 50;*/
                //nextW.Margin = 10;
               // this.AddChild(nextW);
                Button[,] ArrBtn = new Button[M, N];
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                    {
                        ArrBtn[i, j] = new Button();
                        ArrBtn[i, j].Click += ArrBtn_Click;

                        ArrBtn[i, j].Content = "(" + (1 + i).ToString() + "; "
                        + (1 + j).ToString() + ")";

                    }
                RowDefinition[] rows = new RowDefinition[M];
                ColumnDefinition[] cols = new ColumnDefinition[N];
                GridLengthConverter glc = new GridLengthConverter();
                for (int i = 0; i < M; i++)
                {
                    rows[i] = new RowDefinition();
                    myGrid.RowDefinitions.Add(rows[i]);
                }
                for (int i = 0; i < N; i++)
                {
                    cols[i] = new ColumnDefinition();
                    myGrid.ColumnDefinitions.Add(cols[i]);
                }
                for (int i = 1; i < M; i++)
                    for (int j = 0; j < N; j++)
                    {
                        Grid.SetRow(ArrBtn[i, j], i);
                        Grid.SetColumn(ArrBtn[i, j], j);

                   
                    }
               // rows[2].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(3) + "*");
            
                for (int i = 1; i < M; i++)
                    for (int j = 0; j < N; j++)
                    {
                        myGrid.Children.Add(ArrBtn[i, j]);
                    }
            Grid mygrid2 = new Grid();
            mygrid2.HorizontalAlignment = HorizontalAlignment.Center;
            mygrid2.VerticalAlignment = VerticalAlignment.Center;
            //mygrid2.Width = this.Width;
            //mygrid2.Height = this.Height/2;
            mygrid2.ShowGridLines = true;
            RowDefinition[] rows2 = new RowDefinition[M];
            ColumnDefinition[] cols2 = new ColumnDefinition[N];
            Button[,] ArrBtn2 = new Button[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    ArrBtn2[i, j] = new Button();
                    ArrBtn2[i, j].Click += ArrBtn_Click;

                    ArrBtn2[i, j].Content = "(" + (1 + i).ToString() + "; "
                    + (1 + j).ToString() + ")";

                }
            for (int i = 0; i < M; i++)
            {
                rows2[i] = new RowDefinition();
                mygrid2.RowDefinitions.Add(rows2[i]);
            }
            for (int i = 0; i < N; i++)
            {
                cols2[i] = new ColumnDefinition();
                mygrid2.ColumnDefinitions.Add(cols2[i]);
            }
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(ArrBtn2[i, j], i);
                    Grid.SetColumn(ArrBtn2[i, j], j);


                }
            // rows[2].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(3) + "*");

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    mygrid2.Children.Add(ArrBtn2[i, j]);
                }
            Grid.SetRow(mygrid2, 0);
            Grid.SetColumn(mygrid2, 0);
            myGrid.Children.Add(mygrid2);


            this.Content = myGrid; // this.Content = myGrid;
          //  this.Show();
        }

        private void ArrBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show(btn.Content.ToString());
        }
    }
}
