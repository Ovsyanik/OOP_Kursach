   M S B A M L   `   `   `  ����   	Kursovaya    Kursovaya.Pages.AddFlat   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       N� Title$  AddFlat��.���  � RowDefinitions �� $��* ��� $��70 �.+��� ._��� $
��Auto=�.���� $��Center=�.+��� .+��� $��
Адрес��$
��Bold"�$��16(�$��Center=�$��0,20,0,5q�]�    DockPanelAdd#��[  .+��� $��Город:��$	��200��$��Center=���   
TextBoxAdd#��[ ���� *NewFlat.Address.Sity+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . ]� #���   .+��� $��Район:��$	��200��$��Center=��� #��[ ���� *NewFlat.Address.District+$ PropertyChanged=�$ TwoWay=� . ]� #���   .+��� $��Улица:��$	��200��$��Center=��� #��[ ���� *NewFlat.Address.Street+$ PropertyChanged=�$ TwoWay=� . ]� #���   .+��� $��Номер дома:��$	��200��$��Center=��� #��[ ���� *NewFlat.Address.NumberHouse+$ PropertyChanged=�$ TwoWay=� . ]� #���   .+��� $��	Этаж:��$	��200��$��Center=��� #��[ ���� *NewFlat.Address.Floor+$ PropertyChanged=�$ TwoWay=� . ]� #���   .+��� $$��Ближайшее метро:��$	��200��$��Center=��� #���  ���� *NewFlat.Address.Metro+$ PropertyChanged=�$ TwoWay=� . �� $��Center=�.+��� $��Описание��$
��Bold"�$��16(�$��Center=�$��	0,20,0,15q�]� #���   .+��� $-��'Загрузите фотографии��$	��200����   ButtonImage#���  $G��AЗагрузить изображения (формат JPG, PNG)�� � Cursor$
 Hand������ *
AddImage+����  �� ElementName$ 
ImagePanel��]� -    ]�Name$ 
ImagePanel��$��Center=�$
��30,5q�]� #���   .+��� $��Площадь��$	��200���� #��[ ���� *NewFlat.Area+$ PropertyChanged=�$ TwoWay=� . ]� #���   .+��� $'��!Количество комнат��$	��200���� $	��300��$��25�� �� Text �� *NewFlat.CountRooms+$ PropertyChanged=�$ TwoWay=� . .@��� .��1�� .��2�� .��3�� .��4�� .��5]� #���   .+��� $��Ремонт��$	��200���� $	��300��$��25�� �� *NewFlat.Repair+$ PropertyChanged=�$ TwoWay=� . .@��� .��Косметический�� .��Капитальный�� .��Евроремонт�� .��Дизайнерский]� #���   $	��Top=�.+��� $��Цена��$	��200���� #��[ ���� *NewFlat.Price+$ PropertyChanged=�$ TwoWay=� . �� $��Center=�.+��� $)��#Что есть в квартире��$
��Bold"�$��16(�$��center=�$��
0,20,0,-20q�	 K� ZIndex$	 1��]� .+��� $
��55,0q�.+��� $��..\Source\WaterHeater.png��$	��150���� $$��Водонагреватель��$��10,0,0,0q�
 d� 	IsChecked
 �� *NewFlat.Demands.WaterHeater+$ PropertyChanged=�$ TwoWay=��� $
��55,0q�.+��� $��..\Source\Washer.png��$	��150���� $'��!Стиральная машина��
 �� *NewFlat.Demands.Washer+$ PropertyChanged=�$ TwoWay=��� $
��55,0q�.+��� $��..\Source\Microwave.png��$	��150���� $'��!Микроволнова печь��$��5,0,0,0q�
 �� *NewFlat.Demands.Microwave+$ PropertyChanged=�$ TwoWay=�]� .+��� $
��55,0q�.+��� $ ��..\Source\Refregicator.png��$	��150���� $��Холодильник��$��20,0,0,0q�
 �� *NewFlat.Demands.Regregicator+$ PropertyChanged=�$ TwoWay=��� $
��55,0q�.+��� $��..\Source\Internet.png��$	��150���� $��Интернет��$��30,0,0,0q�
 �� *NewFlat.Demands.Internet+$ PropertyChanged=�$ TwoWay=��� $
��55,0q�.+��� $��..\Source\TV.png��$	��150���� $��Телевизор��$��30,0,0,0q�
 �� *NewFlat.Demands.TV+$ PropertyChanged=�$ TwoWay=��� $��Center=�.+��� $ ��Дополнительно��$
��Bold"�$��16(�$��Center=�$��	0,20,0,15q��� $
��Auto=�$	��700��$	��200��$��14(����� *NewFlat.Description+$ PropertyChanged=�$ TwoWay=� .  ]� $��1��$��Bottom=�$��Center=�$��Right=�$
��30,0q�.+���   ButtonSendFlat#���  $	��150��$��40��$��Отправить��$
 Hand������ *
SendFlat+