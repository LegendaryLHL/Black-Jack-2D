using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    class BlackJack2DGame : GameEngine
    {
        string ButtonHover = "";
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
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("ViewDeckCardsButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.ViewDeckCardsFunction();
            }
            //Shuffle Cards Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("ShuffleDeckButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.ShuffleDeckFunction();
            }
            //Back Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("BackButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.BackFunction();
            }
            //Rearrange Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("RearrangeButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.RearrangeFunction();
            }
            //Play Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("PlayButtonHover"))
            {
                ButtonHover = "";
                BlackJack2DCode.PlayFunction();
            }
            //Quit Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("QuitButtonHover"))
            {
                ButtonHover = "";
                Application.Exit();
            }
            //Shop Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("ShopButtonHover"))
            {
                ButtonHover = "";
                Shop.ShopFunction();
            }
            //Upgrade Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("UpgradeButtonHover"))
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
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("StayButtonHover"))
            {
                ButtonHover = "";
                BlackJack2DCode.Stay();
            }
            //_0 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_0Hover") && BlackJack2DCode.Money >= 0)
            {
                BlackJack2DCode.BetAmount = 0;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_50 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_50Hover") && BlackJack2DCode.Money >= 50)
            {
                BlackJack2DCode.BetAmount = 50;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_100 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_100Hover") && BlackJack2DCode.Money >= 100)
            {
                BlackJack2DCode.BetAmount = 100;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_200 Button Up
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_200Hover") && BlackJack2DCode.Money >= 200)
            {
                BlackJack2DCode.BetAmount = 200;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_500
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_500Hover") && BlackJack2DCode.Money >= 500)
            {
                BlackJack2DCode.BetAmount = 500;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_1000
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_1000Hover") && BlackJack2DCode.Money >= 1000)
            {
                BlackJack2DCode.BetAmount = 1000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_5000
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_5000Hover") && BlackJack2DCode.Money >= 5000)
            {
                BlackJack2DCode.BetAmount = 5000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_10000
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_10000Hover") && BlackJack2DCode.Money >= 10000)
            {
                BlackJack2DCode.BetAmount = 10000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_100000
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_100000Hover") && BlackJack2DCode.Money >= 100000)
            {
                BlackJack2DCode.BetAmount = 100000;
                ButtonHover = "";
                BlackJack2DCode.BlackJack();
            }
            //_1000000
            if (e.Button == MouseButtons.Left && Sprite2D.IsCursorOnGraphicElement("_1000000Hover") && BlackJack2DCode.Money >= 1000000)
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
            AllGraphicElements.Clear();
            new Sprite2D("ViewDeckCardsButton");
            new Sprite2D("PlayButton");
            new Sprite2D("QuitButton");
            new Sprite2D("ShopButton");
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
            if (Sprite2D.IsCursorOnGraphicElement("ViewDeckCardsButton") && ButtonHover == "")
            {
                ButtonHover = "ViewDeckCardsButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("ViewDeckCardsButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("ViewDeckCardsButtonHover") && ButtonHover == "ViewDeckCardsButton")
            {
                ButtonHover = "";
                AllGraphicElements["ViewDeckCardsButtonHover"].DestroySelf();
                new Sprite2D("ViewDeckCardsButton");
            }
            //Shuffle Deck Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("ShuffleDeckButton") && ButtonHover == "")
            {
                ButtonHover = "ShuffleDeckButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("ShuffleDeckButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("ShuffleDeckButtonHover") && ButtonHover == "ShuffleDeckButton")
            {
                ButtonHover = "";
                AllGraphicElements["ShuffleDeckButtonHover"].DestroySelf();
                new Sprite2D("ShuffleDeckButton");
            }
            //Back Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("BackButton") && ButtonHover == "")
            {
                ButtonHover = "BackButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("BackButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("BackButtonHover") && ButtonHover == "BackButton")
            {
                ButtonHover = "";
                AllGraphicElements["BackButtonHover"].DestroySelf();
                new Sprite2D("BackButton");
            }
            //Rearrange Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("RearrangeButton") && ButtonHover == "")
            {
                ButtonHover = "RearrangeButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("RearrangeButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("RearrangeButtonHover") && ButtonHover == "RearrangeButton")
            {
                ButtonHover = "";
                AllGraphicElements["RearrangeButtonHover"].DestroySelf();
                new Sprite2D("RearrangeButton");
            }
            //Play Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("PlayButton") && ButtonHover == "")
            {
                ButtonHover = "PlayButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("PlayButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("PlayButtonHover") && ButtonHover == "PlayButton")
            {
                ButtonHover = "";
                AllGraphicElements["PlayButtonHover"].DestroySelf();
                new Sprite2D("PlayButton");
            }
            //Quit Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("QuitButton") && ButtonHover == "")
            {
                ButtonHover = "QuitButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("QuitButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("QuitButtonHover") && ButtonHover == "QuitButton")
            {
                ButtonHover = "";
                AllGraphicElements["QuitButtonHover"].DestroySelf();
                new Sprite2D("QuitButton");
            }
            //Shop Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("ShopButton") && ButtonHover == "")
            {
                ButtonHover = "ShopButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("ShopButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("ShopButtonHover") && ButtonHover == "ShopButton")
            {
                ButtonHover = "";
                AllGraphicElements["ShopButtonHover"].DestroySelf();
                new Sprite2D("ShopButton");
            }
            //Upgrade Button Hover
            if (Sprite2D.IsCursorOnGraphicElement("UpgradeButton") && ButtonHover == "")
            {
                ButtonHover = "UpgradeButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("UpgradeButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("UpgradeButtonHover") && ButtonHover == "UpgradeButton")
            {
                ButtonHover = "";
                AllGraphicElements["UpgradeButtonHover"].DestroySelf();
                new Sprite2D("UpgradeButton");
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
            if (Sprite2D.IsCursorOnGraphicElement("StayButton") && ButtonHover == "")
            {
                ButtonHover = "StayButton";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("StayButtonHover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("StayButtonHover") && ButtonHover == "StayButton")
            {
                ButtonHover = "";
                AllGraphicElements["StayButtonHover"].DestroySelf();
                new Sprite2D("StayButton");
            }
            //_0 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_0") && ButtonHover == "")
            {
                ButtonHover = "_0";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_0Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_0Hover") && ButtonHover == "_0")
            {
                ButtonHover = "";
                AllGraphicElements["_0Hover"].DestroySelf();
                new Sprite2D("_0");
            }
            //_50 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_50") && ButtonHover == "")
            {
                ButtonHover = "_50";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_50Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_50Hover") && ButtonHover == "_50")
            {
                ButtonHover = "";
                AllGraphicElements["_50Hover"].DestroySelf();
                new Sprite2D("_50");
            }
            //_100 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_100") && ButtonHover == "")
            {
                ButtonHover = "_100";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_100Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_100Hover") && ButtonHover == "_100")
            {
                ButtonHover = "";
                AllGraphicElements["_100Hover"].DestroySelf();
                new Sprite2D("_100");
            }
            //_200 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_200") && ButtonHover == "")
            {
                ButtonHover = "_200";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_200Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_200Hover") && ButtonHover == "_200")
            {
                ButtonHover = "";
                AllGraphicElements["_200Hover"].DestroySelf();
                new Sprite2D("_200");
            }
            //_500 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_500") && ButtonHover == "")
            {
                ButtonHover = "_500";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_500Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_500Hover") && ButtonHover == "_500")
            {
                ButtonHover = "";
                AllGraphicElements["_500Hover"].DestroySelf();
                new Sprite2D("_500");
            }
            //_1000 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_1000") && ButtonHover == "")
            {
                ButtonHover = "_1000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_1000Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_1000Hover") && ButtonHover == "_1000")
            {
                ButtonHover = "";
                AllGraphicElements["_1000Hover"].DestroySelf();
                new Sprite2D("_1000");
            }
            //_5000 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_5000") && ButtonHover == "")
            {
                ButtonHover = "_5000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_5000Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_5000Hover") && ButtonHover == "_5000")
            {
                ButtonHover = "";
                AllGraphicElements["_5000Hover"].DestroySelf();
                new Sprite2D("_5000");
            }
            //_10000 hover
            if (Sprite2D.IsCursorOnGraphicElement("_10000") && ButtonHover == "")
            {
                ButtonHover = "_10000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_10000Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_10000Hover") && ButtonHover == "_10000")
            {
                ButtonHover = "";
                AllGraphicElements["_10000Hover"].DestroySelf();
                new Sprite2D("_10000");
            }
            //_100000
            if (Sprite2D.IsCursorOnGraphicElement("_100000") && ButtonHover == "")
            {
                ButtonHover = "_100000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_100000Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_100000Hover") && ButtonHover == "_100000")
            {
                ButtonHover = "";
                AllGraphicElements["_100000Hover"].DestroySelf();
                new Sprite2D("_100000");
            }
            //_1000000 Hover
            if (Sprite2D.IsCursorOnGraphicElement("_1000000") && ButtonHover == "")
            {
                ButtonHover = "_1000000";
                AllGraphicElements[ButtonHover].DestroySelf();
                new Sprite2D("_1000000Hover");
            }
            if (!Sprite2D.IsCursorOnGraphicElement("_1000000Hover") && ButtonHover == "_1000000")
            {
                ButtonHover = "";
                AllGraphicElements["_1000000Hover"].DestroySelf();
                new Sprite2D("_1000000");
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
