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
using System.IO;

namespace lab1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        
        public Window2()
        {
            
            InitializeComponent();
            ininControls();

            StreamReader sr = new StreamReader("D:/KPI/Прога2/lab2/basa.txt");
            while (!sr.EndOfStream)
            {
                s.Add(sr.ReadLine());

            }
        }
        static int M = 9;
        static int N = 6;
        TextBox[] tb = new TextBox[4];
        private void ininControls()
        {
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = this.Width-0.03* this.Width;
            myGrid.Height = this.Height - 0.09 * this.Height;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;
            /*Button nextW = new Button();
            nextW.Height = 50;
            nextW.Width = 50;*/
            //nextW.Margin = 10;
            // this.AddChild(nextW);
           /* Button[,] ArrBtn = new Button[M, N];
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


                 }
             for (int i = 0; i < M; i++)
                 for (int j = 0; j < N; j++)
                 {
                     myGrid.Children.Add(ArrBtn[i, j]);
                 }*/
           //button main
            Button ret = new Button();
            ret.Click += main_Click;
            ret.Content = "main";
            Grid.SetRow(ret, 1);
            Grid.SetColumn(ret, 5);
            myGrid.Children.Add(ret);
            //Label 1
            Label l1 = new Label();
            l1.Content = "№ залікової книжки";
            l1.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(l1, 3);
            Grid.SetColumn(l1, 0);
            myGrid.Children.Add(l1);
            //TextBox1
            TextBox t1 = new TextBox();
            Grid.SetRow(t1, 3);
            Grid.SetColumn(t1, 1);
            t1.Name = "t1";
            tb[0] = t1;
            myGrid.Children.Add(t1);

            //Label 2
            Label l2 = new Label();
            l2.Content = "ПIБ";
            l2.VerticalAlignment = VerticalAlignment.Center;
            l2.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(l2, 3);
            Grid.SetColumn(l2, 2);
            myGrid.Children.Add(l2);
            //TextBox2
            TextBox t2 = new TextBox();
            Grid.SetRow(t2, 3);
            Grid.SetColumn(t2, 3);
            tb[1] = t2;
            myGrid.Children.Add(t2);
            //Label 3
            Label l3 = new Label();
            l3.Content = "Особистi даннi";
            l3.VerticalAlignment = VerticalAlignment.Center;
            l3.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(l3, 3);
            Grid.SetColumn(l3, 4);
            myGrid.Children.Add(l3);
            //TextBox3
            TextBox t3 = new TextBox();
            Grid.SetRow(t3, 3);
            Grid.SetColumn(t3, 5);
            tb[2] = t3;
            myGrid.Children.Add(t3);
            //button Add
            Button ad = new Button();
            ad.Click += add_Click;
            ad.Content = "Додати";
            
            Grid.SetRow(ad, 5);
            Grid.SetColumn(ad, 4);
            myGrid.Children.Add(ad);
            //Label 4
            Label l4 = new Label();
           
            //l4.FontWeight= FontWeights.Bold;
            l4.Content = "№ залікової книжки";

            
            l4.VerticalAlignment = VerticalAlignment.Center;
            l4.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(l4, 7);
            Grid.SetColumn(l4, 1);
            myGrid.Children.Add(l4);
            //TextBox3
            TextBox t4 = new TextBox();
            Grid.SetRow(t4, 7);
            Grid.SetColumn(t4, 2);
            tb[3] = t4;
            myGrid.Children.Add(t4);
            //button Delete
            Button del = new Button();
            del.Click += delete_Click;
            del.Content = "Видaлити";
            Grid.SetRow(del, 7);
            Grid.SetColumn(del, 3);
            myGrid.Children.Add(del);
            //button Exit
            Button ex = new Button();
            ex.Click += exi_Click;
            ex.Content = "Exit";
            Grid.SetRow(ex, 7);
            Grid.SetColumn(ex, 5);
            myGrid.Children.Add(ex);


            this.Content = myGrid; // this.Content = myGrid;
                                   //  this.Show();
        }
        List<string> s = new List<string>();

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }
        private void main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter sw = new StreamWriter("D:/KPI/Прога2/lab2/basa.txt");
            string ss = tb[0].Text + " " + tb[1].Text + " " + tb[2].Text;
            s.Add(ss);
            for(int i=0;i<s.Count-1;i++)
            {
                sw.WriteLine(s[i]);
            }
            sw.Write(s[s.Count-1]);

            sw.Close();
            
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter sw = new StreamWriter("D:/KPI/Прога2/lab2/basa.txt");
            string ss = tb[0].Text + " " + tb[1].Text + " " + tb[2].Text;
            s.Add(ss);
            for (int i = 0; i < s.Count - 1; i++)
            {
                sw.WriteLine(s[i]);
            }
            sw.Write(s[s.Count - 1]);

            sw.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("D:/KPI/Прога2/lab2/basa.txt");
            for (int i=0; i<s.Count; i++)
            {
                string[] ss = s[i].Split(' ');
                if (tb[3].Text == ss[0])
                { 
                    s.RemoveAt(i);
                    break;
                }

                
            }

            for (int i = 0; i < s.Count - 1; i++)
            {
                sw.WriteLine(s[i]);
            }
            sw.Write(s[s.Count - 1]);
            sw.Close();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("D:/KPI/Прога2/lab2/basa.txt");
            for (int i = 0; i < s.Count; i++)
            {
                string[] ss = s[i].Split(' ');
                if (tb[3].Text == ss[0])
                {
                    s.RemoveAt(i);
                    break;
                }


            }

            for (int i = 0; i < s.Count - 1; i++)
            {
                sw.WriteLine(s[i]);
            }
            sw.Write(s[s.Count - 1]);
            sw.Close();
        }

        private void b2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void exi_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
