using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Math;
using System.IO;

namespace Lab_2_First_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List <Ellipse>();
        static PointCollection pC = new PointCollection();
        List<List<int>> pop = new List<List<int>>();
        List<double> dist = new List<double>();
        static int nch = 30;


        public MainWindow()
        {
           // MyCanvas.Children.Clear();
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);            
        }

        private void InitPoints()
        {
            pop.Clear();
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();
            //Random rnd = new Random();
            //
            for(int i =0; i<nch; i++)
            {
                //int[] way = new int[PointCount];
                List<int> way = new List<int>();

                for (int ii = 0; ii < PointCount; ii++)
                    way.Add(ii);

                for (int s = 0; s < 2 * PointCount; s++)
                {
                    int i1, i2, tmp;

                    i1 = rnd.Next(PointCount);
                    i2 = rnd.Next(PointCount);
                    tmp = way[i1];
                    way[i1] = way[i2];
                    way[i2] = tmp;
                }
                pop.Add(way);
               // MessageBox.Show((pop[i].Count).ToString());

            }
            for (int i = 0; i < nch; i++)
                pop.Add(new List<int>());
            
            //
            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75*MainWin.Width)-3*Radius);
                p.Y = rnd.Next(Radius, (int)(0.90*MainWin.Height-3*Radius));                
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            { 
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el); 
            }            
        }

        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;            
            myPolygon.StrokeThickness = 2;            
        }

        private void PlotPoints()
        {            
            for (int i=0; i<PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius/2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius/2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }


        private void PlotWay(int [] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
                        
            dT.Interval = new TimeSpan(0,0,0,0,Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
                
            }
            else
            {                
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
        }

        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
           
            PlotPoints();
            PlotWay(GetBestWay());
        }
      
        private int[] GetBestWay()
        {
            Random rnd = new Random();
            int[] way = new int[PointCount];
         
            pop = mutat(pop);
            dist.Clear();
            
            for(int i=0; i<nch*2; i++)
            {
                int kk = 0;
                dist.Add(kk);
                for(int j =0; j<pop[i].Count-1; j++)
                {
                    dist[i] += Sqrt(Pow(pC[pop[i][j]].X * 1.0 - pC[pop[i][j+1]].X * 1.0, 2) + Pow(pC[pop[i][j]].Y * 1.0 - pC[pop[i][j + 1]].Y * 1.0, 2));
                    //sw.Write(pop[i][j] + " ");
                }
            


                dist[i] += Sqrt(Pow(pC[pop[i][PointCount-1]].X*1.0 - pC[pop[i][0]].X * 1.0, 2) + Pow(pC[pop[i][PointCount - 1]].Y * 1.0 - pC[pop[i][0]].Y * 1.0, 2));
            }
        
            for (int i = 0; i < dist.Count; i++)
            {
                for (int j = 0; j < dist.Count - 1; j++)
                {
                    if (dist[j] > dist[j + 1])
                    {
                        double temp = dist[j + 1];
                        dist[j + 1] = dist[j];
                        dist[j] = temp;

                        List<int> temp2 = pop[j + 1];
                        pop[j + 1] = pop[j];
                        pop[j] = temp2;

                    }
                }
               
            }
          
           
            for (int i =0; i<PointCount; i++)
            {
                way[i] = pop[0][i];
            }
            distance.Content = dist[0].ToString();
            return way;
        }
        private List<List<int>> mutat(List<List<int>> ar)
        {
           
                    
            Random rnd = new Random();
            for (int i =nch; i<nch*2; i++)
            {

                int i1 = rnd.Next(nch-1), i2 = rnd.Next(nch-1), r = rnd.Next(PointCount-1);
               
                HashSet<int> child = new HashSet<int>();
               
                if (rnd.NextDouble()>0.5)
                {
                    
                    for(int j = 0; j<r; j++)
                    {
                       
                        child.Add(ar[i1][j]);
                    }
                    for (int j = r; j < PointCount; j++)
                    {
                       
                        child.Add(ar[i2][j]);
                    }
                    for (int j = 0; j < r; j++)
                    {
                        child.Add(ar[i2][j]);
                    }
                    for (int j = r; j < PointCount; j++)
                    {
                        child.Add(ar[i1][j]);
                    }
                }
                else
                {
                    for (int j = 0; j < r; j++)
                    {
                       
                        child.Add(ar[i2][j]);
                    }
                    for (int j = r; j < PointCount; j++)
                    {
                        
                        child.Add(ar[i1][j]);
                    }
                    for (int j = 0; j < r; j++)
                    {
                        child.Add(ar[i1][j]);
                    }
                    for (int j = r; j < PointCount; j++)
                    {
                        child.Add(ar[i2][j]);
                    }

                }
               
                List<int> child2 = new List<int>();
                
                foreach(int a in child)
                {
                    child2.Add(a);
                   
                }
               
                if (rnd.NextDouble()<=0.7)
                {
                    int j1 = rnd.Next(PointCount - 1), j2 = rnd.Next(PointCount - 1);
                    if (j2 > j1)
                    {
                        int g = 0;
                        int[] aa = new int[j2 - j1 + 1];
                        for (int k = j1; k <= j2; k++)
                        {
                            aa[g] = child2[k];
                            
                            g++;

                        }
                        g--;
                        for(int k = j1; k<=j2; k++)
                        {
                            child2[k] = aa[g];
                            g--;

                        }
                    }
                    else
                    {
                        int g = 0;
                        int[] aa = new int[j1 - j2 + 1];
                        for (int k = j2; k <= j1; k++)
                        {
                            aa[g] = child2[k];
                           
                            g++;

                        }
                        g--;
                        for (int k = j2; k <= j1; k++)
                        {
                            child2[k] = aa[g];
                            g--;

                        }
                    }
                }
               
                bool ff = true;
                foreach(var a in ar)
                {
                    bool ff2 = true;
                    int jj = 0;
                    foreach(int a2 in a)
                    {
                        if (a2 != child2[jj]) ff2 = false;
                        jj++;
                    }
                    if(ff2)
                    {
                        ff = false;
                        break;
                    }
                }
                  
               if(ff || ar[i].Count==0)
                ar[i] = child2;

            }
           

            return ar;
        }

       
    }
}