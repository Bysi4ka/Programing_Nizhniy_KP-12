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
            StreamReader sr = new StreamReader("D:/KPI/Прога2/lab1/basa.txt");
            while (!sr.EndOfStream)
            {
                s.Add(sr.ReadLine());

            }
        }
        List<string> s = new List<string>();

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter sw = new StreamWriter("D:/KPI/Прога2/lab1/basa.txt");
            string ss = t1.Text + " " + t2.Text + " " + t3.Text;
            s.Add(ss);
            for(int i=0;i<s.Count-1;i++)
            {
                sw.WriteLine(s[i]);
            }
            sw.Write(s[s.Count-1]);

            sw.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("D:/KPI/Прога2/lab1/basa.txt");
            for (int i=0; i<s.Count; i++)
            {
                string[] ss = s[i].Split(' ');
                if (t4.Text == ss[0])
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
    }
}
