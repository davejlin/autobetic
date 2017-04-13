using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Scores;
using StrategySimulator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategySimulatorTest
{
    [TestClass]
    public class ScoreTest
    {
        protected ScoreBaccarat score;
        int unitBet = 2;

        [TestInitialize]
        public void init()
        {
            score = new ScoreBaccarat();

            Assert.AreEqual(0, score.NumberBet);
            AssertInitialValuesWin();
            AssertInitialValuesLoss();
        }

        [TestMethod]
        public void ScoreTest_BankerWin_Test()
        {
            score.ScoreBankerWin(unitBet);

            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(0, score.NumberPlayerWin);
            Assert.AreEqual(1, score.NumberBankerWin);
            Assert.AreEqual(0, score.NumberTieWin);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(unitBet, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            AssertInitialValuesLoss();
        }

        [TestMethod]
        public void ScoreTest_PlayerWin_Test()
        {
            score.ScorePlayerWin(unitBet);

            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(1, score.NumberPlayerWin);
            Assert.AreEqual(0, score.NumberBankerWin);
            Assert.AreEqual(0, score.NumberTieWin);

            Assert.AreEqual(unitBet, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);

            AssertInitialValuesLoss();
        }

        [TestMethod]
        public void ScoreTest_TieWin_Test()
        {
            score.ScoreTieWin(unitBet);

            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(0, score.NumberPlayerWin);
            Assert.AreEqual(0, score.NumberBankerWin);
            Assert.AreEqual(1, score.NumberTieWin);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(unitBet * Constants.TiePayoff, score.UnitTieWin);

            AssertInitialValuesLoss();
        }

        [TestMethod]
        public void ScoreTest_BankerLoss_Test()
        {
            score.ScoreLoss(unitBet,OutcomesBaccaratCoup.B);

            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(0, score.NumberPlayerLoss);
            Assert.AreEqual(1, score.NumberBankerLoss);
            Assert.AreEqual(0, score.NumberTieLoss);

            Assert.AreEqual(0, score.UnitPlayerLoss);
            Assert.AreEqual(unitBet, score.UnitBankerLoss);
            Assert.AreEqual(0, score.UnitTieLoss);

            AssertInitialValuesWin();
        }

        [TestMethod]
        public void ScoreTest_PlayerLoss_Test()
        {
            score.ScoreLoss(unitBet, OutcomesBaccaratCoup.P);

            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(1, score.NumberPlayerLoss);
            Assert.AreEqual(0, score.NumberBankerLoss);
            Assert.AreEqual(0, score.NumberTieLoss);

            Assert.AreEqual(unitBet, score.UnitPlayerLoss);
            Assert.AreEqual(0, score.UnitBankerLoss);
            Assert.AreEqual(0, score.UnitTieLoss);

            AssertInitialValuesWin();
        }

        [TestMethod]
        public void ScoreTest_TieLoss_Test()
        {
            score.ScoreLoss(unitBet, OutcomesBaccaratCoup.T);

            Assert.AreEqual(1, score.NumberBet);

            Assert.AreEqual(0, score.NumberPlayerLoss);
            Assert.AreEqual(0, score.NumberBankerLoss);
            Assert.AreEqual(1, score.NumberTieLoss);

            Assert.AreEqual(0, score.UnitPlayerLoss);
            Assert.AreEqual(0, score.UnitBankerLoss);
            Assert.AreEqual(unitBet, score.UnitTieLoss);

            AssertInitialValuesWin();
        }

        [TestMethod]
        public void ScoreTest_MaxWinLoss_Test()
        {
            score.ScoreBankerWin(1);
            score.ScoreBankerWin(2);
            score.ScorePlayerWin(10);
            score.ScoreLoss(20, OutcomesBaccaratCoup.P);
            score.ScoreLoss(25, OutcomesBaccaratCoup.B);
            score.ScoreLoss(10, OutcomesBaccaratCoup.T);

            Assert.AreEqual(10, score.MaxWin);
            Assert.AreEqual(25, score.MaxLoss);

            score.ScoreBankerWin(100); // 0.95x100=95 w/ banker-payoff=0.95
            Assert.AreEqual(95, score.MaxWin);

            score.ScoreTieWin(50); // 8x50=400 w/ tie-payoff=8
            Assert.AreEqual(400, score.MaxWin);
        }

        private void AssertInitialValuesWin()
        {
            Assert.AreEqual(0, score.NumberPlayerWin);
            Assert.AreEqual(0, score.NumberBankerWin);
            Assert.AreEqual(0, score.NumberTieWin);

            Assert.AreEqual(0, score.UnitPlayerWin);
            Assert.AreEqual(0, score.UnitBankerWin);
            Assert.AreEqual(0, score.UnitTieWin);
        }

        private void AssertInitialValuesLoss()
        {
            Assert.AreEqual(0, score.NumberPlayerLoss);
            Assert.AreEqual(0, score.NumberBankerLoss);
            Assert.AreEqual(0, score.NumberTieLoss);

            Assert.AreEqual(0, score.UnitPlayerLoss);
            Assert.AreEqual(0, score.UnitBankerLoss);
            Assert.AreEqual(0, score.UnitTieLoss);
        }
    }
}
