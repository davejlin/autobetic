using StrategySimulator.Model.Results;
using StrategySimulator.Model.Scores;
using StrategySimulator.Model.BetProgressions;
using System.Collections.Generic;
using StrategySimulator.Utilities;

namespace StrategySimulator.Model.Strategies
{
    public class StrategyMultiWrapper
    {
        public StrategyBaccarat[] MyStrategy { get; set; }
        public BetProgressions.BetProgressions[] MyBetProgression { get; set; }

        public StrategyMultiWrapper()
        {
            MyStrategy = new StrategyBaccarat[Constants.StrategizeTotalNumber];
            MyBetProgression = new BetProgressions.BetProgressions[Constants.StrategizeTotalNumber];
        }

        public Strategy GetStrategyMultiWrapper()
        {
            return StrategyWrapper;
        }

        private void StrategyWrapper(List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotal, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            OutcomesBaccaratCoup outcome = OutcomesBaccaratCoup.None;
            for (int i = 0; i < results.Count; i++)
            {
                outcome = MyStrategy[0].StrategyCore(i, results, scoreShoe, sessionTotal + scoreShoe.TotalScore, MyBetProgression[0].BetProgressionCore, mmShoe, mmBankroll);

                if (outcome == OutcomesBaccaratCoup.None || outcome == OutcomesBaccaratCoup.Continue)
                {
                    outcome = MyStrategy[1].StrategyCore(i, results, scoreShoe, sessionTotal + scoreShoe.TotalScore, MyBetProgression[1].BetProgressionCore, mmShoe, mmBankroll);

                    if (outcome == OutcomesBaccaratCoup.None || outcome == OutcomesBaccaratCoup.Continue)
                    {
                        outcome = MyStrategy[2].StrategyCore(i, results, scoreShoe, sessionTotal + scoreShoe.TotalScore, MyBetProgression[2].BetProgressionCore, mmShoe, mmBankroll);

                        if (outcome == OutcomesBaccaratCoup.None || outcome == OutcomesBaccaratCoup.Continue)
                        {
                            outcome = MyStrategy[3].StrategyCore(i, results, scoreShoe, sessionTotal + scoreShoe.TotalScore, MyBetProgression[3].BetProgressionCore, mmShoe, mmBankroll);
                        }
                    }
                }

                if (outcome == OutcomesBaccaratCoup.Break)
                    break;

                results[i].TotalDollarScore = scoreShoe.TotalScore;
            }
        }
    }
}
