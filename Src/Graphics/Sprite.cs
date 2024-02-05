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

        public Sprite(string Directory, string Tag = "not set sprite tag")
        {
            Resolution = Resolution.Resolutions[Tag];
            this.Directory = Directory;
            this.Tag = Tag;

            Image temp = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)Resolution.Scale.x, (int)Resolution.Scale.y);
            SpriteImg = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite(Resolution resolution, string Directory, string Tag = "not set sprite tag")
        {
            Resolution = resolution;
            this.Directory = Directory;
            this.Tag = Tag;

            Image temp = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)Resolution.Scale.x, (int)Resolution.Scale.y);
            SpriteImg = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite(string Tag = "not set sprite tag")
        {
            Resolution = Resolution.Resolutions[Tag];
            Directory = Tag;
            this.Tag = Tag;

            Image temp = Image.FromFile($"../../Assets/Images/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)Resolution.Scale.x, (int)Resolution.Scale.y);
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
        public Sprite(Bitmap Refrence, string Tag = "not set sprite tag")
        {
            Resolution = Resolution.Resolutions[Tag];
            this.Tag = Tag;

            SpriteImg = Refrence;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            Resolution scaledResolution = Resolution.ScaleResolution(Resolution);
            if (!IsRefrence)
            {
                g.DrawImage(SpriteImg, scaledResolution.Position.x, scaledResolution.Position.y, scaledResolution.Scale.x, scaledResolution.Scale.y);
            }
        }
    }
}
