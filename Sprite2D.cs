﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace BlackJack2D
{
    public class Sprite2D : GraphicElement
    {
        public string Directory = null;
        public Bitmap Sprite = null;
        public bool IsRefrence = false;

        public Sprite2D(Resolution resolution, string Directory, string Tag)
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            Sprite = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite2D(Resolution resolution, string Tag)
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            Directory = Tag;
            this.Tag = Tag;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)this.Scale.x, (int)this.Scale.y);
            Sprite = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite2D(string Directory, bool IsRefrence)
        {
            this.IsRefrence = IsRefrence;
            this.Directory = Directory;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp);
            Sprite = sprite;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite2D(Resolution resolution, Bitmap Refrence, string Tag)
        {
            Position = resolution.Position;
            Scale = resolution.Scale;
            this.Tag = Tag;

            Sprite = Refrence;

            GameEngine.RegisterGraphicElement(this);
        }
        public Sprite2D(string Tag)
        {
            Resolution resolutionInstance = Resolution.GetResolution(Tag);
            Position = resolutionInstance.Position;
            Scale = resolutionInstance.Scale;
            Directory = Tag;
            this.Tag = Tag;

            Image temp = Image.FromFile($"Assets/{Directory}.png");
            Bitmap sprite = new Bitmap(temp, (int)Scale.x, (int)Scale.y);
            Sprite = sprite;

            GameEngine.RegisterGraphicElement(this);
        }

        public override void Draw(Graphics g)
        {
            if (!IsRefrence)
            {
                g.DrawImage(Sprite, Position.x, Position.y - 28, Scale.x, Scale.y);
            }
        }
    }
}
