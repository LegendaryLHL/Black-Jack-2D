using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    class ViewDeckCards
    {
        public static void ViewDeckCardsFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            DrawAllCards();
            new Sprite2D("ShuffleDeckButton");
            new Sprite2D("BackButton");
            new Sprite2D("RearrangeButton");
        }
        public static void DrawAllCards()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    BlackJack2DCode.NewPokerDeck.Deck[count].DrawCard(new Resolution(Resolution.GetResolution("DrawAllCards").Scale, new Vector2(j * Resolution.GetResolution("DrawAllCards").Position.x + 50, i * Resolution.GetResolution("DrawAllCards").Position.y + 50)));
                    count++;
                }
            }
        }

        public static void ShuffleDeckFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            BlackJack2DCode.NewPokerDeck.ShuffleDeck();
            ViewDeckCardsFunction();
        }

        public static void RearrangeFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            BlackJack2DCode.NewPokerDeck = new PokerDeck();
            ViewDeckCardsFunction();
        }

        public static void BackFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            BlackJack2DGame.Menu();
        }
    }
}
