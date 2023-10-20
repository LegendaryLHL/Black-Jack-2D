using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    class BlackJackEngine : GameEngine
    {
        string ButtonHover = "";
        public BlackJackEngine() : base(new Vector2(625, 512), ("Black Jack 2D")) { }

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
            // Handle button
            if (e.Button == MouseButtons.Left)
            {
                foreach (GraphicElement graphicElement in AllGraphicElements.Values)
                {
                    if (graphicElement is Button && graphicElement.IsCursorOnGraphicElement())
                    {
                        Button button = (Button)graphicElement;
                        button.RunAction();
                        break;
                    }
                }
            }
            //View Card Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("ViewDeckCardsButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.ViewDeckCardsFunction();
            }
            //Shuffle Cards Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("ShuffleDeckButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.ShuffleDeckFunction();
            }
            //Back Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("BackButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.BackFunction();
            }
            //Rearrange Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("RearrangeButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.RearrangeFunction();
            }
            //Play Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("PlayButtonHover"))
            {
                ButtonHover = "";
                BlackJackGameLogic.PlayFunction();
            }
            //Quit Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("QuitButtonHover"))
            {
                ButtonHover = "";
                Application.Exit();
            }
            //Shop Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("ShopButtonHover"))
            {
                ButtonHover = "";
                Shop.ShopFunction();
            }
            //Upgrade Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("UpgradeButtonHover"))
            {
                ButtonHover = "";
                //upgrade function;
            }
            //Hit Button Up
            /*if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("HitButtonHover"))
            {
                BlackJack2DCode.Hit();
            }*/
            //stay button up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("StayButtonHover"))
            {
                ButtonHover = "";
                BlackJackGameLogic.Stay();
            }
            //_0 Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_0Hover") && BlackJackGameLogic.Money >= 0)
            {
                BlackJackGameLogic.BetAmount = 0;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_50 Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_50Hover") && BlackJackGameLogic.Money >= 50)
            {
                BlackJackGameLogic.BetAmount = 50;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_100 Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_100Hover") && BlackJackGameLogic.Money >= 100)
            {
                BlackJackGameLogic.BetAmount = 100;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_200 Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_200Hover") && BlackJackGameLogic.Money >= 200)
            {
                BlackJackGameLogic.BetAmount = 200;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_500
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_500Hover") && BlackJackGameLogic.Money >= 500)
            {
                BlackJackGameLogic.BetAmount = 500;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_1000
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_1000Hover") && BlackJackGameLogic.Money >= 1000)
            {
                BlackJackGameLogic.BetAmount = 1000;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_5000
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_5000Hover") && BlackJackGameLogic.Money >= 5000)
            {
                BlackJackGameLogic.BetAmount = 5000;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_10000
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_10000Hover") && BlackJackGameLogic.Money >= 10000)
            {
                BlackJackGameLogic.BetAmount = 10000;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_100000
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_100000Hover") && BlackJackGameLogic.Money >= 100000)
            {
                BlackJackGameLogic.BetAmount = 100000;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
            }
            //_1000000
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("_1000000Hover") && BlackJackGameLogic.Money >= 1000000)
            {
                BlackJackGameLogic.BetAmount = 1000000;
                ButtonHover = "";
                BlackJackGameLogic.BlackJack();
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
            AllGraphicElements.Clear();
            new Sprite("ViewDeckCardsButton");
            new Sprite("PlayButton");
            new Sprite("QuitButton");
            new Sprite("ShopButton");
        }

        public void CheakHover()
        {
            // Handle button
            foreach (GraphicElement graphicElement in AllGraphicElements.Values)
            {
                // Not Hover
                if(graphicElement is Button)
                {
                    Button button = (Button)graphicElement;
                    if (graphicElement.IsCursorOnGraphicElement() && !button.IsHover)
                    {
                        button.IsHover = true;
                        break;
                    }
                    else if (!graphicElement.IsCursorOnGraphicElement() && button.IsHover)
                    {
                        button.IsHover = false;
                        break;
                    }
                }
            }
            //View Deck Card button Hover
            if (Sprite.IsCursorOnGraphicElement("ViewDeckCardsButton") && ButtonHover == "")
            {
                ButtonHover = "ViewDeckCardsButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("ViewDeckCardsButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("ViewDeckCardsButtonHover") && ButtonHover == "ViewDeckCardsButton")
            {
                ButtonHover = "";
                AllGraphicElements["ViewDeckCardsButtonHover"].DestroySelf();
                new Sprite("ViewDeckCardsButton");
            }
            //Shuffle Deck Button Hover
            if (Sprite.IsCursorOnGraphicElement("ShuffleDeckButton") && ButtonHover == "")
            {
                ButtonHover = "ShuffleDeckButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("ShuffleDeckButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("ShuffleDeckButtonHover") && ButtonHover == "ShuffleDeckButton")
            {
                ButtonHover = "";
                AllGraphicElements["ShuffleDeckButtonHover"].DestroySelf();
                new Sprite("ShuffleDeckButton");
            }
            //Back Button Hover
            if (Sprite.IsCursorOnGraphicElement("BackButton") && ButtonHover == "")
            {
                ButtonHover = "BackButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("BackButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("BackButtonHover") && ButtonHover == "BackButton")
            {
                ButtonHover = "";
                AllGraphicElements["BackButtonHover"].DestroySelf();
                new Sprite("BackButton");
            }
            //Rearrange Button Hover
            if (Sprite.IsCursorOnGraphicElement("RearrangeButton") && ButtonHover == "")
            {
                ButtonHover = "RearrangeButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("RearrangeButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("RearrangeButtonHover") && ButtonHover == "RearrangeButton")
            {
                ButtonHover = "";
                AllGraphicElements["RearrangeButtonHover"].DestroySelf();
                new Sprite("RearrangeButton");
            }
            //Play Button Hover
            if (Sprite.IsCursorOnGraphicElement("PlayButton") && ButtonHover == "")
            {
                ButtonHover = "PlayButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("PlayButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("PlayButtonHover") && ButtonHover == "PlayButton")
            {
                ButtonHover = "";
                AllGraphicElements["PlayButtonHover"].DestroySelf();
                new Sprite("PlayButton");
            }
            //Quit Button Hover
            if (Sprite.IsCursorOnGraphicElement("QuitButton") && ButtonHover == "")
            {
                ButtonHover = "QuitButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("QuitButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("QuitButtonHover") && ButtonHover == "QuitButton")
            {
                ButtonHover = "";
                AllGraphicElements["QuitButtonHover"].DestroySelf();
                new Sprite("QuitButton");
            }
            //Shop Button Hover
            if (Sprite.IsCursorOnGraphicElement("ShopButton") && ButtonHover == "")
            {
                ButtonHover = "ShopButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("ShopButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("ShopButtonHover") && ButtonHover == "ShopButton")
            {
                ButtonHover = "";
                AllGraphicElements["ShopButtonHover"].DestroySelf();
                new Sprite("ShopButton");
            }
            //Upgrade Button Hover
            if (Sprite.IsCursorOnGraphicElement("UpgradeButton") && ButtonHover == "")
            {
                ButtonHover = "UpgradeButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("UpgradeButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("UpgradeButtonHover") && ButtonHover == "UpgradeButton")
            {
                ButtonHover = "";
                AllGraphicElements["UpgradeButtonHover"].DestroySelf();
                new Sprite("UpgradeButton");
            }
            //Hit Button Hover
            /*if (Sprite2D.IsCursorOnGraphicElement("HitButton") && ButtonHover == "")
            {
                ButtonHover = "HitButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("HitButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("HitButtonHover") && ButtonHover == "HitButton")
            {
                ButtonHover = "";
                AllGraphicElements["HitButtonHover"].DestroySelf();
                new Sprite2D("HitButton");
            }*/
            //Stay Button Hover
            if (Sprite.IsCursorOnGraphicElement("StayButton") && ButtonHover == "")
            {
                ButtonHover = "StayButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("StayButtonHover");
            }
            if (!Sprite.IsCursorOnGraphicElement("StayButtonHover") && ButtonHover == "StayButton")
            {
                ButtonHover = "";
                AllGraphicElements["StayButtonHover"].DestroySelf();
                new Sprite("StayButton");
            }
            //_0 Hover
            if (Sprite.IsCursorOnGraphicElement("_0") && ButtonHover == "")
            {
                ButtonHover = "_0";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_0Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_0Hover") && ButtonHover == "_0")
            {
                ButtonHover = "";
                AllGraphicElements["_0Hover"].DestroySelf();
                new Sprite("_0");
            }
            //_50 Hover
            if (Sprite.IsCursorOnGraphicElement("_50") && ButtonHover == "")
            {
                ButtonHover = "_50";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_50Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_50Hover") && ButtonHover == "_50")
            {
                ButtonHover = "";
                AllGraphicElements["_50Hover"].DestroySelf();
                new Sprite("_50");
            }
            //_100 Hover
            if (Sprite.IsCursorOnGraphicElement("_100") && ButtonHover == "")
            {
                ButtonHover = "_100";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_100Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_100Hover") && ButtonHover == "_100")
            {
                ButtonHover = "";
                AllGraphicElements["_100Hover"].DestroySelf();
                new Sprite("_100");
            }
            //_200 Hover
            if (Sprite.IsCursorOnGraphicElement("_200") && ButtonHover == "")
            {
                ButtonHover = "_200";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_200Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_200Hover") && ButtonHover == "_200")
            {
                ButtonHover = "";
                AllGraphicElements["_200Hover"].DestroySelf();
                new Sprite("_200");
            }
            //_500 Hover
            if (Sprite.IsCursorOnGraphicElement("_500") && ButtonHover == "")
            {
                ButtonHover = "_500";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_500Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_500Hover") && ButtonHover == "_500")
            {
                ButtonHover = "";
                AllGraphicElements["_500Hover"].DestroySelf();
                new Sprite("_500");
            }
            //_1000 Hover
            if (Sprite.IsCursorOnGraphicElement("_1000") && ButtonHover == "")
            {
                ButtonHover = "_1000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_1000Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_1000Hover") && ButtonHover == "_1000")
            {
                ButtonHover = "";
                AllGraphicElements["_1000Hover"].DestroySelf();
                new Sprite("_1000");
            }
            //_5000 Hover
            if (Sprite.IsCursorOnGraphicElement("_5000") && ButtonHover == "")
            {
                ButtonHover = "_5000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_5000Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_5000Hover") && ButtonHover == "_5000")
            {
                ButtonHover = "";
                AllGraphicElements["_5000Hover"].DestroySelf();
                new Sprite("_5000");
            }
            //_10000 hover
            if (Sprite.IsCursorOnGraphicElement("_10000") && ButtonHover == "")
            {
                ButtonHover = "_10000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_10000Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_10000Hover") && ButtonHover == "_10000")
            {
                ButtonHover = "";
                AllGraphicElements["_10000Hover"].DestroySelf();
                new Sprite("_10000");
            }
            //_100000
            if (Sprite.IsCursorOnGraphicElement("_100000") && ButtonHover == "")
            {
                ButtonHover = "_100000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_100000Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_100000Hover") && ButtonHover == "_100000")
            {
                ButtonHover = "";
                AllGraphicElements["_100000Hover"].DestroySelf();
                new Sprite("_100000");
            }
            //_1000000 Hover
            if (Sprite.IsCursorOnGraphicElement("_1000000") && ButtonHover == "")
            {
                ButtonHover = "_1000000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite("_1000000Hover");
            }
            if (!Sprite.IsCursorOnGraphicElement("_1000000Hover") && ButtonHover == "_1000000")
            {
                ButtonHover = "";
                AllGraphicElements["_1000000Hover"].DestroySelf();
                new Sprite("_1000000");
            }

        }

        public override void WindowResize(EventArgs e)
        {
            //Resolution.ScreenResolution = new Vector2(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // New Instance of all resolutions
            //Resolution.Resolutions = new Dictionary<string, Resolution>();
            //Resolution.MakeResolution();

            // Reinitalise resolution of all sprite
            /*foreach (Sprite2D sprite in AllSprites.Values)
            {
                if (sprite.Tag != null)
                {
                    Console.Write(sprite.Tag);
                    sprite.Scale = Resolution.Resolutions[sprite.Tag].Scale;
                    sprite.Position = Resolution.Resolutions[sprite.Tag].Position;
                }
            }*/
        }
    }
}
