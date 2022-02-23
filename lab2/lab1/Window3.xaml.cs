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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            initcontrols();
        }
        static int M = 6;
        static int N = 5;
        private void initcontrols()
        {
            this.Title = "New Test Windows and Controls";
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = this.Width - 10;
            myGrid.Height = this.Height - 10;
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
            /*for (int i = 1; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(ArrBtn[i, j], i);
                    Grid.SetColumn(ArrBtn[i, j], j);


                }*/
             rows[3].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(5) + "*");
             cols[1].Width = (GridLength)glc.ConvertFrom(Convert.ToDouble(1.5) + "*");

            /* for (int i = 1; i < M; i++)
                 for (int j = 0; j < N; j++)
                 {
                     myGrid.Children.Add(ArrBtn[i, j]);
                 }*/

            //grid2
            Grid mygrid2 = new Grid();
            mygrid2.HorizontalAlignment = HorizontalAlignment.Center;
            mygrid2.VerticalAlignment = VerticalAlignment.Center;
            mygrid2.Width = this.Width*0.27;
            mygrid2.Height = this.Height*0.5;
            mygrid2.ShowGridLines = true;
            RowDefinition[] rows2 = new RowDefinition[5];
            ColumnDefinition[] cols2 = new ColumnDefinition[4];
            /*Button[,] ArrBtn2 = new Button[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    ArrBtn2[i, j] = new Button();
                    ArrBtn2[i, j].Click += ArrBtn_Click;

                    ArrBtn2[i, j].Content = "(" + (1 + i).ToString() + "; "
                    + (1 + j).ToString() + ")";

                }*/
            for (int i = 0; i < 5; i++)
            {
                rows2[i] = new RowDefinition();
                mygrid2.RowDefinitions.Add(rows2[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                cols2[i] = new ColumnDefinition();
                mygrid2.ColumnDefinitions.Add(cols2[i]);
            }
            /*for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(ArrBtn2[i, j], i);
                    Grid.SetColumn(ArrBtn2[i, j], j);


                }*/
            // rows[2].Height = (GridLength)glc.ConvertFrom(Convert.ToDouble(3) + "*");

            /*for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    mygrid2.Children.Add(ArrBtn2[i, j]);
                }*/
            //button 1
            Button b1 = new Button();
            b1.Click += b1_Click;
            b1.Content = "1";
            Grid.SetRow(b1, 3);
            Grid.SetColumn(b1, 0);
            mygrid2.Children.Add(b1);
            //button 2
            Button b2 = new Button();
            b2.Click += b2_Click;
            b2.Content = "2";
            Grid.SetRow(b2, 3);
            Grid.SetColumn(b2, 1);
            mygrid2.Children.Add(b2);
            //button 3
            Button b3 = new Button();
            b3.Click += b33_Click;
            b3.Content = "3";
            Grid.SetRow(b3, 3);
            Grid.SetColumn(b3, 2);
            mygrid2.Children.Add(b3);
            //button 4
            Button b4 = new Button();
            b4.Click += b4_Click;
            b4.Content = "4";
            Grid.SetRow(b4, 2);
            Grid.SetColumn(b4, 0);
            mygrid2.Children.Add(b4);
            //button 5
            Button b5 = new Button();
            b5.Click += b5_Click;
            b5.Content = "5";
            Grid.SetRow(b5, 2);
            Grid.SetColumn(b5, 1);
            mygrid2.Children.Add(b5);
            //button 6
            Button b6 = new Button();
            b6.Click += b6_Click;
            b6.Content = "6";
            Grid.SetRow(b6, 2);
            Grid.SetColumn(b6, 2);
            mygrid2.Children.Add(b6);
            //button 7
            Button b7 = new Button();
            b7.Click += b7_Click;
            b7.Content = "7";
            Grid.SetRow(b7, 1);
            Grid.SetColumn(b7, 0);
            mygrid2.Children.Add(b7);
            //button 8
            Button b8 = new Button();
            b8.Click += b8_Click;
            b8.Content = "8";
            Grid.SetRow(b8, 1);
            Grid.SetColumn(b8, 1);
            mygrid2.Children.Add(b8);
            //button 9
            Button b9 = new Button();
            b9.Click += b9_Click;
            b9.Content = "9";
            Grid.SetRow(b9, 1);
            Grid.SetColumn(b9, 2);
            mygrid2.Children.Add(b9);
            //TextBox
            //TextBox t4 = new TextBox();
            tb.VerticalAlignment = VerticalAlignment.Bottom;
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.FontSize = 16;
            Grid.SetRow(tb, 2);
            Grid.SetColumn(tb, 1);
            //tb[3] = t4;
            myGrid.Children.Add(tb);
            //Label 
            Label l4 = new Label();
            l4.Content = "Калькулятор";
            l4.FontSize = 17;
            l4.VerticalAlignment = VerticalAlignment.Center;
            l4.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(l4, 1);
            Grid.SetColumn(l4, 1);
            myGrid.Children.Add(l4);
            //button =
            Button b10 = new Button();
            Brush br = new SolidColorBrush(Color.FromRgb(150, 75, 0));
            b10.Background = br;
            b10.Click += b10_Click;
            b10.Content = "=";
            Grid.SetRow(b10, 0);
            Grid.SetColumn(b10, 1);
            mygrid2.Children.Add(b10);
            //button C
            Button b11 = new Button();
            b11.Click += b11_Click;
            b11.Content = "C";
            Grid.SetRow(b11, 0);
            Grid.SetColumn(b11, 2);
            mygrid2.Children.Add(b11);
            //button del
            Button b12 = new Button();
            b12.Click += b12_Click;
            b12.Content = "del";
            Grid.SetRow(b12, 0);
            Grid.SetColumn(b12, 3);
            mygrid2.Children.Add(b12);
            //button /
            Button b13 = new Button();
            b13.Click += b13_Click;
            b13.Content = "/";
            Grid.SetRow(b13, 1);
            Grid.SetColumn(b13, 3);
            mygrid2.Children.Add(b13);
            //button x
            Button b14 = new Button();
            b14.Click += b14_Click;
            b14.Content = "x";
            Grid.SetRow(b14, 2);
            Grid.SetColumn(b14, 3);
            mygrid2.Children.Add(b14);
            //button -
            Button b15 = new Button();
            b15.Click += b15_Click;
            b15.Content = "-";
            Grid.SetRow(b15, 3);
            Grid.SetColumn(b15, 3);
            mygrid2.Children.Add(b15);
            //button +
            Button b16 = new Button();
            b16.Click += b16_Click;
            b16.Content = "+";
            Grid.SetRow(b16, 4);
            Grid.SetColumn(b16, 3);
            mygrid2.Children.Add(b16);
            //button .
            Button b17 = new Button();
            b17.Click += b17_Click;
            b17.Content = ".";
            Grid.SetRow(b17, 4);
            Grid.SetColumn(b17, 2);
            mygrid2.Children.Add(b17);
            //button 0
            Button b18 = new Button();
            b18.Click += b18_Click;
            b18.Content = "0";
            Grid.SetRow(b18, 4);
            Grid.SetColumn(b18, 1);
            mygrid2.Children.Add(b18);
            //button +/-
            Button b19 = new Button();
            //b18.Click += b18_Click;
            b19.Content = "+/-";
            Grid.SetRow(b19, 4);
            Grid.SetColumn(b19, 0);
            mygrid2.Children.Add(b19);
            //button main
            Button ret = new Button();
            ret.Click += main_Click;
            ret.Content = "main";
            Grid.SetRow(ret, 1);
            Grid.SetColumn(ret, 4);
            myGrid.Children.Add(ret);
            //button Exit
            Button ex = new Button();
            ex.Click += exi_Click;
            ex.Content = "Exit";
            Grid.SetRow(ex, 4);
            Grid.SetColumn(ex, 4);
            myGrid.Children.Add(ex);

            Grid.SetRow(mygrid2, 3);
            Grid.SetColumn(mygrid2, 1);
            myGrid.Children.Add(mygrid2);
            this.Content = myGrid;
        }
        TextBox tb = new TextBox();

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
        private void exi_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if(tb.Text.Length!=24)
            tb.Text = tb.Text + '1';
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '1';
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '2';
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '2';
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '3';
        }
        private void b33_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '3';
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '4';
        }
        private void b4_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '4';
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '5';
        }
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '5';
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '6';
        }
        private void b6_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '6';
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '7';
        }
        private void b7_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '7';
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '8';
        }
        private void b8_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '8';
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '9';
        }
        private void b9_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1 && tb.Text[0] == '0') return;
            if (tb.Text.Length != 24)
                tb.Text = tb.Text + '9';
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if(tb.Text.Length==1)
            {
                if (tb.Text[0] == '0') return;
            }
            else if(tb.Text.Length > 2)
            {
                if (tb.Text[tb.Text.Length - 1] == '0')
                    if (tb.Text[tb.Text.Length - 2] == '+' || tb.Text[tb.Text.Length - 2] == '-' || tb.Text[tb.Text.Length - 2] == 'x' || tb.Text[tb.Text.Length - 2] == '/')
                        return;
                    
            }
            tb.Text = tb.Text + '0';
        }
        private void b18_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 1)
            {
                if (tb.Text[0] == '0') return;
            }
            else if (tb.Text.Length > 2)
            {
                if (tb.Text[tb.Text.Length - 1] == '0')
                    if (tb.Text[tb.Text.Length - 2] == '+' || tb.Text[tb.Text.Length - 2] == '-' || tb.Text[tb.Text.Length - 2] == 'x' || tb.Text[tb.Text.Length - 2] == '/')
                        return;

            }
            tb.Text = tb.Text + '0';
        }
        bool ch = false;

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (ch == true) return;
            
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
                return;
            ch = true;
            tb.Text = tb.Text + '.';


        }
        private void b17_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (ch == true) return;

            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
                return;
            ch = true;
            tb.Text = tb.Text + '.';


        }
        bool oper = false;
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += '+';
                return;

            }
            if (oper==true)
            {
                //oper = false;
                dor();
                tb.Text += '+';
                return;
            }

            if (tb.Text.Length == 0) return;
            
            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            ch = false;
            tb.Text += '+';
            oper = true;
               
        }
        private void b16_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += '+';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                tb.Text += '+';
                return;
            }

            if (tb.Text.Length == 0) return;

            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            ch = false;
            tb.Text += '+';
            oper = true;

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '.') ch = false;
            tb.Text = tb.Text.Remove(tb.Text.Length - 1);

        }
        private void b12_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '.') ch = false;
            tb.Text = tb.Text.Remove(tb.Text.Length - 1);

        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            ch = false;
        }
        private void b11_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
            ch = false;
        }
        private void dor()
        {
            /*if (tb.Text.Length <= 1) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
                return;*/
            string s = tb.Text;
            double a = 0, b = 0, ans=0;
            string[] n = new string[2];
            n[0] = "";
            n[1] = "";
            char op =' ';
            int k = 0;
            /*int[] m = new int[2];
            m[0] = 0; m[1] = 0;*/
            int j = 0;
            for(int i=0; i<s.Length; i++)
            {
                if (s[i] == '+' || s[i] == '-' || s[i] == 'x' || s[i] == '/')
                {
                    op = s[i];
                    k++;
                    j++;
                }
                else
                {
                    //m[j]++;
                    n[k] += s[i];
                }
                    
            }
            if (n[1] == "") return;
            if (op == ' ') return;
            a = Double.Parse(n[0]);
            b = Double.Parse(n[1]);
            if (op == '+') ans = a + b;
            else if (op == '-') ans = a - b;
            else if (op == '/')
            {
                if (b == 0) return;
                else ans = a / b;
            }
            else if (op == 'x') ans = a * b;
            if (Math.Round(ans) != ans) ch = true;
            tb.Text = Convert.ToString(ans);


        }
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            dor();
            oper = false;
        }
        private void b10_Click(object sender, RoutedEventArgs e)
        {
            dor();
            oper = false;
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += '-';
                return;

            }
            if (oper == true)
            {
               // oper = false;
                dor();
                tb.Text += '-';
                return;
            }
            if (tb.Text.Length == 0) return;
            
            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            ch = false;
            oper = true;
            tb.Text += '-';
        }
        private void b15_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += '-';
                return;

            }
            if (oper == true)
            {
                // oper = false;
                dor();
                tb.Text += '-';
                return;
            }
            if (tb.Text.Length == 0) return;

            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            ch = false;
            oper = true;
            tb.Text += '-';
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += '/';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                tb.Text += '/';
                return;
            }
            if (tb.Text.Length == 0) return;
            
            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            oper = true;
            ch = false;
            tb.Text += '/';
        }
        private void b13_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += '/';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                tb.Text += '/';
                return;
            }
            if (tb.Text.Length == 0) return;

            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            oper = true;
            ch = false;
            tb.Text += '/';
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += 'x';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                tb.Text += 'x';
                return;
            }
            if (tb.Text.Length == 0) return;
            
            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            ch = false;
            oper = true;
            tb.Text += 'x';
        }
        private void b14_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length == 0) return;
            if (tb.Text[tb.Text.Length - 1] == '+' || tb.Text[tb.Text.Length - 1] == '-' || tb.Text[tb.Text.Length - 1] == 'x' || tb.Text[tb.Text.Length - 1] == '/')
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
                tb.Text += 'x';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                tb.Text += 'x';
                return;
            }
            if (tb.Text.Length == 0) return;

            if (tb.Text[tb.Text.Length - 1] == '.')
                return;
            ch = false;
            oper = true;
            tb.Text += 'x';
        }

        private void b2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
