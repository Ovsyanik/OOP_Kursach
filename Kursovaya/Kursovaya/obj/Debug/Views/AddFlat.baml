   M S B A M L   `   `   `  ����  	Kursovaya    Kursovaya.Pages.AddFlat   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          N�Name$
  Page��5       N� Title$ AddFlat��5   	   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $��70 �6   6*   .+�5   
   �� ._�5      �� $
��Auto=�6   .��5      �� $��Center=�6   .+�5      �� .+�5      �� $��
Адрес��6$   $
��Bold"�61   $��16(�6C   $��Center=�6Q   $��0,20,0,5q�6n   ]� 5         DockPanelAdd#��[  6$   .+�5      �� $��Город:��6$   $	��200��65   $��Center=�6A   �� 5        
TextBoxAdd#��[ 6&   ��5   &   �� *NewFlat.Address.Sity+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5      ]� 5      #���   6$   .+�5      �� $��Район:��6$   $	��200��65   $��Center=�6A   �� 5      #��[ 6&   ��5      �� *NewFlat.Address.District+$ PropertyChanged=�$ TwoWay=� . 5      ]� 5      #���   6$   .+�5      �� $��Улица:��6$   $	��200��65   $��Center=�6A   �� 5      #��[ 6&   ��5       �� *NewFlat.Address.Street+$ PropertyChanged=�$ TwoWay=� . 5!      ]� 5"      #���   6$   .+�5#      �� $��Номер дома:��6$   $	��200��6:   $��Center=�6F   �� 5$      #��[ 6&   ��5%      �� *NewFlat.Address.NumberHouse+$ PropertyChanged=�$ TwoWay=� . 5&      ]� 5'      #���   6$   .+�5(      �� $��	Этаж:��6$   $	��200��64   $��Center=�6@   �� 5)      #��[ 6&   ��5*      �� *NewFlat.Address.Floor+$ PropertyChanged=�$ TwoWay=� . 5+      ]� 5,      #���   6$   .+�5-      �� $$��Ближайшее метро:��6$   $	��200��6?   $��Center=�6K   �� 5.      #���  6&   ��5/      �� *NewFlat.Address.Metro+$ PropertyChanged=�$ TwoWay=� . 50      51      �� 52      $��Center=�6!   .+�53      �� $��Описание��6$   $
��Bold"�64   $��16(�6F   $��Center=�6T   $��	0,20,0,15q�6q   ]� 54      #���   6$   .+�55      �� $-��'Загрузите фотографии��6$   $	��200��6C   �� 56        ButtonImage#���  6%   $G��AЗагрузить изображения (формат JPG, PNG)��57   %    � Cursor$
 Hand��5:   %   ��58   %   �� *
AddImage+��59   %   ��  �� ElementName$ 
ImagePanel��5:   %   5;      ]� 5<      -   5         ]�Name$ 
ImagePanel��5<   $   $��Center=�68   $
��30,5q�6U   ]� 5>      #���   6$   .+�5?      �� $��Площадь��6$   $	��200��66   �� 5@      #��[ 6&   $	��250��5A   &   $��
100,0,10,0q�5B   &   $
��Left=�5D   &   ��5C   &   �� *NewFlat.Area+$ PropertyChanged=�$ TwoWay=� . 5D   &   �� 5E      $��кв. м��6(   $��0,-5,0,0q�65   $��16(�6G   $��Right=�6U   $��Center=�6l   5F      ]� 5G      #���   6$   .+�5H      �� $'��!Количество комнат��6$   $	��200��6@   �� 5I        ComboBoxAdd#��[ 5J   '   	 �� Text	 5I   '   �� *NewFlat.CountRooms+$ PropertyChanged=�$ TwoWay=� . .@�5K   "   �� .��6/   162   �� 5L   "   .��6/   262   �� 5M   "   .��6/   362   �� 5N   "   .��6/   462   �� 5O   "   .��6/   562   5P      5Q      ]� 5R      #���   6$   .+�5S      �� $��Ремонт��6$   $	��200��65   �� 5U      $	��300��6'   $��25��63   	 5V   '   �� *NewFlat.Repair+$ PropertyChanged=�$ TwoWay=� . .@�5W   "   �� .��6/   Косметический6>   �� 5X   "   .��6/   Капитальный6<   �� 5Y   "   .��6/   Евроремонт6;   �� 5Z   "   .��6/   Дизайнерский6=   5[      5\      ]� 5]      #���   6$   $	��Top=�6K   .+�5^      �� $��Цена��6$   $	��200��63   �� 5_      #��[ 6&   $	��245��5`   &   $��
100,0,10,0q�5a   &   $
��Left=�5c   &   ��5b   &   �� *NewFlat.Price+$ PropertyChanged=�$ TwoWay=� . 5c   &   �� 5d      $��	$\мес.��6(   $��0,-5,0,0q�66   $��16(�6H   $��Right=�6V   $��Center=�6m   5e      5f      �� 5g      $��Center=�6!   .+�5h      �� $)��#Что есть в квартире��6$   $
��Bold"�6?   $��16(�6Q   $��center=�6_   $��
0,20,0,-20q�6|   
 K� ZIndex$
 1��6�   ]� 5i      .+�5j      �� $
