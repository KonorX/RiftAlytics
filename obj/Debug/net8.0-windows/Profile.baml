   M S B A M L   `   `   `  ����F  BRiftAlytics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RiftAlyticsRiftAlytics  5   	       RiftAlytics.Profile   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RiftAlytics     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5           MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignWindow#��[ 5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	     PrimaryHueLightBrush#���  5   	    � Title$ Profile��5   	   $	��800��6   $	��861��6&    � 	Resources 5          RiftAlytics.ColorConverter 
 Colors��%   &	         5   
   6   5      .��5      � ��5   
   �� 5       �� ImageSource$ 	/tree.png��6   .+�5   
   �� -   5        $��Обновить��5        SakuraBlossom#���  6$   #���  6Q   $
��Left=�6   $��
719,42,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ wr��5   4   $��wr��6   ���	#80ffb7c5$��50(�6@   
�������$��
Trajan Pro)�6a   $
��Left=�6y   $��425,221,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $
 info��5      $
��info��6   $��50(�6.   
�������$��
Trajan Pro)�6O   $
��Left=�6g   $��	38,42,0,0q�6�   $	��Top=�6�   $	��174��6�   $	��676��6�   ��5      �� 5        �� Color$ 	#80ffb7c5��6"   5"      �� 5#   
   ���	#80ffb7c5$!��Процент побед: ��6'   $��50(�6A   
�������$��
Trajan Pro)�6b   $
��Left=�6z   $��
38,221,0,0q�6�   $	��Top=�6�   �� 5$   
   -   5         ��Name$ MatchesList��5$      $��10,294,15,10q�6M   $��
Trajan Pro)�6c   $��30(�6{   ���	#E5FFFFFF���	#FFFF0B0B��5%      �� 5&      .R�5'      �� 	 �� CornerRadius$	 5��6]   $��2q�6n   
 �� Padding$
 10q�6y   ��6   �� *IsWin+ �� 	Converter# [ ._�5(      �� ��6$   �� *
GameMode+5)      5*      5,      5.      5/      