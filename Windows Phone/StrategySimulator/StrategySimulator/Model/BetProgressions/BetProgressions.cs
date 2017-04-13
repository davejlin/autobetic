using StrategySimulator.Model.Results;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;
using System;
using System.Collections.Generic;

namespace StrategySimulator.Model.BetProgressions
{
    public class BetProgressions
    {
        private BetProgressionTypes _betProgressionType;
        public BetProgressionTypes BetProgressionType
        {
            get
            {
                return _betProgressionType;
            }

            set
            {
                if (_betProgressionType != value)
                {
                    _betProgressionType = value;
                    SetBetProgression();
                }

                SpecialBetProgressionTypeSettings(); // needs to be done outside the above in case type doesn't change but details do
            }

        }

        private void SpecialBetProgressionTypeSettings()
        {
            switch (_betProgressionType)
            {
                case BetProgressionTypes.Parlay:
                    {
                        CustomBetProgression = ParlayProgression;
                        BetBaseUnit = CustomBetProgression[0];
                    }
                    break;

                case BetProgressionTypes.Custom:
                    {
                        BetBaseUnit = CustomBetProgression[0];
                    }
                    break;
            }
        }

        public int BetBaseUnit { get; set; }
        public int BetMaxUnit { get; set; }
        public int BetLastUnit { get; set; }

        public int MartingaleMultiplier { get; set; }

        public List<int> CustomBetProgression { get; set; }
        public int CustomBetProgressionIndex { get; set; }

        public List<int> LabouchereProgression { get; set; }
        public List<int> LabouchereProgressionWorking { get; set; }

        public List<int> ParlayProgression { get; set; }

        public int DAlembertStart { get; set; }
        public int DAlembertUp { get; set; }
        public int DAlemberDown { get; set; }

        public int FibonacciIndex { get; set; }
        public int FibonacciDown { get; set; }

        public bool ResetAfterProgressionMax { get; set; }
        public bool ResetAfterProgressionShoe { get; set; }

        public bool ReachedProgressionMax { get; set; }

        public int OscarsGrindProfitPerCycle { get; set; }
        public int OscarsGrindScore { get; set; }

        public BetProgressionPolarity ProgressionPolarity { get; set; }
        private OutcomesLastCoupBet[] Outcome { get; set; }

        public BetProgressionCore BetProgressionCore { get; set; }

        public BetProgressions()
        {
            BetProgressionType = BetProgressionTypes.None;
            BetBaseUnit = Constants.BetBaseUnitInitial;
            BetMaxUnit = Constants.BetMaxUnitInitial;

            MartingaleMultiplier = Constants.MartingaleMultiplierInitial;

            CustomBetProgression = new List<int>() { 1 };
            CustomBetProgressionIndex = 0;

            LabouchereProgression = new List<int>() { 1 };
            LabouchereProgressionWorking = new List<int>() { 1 };

            ParlayProgression = new List<int>() { 1 };

            ResetAfterProgressionMax = true;
            ResetAfterProgressionShoe = true;

            ReachedProgressionMax = false;

            ProgressionPolarity = BetProgressionPolarity.Negative;
            Outcome = new OutcomesLastCoupBet[2];
            LoadOutcomeArray();

            DAlembertStart = Constants.DAlembertInitial;
            DAlembertUp = Constants.DAlembertInitial;
            DAlemberDown = Constants.DAlembertInitial;

            FibonacciDown = Constants.FibonacciDownInitial;
            FibonacciIndex = 0;

            ResetBetLastUnitToBaseUnit();

            _betProgressionType = BetProgressionTypes.None;
        }

