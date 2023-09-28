using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    // NOt finished
    public class Shape2D : GraphicElement
    {
        public Shape2D(Vector2 Position, Vector2 Scale, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            GameEngine.RegisterGraphicElement(this);
        }


        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), Position.x, Position.y, Scale.x, Scale.y);
        }
    }
}
