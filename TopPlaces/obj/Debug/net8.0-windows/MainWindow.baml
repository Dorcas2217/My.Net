   M S B A M L   `   `   `  ����D  @TopPlaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TopPlaces	TopPlaces  5   	       TopPlaces.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TopPlaces     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         
TitreStyle �� Property �� Value  
LabelStyle  ItemTemplate �� Orientation��%  &	        &	 �     &	 �     �� 5
   
   .�5      ��  � ��$ 18(�6/   �� 5       � ��
 �   �62   �� 5       � ��$ 2q�66   5      �� 5   
   .�5      ��  � ��$ Courier New)�65   5      �� 5   
   .R�5      �� $ 
Horizontal=�6   $��0 5 0 5q�63   .+�5      �� $��50��6   $��50��6#   $
��Fill=�6/   $��Center=�6W   $��Center=�6r   ��6>   �� *Image+6r   �� 5      $��Center=�68   $��Center=�6S   ��6   �� *Description+6S   5      5      5      .��5      � $��0,0,39,0q�6   .+�5   
   �� -   5        $��listBoxPhotos��5   l   #��[ 6   $��
0,0,621,95q�6X   ��6?   �� 6�   �� 5   
   $��
Top Places��6   $
��Left=�6%   $��
370,10,0,0q�6@   $	��Top=�6T   $��96��6l   $��Baskerville Old Face)�6w   #��[  6�   �� 5   
   -   5        $��Image��5   �   $
��Left=�6   $	��162��6+   $��
304,55,0,0q�68   $	��Top=�6L   $
��Fill=�6d   $	��252��6s   $��/photos/amsterdam.jpg��6�   6�   �� 5   
   $��Description��6   $
��Left=�6&   #��[ 6A   $��186,244,0,0q�6e   $	��Top=�6z   $��99��6�   �� 5    
   $��Nbr Vote��6   $
��Left=�6#   #��[ 6>   $��186,324,0,0q�6b   $	��Top=�6w   $��99��6�   �� 5!   
   $	��Url��6   $
��Left=�6   #��[ 69   $��186,286,0,0q�6]   $	��Top=�6r   $��99��6�   �� 5#   
   -   5         ��Name$ description_value��5#      $
��Left=�6w   #��[ 6�   $��325,244,0,0q�6�   $	��Top=�6�   $	��141��6�    J� RenderTransformOrigin$ 0.526,1.044&�6�   $��24��6  ��6+   ��  �� ElementName$ listBoxPhotos�� �� Path$ SelectedItem.Description�6  �� 5$   
   -   5        $ 	url_value��5$      #��[ 6h   $
��Left=�6�   $��304,286,0,0q�6�   $	��Top=�6�   $	��356��6�   $��37��6�   ��6#   �� $ listBoxPhotos��$ SelectedItem.Path�6�   �� 5%   
   -   5        $ nbrvote_value��5%      #��[ 6o   $
��Left=�6�   $��304,323,0,0q�6�   $	��Top=�6�   $	��156��6�   $��33��6�   ��6'   �� $ listBoxPhotos��$ SelectedItem.NbVotes�6�   �� 5&   
   $
��Left=�6   $��285,379,0,0q�6-   $	��Top=�6B   .��5'      �� $ 
Horizontal=�6   $	��113��62   .+�5(      �� $��photos\jaime.png��6   $��25��62   $��45��6>   $��0,0,0,0q�6I   $
��Left=�6Z   �� 5)      $��Je vote pour��6   $��Center=�60   $��74��6K   5*      5+      5-      5.      