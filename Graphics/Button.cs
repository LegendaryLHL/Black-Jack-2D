using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BlackJack2D
{

    public class Button : GraphicElement
    {
        public string Text;
        public Font Font;
        public Action RunAction;
        public bool IsHover = false;
        public Color Color;

        public Button(Resolution resolution, string text, Font font, Color color, Action runAction, string tag = "not set")
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            Text = text;
            Tag = tag;
            Font = font;
            Color = color;
            RunAction = runAction;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            // Rectangle.
            g.FillRectangle(new SolidBrush(Color), Position.x, Position.y, Scale.x, Scale.y);

            // Text.
            SizeF textSize = g.MeasureString(Text, Font);
            float textX = Position.x + (Scale.x - textSize.Width) / 2;
            float textY = Position.y + (Scale.y - textSize.Height) / 2;
            g.DrawString(Text, Font, new SolidBrush(Color.Black), textX, textY);

            // Hover Border
            if (IsHover)
            {
                Pen borderPen = new Pen(Color.Black, 4);
                g.DrawRectangle(borderPen, Position.x, Position.y, Scale.x, Scale.y);
            }
        }
    }
}
