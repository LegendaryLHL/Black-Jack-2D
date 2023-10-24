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
        private static bool FirstTime = true;
        public static int BetAmount = 0;
        public static int Money = 0;
        private static PokerHand DealerHand = new PokerHand(Resolution.GetResolution("DealerHand"), "DealerHand");
        private static PokerHand PlayerHand = new PokerHand(Resolution.GetResolution("PlayerHand"), "PlayerHand");
        private static PokerHand DiscardPile = new PokerHand(Resolution.GetResolution("YourFirstCard"), "DiscardPile");
        private static PokerHand Shoe = new PokerHand(Resolution.GetResolution("YourFiftCard"), "Shoe");
        public static void Menu()
        {
            GameEngine.AllGraphicElements.Clear();
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
                    if (Money >= value)
                    {
                        BetAmount = value;
                        BlackJack();
                    }
                });
            }
            new Button("BackButton", "Back", Resolution.ScaledFont(80), Color.LightGreen, Menu);
        }
        public static void BlackJack()
        {
            GameEngine.AllGraphicElements.Clear();
            if (FirstTime)
            {
                Shoe.Cards = PokerCard.NewShoe();
                PokerCard.ShuffleHand(Shoe);
                FirstTime = false;
            }

            new Button("HitButton", "Hit", Resolution.ScaledFont(80), Color.LightGreen, Hit);
            new Button("StayButton", "Stay", Resolution.ScaledFont(80), Color.LightGreen, Stay);

            for (int i = 0; i < 2; i++)
            {
                PlayerHand.ReciveTopCard(Shoe, true);
                if(i != 1)
                {
                    DealerHand.ReciveTopCard(Shoe, true);
                }
                else
                {
                    DealerHand.ReciveTopCard(Shoe, true);
                    DealerHand.FlipCard(1);
                }
            }

            if (PlayerHand.CountHandValue() == 21)
            {
                DealerHand.FlipCard(1);
                Won("BlackJack!!!", (int)Math.Round(BetAmount * 1.5));
            }
            else if (DealerHand.CountHandValue() == 21)
            {
                DealerHand.FlipCard(1);
                Won("Dealer BlackJack", -BetAmount);
            }
        }

        public static void Hit()
        { 
            PlayerHand.ReciveTopCard(Shoe, true);
            if(PlayerHand.CountHandValue() > 21)
            {
                DealerHand.FlipCard(1);
                Won("Bust :(", -BetAmount);
            }
            
        }
        public static void Stay()
        {
            DealerHand.FlipCard(1);

            // Dealer draw
            while (DealerHand.CountHandValue() <= 16)
            {
                DealerHand.ReciveTopCard(Shoe, true);
            }

            if (PlayerHand.CountHandValue() > DealerHand.CountHandValue() && PlayerHand.CountHandValue() <= 21)
            {
                Won("You Won!!!!", BetAmount);
            }
            else if (PlayerHand.CountHandValue() <= 21 && DealerHand.CountHandValue() > 21)
            {
                Won("You Won!!!!", BetAmount);
            }
            else if (PlayerHand.CountHandValue() <= 21 && PlayerHand.Cards.Count == 5)
            {
                Won("5-card Charlie!!!!", BetAmount * 3);
            }
            else if (PlayerHand.CountHandValue() <= 21 && PlayerHand.CountHandValue() == DealerHand.CountHandValue())
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

            // Discard the cards
            int numberOfCardOfDealerHand = DealerHand.Cards.Count;
            int numberOfCardOfPlayerHand = PlayerHand.Cards.Count;
            for (int i = 0; i < numberOfCardOfDealerHand; i++)
            {
                DiscardPile.ReciveTopCard(DealerHand);
            }
            for (int i = 0; i < numberOfCardOfPlayerHand; i++)
            {
                DiscardPile.ReciveTopCard(PlayerHand);
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
