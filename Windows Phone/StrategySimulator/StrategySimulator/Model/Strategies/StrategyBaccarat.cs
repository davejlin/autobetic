using StrategySimulator.Model.Results;
using StrategySimulator.Model.Scores;
using System.Collections.Generic;

namespace StrategySimulator.Model.Strategies
{
    public class StrategyBaccarat
    {
        private StrategiesBaccaratTypes _strategyBaccaratType;
        public StrategiesBaccaratTypes StrategyBaccaratType
        {
            get
            {
                return _strategyBaccaratType;   
            }

            set
            {
                if (_strategyBaccaratType != value)
                {
                    _strategyBaccaratType = value;
                    SetStrategyBaccarat();
                }

                SpecialStrategyTypeSettings(); // needs to be done outside the above in case type doesn't change but details do
            }
        }

        public StrategyCore StrategyCore { get; set; }

        private OutcomesBaccaratCoup[] _customPattern_Pattern;
        public OutcomesBaccaratCoup[] CustomPattern_Pattern 
        {
            get
            {
                return _customPattern_Pattern;
            }
            set
            {
                if (_customPattern_Pattern != value)
                {
                    _customPattern_Pattern = value;
                    CustomPattern_Length = CustomPattern_Pattern.Length;
                }
            }
        }

        public OutcomesBaccaratCoup CustomPattern_BetPlacement { get; set; }
        public int CustomPattern_Length { get; set; }

        public OutcomesBaccaratCoup Streaks_Target { get; set; }
        public OutcomesBaccaratCoup Streaks_BetPlacement { get; set; }
        public int                  Streaks_Length { get; set; }

        public int CustomRepeat_Length { get; set; }
        public int CustomOpposite_Length { get; set; }

        public OutcomesBaccaratCoup Follow_BetPlacement { get; set; }
        public int Follow_Length { get; set; }

        public OutcomesLastCoupBet LastBetResult { get; set; }
        public int NextBet { get; set; }

        public StrategyBaccarat()
        {
            CustomPattern_BetPlacement = OutcomesBaccaratCoup.B;
            Follow_BetPlacement = OutcomesBaccaratCoup.None;
            StrategyBaccaratType = StrategiesBaccaratTypes.None;
            LastBetResult = OutcomesLastCoupBet.None;
            StrategyCore = StrategyCore_None;
        }

        private void SetStrategyBaccarat()
        {
            switch (_strategyBaccaratType)
            {
                case StrategiesBaccaratTypes.BankerAlways:
                    {
                        StrategyCore = StrategyCore_BankerAlways;
                    }
                    break;

                case StrategiesBaccaratTypes.PlayerAlways:
                    {
                        StrategyCore = StrategyCore_PlayerAlways;
                    }
                    break;

                case StrategiesBaccaratTypes.TieAlways:
                    {
                        StrategyCore = StrategyCore_TieAlways;
                    }
                    break;

                case StrategiesBaccaratTypes.Repeat:
                    {
                        StrategyCore = StrategyCore_RepeatN;
                    }
                    break;

                case StrategiesBaccaratTypes.Opposite:
                    {
                        StrategyCore = StrategyCore_OppositeN;
                    }
                    break;

                case StrategiesBaccaratTypes.TB4L:
                    {
                        StrategyCore = StrategyCore_RepeatN;
                    }
                    break;

                case StrategiesBaccaratTypes.OTB4L:
                    {
                        StrategyCore = StrategyCore_OppositeN;
                    }
                    break;

                case StrategiesBaccaratTypes.CustomRepeat:
                    {
                        StrategyCore = StrategyCore_RepeatN;
                    }
                    break;

                case StrategiesBaccaratTypes.CustomOpposite:
                    {
                        StrategyCore = StrategyCore_OppositeN;
                    }
                    break;

                case StrategiesBaccaratTypes.CustomPattern:
                    {
                        StrategyCore = StrategyCore_CustomPattern;
                    }
                    break;

                case StrategiesBaccaratTypes.Streaks:
                    {
                        StrategyCore = StrategyCore_CustomPattern;
                    }
                    break;

                case StrategiesBaccaratTypes.Follow:
                    {
                        StrategyCore = StrategyCore_Follow;
                    }
                    break;

                default:
                    {
                        StrategyCore = StrategyCore_None;
                    }
                    break;
            }
        }

        private void SpecialStrategyTypeSettings()
        {
            switch (_strategyBaccaratType)
            {
                case StrategiesBaccaratTypes.Streaks:
                    PrepareCustomPatternForStreaks();
                    break;
                case StrategiesBaccaratTypes.Repeat:
                    CustomRepeat_Length = 1;
                    break;
                case StrategiesBaccaratTypes.TB4L:
                    CustomRepeat_Length = 2;
                    break;
                case StrategiesBaccaratTypes.Opposite:
                    CustomOpposite_Length = 1;
                    break;
                case StrategiesBaccaratTypes.OTB4L:
                    CustomOpposite_Length = 2;
                    break;
            }
        }

