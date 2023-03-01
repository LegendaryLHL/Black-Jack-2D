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
        public PokerDeck()
        {
            
            for (int i = 1; i < 5; i++)
            {
                switch (i)
                {
                    case 1:
                        for (int a = 1; a < 14; a++)
                        {
                            Deck.Add(new PokerCard(a, "Hearts"));
                        }
                        break;
                    case 2:
                        for (int b = 1; b < 14; b++)
                        {
                            Deck.Add(new PokerCard(b, "Diamonds"));
                        }
                        break;
                    case 3:
                        for (int c = 1; c < 14; c++)
                        {
                            Deck.Add(new PokerCard(c, "Clubs"));
                        }
                        break;
                    case 4:
                        for (int d = 1; d < 14; d++)
                        {
                            Deck.Add(new PokerCard(d, "Spades"));
                        }
                        break;
                }
            }
        }

        private static Random rng = new Random();
        public static PokerDeck ShuffleDeck(PokerDeck Deck)
        {
            Console.Write("shuffled");
            for (int i = 1; i < 53; i++)
            {
                int TempRandomNumber = rng.Next(0, 52);
                PokerCard Temp = Deck.Deck[TempRandomNumber];
                Deck.Deck.Remove(Deck.Deck[TempRandomNumber]);
                Deck.Deck.Add(Temp);
            }
            for (int i = 1; i < 27; i++)
            {
                PokerCard Temp = Deck.Deck[i];
                Deck.Deck.Remove(Deck.Deck[i]);
                Deck.Deck.Add(Temp);
            }
            for (int i = 1; i < 53; i++)
            {
                int TempRandomNumber = rng.Next(0, 52);
                PokerCard Temp = Deck.Deck[TempRandomNumber];
                Deck.Deck.Remove(Deck.Deck[TempRandomNumber]);
                Deck.Deck.Add(Temp);
            }
            return Deck;
        }

        public static void WriteDeck(PokerDeck Deck)
        {
            int count = 1;
            foreach (var item in Deck.Deck)
            {
                Console.WriteLine($"{count} Cards: {item.CardId}(id)       {item.CardName}(name)       {item.CardValue}(value)        {item.CardSymbol}(symbol)        {item.CardColor}(Color)");
                count++;
            }
        }
    }
}
