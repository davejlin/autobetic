using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;

namespace StrategySimulatorTest
{
    [TestClass]
    public class StrategyTest : StrategyTestBase
    {
        [TestMethod]
        public void StrategyTest_NoStrategy_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.None;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual(0, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual(0, score.DollarLoss);

            Assert.AreEqual(0, score.UnitBet);
            Assert.AreEqual(0, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.00M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // Tie

            for (int i = 1; i < 10; i++ )
            {
                Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[i].CoupBet.BetPlacement);
            }
        }

        [TestMethod]
        public void StrategyTest_BankerAlways_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.BankerAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(4, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.8, score.DollarWin);

            Assert.AreEqual(5, score.UnitLoss);
            Assert.AreEqual((decimal)5, score.DollarLoss);

            Assert.AreEqual(9, score.UnitBet);
            Assert.AreEqual(9, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-1.20M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[0].OutcomeBet); // Tie

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[i].CoupBet.BetPlacement);
            }
        }

        [TestMethod]
        public void StrategyTest_PlayerAlways_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.PlayerAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(5, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(5, score.UnitWin);
            Assert.AreEqual((decimal)5, score.DollarWin);

            Assert.AreEqual(4, score.UnitLoss);
            Assert.AreEqual((decimal)4, score.DollarLoss);

            Assert.AreEqual(9, score.UnitBet);
            Assert.AreEqual(9, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.00M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[0].OutcomeBet); // Tie

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[i].CoupBet.BetPlacement);
            }
        }

        [TestMethod]
        public void StrategyTest_TieAlways_3_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TieAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(32, score.UnitTieWin);

            Assert.AreEqual(32, score.UnitWin);
            Assert.AreEqual((decimal)32.0M, score.DollarWin);

            Assert.AreEqual(8, score.UnitLoss);
            Assert.AreEqual((decimal)8.00M, score.DollarLoss);

            Assert.AreEqual(12, score.UnitBet);
            Assert.AreEqual(12, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(24.00M, score.TotalScore);

            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[i].CoupBet.BetPlacement);
            }
        }

        [TestMethod]
        public void StrategyTest_RepeatLastDecision_1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Repeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1, score.DollarWin);

            Assert.AreEqual(7, score.UnitLoss);
            Assert.AreEqual((decimal)7, score.DollarLoss);

            Assert.AreEqual(8, score.UnitBet);
            Assert.AreEqual(8, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-6.00M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement); 
        }

        [TestMethod]
        public void StrategyTest_RepeatLastDecision_2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Repeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(3, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.95M, score.DollarWin);

            Assert.AreEqual(4, score.UnitLoss);
            Assert.AreEqual((decimal)4.00M, score.DollarLoss);

            Assert.AreEqual(8, score.UnitBet);
            Assert.AreEqual(8, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-0.05M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // previous was tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_RepeatLastDecision_3_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Repeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.90M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(6, score.UnitBet);
            Assert.AreEqual(6, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-0.10M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_RepeatLastDecision_4_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Repeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.90M, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.90M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[3].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_RepeatLastDecision_5_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Repeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.95M, score.DollarWin);

            Assert.AreEqual(4, score.UnitLoss);
            Assert.AreEqual((decimal)4.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.05M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[1].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_OppositeLastDecision_1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].CustomOpposite_Length = 1;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomOpposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(4, score.UnitPlayerWin);
            Assert.AreEqual(3, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(7, score.UnitWin);
            Assert.AreEqual((decimal)6.85M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(8, score.UnitBet);
            Assert.AreEqual(8, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(5.85M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_OppositeLastDecision_2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Opposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.90M, score.DollarWin);

            Assert.AreEqual(4, score.UnitLoss);
            Assert.AreEqual((decimal)4.00M, score.DollarLoss);

            Assert.AreEqual(8, score.UnitBet);
            Assert.AreEqual(8, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-0.10M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_OppositeLastDecision_3_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Opposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.90M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(6, score.UnitBet);
            Assert.AreEqual(6, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-0.10M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_OppositeLastDecision_4_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Opposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(2, score.UnitWin);
            Assert.AreEqual((decimal)1.95M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.05M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[3].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_OppositeLastDecision_5_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Opposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.90M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.90M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[1].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_TB4L_1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(3, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(5, score.UnitWin);
            Assert.AreEqual((decimal)4.90M, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(2.90M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // skip 2nd
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_TB4L_2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1.00M, score.DollarWin);

            Assert.AreEqual(6, score.UnitLoss);
            Assert.AreEqual((decimal)6.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-5.00M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // skip 2nd
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_TB4L_3_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(4, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-2.05M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // skip 2nd
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_TB4L_4_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(4, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-2.05M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[4].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_TB4L_5_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.90M, score.DollarWin);

            Assert.AreEqual(4, score.UnitLoss);
            Assert.AreEqual((decimal)4.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.10M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_OTB4L_1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.OTB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(2, score.UnitWin);
            Assert.AreEqual((decimal)1.95M, score.DollarWin);

            Assert.AreEqual(5, score.UnitLoss);
            Assert.AreEqual((decimal)5.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-3.05M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // skip 2nd
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_OTB4L_2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.OTB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(3, score.UnitPlayerWin);
            Assert.AreEqual(3, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(6, score.UnitWin);
            Assert.AreEqual((decimal)5.85M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(4.85M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // skip 2nd
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_OTB4L_3_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.OTB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.95M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(4, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.95M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // skip 1st
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // skip 2nd
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_OTB4L_4_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.OTB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.95M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(4, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.95M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[4].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_OTB4L_5_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.OTB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.90M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.90M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe1_Pattern1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(3, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)3.00M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(3.00M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe1_Pattern2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pbp");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(2, score.UnitWin);
            Assert.AreEqual((decimal)1.90M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(2, score.UnitBet);
            Assert.AreEqual(2, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.90M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe1_Pattern3_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pppppppppp");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(0, score.UnitBet);
            Assert.AreEqual(0, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.00M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe2_Pattern1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bpp");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(2, score.UnitBet);
            Assert.AreEqual(2, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-0.05M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe2_Pattern2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bppbbppp");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.95M, game.Results[9].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern1_IgnoreTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame(false);

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1.00M, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.00M, game.Results[7].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern1_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("bb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1.00M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(2, score.UnitBet);
            Assert.AreEqual(2, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern2_IgnoreTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame(false);

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pbbbbpp");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.95M, game.Results[7].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern3_IgnoreTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame(false);

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("b");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(3, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.85M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(4, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.85M, game.Results[7].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern3_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("b");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(2, score.UnitWin);
            Assert.AreEqual((decimal)1.90M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.90M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[3].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[4].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern4_IgnoreTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame(false);

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.95M, game.Results[7].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern4_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pb");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(0, score.UnitBet);
            Assert.AreEqual(0, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement);  // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);  // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);  // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);  // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[3].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[4].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern5_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pbt");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(0, score.UnitBet);
            Assert.AreEqual(0, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);  // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);  // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);  // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);  // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[3].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern6_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pbtt");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.T;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(8, score.UnitTieWin);

            Assert.AreEqual(8, score.UnitWin);
            Assert.AreEqual((decimal)8.00M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(8.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe3_Pattern7_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pbttt");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.95M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe2_Martingale_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe2();
            PrepareGame();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("p");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(6, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(6, score.UnitWin);
            Assert.AreEqual((decimal)5.70M, score.DollarWin);

            Assert.AreEqual(4, score.UnitLoss);
            Assert.AreEqual((decimal)4.00M, score.DollarLoss);

            Assert.AreEqual(10, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.70M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);

            Assert.AreEqual(1, game.Results[3].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[4].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[7].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[8].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[9].CoupBet.UnitBet);
        }

        [TestMethod]
        public void StrategyTest_CustomPattern_Shoe5_Martingale_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("b");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(4, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.80M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.80M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(1, game.Results[1].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[3].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[6].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[9].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[11].CoupBet.UnitBet);
        }

        [TestMethod]
        public void StrategyTest_PStreak1_Shoe1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.P;
            myStrategy[0].Streaks_Length = 1;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1.00M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(4, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-2.00M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_PStreak2_Shoe1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.P;
            myStrategy[0].Streaks_Length = 2;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[8].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.95M, game.Results[8].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_BStreaks1_Shoe3_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.B;
            myStrategy[0].Streaks_Length = 1;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(2, score.UnitWin);
            Assert.AreEqual((decimal)1.90M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.90M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_BStreaks1BetTie_Shoe3_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.B;
            myStrategy[0].Streaks_Length = 1;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.T;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(16, score.UnitTieWin);

            Assert.AreEqual(16, score.UnitWin);
            Assert.AreEqual((decimal)16.00M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(13.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Win, game.Results[2].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[6].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[7].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[8].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Win, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_BStreaks4_Shoe3_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.B;
            myStrategy[0].Streaks_Length = 4;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(0, score.UnitLoss);
            Assert.AreEqual((decimal)0.00M, score.DollarLoss);

            Assert.AreEqual(0, score.UnitBet);
            Assert.AreEqual(0, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_BStreaks4_Shoe3_IgnoreTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame(false);

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.B;
            myStrategy[0].Streaks_Length = 4;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.00M, game.Results[7].TotalDollarScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_TStreaks1_Shoe3_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.T;
            myStrategy[0].Streaks_Length = 1;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.T;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(16, score.UnitTieWin);

            Assert.AreEqual(16, score.UnitWin);
            Assert.AreEqual((decimal)16.00M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(15.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.T, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_TStreaks3_Shoe3_IncludeTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.T;
            myStrategy[0].Streaks_Length = 3;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.P;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(1, score.UnitBet);
            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomRepeatN3_Shoe4_WithTies_Martingale_Test() // we need to check with a progression because we're ignoring ties and want to make sure we're not betting on them
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            myStrategy[0].CustomRepeat_Length = 3;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomRepeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(8, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(8, score.UnitWin);
            Assert.AreEqual((decimal)7.60M, score.DollarWin);

            Assert.AreEqual(7, score.UnitLoss);
            Assert.AreEqual((decimal)7.00M, score.DollarLoss);

            Assert.AreEqual(15, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.60M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie

            Assert.AreEqual(1, game.Results[5].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[8].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[9].CoupBet.UnitBet);
            Assert.AreEqual(8, game.Results[10].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[11].CoupBet.UnitBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomRepeatN3_Shoe5_WithTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myStrategy[0].CustomRepeat_Length = 3;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomRepeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(3, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(5, score.UnitWin);
            Assert.AreEqual((decimal)4.85M, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(2.85M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomRepeatN4_Shoe5_NoTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame(false);

            myStrategy[0].CustomRepeat_Length = 4;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomRepeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)2.90M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(6, score.UnitBet);
            Assert.AreEqual(6, score.NumberBet);

            Assert.AreEqual(game.Results[9].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-0.10M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomOppositeN3_Shoe3_WithTies_Test() 
        {
            cards = GameBaccaratTest.Prepare1DeckShoe3();
            PrepareGame();

            myStrategy[0].CustomOpposite_Length = 3;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomOpposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(2, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(2, score.UnitWin);
            Assert.AreEqual((decimal)2.00M, score.DollarWin);

            Assert.AreEqual(1, score.UnitLoss);
            Assert.AreEqual((decimal)1.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(1.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[3].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement); // tie

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[4].OutcomeBet); // tie
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie
        }

        [TestMethod]
        public void StrategyTest_CustomOppositeN4_Shoe4_NoTies_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame(false);

            myStrategy[0].CustomOpposite_Length = 4;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomOpposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1.00, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2.00M, score.DollarLoss);

            Assert.AreEqual(3, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[6].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_CustomOppositeN3_Shoe5_WithTies_Martingale_Test() // we need to check with a progression because we're ignoring ties and want to make sure we're not betting on them
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            myStrategy[0].CustomOpposite_Length = 3;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomOpposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(16, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(17, score.UnitWin);
            Assert.AreEqual((decimal)16.20M, score.DollarWin);

            Assert.AreEqual(16, score.UnitLoss);
            Assert.AreEqual((decimal)16.00M, score.DollarLoss);

            Assert.AreEqual(33, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.20M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement); // tie
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie

            Assert.AreEqual(1, game.Results[3].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[5].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[6].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[7].CoupBet.UnitBet);
            Assert.AreEqual(8, game.Results[8].CoupBet.UnitBet);
            Assert.AreEqual(16, game.Results[9].CoupBet.UnitBet); // tie
            Assert.AreEqual(16, game.Results[10].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[11].CoupBet.UnitBet);
        }

        [TestMethod]
        public void StrategyTest_FollowN1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_TerribleTwos();
            PrepareGame();

            myStrategy[0].Follow_Length = 1;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Follow;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(3, score.UnitPlayerWin);
            Assert.AreEqual(2, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(5, score.UnitWin);
            Assert.AreEqual((decimal)4.90M, score.DollarWin);

            Assert.AreEqual(6, score.UnitLoss);
            Assert.AreEqual((decimal)6.00M, score.DollarLoss);

            Assert.AreEqual(11, score.UnitBet);
            Assert.AreEqual(11, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-1.10M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_FollowN2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_TerribleTwos();
            PrepareGame();

            myStrategy[0].Follow_Length = 2;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Follow;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00M, score.DollarWin);

            Assert.AreEqual(9, score.UnitLoss);
            Assert.AreEqual((decimal)9.00M, score.DollarLoss);

            Assert.AreEqual(9, score.UnitBet);
            Assert.AreEqual(9, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-9.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);
        }

        [TestMethod]
        public void StrategyTest_FollowN2_Shoe4_Test() // should not bet ties
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myStrategy[0].Follow_Length = 2;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Follow;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(1, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)0.95M, score.DollarWin);

            Assert.AreEqual(7, score.UnitLoss);
            Assert.AreEqual((decimal)7.00M, score.DollarLoss);

            Assert.AreEqual(8, score.UnitBet);
            Assert.AreEqual(4, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-6.05M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie

            Assert.AreEqual(1, game.Results[7].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[8].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[9].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[10].CoupBet.UnitBet);
            Assert.AreEqual(8, game.Results[11].CoupBet.UnitBet);
        }

        [TestMethod]
        public void StrategyTest_FollowN2_Shoe5_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();

            myStrategy[0].Follow_Length = 2;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Follow;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(3, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(3, score.UnitWin);
            Assert.AreEqual((decimal)3.00M, score.DollarWin);

            Assert.AreEqual(8, score.UnitLoss);
            Assert.AreEqual((decimal)8.00M, score.DollarLoss);

            Assert.AreEqual(11, score.UnitBet);
            Assert.AreEqual(6, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.P, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[9].OutcomeBet); // tie

            Assert.AreEqual(1, game.Results[5].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[6].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[7].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[8].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[9].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[10].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[11].CoupBet.UnitBet);
        }

        [TestMethod]
        public void StrategyTest_FollowN3_Shoe4_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe4();
            PrepareGame();

            myStrategy[0].Follow_Length = 3;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Follow;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            myBetProgression[0].BetProgressionType = BetProgressionTypes.Martingale;

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(4, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(4, score.UnitWin);
            Assert.AreEqual((decimal)3.80M, score.DollarWin);

            Assert.AreEqual(3, score.UnitLoss);
            Assert.AreEqual((decimal)3.00M, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[11].TotalDollarScore, score.TotalScore);
            Assert.AreEqual(0.80M, score.TotalScore);

            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[0].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[1].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[2].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[3].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[4].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[5].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[6].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.None, game.Results[7].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[8].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[9].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[10].CoupBet.BetPlacement);
            Assert.AreEqual(OutcomesBaccaratCoup.B, game.Results[11].CoupBet.BetPlacement);

            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[11].OutcomeBet); // tie

            Assert.AreEqual(1, game.Results[8].CoupBet.UnitBet);
            Assert.AreEqual(2, game.Results[9].CoupBet.UnitBet);
            Assert.AreEqual(4, game.Results[10].CoupBet.UnitBet);
            Assert.AreEqual(1, game.Results[11].CoupBet.UnitBet);
        }

        [TestMethod]
        public void StrategyTest_WhenCustomPatternIsChangedCustomLengthIsAlsoCorrectlyChanged_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllB();
            PrepareGame();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("p");
            Assert.AreEqual(1, myStrategy[0].CustomPattern_Length);

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("pbp");
            Assert.AreEqual(3, myStrategy[0].CustomPattern_Length);
        }
    }
}
