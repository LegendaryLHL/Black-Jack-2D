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
            GameLogic.Menu();
            Resolution.ScreenResolution = getWindowWidth();
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
            Resolution.ScreenResolution = getWindowWidth();
        }
    }
}
