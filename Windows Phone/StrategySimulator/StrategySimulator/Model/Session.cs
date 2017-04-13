using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Games;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.Scores;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;
using StrategySimulator.ViewModels;
using System.Collections.Generic;

namespace StrategySimulator.Model
{
    public class Session
    {
        public List<List<ResultBaccaratCoup>> shoeResults { get; set; }
        public List<ScoreBaccarat> shoeScores { get; private set; }
        public List<ItemResultBaccaratShoeViewModel> ItemsShoe { get; private set; }

        GameBaccarat gameBaccarat { get; set; }

        public int NCoup;
        public int NPlayer;
        public int NBanker;
        public int NTie;

        public ScoreBaccarat scoreSession { get; private set; }
        ScoreBaccarat scoreShoe { get; set; }

        Shoe shoe;
        Dealer dealer;
        Strategy strategy;
        StrategyBaccarat[] myStrategy;
        StrategyMultiWrapper strategyMultiWrapper;
        BetProgressions.BetProgressions[] myBetProgression;
        MoneyManagements.MoneyManagements myMoneyManagement;
        MoneyManagementShoe mmShoe;
        MoneyManagementBankroll mmBankroll;

        public Session()
        {
            myStrategy = new StrategyBaccarat[Constants.StrategizeTotalNumber]
            {
                new StrategyBaccarat(),
                new StrategyBaccarat(),
                new StrategyBaccarat(),
                new StrategyBaccarat(),
            };

            strategyMultiWrapper = new StrategyMultiWrapper();

            myBetProgression = new BetProgressions.BetProgressions[Constants.StrategizeTotalNumber]
            {
                new BetProgressions.BetProgressions(),
                new BetProgressions.BetProgressions(),
                new BetProgressions.BetProgressions(),
                new BetProgressions.BetProgressions()
            };

            myMoneyManagement = new MoneyManagements.MoneyManagements();

            shoeResults = new List<List<ResultBaccaratCoup>>();
            shoeScores = new List<ScoreBaccarat>();
            ItemsShoe = new List<ItemResultBaccaratShoeViewModel>();

            shoe = new Shoe(App.GameBaccaratViewModel.NDecksInt);
            dealer = new Dealer() { Shoe = shoe };

            gameBaccarat = new GameBaccarat() { Shoe = dealer.Shoe };

            for (int setNumber = 0; setNumber < Constants.StrategizeTotalNumber; setNumber++)
            {
                strategyMultiWrapper.MyBetProgression[setNumber] = myBetProgression[setNumber];
                strategyMultiWrapper.MyStrategy[setNumber] = myStrategy[setNumber];
            }

            strategy = strategyMultiWrapper.GetStrategyMultiWrapper();
        }

        public void PlaySession()
        {
            ItemsShoe.Clear();
            shoeResults.Clear();
            shoeScores.Clear();

            SetupMoneyManagement();

            for (int setNumber = 0; setNumber < Constants.StrategizeTotalNumber; setNumber++)
            {
                App.StrategizeSetNumber = setNumber;
                SetupBetProgression(setNumber);
                SetupStrategy(setNumber);
            }

            initNumberStats();
            scoreSession = new ScoreBaccarat();

            //Deployment.Current.Dispatcher.BeginInvoke(() =>
            //{
            for (int i = 0; i < App.GameBaccaratViewModel.NShoesInt; i++)
            {
                scoreShoe = new ScoreBaccarat();

                GenerateBaccaratShoe();

                ResetProgressions();

                strategy(gameBaccarat.Results, scoreShoe, scoreSession.TotalScore, mmShoe, mmBankroll);

                gameBaccarat.aResultBaccaratShoe.IndexShoe = i + 1;

                incrementSessionScore();

                ItemsShoe.Add(new ItemResultBaccaratShoeViewModel()
                {
                    IndexShoe = gameBaccarat.aResultBaccaratShoe.IndexShoe.ToString(),
                    NCoup = gameBaccarat.aResultBaccaratShoe.NCoups.ToString(),
                    NPlayer = gameBaccarat.aResultBaccaratShoe.WinPlayer.ToString(),
                    NBanker = gameBaccarat.aResultBaccaratShoe.WinBanker.ToString(),
                    NTie = gameBaccarat.aResultBaccaratShoe.WinTie.ToString(),
                    ScoreShoe = scoreShoe.TotalScore.ToString(),
                    ScoreTotal = scoreSession.TotalScore.ToString(),
                });

                shoeResults.Add(new List<ResultBaccaratCoup>(gameBaccarat.Results));
                shoeScores.Add(scoreShoe);

                if (myMoneyManagement.BankrollBust)
                    break;
            }
            //});
        }

