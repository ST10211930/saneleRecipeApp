   M S B A M L   `   `   `  ����F  BProgPart3v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProgPart3v2ProgPart3v2  5   	       ProgPart3v2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProgPart3v2     5   	     � Title$  SplashScreen��5   	   $	��450��6   $	��800��6+    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   � 
���   �.+�5      � -   5         �Name$ BG��5      ��5      �� 5      -   5        
img_bg�� �� ImageSource$ /Icons/bg spices.jpg��5       j� Stretch$
 Fill=�5      5      5      � 5   
   -   5        $ 	Nav_panel��5      $
��Left=�5      $	��300��5      
������ .+�5       �� -   5         ��Name$ st_pnl��5       .+�5!      � $	��110��6   .+�5"      �� $��1��6    $��0��5#      $��Sanele's Recipe App��5$      
�������$��Center=�5&      
������ $��Center=�5(      $
��Bold"�5)      $��28(�5*      $��18,20,18,53q�6'   5-      �� 50      -   5         ��Name$ ListView��50      
������ 
������ $��Disabled=�53      .@�55      �� -   5        	 ��Name$	 ListViewItem��55   #   $
��Left=�57   "   .��59      �� 
 �� Orientation$
 
Horizontal=�6%   $	��220��5:   !   .+�5<      �� $��/Icons/icon open-book.png��6$   $��Uniform=�5=   !   $��42��63   $��45��6?   �� 5?      $��Recipe Book��6(    �� TextAlignment$
 Left=�5@   !   $��10q�5A   !   $��23(�5B   !   
�������$��Black"�5D   !   $��34��64   $	��140��6@   5E      5F      5G      �� 5J      -   5        $ 	ListView2��5J      
������ 
������ $��Disabled=�5M      .@�5O      �� -   5        $	 ListViewItem2��5O   #   $
��Left=�5Q   #   .��5S      �� $
 
Horizontal=�6)   $	��220��5T   )   .+�5V      �� $��/Icons/icon exit.png��6$   $��Uniform=�5W      $��42��6   $��45��6   �� 5Y      $
��Exit��6(   $
 Left=�5Z   !   $��10q�5[   !   $��23(�5\   !   
�������$��Black"�5^   !   $��34��64   $	��140��6@   5_      5`      5a      5c      5e      5g      5h      