using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Results;
using StrategySimulator.Utilities;

namespace StrategySimulatorTest
{
    [TestClass]
    public class BetProgressionTest
    {
        BetProgressions myBetProgression;

        [TestInitialize]
        public void init()
        {
            myBetProgression = new BetProgressions();
        }

        [TestMethod]
        public void BetProgressionTest_ResetBaseUnit_Test()
        {
            myBetProgression.BetLastUnit = 10;
            int expectedUnitBetAfterReset = 1;
            myBetProgression.ResetBetLastUnitToBaseUnit();
            Assert.AreEqual(expectedUnitBetAfterReset, myBetProgression.BetLastUnit);
        }

        [TestMethod]
        public void BetProgressionTest_MaxBetIsNotExceeded_Test()
        {
            myBetProgression.BetLastUnit = 10;
            myBetProgression.BetMaxUnit = 1000;
            int returnedBet = myBetProgression.CheckMaxBetAndResetIfNecessary(100);
            Assert.AreEqual(100, returnedBet);

            returnedBet = myBetProgression.CheckMaxBetAndResetIfNecessary(1001);
            Assert.AreEqual(10, returnedBet);
        }

        [TestMethod]
        public void BetProgressionTest_BetIsResetToBaseAfterProgressionMaxWhenResetIsEnabled_Test()
        {
            myBetProgression.ResetAfterProgressionMax = true;
            myBetProgression.ReachedProgressionMax = true;

            myBetProgression.BetBaseUnit = 2;
            myBetProgression.BetLastUnit = 5;
            myBetProgression.BetMaxUnit = 10;

            myBetProgression.CustomBetProgressionIndex = 10;

            int returnedBet = myBetProgression.CheckMaxBetAndResetIfNecessary(11);

            Assert.AreEqual(myBetProgression.BetBaseUnit, returnedBet);
            Assert.AreEqual(0, myBetProgression.CustomBetProgressionIndex);
            Assert.IsFalse(myBetProgression.ReachedProgressionMax);
        }

        [TestMethod]
        public void BetProgressionTest_BetIsLastUnitBetAfterProgressionMaxWhenResetIsDisabled_Test()
        {
            myBetProgression.ResetAfterProgressionMax = false;
            myBetProgression.ReachedProgressionMax = true;

            myBetProgression.BetBaseUnit = 2;
            myBetProgression.BetLastUnit = 5;
            myBetProgression.BetMaxUnit = 10;

            myBetProgression.CustomBetProgressionIndex = 10;

            int returnedBet = myBetProgression.CheckMaxBetAndResetIfNecessary(11);

            Assert.AreEqual(myBetProgression.BetLastUnit, returnedBet);
            Assert.AreEqual(10, myBetProgression.CustomBetProgressionIndex);
            Assert.IsTrue(myBetProgression.ReachedProgressionMax);
        }

