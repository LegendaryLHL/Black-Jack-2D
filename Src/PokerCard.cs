using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    public class PokerCard
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public int CardValue { get; set; }
        public string CardColor { get; set; }
        public string CardSuit { get; set; }
        public bool IsAce { get; set; }
        public string CardNameId { get; set; }
        public PokerCard(int CardId, string CardSuit)
        {
            string[] nameForCards = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            this.CardId = CardId;
            this.CardName = nameForCards[CardId - 1];
            if (CardId == 11 || CardId == 12 || CardId == 13)
            {
                CardValue = 10;
            }
            else
            {
                CardValue = CardId;
            }

            if (CardId == 1)
            {
                IsAce = true;
                CardValue = 11;
            }
            else
            {
                IsAce = false;
            }

            switch (CardSuit)
            {
                case "Clubs":
                    this.CardSuit = "Clubs";
                    CardColor = "Black";
                    break;
                case "Diamonds":
                    this.CardSuit = "Diamonds";
                    CardColor = "Red";
                    break;
                case "Hearts":
                    this.CardSuit = "Hearts";
                    CardColor = "Red";
                    break;
                case "Spades":
                    this.CardSuit = "Spades";
                    CardColor = "Black";
                    break;

            }

            CardNameId = CardName + "Of" + CardSuit;
        }

        public void DrawCard()
        {
            new Sprite(CardNameId);
        }
        public void DrawCard(Resolution resolution)
        {
            new Sprite(resolution, CardNameId, CardNameId);
        }
        public void DrawCard(Resolution resolution,string tag)
        {
            new Sprite(resolution, CardNameId, tag);
        }

        //bad
        public void DrawCard(string resolutionName)
        {
            new Sprite(Resolution.GetResolution(resolutionName), CardNameId, CardNameId);
        }

        public static List<PokerCard> NewShoe(int numberOfDeck = 1)
        {
            List<PokerCard> shoe = new List<PokerCard>();
            for (int i = 0; i < numberOfDeck; i++)
            {
                string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
                foreach (string suit in suits)
                {
                    for (int value = 1; value <= 13; value++)
                    {
                        shoe.Add(new PokerCard(value, suit));
                    }
                }
            }
            return shoe;
        }
        public static void ShuffleShoe(List<PokerCard> shoe)
        {
            Random rng = new Random();
            int cardNumber = shoe.Count;

            for (int i = 0; i < cardNumber; i++)
            {
                int randomIndex = rng.Next(i, cardNumber);
                PokerCard temp = shoe[i];
                shoe[i] = shoe[randomIndex];
                shoe[randomIndex] = temp;
            }
        }
        public static PokerCard DrawTopCard(List<PokerCard> cards, List<PokerCard> hand)
        {
            PokerCard card = cards[0];
            cards.Remove(card);
            hand.Add(card);
            return card;
        }
        public static int CountNumberOfDeck(List<PokerCard> shoe)
        {
            return shoe.Count / 52;
        }
    }
}
