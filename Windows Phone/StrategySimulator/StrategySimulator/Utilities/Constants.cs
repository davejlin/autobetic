using StrategySimulator.Model.Results;
using System;
using System.Collections.Generic;

namespace StrategySimulator.Utilities
{
    public class Constants
    {
        public const uint UnsignedIntMax = 4294967295;
        public const int PositiveIntMax = 2147483647;
        public const int NegativeIntMax = -2147483648;

        public const int BetBaseUnitInitial = 1;
        public const int BetMaxUnitInitial = 10000;
        public const int BetBaseUnitMax = 1000;
        public const int BetMaxUnitMax = 1000000;

        public const int NDecksInitial = 8;
        public const int NShoesInitial = 100;
        public const int NDecksMax = 10;
        public const int NShoesMax = 5000;

        public const decimal UnitBankerWinPayoff = 0.95M;
        public const decimal UnitPlayerWinPayoff = 1.00M;
        public const decimal UnitLossPayoff = 1.00M;

        public const int TargetStreakLengthMax = 100;
        public const int TargetStreakLengthInitial = 5;

        public const string CustomPatternInitial = "pb";
        public const string CustomProgressionInitial = "1.3.2.6";

        public const string LabouchereProgressionInitial = "1.2.3.4.5.6";
        public const string ParlayProgressionInitial = "1.2.4";

        public const int DAlembertMax = 10000;
        public const int DAlembertInitial = 1;

        public const int FibonacciDownMax = 100;
        public const int FibonacciDownInitial = 2;

        public const int MartingaleMultiplierMax = 10;
        public const int MartingaleMultiplierInitial = 2;

        public const int BankrollMax = 1000000;
        public const int BankrollInitial = 1000;

        public const int ShoeStopLossMax = 1000000;
        public const int ShoeStopLossInitial = 25;

        public const int ShoeTakeProfitMax = 1000000;
        public const int ShoeTakeProfitInitial = 25;

        public const int OscarsGrindInitial = 1;

        public const int CustomRepeatOppositeLengthMax = 150;
        public const int CustomRepeatOppositeLengthInitial = 3;

        public const int FollowLengthMax = 100;
        public const int FollowLengthInitial = 2;

        public const int StrategizeTotalNumber = 4;

        public const int TiePayoffInitial = 8;

        public readonly static int[] FibonacciSequence = new int[] {1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578,5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170};

        public static Random Random = new Random();

        public static Dictionary<char, OutcomesBaccaratCoup> BetPlacementDictionary = new Dictionary<char, OutcomesBaccaratCoup>()
            {
                {'B', OutcomesBaccaratCoup.B},
                {'P', OutcomesBaccaratCoup.P},
                {'T', OutcomesBaccaratCoup.T},
            };

        public static bool[,] BankerDrawingRules = new bool[8,10]
            {
                {true, true, true, true, true, true, true, true, true, true},
                {true, true, true, true, true, true, true, true, true, true},
                {true, true, true, true, true, true, true, true, true, true},
                {true, true, true, true, true, true, true, true, false, true},
                {false, false, true, true, true, true, true, true, false, false},
                {false, false, false, false, true, true, true, true, false, false},
                {false, false, false, false, false, false, true, true, false, false},
                {false, false, false, false, false, false, false, false, false, false}
            };

        private static int _tiePayoff = TiePayoffInitial;
        public static int TiePayoff
        {
            get
            {
                return _tiePayoff;
            }
            set
            {
                if (value != _tiePayoff)
                    _tiePayoff = value;
            }
        }

    }
}
