﻿using System;
using System.Collections.Generic;
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
            new Sprite2D("UpgradeButton");
            new Sprite2D("BackButton");
        }
    }
}