        public void GenerateBaccaratShoe()
        {
            if (App.GameBaccaratViewModel.IsNewCards)
                SetShoe(new Shoe(App.GameBaccaratViewModel.NDecksInt));

            gameBaccarat.ClearResults();

            dealer.ResetShoePointer();

            if (App.GameBaccaratViewModel.IsShuffle)
                dealer.Shuffle();

            if (App.GameBaccaratViewModel.IsBurn)
                dealer.BurnCards();

            gameBaccarat.IncludeTies = App.GameBaccaratViewModel.IsTies;
            gameBaccarat.Play();
        }

        private void SetupMoneyManagement()
        {
            mmShoe = myMoneyManagement.getMoneyManagementShoe(App.GameBaccaratViewModel.IsShoeStopLoss, App.GameBaccaratViewModel.IsShoeTakeProfit);
            mmBankroll = myMoneyManagement.getMoneyManagementBankroll(App.GameBaccaratViewModel.IsBankroll);
            myMoneyManagement.ShoeStopLoss = App.GameBaccaratViewModel.ShoeStopLossInt;
            myMoneyManagement.ShoeTakeProfit = App.GameBaccaratViewModel.ShoeTakeProfitInt;
            myMoneyManagement.Bankroll = App.GameBaccaratViewModel.BankrollInt;

            for (int setNumber = 0; setNumber < Constants.StrategizeTotalNumber; setNumber++)
            {
                myBetProgression[setNumber].BetBaseUnit = App.GameBaccaratViewModel.BetBaseUnitInt;
                myBetProgression[setNumber].BetMaxUnit = App.GameBaccaratViewModel.BetMaxUnitInt;
            }
        }

        private void SetupBetProgression(int setNumber)
        {

            myBetProgression[setNumber].MartingaleMultiplier = App.StrategizeBaccaratViewModel.MartingaleMultiplierInt;
            myBetProgression[setNumber].FibonacciDown = App.StrategizeBaccaratViewModel.FibonacciDownInt;
            myBetProgression[setNumber].CustomBetProgression = App.StrategizeBaccaratViewModel.CustomProgression;
            myBetProgression[setNumber].LabouchereProgression = App.StrategizeBaccaratViewModel.LabouchereProgression;
            myBetProgression[setNumber].ParlayProgression = App.StrategizeBaccaratViewModel.ParlayProgression;
            myBetProgression[setNumber].DAlembertStart = App.StrategizeBaccaratViewModel.DAlembertStartInt;
            myBetProgression[setNumber].DAlembertUp = App.StrategizeBaccaratViewModel.DAlembertUpInt;
            myBetProgression[setNumber].DAlemberDown = App.StrategizeBaccaratViewModel.DAlembertDownInt;
            myBetProgression[setNumber].ResetAfterProgressionMax = App.StrategizeBaccaratViewModel.IsResetProgressionAfterMax;
            myBetProgression[setNumber].ResetAfterProgressionShoe = App.StrategizeBaccaratViewModel.IsResetProgressionAfterShoe;
            myBetProgression[setNumber].OscarsGrindProfitPerCycle = App.StrategizeBaccaratViewModel.OscarsGrindInt;
            myBetProgression[setNumber].ProgressionPolarity = (BetProgressionPolarity)App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex;
            myBetProgression[setNumber].LoadOutcomeArray();

            myBetProgression[setNumber].BetProgressionType = (BetProgressionTypes)App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex; // this must be last, since the above may be overwritten

            ResetProgression(setNumber);
        }

        private void ResetProgressions()
        {
            for (int setNumber = 0; setNumber < Constants.StrategizeTotalNumber; setNumber++)
            {
                if (myBetProgression[setNumber].ResetAfterProgressionShoe)
                    ResetProgression(setNumber);
            }
        }

        private void ResetProgression(int setNumber)
        {
            myBetProgression[setNumber].ResetBetLastUnitToBaseUnit(); // start prog over
            myBetProgression[setNumber].ReachedProgressionMax = false;
            myStrategy[setNumber].LastBetResult = OutcomesLastCoupBet.None;
        }

