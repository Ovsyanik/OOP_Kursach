   M S B A M L   `   `   `  ����  	Kursovaya    Kursovaya.Pages.PageAdmin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  	PageAdmin��5      .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $��70 �6   6+   .+�5   
   ]� $��0��6   $��10q�6"   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DBGrid��5         AutoGenerateColumns .  $��Center=�5         CanUserAddRows .  ��5      �� *Flats+ �� SelectedItem 5      �� *SelectedFlat+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      CellCenterStyle   	CellStyle# [  5   E   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6)   �� 
 �� Path$
 ID�5        5      $ 
Город��6)   # [  5   )   	 5   )   �� $
 Address.Sity�5   )     5      $ 
Район��6)   # [  5    )   	 5   )   �� $
 Address.District�5    )     5!      $ 
Улица��6)   # [  5#   )   	 5"   )   �� $
 Address.Street�5#   )     5$      $ Номер дома��6)   # [  5&   )   	 5%   )   �� $
 Address.NumberHouse�5&   )     5'      $ Этаж��6)   # [  5)   )   	 5(   )   �� $
 Address.Floor�5)   )     5*      $ 
Метро��6)   # [  5,   )   	 5+   )   �� $
 Address.Metro�5,   )   4  .System.Windows.Controls.DataGridTemplateColumn  5-      $ Image��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6<      
IsReadOnly .    CellTemplate 5.      �� 5/      .R�50   "   �� $	��150��6B   ��6(   �� *Image+6B   51      53        54      $ Площадь(кв.м)��6)   # [  56   )   	 55   )   �� $

 Area�56   )     57      $ Кол-во комнат��6)   # [  59   )   	 58   )   �� $
 
CountRooms�59   )     5;      $ Ремонт��6)   # [  5=   )   	 5<   )   �� $
 Repair�5=   )     5>      $ Цена ($\мес.)��6)   # [  5@   )   	 5?   )   �� $
 Price�5@   )   4  .System.Windows.Controls.DataGridCheckBoxColumn  5A      $$ Водонагреватель��6-   # [  5C   -   	 5B   -   �� $
 Demands.WaterHeater�5C   -     5D      $' !Стиральная машина��6-   # [  5F   -   	 5E   -   �� $
 Demands.Washer�5F   -     5G      $  Микроволновка��6-   # [  5I   -   	 5H   -   �� $
 Demands.Microwave�5I   -     5J      $ Холодильник��6-   # [  5L   -   	 5K   -   �� $
 Demands.Refrigicator�5L   -     5M      $ Интернет��6-   # [  5O   -   	 5N   -   �� $
 Demands.Internet�5O   -     5P      $ Телевизор��6-   # [  5R   -   	 5Q   -   �� $
 
Demands.TV�5R   -     5S      $ 
Вывод��6-   # [  5U   -   	 5T   -   �� $
 Output�5U   -   5W      5X      ]� 5Y   
   $��1��6   $��Center=�6!   .+�5Z      �� $��Удалить��6     ButtonSendFlat#���  5]       � Cursor$
 Hand��5^      ��5[      �� *
RemoveFlat+��5\      �� *SelectedFlat+5^      �� 5_      $��Сохранить��6   #���  5b      $
 Hand��5c      ��5`      �� *SaveChangedFlats+��5a      �� *SelectedFlat+5c      �� 5d      $%��Новые объявления��6   #���  5f      $
 Hand��5g      ��5e      �� *
GetNewFlat+5g      5h      5i      5j      