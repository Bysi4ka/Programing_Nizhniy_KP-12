   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	       lab4.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab4     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1200��6)    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$ SingleBorderWindow=�6[    � Cursor$ AppStarting��6|   .��5	      � ��5
   
   �� 5       �� ImageSource$ 
/money.jpg��6    � ColumnDefinitions 5   
   �� 5      $	��15* �6   �� 5      $
��332* �6   �� 5      $	��53* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��firmbook��5      $
��Left=�6$   $	��448��6?   $	��Top=�6L   $	��314��6d   $��2��6p     5   
   -   5        $��forsale��5      $
��Left=�6#   $	��448��6>   $	��Top=�6K   $	��314��6c   $��1��6o   $��	401,0,0,0q�6     5   
   -   5        $
��sold��5      $
��Left=�6    $	��448��6;   $	��Top=�6H   $	��314��6`   $��1��6l   $��	839,0,0,0q�6|   $��2��6�     5   
   -   5        $��seller��5      $
��Left=�6"   $	��302��6=   $	��Top=�6J   $	��544��6b   $��	8,480,0,0q�6n   $��2��6�     5   
   -   5        $
��byer��5      $
��Left=�6    $	��302��6;   $	��Top=�6H   $	��544��6`   $��602,482,0,0q�6l   $��2��6�   $��1��6�   5      5      