        private OutcomesBaccaratCoup StrategyCore_None(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                return OutcomesBaccaratCoup.Break;

            ResultBaccaratCoup result = results[i];

            OutcomesBaccaratCoup betPlacement = OutcomesBaccaratCoup.None;
            result.CoupBet.BetPlacement = betPlacement;
            result.CoupBet.UnitBet = NextBet;

            return betPlacement;
        }

        private OutcomesBaccaratCoup StrategyCore_BankerAlways(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                return OutcomesBaccaratCoup.Break;

            ResultBaccaratCoup result = results[i];

            OutcomesBaccaratCoup betPlacement = OutcomesBaccaratCoup.B;

            result.CoupBet.BetPlacement = betPlacement;
            result.CoupBet.UnitBet = NextBet;

            OutcomesBaccaratCoup outcome = result.OutcomeCoup;

            if (outcome == OutcomesBaccaratCoup.B)
            {
                scoreShoe.ScoreBankerWin(NextBet);

                result.OutcomeBet = OutcomesLastCoupBet.Win;
                LastBetResult = OutcomesLastCoupBet.Win;
            }
            else if (outcome == OutcomesBaccaratCoup.P)
            {
                scoreShoe.ScoreLoss(NextBet, betPlacement);

                result.OutcomeBet = OutcomesLastCoupBet.Loss;
                LastBetResult = OutcomesLastCoupBet.Loss;
            }
            else if (outcome == OutcomesBaccaratCoup.T)
            {
                result.OutcomeBet = OutcomesLastCoupBet.Push;
                LastBetResult = OutcomesLastCoupBet.Push;
            }

            return betPlacement;
        }

        private OutcomesBaccaratCoup StrategyCore_PlayerAlways(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                return OutcomesBaccaratCoup.Break;

            ResultBaccaratCoup result = results[i];

            OutcomesBaccaratCoup betPlacement = OutcomesBaccaratCoup.P;

            result.CoupBet.BetPlacement = betPlacement;
            result.CoupBet.UnitBet = NextBet;

            OutcomesBaccaratCoup outcome = result.OutcomeCoup;

            if (outcome == OutcomesBaccaratCoup.B)
            {
                scoreShoe.ScoreLoss(NextBet, betPlacement);

                result.OutcomeBet = OutcomesLastCoupBet.Loss;
                LastBetResult = OutcomesLastCoupBet.Loss;
            }
            else if (outcome == OutcomesBaccaratCoup.P)
            {
                scoreShoe.ScorePlayerWin(NextBet);

                result.OutcomeBet = OutcomesLastCoupBet.Win;
                LastBetResult = OutcomesLastCoupBet.Win;
            }
            else if (outcome == OutcomesBaccaratCoup.T)
            {
                result.OutcomeBet = OutcomesLastCoupBet.Push;
                LastBetResult = OutcomesLastCoupBet.Push;
            }

            return betPlacement;
        }

        private OutcomesBaccaratCoup StrategyCore_TieAlways(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                return OutcomesBaccaratCoup.Break;

            ResultBaccaratCoup result = results[i];

            OutcomesBaccaratCoup betPlacement = OutcomesBaccaratCoup.T;

            result.CoupBet.BetPlacement = betPlacement;
            result.CoupBet.UnitBet = NextBet;

            OutcomesBaccaratCoup outcome = result.OutcomeCoup;

            if (outcome == OutcomesBaccaratCoup.T)
            {
                scoreShoe.ScoreTieWin(NextBet);

                result.OutcomeBet = OutcomesLastCoupBet.Win;
                LastBetResult = OutcomesLastCoupBet.Win;
            }
            else
            {
                scoreShoe.ScoreLoss(NextBet, betPlacement);

                result.OutcomeBet = OutcomesLastCoupBet.Loss;
                LastBetResult = OutcomesLastCoupBet.Loss;
            }

            return betPlacement;
        }