��55,0q�6)   .+�5k   "   �� $��..\Source\WaterHeater.png��6(   $	��150��6K   �� 5l   "   $$��Водонагреватель��6+   $��10,0,0,0q�5m   +    d� 	IsChecked 5n   +   �� *NewFlat.Demands.WaterHeater+$ PropertyChanged=�$ TwoWay=�5o      �� 5p      $
��55,0q�6)   .+�5q   "   �� $��..\Source\Washer.png��6(   $	��150��6F   �� 5r   "   $'��!Стиральная машина��6+    5s   +   �� *NewFlat.Demands.Washer+$ PropertyChanged=�$ TwoWay=�5t      �� 5u      $
��55,0q�6)   .+�5v   "   �� $��..\Source\Microwave.png��6(   $	��150��6I   �� 5w   "   $'��!Микроволнова печь��6+   $��5,0,0,0q�5x   +    5y   +   �� *NewFlat.Demands.Microwave+$ PropertyChanged=�$ TwoWay=�5z      5{      ]� 5|      .+�5}      �� $
��55,0q�6)   .+�5~   "   �� $ ��..\Source\Refregicator.png��6(   $	��150��6L   �� 5   "   $��Холодильник��6+   $��20,0,0,0q�5�   +    5�   +   �� *NewFlat.Demands.Refrigicator+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $
��55,0q�6)   .+�5�   "   �� $��..\Source\Internet.png��6(   $	��150��6H   �� 5�   "   $��Интернет��6+   $��30,0,0,0q�5�   +    5�   +   �� *NewFlat.Demands.Internet+$ PropertyChanged=�$ TwoWay=�5�      �� 5�      $
��55,0q�6)   .+�5�   "   �� $��..\Source\TV.png��6(   $	��150��6B   �� 5�   "   $��Телевизор��6+   $��30,0,0,0q�5�   +    5�   +   �� *NewFlat.Demands.TV+$ PropertyChanged=�$ TwoWay=�5�      5�      5�      �� 5�      $��Center=�6!   .+�5�      �� $ ��Дополнительно��6$   $
��Bold"�69   $��16(�6K   $��Center=�6Y   $��	0,20,0,15q�6v   �� 5�      $
��Auto=�6"   $	��700��5�   "   $	��200��6.   $��14(�6;    �� TextWrapping$
 Wrap=�6I   ��5�   "   �� *NewFlat.Description+$ PropertyChanged=�$ TwoWay=�5�      5�      5�      5�      ]� 5�   
   $��1��6   $��Bottom=�6!   $��Center=�69   $��Right=�6T   $
��30,0q�6p   .+�5�      �� $
��Left=�6W   
���  ����6   �� *	ErrorLine+$ PropertyChanged=�6m   �� 5�        ButtonSendFlat#���  6   $	��150��5�      $��40��6!   $��Отправить��6-   $
 Hand��5�      ��5�      �� *
SendFlat+��5�      �� $
 Page��5�      5�      5�      5�      