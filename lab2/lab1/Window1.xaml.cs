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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

      

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            Hide();
            w.Show();
        }
        int k = 0;

        

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
             int l = 0;
            if (p00.SelectedIndex == pp.SelectedIndex) l++;
            if (p01.SelectedIndex == pp.SelectedIndex) l++;
            if (p02.SelectedIndex == pp.SelectedIndex) l++;
            if (p10.SelectedIndex == pp.SelectedIndex) l++;
            if (p11.SelectedIndex == pp.SelectedIndex) l++;
            if (p12.SelectedIndex == pp.SelectedIndex) l++;
            if (p20.SelectedIndex == pp.SelectedIndex) l++;
            if (p21.SelectedIndex == pp.SelectedIndex) l++;
            if (p22.SelectedIndex == pp.SelectedIndex) l++;
            int hod=0,grav=1;
            if (l-k== 1)
            {
                int[,] a = new int[3, 3];
                a[0, 0] = p00.SelectedIndex;
                a[0, 1] = p01.SelectedIndex;
                a[0, 2] = p02.SelectedIndex;
                a[1, 0] = p10.SelectedIndex;
                a[1, 1] = p11.SelectedIndex;
                a[1, 2] = p12.SelectedIndex;
                a[2, 0] = p20.SelectedIndex;
                a[2, 1] = p21.SelectedIndex;
                a[2, 2] = p22.SelectedIndex;
                if (pp.SelectedIndex == 0)
                {
                    hod = 1;
                    grav = 0;
                }
                for (int i=0; i<3; i++)
                {
                    int kilhod = 0,kilgrav=0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (a[i, j] == hod)
                        {
                            kilhod++;
                        }
                        if (a[i, j] == grav)
                        {
                            kilgrav++;
                        }
                    }
                    if(kilgrav==2)
                    {
                        if(kilgrav+kilhod!=3)
                        {
                            if(a[i,0]==-1)
                            {
                                if(i==0)
                                {
                                    p00.SelectedItem = p00.Items[hod];
                                }
                                if (i == 1)
                                {
                                    p10.SelectedItem = p10.Items[hod];
                                }
                                if (i == 2)
                                {
                                    p20.SelectedItem = p20.Items[hod];
                                }
                            }
                            if (a[i, 1] == -1)
                            {
                                if (i == 0)
                                {
                                    p01.SelectedItem = p01.Items[hod];
                                }
                                if (i == 1)
                                {
                                    p11.SelectedItem = p11.Items[hod];
                                }
                                if (i == 2)
                                {
                                    p21.SelectedItem = p21.Items[hod];
                                }
                            }
                            if (a[i, 2] == -1)
                            {
                                if (i == 0)
                                {
                                    p02.SelectedItem = p02.Items[hod];
                                }
                                if (i == 1)
                                {
                                    p12.SelectedItem = p12.Items[hod];
                                }
                                if (i == 2)
                                {
                                    p22.SelectedItem = p22.Items[hod];
                                }
                            }

                        }
                    }
                }
                

                p22.SelectedValue = p22.Items[hod];
                k = l;
            }

            l1.Content = l;
            //p11.SelectedItem = pp.Items[0];
            //p22.SelectedItem = pp.Items[0];
        }

        private void b2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
