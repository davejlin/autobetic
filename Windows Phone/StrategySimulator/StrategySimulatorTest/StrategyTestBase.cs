using StrategySimulator.Model;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Games;
using StrategySimulator.Model.MoneyManagements;
using StrategySimulator.Model.Scores;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;

namespace StrategySimulatorTest
{
    public class StrategyTestBase
    {
        protected Shoe shoe;
        protected GameBaccarat game;
        protected Card[] cards;
        protected ScoreBaccarat score;
        protected Strategy strategy;
        protected StrategyBaccarat[] myStrategy;
        protected StrategyMultiWrapper strategyMultiWrapper;
        protected BetProgressions[] myBetProgression;
        protected MoneyManagementShoe mmShoe;
        protected MoneyManagementBankroll mmBankroll;
        protected MoneyManagements myMoneyManagement;

        public void PrepareGame(bool includeTies = true)
        {
            score = new ScoreBaccarat();
            shoe = new Shoe(cards);
            game = new GameBaccarat() { Shoe = shoe};
            game.IncludeTies = includeTies;
            game.Play();

            myBetProgression = new BetProgressions[Constants.StrategizeTotalNumber]
            {
                new BetProgressions(),
                new BetProgressions(),
                new BetProgressions(),
                new BetProgressions()
            };

            myStrategy = new StrategyBaccarat[Constants.StrategizeTotalNumber]
            {
                new StrategyBaccarat(),
                new StrategyBaccarat(),
                new StrategyBaccarat(),
                new StrategyBaccarat()
            };

            for (int setNumber = 0; setNumber < Constants.StrategizeTotalNumber; setNumber++)
            {
                myBetProgression[setNumber].BetProgressionType = BetProgressionTypes.FlatBet;
                myStrategy[setNumber].StrategyBaccaratType = StrategiesBaccaratTypes.None;
            }

            strategyMultiWrapper = new StrategyMultiWrapper();

            for (int setNumber = 0; setNumber < Constants.StrategizeTotalNumber; setNumber++)
            {
                strategyMultiWrapper.MyBetProgression[setNumber] = myBetProgression[setNumber];
                strategyMultiWrapper.MyStrategy[setNumber] = myStrategy[setNumber];
            }

            myMoneyManagement = new MoneyManagements();
            mmShoe = myMoneyManagement.getMoneyManagementShoe(false, false);
            mmBankroll = myMoneyManagement.getMoneyManagementBankroll(false);
        }
    }
}
