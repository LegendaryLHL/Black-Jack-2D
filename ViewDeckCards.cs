﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    class ViewDeckCards
    {
        public static Sprite2D ShuffleDeckButton;
        public static Sprite2D ShuffleDeckButtonHover;
        public static Sprite2D BackButton;
        public static Sprite2D BackButtonHover;
        public static Sprite2D RearrangeButton;
        public static Sprite2D RearrangeButtonHover;
        public static void ViewDeckCardsFunction()
        {
            Sprite2D.ClearSprites();
            DrawAllCards();
            ShuffleDeckButton = new Sprite2D(Resolution.ShuffleDeckButtonLocation, Resolution.ShuffleDeckButtonScale, "ShuffleDeckButton", "ShuffleDeckButton");
            BackButton = new Sprite2D(Resolution.BackButtonLocation, Resolution.BackButtonScale, "BackButton", "BackButton");
            RearrangeButton = new Sprite2D(Resolution.RearrangeButtonLocation, Resolution.RearrangeButtonScale, "RearrangeButton", "RearrangeButton");
        }
        public static void DrawAllCards()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    BlackJack2DCode.NewPokerDeck.Deck[count].DrawCard(new Vector2(j * Resolution.DrawAllCardsLocation.x + 50, i * Resolution.DrawAllCardsLocation.y + 50), Resolution.DrawAllCardsScale);
                    count++;
                }
            }
        }

        public static void ShuffleDeckFunction()
        {
            Sprite2D.ClearSprites();
            BlackJack2DCode.NewPokerDeck = PokerDeck.ShuffleDeck(BlackJack2DCode.NewPokerDeck);
            ViewDeckCardsFunction();
        }

        public static void RearrangeFunction()
        {
            Sprite2D.ClearSprites();
            BlackJack2DCode.NewPokerDeck = new PokerDeck();
            ViewDeckCardsFunction();
        }

        public static void BackFunction()
        {
            Sprite2D.ClearSprites();
            BlackJack2DGame.Menu();
        }
    }
}
