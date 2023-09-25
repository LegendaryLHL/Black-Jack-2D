using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    class BlackJack2DGame : GameEngine
    {
        string ButtonHover = "";
        public static Sprite2D ViewDeckCardsButton;
        public static Sprite2D ViewDeckCardsButtonHover;
        public static Sprite2D PlayButton;
        public static Sprite2D PlayButtonHover;
        public static Sprite2D QuitButton;
        public static Sprite2D QuitButtonHover;
        public static Sprite2D ShopButton;
        public static Sprite2D ShopButtonHover;
        public BlackJack2DGame() : base(new Vector2(625, 512), ("Black Jack 2D")) { }

        public override void OnInitialise()
        {
            WindowStateSize = FormWindowState.Maximized;
        }
        public override void OnLoad()
        {
            Resolution.MakeResolution();
            BackgroundColour = Color.Green;
            Menu();
        }
        public override void OnDraw()
        {

        }

        public override void OnUpdate()
        {
            //Console.WriteLine("x: " + Cursor.Position.X + " y: " + Cursor.Position.Y);
        }

        public override void GetKeyDown(KeyEventArgs e)
        {

        }

        public override void GetKeyUp(KeyEventArgs e)
        {

        }

        public override void GetKeyPress(KeyPressEventArgs e)
        {

        }

        public override void GetMouseDown(MouseEventArgs e)
        {
        }

        public override void GetMouseUp(MouseEventArgs e)
        {
            //View Card Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("ViewDeckCardsButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.ViewDeckCardsFunction();
            }
            //Shuffle Cards Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("ShuffleDeckButtonHover"))
            {
                ViewDeckCards.ShuffleDeckFunction();
            }
            //Back Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("BackButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.BackFunction();
            }
            //Rearrange Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("RearrangeButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.RearrangeFunction();
            }
            //Play Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("PlayButtonHover"))
            {
                ButtonHover = "";
                BlackJack2DCode.PlayFunction();
            }
            //Quit Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("QuitButtonHover"))
            {
                ButtonHover = "";
                Application.Exit();
            }
            //Shop Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("ShopButtonHover"))
            {
                ButtonHover = "";
                Shop.ShopFunction();
            }
            //Upgrade Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("UpgradeButtonHover"))
            {
                ButtonHover = "";
                //upgrade function;
            }
            //Hit Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("HitButtonHover") && BlackJack2DCode.State == 1)
            {
                BlackJack2DCode.State = 2;
                BlackJack2DCode.State1Function();
            }
            else if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("HitButtonHover") && BlackJack2DCode.State == 2)
            {
                BlackJack2DCode.State = 3;
                BlackJack2DCode.State2Function();
            }
            else if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("HitButtonHover") && BlackJack2DCode.State == 3)
            {
                BlackJack2DCode.State = 4;
                BlackJack2DCode.State3Function();
            }
            //stay button up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("StayButtonHover"))
            {
                ButtonHover = "";
                BlackJack2DCode.StayFunction();
            }
            //_0 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_0Hover") && BlackJack2DCode.Money >= 0)
            {
                BlackJack2DCode.BetAmount = 0;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_50 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_50Hover") && BlackJack2DCode.Money >= 50)
            {
                BlackJack2DCode.BetAmount = 50;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_100 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_100Hover") && BlackJack2DCode.Money >= 100)
            {
                BlackJack2DCode.BetAmount = 100;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_200 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_200Hover") && BlackJack2DCode.Money >= 200)
            {
                BlackJack2DCode.BetAmount = 200;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_500
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_500Hover") && BlackJack2DCode.Money >= 500)
            {
                BlackJack2DCode.BetAmount = 500;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_1000
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_1000Hover") && BlackJack2DCode.Money >= 1000)
            {
                BlackJack2DCode.BetAmount = 1000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_5000
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_5000Hover") && BlackJack2DCode.Money >= 5000)
            {
                BlackJack2DCode.BetAmount = 5000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_10000
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_10000Hover") && BlackJack2DCode.Money >= 10000)
            {
                BlackJack2DCode.BetAmount = 10000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_100000
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_100000Hover") && BlackJack2DCode.Money >= 100000)
            {
                BlackJack2DCode.BetAmount = 100000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_1000000
            if (e.Button == MouseButtons.Left && Sprite2D.CursorIsOnStripe("_1000000Hover") && BlackJack2DCode.Money >= 1000000)
            {
                BlackJack2DCode.BetAmount = 1000000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }

            //Same code bcause need to hover
            CheakHover();//because after click becomes not hover so click cheak again lol
        }

        public override void GetMouseHover(EventArgs e)
        {

        }

        public override void GetMouseMove(EventArgs e)
        {
            CheakHover();
        }

        public static void Menu()
        {
            Sprite2D.ClearSprites();
            ViewDeckCardsButton = new Sprite2D("ViewDeckCardsButton");
            PlayButton = new Sprite2D("PlayButton");
            QuitButton = new Sprite2D("QuitButton");
            ShopButton = new Sprite2D("ShopButton");
        }

        public void CheakHover()
        {
            //View Deck Card button Hover
            if (Sprite2D.CursorIsOnStripe("ViewDeckCardsButton") && ButtonHover == "")
            {
                ButtonHover = "ViewDeckCardsButton";
                ViewDeckCardsButton.DestroySelf();
                ViewDeckCardsButtonHover = new Sprite2D("ViewDeckCardsButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("ViewDeckCardsButtonHover") && ButtonHover == "ViewDeckCardsButton")
            {
                ButtonHover = "";
                ViewDeckCardsButtonHover.DestroySelf();
                ViewDeckCardsButton = new Sprite2D("ViewDeckCardsButton");
            }
            //Shuffle Deck Button Hover
            if (Sprite2D.CursorIsOnStripe("ShuffleDeckButton") && ButtonHover == "")
            {
                ButtonHover = ButtonHover = "ShuffleDeckButton";
                ViewDeckCards.ShuffleDeckButton.DestroySelf();
                ViewDeckCards.ShuffleDeckButtonHover = new Sprite2D("ShuffleDeckButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("ShuffleDeckButtonHover") && ButtonHover == "ShuffleDeckButton")
            {
                ButtonHover = "";
                ViewDeckCards.ShuffleDeckButtonHover.DestroySelf();
                ViewDeckCards.ShuffleDeckButton = new Sprite2D("ShuffleDeckButton");
            }
            //Back Button Hover
            if (Sprite2D.CursorIsOnStripe("BackButton") && ButtonHover == "")
            {
                ButtonHover = "BackButton";
                ViewDeckCards.BackButton.DestroySelf();
                ViewDeckCards.BackButtonHover = new Sprite2D("BackButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("BackButtonHover") && ButtonHover == "BackButton")
            {
                ButtonHover = "";
                ViewDeckCards.BackButtonHover.DestroySelf();
                ViewDeckCards.BackButton = new Sprite2D("BackButton");
            }
            //Rearrange Button Hover
            if (Sprite2D.CursorIsOnStripe("RearrangeButton") && ButtonHover == "")
            {
                ButtonHover = "RearrangeButton";
                ViewDeckCards.RearrangeButton.DestroySelf();
                ViewDeckCards.RearrangeButtonHover = new Sprite2D("RearrangeButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("RearrangeButtonHover") && ButtonHover == "RearrangeButton")
            {
                ButtonHover = "";
                ViewDeckCards.RearrangeButtonHover.DestroySelf();
                ViewDeckCards.RearrangeButton = new Sprite2D("RearrangeButton");
            }
            //Play Button Hover
            if (Sprite2D.CursorIsOnStripe("PlayButton") && ButtonHover == "")
            {
                ButtonHover = "PlayButton";
                PlayButton.DestroySelf();
                PlayButtonHover = new Sprite2D("PlayButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("PlayButtonHover") && ButtonHover == "PlayButton")
            {
                ButtonHover = "";
                PlayButtonHover.DestroySelf();
                PlayButton = new Sprite2D("PlayButton");
            }
            //Quit Button Hover
            if (Sprite2D.CursorIsOnStripe("QuitButton") && ButtonHover == "")
            {
                ButtonHover = "QuitButton";
                QuitButton.DestroySelf();
                QuitButtonHover = new Sprite2D("QuitButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("QuitButtonHover") && ButtonHover == "QuitButton")
            {
                ButtonHover = "";
                QuitButtonHover.DestroySelf();
                QuitButton = new Sprite2D("QuitButton");
            }
            //Shop Button Hover
            if (Sprite2D.CursorIsOnStripe("ShopButton") && ButtonHover == "")
            {
                ButtonHover = "ShopButton";
                ShopButton.DestroySelf();
                ShopButtonHover = new Sprite2D("ShopButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("ShopButtonHover") && ButtonHover == "ShopButton")
            {
                ButtonHover = "";
                ShopButtonHover.DestroySelf();
                ShopButton = new Sprite2D("ShopButton");
            }
            //Upgrade Button Hover
            if (Sprite2D.CursorIsOnStripe("UpgradeButton") && ButtonHover == "")
            {
                    ButtonHover = "UpgradeButton";
                    Shop.UpgradeButton.DestroySelf();
                    Shop.UpgradeButtonHover = new Sprite2D("UpgradeButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("UpgradeButtonHover") && ButtonHover == "UpgradeButton")
            {
                ButtonHover = "";
                Shop.UpgradeButtonHover.DestroySelf();
                Shop.UpgradeButton = new Sprite2D("UpgradeButton");
            }
            //Hit Button Hover
            if (Sprite2D.CursorIsOnStripe("HitButton") && ButtonHover == "")
            {
                ButtonHover = "HitButton";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("HitButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("HitButtonHover") && ButtonHover == "HitButton")
            {
                ButtonHover = "";
                AllSprites["HitButtonHover"].DestroySelf();
                new Sprite2D("HitButton");
            }
            //Stay Button Hover
            if (Sprite2D.CursorIsOnStripe("StayButton") && ButtonHover == "")
            {
                ButtonHover = "StayButton";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("StayButtonHover");
            }
            if (!Sprite2D.CursorIsOnStripe("StayButtonHover") && ButtonHover == "StayButton")
            {
                ButtonHover = "";
                AllSprites["StayButtonHover"].DestroySelf();
                new Sprite2D("StayButton");
            }
            //_0 Hover
            if (Sprite2D.CursorIsOnStripe("_0") && ButtonHover == "")
            {
                ButtonHover = "_0";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_0Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_0Hover") && ButtonHover == "_0")
            {
                ButtonHover = "";
                AllSprites["_0Hover"].DestroySelf();
                new Sprite2D("_0");
            }
            //_50 Hover
            if (Sprite2D.CursorIsOnStripe("_50") && ButtonHover == "")
            {
                ButtonHover = "_50";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_50Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_50Hover") && ButtonHover == "_50")
            {
                ButtonHover = "";
                AllSprites["_50Hover"].DestroySelf();
                new Sprite2D("_50");
            }
            //_100 Hover
            if (Sprite2D.CursorIsOnStripe("_100") && ButtonHover == "")
            {
                ButtonHover = "_100";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_100Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_100Hover") && ButtonHover == "_100")
            {
                ButtonHover = "";
                AllSprites["_100Hover"].DestroySelf();
                new Sprite2D("_100");
            }
            //_200 Hover
            if (Sprite2D.CursorIsOnStripe("_200") && ButtonHover == "")
            {
                ButtonHover = "_200";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_200Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_200Hover") && ButtonHover == "_200")
            {
                ButtonHover = "";
                AllSprites["_200Hover"].DestroySelf();
                new Sprite2D("_200");
            }
            //_500 Hover
            if (Sprite2D.CursorIsOnStripe("_500") && ButtonHover == "")
            {
                ButtonHover = "_500";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_500Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_500Hover") && ButtonHover == "_500")
            {
                ButtonHover = "";
                AllSprites["_500Hover"].DestroySelf();
                new Sprite2D("_500");
            }
            //_1000 Hover
            if (Sprite2D.CursorIsOnStripe("_1000") && ButtonHover == "")
            {
               ButtonHover = "_1000";
                AllSprites[ButtonHover].DestroySelf();
               new Sprite2D("_1000Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_1000Hover") && ButtonHover == "_1000")
            {
                ButtonHover = "";
                AllSprites["_1000Hover"].DestroySelf();
                new Sprite2D("_1000");
            }
            //_5000 Hover
            if (Sprite2D.CursorIsOnStripe("_5000") && ButtonHover == "")
            {
                ButtonHover = "_5000";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_5000Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_5000Hover") && ButtonHover == "_5000")
            {
                ButtonHover = "";
                AllSprites["_5000Hover"].DestroySelf();
                new Sprite2D("_5000");
            }
            //_10000 hover
            if (Sprite2D.CursorIsOnStripe("_10000") && ButtonHover == "")
            {
                ButtonHover = "_10000";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_10000Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_10000Hover") && ButtonHover == "_10000")
            {
                ButtonHover = "";
                AllSprites["_10000Hover"].DestroySelf();
                new Sprite2D("_10000");
            }
            //_100000
            if (Sprite2D.CursorIsOnStripe("_100000") && ButtonHover == "")
            {
                ButtonHover = "_100000";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_100000Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_100000Hover") && ButtonHover == "_100000")
            {
                ButtonHover = "";
                AllSprites["_100000Hover"].DestroySelf();
                new Sprite2D("_100000");
            }
            //_1000000 Hover
            if (Sprite2D.CursorIsOnStripe("_1000000") && ButtonHover == "")
            {
                ButtonHover = "_1000000";
                AllSprites[ButtonHover].DestroySelf();
                new Sprite2D("_1000000Hover");
            }
            if (!Sprite2D.CursorIsOnStripe("_1000000Hover") && ButtonHover == "_1000000")
            {
                ButtonHover = "";
                AllSprites["_1000000Hover"].DestroySelf();
                new Sprite2D("_1000000");
            }
            
        }
    }
}
