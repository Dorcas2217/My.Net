   M S B A M L   `   `   `  ����E  ADemoLegume, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DemoLegume
DemoLegume  5   	       DemoLegume.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DemoLegume     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         ItemTemplate �� Orientation��%  &	        �� 5
   
   .R�5      �� $ 
Horizontal=�6   $��0 5 0 5q�63   .+�5      �� $��Center=�6/   $��Center=�6J   ��6   �� *Id+6J   �� 5      $��Center=�66   $��Center=�6Q   ��6   �� *	NameCombo+6Q   5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ combo��5      $
��Left=�6"   $��	87,75,0,0q�6=   $	��Top=�6P   $	��120��6h   #��[  5      ��5   t   �� *LegumesList+ �� SelectedItem 5   ?   �� *SelectedLegume+�� 5   
   $��Id��6   $
��Left=�6   $��
51,161,0,0q�68   $	��Top=�6L   �� 5   
   $
��Name��6   $
��Left=�6   $��
51,192,0,0q�6:   $	��Top=�6N   �� 5   
   $
��Left=�6   $��23��6-   $��
98,161,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�5   I   $	��120��6a   ��5   a   �� *Id+ �� Mode$ OneWay=� � DataContext 5      �� *SelectedItem+ �� ElementName$ combo��6a   �� 5   
   $
��Left=�6   $��23��6-   $��
98,194,0,0q�69   $
 Wrap=�6M   $	��Top=�5   I   $	��120��6a   ��5   a   �� *Name+ 5      �� *SelectedItem+$ combo��6a   �� 5   
   $	��New��6   $
��Left=�6>   $��299,237,0,0q�6Y   $	��Top=�6n   $��75��6�   ��6   �� *
NewCommand+6�   5      5       