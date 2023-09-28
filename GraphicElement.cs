using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    public abstract class GraphicElement
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public string Tag = "";

        public GraphicElement()
        {
            GameEngine.RegisterGraphicElement(this);
        }

        public void DestroySelf()
        {
            GameEngine.UnRegisterGraphicElement(this);
        }

        public static bool CursorIsOnGraphicElement(string tag)
        {
            foreach (GraphicElement e in GameEngine.AllGraphicElements.Values)
            {
                if (e.Tag == tag)
                {
                    if (Cursor.Position.X < e.Position.x + e.Scale.x &&
                        Cursor.Position.Y < e.Position.y + e.Scale.y &&
                        Cursor.Position.X > e.Position.x &&
                        Cursor.Position.Y > e.Position.y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // tag is other element
        public bool IsColiding(string tag)
        {
            foreach (Sprite2D b in GameEngine.AllGraphicElements.Values)
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

        public abstract void Draw(Graphics g);
    }
}
