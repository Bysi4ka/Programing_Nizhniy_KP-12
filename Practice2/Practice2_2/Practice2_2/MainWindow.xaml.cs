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
    public partial class Window1 : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection pC = new PointCollection();
        List<List<int>> pop = new List<List<int>>();
        List<double> dist = new List<double>();
        static int nch = 30;


        public Window1()
        {
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
           
            for (int i = 0; i < nch; i++)
            {
                
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
              

            }
            for (int i = 0; i < nch; i++)
                pop.Add(new List<int>());

            //
            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75 * this.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * this.Height - 3 * Radius));
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
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }


        private void PlotWay(int[] BestWayIndex)
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

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
                //sw.Close();
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
            //InitPoints();
            PlotPoints();
            PlotWay(GetBestWay());
        }
        // StreamWriter sw = new StreamWriter("outout.txt");
        private int[] GetBestWay()
        {
            Random rnd = new Random();
            int[] way = new int[PointCount];

            way[0] = 0;
            double[,] a = new double[PointCount, PointCount];
           
            for (int i = 0; i < PointCount; i++)
            {
                for (int j = 0; j < PointCount; j++)
                {


                    a[i, j] = Sqrt(Pow(pC[i].X * 1.0 - pC[j].X * 1.0, 2) + Pow(pC[i].Y * 1.0 - pC[j].Y * 1.0, 2));
                    

                }
              

            }
           
            int[] v = new int[PointCount];
            for (int i = 1; i < PointCount; i++)
            {
                v[i] = 0;
            }
            v[0] = 1;
            int jj = 0;
            for (int i = 1; i < PointCount; i++)
            {
                int cur = 0;
                double min = double.MaxValue;
                for (int k = 1; k < PointCount; k++)
                {
                    if (a[jj, k] < min && v[k] != 1)
                    {
                        min = a[jj, k];
                        cur = k;

                    }
                }
                jj = cur;
                v[jj] = 1;
               
                way[i] = jj;

            }
            return way;
        }

        
    }
}