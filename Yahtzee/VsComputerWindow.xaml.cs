﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VsComputerWindow.xaml.cs" company="NWTC">
//   Copyright
// </copyright>
// <summary>
//   Interaction logic for TwoPlayersWindow
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Yahtzee
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for TwoPlayersWindow
    /// </summary>
    public partial class VsComputerWindow : Window
    {
        /// <summary>
        /// The player 1 rolls.
        /// </summary>
        private int player1Rolls = 0;

        /// <summary>
        /// The computer rolls.
        /// </summary>
        private int computerRolls = 0;

        /// <summary>
        /// The player 1 dices.
        /// </summary>
        private int[] player1Dices = new int[] { 0, 0, 0, 0, 0 };

        /// <summary>
        /// The computer dices.
        /// </summary>
        private int[] computerDices = new int[] { 0, 0, 0, 0, 0 };

        /// <summary>
        /// The player 1 dices hold.
        /// </summary>
        private List<int> player1DicesHold = new List<int>();

        /// <summary>
        /// The computer dices hold.
        /// </summary>
        private List<int> computerDicesHold = new List<int>();

        /// <summary>
        /// The player 1 scores played.
        /// </summary>
        private List<string> player1ScoresPlayed = new List<string> { "TotalScore", "Sum", "Bonus" };

        /// <summary>
        /// The computer scores played.
        /// </summary>
        private List<string> computerScoresPlayed = new List<string> { "TotalScore", "Sum", "Bonus" };

        /// <summary>
        /// The player 1 dices score.
        /// </summary>
        private CheckDices player1DicesScore = new CheckDices();

        /// <summary>
        /// The computer dices score.
        /// </summary>
        private CheckDices computerDicesScore = new CheckDices();

        /// <summary>
        /// The player 1 score.
        /// </summary>
        private Dictionary<string, int> player1Score;

        /// <summary>
        /// The computer score.
        /// </summary>
        private Dictionary<string, int> computerScore;

        /// <summary>
        /// The player 1 score buttons.
        /// </summary>
        private Dictionary<string, Button> player1ScoreButtons = new Dictionary<string, Button>();

        /// <summary>
        /// The computer score buttons.
        /// </summary>
        private Dictionary<string, Button> computerScoreButtons = new Dictionary<string, Button>();

        /// <summary>
        /// The turn machine.
        /// </summary>
        private TurnMachine turnMachine = new TurnMachine("Player1", "HAL 9000");

        /// <summary>
        /// The player 1 sum.
        /// </summary>
        private int player1Sum = 0;

        /// <summary>
        /// The player 1 sum for lower section.
        /// </summary>
        private int player1LowerSectionSum = 0;

        /// <summary>
        /// The player 1 bonus.
        /// </summary>
        private int player1Bonus;

        /// <summary>
        /// The player 1 total sum.
        /// </summary>
        private int player1TotalSum = 0;

        /// <summary>
        /// The computer sum.
        /// </summary>
        private int computerSum = 0;

        /// <summary>
        /// The computer sum for lower section.
        /// </summary>
        private int computerLowerSectionSum = 0;

        /// <summary>
        /// The computer bonus.
        /// </summary>
        private int computerBonus;

        /// <summary>
        /// The computer total sum.
        /// </summary>
        private int computerTotalSum = 0;

        /// <summary>
        /// The player 1 score count.
        /// </summary>
        private int player1ScoreCount = 0;

        /// <summary>
        /// The computer score count.
        /// </summary>
        private int computerScoreCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoPlayersWindow"/> class.
        /// </summary>
        public VsComputerWindow()
        {
            this.InitializeComponent();
            this.ControlDicesPlayer1(false);
            this.ControlDicesPlayer2(false);
            this.DisableButtons();
            this.Player1ScoreButtonsMap();
            this.Player2ScoreButtonsMap();
        }

        /// <summary>
        /// Gets or sets the turn machine.
        /// </summary>
        public TurnMachine TurnMachine
        {
            get
            {
                return this.turnMachine;
            }

            set
            {
                this.turnMachine = value;
            }
        }

        /// <summary>
        /// The button player 1 roll dice click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1RollDiceClick(object sender, RoutedEventArgs e)
        {
            if (this.TurnMachine.AskForTurn() == "Player1" && this.player1Rolls != 3)
            {
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    if (!this.player1DicesHold.Contains(i))
                    {
                        this.player1Dices[i] = rnd.Next(1, 7);
                    }
                }

                this.ControlDicesPlayer1(true);
                this.player1Rolls++;
                this.player1DicesScore.AssignDices(this.player1Dices);
                this.player1Score = this.player1DicesScore.CheckCombinations();
                if (this.player1Rolls == 3)
                {
                    if (this.CheckForValidMovePlayer1())
                    {
                        this.AddScorePlayer1();
                    }
                    else
                    {
                        MessageBox.Show("You don't have any moves. It's HAL 9000 turn now.");
                        this.TurnMachine.GetTurn();
                        this.ResetDicesPlayer1();
                        this.player1Rolls = 0;
                    }

                    this.ControlDicesPlayer1(false);
                    this.UnholdImages();
                    this.player1DicesHold.Clear();
                }

                this.imgPlayer1Dice1.Source = new BitmapImage(new Uri("static/dice" + this.player1Dices[0] + ".png", UriKind.Relative));
                this.imgPlayer1Dice2.Source = new BitmapImage(new Uri("static/dice" + this.player1Dices[1] + ".png", UriKind.Relative));
                this.imgPlayer1Dice3.Source = new BitmapImage(new Uri("static/dice" + this.player1Dices[2] + ".png", UriKind.Relative));
                this.imgPlayer1Dice4.Source = new BitmapImage(new Uri("static/dice" + this.player1Dices[3] + ".png", UriKind.Relative));
                this.imgPlayer1Dice5.Source = new BitmapImage(new Uri("static/dice" + this.player1Dices[4] + ".png", UriKind.Relative));
                this.ResetButtonsPlayer1();
                this.AddScorePlayer1();
            }
        }

        /// <summary>
        /// The button computer roll dice click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2RollDiceClick(object sender, RoutedEventArgs e)
        {
            if (this.TurnMachine.AskForTurn() == "HAL 9000" && this.computerRolls != 3)
            {
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    if (!this.computerDicesHold.Contains(i))
                    {
                        this.computerDices[i] = rnd.Next(1, 7);
                    }
                }

                this.ControlDicesPlayer2(true);
                this.computerRolls++;
                this.computerDicesScore.AssignDices(this.computerDices);
                this.computerScore = this.computerDicesScore.CheckCombinations();
                if (this.computerRolls == 3)
                {
                    if (this.CheckForValidMovePlayer2())
                    {
                        this.AddScorePlayer2();
                    }
                    else
                    {
                        // MessageBox.Show("You don't have any moves. It's Player 1 turn now.");
                        this.TurnMachine.GetTurn();
                        this.ResetDicesPlayer2();
                        this.computerRolls = 0;
                    }

                    this.ControlDicesPlayer2(false);
                    this.UnholdImages();
                    this.computerDicesHold.Clear();
                }

                this.imgPlayer2Dice1.Source = new BitmapImage(new Uri("static/dice" + this.computerDices[0] + ".png", UriKind.Relative));
                this.imgPlayer2Dice2.Source = new BitmapImage(new Uri("static/dice" + this.computerDices[1] + ".png", UriKind.Relative));
                this.imgPlayer2Dice3.Source = new BitmapImage(new Uri("static/dice" + this.computerDices[2] + ".png", UriKind.Relative));
                this.imgPlayer2Dice4.Source = new BitmapImage(new Uri("static/dice" + this.computerDices[3] + ".png", UriKind.Relative));
                this.imgPlayer2Dice5.Source = new BitmapImage(new Uri("static/dice" + this.computerDices[4] + ".png", UriKind.Relative));
                this.ResetButtonsPlayer2();
                this.AddScorePlayer2();
            }
        }

        /// <summary>
        /// The check for valid move player 1.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckForValidMovePlayer1()
        {
            foreach (var score in this.player1Score)
            {
                if (!this.player1ScoresPlayed.Contains(score.Key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The check for valid move computer.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckForValidMovePlayer2()
        {
            foreach (var score in this.computerScore)
            {
                if (!this.computerScoresPlayed.Contains(score.Key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The player 1 dice 1 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player1Dice1Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer1Dice1.Opacity == 1)
            {
                this.imgPlayer1Dice1.Opacity = 0.5;
                this.player1DicesHold.Add(0);
            }
            else
            {
                this.imgPlayer1Dice1.Opacity = 1;
                this.player1DicesHold.Remove(0);
            }
        }

        /// <summary>
        /// The player 1 dice 2 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player1Dice2Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer1Dice2.Opacity == 1)
            {
                this.imgPlayer1Dice2.Opacity = 0.5;
                this.player1DicesHold.Add(1);
            }
            else
            {
                this.imgPlayer1Dice2.Opacity = 1;
                this.player1DicesHold.Remove(1);
            }
        }

        /// <summary>
        /// The player 1 dice 3 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player1Dice3Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer1Dice3.Opacity == 1)
            {
                this.imgPlayer1Dice3.Opacity = 0.5;
                this.player1DicesHold.Add(2);
            }
            else
            {
                this.imgPlayer1Dice3.Opacity = 1;
                this.player1DicesHold.Remove(2);
            }
        }

        /// <summary>
        /// The player 1 dice 4 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player1Dice4Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer1Dice4.Opacity == 1)
            {
                this.imgPlayer1Dice4.Opacity = 0.5;
                this.player1DicesHold.Add(3);
            }
            else
            {
                this.imgPlayer1Dice4.Opacity = 1;
                this.player1DicesHold.Remove(3);
            }
        }

        /// <summary>
        /// The player 1 dice 5 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player1Dice5Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer1Dice5.Opacity == 1)
            {
                this.imgPlayer1Dice5.Opacity = 0.5;
                this.player1DicesHold.Add(4);
            }
            else
            {
                this.imgPlayer1Dice5.Opacity = 1;
                this.player1DicesHold.Remove(4);
            }
        }

        /// <summary>
        /// The computer dice 1 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player2Dice1Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer2Dice1.Opacity == 1)
            {
                this.imgPlayer2Dice1.Opacity = 0.5;
                this.computerDicesHold.Add(0);
            }
            else
            {
                this.imgPlayer2Dice1.Opacity = 1;
                this.computerDicesHold.Remove(0);
            }
        }

        /// <summary>
        /// The computer dice 2 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player2Dice2Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer2Dice2.Opacity == 1)
            {
                this.imgPlayer2Dice2.Opacity = 0.5;
                this.computerDicesHold.Add(1);
            }
            else
            {
                this.imgPlayer2Dice2.Opacity = 1;
                this.computerDicesHold.Remove(1);
            }
        }

        /// <summary>
        /// The computer dice 3 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player2Dice3Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer2Dice3.Opacity == 1)
            {
                this.imgPlayer2Dice3.Opacity = 0.5;
                this.computerDicesHold.Add(2);
            }
            else
            {
                this.imgPlayer2Dice3.Opacity = 1;
                this.computerDicesHold.Remove(2);
            }
        }

        /// <summary>
        /// The computer dice 4 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player2Dice4Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer2Dice4.Opacity == 1)
            {
                this.imgPlayer2Dice4.Opacity = 0.5;
                this.computerDicesHold.Add(3);
            }
            else
            {
                this.imgPlayer2Dice4.Opacity = 1;
                this.computerDicesHold.Remove(3);
            }
        }

        /// <summary>
        /// The computer dice 5 click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Player2Dice5Click(object sender, RoutedEventArgs e)
        {
            if (this.imgPlayer2Dice5.Opacity == 1)
            {
                this.imgPlayer2Dice5.Opacity = 0.5;
                this.computerDicesHold.Add(4);
            }
            else
            {
                this.imgPlayer2Dice5.Opacity = 1;
                this.computerDicesHold.Remove(4);
            }
        }

        /// <summary>
        /// Enables controls for player 1.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private void ControlDicesPlayer1(bool value)
        {
            this.imgPlayer1Dice1.IsEnabled = value;
            this.imgPlayer1Dice2.IsEnabled = value;
            this.imgPlayer1Dice3.IsEnabled = value;
            this.imgPlayer1Dice4.IsEnabled = value;
            this.imgPlayer1Dice5.IsEnabled = value;
        }

        /// <summary>
        /// Enables controls for computer.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private void ControlDicesPlayer2(bool value)
        {
            this.imgPlayer2Dice1.IsEnabled = value;
            this.imgPlayer2Dice2.IsEnabled = value;
            this.imgPlayer2Dice3.IsEnabled = value;
            this.imgPlayer2Dice4.IsEnabled = value;
            this.imgPlayer2Dice5.IsEnabled = value;
        }

        /// <summary>
        /// Removes opacity from all dice images.
        /// </summary>
        private void UnholdImages()
        {
            this.imgPlayer1Dice1.Opacity = 1;
            this.imgPlayer1Dice2.Opacity = 1;
            this.imgPlayer1Dice3.Opacity = 1;
            this.imgPlayer1Dice4.Opacity = 1;
            this.imgPlayer1Dice5.Opacity = 1;

            this.imgPlayer2Dice1.Opacity = 1;
            this.imgPlayer2Dice2.Opacity = 1;
            this.imgPlayer2Dice3.Opacity = 1;
            this.imgPlayer2Dice4.Opacity = 1;
            this.imgPlayer2Dice5.Opacity = 1;
        }

        /// <summary>
        /// The disable buttons.
        /// </summary>
        private void DisableButtons()
        {
            this.btnPlayer1Ones.IsEnabled = false;
            this.btnPlayer2Ones.IsEnabled = false;
            this.btnPlayer1Twos.IsEnabled = false;
            this.btnPlayer2Twos.IsEnabled = false;
            this.btnPlayer1Threes.IsEnabled = false;
            this.btnPlayer2Threes.IsEnabled = false;
            this.btnPlayer1Fours.IsEnabled = false;
            this.btnPlayer2Fours.IsEnabled = false;
            this.btnPlayer1Fives.IsEnabled = false;
            this.btnPlayer2Fives.IsEnabled = false;
            this.btnPlayer1Sixes.IsEnabled = false;
            this.btnPlayer2Sixes.IsEnabled = false;
            this.btnPlayer1Sum.IsEnabled = false;
            this.btnPlayer2Sum.IsEnabled = false;
            this.btnPlayer1Bonus.IsEnabled = false;
            this.btnPlayer2Bonus.IsEnabled = false;
            this.btnPlayer1ThreeOfAKind.IsEnabled = false;
            this.btnPlayer2ThreeOfAKind.IsEnabled = false;
            this.btnPlayer1FourOfAKind.IsEnabled = false;
            this.btnPlayer2FourOfAKind.IsEnabled = false;
            this.btnPlayer1FullHouse.IsEnabled = false;
            this.btnPlayer2FullHouse.IsEnabled = false;
            this.btnPlayer1SmallStraight.IsEnabled = false;
            this.btnPlayer2SmallStraight.IsEnabled = false;
            this.btnPlayer1LargeStraight.IsEnabled = false;
            this.btnPlayer2LargeStraight.IsEnabled = false;
            this.btnPlayer1Chance.IsEnabled = false;
            this.btnPlayer2Chance.IsEnabled = false;
            this.btnPlayer1Yahtzee.IsEnabled = false;
            this.btnPlayer2Yahtzee.IsEnabled = false;
            this.btnPlayer1TotalScore.IsEnabled = false;
            this.btnPlayer2TotalScore.IsEnabled = false;
        }

        /// <summary>
        /// The player 1 score buttons map.
        /// </summary>
        private void Player1ScoreButtonsMap()
        {
            this.player1ScoreButtons.Add("Ones", this.btnPlayer1Ones);
            this.player1ScoreButtons.Add("Twos", this.btnPlayer1Twos);
            this.player1ScoreButtons.Add("Threes", this.btnPlayer1Threes);
            this.player1ScoreButtons.Add("Fours", this.btnPlayer1Fours);
            this.player1ScoreButtons.Add("Fives", this.btnPlayer1Fives);
            this.player1ScoreButtons.Add("Sixes", this.btnPlayer1Sixes);
            this.player1ScoreButtons.Add("Yahtzee", this.btnPlayer1Yahtzee);
            this.player1ScoreButtons.Add("BigStraight", this.btnPlayer1LargeStraight);
            this.player1ScoreButtons.Add("SmallStraight", this.btnPlayer1SmallStraight);
            this.player1ScoreButtons.Add("FourOfAKind", this.btnPlayer1FourOfAKind);
            this.player1ScoreButtons.Add("FullHouse", this.btnPlayer1FullHouse);
            this.player1ScoreButtons.Add("ThreeOfAKind", this.btnPlayer1ThreeOfAKind);
            this.player1ScoreButtons.Add("Sum", this.btnPlayer1Sum);
            this.player1ScoreButtons.Add("Bonus", this.btnPlayer1Bonus);
            this.player1ScoreButtons.Add("Chance", this.btnPlayer1Chance);
            this.player1ScoreButtons.Add("TotalScore", this.btnPlayer1TotalScore);
        }

        /// <summary>
        /// The computer score buttons map.
        /// </summary>
        private void Player2ScoreButtonsMap()
        {
            this.computerScoreButtons.Add("Ones", this.btnPlayer2Ones);
            this.computerScoreButtons.Add("Twos", this.btnPlayer2Twos);
            this.computerScoreButtons.Add("Threes", this.btnPlayer2Threes);
            this.computerScoreButtons.Add("Fours", this.btnPlayer2Fours);
            this.computerScoreButtons.Add("Fives", this.btnPlayer2Fives);
            this.computerScoreButtons.Add("Sixes", this.btnPlayer2Sixes);
            this.computerScoreButtons.Add("Yahtzee", this.btnPlayer2Yahtzee);
            this.computerScoreButtons.Add("BigStraight", this.btnPlayer2LargeStraight);
            this.computerScoreButtons.Add("SmallStraight", this.btnPlayer2SmallStraight);
            this.computerScoreButtons.Add("FourOfAKind", this.btnPlayer2FourOfAKind);
            this.computerScoreButtons.Add("FullHouse", this.btnPlayer2FullHouse);
            this.computerScoreButtons.Add("ThreeOfAKind", this.btnPlayer2ThreeOfAKind);
            this.computerScoreButtons.Add("Sum", this.btnPlayer2Sum);
            this.computerScoreButtons.Add("Bonus", this.btnPlayer2Bonus);
            this.computerScoreButtons.Add("Chance", this.btnPlayer2Chance);
            this.computerScoreButtons.Add("TotalScore", this.btnPlayer2TotalScore);
        }

        /// <summary>
        /// The add score player 1.
        /// </summary>
        private void AddScorePlayer1()
        {
            foreach (KeyValuePair<string, int> pair in this.player1Score)
            {
                if (!this.player1ScoresPlayed.Contains(pair.Key))
                {
                    this.player1ScoreButtons[pair.Key].IsEnabled = true;
                    this.player1ScoreButtons[pair.Key].Content = pair.Value;
                }
            }
        }

        /// <summary>
        /// The add score computer.
        /// </summary>
        private void AddScorePlayer2()
        {
            foreach (KeyValuePair<string, int> pair in this.computerScore)
            {
                if (!this.computerScoresPlayed.Contains(pair.Key))
                {
                    this.computerScoreButtons[pair.Key].IsEnabled = true;
                    this.computerScoreButtons[pair.Key].Content = pair.Value;
                }
            }
        }

        /// <summary>
        /// The player 1 pick score.
        /// </summary>
        /// <param name="dice">
        /// The dice.
        /// </param>
        private void Player1PickScore(string dice)
        {
            this.player1ScoresPlayed.Add(dice);
            this.DisableButtons();
            this.ResetButtonsPlayer1();
            this.TurnMachine.GetTurn();
            this.lblPlayerTurn.Content = this.TurnMachine.AskForTurn();
            this.player1Rolls = 0;
            this.CheckAndAddBonusPlayer1();
            this.ResetDicesPlayer1();
            this.UnholdImages();
            this.player1ScoreCount++;
            this.CheckVictory();
        }

        /// <summary>
        /// The check and add bonus player 1.
        /// </summary>
        private void CheckAndAddBonusPlayer1()
        {
            if (this.player1Sum > 63)
            {
                this.player1Bonus = 35;
                this.btnPlayer1Bonus.Content = 35;
            }
        }

        /// <summary>
        /// The check and add bonus computer.
        /// </summary>
        private void CheckAndAddBonusPlayer2()
        {
            if (this.computerSum > 63)
            {
                this.computerBonus = 35;
                this.btnPlayer2Bonus.Content = 35;
            }
        }

        /// <summary>
        /// The button player 1 ones click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1OnesClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Ones");
            this.player1Sum += int.Parse(this.btnPlayer1Ones.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1Sum.Content = this.player1Sum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 twos click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1TwosClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Twos");
            this.player1Sum += int.Parse(this.btnPlayer1Twos.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1Sum.Content = this.player1Sum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 threes click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1ThreesClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Threes");
            this.player1Sum += int.Parse(this.btnPlayer1Threes.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1Sum.Content = this.player1Sum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 fours click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1FoursClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Fours");
            this.player1Sum += int.Parse(this.btnPlayer1Fours.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1Sum.Content = this.player1Sum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 fives click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1FivesClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Fives");
            this.player1Sum += int.Parse(this.btnPlayer1Fives.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1Sum.Content = this.player1Sum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 sixes click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1SixesClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Sixes");
            this.player1Sum += int.Parse(this.btnPlayer1Sixes.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1Sum.Content = this.player1Sum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 three of a kind click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1ThreeOfAKindClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("ThreeOfAKind");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1ThreeOfAKind.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 four of a kind click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1FourOfAKindClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("FourOfAKind");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1FourOfAKind.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 full house click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1FullHouseClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("FullHouse");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1FullHouse.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 small straight click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1SmallStraightClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("SmallStraight");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1SmallStraight.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 large straight click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1LargeStraightClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("BigStraight");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1LargeStraight.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 chance click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1ChanceClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Chance");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1Chance.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The button player 1 Yahtzee click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer1YahtzeeClick(object sender, RoutedEventArgs e)
        {
            this.Player1PickScore("Yahtzee");
            this.player1LowerSectionSum += int.Parse(this.btnPlayer1Yahtzee.Content.ToString());
            this.player1TotalSum = this.player1Sum + this.player1LowerSectionSum;
            this.btnPlayer1TotalScore.Content = this.player1TotalSum;
        }

        /// <summary>
        /// The reset buttons player 1.
        /// </summary>
        private void ResetButtonsPlayer1()
        {
            foreach (KeyValuePair<string, Button> pair in this.player1ScoreButtons)
            {
                if (!this.player1ScoresPlayed.Contains(pair.Key))
                {
                    pair.Value.IsEnabled = false;
                    pair.Value.Content = 0;
                }
            }
        }

        /// <summary>
        /// The reset buttons computer.
        /// </summary>
        private void ResetButtonsPlayer2()
        {
            foreach (KeyValuePair<string, Button> pair in this.computerScoreButtons)
            {
                if (!this.computerScoresPlayed.Contains(pair.Key))
                {
                    pair.Value.IsEnabled = false;
                    pair.Value.Content = 0;
                }
            }
        }

        /// <summary>
        /// The computer pick score.
        /// </summary>
        /// <param name="dice">
        /// The dice.
        /// </param>
        private void Player2PickScore(string dice)
        {
            this.computerScoresPlayed.Add(dice);
            this.DisableButtons();
            this.ResetButtonsPlayer2();
            this.TurnMachine.GetTurn();
            this.lblPlayerTurn.Content = this.TurnMachine.AskForTurn();
            this.computerRolls = 0;
            this.CheckAndAddBonusPlayer2();
            this.ResetDicesPlayer2();
            this.UnholdImages();
            this.computerScoreCount++;
            this.CheckVictory();
        }

        /// <summary>
        /// The button computer ones click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2OnesClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Ones");
            this.computerSum += int.Parse(this.btnPlayer2Ones.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2Sum.Content = this.computerSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer twos_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2TwosClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Twos");
            this.computerSum += int.Parse(this.btnPlayer2Twos.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2Sum.Content = this.computerSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer threes click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2ThreesClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Threes");
            this.computerSum += int.Parse(this.btnPlayer2Threes.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2Sum.Content = this.computerSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer fours click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2FoursClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Fours");
            this.computerSum += int.Parse(this.btnPlayer2Fours.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2Sum.Content = this.computerSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer fives click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2FivesClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Fives");
            this.computerSum += int.Parse(this.btnPlayer2Fives.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2Sum.Content = this.computerSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer sixes click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2SixesClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Sixes");
            this.computerSum += int.Parse(this.btnPlayer2Sixes.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2Sum.Content = this.computerSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer three of a kind click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2ThreeOfAKindClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("ThreeOfAKind");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2ThreeOfAKind.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer four of a kind click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2FourOfAKindClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("FourOfAKind");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2FourOfAKind.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer full house click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2FullHouseClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("FullHouse");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2FullHouse.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer small straight click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2SmallStraightClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("SmallStraight");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2SmallStraight.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer large straight click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2LargeStraightClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("BigStraight");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2LargeStraight.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer chance click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2ChanceClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Chance");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2Chance.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The button computer Yahtzee click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnPlayer2YahtzeeClick(object sender, RoutedEventArgs e)
        {
            this.Player2PickScore("Yahtzee");
            this.computerLowerSectionSum += int.Parse(this.btnPlayer2Yahtzee.Content.ToString());
            this.computerTotalSum = this.computerSum + this.computerLowerSectionSum;
            this.btnPlayer2TotalScore.Content = this.computerTotalSum;
        }

        /// <summary>
        /// The reset dices player 1.
        /// </summary>
        private void ResetDicesPlayer1()
        {
            this.imgPlayer1Dice1.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer1Dice2.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer1Dice3.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer1Dice4.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer1Dice5.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
        }

        /// <summary>
        /// The reset dices computer.
        /// </summary>
        private void ResetDicesPlayer2()
        {
            this.imgPlayer2Dice1.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer2Dice2.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer2Dice3.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer2Dice4.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
            this.imgPlayer2Dice5.Source = new BitmapImage(new Uri("static/emptydice.png", UriKind.Relative));
        }

        /// <summary>
        /// The check victory.
        /// </summary>
        private void CheckVictory()
        {
            if (this.player1ScoreCount == this.computerScoreCount && this.player1ScoreCount == 13)
            {
                if (this.player1TotalSum > this.computerTotalSum)
                {
                    MessageBox.Show("Player 1 WON !!!");
                    this.InitializeComponent();
                }
                else if (this.player1TotalSum < this.computerTotalSum)
                {
                    MessageBox.Show("The computer WON !!!");
                    this.InitializeComponent();
                }
                else
                {
                    MessageBox.Show("DRAW !!!");
                    this.InitializeComponent();
                }
            }
        }
    }
}
