   M S B A M L   `   `   `  ����   	Kursovaya    Kursovaya.Main   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  Window�� � Title$ 
FlatHelper��$	��700��$
��1150�� � UseLayoutRounding .  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . .���  � RowDefinitions �� $	��200 ���  � ColumnDefinitions �� $	��220 ��� .+��� ���#134187$��0��._��  �� $��35 ��� .+��� -   	 ��Name$	 HeaderTitle�����#134187._��� $��
FlatHelper��$��Source Sans Pro Black)�
�������$��Center=�$��Center=��� $��1��._��� $��Source\House.png��$��24q�$��Center=��� ���#134187$��1��$��0��._��  �� $��35 ��� .+��� 
�������._��  �� $��* ��� $	��120 �.+��� -   
�������$��0��._�]� .+��� -   
 ��Name$
 UserTextBlock��$��Right=�$��Center=�$��14(�$��Right=�$��0,0,10,0q� � ContextMenu �� .@�m� $-��'Сменить пользователя��
������� m� Command �� *
ChangeUser+�� $��1��$��35��$	��Top=�._�]� $��Right=�$	��120��$��0��.+��� $��_��   MinButtonLar#���   ���� *MainWindowMinimize+����  �� ElementName$ Window���� $��.��#���   ���� *MainWindowMaximize+���� $ Window���� $��X��#���   ���� *CloseMainWindow+���� $ Window���� $��1�����#134187 J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   	Direction$	 221Q�   Opacity$	 0.1Q�   Color$ 	#FF151313���� $��1��._�]� $��1��$��Center=�$��Center=�.+��� $��1��
�������$��24(�$��
Constantia)����� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� ���#134187$��0��$��1��._�]� -    ]�Name$ 	MenuPanel��$	��Top=�.+���   ButtonStyleMenu#��[ $��Главная�� � Cursor$
 Hand������ *OpenMainPage+�� #��[ $��Фильтр��$
 Hand������ *
OpenFilter+�� -    ��Name$ AddFlatButton��#��[ $��Добавить��$
 Hand������ *OpenAddFlat+�� -   $ AdminButton��#��[ $(��"Администрирование��$
 Hand������ *OpenPageAdmin+�� -   $	 Pages��$��1��$��1��._� �   � NavigationUIVisibility$ Hidden=����� *CurrentPage+