   M S B A M L   `   `   `  ����   	Kursovaya    Kursovaya.Pages.MainPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  MainPage��.��� .+��� $��1��.���  � RowDefinitions �� $��50 ��� $��* �.+��� ._��� $6��0Показать новые объявления��   ButtonMainPage#���   $��0,10,0,0q�$	��500�� � Cursor$
 Hand������ *
UpdateList+�� $��1��$��Center=� � UseLayoutRounding . ._��� ���� *Flats+���� .R�� ���� .R���  �� Padding$ 10q�$��20q�$	��300��$	��300�����#F7F7F7 .  �� CornerRadius$ 5�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 1Q�   Color$ 	#FFBBBBBB��	   	Direction$	 0Q�
   RenderingBias$
 Quality=�   
BlurRadius$ 15Q�._��� $��5q�.+��� $
��Fill=�$��Center=�$	��150������ *Image+]� $��	5,-20,0,0q�.+��� $��Center=�
����������� *Price+�� $��$��
�������]� $��5q�.+��� $��Center=����� *Address.Sity+�� $��, ��$��Center=��� $��Center=����� *Address.Street+�� $��, ��$��Center=��� $��Center=����� *Address.NumberHouse+� .+��� $��Подробнее��$��30��
�������$	��0,5q����� *DataContext.OpenDetails+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$
 PageL����� 