        private OutcomesBaccaratCoup StrategyCore_RepeatN(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (i < CustomRepeat_Length)
                return OutcomesBaccaratCoup.Continue;

            OutcomesBaccaratCoup outcomeN = results[i - CustomRepeat_Length].OutcomeCoup;
            if (outcomeN == OutcomesBaccaratCoup.T)
                return OutcomesBaccaratCoup.Continue;

            if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                return OutcomesBaccaratCoup.Break;

            ResultBaccaratCoup result = results[i];

            OutcomesBaccaratCoup betPlacement = outcomeN;

            result.CoupBet.BetPlacement = betPlacement;
            result.CoupBet.UnitBet = NextBet;

            OutcomesBaccaratCoup outcome = result.OutcomeCoup;

            if (betPlacement == outcome)
            {
                if (outcome == OutcomesBaccaratCoup.B)
                    scoreShoe.ScoreBankerWin(NextBet);
                else
                    scoreShoe.ScorePlayerWin(NextBet);

                result.OutcomeBet = OutcomesLastCoupBet.Win;
                LastBetResult = OutcomesLastCoupBet.Win;
            }
            else
            {
                if (outcome == OutcomesBaccaratCoup.T)
                {
                    result.OutcomeBet = OutcomesLastCoupBet.Push;
                    LastBetResult = OutcomesLastCoupBet.Push;
                }
                else
                {
                    scoreShoe.ScoreLoss(NextBet, betPlacement);

                    result.OutcomeBet = OutcomesLastCoupBet.Loss;
                    LastBetResult = OutcomesLastCoupBet.Loss;
                }
            }

            return betPlacement;
        }

        private OutcomesBaccaratCoup StrategyCore_OppositeN(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (i < CustomOpposite_Length)
                return OutcomesBaccaratCoup.Continue;

            OutcomesBaccaratCoup outcomeN = results[i - CustomOpposite_Length].OutcomeCoup;

            if (outcomeN == OutcomesBaccaratCoup.T)
                return OutcomesBaccaratCoup.Continue;

            if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                return OutcomesBaccaratCoup.Break;

            ResultBaccaratCoup result = results[i];

            OutcomesBaccaratCoup betPlacement;

            if (outcomeN == OutcomesBaccaratCoup.B)
                betPlacement = OutcomesBaccaratCoup.P;
            else
                betPlacement = OutcomesBaccaratCoup.B;

            result.CoupBet.BetPlacement = betPlacement;
            result.CoupBet.UnitBet = NextBet;

            OutcomesBaccaratCoup outcome = result.OutcomeCoup;

            if (betPlacement == outcome)
            {
                if (outcome == OutcomesBaccaratCoup.B)
                    scoreShoe.ScoreBankerWin(NextBet);
                else
                    scoreShoe.ScorePlayerWin(NextBet);

                result.OutcomeBet = OutcomesLastCoupBet.Win;
                LastBetResult = OutcomesLastCoupBet.Win;
            }
            else
            {
                if (outcome == OutcomesBaccaratCoup.T)
                {
                    result.OutcomeBet = OutcomesLastCoupBet.Push;
                    LastBetResult = OutcomesLastCoupBet.Push;
                }
                else
                {
                    scoreShoe.ScoreLoss(NextBet, betPlacement);

                    result.OutcomeBet = OutcomesLastCoupBet.Loss;
                    LastBetResult = OutcomesLastCoupBet.Loss;
                }
            }

            return betPlacement;
        }        
        
        /// <summary>
        /// StrategyCore_CustomPattern
        /// Search pattern includes P, B, and T
        /// Shoe outcomes can include T and T will be included in the pattern search.
        /// For example, search pattern "pb" will match "pb", but will *not* match "ptb", "pttb", etc.
        /// To ignore ties in the search, omit ties from the original shoe from the beginning!
        /// </summary>
        private OutcomesBaccaratCoup StrategyCore_CustomPattern(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (i < CustomPattern_Length)
                return OutcomesBaccaratCoup.Continue;

            int j;
            for (j = 0; j < CustomPattern_Length; j++)
            {
                if (results[i - CustomPattern_Length + j].OutcomeCoup != CustomPattern_Pattern[j])
                    break;
            }

            OutcomesBaccaratCoup betPlacement = OutcomesBaccaratCoup.None;

            if (j == CustomPattern_Length)
            {
                if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                    return OutcomesBaccaratCoup.Break;
                
                ResultBaccaratCoup result = results[i];

                OutcomesBaccaratCoup outcome = result.OutcomeCoup;

                betPlacement = CustomPattern_BetPlacement;
                result.CoupBet.BetPlacement = betPlacement;
                result.CoupBet.UnitBet = NextBet;

                if (outcome == betPlacement)
                {
                    if (outcome == OutcomesBaccaratCoup.B)
                        scoreShoe.ScoreBankerWin(NextBet);
                    else if (outcome == OutcomesBaccaratCoup.P)
                        scoreShoe.ScorePlayerWin(NextBet);
                    else if (outcome == OutcomesBaccaratCoup.T)
                        scoreShoe.ScoreTieWin(NextBet);

                    result.OutcomeBet = OutcomesLastCoupBet.Win;
                    LastBetResult = result.OutcomeBet;
                }
                else
                {
                    if (outcome == OutcomesBaccaratCoup.T)
                    {
                        if (betPlacement != OutcomesBaccaratCoup.T)
                        {
                            result.OutcomeBet = OutcomesLastCoupBet.Push;
                            LastBetResult = result.OutcomeBet;
                        }
                    }
                    else
                    {
                        scoreShoe.ScoreLoss(NextBet, betPlacement);

                        result.OutcomeBet = OutcomesLastCoupBet.Loss;
                        LastBetResult = result.OutcomeBet;
                    }
                }
            }

            return betPlacement;
        }

