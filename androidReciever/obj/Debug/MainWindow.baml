   M S B A M L   `   `   `  ����J  FandroidReciever, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:androidRecieverandroidReciever  5   	        androidReciever.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:androidReciever     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��30* �6   �� 5      $
��118* �6   �� 5      $
��209* �6   �� 5      $
��119* �6   �� 5      $	��42* �6   .+�5   
   �� -   5         ��Name$ btnStart��5      $��Start��6#   $
��Left=�63   $��25.863,248,0,0q�6N   $	��Top=�6f   $��75��6~   $��3��6�   �� 5   
   -   5         ��Name$ label��5      $��
IP Address��6   $
��Left=�64   $��32.6,84,0,0q�6O   $	��Top=�6d   $��1��6|   �� 5   
   -   5         ��Name$ txtIP��5      $
��Left=�6!   $��23��6<   $��32.6,114,0,0q�6H    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�   $��2��6�   $��1��6�   $��192.168.1.3��6�   �� 5   
   -   5        $ 
label_Copy��5      $
��Port��6$   $
��Left=�63   $��73.2,83,0,0q�6N   $	��Top=�6c   $��2��6{   �� 5   
   -   5        $ txtPort��5      $
��Left=�6#   $��23��6>   $��73.2,114,0,0q�6J   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   $��2��6�   $
��8880��6�   �� 5   
   -   5        $ btnStop��5      $
��Stop��6"   $
��Left=�61   $��25.863,272,0,0q�6L   $	��Top=�6d   $��75��6|   $��3��6�   5      5      