        private void SetupStrategy(int setNumber)
        {
            myStrategy[setNumber].LastBetResult = OutcomesLastCoupBet.None;
            myStrategy[setNumber].CustomPattern_Pattern = App.StrategizeBaccaratViewModel.TargetCustomPattern;
            myStrategy[setNumber].CustomPattern_BetPlacement = (OutcomesBaccaratCoup)App.StrategizeBaccaratViewModel.BetPlacementCustomPatternOptionPickedIndex;
            myStrategy[setNumber].Streaks_BetPlacement = (OutcomesBaccaratCoup)App.StrategizeBaccaratViewModel.BetPlacementStreaksOptionPickedIndex;
            myStrategy[setNumber].Streaks_Target = (OutcomesBaccaratCoup)App.StrategizeBaccaratViewModel.TargetStreaksOptionPickedIndex;
            myStrategy[setNumber].Streaks_Length = App.StrategizeBaccaratViewModel.TargetStreakLengthInt;
            myStrategy[setNumber].CustomRepeat_Length = App.StrategizeBaccaratViewModel.CustomRepeatLengthInt;
            myStrategy[setNumber].CustomOpposite_Length = App.StrategizeBaccaratViewModel.CustomOppositeLengthInt;
            myStrategy[setNumber].Follow_Length = App.StrategizeBaccaratViewModel.FollowLengthInt;
            myStrategy[setNumber].Follow_BetPlacement = OutcomesBaccaratCoup.None;

            myStrategy[setNumber].StrategyBaccaratType = (StrategiesBaccaratTypes)App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex; // this must be last, since the above may be overwritten
        }

        public void SetShoe(Shoe shoe)
        {
            this.shoe = shoe;
            dealer.Shoe = this.shoe;
            gameBaccarat.Shoe = this.shoe;
        }

        public int GetCustomRepeatLength(int setNumber)
        {
            return myStrategy[setNumber].CustomRepeat_Length;
        }

        public int GetCustomOppositeLength(int setNumber)
        {
            return myStrategy[setNumber].CustomOpposite_Length;
        }

        private void incrementSessionScore()
        {
            NCoup += gameBaccarat.aResultBaccaratShoe.NCoups;
            NPlayer += gameBaccarat.aResultBaccaratShoe.WinPlayer;
            NBanker += gameBaccarat.aResultBaccaratShoe.WinBanker;
            NTie += gameBaccarat.aResultBaccaratShoe.WinTie;

            scoreSession.DollarLoss += scoreShoe.DollarLoss;
            scoreSession.DollarWin += scoreShoe.DollarWin;
            scoreSession.NumberBankerLoss += scoreShoe.NumberBankerLoss;
            scoreSession.NumberBankerWin += scoreShoe.NumberBankerWin;
            scoreSession.NumberBet += scoreShoe.NumberBet;
            scoreSession.NumberPlayerLoss += scoreShoe.NumberPlayerLoss;
            scoreSession.NumberPlayerWin += scoreShoe.NumberPlayerWin;
            scoreSession.NumberTieLoss += scoreShoe.NumberTieLoss;
            scoreSession.NumberTieWin += scoreShoe.NumberTieWin;
            scoreSession.TotalScore += scoreShoe.TotalScore;
            scoreSession.UnitBankerLoss += scoreShoe.UnitBankerLoss;
            scoreSession.UnitBankerWin += scoreShoe.UnitBankerWin;
            scoreSession.UnitBet += scoreShoe.UnitBet;
            scoreSession.UnitLoss += scoreShoe.UnitLoss;
            scoreSession.UnitPlayerLoss += scoreShoe.UnitPlayerLoss;
            scoreSession.UnitPlayerWin += scoreShoe.UnitPlayerWin;
            scoreSession.UnitTieLoss += scoreShoe.UnitTieLoss;
            scoreSession.UnitTieWin += scoreShoe.UnitTieWin;
            scoreSession.UnitWin += scoreShoe.UnitWin;
            scoreSession.MaxWin = scoreShoe.MaxWin;
            scoreSession.MaxLoss = scoreShoe.MaxLoss;
        }

        private void initNumberStats()
        {
            NCoup = 0;
            NPlayer = 0;
            NBanker = 0;
            NTie = 0;
        }
    }

}
