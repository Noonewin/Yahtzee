   M S B A M L   `   `   `  ����B  >Yahtzee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:YahtzeeYahtzee  5   	        Yahtzee.SinglePlayerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Yahtzee     5   	     � Title$  Yahtzee��5   	   $	��575��6   $	��734��6&   .��5	      � ��5
   
   �� 5       �� ImageSource$! static/yatzy-background.jpg��6   .+�5   
   �� -   5         ��Name$ btnPlayer1RollDice��5      $��	Roll Dice��6-   $
��Left=�6A   $	��Top=�6\   $��75��6t   $��193,483,0,0q�6   ���	#FF5BA0F1 J� RenderTransformOrigin$ 0.5,0.5&�6�   
���   � J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ imgPlayer1Dice1��5      $
��Left=�6)   $��static/emptydice.png��6D   $��39��6b   $	��Top=�6n   $��39��6�   $��122,436,0,0q�6�   6�   �� 5   
   -   5        $ imgPlayer1Dice2��5      $
��Left=�6)   $��static/emptydice.png��6D   $��39��6b   $	��Top=�6n   $��39��6�   $��166,436,0,0q�6�   5      �� 5   
   -   5        $ imgPlayer1Dice3��5      $
��Left=�6)   $��static/emptydice.png��6D   $��39��6b   $	��Top=�6n   $��39��6�   $��210,436,0,0q�6�   $ 2.385,0.487&�6�   5      �� 5   
   -   5        $ imgPlayer1Dice4��5      $
��Left=�6)   $��static/emptydice.png��6D   $��39��6b   $	��Top=�6n   $��39��6�   $��254,436,0,0q�6�   $ 2.385,0.487&�6�   5      �� 5   
   -   5        $ imgPlayer1Dice5��5      $
��Left=�6)   $��static/emptydice.png��6D   $��39��6b   $	��Top=�6n   $��39��6�   $��298,436,0,0q�6�   $ 2.385,0.487&�6�   5      �� 5   
   -   5         ��Name$ grpBoxScore��5      $��Score��6(   $
��Left=�67   $��
458,37,0,0q�6R   $	��Top=�6f   $	��472��6~   $	��192��6�   $
��Bold"�6�   $��18(�6�   ��5      �� 5       �� Color$ White��6"    �� Opacity$
 0.15Q�60   5      �� 5    
   -   5        	 ��Name$	 lblTwos��5       $
��Twos��6!   $
��Left=�60   $��467,111,0,0q�6K   $	��Top=�6`   �� 5!   
   -	   5        $	 lblOnes��5!      $
��Ones��6!   $
��Left=�60   $��
467,85,0,0q�6K   $	��Top=�6_   �� 5"   
   -
   5        $	 	lblThrees��5"      $��Threes��6#   $
��Left=�64   $��467,137,0,0q�6O   $ 0.596,2.731&�6d   $	��Top=�6�   �� 5#   
   -   5        $	 lblFives��5#      $��Fives��6"   $
��Left=�62   $��467,189,0,0q�6M   $	��Top=�6b   �� 5$   
   -   5        $	 lblFours��5$      $��Fours��6"   $
��Left=�62   $��467,163,0,0q�6M   $	��Top=�6b   �� 5%   
   -   5        $	 lblSixes��5%      $��Sixes��6"   $
��Left=�62   $��467,215,0,0q�6M   $ 0.596,2.731&�6b   $	��Top=�6�   �� 5&   
   -   5        $	 lblBonus��5&      $��Bonus��6"   $
��Left=�62   $��467,267,0,0q�6M   $	��Top=�6b   $
��Bold"�6z   �� 5'   
   -   5        $	 lblSum��5'      $	��Sum��6    $
��Left=�6.   $��467,241,0,0q�6I   $	��Top=�6^   $
��Bold"�6v   �� 5(   
   -   5        $	 lblThreeOfAKind��5(      $��Three of a kind��6)   $
��Left=�6C   $��467,293,0,0q�6^   $ 0.596,2.731&�6s   $	��Top=�6�   �� 5)   
   -   5        $	 lblFullHouse��5)      $��
Full House��6&   $
��Left=�6;   $��467,345,0,0q�6V   $	��Top=�6k   �� 5*   
   -   5        $	 lblFourOfAKind��5*      $��Four of a kind��6(   $
��Left=�6A   $��467,319,0,0q�6\   $	��Top=�6q   �� 5+   
   -   5        $	 lblSmallStraight��5+      $��Small straight��6*   $
��Left=�6C   $��467,371,0,0q�6^   $ 0.596,2.731&�6s   $	��Top=�6�   �� 5,   
   -   5        $	 lblLargeStraight��5,      $��Large staight��6*   $
��Left=�6B   $��467,399,0,0q�6]   $ 0.596,2.731&�6r   $	��Top=�6�   �� 5-   
   -   5        $	 	lblChance��5-      $��Chance��6#   $
