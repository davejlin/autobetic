using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using StrategySimulator.Model.MoneyManagements;

namespace StrategySimulatorTest
{
    [TestClass]
    public class MoneyManagementBankrollTest
    {
        decimal sessionTotalScore;
        int nextBet;
        bool actualResult;

        MoneyManagementBankroll moneyManagement;
        MoneyManagements myMoneyManagement;

        [TestInitialize]
        public void init()
        {
            sessionTotalScore = 0;
            nextBet = 0;
            myMoneyManagement = new MoneyManagements();
        }

        [TestMethod]
        public void MoneyManagementTest_NoBankroll_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementBankroll(false);

            myMoneyManagement.Bankroll = 50;
            sessionTotalScore = -45M;
            nextBet = 10;

            actualResult = moneyManagement(sessionTotalScore, nextBet);
            Assert.IsFalse(actualResult);
        }

        [TestMethod]
        public void MoneyManagementTest_Bankroll_Test()
        {
            moneyManagement = myMoneyManagement.getMoneyManagementBankroll(true);

            myMoneyManagement.Bankroll = 50;
            sessionTotalScore = -45M;
            nextBet = 5;

            actualResult = moneyManagement(sessionTotalScore, nextBet);
            Assert.IsFalse(actualResult);

            sessionTotalScore = -45M;
            nextBet = 6;

            actualResult = moneyManagement(sessionTotalScore, nextBet);
            Assert.IsTrue(actualResult);

            myMoneyManagement.BankrollBust = false; // reset

            sessionTotalScore = 0;
            nextBet = 50;

            actualResult = moneyManagement(sessionTotalScore, nextBet);
            Assert.IsFalse(actualResult);

            sessionTotalScore = 0;
            nextBet = 51;

            actualResult = moneyManagement(sessionTotalScore, nextBet);
            Assert.IsTrue(actualResult);
        }
    }
}
