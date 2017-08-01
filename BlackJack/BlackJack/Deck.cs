using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        public struct Card 
        {
            public Suit Suit { get; private set; }
            public Rank Rank { get; private set; }
            public Card(Suit suit, Rank rank) :
                this()
            {
                this.Suit = suit;
                this.Rank = rank;
            }
            //makes it a readable string
            public override string ToString()
            {
                return string.Format("{0} {1}", (Char)this.Suit, this.Rank);
            }

        }
  
        public enum Suit { Spades = 'S', Clubs = 'C', Diamonds = 'D', Hearts = 'H' }

        public enum Rank { Ace, Deuce, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    }
}


