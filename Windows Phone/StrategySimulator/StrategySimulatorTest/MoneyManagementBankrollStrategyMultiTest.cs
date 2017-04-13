using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;

namespace StrategySimulatorTest
{
    [TestClass]
    public class MoneyManagementBankrollStrategyMultiTest : StrategyTestBase
    {
        public void MoneyManagementInitialize()
        {
            mmBankroll = myMoneyManagement.getMoneyManagementBankroll(true);
            myMoneyManagement.Bankroll = 5;
        }

        [TestMethod]
        public void MoneyManagementBankrollMulti_AllStrategySets_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllB();
            PrepareGame();
            MoneyManagementInitialize();

            // Strategy set 1
            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bbbb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];

            // Strategy set 2
            myStrategy[1].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bbb");
            myStrategy[1].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[1].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[1] = myStrategy[1];

            // Strategy set 3
            myStrategy[2].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bb");
            myStrategy[2].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[2].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[2] = myStrategy[2];

            // Strategy set 4
            myStrategy[3].CustomPattern_Pattern = Utilities.ParseBetPlacementString("b");
            myStrategy[3].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[3].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[3] = myStrategy[3];

            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0, score.DollarWin);

            Assert.AreEqual(5, score.UnitLoss);
            Assert.AreEqual((decimal)5, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[5].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, game.Results[5].TotalDollarScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);

            for (int i = 1; i < 6; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 6; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }
    }
}
