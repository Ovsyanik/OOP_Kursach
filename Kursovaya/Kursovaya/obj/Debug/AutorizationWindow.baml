   M S B A M L   `   `   `  ����  	Kursovaya"    Kursovaya.AutorizationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  Window��5   	    � Title$
 Main��5   	   $	��600��6   $	��400��6&    � UseLayoutRounding .   � WindowStyle$
 None=�5	   	    � AllowsTransparency . .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   6*   �� 5      6   .+�5   
   �� $��2��6   $��1q�6"   ���	#FFBBBBBB J� Opacity$	 0.5Q�6N   �� 5   
   -   5         ��Name$ 	Rectangle��5      $	��360��6(   $	��Top=�66   $��0��6N   $��2��6[   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&   	 �� EndPoint$	 0.5,1&�69   .��5      � 
 � Color$
 #048adc��6#   � 5      $
 #134187��6#    � Offset$ 1Q�63   � 5      $
 #0593e6��6#   5      5      �� 5   
   $	��Top=�6   $��1��6)   $��80��66   ._�5      �� $��Source\House.png��6   5      �� 5   
   -   5         ��Name$ BorderFrame1��5      $
�� 280��6'   $��1��64   $	��400��6A    �� CornerRadius$ 40��6N   
������� . ._�5        �   � NavigationUIVisibility$ Hidden=�5!      ��5       �� *CurrentPage+5!       J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         Color$ 	#FFBBBBBB��6#      	Direction$ 0Q�65      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6k   5%      �� 5(   
   ���#048adc$��0��6&   ._�5)      �  � ColumnDefinitions 5*      �� 5+      $��* �6'   63   �� 5,      $��75 �6'   64   .+�5/      �� -   5        $��0��5/      ���#048adc6>   �� 52      $��1��6   ���#048adc._�53      ]� $��Right=�6    $��75��6<   .+�54      �� $��_��6!      ControlButtonAutorizWin#���   55   !   ��56   !   �� *MainWindowMinimize+��57   !   ��  �� ElementName$ Window���� 58      $��X��6!   #���   59   !   ��5:   !   �� *CloseMainWindow+��5;   !   �� $ Window��5<      5=      5>      5?      5C      5D      