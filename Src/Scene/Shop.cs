using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    class Shop
    {
        public static void ShopFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            new Button("Upgrade", 50, Color.LightGreen, () => { }, "UpgradeButton");
            new Button("Back", 80, Color.LightGreen, GameLogic.Menu, "BackButton");
        }
    }
}
