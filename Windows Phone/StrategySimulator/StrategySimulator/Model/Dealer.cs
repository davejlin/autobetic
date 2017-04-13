using System;

namespace StrategySimulator.Model
{
    public class Dealer
    {
        public Shoe Shoe { get; set; }
        public Dealer()
        {
        }

        public void Shuffle()
        {
            Utilities.Utilities.Shuffle(Shoe.Cards);
        }

        public void BurnCards()
        {
            int valueFirstCard = (int) Shoe.Cards[0].Value;

            Shoe.PointerIndex = Utilities.Utilities.BurnCards(0, Math.Min(valueFirstCard,10));
        }

        public void ResetShoePointer()
        {
            Shoe.PointerIndex = 0;
        }
    }
}
