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
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            VerifField.Text = DATE.che;
        }
        //StreamWriter swr = new StreamWriter("ListOfTimes2.txt");
        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
            //swr.WriteLine(DATE.time.Count);
            //swr.Close();

            
        }
        List<string> temp = new List<string>();
        int k = 0;
        int hh = 0;
        int l = 1;
        Stopwatch sw = new Stopwatch();
        
        private void InputField_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (hh == 0)
            {
                DATE.time2.Add(new List<string>());
                hh++;
            }

            sw.Stop();
  
            DATE.time2[k].Add(Convert.ToString(sw.ElapsedMilliseconds));
            sw.Reset();
            sw.Start();
            if (InputField.Text[l - 1] != VerifField.Text[l - 1])
            {
                // k++;
                // DATE.time.Add(new List<string>());
                DATE.time[k].Clear();
                temp.Clear();
                InputField.Text = "";
                l = 0;
                SymbolCount.Content = 0;

            }
            
            l++;
            SymbolCount.Content = l - 1;
            if (VerifField.Text == InputField.Text)
            {
                l = 1;
                SymbolCount.Content = 0;

                //Calculate M
                //for (int i = 0; i < DATE.time.Count - 1; i++)
                //{
                DATE.M2.Add(new List<string>());
                for (int j = 1; j < DATE.time2[k].Count; j++)
                {
                    double sum = 0;
                    for (int kk = 1; kk < DATE.time2[k].Count; kk++)
                    {
                        if (kk != j) sum += Convert.ToDouble(DATE.time2[k][kk]);
                    }
                    double s = sum / DATE.time2[k].Count - 2;
                    DATE.M2[k].Add(Convert.ToString(s));
                }
                //}
                //Calculate S^2

                //for (int i = 0; i < DATE.M.Count; i++)
                //{

                DATE.S2.Add(new List<string>());
                for (int j = 0; j < DATE.M2[k].Count; j++)
                {
                    //MessageBox.Show(DATE.M[i].Count.ToString());
                    double sum = 0;
                    for (int kk = 1; kk < DATE.time2[k].Count; kk++)
                    {
                        if (kk != j + 1) sum += Math.Pow(Convert.ToDouble(DATE.time2[k][kk]) - Convert.ToDouble(DATE.M2[k][j]), 2);
                    }
                    double s = sum / DATE.M2[k].Count - 2;
                    DATE.S2[k].Add(Convert.ToString(s));
                }
               
                DATE.time2.Add(new List<string>());
                k++;
                count.Content = k;
                temp.Clear();
                InputField.Text = "";
             
            }
            if (k == (Convert.ToInt32(CountProtection.SelectedIndex) + 3))
            {
                StreamWriter swr = new StreamWriter("ListOfTimes2.txt");
                InputField.Text = "Done";
                int kl = 0;
                int vir = 0;
                for (int i = 0; i < DATE.M.Count; i++)
                {
                    for (int kk = 0; kk < DATE.M2.Count; kk++)
                    {
                        bool jj = true;
                        DATE.SS.Add(new List<string>());
                        DATE.tP2.Add(new List<string>());
                        for (int j = 0; j < DATE.M[i].Count; j++)
                        {


                            double ss = (Convert.ToDouble(DATE.S[i][j]) + Convert.ToDouble(DATE.S2[kk][j])) * (DATE.M[i].Count - 1);
                            double s = Math.Sqrt(ss / (2 * DATE.M[i].Count - 1));
                            DATE.SS[kl].Add(Convert.ToString(s));
                            double smax = Math.Max(Convert.ToDouble(DATE.S[i][j]), Convert.ToDouble(DATE.S2[kk][j]));
                            double smin = Math.Min(Convert.ToDouble(DATE.S[i][j]), Convert.ToDouble(DATE.S2[kk][j]));
                            double Fr = smax / smin;
                            if (Fr > DATE.Ft) DATE.odn = false;
                            double res1 = Math.Abs(Convert.ToDouble(DATE.M[i][j]) - Convert.ToDouble(DATE.M2[kk][j]));
                            double res2 = s * Math.Sqrt(1.0*2 / DATE.M[i].Count);
                            //MessageBox.Show(res1.ToString());
                           // MessageBox.Show(res2.ToString());
                            double res = res1 / res2;
                            DATE.tP2[kl].Add(Convert.ToString(res));
                            if (res > DATE.tT) jj = false;
                        }
                        kl++;
                        if (jj) vir++;
                    }

                     
                }
                
                if (legit.IsChecked.Value)
                {
                    DATE.kolneg += DATE.M.Count * DATE.M2.Count - vir;
                    DATE.kolsppos += DATE.M.Count * DATE.M2.Count;
                }
                else
                {
                    DATE.kolpos += vir;
                    DATE.kolspneg += DATE.M.Count * DATE.M2.Count;
                }
                if (DATE.kolsppos != 0)
                    P1Field.Content = 1.0 * DATE.kolneg / DATE.kolsppos;
                else P1Field.Content = 0;
                if (DATE.kolspneg != 0)
                    P2Field.Content = 1.0 * DATE.kolpos / DATE.kolspneg;
                else P2Field.Content = 0;


                // MessageBox.Show(vir.ToString());
                StatisticsBlock.Content = (1.0 * vir) / (DATE.M.Count * DATE.M2.Count);
                if (DATE.odn == true) DispField.Content = "однорiднi";
                else DispField.Content = "не однорiднi";

                // MessageBox.Show(DATE.M[2].Count.ToString());
                // MessageBox.Show(DATE.time[3].Count.ToString());


                foreach (var item in DATE.time2)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.time2.Count);
                swr.WriteLine();
                foreach (var item in DATE.M2)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.M2.Count);
                swr.WriteLine();
                foreach (var item in DATE.S2)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.S2.Count);
                swr.WriteLine();
                foreach (var item in DATE.SS)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.SS.Count);
                swr.WriteLine();
                foreach (var item in DATE.tP2)
                {
                    foreach (var item2 in item)
                    {
                        swr.Write(item2 + " ");
                    }
                    swr.WriteLine();
                }
                swr.Write(DATE.tP2.Count);
                swr.Close();
                DATE.time2.Clear();
                DATE.M2.Clear();
                DATE.S2.Clear();
                DATE.tP2.Clear();
                DATE.odn = true;
                k = 0;
                l = 1;
                hh = 0;
                count.Content = 0;
                //System.Threading.Thread.Sleep(10000000);
                InputField.Text = "";

            }
            //test.Text = Convert.ToString(t.Millisecond);


        }
    }
}
