   M S B A M L   `   `   `  ����   	Kursovaya    Kursovaya.Pages.PageAdmin   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  	PageAdmin��.���  � RowDefinitions �� $��* ��� $��70 �.+�]� $��0��$��10q�.+�&   System.Windows.Controls.DataGrid  -     Name$ DBGrid��   AutoGenerateColumns .  $��Center=����� *Flats+ �� SelectedItem �� *SelectedFlat+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ ID�  $ 
Город��	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80  �� $ Address.Sity�  $ 
Район��$	 80  �� $ Address.District�  $ 
Улица��$	 80  �� $ Address.Street�  $ Номер дома�� �� $ Address.NumberHouse�  $ Этаж�� �� $ Address.Floor�  $ 
Метро��$	 80  �� $ Address.Metro�4  .System.Windows.Controls.DataGridTemplateColumn  $ Image��$	 SizeToCells 
   
IsReadOnly
 .    CellTemplate �� .R��� $	��150������ *Image+  $ Площадь�� �� $
 Area�  $ Кол-во комнат�� �� $ 
CountRooms�  $ Ремонт�� �� $ Repair�  $ Цена ($)�� �� $ Price�4  .System.Windows.Controls.DataGridCheckBoxColumn  $$ Водонагреватель��$	 50  �� $ Demands.WaterHeater�  $' !Стиральная машина�� �� $ Demands.Washer�  $  Микроволновка�� �� $ Demands.Microwave�  $ Холодильник�� �� $ Demands.Regregicator�  $ Интернет�� �� $ Demands.Internet�  $ Телевизор�� �� $ 
Demands.TV�  $ 
Вывод�� �� $ Output�]� $��1��$��Center=�.+��� $��Удалить��   ButtonSendFlat#���    � Cursor$
 Hand������ *
RemoveFlat+���� *SelectedFlat+�� $��Сохранить��#���   $
 Hand������ *SaveChangedFlats+���� *SelectedFlat+�� $%��Новые объявления��#���   $
 Hand������ *
GetNewFlat+