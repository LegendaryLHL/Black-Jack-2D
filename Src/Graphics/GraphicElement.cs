using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    public abstract class GraphicElement
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public string Tag = "";

        public void DestroySelf()
        {
            GameEngine.UnRegisterGraphicElement(this);
        }

        public static bool IsCursorOnGraphicElement(string tag)
        {
            foreach (GraphicElement e in GameEngine.AllGraphicElements.Values)
            {
                if (e.Tag == tag)
                {
                    if (GameEngine.CursorPosition.x < e.Position.x + e.Scale.x &&
                        GameEngine.CursorPosition.y < e.Position.y + e.Scale.y &&
                        GameEngine.CursorPosition.x > e.Position.x &&
                        GameEngine.CursorPosition.y > e.Position.y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCursorOnGraphicElement()
        {
            return      GameEngine.CursorPosition.x < Position.x + Scale.x &&
                        GameEngine.CursorPosition.y < Position.y + Scale.y &&
                        GameEngine.CursorPosition.x > Position.x &&
                        GameEngine.CursorPosition.y > Position.y;
        }

        // tag is other element
        public bool IsColiding(string tag)
        {
            foreach (GraphicElement b in GameEngine.AllGraphicElements.Values)
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
