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
            new Text("Place your bet:", new Font("Arial", 100, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.PlaceBetLocation);
            new Text($"Your Money: {Money}$", new Font("Arial", 50, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.YourMoneyLocation);
            _0 = new Sprite2D(Resolution._0Location, Resolution.AskForBetButtonsScale, "_0", "_0");
            _50 = new Sprite2D(Resolution._50Location, Resolution.AskForBetButtonsScale, "_50", "_50");
            _100 = new Sprite2D(Resolution._100Location, Resolution.AskForBetButtonsScale, "_100", "_100");
            _200 = new Sprite2D(Resolution._200Location, Resolution.AskForBetButtonsScale, "_200", "_200");
            _500 = new Sprite2D(Resolution._500Location, Resolution.AskForBetButtonsScale, "_500", "_500");
            _1000 = new Sprite2D(Resolution._1000Location, Resolution.AskForBetButtonsScale, "_1000", "_1000");
            _5000 = new Sprite2D(Resolution._5000Location, Resolution.AskForBetButtonsScale, "_5000", "_5000");
            _10000 = new Sprite2D(Resolution._10000Location, Resolution.AskForBetButtonsScale, "_10000", "_10000");
            _100000 = new Sprite2D(Resolution._100000Location, Resolution.AskForBetButtonsScale, "_100000", "_100000");
            _1000000 = new Sprite2D(Resolution._1000000Location, Resolution.AskForBetButtonsScale, "_1000000", "_1000000");
            ViewDeckCards.BackButton = new Sprite2D(Resolution.BackButtonLocation, Resolution.BackButtonScale, "BackButton", "BackButton");
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

            HitButton = new Sprite2D(Resolution.HitButtonLocation, Resolution.HitButtonScale, "HitButton", "HitButton");
            StayButton = new Sprite2D(Resolution.StayButtonLocation, Resolution.StayButtonScale, "StayButton", "StayButton");

            NewPokerDeck.Deck[0].DrawCard(Resolution.DealerFirstCard, Resolution.PlayBlackJackCardsScale);
            BackCard = new Sprite2D(Resolution.DealerSecondCard, Resolution.PlayBlackJackCardsScale, "PokerCardBack", "PokerCardBack");

            NewPokerDeck.Deck[5].DrawCard(Resolution.YourFirstCard, Resolution.PlayBlackJackCardsScale);
            NewPokerDeck.Deck[6].DrawCard(Resolution.YourSecondCard, Resolution.PlayBlackJackCardsScale);
        }

        public static void State1Function()
        {
            NewPokerDeck.Deck[7].DrawCard(Resolution.YourThirdCard, Resolution.PlayBlackJackCardsScale);
        }
        public static void State2Function()
        {
            NewPokerDeck.Deck[8].DrawCard(Resolution.YourFourthCard, Resolution.PlayBlackJackCardsScale);
        }
        public static void State3Function()
        {
            NewPokerDeck.Deck[9].DrawCard(Resolution.YourFifthCard, Resolution.PlayBlackJackCardsScale);
        }

        public static void StayFunction()
        {
            BackCard.DestroySelf();
            NewPokerDeck.Deck[1].DrawCard(Resolution.DealerSecondCard, Resolution.PlayBlackJackCardsScale);
            DealerTotal = NewPokerDeck.Deck[0].CardValue + NewPokerDeck.Deck[1].CardValue;
            DealerState = 1;
            if (DealerTotal < 17)
            {
                NewPokerDeck.Deck[2].DrawCard(Resolution.DealerThirdCard, Resolution.PlayBlackJackCardsScale);
                DealerTotal += NewPokerDeck.Deck[2].CardValue;
                DealerState = 2;
            }
            if (DealerTotal < 17)
            {
                NewPokerDeck.Deck[3].DrawCard(Resolution.DealerFourthCard, Resolution.PlayBlackJackCardsScale);
                DealerTotal += NewPokerDeck.Deck[3].CardValue;
                DealerState = 3;
            }
            if (DealerTotal < 17)
            {
                NewPokerDeck.Deck[4].DrawCard(Resolution.DealerFifthCard, Resolution.PlayBlackJackCardsScale);
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
            ViewDeckCards.BackButton = new Sprite2D(Resolution.BackButtonLocation, Resolution.BackButtonScale, "BackButton", "BackButton");
            if (YourTotal > DealerTotal && YourTotal <= 21)
            {
                //win
                new Text("You Won!!!!", new Font("Arial", Resolution.HitButtonScale.y, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.HitButtonLocation);
                Money += BetAmount;
            }
            else if (YourTotal <= 21 && DealerTotal > 21)
            {
                //win
                new Text("You Won!!!!", new Font("Arial", Resolution.HitButtonScale.y, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.HitButtonLocation);
                Money += BetAmount;
            }
            else if (YourTotal <= 21 && YourTotal == DealerTotal)
            {
                //tie
                new Text("Tie", new Font("Arial", Resolution.HitButtonScale.y, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.HitButtonLocation);
            }
            else
            {
                //lose
                new Text("You Lost :(", new Font("Arial", Resolution.HitButtonScale.y, FontStyle.Regular, GraphicsUnit.Pixel), Resolution.HitButtonLocation);
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
