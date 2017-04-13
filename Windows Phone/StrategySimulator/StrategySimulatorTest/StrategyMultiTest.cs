using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;

namespace StrategySimulatorTest
{
    [TestClass]
    public class StrategyMultiTest : StrategyTestBase
    {
        [TestMethod]
        public void StrategyMultiTest_TwoStrategies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            // Strategy set 1
            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];

            // Strategy set 2
            myStrategy[1].StrategyBaccaratType = StrategiesBaccaratTypes.BankerAlways;
            strategyMultiWrapper.MyStrategy[1] = myStrategy[1];

            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();
            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(6, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(7, score.UnitWin);
            Assert.AreEqual((decimal)6.70M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(10, score.UnitBet);
            Assert.AreEqual(10, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(3.70M, game.Results[11].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyMultiTest_ThreeStrategies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            // Strategy set 1
            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("btbp");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];

            // Strategy set 2
            myStrategy[1].Streaks_Length = 2;
            myStrategy[1].Streaks_Target = OutcomesBaccaratCoup.P;
            myStrategy[1].Streaks_BetPlacement = OutcomesBaccaratCoup.B;
            myStrategy[1].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[1] = myStrategy[1];

            // Strategy set 3
            myStrategy[2].CustomPattern_Pattern = Utilities.ParseBetPlacementString("b");
            myStrategy[2].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;
            myStrategy[2].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[2] = myStrategy[2];

            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();
            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(3, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.85M, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(6, score.UnitBet);
            Assert.AreEqual(6, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.85M, game.Results[11].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyMultiTest_FourStrategies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            // Strategy set 1
            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bppb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];

            // Strategy set 2
            myStrategy[1].Streaks_Length = 3;
            myStrategy[1].Streaks_Target = OutcomesBaccaratCoup.B;
            myStrategy[1].Streaks_BetPlacement = OutcomesBaccaratCoup.P;
            myStrategy[1].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[1] = myStrategy[1];

            // Strategy set 3
            myStrategy[2].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bb");
            myStrategy[2].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;
            myStrategy[2].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[2] = myStrategy[2];

            // Strategy set 4
            myStrategy[3].CustomPattern_Pattern = Utilities.ParseBetPlacementString("p");
            myStrategy[3].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;
            myStrategy[3].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[3] = myStrategy[3];

            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();
            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.95M, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.95M, game.Results[11].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);
        }
    }
}
