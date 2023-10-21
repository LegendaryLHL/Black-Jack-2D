using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    class BlackJackEngine : GameEngine
    {
        public BlackJackEngine() : base(new Vector2(625, 512), ("Black Jack 2D")) { }

        public override void OnInitialise()
        {
            WindowStateSize = FormWindowState.Maximized;
        }
        public override void OnLoad()
        {
            Resolution.MakeResolution();
            BackgroundColour = Color.Green;
            BlackJackGameLogic.Menu();
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
            }/*
            
            //Shuffle Cards Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("ShuffleDeckButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.ShuffleDeckFunction();
            }
            //Rearrange Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("RearrangeButtonHover"))
            {
                ButtonHover = "";
                ViewDeckCards.RearrangeFunction();
            }
            //Upgrade Button Up
            if (e.Button == MouseButtons.Left && Sprite.IsCursorOnGraphicElement("UpgradeButtonHover"))
            {
                ButtonHover = "";
                //upgrade function;
            }

            //Same code bcause need to hover
            CheakHover();//because after click becomes not hover so click cheak again lol*/
        }

        public override void GetMouseMove(EventArgs e)
        {
            // Handle button
            foreach (GraphicElement graphicElement in AllGraphicElements.Values)
            {
                // Not Hover
                if (graphicElement is Button)
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
