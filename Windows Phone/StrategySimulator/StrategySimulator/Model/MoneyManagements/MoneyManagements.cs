
namespace StrategySimulator.Model.MoneyManagements
{
    public class MoneyManagements
    {
        public int ShoeStopLoss { get; set; }
        public int ShoeTakeProfit { get; set; }
        public int Bankroll { get; set; }
        public bool BankrollBust { get; set; }

        public MoneyManagementShoe getMoneyManagementShoe(bool getShoeStopLoss, bool getShoeTakeProfit)
        {
            if (getShoeStopLoss && getShoeTakeProfit)
                return new MoneyManagementShoe(CheckShoeStopLossAndTakeProfit);

            if (getShoeStopLoss)
                return new MoneyManagementShoe(CheckShoeStopLoss);

            if (getShoeTakeProfit)
                return new MoneyManagementShoe(CheckShoeTakeProfit);

            return new MoneyManagementShoe(NoMoneyManagementShoe);
        }

        public MoneyManagementBankroll getMoneyManagementBankroll(bool useBankroll)
        {
            BankrollBust = false;
            if (useBankroll)
                return new MoneyManagementBankroll(CheckBankroll);

            return new MoneyManagementBankroll(NoMoneyManagementBankroll);
        }

        public bool NoMoneyManagementShoe(decimal totalScore)
        {
            return false;
        }

        public bool CheckShoeStopLossAndTakeProfit(decimal shoeTotalScore)
        {
            if (CheckShoeStopLoss(shoeTotalScore) || CheckShoeTakeProfit(shoeTotalScore))
                return true;

            return false;
        }

        public bool CheckShoeStopLoss(decimal shoeTotalScore)
        {
            if (shoeTotalScore <= -ShoeStopLoss)
                return true;

            return false;
        }

        public bool CheckShoeTakeProfit(decimal shoeTotalScore)
        {
            if (shoeTotalScore >= ShoeTakeProfit)
                return true;

            return false;
        }

        public bool NoMoneyManagementBankroll(decimal totalScore, int nextBet)
        {
            return false;
        }

        public bool CheckBankroll(decimal totalScore, int nextBet)
        {
            if (Bankroll + (totalScore - nextBet) >= 0)
                return false;

            BankrollBust = true;
            return true;
        }

    }
}
