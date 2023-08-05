using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    public class Resolution
    {
        public string Id { get; set; }
        public static List<Resolution> Resolutions { get; set; }
        public Vector2 Vector { get; set; }

        private static Vector2 ScreenResolution = new Vector2(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
        //todo RearrangeButton, ShopButton, UpgradeButton 
        private static Vector2 OriginalResolution = new Vector2(2048,1152);

        public Resolution(Vector2 vector, string id)
        {
            Vector = vector;
            Id = id;
        }
        private static void NewResolution(Vector2 vector, string id)
        {
            Resolutions.Add(new Resolution(vector, id));
        }
        public static void MakeResolution()
        {
            //made for 2048, 1152
            NewResolution(new Vector2(850, 520), "ViewDeckCardsButtonLocation");
            NewResolution(new Vector2(350, 900), "ShuffleDeckButtonLocation");
            NewResolution(new Vector2(1300, 900), "BackButtonLocation");
            NewResolution(new Vector2(845, 900), "RearrangeButtonLocation");
            NewResolution(new Vector2(140, 200), "DrawAllCardsLocation");
            NewResolution(new Vector2(400, 520), "PlayButtonLocation");
            NewResolution(new Vector2(1300, 520), "QuitButtonLocation");
            NewResolution(new Vector2(200, 100), "DealerFirstCard");
            NewResolution(new Vector2(500, 100), "DealerSecondCard");
            NewResolution(new Vector2(800, 100), "DealerThirdCard");
            NewResolution(new Vector2(1100, 100), "DealerFourthCard");
            NewResolution(new Vector2(1400, 100), "DealerFifthCard");
            NewResolution(new Vector2(200, 400), "YourFirstCard");
            NewResolution(new Vector2(500, 400), "YourSecondCard");
            NewResolution(new Vector2(800, 400), "YourThirdCard");
            NewResolution(new Vector2(1100, 400), "YourFourthCard");
            NewResolution(new Vector2(1400, 400), "YourFifthCard");
            NewResolution(new Vector2(350, 900), "HitButtonLocation");
            NewResolution(new Vector2(1250, 900), "StayButtonLocation");
            NewResolution(new Vector2(200, 100), "PlaceBetLocation");
            NewResolution(new Vector2(100, 1000), "YourMoneyLocation");
            NewResolution(new Vector2(100, 520), "_0Location");
            NewResolution(new Vector2(400, 520), "_50Location");
            NewResolution(new Vector2(700, 520), "_100Location");
            NewResolution(new Vector2(1000, 520), "_200Location");
            NewResolution(new Vector2(1300, 520), "_500Location");
            NewResolution(new Vector2(1600, 520), "_1000Location");
            NewResolution(new Vector2(100, 700), "_5000Location");
            NewResolution(new Vector2(400, 700), "_10000Location");
            NewResolution(new Vector2(700, 700), "_100000Location");
            NewResolution(new Vector2(1000, 700), "_1000000Location");
            NewResolution(new Vector2(630, 750), "ShopButtonLocation");
            NewResolution(new Vector2(400, 520), "UpgradeButtonLocation");
            NewResolution(new Vector2(200, 100), "ViewDeckCardsButtonScale");
            NewResolution(new Vector2(200, 100), "ShuffleDeckButtonScale");
            NewResolution(new Vector2(200, 100), "BackButtonScale");
            NewResolution(new Vector2(200, 100), "RearrangeButtonScale");
            NewResolution(new Vector2(88, 124), "DrawAllCardsScale");
            NewResolution(new Vector2(200, 100), "PlayButtonScale");
            NewResolution(new Vector2(200, 100), "QuitButtonScale");
            NewResolution(new Vector2(176, 248), "PlayBlackJackCardsScale");
            NewResolution(new Vector2(200, 100), "HitButtonScale");
            NewResolution(new Vector2(200, 100), "StayButtonScale");
            NewResolution(new Vector2(200, 100), "AskForBetButtonsScale");
            NewResolution(new Vector2(200, 100), "ShopButtonScale");
            NewResolution(new Vector2(200, 100), "UpgradeButtonScale");

            foreach (Resolution resolution in Resolutions)
            {
                if (resolution.Id.Contains("Scale"))
                {
                    resolution.Vector = new Vector2(resolution.Vector.x* ScreenResolution.x / OriginalResolution.x, resolution.Vector.y * ScreenResolution.y / OriginalResolution.y);
                }
            }
        }
        private protected static void ViewResolutionSimulation(int x, int y)
        {
            new Sprite2D(new Vector2(x, 1), new Vector2(1, 2000), "ViewDeckCardsButton", "ViewDeckCardsButton");
            new Sprite2D(new Vector2(1, y), new Vector2(2000, 1), "ViewDeckCardsButton", "ViewDeckCardsButton");
        }
    }
}
