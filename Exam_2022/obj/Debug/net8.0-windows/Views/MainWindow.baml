   M S B A M L   `   `   `  ����D  @Exam_2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Exam_2022	Exam_2022  5   	       Exam_2022.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Exam_2022     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��0��6   $��10q�5      ��5      �� *ProductsList+ �� SelectedItem 5      �� *	Product+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       �� $��5q�6?   ��6$   �� *	ProductId+6?   �� 5!      $	�� - ��6$   �� 5"      $��5q�6A   ��6$   �� *ProductName+6A   5#      5$      5&      �� 5)   
   $��0��6   $��1��6   $��10q�5*      ��5+      �� *TotalSalePerProduct+��5,      �� 5-      .R�5.      �� $ 
Horizontal=�6!   .+�5/      �� $��5q�69   ��6$   �� *Key+69   �� 50      $��: ��6$   �� 51      $��5q�6;   ��6$   �� *Value+6;   52      53      55      �� 58   
   $��1��6   $��2��6"   $��10q�66   .+�59      �  5:      �� 5;      $��1* �6'   �� 5<      $��2* �6'    5>      �� 5?      $
��Auto �6$   �� 5@      $
��Auto �6$   �� 5A      $
��Auto �6$   �� 5B      $
��Auto �6$   .+�5E      �� $��0��6   $��0��6)   $��Product ID:��69   $��5q�6L   �� 5F      $��0��6   $��1��6'    �� 
IsReadOnly$
 True��6Z   $��5q�6l   ��67   �� *Product.ProductId+6l   �� 5H      $��1��6   $��0��6)   $��Product Name:��69   $��5q�6N   �� 5I      $��1��6   $��1��6'   $��5q�6\   ��67   �� *Product.ProductName+6\   �� 5K      $��2��6   $��0��6)   $��Quantity Per Unit:��69   $��5q�6S   �� 5L      $��2��6   $��1��6'   $��5q�6`   ��67   �� *Product.QuantityPerUnit+6`   �� 5N      $��3��6   $��0��6)   $��Supplier Contact Name:��69   $��5q�6W   �� 5O      $��3��6   $��1��6'   $
 True��6\   $��5q�6n   ��67   �� *Product.ContactName+6n   5P      �� 5S      $	��Maj��6   $��5q�6E   $��Center=�6P   $	��100��6m   ��6#   �� *ModifyCommand+6m   5T      5U      5V      