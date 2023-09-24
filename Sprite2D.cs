using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack2D
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Directory = null;
        public string Tag = "";
        public Bitmap Sprite = null;
        public bool IsRefrence = false;

        public Sprite2D(Resolution resolution, string Directory, string Tag)
        {
            this.Position = resolution.Position;
            this.Scale = resolution.Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            Sprite = sprite;

            GameEngine.RegisterSprite(this);
        }
        public Sprite2D(Resolution resolution, string Tag)
        {
            this.Position = resolution.Position;
            this.Scale = resolution.Scale;
            this.Directory = Tag;
            this.Tag = Tag;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            Sprite = sprite;

            GameEngine.RegisterSprite(this);
        }
        public Sprite2D(string Directory, bool IsRefrence)
        {
            this.IsRefrence = IsRefrence;
            this.Directory = Directory;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp);
            Sprite = sprite;

            GameEngine.RegisterSprite(this);
        }
        public Sprite2D(Resolution resolution, Bitmap Refrence, string Tag)
        {
            this.Position = resolution.Position;
            this.Scale = resolution.Scale;
            this.Tag = Tag;

            Sprite = Refrence;

            GameEngine.RegisterSprite(this);
        }
        public Sprite2D(string Tag)
        {
            Resolution resolutionInstance = Resolution.GetResolution(Tag);
            this.Position = resolutionInstance.Position;
            this.Scale = resolutionInstance.Scale;
            this.Directory = Tag;
            this.Tag = Tag;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            Sprite = sprite;

            GameEngine.RegisterSprite(this);
        }
        public bool IsColiding(string tag)
        {
            foreach (Sprite2D b in GameEngine.AllSprites.Values)
            {
                if (b.Tag == tag)
                {
                    if (Position.x < b.Position.x + b.Scale.x &&
                        Position.x + Scale.x > b.Position.x &&
                        Position.y < b.Position.y + b.Scale.y &&
                        Position.y + Scale.y > b.Position.y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool CursorIsOnStripe(string tag)
        {
            foreach (Sprite2D b in GameEngine.AllSprites.Values)
            {
                if (b.Tag == tag)
                {
                    if (Cursor.Position.X < b.Position.x + b.Scale.x &&
                        Cursor.Position.Y < b.Position.y + b.Scale.y &&
                        Cursor.Position.X > b.Position.x &&
                        Cursor.Position.Y > b.Position.y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DestroySelf()
        {
            GameEngine.UnRegisterSprite(this);
        }
        public static void ClearSprites()
        {
            GameEngine.AllSprites.Clear();
            GameEngine.AllTexts.Clear();
            GameEngine.AllShapes.Clear();
        }
    }
}
