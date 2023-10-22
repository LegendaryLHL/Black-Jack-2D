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
    class BlackJackGameLogic
    {
        public static int BetAmount = 0;
        public static int Money = 0;
        public static List<PokerCard> DealerHand;
        public static List<PokerCard> PlayerHand;
        private static string[] Numbers = { "Zeroth", "First", "Second", "Third", "Fourth", "Fifth" };

        public static List<PokerCard> Shoe = PokerCard.NewShoe();
        public static void Menu()
        {
            GameEngine.AllGraphicElements.Clear();
            new Button("ViewDeckCardsButton", "View Deck", Resolution.ScaledFont(40), Color.LightGreen, ViewDeckCards.ViewDeckCardsFunction);
            new Button("PlayButton", "Play", Resolution.ScaledFont(80), Color.LightGreen, Play);
            new Button("QuitButton", "Quit", Resolution.ScaledFont(80), Color.LightGreen, Application.Exit);
            new Button("ShopButton", "Shop", Resolution.ScaledFont(80), Color.LightGreen, Shop.ShopFunction);
        }
        public static void Play()
        {
            ReadMoney();
            if (Money < 50)
            {
                Money = 50;
            }
            //put bet
            GameEngine.AllGraphicElements.Clear();
            new Text("Place your bet:", Resolution.ScaledFont(100), Resolution.GetResolution("PlaceBet").Position, "placeBet");
            new Text($"Your Money: {Money}$", Resolution.ScaledFont(100), Resolution.GetResolution("YourMoney").Position, "yourMoney");
            int[] values = {0, 50, 100, 200, 500, 1000, 5000, 10000, 100000, 1000000};
            foreach (var value in values)
            {
                new Button(value.ToString(), value.ToString(), Resolution.ScaledFont(50), Color.LightGreen, () =>
                {
                    BetAmount = value;
                    BlackJack();
                });
            }
            new Button("BackButton", "Back", Resolution.ScaledFont(80), Color.LightGreen, Menu);
        }
        public static void BlackJack()
        {
            GameEngine.AllGraphicElements.Clear();
            PlayerHand = new List<PokerCard>();
            DealerHand = new List<PokerCard>();

            new Button("HitButton", "Hit", Resolution.ScaledFont(80), Color.LightGreen, Hit);
            new Button("StayButton", "Stay", Resolution.ScaledFont(80), Color.LightGreen, Stay);

            for (int i = 0; i < 2; i++)
            {
                PokerCard.DrawTopCard(Shoe, PlayerHand);
                PokerCard.DrawTopCard(Shoe, DealerHand);
            }

            DealerHand[0].DrawCard("DealerFirstCard");
            new Sprite(Resolution.GetResolution("DealerSecondCard"), "PokerCardBack");

            PlayerHand[0].DrawCard("YourFirstCard");
            PlayerHand[1].DrawCard("YourSecondCard");

            if (CountHandValue(PlayerHand) == 21){
                Won("BlackJack!!!", (int)Math.Round(BetAmount * 1.5));
            } 
        }

        public static void Hit()
        {
            if (PlayerHand.Count < 5)
            {
                PokerCard.DrawTopCard(Shoe, PlayerHand).DrawCard("Your" + Numbers[PlayerHand.Count] + "Card");
                if(CountHandValue(PlayerHand) > 21)
                {
                    Won("Bust :(", -BetAmount);
                }
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
                PokerCard.DrawTopCard(Shoe, DealerHand).DrawCard("Dealer" + Numbers[DealerHand.Count] + "Card");
            }

            if (CountHandValue(PlayerHand) > CountHandValue(DealerHand) && CountHandValue(PlayerHand) <= 21)
            {
                Won("You Won!!!!", BetAmount);
            }
            else if (CountHandValue(PlayerHand) <= 21 && CountHandValue(DealerHand) > 21)
            {
                Won("You Won!!!!", BetAmount);
            }
            else if (CountHandValue(PlayerHand) <= 21 && PlayerHand.Count == 5)
            {
                Won("5-card Charlie!!!!", BetAmount * 3);
            }
            else if (CountHandValue(PlayerHand) <= 21 && CountHandValue(PlayerHand) == CountHandValue(DealerHand))
            {
                Won("Tie", 0);
            }
            else
            {
                Won("You Lose :(", -BetAmount);
            }
        }

        private static void Won(string msg, int winAmount)
        {
            GameEngine.AllGraphicElements["HitButton"].DestroySelf();
            GameEngine.AllGraphicElements["StayButton"].DestroySelf();

            new Button("BackButton", "Back", Resolution.ScaledFont(80), Color.LightGreen, Menu);

            new Text(msg, Resolution.ScaledFont(100), Resolution.GetResolution("HitButton").Position);
            Money += winAmount;

            WriteMoney();

            // Put back the cards
            foreach (var card in DealerHand)
            {
                Shoe.Add(card);
            }
            foreach (var card in PlayerHand)
            {
                Shoe.Add(card);
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
