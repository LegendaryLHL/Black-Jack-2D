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
        public static Sprite2D HitButton;
        public static Sprite2D HitButtonHover;
        public static Sprite2D StayButton;
        public static Sprite2D StayButtonHover;
        public static Sprite2D _0;
        public static Sprite2D _50;
        public static Sprite2D _100;
        public static Sprite2D _200;
        public static Sprite2D _500;
        public static Sprite2D _1000;
        public static Sprite2D _5000;
        public static Sprite2D _10000;
        public static Sprite2D _100000;
        public static Sprite2D _1000000;
        public static Sprite2D _0Hover;
        public static Sprite2D _50Hover;
        public static Sprite2D _100Hover;
        public static Sprite2D _200Hover;
        public static Sprite2D _500Hover;
        public static Sprite2D _1000Hover;
        public static Sprite2D _5000Hover;
        public static Sprite2D _10000Hover;
        public static Sprite2D _100000Hover;
        public static Sprite2D _1000000Hover;
        public static Sprite2D BackCard;

        public static int BetAmount = 0;
        public static int Money = 0;
        public static int State = 1;
        public static int DealerTotal = 0;
        public static int YourTotal = 0;
        public static int DealerState = 0;

        public static PokerDeck NewPokerDeck = new PokerDeck();
        public static void PlayFunction()
        {
            ReadMoney();
            if (Money < 50)
            {
                Money = 50;
            }
            //put bet
            Sprite2D.ClearSprites();
            new Text("Place your bet:", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("PlaceBet").Position);
            new Text($"Your Money: {Money}$", new Font("Arial", 50, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("YourMoney").Position);
            _0 = new Sprite2D("_0");
            _50 = new Sprite2D("_50");
            _100 = new Sprite2D("_100");
            _200 = new Sprite2D("_200");
            _500 = new Sprite2D("_500");
            _1000 = new Sprite2D("_1000");
            _5000 = new Sprite2D("_5000");
            _10000 = new Sprite2D("_10000");
            _100000 = new Sprite2D("_100000");
            _1000000 = new Sprite2D("_1000000");
            ViewDeckCards.BackButton = new Sprite2D("BackButton");
        }
        public static void BlackJack()
        {
            Sprite2D.ClearSprites();
            for (int i = 0; i < DealerState; i++)
            {
                PokerCard Temp = NewPokerDeck.Deck[i];
                NewPokerDeck.Deck.Remove(NewPokerDeck.Deck[i]);
                NewPokerDeck.Deck.Add(Temp);
            }
            for (int i = 5; i < State+5; i++)
            {
                PokerCard Temp = NewPokerDeck.Deck[i];
                NewPokerDeck.Deck.Remove(NewPokerDeck.Deck[i]);
                NewPokerDeck.Deck.Add(Temp);
            }

            HitButton = new Sprite2D("HitButton");
            StayButton = new Sprite2D("StayButton");

            NewPokerDeck.Deck[0].DrawCard("DealerFirstCard");
            BackCard = new Sprite2D(Resolution.GetResolution("DealerSecondCard"), "PokerCardBack");

            NewPokerDeck.Deck[5].DrawCard("YourFirstCard");
            NewPokerDeck.Deck[6].DrawCard("YourSecondCard");
        }

        public static void State1Function()
        {
            NewPokerDeck.Deck[7].DrawCard("YourThirdCard");
        }
        public static void State2Function()
        {
            NewPokerDeck.Deck[8].DrawCard("YourFourthCard");
        }
        public static void State3Function()
        {
            NewPokerDeck.Deck[9].DrawCard("YourFifthCard");
        }

        public static void StayFunction()
        {
            BackCard.DestroySelf();
            NewPokerDeck.Deck[1].DrawCard("DealerSecondCard");
            DealerTotal = NewPokerDeck.Deck[0].CardValue + NewPokerDeck.Deck[1].CardValue;
            DealerState = 1;
            if (DealerTotal < 17)
            {
                NewPokerDeck.Deck[2].DrawCard("DealerThirdCard");
                DealerTotal += NewPokerDeck.Deck[2].CardValue;
                DealerState = 2;
            }
            if (DealerTotal < 17)
            {
                NewPokerDeck.Deck[3].DrawCard("DealerFourthCard");
                DealerTotal += NewPokerDeck.Deck[3].CardValue;
                DealerState = 3;
            }
            if (DealerTotal < 17)
            {
                NewPokerDeck.Deck[4].DrawCard("DealerFifthCard");
                DealerTotal += NewPokerDeck.Deck[4].CardValue;
                DealerState = 4;
            }
            if (DealerTotal > 21)
            {
                if (NewPokerDeck.Deck[0].IsAce)
                {
                    DealerTotal = -10;
                }
                else if (NewPokerDeck.Deck[1].IsAce)
                {
                    DealerTotal = -10;
                }
                else if (NewPokerDeck.Deck[2].IsAce)
                {
                    DealerTotal = -10;
                }
                else if (NewPokerDeck.Deck[3].IsAce)
                {
                    DealerTotal = -10;
                }
                else if (NewPokerDeck.Deck[4].IsAce)
                {
                    DealerTotal = -10;
                }
            }

            if (State == 1)
            {
                YourTotal = NewPokerDeck.Deck[5].CardValue + NewPokerDeck.Deck[6].CardValue;
            }
            if (State == 2)
            {
                YourTotal = NewPokerDeck.Deck[5].CardValue + NewPokerDeck.Deck[6].CardValue + NewPokerDeck.Deck[7].CardValue;
            }
            if (State == 3)
            {
                YourTotal = NewPokerDeck.Deck[5].CardValue + NewPokerDeck.Deck[6].CardValue + NewPokerDeck.Deck[7].CardValue + NewPokerDeck.Deck[8].CardValue;
            }
            if (State == 4)
            {
                YourTotal = NewPokerDeck.Deck[5].CardValue + NewPokerDeck.Deck[6].CardValue + NewPokerDeck.Deck[7].CardValue + NewPokerDeck.Deck[8].CardValue + NewPokerDeck.Deck[9].CardValue;
            }

            if (YourTotal > 21)
            {
                if (NewPokerDeck.Deck[5].IsAce)
                {
                    YourTotal = -10;
                }
                else if (NewPokerDeck.Deck[6].IsAce)
                {
                    YourTotal = -10;
                }
                else if (NewPokerDeck.Deck[7].IsAce)
                {
                    YourTotal = -10;
                }
                else if (NewPokerDeck.Deck[8].IsAce)
                {
                    YourTotal = -10;
                }
                else if (NewPokerDeck.Deck[9].IsAce)
                {
                    YourTotal = -10;
                }
            }

            HitButton.DestroySelf();
            StayButtonHover.DestroySelf();
            ViewDeckCards.BackButton = new Sprite2D("BackButton");
            if (YourTotal > DealerTotal && YourTotal <= 21)
            {
                //win
                new Text("You Won!!!!", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
                Money += BetAmount;
            }
            else if (YourTotal <= 21 && DealerTotal > 21)
            {
                //win
                new Text("You Won!!!!", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.GetResolution("HitButton").Position);
                Money += BetAmount;
            }
            else if (YourTotal <= 21 && YourTotal == DealerTotal)
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
            State = 1;
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
