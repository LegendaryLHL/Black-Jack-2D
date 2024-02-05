using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    // NOt finished
    public class Shape : GraphicElement
    {
        public Color Color;
        public Shape(Color color, string Tag = "not set shape tag")
        {
            Resolution = Resolution.Resolutions[Tag];
            this.Tag = Tag;

            GameEngine.RegisterGraphicElement(this);
        }


        public override void Draw(Graphics g)
        {
            Resolution scaledResolution = Resolution.ScaleResolution(Resolution);
            g.FillRectangle(new SolidBrush(Color), scaledResolution.Position.x, scaledResolution.Position.y, scaledResolution.Scale.x, scaledResolution.Scale.y);
        }
    }
}