        private void SetBetProgression()
        {
            ResetBetLastUnitToBaseUnit();

            switch (_betProgressionType)
            {
                case BetProgressionTypes.FlatBet:
                    {
                        BetProgressionCore = BetProgression_FlatBet_Method;
                    }
                    break;

                case BetProgressionTypes.Martingale:
                    {
                        BetProgressionCore = BetProgression_Martingale_Method;
                    }
                    break;

                case BetProgressionTypes.DAlembert:
                    {
                        BetProgressionCore = BetProgression_DAlembert_Method;
                    }
                    break;

                case BetProgressionTypes.Parlay:
                    {
                        BetProgressionCore = BetProgression_Custom_Method;
                    }
                    break;

                case BetProgressionTypes.Custom:
                    {
                        BetProgressionCore = BetProgression_Custom_Method;
                    }
                    break;

                case BetProgressionTypes.Fibonacci:
                    {
                        BetProgressionCore = BetProgression_Fibonnaci_Method;
                    }
                    break;

                case BetProgressionTypes.Labouchere:
                    {
                        BetProgressionCore = BetProgression_Labouchere_Method;
                    }
                    break;

                case BetProgressionTypes.OscarsGrind:
                    {
                        BetProgressionCore = BetProgression_OscarsGrind_Method;
                    }
                    break;

                default:
                    {
                        BetProgressionCore = BetProgression_No_Method;
                    }
                    break;
            }
        }

        private int BetProgression_No_Method(OutcomesLastCoupBet lastBetResult)
        {
            return 0;
        }

        private int BetProgression_FlatBet_Method(OutcomesLastCoupBet lastBetResult)
        {
            return CheckMaxBetAndResetIfNecessary(BetLastUnit);
        }

        private int BetProgression_Martingale_Method(OutcomesLastCoupBet lastBetResult)
        {
            int newBet = BetLastUnit;
            if (lastBetResult == Outcome[0])
            {
                newBet = getNextMartingaleBetProgression();
            }
            else if (lastBetResult == Outcome[1])
            {
                newBet = BetBaseUnit;
            }

            BetLastUnit = CheckMaxBetAndResetIfNecessary(newBet);
            return BetLastUnit;
        }

        private int getNextMartingaleBetProgression()
        {
            int newBet = MartingaleMultiplier * BetLastUnit;
            if (newBet > BetMaxUnit)
            {
                ReachedProgressionMax = true;
                newBet = BetLastUnit;
            }

            return newBet;
        }

        private int BetProgression_Custom_Method(OutcomesLastCoupBet lastBetResult)
        {
            int newBet = CustomBetProgression[CustomBetProgressionIndex];
            if (lastBetResult == Outcome[0])
            {
                newBet = getNextCustomBetProgression();
            }
            else if (lastBetResult == Outcome[1])
            {
                newBet = getAndResetBaseCustomBetProgression();
            }

            BetLastUnit = CheckMaxBetAndResetIfNecessary(newBet);
            return BetLastUnit;
        }

        private int getNextCustomBetProgression()
        {
            if (CustomBetProgressionIndex < CustomBetProgression.Count - 1)
                CustomBetProgressionIndex++;
            else
                ReachedProgressionMax = true;

            return CustomBetProgression[CustomBetProgressionIndex];
        }

        private int getAndResetBaseCustomBetProgression()
        {
            CustomBetProgressionIndex = 0;
            return CustomBetProgression[CustomBetProgressionIndex];
        }

        private int BetProgression_DAlembert_Method(OutcomesLastCoupBet lastBetResult)
        {
            int newBet = BetLastUnit;

            if (lastBetResult == Outcome[0])
            {
                newBet = BetLastUnit + DAlembertUp;
            }
            else if (lastBetResult == Outcome[1])
            {
                newBet = Math.Max(BetLastUnit - DAlemberDown, BetBaseUnit);
            }

            BetLastUnit = CheckMaxBetAndResetIfNecessary(newBet);
            return BetLastUnit;
        }

        private int BetProgression_Fibonnaci_Method(OutcomesLastCoupBet lastBetResult)
        {
            int newBet = Constants.FibonacciSequence[FibonacciIndex];
            if (lastBetResult == Outcome[0])
            {
                newBet = getNextFibonacciBetProgression();
            }
            else if (lastBetResult == Outcome[1])
            {
                newBet = getPreviousFibonacciBetProgression();
            }

            BetLastUnit = CheckMaxBetAndResetIfNecessary(newBet);
            return BetLastUnit;
        }

        private int getNextFibonacciBetProgression()
        {
            if (FibonacciIndex < Constants.FibonacciSequence.Length - 1)
                FibonacciIndex++;
            else
                ReachedProgressionMax = true;

            return Constants.FibonacciSequence[FibonacciIndex];
        }

        private int getPreviousFibonacciBetProgression()
        {
            FibonacciIndex = Math.Max(FibonacciIndex-FibonacciDown,0);

            return Constants.FibonacciSequence[FibonacciIndex];
        }

