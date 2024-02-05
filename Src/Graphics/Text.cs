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
        public int FontSize;

        public Text(string textString, int fontSize, string tag = "not set text tag")
        {
            TextString = textString;
            FontSize = fontSize;
            Resolution = Resolution.Resolutions[tag];
            Tag = tag;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            Resolution scaledResolution = Resolution.ScaleResolution(Resolution);
            g.DrawString(TextString, Resolution.ScaledFont(FontSize), new SolidBrush(Color.Black), scaledResolution.Position.x, scaledResolution.Position.y);
        }
    }
}
