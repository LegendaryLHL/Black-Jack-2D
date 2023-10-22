using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack2D
{
    public class Resolution
    {
        public string Id { get; set; } //same as tag in sprite
        public static Dictionary<string, Resolution> Resolutions = new Dictionary<string, Resolution>();
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }

        public static Vector2 ScreenResolution = new Vector2(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        private static Vector2 OriginalResolution = new Vector2(2048,1152);

        public Resolution(Vector2 scale, Vector2 position, string id)
        {
            Scale = scale;
            Position = position;
            Id = id;
            Resolutions[id] = ScaleResolution(this);
        }
        public Resolution(Vector2 scale, Vector2 position)
        {
            Scale = scale;
            Position = position;
            Resolutions["Tag not set"] = ScaleResolution(this);
        }
        public static void MakeResolution()
        {
            // Made for 2048, 1152
            new Resolution(new Vector2(200, 100), new Vector2(850, 450), "ViewDeckCardsButton");
            new Resolution(new Vector2(200, 100), new Vector2(350, 900), "ShuffleDeckButton");
            new Resolution( new Vector2(200, 100), new Vector2(1300, 900), "BackButton");
            new Resolution(new Vector2(200, 100), new Vector2(845, 900), "RearrangeButton");
            new Resolution(new Vector2(88, 124), new Vector2(140, 200), "DrawAllCards");
            new Resolution(new Vector2(200, 100), new Vector2(400, 450), "PlayButton");
            new Resolution(new Vector2(200, 100), new Vector2(1300, 450), "QuitButton");
            new Resolution(new Vector2(176, 248), new Vector2(200, 100), "DealerFirstCard");
            new Resolution(new Vector2(176, 248), new Vector2(500, 100), "DealerSecondCard");
            new Resolution(new Vector2(176, 248), new Vector2(800, 100), "DealerThirdCard");
            new Resolution(new Vector2(176, 248), new Vector2(1100, 100), "DealerFourthCard");
            new Resolution(new Vector2(176, 248), new Vector2(1400, 100), "DealerFifthCard");
            new Resolution(new Vector2(176, 248), new Vector2(200, 400), "YourFirstCard");
            new Resolution(new Vector2(176, 248), new Vector2(500, 400), "YourSecondCard");
            new Resolution(new Vector2(176, 248), new Vector2(800, 400), "YourThirdCard");
            new Resolution(new Vector2(176, 248), new Vector2(1100, 400), "YourFourthCard");
            new Resolution(new Vector2(176, 248), new Vector2(1400, 400), "YourFifthCard");
            new Resolution(new Vector2(200, 100), new Vector2(350, 900), "HitButton");
            new Resolution(new Vector2(200, 100), new Vector2(1250, 900), "StayButton");
            new Resolution(new Vector2(0,0), new Vector2(100, 100), "PlaceBet");
            new Resolution(new Vector2(0,0), new Vector2(100, 900), "YourMoney");
            new Resolution(new Vector2(200, 100), new Vector2(100, 450), "0");
            new Resolution(new Vector2(200, 100), new Vector2(400, 450), "50");
            new Resolution(new Vector2(200, 100), new Vector2(700, 450), "100");
            new Resolution(new Vector2(200, 100), new Vector2(1000, 450), "200");
            new Resolution(new Vector2(200, 100), new Vector2(1300, 450), "500");
            new Resolution(new Vector2(200, 100), new Vector2(1600, 450), "1000");
            new Resolution(new Vector2(200, 100), new Vector2(100, 640), "5000");
            new Resolution(new Vector2(200, 100), new Vector2(400, 640), "10000");
            new Resolution(new Vector2(200, 100), new Vector2(700, 640), "100000");
            new Resolution(new Vector2(200, 100), new Vector2(1000, 640), "1000000");
            new Resolution(new Vector2(200, 100), new Vector2(630, 750), "ShopButton");
            new Resolution(new Vector2(200, 100), new Vector2(400, 450), "UpgradeButton");
        }

        private static Resolution ScaleResolution(Resolution resolution)
        {
            resolution.Scale = new Vector2(resolution.Scale.x * ScreenResolution.x / OriginalResolution.x, resolution.Scale.y * ScreenResolution.y / OriginalResolution.y);
            resolution.Position = new Vector2(resolution.Position.x * ScreenResolution.x / OriginalResolution.x, resolution.Position.y * ScreenResolution.y / OriginalResolution.y);
            return resolution;
        }
        public static Font ScaledFont(int fontSize)
        {
            float scaleX = (float)ScreenResolution.x / OriginalResolution.x;
            float scaleY = (float)ScreenResolution.y / OriginalResolution.y;

            int scaledFontSize = (int)(fontSize * Math.Min(scaleX, scaleY));

            if (scaledFontSize < 1)
            {
                scaledFontSize = 1;
            }

            return new Font("Arial", scaledFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }
        public static Resolution GetResolution(string id)
        {
            foreach (Resolution resolution in Resolutions.Values)
            {
                if (resolution.Id == id)
                {
                    return resolution;
                }
            }

            //hover temp fix later
            foreach (Resolution resolution in Resolutions.Values)
            {
                if (resolution.Id == id.Replace("Hover", ""))
                {
                    return resolution;
                }
            }

            //how to fix this
            foreach (Resolution resolution in Resolutions.Values)
            {
                if (resolution.Id == "DrawAllCards")
                {
                    return resolution;
                }
            }

            return null;
        }

        public static int Scaled(int number)
        {
            float scaleX = (float)ScreenResolution.x / OriginalResolution.x;
            float scaleY = (float)ScreenResolution.y / OriginalResolution.y;

            int scaledNumber = (int)(number * Math.Min(scaleX, scaleY));

            if (scaledNumber < 1)
            {
                scaledNumber = 1;
            }

            return scaledNumber;
        }
    }
}
