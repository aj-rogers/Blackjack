using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deal
    {

        //Creates New Deck
        public static List<Deck.Card> NewDeck()
        {
            List<Deck.Card> deck = new List<Deck.Card>();
            foreach (Deck.Rank r in Enum.GetValues(typeof(Deck.Rank)))
            {
                foreach (Deck.Suit s in Enum.GetValues(typeof(Deck.Suit)))
                {
                    deck.Add(new Deck.Card(s, r));
                }
            }
            return deck;
        }

        //converts the list into a string list
        public static List<String> cardsToString(List<Deck.Card> deck)
        {
            List<String> cards = new List<string>();
            foreach (Deck.Card card in deck)
            {
                cards.Add(card.ToString());
            }
            return cards;
        }
        //shuffles the deck
        public static void Shuffle(List<String> cards)
        {
            Random rng = new Random();
            int n = cards.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                String tmp = cards[k];
                cards[k] = cards[n];
                cards[n] = tmp;
            }
        }
    }
}
