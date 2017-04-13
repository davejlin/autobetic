using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;

namespace StrategySimulatorTest
{
    [TestClass]
    public class MoneyManagementBankrollStrategyTest : StrategyTestBase
    {
        public void MoneyManagementInitialize()
        {
            mmBankroll = myMoneyManagement.getMoneyManagementBankroll(true);
            myMoneyManagement.Bankroll = 5;
        }

        [TestMethod]
        public void MoneyManagementBankroll_BankerAlways_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllP();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.BankerAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
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

            Assert.AreEqual(game.Results[4].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, game.Results[4].TotalDollarScore);

            for (int i = 0; i < 5; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 5; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_BankerAlways_ProgressionResetTest()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllP();
            PrepareGame();
            MoneyManagementInitialize();

            myMoneyManagement.Bankroll = 9;

            myBetProgression[0].CustomBetProgression = Utilities.ParseBetProgressionString("1.2.3.4");
            myBetProgression[0].ResetAfterProgressionMax = true;
            myBetProgression[0].BetProgressionType = BetProgressionTypes.Custom;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.BankerAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0, score.DollarWin);

            Assert.AreEqual(6, score.UnitLoss);
            Assert.AreEqual((decimal)6, score.DollarLoss);

            Assert.AreEqual(6, score.UnitBet);
            Assert.AreEqual(3, score.NumberBet);

            Assert.AreEqual(game.Results[2].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-6.00M, score.TotalScore);

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 3; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_PlayerAlways_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllB();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.PlayerAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
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

            Assert.AreEqual(game.Results[4].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            for (int i = 0; i < 5; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 5; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_TieAlways_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllB();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TieAlways;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
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

            Assert.AreEqual(game.Results[4].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            for (int i = 0; i < 5; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 5; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_RepeatLastDecision_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Repeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1, score.DollarWin);

            Assert.AreEqual(6, score.UnitLoss);
            Assert.AreEqual((decimal)6, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[1].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Win, game.Results[2].OutcomeBet);

            for (int i = 3; i < 8; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[8].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_OppositeLastDecision_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllB();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Opposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
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
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);

            for (int i = 1; i < 6; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 6; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_TB4L_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_TerribleTwos();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.TB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00, score.DollarWin);

            Assert.AreEqual(5, score.UnitLoss);
            Assert.AreEqual((decimal)5, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[6].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[1].OutcomeBet);

            for (int i = 2; i < 7; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 7; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_OTB4L_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllP();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.OTB4L;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00, score.DollarWin);

            Assert.AreEqual(5, score.UnitLoss);
            Assert.AreEqual((decimal)5, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[6].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[1].OutcomeBet);

            for (int i = 2; i < 7; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 7; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_Custom_1_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllP();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("p");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00, score.DollarWin);

            Assert.AreEqual(5, score.UnitLoss);
            Assert.AreEqual((decimal)5, score.DollarLoss);

            Assert.AreEqual(5, score.UnitBet);
            Assert.AreEqual(5, score.NumberBet);

            Assert.AreEqual(game.Results[5].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);

            for (int i = 1; i < 6; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 6; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_Custom_2_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe5();
            PrepareGame();
            MoneyManagementInitialize();
            myMoneyManagement.Bankroll = 2;

            myStrategy[0].CustomPattern_Pattern = Utilities.ParseBetPlacementString("b");
            myStrategy[0].CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomPattern;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2, score.DollarLoss);

            Assert.AreEqual(2, score.UnitBet);
            Assert.AreEqual(2, score.NumberBet);

            Assert.AreEqual(game.Results[6].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-2.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Push, game.Results[1].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[2].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[3].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[4].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[5].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[6].OutcomeBet);

            for (int i = 7; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_Streaks_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllP();
            PrepareGame();
            MoneyManagementInitialize();
            myMoneyManagement.Bankroll = 2;

            myStrategy[0].Streaks_Target = OutcomesBaccaratCoup.P;
            myStrategy[0].Streaks_Length = 3;
            myStrategy[0].Streaks_BetPlacement = OutcomesBaccaratCoup.B;

            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Streaks;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(0, score.UnitWin);
            Assert.AreEqual((decimal)0.00, score.DollarWin);

            Assert.AreEqual(2, score.UnitLoss);
            Assert.AreEqual((decimal)2, score.DollarLoss);

            Assert.AreEqual(2, score.UnitBet);
            Assert.AreEqual(2, score.NumberBet);

            Assert.AreEqual(game.Results[4].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-2.00M, score.TotalScore);

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);

            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[3].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[4].OutcomeBet);

            for (int i = 5; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }


        [TestMethod]
        public void MoneyManagementBankroll_CustomRepeat_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe1();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].CustomRepeat_Length = 1; // N=1 : same as normal Repeat for shoes without ties
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomRepeat;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();

            strategy(game.Results, score, score.TotalScore, mmShoe, mmBankroll);

            Assert.AreEqual(1, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            Assert.AreEqual(1, score.UnitWin);
            Assert.AreEqual((decimal)1, score.DollarWin);

            Assert.AreEqual(6, score.UnitLoss);
            Assert.AreEqual((decimal)6, score.DollarLoss);

            Assert.AreEqual(7, score.UnitBet);
            Assert.AreEqual(7, score.NumberBet);

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[1].OutcomeBet);
            Assert.AreEqual(OutcomesLastCoupBet.Win, game.Results[2].OutcomeBet);

            for (int i = 3; i < 8; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[8].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_CustomOpposite_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_AllB();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].CustomOpposite_Length = 1; // N=1 : same as normal Repeat for shoes without ties
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.CustomOpposite;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
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
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[0].OutcomeBet);

            for (int i = 1; i < 6; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 6; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }

        [TestMethod]
        public void MoneyManagementBankroll_Follow_Test()
        {
            cards = GameBaccaratTest.Prepare1DeckShoe_TerribleTwos();
            PrepareGame();
            MoneyManagementInitialize();

            myStrategy[0].Follow_Length = 2;
            myStrategy[0].StrategyBaccaratType = StrategiesBaccaratTypes.Follow;
            strategyMultiWrapper.MyStrategy[0] = myStrategy[0];
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

            Assert.AreEqual(game.Results[7].TotalDollarScore, score.TotalScore);
            Assert.AreEqual((decimal)-5.00M, score.TotalScore);

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);

            for (int i = 3; i < 8; i++)
                Assert.AreEqual(OutcomesLastCoupBet.Loss, game.Results[i].OutcomeBet);

            for (int i = 8; i < 12; i++)
                Assert.AreEqual(OutcomesLastCoupBet.None, game.Results[i].OutcomeBet);
        }
    }
}
