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
        public int FontSize;
        public Action RunAction;
        public bool IsHover = false;
        public bool IsHeld = false;
        public Color Color;

        public Button(string text, int fontSize, Color color, Action runAction, string tag = "not set button tag")
        {
            Resolution = Resolution.Resolutions[tag];
            Text = text;
            Tag = tag;
            FontSize = fontSize;
            Color = color;
            RunAction = runAction;

            GameEngine.RegisterGraphicElement(this);
        }
        public override void Draw(Graphics g)
        {
            Resolution scaledResolution = Resolution.ScaleResolution(Resolution);
            // Rectangle
            g.FillRectangle(new SolidBrush(Color), scaledResolution.Position.x, scaledResolution.Position.y, scaledResolution.Scale.x, scaledResolution.Scale.y);

            // Text
            SizeF textSize = g.MeasureString(Text, Resolution.ScaledFont(FontSize));
            float textX = scaledResolution.Position.x + (scaledResolution.Scale.x - textSize.Width) / 2;
            float textY = scaledResolution.Position.y + (scaledResolution.Scale.y - textSize.Height) / 2;
            g.DrawString(Text, Resolution.ScaledFont(FontSize), new SolidBrush(Color.Black), textX, textY);

            // Hover Border
            if (IsHover)
            {
                Pen borderPen = new Pen(Color.Black, 4);
                g.DrawRectangle(borderPen, scaledResolution.Position.x, scaledResolution.Position.y, scaledResolution.Scale.x, scaledResolution.Scale.y);
            }
        }
    }
}
