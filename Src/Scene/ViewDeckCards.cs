using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack2D
{
    class ViewDeckCards
    {
        /*
         * maybe TODO:
         * make scene handler
         */
        public static void ViewDeckCardsFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            DrawAllCards();
            new Button("ShuffleDeckButton", "Shuffle Deck", Resolution.ScaledFont(30), Color.LightGreen, ShuffleDeckFunction);
            new Button("BackButton", "Back", Resolution.ScaledFont(80), Color.LightGreen, BlackJackGameLogic.Menu);
            new Button("RearrangeButton", "Rearrange", Resolution.ScaledFont(40), Color.LightGreen, RearrangeFunction);
        }
        public static void DrawAllCards()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    BlackJackGameLogic.Shoe[count].DrawCard(
                        new Resolution(Resolution.GetResolution("DrawAllCards").Scale, 
                        new Vector2(j * Resolution.GetResolution("DrawAllCards").Position.x + Resolution.Scaled(50), 
                        i * Resolution.GetResolution("DrawAllCards").Position.y + Resolution.Scaled(50))), count.ToString());
                    count++;
                }
            }
        }

        public static void ShuffleDeckFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            PokerCard.ShuffleShoe(BlackJackGameLogic.Shoe);
            ViewDeckCardsFunction();
        }

        public static void RearrangeFunction()
        {
            GameEngine.AllGraphicElements.Clear();
            BlackJackGameLogic.Shoe = PokerCard.NewShoe(PokerCard.CountNumberOfDeck(BlackJackGameLogic.Shoe));
            ViewDeckCardsFunction();
        }
    }
}
