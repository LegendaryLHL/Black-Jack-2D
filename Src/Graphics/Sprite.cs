using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace BlackJack2D
{
    public class Sprite : GraphicElement
    {
        public string Directory = null;
        public Bitmap SpriteImg = null;
        public bool IsRefrence = false;

        public Sprite(Resolution resolution, string Directory, string Tag)
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Image temp = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            SpriteImg = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite(Resolution resolution, string Tag)
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            Directory = Tag;
            this.Tag = Tag;

            Image temp = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            SpriteImg = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite(string Directory, bool IsRefrence)
        {
            this.IsRefrence = IsRefrence;
            this.Directory = Directory;

            Image temp = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(temp);
            SpriteImg = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite(Resolution resolution, Bitmap Refrence, string Tag)
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            this.Tag = Tag;

            SpriteImg = Refrence;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite(string Tag)
        {
            Resolution resolution = Resolution.GetResolution(Tag);
            Position = resolution.Position;
            Scale = resolution.Scale;
            Directory = Tag;
            this.Tag = Tag;

            Image img = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(img, (int)Scale.x, (int)Scale.y);
            SpriteImg = sprite;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            if (!IsRefrence)
            {
                g.DrawImage(SpriteImg, Position.x, Position.y - 28, Scale.x, Scale.y);
            }
        }
    }
}
