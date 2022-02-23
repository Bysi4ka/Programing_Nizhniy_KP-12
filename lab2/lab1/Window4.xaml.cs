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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            initControls();
        }
        static int M = 9;
        static int N = 11;
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
            ComboBox cb1 = new ComboBox();
            ListBoxItem lb1 = new ListBoxItem();
            ListBoxItem lb2 = new ListBoxItem();
            lb1.Content = "x";
            lb2.Content = "o";
            cb1.Items.Add(lb1);
            cb1.Items.Add(lb2);

            ComboBox[,] ArrBtn = new ComboBox[M, N];
            for (int i = 2; i < 7; i++)
                for (int j = 3; j < 8; j++)
                {
                    ArrBtn[i, j] = new ComboBox();
                    ListBoxItem lb = new ListBoxItem();
                    ListBoxItem lbb = new ListBoxItem();
                    lb.Content = "x";
                    lbb.Content = "o";
                    ArrBtn[i,j].Items.Add(lb);
                    ArrBtn[i, j].Items.Add(lbb);

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
            for (int i = 2; i < 7; i++)
                for (int j = 3; j < 8; j++)
                {
                    Grid.SetRow(ArrBtn[i, j], i);
                    Grid.SetColumn(ArrBtn[i, j], j);


                }

            //Label 1
            Label l1 = new Label();
            l1.Content = "Side";
            l1.VerticalAlignment = VerticalAlignment.Center;
            l1.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(l1, 1);
            Grid.SetColumn(l1, 1);
            myGrid.Children.Add(l1);
            //button main
            Button ret = new Button();
            ret.Click += main_Click;
            ret.Content = "main";
            Grid.SetRow(ret, 1);
            Grid.SetColumn(ret, 9);
            myGrid.Children.Add(ret);
            //button Exit
            Button ex = new Button();
            ex.Click += exi_Click;
            ex.Content = "Exit";
            Grid.SetRow(ex, 7);
            Grid.SetColumn(ex, 9);
            myGrid.Children.Add(ex);

            Grid.SetRow(cb1, 2);
            Grid.SetColumn(cb1, 1);
            myGrid.Children.Add(cb1);
            cols[9].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(2) + "*");

            for (int i = 2; i < 7; i++)
                for (int j = 3; j < 8; j++)
                {
                    myGrid.Children.Add(ArrBtn[i, j]);
                }
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
        private void ArrBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show(btn.Content.ToString());
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
