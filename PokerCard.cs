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
        public string CardSymbol { get; set; }  
        public bool IsAce {get; set; }
        public string CardNameId { get; set; }
        public PokerCard(int CardId, string CardSymbol)
        {
            switch (CardId)
            {
                case 1:
                    this.CardId = 1;
                    CardName = "Ace";
                    CardValue = 11;
                    IsAce = true;
                    break;
                case 2:
                    this.CardId = 2;
                    CardName = "2";
                    CardValue = 2;
                    break;
                case 3:
                    this.CardId = 3;
                    CardName = "3";
                    CardValue = 3;
                    break;
                case 4:
                    this.CardId = 4;
                    CardName = "4";
                    CardValue = 4;
                    break;
                case 5:
                    this.CardId = 5;
                    CardName = "5";
                    CardValue = 5;
                    break;
                case 6:
                    this.CardId = 6;
                    CardName = "6";
                    CardValue = 6;
                    break;
                case 7:
                    this.CardId = 7;
                    CardName = "7";
                    CardValue = 7;
                    break;
                case 8:
                    this.CardId = 8;
                    CardName = "8";
                    CardValue = 8;
                    break;
                case 9:
                    this.CardId = 9;
                    CardName = "9";
                    CardValue = 9;
                    break;
                case 10:
                    this.CardId = 10;
                    CardName = "10";
                    CardValue = 10;
                    break;
                case 11:
                    this.CardId = 11;
                    CardName = "Joker";
                    CardValue = 10;
                    break;
                case 12:
                    this.CardId = 12;
                    CardName = "Queen";
                    CardValue = 10;
                    break;
                case 13:
                    this.CardId = 13;
                    CardName = "King";
                    CardValue = 10;
                    break;
            }
            
            switch (CardSymbol)
            {
                case "Clubs":
                    this.CardSymbol = "Clubs";
                    CardColor = "Black";
                    break;
                case "Diamonds":
                    this.CardSymbol = "Diamonds";
                    CardColor = "Red";
                    break;
                case "Hearts":
                    this.CardSymbol = "Hearts";
                    CardColor = "Red";
                    break;
                case "Spades":
                    this.CardSymbol = "Spades";
                    CardColor = "Black";
                    break;

            }
            if (CardName == "Ace" && CardSymbol == "Clubs")
            {
                CardNameId = "AceOfClubs";
            }
            else if (CardName == "Ace" && CardSymbol == "Diamonds")
            {
                CardNameId = "AceOfDiamonds";
            }
            else if (CardName == "Ace" && CardSymbol == "Hearts")
            {
                CardNameId = "AceOfHearts";
            }
            else if (CardName == "Ace" && CardSymbol == "Spades")
            {
                CardNameId = "AceOfSpades";
            }
            else if (CardName == "2" && CardSymbol == "Clubs")
            {
                CardNameId = "2OfClubs";
            }
            else if (CardName == "2" && CardSymbol == "Diamonds")
            {
                CardNameId = "2OfDiamonds";
            }
            else if (CardName == "2" && CardSymbol == "Hearts")
            {
                CardNameId = "2OfHearts";
            }
            else if (CardName == "2" && CardSymbol == "Spades")
            {
                CardNameId = "2OfSpades";
            }
            else if (CardName == "3" && CardSymbol == "Clubs")
            {
                CardNameId = "3OfClubs";
            }
            else if (CardName == "3" && CardSymbol == "Diamonds")
            {
                CardNameId = "3OfDiamonds";
            }
            else if (CardName == "3" && CardSymbol == "Hearts")
            {
                CardNameId = "3OfHearts";
            }
            else if (CardName == "3" && CardSymbol == "Spades")
            {
                CardNameId = "3OfSpades";
            }
            else if (CardName == "4" && CardSymbol == "Clubs")
            {
                CardNameId = "4OfClubs";
            }
            else if (CardName == "4" && CardSymbol == "Diamonds")
            {
                CardNameId = "4OfDiamonds";
            }
            else if (CardName == "4" && CardSymbol == "Hearts")
            {
                CardNameId = "4OfHearts";
            }
            else if (CardName == "4" && CardSymbol == "Spades")
            {
                CardNameId = "4OfSpades";
            }
            else if (CardName == "5" && CardSymbol == "Clubs")
            {
                CardNameId = "5OfClubs";
            }
            else if (CardName == "5" && CardSymbol == "Diamonds")
            {
                CardNameId = "5OfDiamonds";
            }
            else if (CardName == "5" && CardSymbol == "Hearts")
            {
                CardNameId = "5OfHearts";
            }
            else if (CardName == "5" && CardSymbol == "Spades")
            {
                CardNameId = "5OfSpades";
            }
            else if (CardName == "6" && CardSymbol == "Clubs")
            {
                CardNameId = "6OfClubs";
            }
            else if (CardName == "6" && CardSymbol == "Diamonds")
            {
                CardNameId = "6OfDiamonds";
            }
            else if (CardName == "6" && CardSymbol == "Hearts")
            {
                CardNameId = "6OfHearts";
            }
            else if (CardName == "6" && CardSymbol == "Spades")
            {
                CardNameId = "6OfSpades";
            }
            else if (CardName == "7" && CardSymbol == "Clubs")
            {
                CardNameId = "7OfClubs";
            }
            else if (CardName == "7" && CardSymbol == "Diamonds")
            {
                CardNameId = "7OfDiamonds";
            }
            else if (CardName == "7" && CardSymbol == "Hearts")
            {
                CardNameId = "7OfHearts";
            }
            else if (CardName == "7" && CardSymbol == "Spades")
            {
                CardNameId = "7OfSpades";
            }
            else if (CardName == "8" && CardSymbol == "Clubs")
            {
                CardNameId = "8OfClubs";
            }
            else if (CardName == "8" && CardSymbol == "Diamonds")
            {
                CardNameId = "8OfDiamonds";
            }
            else if (CardName == "8" && CardSymbol == "Hearts")
            {
                CardNameId = "8OfHearts";
            }
            else if (CardName == "8" && CardSymbol == "Spades")
            {
                CardNameId = "8OfSpades";
            }
            else if (CardName == "9" && CardSymbol == "Clubs")
            {
                CardNameId = "9OfClubs";
            }
            else if (CardName == "9" && CardSymbol == "Diamonds")
            {
                CardNameId = "9OfDiamonds";
            }
            else if (CardName == "9" && CardSymbol == "Hearts")
            {
                CardNameId = "9OfHearts";
            }
            else if (CardName == "9" && CardSymbol == "Spades")
            {
                CardNameId = "9OfSpades";
            }
            else if (CardName == "10" && CardSymbol == "Clubs")
            {
                CardNameId = "10OfClubs";
            }
            else if (CardName == "10" && CardSymbol == "Diamonds")
            {
                CardNameId = "10OfDiamonds";
            }
            else if (CardName == "10" && CardSymbol == "Hearts")
            {
                CardNameId = "10OfHearts";
            }
            else if (CardName == "10" && CardSymbol == "Spades")
            {
                CardNameId = "10OfSpades";
            }
            else if (CardName == "Joker" && CardSymbol == "Clubs")
            {
                CardNameId = "JokerOfClubs";
            }
            else if (CardName == "Joker" && CardSymbol == "Diamonds")
            {
                CardNameId = "JokerOfDiamonds";
            }
            else if (CardName == "Joker" && CardSymbol == "Hearts")
            {
                CardNameId = "JokerOfHearts";
            }
            else if (CardName == "Joker" && CardSymbol == "Spades")
            {
                CardNameId = "JokerOfSpades";
            }
            else if (CardName == "Queen" && CardSymbol == "Clubs")
            {
                CardNameId = "QueenOfClubs";
            }
            else if (CardName == "Queen" && CardSymbol == "Diamonds")
            {
                CardNameId = "QueenOfDiamonds";
            }
            else if (CardName == "Queen" && CardSymbol == "Hearts")
            {
                CardNameId = "QueenOfHearts";
            }
            else if (CardName == "Queen" && CardSymbol == "Spades")
            {
                CardNameId = "QueenOfSpades";
            }
            else if (CardName == "King" && CardSymbol == "Clubs")
            {
                CardNameId = "KingOfClubs";
            }
            else if (CardName == "King" && CardSymbol == "Diamonds")
            {
                CardNameId = "KingOfDiamonds";
            }
            else if (CardName == "King" && CardSymbol == "Hearts")
            {
                CardNameId = "KingOfHearts";
            }
            else if (CardName == "King" && CardSymbol == "Spades")
            {
                CardNameId = "KingOfSpades";
            }
        }

        public void DrawCard(Vector2 a, Vector2 b)
        {
            if (CardNameId == "AceOfClubs")
            {
                new Sprite2D(a, b, "AceOfClubs", "AceOfClubs");
            }
            else if (CardNameId == "AceOfDiamonds")
            {
                new Sprite2D(a, b, "AceOfDiamonds", "AceOfDiamonds");
            }
            else if (CardNameId == "AceOfHearts")
            {
                new Sprite2D(a, b, "AceOfHearts", "AceOfHearts");
            }
            else if (CardNameId == "AceOfSpades")
            {
                new Sprite2D(a, b, "AceOfSpades", "AceOfSpades");
            }
            else if (CardNameId == "2OfClubs")
            {
                new Sprite2D(a, b, "2OfClubs", "2OfClubs");
            }
            else if (CardNameId == "2OfDiamonds")
            {
                new Sprite2D(a, b, "2OfDiamonds", "2OfDiamonds");
            }
            else if (CardNameId == "2OfHearts")
            {
                new Sprite2D(a, b, "2OfHearts", "2OfHearts");
            }
            else if (CardNameId == "2OfSpades")
            {
                new Sprite2D(a, b, "2OfSpades", "2OfSpades");
            }
            else if (CardNameId == "3OfClubs")
            {
                new Sprite2D(a, b, "3OfClubs", "3OfClubs");
            }
            else if (CardNameId == "3OfDiamonds")
            {
                new Sprite2D(a, b, "3OfDiamonds", "3OfDiamonds");
            }
            else if (CardNameId == "3OfHearts")
            {
                new Sprite2D(a, b, "3OfHearts", "3OfHearts");
            }
            else if (CardNameId == "3OfSpades")
            {
                new Sprite2D(a, b, "3OfSpades", "3OfSpades");
            }
            else if (CardNameId == "4OfClubs")
            {
                new Sprite2D(a, b, "4OfClubs", "4OfClubs");
            }
            else if (CardNameId == "4OfDiamonds")
            {
                new Sprite2D(a, b, "4OfDiamonds", "4OfDiamonds");
            }
            else if (CardNameId == "4OfHearts")
            {
                new Sprite2D(a, b, "4OfHearts", "4OfHearts");
            }
            else if (CardNameId == "4OfSpades")
            {
                new Sprite2D(a, b, "4OfSpades", "4OfSpades");
            }
            else if (CardNameId == "5OfClubs")
            {
                new Sprite2D(a, b, "5OfClubs", "5OfClubs");
            }
            else if (CardNameId == "5OfDiamonds")
            {
                new Sprite2D(a, b, "5OfDiamonds", "5OfDiamonds");
            }
            else if (CardNameId == "5OfHearts")
            {
                new Sprite2D(a, b, "5OfHearts", "5OfHearts");
            }
            else if (CardNameId == "5OfSpades")
            {
                new Sprite2D(a, b, "5OfSpades", "5OfSpades");
            }
            else if (CardNameId == "6OfClubs")
            {
                new Sprite2D(a, b, "6OfClubs", "6OfClubs");
            }
            else if (CardNameId == "6OfDiamonds")
            {
                new Sprite2D(a, b, "6OfDiamonds", "6OfDiamonds");
            }
            else if (CardNameId == "6OfHearts")
            {
                new Sprite2D(a, b, "6OfHearts", "6OfHearts");
            }
            else if (CardNameId == "6OfSpades")
            {
                new Sprite2D(a, b, "6OfSpades", "6OfSpades");
            }
            else if (CardNameId == "7OfClubs")
            {
                new Sprite2D(a, b, "7OfClubs", "7OfClubs");
            }
            else if (CardNameId == "7OfDiamonds")
            {
                new Sprite2D(a, b, "7OfDiamonds", "7OfDiamonds");
            }
            else if (CardNameId == "7OfHearts")
            {
                new Sprite2D(a, b, "7OfHearts", "7OfHearts");
            }
            else if (CardNameId == "7OfSpades")
            {
                new Sprite2D(a, b, "7OfSpades", "7OfSpades");
            }
            else if (CardNameId == "8OfClubs")
            {
                new Sprite2D(a, b, "8OfClubs", "8OfClubs");
            }
            else if (CardNameId == "8OfDiamonds")
            {
                new Sprite2D(a, b, "8OfDiamonds", "8OfDiamonds");
            }
            else if (CardNameId == "8OfHearts")
            {
                new Sprite2D(a, b, "8OfHearts", "8OfHearts");
            }
            else if (CardNameId == "8OfSpades")
            {
                new Sprite2D(a, b, "8OfSpades", "8OfSpades");
            }
            else if (CardNameId == "9OfClubs")
            {
                new Sprite2D(a, b, "9OfClubs", "9OfClubs");
            }
            else if (CardNameId == "9OfDiamonds")
            {
                new Sprite2D(a, b, "9OfDiamonds", "9OfDiamonds");
            }
            else if (CardNameId == "9OfHearts")
            {
                new Sprite2D(a, b, "9OfHearts", "9OfHearts");
            }
            else if (CardNameId == "9OfSpades")
            {
                new Sprite2D(a, b, "9OfSpades", "9OfSpades");
            }
            else if (CardNameId == "10OfClubs")
            {
                new Sprite2D(a, b, "10OfClubs", "10OfClubs");
            }
            else if (CardNameId == "10OfDiamonds")
            {
                new Sprite2D(a, b, "10OfDiamonds", "10OfDiamonds");
            }
            else if (CardNameId == "10OfHearts")
            {
                new Sprite2D(a, b, "10OfHearts", "10OfHearts");
            }
            else if (CardNameId == "10OfSpades")
            {
                new Sprite2D(a, b, "10OfSpades", "10OfSpades");
            }
            else if (CardNameId == "JokerOfClubs")
            {
                new Sprite2D(a, b, "JokerOfClubs", "JokerOfClubs");
            }
            else if (CardNameId == "JokerOfDiamonds")
            {
                new Sprite2D(a, b, "JokerOfDiamonds", "JokerOfDiamonds");
            }
            else if (CardNameId == "JokerOfHearts")
            {
                new Sprite2D(a, b, "JokerOfHearts", "JokerOfHearts");
            }
            else if (CardNameId == "JokerOfSpades")
            {
                new Sprite2D(a, b, "JokerOfSpades", "JokerOfSpades");
            }
            else if (CardNameId == "QueenOfClubs")
            {
                new Sprite2D(a, b, "QueenOfClubs", "QueenOfClubs");
            }
            else if (CardNameId == "QueenOfDiamonds")
            {
                new Sprite2D(a, b, "QueenOfDiamonds", "QueenOfDiamonds");
            }
            else if (CardNameId == "QueenOfHearts")
            {
                new Sprite2D(a, b, "QueenOfHearts", "QueenOfHearts");
            }
            else if (CardNameId == "QueenOfSpades")
            {
                new Sprite2D(a, b, "QueenOfSpades", "QueenOfSpades");
            }
            else if (CardNameId == "KingOfClubs")
            {
                new Sprite2D(a, b, "KingOfClubs", "KingOfClubs");
            }
            else if (CardNameId == "KingOfDiamonds")
            {
                new Sprite2D(a, b, "KingOfDiamonds", "KingOfDiamonds");
            }
            else if (CardNameId == "KingOfHearts")
            {
                new Sprite2D(a, b, "KingOfHearts", "KingOfHearts");
            }
            else if (CardNameId == "KingOfSpades")
            {
                new Sprite2D(a, b, "KingOfSpades", "KingOfSpades");
            }

        }
    }
}
