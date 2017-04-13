
namespace StrategySimulator.Model.Scores
{
    public class Score
    {
        public int UnitBet { get; set; }
        public int UnitWin { get; set; }
        public int UnitLoss { get; set; }

        public decimal DollarWin { get; set; }
        public decimal DollarLoss { get; set; }

        public decimal TotalScore { get; set; }

        public Score()
        {
            UnitBet = 0;
            UnitWin = 0;
            UnitLoss = 0;
            
            DollarWin = 0.0M;
            DollarLoss = 0.0M;

            TotalScore = 0.0M;
        }
    }
}
