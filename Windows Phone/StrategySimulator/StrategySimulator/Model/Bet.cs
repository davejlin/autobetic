using StrategySimulator.Model.Results;

namespace StrategySimulator.Model
{
    public class Bet
    {
        public OutcomesBaccaratCoup BetPlacement { get; set; }
        public int UnitBet { get; set; }

        public Bet(OutcomesBaccaratCoup betPlacement, int unitBet)
        {
            BetPlacement = betPlacement;
            UnitBet = unitBet;
        }
    }
}
