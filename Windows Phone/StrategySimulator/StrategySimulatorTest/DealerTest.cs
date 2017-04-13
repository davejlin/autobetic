using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;
using System;

namespace StrategySimulatorTest
{
    [TestClass]
    public class DealerTest
    {
        int nDecks = 8;
        Shoe shoe;
        Dealer dealer;

        [TestInitialize]
        public void init()
        {
            shoe = new Shoe(nDecks);
            dealer = new Dealer() { Shoe = shoe };
        }

        [TestMethod]
        public void DealerTest_BurnCorrectNumberOfCards_Test()
        {
            dealer.Shuffle();

            int valueFirstCard = (int) dealer.Shoe.Cards[0].Value;
            int expectedNumberOfCardsAfterBurn = (nDecks * 52) - 1 - Math.Min(valueFirstCard,10);
            
            dealer.BurnCards();

            int ActualNumberOfCardsAfterBurn = dealer.Shoe.Cards.Length - 1 - Math.Min(valueFirstCard, 10);

            Assert.AreEqual(expectedNumberOfCardsAfterBurn, ActualNumberOfCardsAfterBurn);
            Assert.AreEqual(Math.Min(valueFirstCard, 10), dealer.Shoe.PointerIndex);
        }
  
    }
}
