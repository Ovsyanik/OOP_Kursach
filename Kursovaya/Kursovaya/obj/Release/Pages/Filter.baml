   M S B A M L   `   `   `  ����   	Kursovaya    Kursovaya.Pages.Filter   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     N�Name$  
FilterPage�� N� Title$ Filter��.���  � RowDefinitions �� $��* ��� $��70��.+��� $��0��$
��Auto=�.���� $��Center=�$��Center=����#f4f4f4.+�]�    	RowFilter#��[  .+�]�   ChildInRowFilter#���  .+��� $��Город: ��$��90��$��15(�$��Center=��� -    ��Name$ SityBox��  TextBoxFilter#��[ ���� *FlatFilter.Address.Sity+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . ]� #���  $��Right=�.+��� $��Район: ��$��90��$��15(�$��Center=��� -   $ DistrictBox��#��[ ���� *FlatFilter.Address.District+$ PropertyChanged=�$ TwoWay=� . ]� #��[  $	��950��.+�]� #���  $
��Left=�$	��460��.+��� $)��#Количество комнат: ��$��15(�$	��180��$��23,0,0,0q�$��Center=��� -    ��Name$ CountRoomsBox��  ComboBoxFilter#��[ $��7q� �� Text �� *FlatFilter.CountRooms+$ PropertyChanged=�$ TwoWay=� . .@��� .��1�� .��2�� .��3�� .��4�� .��5]� #��[  .+�]� #���  .+��� $��
Этаж: ��$��90��$��15(�$��Center=��� $��от:��$��15(�$��0,0,10,0q�$��Center=��� -   $ FloorMin��#��[ $	��100������ *FlatFilter.Address.FloorMin+$ PropertyChanged=�$ TwoWay=� . �� $��до:��$��Center=�$��15(�$��
30,0,-15,0q��� -   $ FloorMax��#��[ $	��100������ *FlatFilter.Address.FloorMax+$ PropertyChanged=�$ TwoWay=� . ]� #���  .+��� $��Метро: ��$��15(�$��90��$��Center=��� -   $ MetroBox��#��[ ���� *FlatFilter.Address.Metro+$ PropertyChanged=�$ TwoWay=� . ]� #��[  .+�]� #���  .+��� $��Площадь: ��$��90��$��15(�$��Center=��� $��от:��$��15(�$��0,0,10,0q�$��Center=��� -   $ AreaMin��#��[ $	��100������ *FlatFilter.AreaMin+$ PropertyChanged=�$ TwoWay=� . �� $��до:��$��Center=�$��15(�$��
30,0,-15,0q��� -	   $ AreaMax��#��[ $	��100������ *FlatFilter.AreaMax+$ PropertyChanged=�$ TwoWay=� . ]� #���  $��Center=�.+��� $��Улица: ��$��90��$��15(�$��Center=��� -
   $ 	StreetBox��#��[ ���� *FlatFilter.Address.Street+$ PropertyChanged=�$ TwoWay=� . ]� #��[  .+�]� #���  .+��� $��Ремонт: ��$��90��$��15(�$��Center=��� -   $ 	RepairBox��#��[ $��20(�$��7q� �� *FlatFilter.Repair+$ PropertyChanged=�$ TwoWay=� . .@��� .��Косметический�� .��Капитальный�� .��Евроремонт�� .��Дизайнерский]� #���  $	��Top=�.+��� $��
Цена: ��$��90��$��15(�$��Center=��� $��от:��$��15(�$��0,0,10,0q�$��Center=��� -   $ PriceMin��#��[ $	��100������ *FlatFilter.PriceMin+$ PropertyChanged=�$ TwoWay=� . �� $��до:��$��Center=�$��15(�$��
30,0,-15,0q��� -   $ PriceMax��#��[ $	��100������ *FlatFilter.PriceMax+$ PropertyChanged=�$ TwoWay=� . ]� #��[  $��Center=�.+��� -   	 ��Name$	 CheckBoxFilter��$6��0Наличие бытовых предметов��$��Center=�]�   
CheckPanel#��[ .+��� -   $	 WaterHeaterCheck��$$��Водонагреватель��$��15(�$
��10,0q�
 d� 	IsChecked
 �� * FlatFilter.Demands.WaterHeater+$ PropertyChanged=�$ TwoWay=��� -   $	 WasherCheck��$'��!Стиральная машина��$��15(�$
��10,0q�
 �� *FlatFilter.Demands.Washer+$ PropertyChanged=�$ TwoWay=��� -   $	 MicrowaveCheck��$'��!Микроволнова печь��$��15(�$
��10,0q�
 �� *FlatFilter.Demands.Microwave+$ PropertyChanged=�$ TwoWay=��� -   $	 RefregicatorCheck��$��Холодильник��$��15(�$
��10,0q�
 �� *!FlatFilter.Demands.Regregicator+$ PropertyChanged=�$ TwoWay=��� -   $	 InternetCheck��$��Интернет��$��15(�$
��10,0q�
 �� *NewFlat.Demands.Internet+$ PropertyChanged=�$ TwoWay=��� -   $	 TVCheck��$��Телевизор��$��15(�$
��10,0q�
 �� *FlatFilter.Demands.TV+$ PropertyChanged=�$ TwoWay=��� $��1��._�]� $��Center=�$��1��.+��� $��Сбросить��  ButtonSendFlat#���   � Cursor$
 Hand������ *ResetFilter+����  �� ElementName$ 
FilterPage���� $ ��Отфильтровать��#���  $
 Hand������ *ApplyFilter+���� $ 
FilterPage��