   M S B A M L   `   `   `  ����B  >Kyrsova, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:KyrsovaKyrsova  5   	       Kyrsova.Firmbook   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Kyrsova     5   	     � Title$  Firmbook��5   	   $	��500��6   $	��750��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
FirmBookDG��5
      $
��Left=�6'   $	��257��6B   $��	10,10,0,0q�6O   $	��Top=�6b   $	��363��6z   $��17(�6�      
IsReadOnly . 6�   �� 5   
   $��Дата��6   $
��Left=�6   $��100,272,0,0q�6:   $	��Top=�6O   $��17(�6g   �� 5   
   $��З��6   $
��Left=�6   $��
20,305,0,0q�67   $	��Top=�6K   $��17(�6c   �� 5   
   $
��По��6   $
��Left=�6   $��
20,343,0,0q�68   $	��Top=�6L   $��17(�6d   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datefrom��5      $
��Left=�6'   $��32��6B   $��
52,309,0,0q�6N   $	��Top=�6b   $	��202��6z   $��17(�6�      FirstDayOfWeek$ Monday=�6�     5   
   -   5        $ dateto��5      $
��Left=�6%   $��32��6@   $��
52,343,0,0q�6L   $	��Top=�6`   $	��202��6x   $��17(�6�   $ Monday=�6�   6�   �� 5   
   $��
Місце��6   $
��Left=�6    $��
20,398,0,0q�6;   $	��Top=�6O   $��17(�6g   �� 5   
   -   5         ��Name$ placesCB��5      $
��Left=�6%   $��32��6@   $��
81,398,0,0q�6L   $	��Top=�6`   $	��173��6x   $��17(�6�   6�   �� 5   
   -   5         ��Name$ infoaboutauction��5      $2��,Інформація про аукціони��6+   $
��Left=�6M   $��57��6h   $��
422,31,0,0q�6t   $	��Top=�6�   $	��283��6�   $��17(�6�   6�   �� 5   
   -   5        $ incomeB��5      $��
Дохід��6"   $
��Left=�62   $��57��6M   $��422,130,0,0q�6Y   $	��Top=�6n   $	��283��6�   $��17(�6�   6�   �� 5   
   -   5        $ addauctionB��5      $!��Додати аукціон��6&   $
��Left=�6?   $��57��6Z   $��422,231,0,0q�6f   $	��Top=�6{   $	��283��6�   $��17(�6�   6�   �� 5   
   -   5        $ MainB��5      $��На головну��6    $
��Left=�65   $��57��6P   $��590,362,0,0q�6\   $	��Top=�6q   $	��115��6�   $��17(�6�   6�   5      5      