        [TestMethod]
        public void BetProgressionTest_None_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.None;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(0, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(0, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(0, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(0, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_FlatBet_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.FlatBet;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_Martingale_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.Martingale;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Martingale_Multiplier3_Test()
        {
            myBetProgression.MartingaleMultiplier = 3;
            myBetProgression.BetProgressionType = BetProgressionTypes.Martingale;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(9, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(27, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(27, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Martingale_PositivePolarity_Test()
        {
            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();
            myBetProgression.BetProgressionType = BetProgressionTypes.Martingale;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Martingale_DoNotResetProgressionAfterMax_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.Martingale;

            myBetProgression.BetMaxUnit = 20;
            myBetProgression.ResetAfterProgressionMax = false;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(16, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(16, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(16, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Martingale_ResetProgressionAfterMax_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.Martingale;

            myBetProgression.BetMaxUnit = 20;
            myBetProgression.ResetAfterProgressionMax = true;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(16, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Custom_PositivePolarity_Test()
        {
            string inputString = "4.1.2.3.5";
            myBetProgression.CustomBetProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();
            myBetProgression.BetProgressionType = BetProgressionTypes.Custom;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Custom_DoNotResetProgressionAfterMax_Test()
        {
            string inputString = "4.1.2.3.5.8.13";
            myBetProgression.CustomBetProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Custom;

            myBetProgression.ResetAfterProgressionMax = false;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(13, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(13, nextBet);

        }

        [TestMethod]
        public void BetProgressionTest_Custom_ResetProgressionAfterMax_Test()
        {
            string inputString = "4.2.3";
            myBetProgression.CustomBetProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Custom;

            myBetProgression.ResetAfterProgressionMax = true;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_Custom_ProgressionItemExceedsMax_Reset_Test()
        {
            string inputString = "10.100.1000.2000.5000";
            myBetProgression.CustomBetProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Custom;

            myBetProgression.BetMaxUnit = 1000;

            myBetProgression.ResetAfterProgressionMax = true;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(100, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(100, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_Custom_ProgressionItemExceedsMax_DoNotReset_Test()
        {
            string inputString = "10.100.1000.2000.5000";
            myBetProgression.CustomBetProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Custom;

            myBetProgression.BetMaxUnit = 1000;

            myBetProgression.ResetAfterProgressionMax = false;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(100, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1000, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_DAlembert_U1D1_Test()
        {
            myBetProgression.DAlembertStart = 1;
            myBetProgression.DAlembertUp = 1;
            myBetProgression.DAlemberDown = 1;

            myBetProgression.BetProgressionType = BetProgressionTypes.DAlembert;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_DAlembert_U1D2_Test()
        {
            myBetProgression.DAlembertStart = 1;
            myBetProgression.DAlembertUp = 1;
            myBetProgression.DAlemberDown = 2;

            myBetProgression.BetProgressionType = BetProgressionTypes.DAlembert;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_DAlembert_U2D1_Test()
        {
            myBetProgression.DAlembertStart = 1;
            myBetProgression.DAlembertUp = 2;
            myBetProgression.DAlemberDown = 1;

            myBetProgression.BetProgressionType = BetProgressionTypes.DAlembert;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(6, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(9, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(12, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(14, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(13, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(12, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(11, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_DAlembert_U1D2_Positive_Test()
        {
            myBetProgression.DAlembertStart = 1;
            myBetProgression.DAlembertUp = 1;
            myBetProgression.DAlemberDown = 2;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            myBetProgression.BetProgressionType = BetProgressionTypes.DAlembert;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_DAlembert_U1D1_Start100Test()
        {
            myBetProgression.DAlembertStart = 100;
            myBetProgression.DAlembertUp = 1;
            myBetProgression.DAlemberDown = 1;

            myBetProgression.BetProgressionType = BetProgressionTypes.DAlembert;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(100, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(101, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(102, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(101, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(102, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(101, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(100, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(99, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(98, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(99, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(100, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(99, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(100, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(99, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(98, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(97, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_FibonnaciD1_Test()
        {
            myBetProgression.FibonacciDown = 1;

            myBetProgression.BetProgressionType = BetProgressionTypes.Fibonacci;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_FibonnaciD2_Test()
        {
            myBetProgression.FibonacciDown = 2;

            myBetProgression.BetProgressionType = BetProgressionTypes.Fibonacci;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_FibonnaciD3_Test()
        {
            myBetProgression.FibonacciDown = 3;

            myBetProgression.BetProgressionType = BetProgressionTypes.Fibonacci;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_FibonnaciD2_Positive_Test()
        {
            myBetProgression.FibonacciDown = 2;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            myBetProgression.BetProgressionType = BetProgressionTypes.Fibonacci;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_Labouchere_Test()
        {
            string inputString = "1.2.3.4.5.6";
            myBetProgression.LabouchereProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Labouchere;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(9, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(9, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(13, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(13, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(15, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(7, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_Labouchere_Positive_Test()
        {
            string inputString = "1.2.4.6";
            myBetProgression.LabouchereProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Labouchere;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(6, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(10, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(8, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(7, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(8, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_Parlay_Positive_Test() // Parlay (e.g. Paroli) is just a 1.2.4 positive progression 
        {
            string inputString = "1.2.4";
            myBetProgression.ParlayProgression = Utilities.ParseBetProgressionString(inputString);

            myBetProgression.BetProgressionType = BetProgressionTypes.Parlay;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Push);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss);
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win);
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_OscarsGrind_Positive_Profit1_1_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.OscarsGrind;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            myBetProgression.OscarsGrindProfitPerCycle = 1;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None); // 0
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -1
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -2
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -1
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +1 cycle won: restart new cycle
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +1 cycle won: restart new cycle
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -1 cycle won: restart new cycle
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // 0 : next bet should be 1, not 2, since we only want to win our specified profit of +1 per cycle
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -1
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -2
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -3
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -2
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // 0 : next bet should be 1, not 2, since we only want to win our specified profit of +1 per cycle
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -1
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // 0
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // 0  // +1 cycle won: restart new cycle
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_OscarsGrind_Positive_Profit1_2_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.OscarsGrind;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            myBetProgression.OscarsGrindProfitPerCycle = 1;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None); // 0
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -1
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -2
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -3
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -4
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -5
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -6
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -7
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -8
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -9
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -10
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -9
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -7
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -10
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -13
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -10
            Assert.AreEqual(4, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -6
            Assert.AreEqual(5, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -1 : next bet should be 2 to make +1 profit to end cycle
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -3
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -5
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -3
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // 0
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +1 : cycle ends
            Assert.AreEqual(1, nextBet);
        }

        [TestMethod]
        public void BetProgressionTest_OscarsGrind_Positive_Profit4_Test()
        {
            myBetProgression.BetProgressionType = BetProgressionTypes.OscarsGrind;

            myBetProgression.ProgressionPolarity = BetProgressionPolarity.Positive;
            myBetProgression.LoadOutcomeArray();

            myBetProgression.OscarsGrindProfitPerCycle = 4;

            int nextBet;
            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.None); // 0
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +1
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +3 : next bet is 1 to win +4 to end cycle
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // +2
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // +1
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // +0
            Assert.AreEqual(1, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +1
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -1
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Loss); // -3
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // -1
            Assert.AreEqual(3, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +2 : next bet is 2 to win +4 to end cycle
            Assert.AreEqual(2, nextBet);

            nextBet = myBetProgression.BetProgressionCore(OutcomesLastCoupBet.Win); // +4 : profit goal achieved, reset bet to base
            Assert.AreEqual(1, nextBet);

        }
    }
}
