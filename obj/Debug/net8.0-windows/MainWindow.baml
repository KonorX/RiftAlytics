   M S B A M L   `   `   `  ����F  BRiftAlytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RiftAlyticsRiftAlytics  5   	       RiftAlytics.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RiftAlytics     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignWindow#��[ 5   	   
������   MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      � ��5   
   �� 5       �� ImageSource$ /sakura.png��6    j� Stretch$ UniformToFill=�63   .+�5   
   �� -   5        $��
Поиск��5      $
��Left=�6!   $��565,295,0,0q�6<   $	��Top=�6Q     SakuraBlossom#���  6j   #���  6�   $��45(�6�   $��66��6�   $	��206��6�   $��
Trajan Pro)�6   �� 5   
   -   5         ��Name$ 	InputText��5   A   $
��Left=�6   $��
51,184,0,0q�6-    �� TextWrapping$
 Wrap=�6T   $�� ��6h   
�������$	��Top=�6�   $	��270��6�   	 �� 
CaretBrush
	 �����
 �� SelectionBrush

 ��������	#FFFFB7C5$��20(�6�   $��
Trajan Pro)�6�   �� 5   
   -   5         ��Name$ Output��5   h   $<��6Введите имя призывателя и тег��6   $
��Left=�69   $��
51,147,0,0q�6T   $	��Top=�6x   
����������	#80ffb7c5$��20(�6�   $��32��6�   $��
Trajan Pro)�6�   �� 5   
   ���	#80ffb7c5$��RiftAlytics��6'   $
��Left=�6=   $��70(�6X   
�������$��	30,10,0,0q�6y   $	��Top=�6�   $1��+/RiftAlytics;component/Fonts/TrajanPro-Bold)�6�   �� 5   
   -   5        $ SummonerInfoLabel��5      $y�Hidden=�6+   ���	#80ffb7c5$�� ��6V   $
��Left=�6a   $��
40,297,0,0q�6|   $	��Top=�6�   $��25(�6�   $��
Trajan Pro)�6�   
�������$	��292��6�   $��67��6�   �� 5    
   -   5         ��Name$ start��5       $y�Hidden=�6    $��Начать��65   $
��Left=�6F   $��364,304,0,0q�6a   $	��Top=�6v   $��25(�6�   
�������#���  6�   #���  6�   $��54��6
  $	��134��6  6"  �� 5!   
   -   5        $ tagName��5!      $
��Left=�6#   $��346,184,0,0q�6>   $
 Wrap=�6T   $�� ��6h   
�������$	��Top=�6�   $	��104��6�   
	 �����

 ��������	#FFFFB7C5$��20(�6�   $��
Trajan Pro)�6�   �� 5"   
   -   5        $!��История поиска��5"      $��19(�6*    J� Opacity$	 0.7Q�68   
�������#���  6Y   #���  6�   $
��Left=�6�   $��480,184,0,0q�6�   $	��Top=�6�   $	��188��6�   6  5%      5&      