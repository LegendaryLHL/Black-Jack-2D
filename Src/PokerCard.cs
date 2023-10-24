using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BlackJack2D
{
    public class PokerCard
    {
        // Fix naming
        // make sure this is the api ignore logic first first make the base
        // Dont cut CORNER!!!
        // make as many function
        public string CardName { get; set; }
        public int CardValue { get; set; }
        public string CardColor { get; set; }
        public string CardSuit { get; set; }
        public bool IsAce { get; set; }
        public bool FaceUp = true;
        public string CardImageDirectory { get; set; }
        public string Tag { get; set; }
        public PokerCard(int generatorNum, string CardSuit, string addUniqueTag = "")
        {
            string[] nameForCards = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            CardName = nameForCards[generatorNum - 1];
            if (generatorNum == 11 || generatorNum == 12 || generatorNum == 13)
            {
                CardValue = 10;
            }
            else
            {
                CardValue = generatorNum;
            }

            if (generatorNum == 1)
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

            CardImageDirectory = CardName + "Of" + CardSuit;
            Tag = CardName + "Of" + CardSuit + addUniqueTag;
        }

        public void DrawCard(Resolution resolution)
        {
            if (FaceUp)
            {
                new Sprite(resolution, CardImageDirectory, Tag);
            }
            else
            {
                new Sprite(resolution, "PokerCardBack", Tag);
            }
        }
        public void UnDrawCard()
        {
            GameEngine.UnRegisterGraphicElement(GameEngine.AllGraphicElements[Tag]);
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
                        shoe.Add(new PokerCard(value, suit, i.ToString()));
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
        public string Id;
        public PokerHand(Resolution resolution, string id)
        {
            Resolution = resolution;
            Id = id;
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
        public void FlipCard(int index = -1)
        {
            if(index == -1)
            {
                index = Cards.Count - 1;
            }
            PokerCard card = Cards[index];
            card.FaceUp = !card.FaceUp;
            if (GameEngine.AllGraphicElements.ContainsKey(card.Tag))
            {
                card.UnDrawCard();
                card.DrawCard(GetCardResolutionOfHand(Cards.Count));
            }
        }
        public void ReciveTopCard(PokerHand from, bool draw = false)
        {
            PokerCard card = from.Cards[0];
            from.Cards.Remove(card);
            Cards.Add(card);
            if (draw)
            {
                card.DrawCard(GetCardResolutionOfHand(Cards.Count));
            }
        }
        public Resolution GetCardResolutionOfHand(int index)
        {
            return new Resolution(
            Resolution.Scale,
                new Vector2(Resolution.Position.x + index * Resolution.Scaled(50),
                Resolution.Position.y - index * Resolution.Scaled(50)));
        }
    }
}
