using System.Drawing;
using System.Windows.Forms;

namespace BlackJack2D
{
    public abstract class GraphicElement
    {
        public Resolution Resolution { get; set; }
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
                    Resolution scaledResolution = Resolution.ScaleResolution(e.Resolution);
                    if (GameEngine.CursorPosition.x < scaledResolution.Position.x + scaledResolution.Scale.x &&
                        GameEngine.CursorPosition.y < scaledResolution.Position.y + scaledResolution.Scale.y &&
                        GameEngine.CursorPosition.x > scaledResolution.Position.x &&
                        GameEngine.CursorPosition.y > scaledResolution.Position.y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCursorOnGraphicElement()
        {
            Resolution scaledResolution = Resolution.ScaleResolution(Resolution);
            return      GameEngine.CursorPosition.x < scaledResolution.Position.x + scaledResolution.Scale.x &&
                        GameEngine.CursorPosition.y < scaledResolution.Position.y + scaledResolution.Scale.y &&
                        GameEngine.CursorPosition.x > scaledResolution.Position.x &&
                        GameEngine.CursorPosition.y > scaledResolution.Position.y;
        }

        // tag is other element
        public bool IsColiding(string tag)
        {
            foreach (GraphicElement b in GameEngine.AllGraphicElements.Values)
            {
                if (b.Tag == tag)
                {
                    if (Resolution.Position.x < b.Resolution.Position.x + b.Resolution.Scale.x &&
                        Resolution.Position.x + Resolution.Scale.x > b.Resolution.Position.x &&
                        Resolution.Position.y < b.Resolution.Position.y + b.Resolution.Scale.y &&
                        Resolution.Position.y + Resolution.Scale.y > b.Resolution.Position.y)
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
