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
            new Button("UpgradeButton", "Upgrade", Resolution.ScaledFont(50), Color.LightGreen, () => { });
            new Button("BackButton", "Back", Resolution.ScaledFont(80), Color.LightGreen, BlackJackGameLogic.Menu);
        }
    }
}
