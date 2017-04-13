
namespace StrategySimulator.Model.Results
{
    public class ResultBaccaratCoup
    {
        public int IndexShoe { get; set; }
        public int IndexDecision { get; set; }

        public OutcomesBaccaratCoup OutcomeCoup { get; set; }
        public OutcomesLastCoupBet OutcomeBet { get; set; }

        public Card CardPlayer1 { get; set; }
        public Card CardPlayer2 { get; set; }
        public Card CardPlayer3 { get; set; }

        public Card CardBanker1 { get; set; }
        public Card CardBanker2 { get; set; }
        public Card CardBanker3 { get; set; }

        public Bet CoupBet { get; set; }
        public decimal TotalDollarScore { get; set; }

        public ResultBaccaratCoup()
        {
            IndexShoe = 0;
            IndexDecision = 0;
            OutcomeCoup = OutcomesBaccaratCoup.None;
            OutcomeBet = OutcomesLastCoupBet.None;
            CardPlayer1 = new Card(Suits.None,Values.None);
            CardPlayer2 = new Card(Suits.None, Values.None);
            CardPlayer3 = new Card(Suits.None, Values.None);
            CardBanker1 = new Card(Suits.None, Values.None);
            CardBanker2 = new Card(Suits.None, Values.None);
            CardBanker3 = new Card(Suits.None, Values.None);
            CoupBet = new Bet(OutcomesBaccaratCoup.None, 0);
            TotalDollarScore = 0;
        }
    }
}
