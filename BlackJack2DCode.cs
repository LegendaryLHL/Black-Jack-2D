using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Media;

namespace BlackJack2D
{
    class BlackJack2DCode
    {
        public static int BetAmount = 0;
        public static int Money = 0;
        public static List<PokerCard> DealerHand;
        public static List<PokerCard> PlayerHand;

        public static PokerDeck NewPokerDeck = new PokerDeck();
        public static void PlayFunction()
        {
            ReadMoney();
            if (Money < 50)
            {
                Money = 50;
            }
            //put bet
            GameEngine.AllGraphicElements.Clear();
            new Text("Place your bet:", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("PlaceBet").Position);
            new Text($"Your Money: {Money}$", new Font("Arial", 50, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("YourMoney").Position);
            new Sprite2D("_0");
            new Sprite2D("_50");
            new Sprite2D("_100");
            new Sprite2D("_200");
            new Sprite2D("_500");
            new Sprite2D("_1000");
            new Sprite2D("_5000");
            new Sprite2D("_10000");
            new Sprite2D("_100000");
            new Sprite2D("_1000000");
            new Sprite2D("BackButton");
        }
        public static void BlackJack()
        {
            GameEngine.AllGraphicElements.Clear();
            PlayerHand = new List<PokerCard>();
            DealerHand = new List<PokerCard>();

            new Sprite2D("HitButton");
            new Sprite2D("StayButton");

            for (int i = 0; i < 2; i++)
            {
                NewPokerDeck.DrawCardToHand(PlayerHand);
                NewPokerDeck.DrawCardToHand(DealerHand);
            }

            DealerHand[0].DrawCard("DealerFirstCard");
            new Sprite2D(Resolution.GetResolution("DealerSecondCard"), "PokerCardBack");

            PlayerHand[0].DrawCard("YourFirstCard");
            PlayerHand[1].DrawCard("YourSecondCard");
        }

        public static string NumberToOrder(int number)
        {
            var map = new[] { "Zeroth", "First", "Second", "Third", "Fourth", "Fifth" };
            return map[number];
        }
        public static void Hit()
        {
            if (PlayerHand.Count < 5)
            {
                NewPokerDeck.DrawCardToHand(PlayerHand).DrawCard("Your" + NumberToOrder(PlayerHand.Count) + "Card");
            }
        }

        public static int CountHandValue(List<PokerCard> hand)
        {
            int total = 0;
            int numberOfAces = 0;

            foreach (var card in hand)
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
        public static void Stay()
        {
            GameEngine.AllGraphicElements["PokerCardBack"].DestroySelf();
            DealerHand[1].DrawCard("DealerSecondCard");

            // Dealer draw
            while (CountHandValue(DealerHand) <= 16 && DealerHand.Count < 5)
            {
                NewPokerDeck.DrawCardToHand(DealerHand).DrawCard("Dealer" + NumberToOrder(DealerHand.Count) + "Card");
            }

            GameEngine.AllGraphicElements["HitButton"].DestroySelf();
            GameEngine.AllGraphicElements["StayButtonHover"].DestroySelf();
            new Sprite2D("BackButton");
            if (CountHandValue(PlayerHand) > CountHandValue(DealerHand) && CountHandValue(PlayerHand) <= 21)
            {
                //win
                new Text("You Won!!!!", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
                Money += BetAmount;
            }
            else if (CountHandValue(PlayerHand) <= 21 && CountHandValue(DealerHand) > 21)
            {
                //win
                new Text("You Won!!!!", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
                Money += BetAmount;
            }
            else if (CountHandValue(PlayerHand) <= 21 && PlayerHand.Count == 5)
            {
                // Five Card
                new Text("5-card Charlie!!!!", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
                Money += BetAmount * 3;
            }
            else if (CountHandValue(PlayerHand) <= 21 && CountHandValue(PlayerHand) == CountHandValue(DealerHand))
            {
                //tie
                new Text("Tie", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
            }
            else
            {
                //lose
                new Text("You Lost :(", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
                Money -= BetAmount;
            }
            WriteMoney();

            // Put back the cards
            foreach (var card in DealerHand)
            {
                NewPokerDeck.Deck.Add(card);
            }
            foreach (var card in PlayerHand)
            {
                NewPokerDeck.Deck.Add(card);
            }
        }

        //writer
        public static void WriteMoney()
        {
            using (StreamWriter sw = new StreamWriter("Cache.txt"))
            {
                sw.WriteLine(Money);
            }
        }

        //read
        public static void ReadMoney()
        {
            if (File.Exists("Cache.txt"))
            {
                using (StreamReader SW = new StreamReader("Cache.txt"))
                {
                    Money = Int32.Parse(SW.ReadLine());
                }
            }
        }
    }
}
