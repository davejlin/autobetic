
namespace StrategySimulator.Model
{
    public class Deck
    {
        public Card[] Cards { get; private set; }
        private int _cardsInDeck = 52;

        public Deck()
        {
            createDeck();
        }

        private void createDeck()
        {
            int index = 0;
            Cards = new Card[_cardsInDeck];
            for (int suit = 1; suit < 5; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    Card card = new Card((Suits)suit, (Values)value);
                    Cards[index++] = card;
                }
            }
        }
    }
}
