using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Deck.Card> deck;
        private List<String> cards;
        public static int playerScore;
        private int dealerScore;
        private int count;

        public MainWindow()
        {
            InitializeComponent();

        }

        private async void bDeal_Click(object sender, RoutedEventArgs e)
        {
            //Creates new deck and Shuffles cards
            deck = Deal.NewDeck();
            cards = Deal.cardsToString(deck);
            Deal.Shuffle(cards);
            //Sets scores to zero, and next card index
            playerScore = 0;
            dealerScore = 0;
            count = 4;
            //clears the player's / dealer's score and cards
            tbPlayerScore.Text = playerScore.ToString();
            tbDealersScore.Text = dealerScore.ToString();
            playersCards.Text = "";
            dealersCards.Text = "";

            //deals out first card
            playersCards.Text = cards[0];
            ScoreCard.AddToScore(ref playerScore, cards[0], true);
            tbPlayerScore.Text = playerScore.ToString();
            await Task.Delay(2000);

            //deals out second card
            dealersCards.Text = cards[1];
            ScoreCard.AddToScore(ref dealerScore, cards[1], false);
            tbDealersScore.Text = dealerScore.ToString();
            await Task.Delay(2000);

            //deals out third card
            playersCards.Text += "\n";
            playersCards.Text += cards[2];
            ScoreCard.AddToScore(ref playerScore, cards[2], true);
            tbPlayerScore.Text = playerScore.ToString();
            await Task.Delay(2000);

            //deals out fourth card
            dealersCards.Text += "\n";
            dealersCards.Text += cards[3];
            ScoreCard.AddToScore(ref dealerScore, cards[3], false);
            tbDealersScore.Text = dealerScore.ToString();

            //allows player to Hit or Stay, not Deal
            bHit.IsEnabled = true;
            bStay.IsEnabled = true;
            bDeal.IsEnabled = false;
        }

        //Hit button listener
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //deals player one more card
            playersCards.Text += "\n";
            playersCards.Text += cards[count];
            ScoreCard.AddToScore(ref playerScore, cards[count], true);
            tbPlayerScore.Text = playerScore.ToString();
            ++count;
            //if player breaks 21 they lose
            if(playerScore > 21)
            {
                MessageBox.Show("You Busted");

                //allows player to Deal, not Hit or Stay
                bHit.IsEnabled = false;
                bStay.IsEnabled = false;
                bDeal.IsEnabled = true;

            }
        }

        //Stay button listener
        private async void bStay_Click(object sender, RoutedEventArgs e)
        {
            if (dealerScore < playerScore)
            {
                //adds one card at a time until the dealer wins or breaks
                while (dealerScore < playerScore)
                {
                    dealersCards.Text += "\n";
                    dealersCards.Text += cards[count];
                    ScoreCard.AddToScore(ref dealerScore, cards[count], false);
                    tbDealersScore.Text = dealerScore.ToString();
                    await Task.Delay(2000);
                    ++count;
                    //dealer loses
                    if (dealerScore > 21)
                    {
                        if(playerScore == 21)
                        {
                            MessageBox.Show("BlackJack, You Win");
                            //allows player to Deal, not Hit or Stay
                            bHit.IsEnabled = false;
                            bStay.IsEnabled = false;
                            bDeal.IsEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Dealer Busted, You Win");
                            //allows player to Deal, not Hit or Stay
                            bHit.IsEnabled = false;
                            bStay.IsEnabled = false;
                            bDeal.IsEnabled = true;
                        }
                    }
                    //dealer BlackJack
                    if (dealerScore == 21)
                    {
                        MessageBox.Show("Dealer BlackJack, You Lose");
                        //allows player to Deal, not Hit or Stay
                        bHit.IsEnabled = false;
                        bStay.IsEnabled = false;
                        bDeal.IsEnabled = true;
                    }
                    //dealer wins
                    if (dealerScore > playerScore && dealerScore < 21 || dealerScore == playerScore)
                    {
                        MessageBox.Show("You Lose");
                        //allows player to Deal, not Hit or Stay
                        bHit.IsEnabled = false;
                        bStay.IsEnabled = false;
                        bDeal.IsEnabled = true;
                    }
                }
            }
            //if dealer won after player clicked stay button
            else
            {
                MessageBox.Show("You Lose");
                //allows player to Deal, not Hit or Stay
                bHit.IsEnabled = false;
                bStay.IsEnabled = false;
                bDeal.IsEnabled = true;
            }
        }
    }
}
