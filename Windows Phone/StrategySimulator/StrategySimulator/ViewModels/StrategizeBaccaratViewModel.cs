using StrategySimulator.Model.ListPickerItem;
using StrategySimulator.Model.Results;
using StrategySimulator.Model.State;
using StrategySimulator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrategySimulator.ViewModels
{
    public class StrategizeBaccaratViewModel : BaseViewModel
    {
        private GameBaccaratStateModel _gameBaccaratStateModel;
        public GameBaccaratStateModel GameBaccaratStateModel
        {
            get { return _gameBaccaratStateModel; }
            set
            {
                if (_gameBaccaratStateModel != value)
                {
                    _gameBaccaratStateModel = value;
                    NotifyPropertyChanged("GameBaccaratStateModel");
                }
            }
        }

        public StrategizeBaccaratViewModel()
        {
            _gameBaccaratStateModel = new GameBaccaratStateModel();

            ResetToInitialValues();
        }

        public void ResetToInitialValues()
        {
            _gameBaccaratStateModel.IsCustomPatternVisible = false;
            _gameBaccaratStateModel.IsStreaksVisible = false;
            _gameBaccaratStateModel.IsCustomProgressionVisible = false;
            _gameBaccaratStateModel.IsDAlembertVisible = false;
            _gameBaccaratStateModel.IsMartingaleMultiplierVisible = false;
            _gameBaccaratStateModel.IsCustomPatternVisible = false;

            IsResetProgressionAfterMax = true;
            IsResetProgressionAfterShoe = true;

            TargetCustomPatternString = Constants.CustomPatternInitial;
            TargetStreakLength = Constants.TargetStreakLengthInitial.ToString();

            CustomProgressionString = Constants.CustomProgressionInitial;
            LabouchereProgressionString = Constants.LabouchereProgressionInitial;
            ParlayProgressionString = Constants.ParlayProgressionInitial;

            DAlembertStartString = Constants.DAlembertInitial.ToString();
            DAlembertUpString = DAlembertStartString;
            DAlembertDownString = DAlembertStartString;

            MartingaleMultiplierString = Constants.MartingaleMultiplierInitial.ToString();
            FibonacciDownString = Constants.FibonacciDownInitial.ToString();

            OscarsGrindString = Constants.OscarsGrindInitial.ToString();

            CustomOppositeLength = Constants.CustomRepeatOppositeLengthInitial.ToString();
            CustomRepeatLength = Constants.CustomRepeatOppositeLengthInitial.ToString();

            FollowLength = Constants.FollowLengthInitial.ToString();

            BetPlacementStrategyOptionPickedIndex = 0;
            BetProgressionOptionPickedIndex = 0;

            BetPlacementCustomPatternOptionPickedIndex = 0;
            BetPlacementStreaksOptionPickedIndex = 0;
            TargetStreaksOptionPickedIndex = 0;
            ProgressionPolarityOptionPickedIndex = 0;
        }


        readonly IEnumerable<ListPickerItem> betPlacementStrategyOptions = new List<ListPickerItem>
        {
            new ListPickerItem("none",                                "bet never",                                                    "none"),
            new ListPickerItem("banker (b) always",                   "bet banker always",                                            "b always"),
            new ListPickerItem("player (p) always",                   "bet player always",                                            "p always"),
            new ListPickerItem("tie (t) always",                      "bet tie always",                                               "t always"),
            new ListPickerItem("repeat (R)",                          "bet last decision, skip ties",                                 "repeat R"),
            new ListPickerItem("opposite (O)",                        "bet opposite of last decision, skip ties",                     "opposite O"),
            new ListPickerItem("avant dernier (TB4L)",                "bet same as second to last decision, skip ties",               "TB4L"),
            new ListPickerItem("reverse avant dernier (OTB4L)",       "bet opposite of second to last decision, skip ties",           "OTB4L"),
            new ListPickerItem("custom repeat (Rn)",                  "bet same as nth to last decision, skip ties",                  "custom repeat Rn"),
            new ListPickerItem("custom opposite (On)",                "bet opposite as nth to last decision, skip ties",              "custom opposite On"),
            new ListPickerItem("custom bet after custom pattern (CC)","bet b/p/t after a custom defined b/p/t target pattern",        "custom pattern CC"),
            new ListPickerItem("custom bet after streaks of n (Cn)",  "bet b/p/t after a b/p/t streak of specified length",           "custom streak Cn"),
            new ListPickerItem("follow after streak of n (Fn)",        "bet same side after streak of specified length, skip ties",   "follow Fn"),
        };

        public IEnumerable<ListPickerItem> BetPlacementStrategyOptions
        {
            get
            {
                return betPlacementStrategyOptions;
            }
        }

        readonly IEnumerable<ListPickerItem> betProgressionOptions = new List<ListPickerItem>
        {
            new ListPickerItem("flat (F)",               "bet same base amount every time",                               "flat F"),
            new ListPickerItem("martingale (M)",         "bet a multiple of last bet, the most aggressive progression",   "martingale M"),
            new ListPickerItem("d'alembert (DA)",         "bet up and down increments of last bet",                       "d'alembert DA"),
            new ListPickerItem("labouchere (L)",         "bet a staking line",                                            "labouchere L"),
            new ListPickerItem("fibonacci (F)",          "bet values based on the Fibonacci natural sequence of numbers", "fibonacci F"),
            new ListPickerItem("parlay (paroli) (P)",    "bet aggressively on winning streaks, a positive progression",   "parlay P"),
            new ListPickerItem("oscar's grind (OG)",      "bet incrementally on winning streaks, a positive progression", "oscar's grind OG"),
            new ListPickerItem("custom progression (C)",  "bet a custom defined progression",                             "custom prog C"),
        };

        public IEnumerable<ListPickerItem> BetProgressionOptions
        {
            get
            {
                return betProgressionOptions;
            }
        }

        readonly IEnumerable<string> betPlacementOptions = new List<string>
        {
            "banker (b)",
            "player (p)",
            "tie (t)",
        };

        public IEnumerable<string> BetPlacementOptions
        {
            get
            {
                return betPlacementOptions;
            }
        }

        readonly IEnumerable<string> progressionPolarityOptions = new List<string>
        {
            "Negative (up as you lose)",
            "Positive (up as you win)",
        };

        public IEnumerable<string> ProgressionPolarityOptions
        {
            get
            {
                return progressionPolarityOptions;
            }
        }

        private string _header;
        public string Header
        {
            get
            {
                return _header;
            }

            set
            {
                if (value != _header)
                {
                    _header = value;
                    NotifyPropertyChanged("Header");
                }
            }
        }

        private bool _isResetProgressionAfterMax;
        public bool IsResetProgressionAfterMax
        {
            get
            {
                return _isResetProgressionAfterMax;
            }

            set
            {
                if (value != _isResetProgressionAfterMax)
                {
                    _isResetProgressionAfterMax = value;
                    NotifyPropertyChanged("IsResetProgressionAfterMax");
                }
            }
        }

        private bool _isResetProgressionAfterShoe;
        public bool IsResetProgressionAfterShoe
        {
            get
            {
                return _isResetProgressionAfterShoe;
            }

            set
            {
                if (value != _isResetProgressionAfterShoe)
                {
                    _isResetProgressionAfterShoe = value;
                    NotifyPropertyChanged("IsResetProgressionAfterShoe");
                }
            }
        }

        private int _betPlacementStrategyOptionPickedIndex;
        public int BetPlacementStrategyOptionPickedIndex
        {
            get
            {
                return _betPlacementStrategyOptionPickedIndex;
            }

            set
            {
                if (value != _betPlacementStrategyOptionPickedIndex)
                {
                    _betPlacementStrategyOptionPickedIndex = value;
                    NotifyPropertyChanged("BetPlacementStrategyOptionPickedIndex");
                }
            }
        }

        private int _betProgressionOptionPickedIndex;
        public int BetProgressionOptionPickedIndex
        {
            get
            {
                return _betProgressionOptionPickedIndex;
            }

            set
            {
                if (value != _betProgressionOptionPickedIndex)
                {
                    _betProgressionOptionPickedIndex = value;
                    NotifyPropertyChanged("BetProgressionOptionPickedIndex");
                }
            }
        }

        private int _betPlacementCustomPatternOptionPickedIndex;
        public int BetPlacementCustomPatternOptionPickedIndex
        {
            get
            {
                return _betPlacementCustomPatternOptionPickedIndex;
            }

            set
            {
                if (value != _betPlacementCustomPatternOptionPickedIndex)
                {
                    _betPlacementCustomPatternOptionPickedIndex = value;
                    NotifyPropertyChanged("BetPlacementCustomPatternOptionPickedIndex");
                }
            }
        }

        private int _betPlacementStreaksOptionPickedIndex;
        public int BetPlacementStreaksOptionPickedIndex
        {
            get
            {
                return _betPlacementStreaksOptionPickedIndex;
            }

            set
            {
                if (value != _betPlacementStreaksOptionPickedIndex)
                {
                    _betPlacementStreaksOptionPickedIndex = value;
                    NotifyPropertyChanged("BetPlacementStreaksOptionPickedIndex");
                }
            }
        }

        private int _targetStreaksOptionPickedIndex;
        public int TargetStreaksOptionPickedIndex
        {
            get
            {
                return _targetStreaksOptionPickedIndex;
            }

            set
            {
                if (value != _targetStreaksOptionPickedIndex)
                {
                    _targetStreaksOptionPickedIndex = value;
                    NotifyPropertyChanged("TargetStreaksOptionPickedIndex");
                }
            }
        }

        private int _progressionPolarityOptionPickedIndex;
        public int ProgressionPolarityOptionPickedIndex
        {
            get
            {
                return _progressionPolarityOptionPickedIndex;
            }

            set
            {
                if (value != _progressionPolarityOptionPickedIndex)
                {
                    _progressionPolarityOptionPickedIndex = value;
                    NotifyPropertyChanged("ProgressionPolarityOptionPickedIndex");
                }
            }
        }

        public OutcomesBaccaratCoup[] TargetCustomPattern { get; set; }
        private string _targetCustomPatternString;
        public string TargetCustomPatternString
        {
            get
            {
                return _targetCustomPatternString;
            }

            set
            {
                if (value != _targetCustomPatternString)
                {
                    _targetCustomPatternString = value;
                    TargetCustomPattern = Utilities.Utilities.ParseBetPlacementString(value.ToString());

                    NotifyPropertyChanged("TargetCustomPattern");
                }
            }
        }

        public List<int> CustomProgression { get; set; }
        private string _customProgressionString;
        public string CustomProgressionString
        {
            get
            {
                return _customProgressionString;
            }

            set
            {
                if (value != _customProgressionString)
                {
                    _customProgressionString = value;
                    CustomProgression = Utilities.Utilities.ParseBetProgressionString(value.ToString());

                    NotifyPropertyChanged("CustomProgressionString");
                }
            }
        }

        public List<int> LabouchereProgression { get; set; }
        private string _labouchereProgressionString;
        public string LabouchereProgressionString
        {
            get
            {
                return _labouchereProgressionString;
            }

            set
            {
                if (value != _labouchereProgressionString)
                {
                    _labouchereProgressionString = value;
                    LabouchereProgression = Utilities.Utilities.ParseBetProgressionString(value.ToString());

                    NotifyPropertyChanged("LabouchereProgressionString");
                }
            }
        }

        public List<int> ParlayProgression { get; set; }
        private string _parlayProgressionString;
        public string ParlayProgressionString
        {
            get
            {
                return _parlayProgressionString;
            }

            set
            {
                if (value != _parlayProgressionString)
                {
                    _parlayProgressionString = value;
                    ParlayProgression = Utilities.Utilities.ParseBetProgressionString(value.ToString());

                    NotifyPropertyChanged("ParlayProgressionString");
                }
            }
        }

        Regex regexNumber = new Regex("^[0-9]+$");

        public int TargetStreakLengthInt { get; set; }
        private string _targetStreakLength;
        public string TargetStreakLength
        {
            get
            {
                return _targetStreakLength;
            }

            set
            {
                if (value != _targetStreakLength)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int lengthInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.TargetStreakLengthMax, "EXCEPTION: GameBaccaratViewModel/TargetStreakLength");

                        _targetStreakLength = lengthInt.ToString();
                        TargetStreakLengthInt = lengthInt;
                    }

                    NotifyPropertyChanged("TargetStreakLength");
                }
            }
        }

        public int CustomRepeatLengthInt { get; set; }
        private string _customRepeatLength;
        public string CustomRepeatLength
        {
            get
            {
                return _customRepeatLength;
            }

            set
            {
                if (value != _customRepeatLength)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int lengthInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.CustomRepeatOppositeLengthMax, "EXCEPTION: GameBaccaratViewModel/CustomRepeatLength");

                        if (lengthInt > 0) // 0 would match every decision exactly!
                        {
                            _customRepeatLength = lengthInt.ToString();
                            CustomRepeatLengthInt = lengthInt;
                        }
                    }

                    NotifyPropertyChanged("CustomRepeatLength");
                }
            }
        }

        public int CustomOppositeLengthInt { get; set; }
        private string _customOppositeLength;
        public string CustomOppositeLength
        {
            get
            {
                return _customOppositeLength;
            }

            set
            {
                if (value != _customOppositeLength)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int lengthInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.CustomRepeatOppositeLengthMax, "EXCEPTION: GameBaccaratViewModel/CustomOppositeLength");

                        if (lengthInt > 0) // 0 would miss every decision exactly!
                        {
                            _customOppositeLength = lengthInt.ToString();
                            CustomOppositeLengthInt = lengthInt;
                        }
                    }

                    NotifyPropertyChanged("CustomOppositeLength");
                }
            }
        }

        public int FollowLengthInt { get; set; }
        private string _followLength;
        public string FollowLength
        {
            get
            {
                return _followLength;
            }

            set
            {
                if (value != _followLength)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int lengthInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.FollowLengthMax, "EXCEPTION: GameBaccaratViewModel/FollowLength");

                        if (lengthInt > 0) // 0 would match every decision exactly!
                        {
                            _followLength = lengthInt.ToString();
                            FollowLengthInt = lengthInt;
                        }
                    }

                    NotifyPropertyChanged("FollowLength");
                }
            }
        }

        public int DAlembertUpInt { get; set; }
        private string _dAlembertUpString;
        public string DAlembertUpString
        {
            get
            {
                return _dAlembertUpString;
            }

            set
            {
                if (value != _dAlembertUpString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int upInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.DAlembertMax, "EXCEPTION: GameBaccaratViewModel/DAlemberUpString");

                        _dAlembertUpString = upInt.ToString();
                        DAlembertUpInt = upInt;
                    }

                    NotifyPropertyChanged("DAlembertUpString");
                }
            }
        }

        public int DAlembertDownInt { get; set; }
        private string _dAlembertDownString;
        public string DAlembertDownString
        {
            get
            {
                return _dAlembertDownString;
            }

            set
            {
                if (value != _dAlembertDownString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int downInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.DAlembertMax, "EXCEPTION: GameBaccaratViewModel/DAlembertDownString");

                        _dAlembertDownString = downInt.ToString();
                        DAlembertDownInt = downInt;
                    }

                    NotifyPropertyChanged("DAlembertDownString");
                }
            }
        }

        public int DAlembertStartInt { get; set; }
        private string _dAlembertStartString;
        public string DAlembertStartString
        {
            get
            {
                return _dAlembertStartString;
            }

            set
            {
                if (value != _dAlembertStartString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int startInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.DAlembertMax, "EXCEPTION: GameBaccaratViewModel/DAlembertStartString");

                        _dAlembertStartString = startInt.ToString();
                        DAlembertStartInt = startInt;
                    }

                    NotifyPropertyChanged("DAlembertStartString");
                }
            }
        }

        public int MartingaleMultiplierInt { get; set; }
        private string _martingaleMultiplierString;
        public string MartingaleMultiplierString
        {
            get
            {
                return _martingaleMultiplierString;
            }

            set
            {
                if (value != _martingaleMultiplierString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int multInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.MartingaleMultiplierMax, "EXCEPTION: GameBaccaratViewModel/MartingaleMultiplierString");

                        _martingaleMultiplierString = multInt.ToString();
                        MartingaleMultiplierInt = multInt;
                    }

                    NotifyPropertyChanged("MartingaleMultiplierString");
                }
            }
        }

        public int FibonacciDownInt { get; set; }
        private string _fibonacciDownString;
        public string FibonacciDownString
        {
            get
            {
                return _fibonacciDownString;
            }

            set
            {
                if (value != _fibonacciDownString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int fibInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.FibonacciDownMax, "EXCEPTION: GameBaccaratViewModel/FibonacciDownString");

                        _fibonacciDownString = fibInt.ToString();
                        FibonacciDownInt = fibInt;
                    }

                    NotifyPropertyChanged("FibonacciDownString");
                }
            }
        }

        public int OscarsGrindInt { get; set; }
        private string _oscarsGrindString;
        public string OscarsGrindString
        {
            get
            {
                return _oscarsGrindString;
            }

            set
            {
                if (value != _oscarsGrindString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int oscarsgrindInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.ShoeTakeProfitMax, "EXCEPTION: GameBaccaratViewModel/OscarsGrindString");

                        _oscarsGrindString = oscarsgrindInt.ToString();
                        OscarsGrindInt = oscarsgrindInt;
                    }

                    NotifyPropertyChanged("OscarsGrindString");
                }
            }
        }
    }
}
