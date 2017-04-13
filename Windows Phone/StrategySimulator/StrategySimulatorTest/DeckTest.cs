using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;

namespace StrategySimulatorTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DeckTest_FullDeckConstructedCorrectly_Test()
        {
            Deck deck = new Deck();
            Card[] cards = deck.Cards;

            Assert.AreEqual(4*13, cards.Length);
            CheckPresenceOfAllCardsInOrder(cards, 1);
        }

        public static void CheckPresenceOfAllCardsInOrder(Card[] cards, int nDecks)
        {
            for (int decks = 0; decks < nDecks; decks++)
            {
                for (int suit = 1; suit < 5; suit++)
                {
                    for (int value = 1; value < 14; value++)
                    {
                        Card card = new Card((Suits)suit, (Values)value);

                        int deckIndex = (52*decks) + (13*(suit-1)) + value - 1;

                        Assert.AreEqual(cards[deckIndex].ToString(), card.ToString());
                    }
                }
            }
        }
    }
}
