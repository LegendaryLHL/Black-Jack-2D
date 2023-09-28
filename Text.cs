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

        public Text(string TextString, Font Font, Vector2 Position, string Tag = "not set")
        {
            this.TextString = TextString;
            this.Font = Font;
            this.Position = Position;
            this.Tag = Tag;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            g.DrawString(TextString, Font, new SolidBrush(Color.Black), Position.x, Position.y);
        }
    }
}
