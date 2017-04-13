using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;

namespace StrategySimulatorTest
{
    [TestClass]
    public class ShoeTest
    {
        [TestMethod]
        public void ShoeTest_ShoeConstructedCorrectly_Test()
        {
            int nDecks = 1;
            Shoe shoe = new Shoe(nDecks);
            Assert.AreEqual(52*nDecks, shoe.Cards.Length);
            DeckTest.CheckPresenceOfAllCardsInOrder(shoe.Cards, nDecks);

            nDecks = 8;
            shoe = new Shoe(nDecks);
            Assert.AreEqual(52*nDecks, shoe.Cards.Length);
            DeckTest.CheckPresenceOfAllCardsInOrder(shoe.Cards, nDecks);
        }

        [TestMethod]
        public void ShoeTest_NoDeckDefaultsToOneDeck_Test()
        {
            int nDecks = 0;
            Shoe shoe = new Shoe(nDecks);
            Assert.AreEqual(52 * 1, shoe.Cards.Length);
            DeckTest.CheckPresenceOfAllCardsInOrder(shoe.Cards, 1);;
        }

    }
}
