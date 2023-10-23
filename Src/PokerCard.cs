using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static void ShuffleHand(PokerHand hand)
        {
            Random rng = new Random();
            int cardNumber = hand.Cards.Count;

            for (int i = 0; i < cardNumber; i++)
            {
                int randomIndex = rng.Next(i, cardNumber);
                PokerCard temp = hand.Cards[i];
                hand.Cards[i] = hand.Cards[randomIndex];
                hand.Cards[randomIndex] = temp;
            }
        }
        public static PokerCard DrawTopCard(PokerHand from, PokerHand to)
        {
            PokerCard card = from.Cards[0];
            from.Cards.Remove(card);
            to.Cards.Add(card);
            return card;
        }
        public static int CountNumberOfDeck(List<PokerCard> shoe)
        {
            return shoe.Count / 52;
        }
    }

    public class PokerHand
    {
        public Resolution Resolution;
        public List<PokerCard> Cards = new List<PokerCard>();
        public static Dictionary<string, PokerHand> Hands = new Dictionary<string, PokerHand>();
        public PokerHand(Resolution resolution, string id)
        {
            Resolution = resolution;
            RegisterHand(id, this);
        }
        public static void RegisterHand(string id, PokerHand hand)
        {
            if (Hands.ContainsKey(id))
            {
                Log.Warning("Hand already exist: " + id);
            }
            Hands[id] = hand;
        }

        public int CountHandValue()
        {
            int total = 0;
            int numberOfAces = 0;

            foreach (var card in Cards)
            {
                // Count Ace first handle them later
                if (card.IsAce)
                {
                    numberOfAces++;
                }
                total += card.CardValue;
            }

            while (numberOfAces > 0 && total > 21)
            {
                total -= 10;
                numberOfAces--;
            }
            return total;
        }
        public Resolution GetCardResolutionOfHand(int index)
        {
            return new Resolution(
                Resolution.Scale,
                new Vector2(Resolution.Position.x + index * Resolution.Scaled(50),
                Resolution.Position.y - index * Resolution.Scaled(20)));
        }
        public Resolution GetCardResolutionOfHand(int index, int x, int y)
        {
            return new Resolution(
                Resolution.Scale,
                new Vector2(Resolution.Position.x - index * Resolution.Scaled(x),
                Resolution.Position.y - index * Resolution.Scaled(y)));
        }
    }
}
