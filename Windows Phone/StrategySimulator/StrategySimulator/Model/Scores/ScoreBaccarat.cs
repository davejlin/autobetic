using StrategySimulator.Model.Results;
using StrategySimulator.Utilities;

namespace StrategySimulator.Model.Scores
{
    public class ScoreBaccarat : Score
    {
        public int NumberBet { get; set; }

        public int NumberPlayerWin { get; set; }
        public int NumberBankerWin { get; set; }
        public int NumberTieWin { get; set; }

        public int UnitPlayerWin { get; set; }
        public int UnitBankerWin { get; set; }
        public int UnitTieWin { get; set; }

        public int NumberPlayerLoss { get; set; }
        public int NumberBankerLoss { get; set; }
        public int NumberTieLoss { get; set; }

        public int UnitPlayerLoss { get; set; }
        public int UnitBankerLoss { get; set; }
        public int UnitTieLoss { get; set; }

        public decimal MaxWin { get; set; }
        public decimal MaxLoss { get; set; }

        private decimal ThisWin;
        private decimal ThisLoss;

        public ScoreBaccarat() : base()
        {
            NumberBet = 0;

            NumberPlayerWin = 0;
            NumberBankerWin = 0;
            NumberTieWin = 0;

            UnitPlayerWin = 0;
            UnitBankerWin = 0;
            UnitTieWin    = 0;

            NumberPlayerLoss = 0;
            NumberBankerLoss = 0;
            NumberTieLoss = 0;

            UnitPlayerLoss = 0;
            UnitBankerLoss = 0;
            UnitTieLoss = 0;
        }

        public void ScoreBankerWin(int aUnitBet)
        {
            NumberBet++;
            NumberBankerWin++;

            UnitBet += aUnitBet;
            UnitWin += aUnitBet;
            UnitBankerWin += aUnitBet;

            ThisWin = (decimal)Constants.UnitBankerWinPayoff * aUnitBet;

            DollarWin += ThisWin;
            TotalScore += ThisWin;

            SetMaxWin();
        }

        public void ScorePlayerWin(int aUnitBet)
        {
            NumberBet++;
            NumberPlayerWin++;

            UnitBet += aUnitBet;
            UnitWin += aUnitBet;
            UnitPlayerWin += aUnitBet;

            ThisWin = (decimal) Constants.UnitPlayerWinPayoff * aUnitBet;

            DollarWin += ThisWin;
            TotalScore += ThisWin;

            SetMaxWin();
        }

        public void ScoreTieWin(int aUnitBet)
        {
            NumberBet++;
            NumberTieWin++;

            UnitBet += aUnitBet;
            UnitWin += Constants.TiePayoff * aUnitBet;
            UnitTieWin += Constants.TiePayoff * aUnitBet;

            ThisWin = (decimal) Constants.TiePayoff * aUnitBet;

            DollarWin += ThisWin;
            TotalScore += ThisWin;

            SetMaxWin();
        }

        public void ScoreLoss(int aUnitBet, OutcomesBaccaratCoup betPlacement)
        {
            NumberBet++;
            UnitBet += aUnitBet;
            UnitLoss += aUnitBet;

            ThisLoss = (decimal) Constants.UnitLossPayoff * aUnitBet;

            DollarLoss += ThisLoss;
            TotalScore -= ThisLoss;

            switch (betPlacement)
            {
                case OutcomesBaccaratCoup.B:
                    NumberBankerLoss++;
                    UnitBankerLoss += aUnitBet;
                    break;
                case OutcomesBaccaratCoup.P:
                    NumberPlayerLoss++;
                    UnitPlayerLoss += aUnitBet;
                    break;
                case OutcomesBaccaratCoup.T:
                    NumberTieLoss++;
                    UnitTieLoss += aUnitBet;
                    break;
                default:
                    break;
            }

            SetMaxLoss();
        }

        private void SetMaxWin()
        {
            if (ThisWin > MaxWin)
                MaxWin = ThisWin;
        }

        private void SetMaxLoss()
        {
            if (ThisLoss > MaxLoss)
                MaxLoss = ThisLoss;
        }
    }
}
