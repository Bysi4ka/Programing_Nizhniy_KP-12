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
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if(res.Text.Length!=24)
            res.Text = res.Text + '1';
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '2';
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '3';
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '4';
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '5';
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '6';
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '7';
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '8';
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 1 && res.Text[0] == '0') return;
            if (res.Text.Length != 24)
                res.Text = res.Text + '9';
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if(res.Text.Length==1)
            {
                if (res.Text[0] == '0') return;
            }
            else if(res.Text.Length > 2)
            {
                if (res.Text[res.Text.Length - 1] == '0')
                    if (res.Text[res.Text.Length - 2] == '+' || res.Text[res.Text.Length - 2] == '-' || res.Text[res.Text.Length - 2] == 'x' || res.Text[res.Text.Length - 2] == '/')
                        return;
                    
            }
            res.Text = res.Text + '0';
        }
        bool ch = false;

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 0) return;
            if (ch == true) return;
            
            if (res.Text[res.Text.Length - 1] == '+' || res.Text[res.Text.Length - 1] == '-' || res.Text[res.Text.Length - 1] == 'x' || res.Text[res.Text.Length - 1] == '/')
                return;
            ch = true;
            res.Text = res.Text + '.';


        }
        bool oper = false;
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 0) return;
            if (res.Text[res.Text.Length - 1] == '+' || res.Text[res.Text.Length - 1] == '-' || res.Text[res.Text.Length - 1] == 'x' || res.Text[res.Text.Length - 1] == '/')
            {
                res.Text = res.Text.Remove(res.Text.Length - 1);
                res.Text += '+';
                return;

            }
            if (oper==true)
            {
                //oper = false;
                dor();
                res.Text += '+';
                return;
            }

            if (res.Text.Length == 0) return;
            
            if (res.Text[res.Text.Length - 1] == '.')
                return;
            ch = false;
            res.Text += '+';
            oper = true;
               
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 0) return;
            if (res.Text[res.Text.Length - 1] == '.') ch = false;
            res.Text = res.Text.Remove(res.Text.Length - 1);

        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            res.Text = "";
            ch = false;
        }
        private void dor()
        {
            /*if (res.Text.Length <= 1) return;
            if (res.Text[res.Text.Length - 1] == '+' || res.Text[res.Text.Length - 1] == '-' || res.Text[res.Text.Length - 1] == 'x' || res.Text[res.Text.Length - 1] == '/')
                return;*/
            string s = res.Text;
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
            res.Text = Convert.ToString(ans);


        }
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            dor();
            oper = false;
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 0) return;
            if (res.Text[res.Text.Length - 1] == '+' || res.Text[res.Text.Length - 1] == '-' || res.Text[res.Text.Length - 1] == 'x' || res.Text[res.Text.Length - 1] == '/')
            {
                res.Text = res.Text.Remove(res.Text.Length - 1);
                res.Text += '-';
                return;

            }
            if (oper == true)
            {
               // oper = false;
                dor();
                res.Text += '-';
                return;
            }
            if (res.Text.Length == 0) return;
            
            if (res.Text[res.Text.Length - 1] == '.')
                return;
            ch = false;
            oper = true;
            res.Text += '-';
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 0) return;
            if (res.Text[res.Text.Length - 1] == '+' || res.Text[res.Text.Length - 1] == '-' || res.Text[res.Text.Length - 1] == 'x' || res.Text[res.Text.Length - 1] == '/')
            {
                res.Text = res.Text.Remove(res.Text.Length - 1);
                res.Text += '/';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                res.Text += '/';
                return;
            }
            if (res.Text.Length == 0) return;
            
            if (res.Text[res.Text.Length - 1] == '.')
                return;
            oper = true;
            ch = false;
            res.Text += '/';
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (res.Text.Length == 0) return;
            if (res.Text[res.Text.Length - 1] == '+' || res.Text[res.Text.Length - 1] == '-' || res.Text[res.Text.Length - 1] == 'x' || res.Text[res.Text.Length - 1] == '/')
            {
                res.Text = res.Text.Remove(res.Text.Length - 1);
                res.Text += 'x';
                return;

            }
            if (oper == true)
            {
                //oper = false;
                dor();
                res.Text += 'x';
                return;
            }
            if (res.Text.Length == 0) return;
            
            if (res.Text[res.Text.Length - 1] == '.')
                return;
            ch = false;
            oper = true;
            res.Text += 'x';
        }

        private void b2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
