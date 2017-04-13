using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model;

namespace StrategySimulatorTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardTest_CorrectNameOfCard_Test()
        {
            Card card = new Card(Suits.Spades, Values.Ace);
            string actualCardName = card.ToString();
            string expectedCardName = "SpadesAce";

            Assert.AreEqual(expectedCardName, actualCardName);

            card = new Card(Suits.Clubs, Values.Jack);
            actualCardName = card.ToString();
            expectedCardName = "ClubsJack";

            Assert.AreEqual(expectedCardName, actualCardName);

            card = new Card(Suits.Diamonds, Values.Ten);
            actualCardName = card.ToString();
            expectedCardName = "DiamondsTen";

            Assert.AreEqual(expectedCardName, actualCardName);

            card = new Card(Suits.Hearts, Values.King);
            actualCardName = card.ToString();
            expectedCardName = "HeartsKing";

            Assert.AreEqual(expectedCardName, actualCardName);
        }
    }
}
