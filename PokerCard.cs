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
        public bool IsAce {get; set; }
        public string CardNameId { get; set; }
        public PokerCard(int CardId, string CardSuit)
        {
            String[] nameForCards = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10","Jack", "Queen", "King" };
            this.CardId = CardId;
            this.CardName = nameForCards[CardId - 1];
            if (CardId == (11 | 12 | 13))
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
            new Sprite2D(CardNameId);
        }
        public void DrawCard(Resolution resolution)
        {
            new Sprite2D(resolution, CardNameId, CardNameId);
        }

        //bad
        public void DrawCard(string resolutionName)
        {
            new Sprite2D(Resolution.GetResolution(resolutionName), CardNameId, CardNameId);
        }
    }
}