        private int BetProgression_Labouchere_Method(OutcomesLastCoupBet lastBetResult)
        {
            int lastIndex = 0;
            if (lastBetResult == Outcome[0])
            {
                LabouchereProgressionWorking.Add(BetLastUnit);
            }
            else if (lastBetResult == Outcome[1])
            {
                lastIndex = LabouchereProgressionWorking.Count - 1;
                if (lastIndex > 1)
                {
                    LabouchereProgressionWorking.RemoveAt(0);
                    LabouchereProgressionWorking.RemoveAt(LabouchereProgressionWorking.Count - 1);
                }
                else
                {
                    ResetLabouchereWorking();
                }
            }

            int newBet;
            lastIndex = LabouchereProgressionWorking.Count - 1;

            newBet = LabouchereProgressionWorking[0];

            if (lastIndex > 0)
                newBet += LabouchereProgressionWorking[lastIndex];

            BetLastUnit = CheckMaxBetAndResetIfNecessary(newBet);
            return BetLastUnit;
        }

        private int BetProgression_OscarsGrind_Method(OutcomesLastCoupBet lastBetResult)
        {
            int newBet = BetLastUnit;

            OscarsGrindScoreTally(lastBetResult);

            if (lastBetResult == Outcome[0])
            {
                if (OscarsGrindScore >= OscarsGrindProfitPerCycle)
                {
                    OscarsGrindScore = 0;
                    newBet = BetBaseUnit;
                }
                else
                {
                    if (OscarsGrindScore + BetLastUnit + 1 > OscarsGrindProfitPerCycle)
                        newBet = OscarsGrindProfitPerCycle - OscarsGrindScore;
                    else
                        newBet += 1;
                }
            }
            else if (lastBetResult == Outcome[1])
            {
            }

            BetLastUnit = CheckMaxBetAndResetIfNecessary(newBet);
            return BetLastUnit;
        }

        private void OscarsGrindScoreTally(OutcomesLastCoupBet lastBetResult)
        {
            if (lastBetResult == OutcomesLastCoupBet.Win)
                OscarsGrindScore += BetLastUnit;
            else if (lastBetResult == OutcomesLastCoupBet.Loss)
                OscarsGrindScore -= BetLastUnit;
        }

        public void ResetBetLastUnitToBaseUnit()
        {
            CustomBetProgressionIndex = 0;
            FibonacciIndex = 0;
            OscarsGrindScore = 0;

            if (BetProgressionType == BetProgressionTypes.DAlembert)
                BetLastUnit = DAlembertStart;
            else if (BetProgressionType == BetProgressionTypes.Labouchere)
                ResetLabouchereWorking();
            else
                BetLastUnit = BetBaseUnit;
        }

        private void ResetLabouchereWorking()
        {
            LabouchereProgressionWorking = LabouchereProgression.GetRange(0, LabouchereProgression.Count);
        }

        public int CheckMaxBetAndResetIfNecessary(int bet)
        {
            if (bet > BetMaxUnit)
            {
                bet = BetLastUnit;
            }
            
            if (ResetAfterProgressionMax && ReachedProgressionMax)
            {
                bet = BetBaseUnit;
                CustomBetProgressionIndex = 0;
                FibonacciIndex = 0;
                ReachedProgressionMax = false;
            }

            return bet;
        }

        public void LoadOutcomeArray()
        {
            if (ProgressionPolarity == BetProgressionPolarity.Negative)
            {
                Outcome[0] = OutcomesLastCoupBet.Loss;
                Outcome[1] = OutcomesLastCoupBet.Win;
            }
            else if (ProgressionPolarity == BetProgressionPolarity.Positive)
            {
                Outcome[0] = OutcomesLastCoupBet.Win;
                Outcome[1] = OutcomesLastCoupBet.Loss;
            }
        }
    }

    public enum BetProgressionTypes
    {
        None = -1,
        FlatBet = 0,
        Martingale = 1,
        DAlembert = 2,
        Labouchere = 3,
        Fibonacci = 4,
        Parlay = 5,
        OscarsGrind = 6,
        Custom = 7,
    }

    public enum BetProgressionPolarity
    {
        Negative,
        Positive
    }
}
