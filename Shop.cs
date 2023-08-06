using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    class Shop
    {
        public static Sprite2D UpgradeButton;
        public static Sprite2D UpgradeButtonHover;
        public static void ShopFunction()
        {
            Sprite2D.ClearSprites();
            UpgradeButton = new Sprite2D("UpgradeButton");
            ViewDeckCards.BackButton = new Sprite2D("BackButton");
        }
    }
}
