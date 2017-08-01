using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace BlackJack
{
    class ScoreCard
    {
        //adds up score depending on card pulled
        public static void AddToScore(ref int score, string card, bool player)
        {
            if (card.Contains("Ace"))
            {
                //checks if player is the one that pulled ace
                if(player)
                {
                    AcePopUp popUp = new AcePopUp();
                    var dialogResult = popUp.ShowDialog();
                }
                else
                {
                    //if dealer pulls ace it decides what value is best to assign to it.
                    if(score + 11 > 21)
                    {
                        score += 1;
                    }
                    else
                    {
                        score += 11;
                    }
                }
       

            }
            if (card.Contains("Deuce"))
            {
                score += 2;
            }
            if (card.Contains("Three"))
            {
                score += 3;
            }
            if (card.Contains("Four"))
            {
                score += 4;
            }
            if (card.Contains("Five"))
            {
                score += 5;
            }
            if (card.Contains("Six"))
            {
                score += 6;
            }
            if (card.Contains("Seven"))
            {
                score += 7;
            }
            if (card.Contains("Eight"))
            {
                score += 8;
            }
            if (card.Contains("Nine"))
            {
                score += 9;
            }
            if (card.Contains("Ten") || card.Contains("Jack") || card.Contains("Queen") || card.Contains("King"))
            {
                score += 10;
            }
            
        }
    }
}
