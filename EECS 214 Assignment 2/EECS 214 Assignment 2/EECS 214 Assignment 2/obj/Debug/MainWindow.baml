   M S B A M L   `   `   `  ����  EECS 214 Assignment 2    Assignment_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Visualization��5   	   $	��410��6   $	��500��6,   
������� � 
ResizeMode$ NoResize=�6K   .��5      �� $
��Left=�6   $	��492��6,   .+�5   
   �� -   5         ��Name$ canvas��5      $	��300��6!   
������� J� IsHitTestVisible . $��	40,0,40,5q�6Y   � 5   
    � RowDefinitions 5      �� 5	      $
��Auto �6    �� 5
      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5         ��Name$ input��5      $	��300��6%   $��0��61   $��0��6>   $��40,0,0,0q�6N   �� 5      -   5         ��Name$ AddFrontBtn��5      $��	Add Front��6*   $��0��6?   $��1��6L   $��
51,0,-40,0q�6\   �� 5      -   5        $ RemoveFrontBtn��5      $��Remove Front��6-   $��1��6D   $��1��6Q   $��51,10,-40,0q�6a   �� 5      -   5        $ RemoveEndBtn��5      $��
Remove End��6+   $��1��6A   $��0��6N   $��224,10,30,10q�6^   �� 5      -   5        $ 	AddEndBtn��5      $��Add End��6(   $��1��6:   $��0��6G   $��62,10,191,10q�6W   5      5      5      