        private OutcomesBaccaratCoup StrategyCore_Follow(int i, List<ResultBaccaratCoup> results, ScoreBaccarat scoreShoe, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (i < Follow_Length)
            {
                Follow_BetPlacement = OutcomesBaccaratCoup.None;
                return OutcomesBaccaratCoup.Continue;
            }

            int j = 1;
            OutcomesBaccaratCoup lastOutcome = results[i-j].OutcomeCoup;

            for (; j < Follow_Length; j++)
            {
                if (results[i-j-1].OutcomeCoup != lastOutcome)
                    break;
            }

            if (j == Follow_Length)
                if (lastOutcome != OutcomesBaccaratCoup.T)
                    Follow_BetPlacement = lastOutcome;

            if (Follow_BetPlacement != OutcomesBaccaratCoup.None)
            {
                if (MoneyManager(scoreShoe.TotalScore, sessionTotalScore, betProgression, mmShoe, mmBankroll))
                    return OutcomesBaccaratCoup.Break;

                ResultBaccaratCoup result = results[i];

                OutcomesBaccaratCoup betPlacement = Follow_BetPlacement;

                result.CoupBet.BetPlacement = betPlacement;
                result.CoupBet.UnitBet = NextBet;

                OutcomesBaccaratCoup outcome = result.OutcomeCoup;

                if (outcome == betPlacement)
                {
                    if (outcome == OutcomesBaccaratCoup.B)
                        scoreShoe.ScoreBankerWin(NextBet);
                    else if (outcome == OutcomesBaccaratCoup.P)
                        scoreShoe.ScorePlayerWin(NextBet);
                    else if (outcome == OutcomesBaccaratCoup.T)
                        scoreShoe.ScoreTieWin(NextBet);

                    result.OutcomeBet = OutcomesLastCoupBet.Win;
                    LastBetResult = result.OutcomeBet;
                }
                else
                {
                    if (outcome == OutcomesBaccaratCoup.T)
                    {
                        if (CustomPattern_BetPlacement != OutcomesBaccaratCoup.T)
                        {
                            result.OutcomeBet = OutcomesLastCoupBet.Push;
                            LastBetResult = result.OutcomeBet;
                        }
                    }
                    else
                    {
                        scoreShoe.ScoreLoss(NextBet, betPlacement);

                        result.OutcomeBet = OutcomesLastCoupBet.Loss;
                        LastBetResult = result.OutcomeBet;
                    }
                }

            }

            return Follow_BetPlacement;
        }

        /// <summary>
        /// Money Manager checks if the shoe or session should end based on stop loss, take profit, and bankroll
        /// Note that NextBet is committed here, because it is needed for the bankroll check.
        /// The call to betProgression advances the progression, if any.
        /// </summary>
        /// <param name="score"></param>
        /// <param name="betProgression"></param>
        /// <param name="mmShoe"></param>
        /// <param name="mmBankroll"></param>
        /// <returns></returns>
        private bool MoneyManager(decimal shoeTotalScore, decimal sessionTotalScore, BetProgressionCore betProgression, MoneyManagementShoe mmShoe, MoneyManagementBankroll mmBankroll)
        {
            if (mmShoe(shoeTotalScore))
                return true;

            NextBet = betProgression(LastBetResult);
            if (mmBankroll(sessionTotalScore, NextBet))
                return true;

            return false;
        }

        /// <summary>
        /// PrepareStreaks
        /// Set up CustomPattern strategy parameters for streaks
        /// </summary>
        private void PrepareCustomPatternForStreaks()
        {
            CustomPattern_Pattern = new OutcomesBaccaratCoup[Streaks_Length];

            for (int i = 0; i < Streaks_Length; i++)
                CustomPattern_Pattern[i] = Streaks_Target;

            CustomPattern_BetPlacement = Streaks_BetPlacement;
            CustomPattern_Length = Streaks_Length;
        }
    }

    public enum StrategiesBaccaratTypes
    {
        None = 0,
        BankerAlways = 1,
        PlayerAlways = 2,
        TieAlways = 3,
        Repeat = 4,
        Opposite = 5,
        TB4L = 6,
        OTB4L = 7,
        CustomRepeat = 8,
        CustomOpposite = 9,
        CustomPattern = 10,
        Streaks = 11,
        Follow = 12
    }
}
