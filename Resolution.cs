using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    public class Resolution
    {
        public static Vector2 ScreenResolution = new Vector2(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
        public static Vector2 ViewDeckCardsButtonLocation;
        public static Vector2 ViewDeckCardsButtonScale;
        public static Vector2 ShuffleDeckButtonLocation;
        public static Vector2 ShuffleDeckButtonScale;
        public static Vector2 BackButtonLocation;
        public static Vector2 BackButtonScale;
        public static Vector2 RearrangeButtonLocation;
        public static Vector2 RearrangeButtonScale;
        public static Vector2 DrawAllCardsLocation;
        public static Vector2 DrawAllCardsScale;
        public static Vector2 PlayButtonLocation;
        public static Vector2 PlayButtonScale;
        public static Vector2 QuitButtonLocation;
        public static Vector2 QuitButtonScale;
        public static Vector2 PlayBlackJackCardsScale;
        public static Vector2 YourFirstCard;
        public static Vector2 YourSecondCard;
        public static Vector2 YourThirdCard;
        public static Vector2 YourFourthCard;
        public static Vector2 YourFifthCard;
        public static Vector2 DealerFirstCard;
        public static Vector2 DealerSecondCard;
        public static Vector2 DealerThirdCard;
        public static Vector2 DealerFourthCard;
        public static Vector2 DealerFifthCard;
        public static Vector2 HitButtonLocation;
        public static Vector2 HitButtonScale;
        public static Vector2 StayButtonLocation;
        public static Vector2 StayButtonScale;
        public static Vector2 PlaceBetLocation;
        public static Vector2 YourMoneyLocation;
        public static Vector2 AskForBetButtonsScale;
        public static Vector2 _0Location;
        public static Vector2 _50Location;
        public static Vector2 _100Location;
        public static Vector2 _200Location;
        public static Vector2 _500Location;
        public static Vector2 _1000Location;
        public static Vector2 _5000Location;
        public static Vector2 _10000Location;
        public static Vector2 _100000Location;
        public static Vector2 _1000000Location;
        public static Vector2 ShopButtonLocation;
        public static Vector2 ShopButtonScale;
        public static Vector2 UpgradeButtonLocation;
        public static Vector2 UpgradeButtonScale;
        //todo RearrangeButton, ShopButton, UpgradeButton 
        public static void MakeResolution()
        {
            if (ScreenResolution.x == 2048 && ScreenResolution.y == 1152)
            {
                ViewDeckCardsButtonLocation = new Vector2(850, 520);
                ViewDeckCardsButtonScale = new Vector2(200, 100);
                ShuffleDeckButtonLocation = new Vector2(350, 900);
                ShuffleDeckButtonScale = new Vector2(200, 100);
                BackButtonLocation = new Vector2(1300, 900);
                BackButtonScale = new Vector2(200, 100);
                RearrangeButtonLocation = new Vector2(845, 900);
                RearrangeButtonScale = new Vector2(200, 100);
                DrawAllCardsLocation = new Vector2(140, 200);
                DrawAllCardsScale = new Vector2(88, 124);
                PlayButtonLocation = new Vector2(400, 520);
                PlayButtonScale = new Vector2(200, 100);
                QuitButtonLocation = new Vector2(1300, 520);
                QuitButtonScale = new Vector2(200, 100);
                PlayBlackJackCardsScale = new Vector2(176, 248);
                DealerFirstCard = new Vector2(200, 100);
                DealerSecondCard = new Vector2(500, 100);
                DealerThirdCard = new Vector2(800, 100);
                DealerFourthCard = new Vector2(1100, 100);
                DealerFifthCard = new Vector2(1400, 100);
                YourFirstCard = new Vector2(200, 400);
                YourSecondCard = new Vector2(500, 400);
                YourThirdCard = new Vector2(800, 400);
                YourFourthCard = new Vector2(1100, 400);
                YourFifthCard = new Vector2(1400, 400);
                HitButtonLocation = new Vector2(350, 900);
                HitButtonScale = new Vector2(200, 100);
                StayButtonLocation = new Vector2(1250, 900);
                StayButtonScale = new Vector2(200, 100);
                PlaceBetLocation = new Vector2(200, 100);
                YourMoneyLocation = new Vector2(100, 1000);
                AskForBetButtonsScale = new Vector2(200, 100);
                _0Location = new Vector2(100, 520);
                _50Location = new Vector2(400, 520);
                _100Location = new Vector2(700, 520);
                _200Location = new Vector2(1000, 520);
                _500Location = new Vector2(1300, 520);
                _1000Location = new Vector2(1600, 520);
                _5000Location = new Vector2(100, 700);
                _10000Location = new Vector2(400, 700);
                _100000Location = new Vector2(700, 700);
                _1000000Location = new Vector2(1000, 700);
                ShopButtonLocation = new Vector2(630, 750);
                ShopButtonScale = new Vector2(200, 100);
                UpgradeButtonLocation = new Vector2(400, 520);
                UpgradeButtonScale = new Vector2(200, 100);
            }
            else if (ScreenResolution.x == 1366 && ScreenResolution.y == 768)
            {
                ViewDeckCardsButtonLocation = new Vector2(600, 384);
                ViewDeckCardsButtonScale = new Vector2(150, 75);
                ShuffleDeckButtonLocation = new Vector2(200, 630);
                ShuffleDeckButtonScale = new Vector2(150, 75);
                BackButtonLocation = new Vector2(900, 630);
                BackButtonScale = new Vector2(150, 75);
                DrawAllCardsLocation = new Vector2(99, 140);
                DrawAllCardsScale = new Vector2(88, 124);
                PlayButtonLocation = new Vector2(250, 384);
                PlayButtonScale = new Vector2(150, 75);
                QuitButtonLocation = new Vector2(950, 384);
                QuitButtonScale = new Vector2(150, 75);
                PlayBlackJackCardsScale = new Vector2(88, 124);
                DealerFirstCard = new Vector2(100, 75);
                DealerSecondCard = new Vector2(250, 75);
                DealerThirdCard = new Vector2(400, 75);
                DealerFourthCard = new Vector2(550, 75);
                DealerFifthCard = new Vector2(700, 75);
                YourFirstCard = new Vector2(100, 300);
                YourSecondCard = new Vector2(250, 300);
                YourThirdCard = new Vector2(400, 300);
                YourFourthCard = new Vector2(550, 300);
                YourFifthCard = new Vector2(700, 300);
                HitButtonLocation = new Vector2(200, 630);
                HitButtonScale = new Vector2(150, 75);
                StayButtonLocation = new Vector2(900, 630);
                StayButtonScale = new Vector2(150, 75);
                PlaceBetLocation = new Vector2(100, 50);
                YourMoneyLocation = new Vector2(50, 600);
                AskForBetButtonsScale = new Vector2(150, 75);
                _0Location = new Vector2(50, 250);
                _50Location = new Vector2(250, 250);
                _100Location = new Vector2(450, 250);
                _200Location = new Vector2(650, 250);
                _500Location = new Vector2(850, 250);
                _1000Location = new Vector2(1050, 250);
                _5000Location = new Vector2(50, 350);
                _10000Location = new Vector2(250, 350);
                _100000Location = new Vector2(450, 350);
                _1000000Location = new Vector2(650, 350);
            }
            else
            {
                ViewDeckCardsButtonLocation = new Vector2(850, 520);
                ViewDeckCardsButtonScale = new Vector2(200, 100);
                ShuffleDeckButtonLocation = new Vector2(350, 900);
                ShuffleDeckButtonScale = new Vector2(200, 100);
                BackButtonLocation = new Vector2(1250, 900);
                BackButtonScale = new Vector2(200, 100);
                DrawAllCardsLocation = new Vector2(140, 200);
                DrawAllCardsScale = new Vector2(88, 124);
                PlayButtonLocation = new Vector2(400, 520);
                PlayButtonScale = new Vector2(200, 100);
                QuitButtonLocation = new Vector2(1300, 520);
                QuitButtonScale = new Vector2(200, 100);
                PlayBlackJackCardsScale = new Vector2(176, 248);
                DealerFirstCard = new Vector2(200, 100);
                DealerSecondCard = new Vector2(500, 100);
                DealerThirdCard = new Vector2(800, 100);
                DealerFourthCard = new Vector2(1100, 100);
                DealerFifthCard = new Vector2(1400, 100);
                YourFirstCard = new Vector2(200, 400);
                YourSecondCard = new Vector2(500, 400);
                YourThirdCard = new Vector2(800, 400);
                YourFourthCard = new Vector2(1100, 400);
                YourFifthCard = new Vector2(1400, 400);
                HitButtonLocation = new Vector2(350, 900);
                HitButtonScale = new Vector2(200, 100);
                StayButtonLocation = new Vector2(1250, 900);
                StayButtonScale = new Vector2(200, 100);
                PlaceBetLocation = new Vector2(200, 100);
                YourMoneyLocation = new Vector2(100, 1000);
                AskForBetButtonsScale = new Vector2(200, 100);
                _0Location = new Vector2(100, 520);
                _50Location = new Vector2(400, 520);
                _100Location = new Vector2(700, 520);
                _200Location = new Vector2(1000, 520);
                _500Location = new Vector2(1300, 520);
                _1000Location = new Vector2(1600, 520);
                _5000Location = new Vector2(100, 700);
                _10000Location = new Vector2(400, 700);
                _100000Location = new Vector2(700, 700);
                _1000000Location = new Vector2(1000, 700);
            }

            //resolution COnstructor
            //if (ScreenResolution.x == 2048 && ScreenResolution.y == 1152)
            //{
            //    ViewDeckCardsButtonLocation = new Vector2(850, 520);
            //    ViewDeckCardsButtonScale = new Vector2(200, 100);
            //    ShuffleDeckButtonLocation = new Vector2(350, 900);
            //    ShuffleDeckButtonScale = new Vector2(200, 100);
            //    BackButtonLocation = new Vector2(1250, 900);
            //    BackButtonScale = new Vector2(200, 100);
            //    DrawAllCardsLocation = new Vector2(140, 200);
            //    DrawAllCardsScale = new Vector2(88, 124);
            //    PlayButtonLocation = new Vector2(400, 520);
            //    PlayButtonScale = new Vector2(200, 100);
            //    QuitButtonLocation = new Vector2(1300, 520);
            //    QuitButtonScale = new Vector2(200, 100);
            //    PlayBlackJackCardsScale = new Vector2(176, 248);
            //    DealerFirstCard = new Vector2(200, 100);
            //    DealerSecondCard = new Vector2(500, 100);
            //    DealerThirdCard = new Vector2(800, 100);
            //    DealerFourthCard = new Vector2(1100, 100);
            //    DealerFifthCard = new Vector2(1400, 100);
            //    YourFirstCard = new Vector2(200, 400);
            //    YourSecondCard = new Vector2(500, 400);
            //    YourThirdCard = new Vector2(800, 400);
            //    YourFourthCard = new Vector2(1100, 400);
            //    YourFifthCard = new Vector2(1400, 400);
            //    HitButtonLocation = new Vector2(350, 900);
            //    HitButtonScale = new Vector2(200, 100);
            //    StayButtonLocation = new Vector2(1250, 900);
            //    StayButtonScale = new Vector2(200, 100);
            //    PlaceBetLocation = new Vector2(200, 100);
            //    YourMoneyLocation = new Vector2(100, 1000);
            //    AskForBetButtonsScale = new Vector2(200, 100);
            //    _0Location = new Vector2(100, 520);
            //    _50Location = new Vector2(400, 520);
            //    _100Location = new Vector2(700, 520);
            //    _200Location = new Vector2(1000, 520);
            //    _500Location = new Vector2(1300, 520);
            //    _1000Location = new Vector2(1600, 520);
            //    _5000Location = new Vector2(100, 700);
            //    _10000Location = new Vector2(400, 700);
            //    _100000Location = new Vector2(700, 700);
            //    _1000000Location = new Vector2(1000, 700);
            //}

        }
        public static void ViewResolutionSimulation(int x, int y)
        {
            new Sprite2D(new Vector2(x, 1), new Vector2(1, 2000), "ViewDeckCardsButton", "ViewDeckCardsButton");
            new Sprite2D(new Vector2(1, y), new Vector2(2000, 1), "ViewDeckCardsButton", "ViewDeckCardsButton");
        }
    }
}
