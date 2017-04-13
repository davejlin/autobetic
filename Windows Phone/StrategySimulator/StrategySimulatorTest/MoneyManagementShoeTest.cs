using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.MoneyManagements;

namespace StrategySimulatorTest
{
    [TestClass]
    public class MoneyManagementShoeTest
    {
        decimal shoeTotalScore;
        bool actualResult;

        MoneyManagementShoe moneyManagement;
        MoneyManagements myMoneyManagement;

        [TestInitialize]
        public void init()
        {
            shoeTotalScore = 0;
            myMoneyManagement = new MoneyManagements();
        }

        [TestMethod]
        public void MoneyManagementTest_CheckShoeStopLoss_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementShoe(true, false);

            myMoneyManagement.ShoeStopLoss = 12;
            shoeTotalScore = -5M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);

            myMoneyManagement.ShoeStopLoss = 12;
            shoeTotalScore = -13M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void MoneyManagementTest_NoShoeStopLoss_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementShoe(false, true);

            myMoneyManagement.ShoeStopLoss = 12;
            shoeTotalScore = -12M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void MoneyManagementTest_CheckShoeTakeProfit_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementShoe(false, true);

            myMoneyManagement.ShoeTakeProfit = 16;
            shoeTotalScore = 12M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);

            myMoneyManagement.ShoeTakeProfit = 16;
            shoeTotalScore = 16M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void MoneyManagementTest_NoTakeProfit_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementShoe(true, false);

            myMoneyManagement.ShoeTakeProfit = 10;
            shoeTotalScore = 11M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void MoneyManagementTest_CheckShoeStopLossAndTakeProfit_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementShoe(true, true);

            myMoneyManagement.ShoeStopLoss = 10;
            myMoneyManagement.ShoeTakeProfit = 10;
            shoeTotalScore = -5M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);

            shoeTotalScore = -11M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsTrue(actualResult);

            shoeTotalScore = 11M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsTrue(actualResult);
        }

        [TestMethod]
        public void MoneyManagementTest_NoShoeMoneyManagement_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementShoe(false, false);

            myMoneyManagement.ShoeStopLoss = 10;
            myMoneyManagement.ShoeTakeProfit = 10;
            shoeTotalScore = -5M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);

            shoeTotalScore = -11M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);

            shoeTotalScore = 11M;

            actualResult = moneyManagement(shoeTotalScore);
            Assert.IsFalse(actualResult);
        }
    }
}
