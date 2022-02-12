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
using System.Diagnostics;
using System.IO;
namespace Practice1
{
    static class DATE
    {
        static public List<List<string>> time = new List<List<string>>(); 
        static public List<List<string>> M = new List<List<string>>();
        static public List<List<string>> S = new List<List<string>>();
        static public List<List<string>> tP = new List<List<string>>();
        static public List<List<string>> time2 = new List<List<string>>();
        static public List<List<string>> M2 = new List<List<string>>();
        static public List<List<string>> S2 = new List<List<string>>();
        static public List<List<string>> tP2 = new List<List<string>>();
        static public List<List<string>> SS = new List<List<string>>();
        static public double tT = 2.3060;
        static public double tT2 = 3.35;
        static public double Ft = 2.31;
        static public double Ft2 = 3.36;
        static public bool odn = true;
        static public int kolsppos = 0;
        static public int kolspneg = 0;
        static public int kolpos = 0;
        static public int kolneg = 0;
        static public string che="длагнитор";



    }
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       

        public Window1()
        {
            InitializeComponent();
            DATE.time.Clear();
            DATE.M.Clear();
            DATE.S.Clear();
            DATE.tP.Clear();
            DATE.SS.Clear();
        }

       

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
            swr.Close();
        }
        //DATE date = new DATE();
        
        List<string> temp = new List<string>();
        int k = 0;
        int hh = 0;
        int l = 1;
        Stopwatch sw = new Stopwatch();
        StreamWriter swr = new StreamWriter("ListOfTimes.txt");
        private void InputField_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (InputField.Text.Length == 0) return;
            DATE.che = check.Text;
            if(DATE.che.Length!=9)
            {
                MessageBox.Show("В кодовому словы повинно бути 9 букв");
                InputField.Text = "";
                return;
            }
            if (hh == 0)
            {
                DATE.time.Add(new List<string>());
                hh++;
            } 
            
            sw.Stop();
            //temp.Add(Convert.ToString(sw.ElapsedMilliseconds));
            DATE.time[k].Add(Convert.ToString(sw.ElapsedMilliseconds));
            sw.Reset();
            sw.Start();
            if (InputField.Text[l - 1] != DATE.che[l - 1])
            {
                // k++;
                // DATE.time.Add(new List<string>());
                DATE.time[k].Clear();
                temp.Clear();
                InputField.Text = "";
                l = 0;
                SymbolCount.Content = 0;

            }


            /*if(time.Count==1)
            {
                
                time.Add(t);
                test.Text = Convert.ToString(time[1]-time[0]);
                
                TimeSpan r = time[1] - time[0];
                test.Text += '\n';
                test.Text += Convert.ToString(r.Milliseconds);

            }
            else
            {
                time.Add(t);
            }*/
            // time.Add(t);

            l++;
            SymbolCount.Content = l-1;
            if (DATE.che == InputField.Text)
            {
                l = 1;
                SymbolCount.Content = 0;
               
                //Calculate M
                //for (int i = 0; i < DATE.time.Count - 1; i++)
                //{
                    DATE.M.Add(new List<string>());
                    for (int j = 1; j < DATE.time[k].Count; j++)
                    {
                        double sum = 0;
                        for (int kk = 1; kk < DATE.time[k].Count; kk++)
                        {
                            if (kk != j) sum += Convert.ToDouble(DATE.time[k][kk]);
                        }
                        double s = sum / DATE.time[k].Count - 2;
                        DATE.M[k].Add(Convert.ToString(s));
                    }
                //}
                //Calculate S^2

                //for (int i = 0; i < DATE.M.Count; i++)
                //{

                    DATE.S.Add(new List<string>());
                    for (int j = 0; j < DATE.M[k].Count; j++)
                    {
                        //MessageBox.Show(DATE.M[i].Count.ToString());
                        double sum = 0;
                        for (int kk = 1; kk < DATE.time[k].Count; kk++)
                        {
                            if (kk != j + 1) sum += Math.Pow(Convert.ToDouble(DATE.time[k][kk]) - Convert.ToDouble(DATE.M[k][j]), 2);
                        }
                        double s = sum / DATE.M[k].Count - 2;
                        DATE.S[k].Add(Convert.ToString(s));
                    }
               // }
                //Calculate tP
           
               // for (int i = 0; i < DATE.M.Count; i++)
                //{
                    DATE.tP.Add(new List<string>());
                    for (int j = 0; j < DATE.M[k].Count; j++)
                    {

                        double s = Math.Abs((Convert.ToDouble(DATE.time[k][j + 1]) - Convert.ToDouble(DATE.M[k][j])) / Math.Sqrt(Convert.ToDouble(DATE.S[k][j])));
                    if(s>DATE.tT2)
                    {
                        DATE.tP.RemoveAt(DATE.tP.Count - 1);
                        DATE.time[k].Clear();
                        DATE.S.RemoveAt(DATE.S.Count - 1);
                        DATE.M.RemoveAt(DATE.M.Count - 1);
                        InputField.Text = "";
                        l = 1;
                        SymbolCount.Content = 0;
                        //MessageBox.Show(DATE.M.Count.ToString());
                        return;
                       // k--;

                    }
                        DATE.tP[k].Add(Convert.ToString(s));
                    }
                // }
                DATE.time.Add(new List<string>());
                k++;
                count.Content = k;
                temp.Clear();
                InputField.Text = "";
               /* for(int i=0; i<time.Count; i++)
                {
                    swr.Write(time[i] + " ");
                }
                swr.WriteLine();
                time.Clear();*/
            }
            if (k == (Convert.ToInt32(CountProtection.SelectedIndex) + 3))
            {
                InputField.Text = "Done";
                


                // MessageBox.Show(DATE.M[2].Count.ToString());
                // MessageBox.Show(DATE.time[3].Count.ToString());


                foreach (var item in DATE.time)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.time.Count);
                swr.WriteLine();
                foreach (var item in DATE.M)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.M.Count);
                swr.WriteLine();
                foreach (var item in DATE.S)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.S.Count);
                swr.WriteLine();
                foreach (var item in DATE.tP)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.tP.Count);
                swr.Close();
                



            }
            //test.Text = Convert.ToString(t.Millisecond);


        }
    }
}
