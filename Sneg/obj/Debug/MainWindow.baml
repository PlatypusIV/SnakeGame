   M S B A M L   `   `   `  ����?  ;Sneg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnegSneg  5   	       Sneg.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Sneg     5   	   -   5          � Title$  Snek Challenge��5   	   $	��840��6    $
��1020��6-    � 
ResizeMode$ NoResize=�5	   	   
���   �.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��infoStackPanel��5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5        $��
scoreLabel��5      
�������5      �� 5      -   5        $��imageOfSnek��5      $	��100��5      $��UniformToFill=�5      5      r� 5      -   5        $��gameTimeTunes��5        r� Source$ Assets/HikageTheme.mp3?�5       r� LoadedBehavior$ Manual=�5      $y�	Collapsed=�5       r� Volume$	 0.5Q�5"      5$      �� 5&      $b��\W/A/S/D or arrow keys to guide Hikage                             Dont go through the walls!��6   
�������$��16(�5)      5,      �� 5.   
   -   5        $��
gameCanvas��5.      $��Stretch=�5/      $��Stretch=�50      
�������$��1��52      $��1q�53      .+�55      r� -   5        $��whenShitGetsRealElement��55      $ Manual=�56      $y�	Collapsed=�57       r� Stretch$
 Fill=�59      $
��1020��5:      $	��740��5;      5=      5?      5@      