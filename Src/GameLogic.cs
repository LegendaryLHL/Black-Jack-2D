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
    class GameLogic
    {
        private static bool FirstTime = true;
        public static int BetAmount = 0;
        public static int Money = 0;
        private static PokerHand DealerHand = new PokerHand(Resolution.Resolutions["DealerHand"], "DealerHand");
        private static PokerHand PlayerHand = new PokerHand(Resolution.Resolutions["PlayerHand"], "PlayerHand");
        private static PokerHand DiscardPile = new PokerHand(Resolution.Resolutions["DiscardPile"], "DiscardPile");
        private static PokerHand Shoe = new PokerHand(Resolution.Resolutions["Shoe"], "Shoe");
        public static void Menu()
        {
            GameEngine.AllGraphicElements.Clear();
            new Button("Play", 80, Color.LightGreen, Play, "PlayButton");
            new Button("Quit", 80, Color.LightGreen, Application.Exit, "QuitButton");
            new Button("Shop", 80, Color.LightGreen, Shop.ShopFunction, "ShopButton");
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
            new Text("Place your bet:", 100, "PlaceBet");
            new Text($"Your Money: {Money}$", 100, "YourMoney");
            int[] values = {0, 50, 100, 200, 500, 1000, 5000, 10000, 100000, 1000000};
            foreach (var value in values)
            {
                new Button(value.ToString(), 50, Color.LightGreen, () =>
                {
                    if (Money >= value)
                    {
                        BetAmount = value;
                        BlackJack();
                    }
                }, value.ToString());
            }
            new Button("Back", 80, Color.LightGreen, Menu, "BackButton");
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

            new Button("Hit", 80, Color.LightGreen, Hit, "HitButton");
            new Button("Stay", 80, Color.LightGreen, Stay, "StayButton");

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

            new Button("Back", 80, Color.LightGreen, Menu, "BackButton");

            new Text(msg, 100, "HitButton");
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

        // Serialize data to a binary file
        public static void WriteMoney()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("Cache.dat", FileMode.Create)))
            {
                writer.Write(Money);
            }
        }

        // Deserialize data from a binary file
        public static void ReadMoney()
        {
            if (File.Exists("Cache.dat"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open("Cache.dat", FileMode.Open)))
                {
                    Money = reader.ReadInt32();
                }
            }
        }
    }
}