��Left=�64   $��467,425,0,0q�6O   $ 0.596,2.731&�6d   $	��Top=�6�   �� 5.   
   -   5        $	 
lblYahtzee��5.      $��Yahtzee��6$   $
��Left=�66   $��467,451,0,0q�6Q   $ 0.596,2.731&�6f   $	��Top=�6�   �� 5/   
   -   5        $	 lblTotalScore��5/      $��Total Score��6'   $
��Left=�6=   $��467,477,0,0q�6X   $ 0.596,2.731&�6m   $	��Top=�6�   $
��Bold"�6�   �� 50   
   -   5        $ btnPlayer1Ones��50      $��0��6)   $
��Left=�65   $	��Top=�6P   $��76��6h   $��
561,88,0,0q�6s   ���	#FF0E0E0E6�   �� 51   
   -   5        $ btnPlayer1Twos��51      $��0��6)   $
��Left=�65   $	��Top=�6P   $��76��6h   $��561,114,0,0q�6s   6�   �� 52   
   -   5        $ btnPlayer1Threes��52      $��0��6+   $
��Left=�67   $	��Top=�6R   $��76��6j   $��561,140,0,0q�6u   6�   �� 53   
   -   5        $ btnPlayer1Fours��53      $��0��6*   $
��Left=�66   $	��Top=�6Q   $��76��6i   $��561,166,0,0q�6t   6�   �� 54   
   -   5        $ btnPlayer1Fives��54      $��0��6*   $
��Left=�66   $	��Top=�6Q   $��76��6i   $��561,192,0,0q�6t   6�   �� 55   
   -   5        $ btnPlayer1Sixes��55      $��0��6*   $
��Left=�66   $	��Top=�6Q   $��76��6i   $��561,218,0,0q�6t   6�   �� 56   
   -   5        $ btnPlayer1Sum��56      $��0��6(   $
��Left=�64   $	��Top=�6O   $��76��6g   $��561,244,0,0q�6r   �� 57   
   -   5        $ btnPlayer1Bonus��57      $��0��6*   $
��Left=�66   $	��Top=�6Q   $��76��6i   $��561,270,0,0q�6t   �� 58   
   -    5        $ btnPlayer1ThreeOfAKind��58      $��0��61   $
��Left=�6=   $	��Top=�6X   $��76��6p   $��561,297,0,0q�6{   6�   �� 59   
   -!   5        $ btnPlayer1FourOfAKind��59      $��0��60   $
��Left=�6<   $	��Top=�6W   $��76��6o   $��561,322,0,0q�6z   6�   �� 5:   
   -"   5        $ btnPlayer1FullHouse��5:      $��0��6.   $
��Left=�6:   $	��Top=�6U   $��76��6m   $��561,348,0,0q�6x   6�   �� 5;   
   -#   5        $ btnPlayer1SmallStraight��5;      $��0��62   $
��Left=�6>   $	��Top=�6Y   $��76��6q   $��561,374,0,0q�6|   6�   �� 5<   
   -$   5        $ btnPlayer1LargeStraight��5<      $��0��62   $
��Left=�6>   $	��Top=�6Y   $��76��6q   $��561,402,0,0q�6|   6�   �� 5=   
   -%   5        $ btnPlayer1Chance��5=      $��0��6+   $
��Left=�67   $	��Top=�6R   $��76��6j   $��561,428,0,0q�6u   6�   �� 5>   
   -&   5        $ btnPlayer1Yahtzee��5>      $��0��6,   $
��Left=�68   $	��Top=�6S   $��76��6k   $��561,454,0,0q�6v   6�   �� 5?   
   -'   5        $ btnPlayer1TotalScore��5?      $��0��6/   $
��Left=�6;   $	��Top=�6V   $��76��6n   $��561,480,0,0q�6y   �� 5@   
   -(   5        $	 lblPlayer1Score��5@      $��Player 1��6)   $
��Left=�6<   $	��Top=�6W   $��
570,57,0,0q�6o   $
��Bold"�6�   �� 5A   
   -)   5        $	 
lblPlayer1��5A      $��Player 1��6$   $
��Left=�67   $��210,404,0,0q�6R   $	��Top=�6g   �� 5B   
   -*   5        $ image��5B      $
��Left=�6   $	��286��6:   $	��Top=�6G   $	��343��6_   $��	61,85,0,0q�6k   $��static/yahtzeelogo.png��6~   5C      5D      5E      