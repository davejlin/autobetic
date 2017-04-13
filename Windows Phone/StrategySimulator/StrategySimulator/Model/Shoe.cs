using System;

namespace StrategySimulator.Model
{
    public class Shoe
    {
        public int NDecks { get; private set; }
        public Card[] Cards { get; private set; }
        public int PointerIndex { get; set; } 

        public Shoe(int nDecks)
        {
            NDecks = Math.Max(nDecks,1);
            createShoe();
            PointerIndex = 0;
        }

        public Shoe(Card[] cards)
        {
            Cards = cards;
            PointerIndex = 0;
        }

        private void createShoe()
        {
            Cards = new Card[52 * NDecks];
            for (int i = 0; i < NDecks; i++)
            {
                Deck deck = new Deck();

                int cardIndex = 0;
                foreach (Card card in deck.Cards)
                {
                    Cards[(52*i)+(cardIndex++)]=card;
                }
            }
        }


        public string DisplayAllCardsNames()
        {
            return Utilities.Utilities.DisplayAllCardNames(Cards);
        }
    }
}
