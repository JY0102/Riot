   M S B A M L   `   `   `  ����G  C전적검색, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:전적검색.Controls전적검색.Controls  5   	   +clr-namespace:전적검색전적검색  5   	       전적검색.MainWindow   5   	   0Controls#clr-namespace:전적검색.Controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:전적검색     5   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1034��6)    � 	Resources 5	         전적검색.InfoConverter   infoConverter��%   &	          5
   
   6   5       � DataContext 5         전적검색.MainViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��Stretch=�6"   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      .+�5"      �� $�� 이름��6   $��1��6&   $��30��66   $��2��6C   $��	0,6,200,6q�6W   �� 5#      -   5         ��Name$ GameName��5#      $��2��6F   $��10,10,10,10q�6V   $	��180��6k   $��14(�6w   ��6,   �� *
GameName+6w   �� 5$      -   5         ��Name$ 	_GameType��5$      $��3��6.   $��10,10,10,10q�6>   $��70��6S    �� SelectedIndex$ 0��6^    �� SelectedItem 6p   �� *
GameType+.@�5%      �� $	��All��6#   �� 5&      $��normal��6#   �� 5'      $��ranked��6#   5(      �� 5)      $�� 출력개수 ��6   $��4��6)   $��30��69   $��10q�6F   �� 5*      -   5        $ Count��5*      $��5��6A   $��10,10,10,10q�6Q   $��70��6f   	 �� TextAlignment$	 Center=�6q   $��18(�6�   ��6)   �� *Count+6�   �� 5+      -   5        
 ��Name$
 SearchButton��5+      $��검색��6Q   $��6��6^   $��
10,10,0,10q�6n   $��60��6�   $
��Left=�6�   ��6/   �� *SearchCommand+6�   5,      5-      �� 5.   
   -   5         ��Name$ listBox��5.      $��1��6C   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6w    %� IsVirtualizing .  ��6#   �� *	Matches+ 6P   �� *SelectedMatch+��5/      �� 50      .R�51         전적검색.Controls.fow  52      54      56      57      