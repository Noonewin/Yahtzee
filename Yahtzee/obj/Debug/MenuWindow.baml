   M S B A M L   `   `   `  ����B  >Yahtzee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:YahtzeeYahtzee  5   	       Yahtzee.MenuWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Yahtzee     5   	     � Title$  Yahtzee��5   	   $	��600��6   $	��800��6&   .��5	      � ��5
   
   �� 5       �� ImageSource$! static/yatzy-background.jpg��6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��303��6:   $	��Top=�6G   $	��476��6_   $��
198,-9,0,0q�6k   $��static/yahtzeelogo.png��6�   �� 5   
   -   5         ��Name$ btnSinglePlayer��5      $��Single Player��6*   $	��120��6B   $��30��6N   $��330,294,0,0q�6Z   ���	#FF0AB2E4$	��Top=�6�   $
��Left=�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        $ btnTwoPlayers��5      $��Two Players��6(   $	��120��6>   $��30��6J   $��330,346,0,0q�6V   ���	#FF0AB2E4$	��Top=�6�   $
��Left=�6�    5        5      5      �� 5   
   -   5        $ btnVsComputer��5      $��vs Computer��6(   $	��120��6>   $��30��6J   $��330,398,0,0q�6V   ���	#FF0AB2E4$	��Top=�6�   $
��Left=�6�    5        5      5      �� 5   
   -   5        $ btnExit��5      $
��Exit��6"   $	��120��62   $��30��6>   $��330,448,0,0q�6J   ���	#FF0AB2E4$	��Top=�6v   $
��Left=�6�    5        5      5!      5"      5#      