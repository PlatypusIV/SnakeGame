   M S B A M L   `   `   `  ����?  ;Sneg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Sneg.ScreensSneg.Screens  5   	   !    Sneg.Screens.PostGameScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Sneg.Screens     5   	     � Title$  PostGameScreen��5   	   $	��840��6    $
��1020��6-   
���   � � 
ResizeMode$ NoResize=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5      r� -   5        $��audioElement��5      $y�	Collapsed=�5       r� LoadedBehavior$ Manual=�5      � 5   
   .+�5      �� -   5        $��gameOverImage��5      $��/Assets/SnegPlompf.png��5      �� 5      -   5        $��endScoreLabel��5      $��Bottom=�5      $��Center=�5      
�������$��50(�5      $��0,0,0,30q�5      5       �� 5&   
   $��1��6    �� Orientation$ 
Horizontal=�5'      $��Center=�5(      .+�5)      �� -   5        $��retryBtn��5)      $��40��5*      $	��100��5+      
�������
���   �$��Retry?��5.      $��30(�5/      $��1q�50      51      �� 53      -   5        $��closeGameBtn��53      $��40��54      $	��100��55      
�������
���   �$��Close?��58      $��30(�59      $��1q�5:      5;      5<      5@      5A      