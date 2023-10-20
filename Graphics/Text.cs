using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BlackJack2D
{
    public class Text : GraphicElement
    {
        public string TextString;
        public Font Font;

        public Text(string textString, Font font, Vector2 position, string tag = "not set")
        {
            TextString = textString;
            Font = font;
            Position = position;
            Tag = tag;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(TextString, Font, new SolidBrush(Color.Black), Position.x, Position.y);
        }
    }
}
