using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab1
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
            initControls();
        }
        static int M = 9;
        static int N = 8;
        private void initControls()
        {
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = this.Width - 0.03 * this.Width;
            myGrid.Height = this.Height - 0.09 * this.Height;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;
            /*Button nextW = new Button();
            nextW.Height = 50;
            nextW.Width = 50;*/
            //nextW.Margin = 10;
            // this.AddChild(nextW);
            /*Button[,] ArrBtn = new Button[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    ArrBtn[i, j] = new Button();
                    ArrBtn[i, j].Click += ArrBtn_Click;

                    ArrBtn[i, j].Content = "(" + (1 + i).ToString() + "; "
                    + (1 + j).ToString() + ")";

                }*/
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
           /* for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(ArrBtn[i, j], i);
                    Grid.SetColumn(ArrBtn[i, j], j);


                }*/
            rows[1].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(1.5) + "*");
            rows[0].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(0.5) + "*");
            rows[7].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(1.5) + "*");
            rows[6].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(3.5) + "*");
            rows[8].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(0.5) + "*");
            cols[1].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(1.5) + "*");
            cols[2].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(1.5) + "*");
            cols[4].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(3) + "*");
            cols[5].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(2.5) + "*");
            cols[6].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(1.5) + "*");
            //Label 1
            Label l1 = new Label();
            l1.Content = "About owner";
            l1.FontWeight = FontWeights.Bold;
            l1.FontSize = 22;
            l1.VerticalAlignment = VerticalAlignment.Center;
            l1.HorizontalAlignment = HorizontalAlignment.Center;
            l1.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l1, 1);
            Grid.SetColumn(l1, 4);
            myGrid.Children.Add(l1);
            //Label 1
            Label l2 = new Label();
            l2.Content = "Name";
            //l2.FontWeight = FontWeights.Bold;
            l2.FontSize = 17;
            l2.VerticalAlignment = VerticalAlignment.Center;
            l2.HorizontalAlignment = HorizontalAlignment.Center;
            l2.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l2, 3);
            Grid.SetColumn(l2, 1);
            myGrid.Children.Add(l2);
            //Label 1
            Label l3 = new Label();
            l3.Content = "Ivan";
            l3.FontWeight = FontWeights.Bold;
            l3.FontSize = 17;
            l3.VerticalAlignment = VerticalAlignment.Center;
            l3.HorizontalAlignment = HorizontalAlignment.Center;
            l3.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l3, 3);
            Grid.SetColumn(l3, 2);
            myGrid.Children.Add(l3);
            //Label 1
            Label l4 = new Label();
            l4.Content = "Sirname";
            //l2.FontWeight = FontWeights.Bold;
            l4.FontSize = 17;
            l4.VerticalAlignment = VerticalAlignment.Center;
            l4.HorizontalAlignment = HorizontalAlignment.Center;
            l4.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l4, 4);
            Grid.SetColumn(l4, 1);
            myGrid.Children.Add(l4);
            //Label 1
            Label l5 = new Label();
            l5.Content = "Nizhniy";
            l5.FontWeight = FontWeights.Bold;
            l5.FontSize = 17;
            l5.VerticalAlignment = VerticalAlignment.Center;
            l5.HorizontalAlignment = HorizontalAlignment.Center;
            l5.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l5, 4);
            Grid.SetColumn(l5, 2);
            myGrid.Children.Add(l5);
            //Label 1
            Label l6 = new Label();
            l6.Content = "Groupe";
            //l2.FontWeight = FontWeights.Bold;
            l6.FontSize = 17;
            l6.VerticalAlignment = VerticalAlignment.Center;
            l6.HorizontalAlignment = HorizontalAlignment.Center;
            l6.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l6, 5);
            Grid.SetColumn(l6, 1);
            myGrid.Children.Add(l6);
            //Label 1
            Label l7 = new Label();
            l7.Content = "KP-12";
            l7.FontWeight = FontWeights.Bold;
            l7.FontSize = 17;
            l7.VerticalAlignment = VerticalAlignment.Center;
            l7.HorizontalAlignment = HorizontalAlignment.Center;
            l7.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l7, 5);
            Grid.SetColumn(l7, 2);
            myGrid.Children.Add(l7);
            //Label 1
            Label l8 = new Label();
            l8.Content = "Year 2022";
            l8.FontWeight = FontWeights.Bold;
            l8.FontSize = 17;
            l8.VerticalAlignment = VerticalAlignment.Center;
            l8.HorizontalAlignment = HorizontalAlignment.Center;
            l8.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l8, 7);
            Grid.SetColumn(l8, 4);
            myGrid.Children.Add(l8);
            //button main
            Button ret = new Button();
            ret.Click += main_Click;
            ret.Content = "main";
            Grid.SetRow(ret, 1);
            Grid.SetColumn(ret, 6);
            myGrid.Children.Add(ret);
            //button Exit
            Button ex = new Button();
            ex.Click += exi_Click;
            ex.Content = "Exit";
            Grid.SetRow(ex, 7);
            Grid.SetColumn(ex, 6);
            myGrid.Children.Add(ex);

            /* for (int i = 0; i < M; i++)
                 for (int j = 0; j < N; j++)
                 {
                     myGrid.Children.Add(ArrBtn[i, j]);
                 }*/
            this.Content = myGrid; // this.Content = myGrid;
                                   //  this.Show();
        }
        private void main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }
        private void exi_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();   
        }

        private void b2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
