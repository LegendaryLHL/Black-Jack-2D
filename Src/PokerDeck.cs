using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    class PokerDeck
    {
        public List<PokerCard> Deck = new List<PokerCard>();
        public PokerDeck(int numberOfDeck = 1)
        {
            for (int i = 0; i < numberOfDeck; i++)
            {
                string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
                foreach (string suit in suits)
                {
                    for (int value = 1; value <= 13; value++)
                    {
                        Deck.Add(new PokerCard(value, suit));
                    }
                }
            }
        }

        private static Random rng = new Random();
        public void ShuffleDeck()
        {
            Random rng = new Random();
            int deckSize = Deck.Count;

            for (int i = 0; i < deckSize; i++)
            {
                int randomIndex = rng.Next(i, deckSize);
                PokerCard temp = Deck[i];
                Deck[i] = Deck[randomIndex];
                Deck[randomIndex] = temp;
            }
        }
        public PokerCard DrawCardToHand(List<PokerCard> hand)
        {
            PokerCard card = Deck[0];
            Deck.Remove(card);
            hand.Add(card);
            return card;
        }

        // Debug
        public static void WriteDeck(PokerDeck Deck)
        {
            int count = 1;
            foreach (var item in Deck.Deck)
            {
                Console.WriteLine($"{count} Cards: {item.CardId}(id)       {item.CardName}(name)       {item.CardValue}(value)        {item.CardSuit}(Suit)        {item.CardColor}(Color)");
                count++;
            }
        }
    }
}
