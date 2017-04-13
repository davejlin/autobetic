using StrategySimulator.Model.ListPickerItem;
using StrategySimulator.Model.Results;
using StrategySimulator.Utilities;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StrategySimulator.ViewModels
{
    public class GameBaccaratViewModel : BaseViewModel
    {
        public GameBaccaratViewModel()
        {
            ResetToInitialValues();
        }

        public void ResetToInitialValues()
        {
            IsTies = true;
            IsBurn = true;
            IsShuffle = true;
            IsBankroll = false;
            IsShoeStopLoss = false;
            IsShoeTakeProfit = false;
            IsNewCards = false;

            BetBaseUnit = Constants.BetBaseUnitInitial.ToString();
            BetMaxUnit = Constants.BetMaxUnitInitial.ToString();

            NDecks = Constants.NDecksInitial.ToString();
            NShoes = Constants.NShoesInitial.ToString();

            BankrollString = Constants.BankrollInitial.ToString();
            ShoeStopLossString = Constants.ShoeStopLossInitial.ToString();
            ShoeTakeProfitString = Constants.ShoeTakeProfitInitial.ToString();

            TiePayoffOptionPickedIndex = 0;
            Constants.TiePayoff = Constants.TiePayoffInitial;
        }

        readonly IEnumerable<string> tiePayOffOptions = new List<string>
        {
            "8",
            "9",
        };

        public IEnumerable<string> TiePayoffOptions
        {
            get
            {
                return tiePayOffOptions;
            }
        }

        private bool _isTies;
        public bool IsTies
        {
            get
            {
                return _isTies;
            }

            set
            {
                if (value != _isTies)
                {
                    _isTies = value;
                    NotifyPropertyChanged("IsTies");
                }
            }
        }

        private int _tiePayoffOptionPickedIndex;
        public int TiePayoffOptionPickedIndex
        {
            get
            {
                return _tiePayoffOptionPickedIndex;
            }

            set
            {
                if (value != _tiePayoffOptionPickedIndex)
                {
                    _tiePayoffOptionPickedIndex = value;
                    NotifyPropertyChanged("TiePayoffOptionPickedIndex");
                }
            }
        }

        private bool _isBurn;
        public bool IsBurn
        {
            get
            {
                return _isBurn;
            }

            set
            {
                if (value != _isBurn)
                {
                    _isBurn = value;
                    NotifyPropertyChanged("IsBurn");
                }
            }
        }

        private bool _isShuffle;
        public bool IsShuffle
        {
            get
            {
                return _isShuffle;
            }

            set
            {
                if (value != _isShuffle)
                {
                    _isShuffle = value;
                    NotifyPropertyChanged("IsShuffle");
                }
            }
        }

        private bool _isNewCards;
        public bool IsNewCards
        {
            get
            {
                return _isNewCards;
            }

            set
            {
                if (value != _isNewCards)
                {
                    _isNewCards = value;
                    NotifyPropertyChanged("IsNewCards");
                }
            }
        }

        private bool _isBankroll;
        public bool IsBankroll
        {
            get
            {
                return _isBankroll;
            }

            set
            {
                if (value != _isBankroll)
                {
                    _isBankroll = value;
                    NotifyPropertyChanged("IsBankroll");
                }
            }
        }

        private bool _isShoeStopLoss;
        public bool IsShoeStopLoss
        {
            get
            {
                return _isShoeStopLoss;
            }

            set
            {
                if (value != _isShoeStopLoss)
                {
                    _isShoeStopLoss = value;
                    NotifyPropertyChanged("IsShoeStopLoss");
                }
            }
        }

        private bool _isShoeTakeProfit;
        public bool IsShoeTakeProfit
        {
            get
            {
                return _isShoeTakeProfit;
            }

            set
            {
                if (value != _isShoeTakeProfit)
                {
                    _isShoeTakeProfit = value;
                    NotifyPropertyChanged("IsShoeTakeProfit");
                }
            }
        }

        Regex regexNumber = new Regex("^[0-9]+$");

        public int BetBaseUnitInt { get; set; }
        private string _betBaseUnit;
        public string BetBaseUnit
        {
            get
            {
                return _betBaseUnit;
            }

            set
            {
                if (value != _betBaseUnit)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int betInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.BetBaseUnitMax, "EXCEPTION: GameBaccaratViewModel/BetBaseUnit");

                        _betBaseUnit = betInt.ToString();
                        BetBaseUnitInt = betInt;
                    }

                    NotifyPropertyChanged("BetBaseUnit");
                }
            }
        }

        public int BetMaxUnitInt { get; set; }
        private string _betMaxUnit;
        public string BetMaxUnit
        {
            get
            {
                return _betMaxUnit;
            }

            set
            {
                if (value != _betMaxUnit)
                {
                    if (regexNumber.IsMatch(value))
                    {

                        int betInt = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.BetMaxUnitMax, "EXCEPTION: GameBaccaratViewModel/BetMaxUnit");

                        _betMaxUnit = betInt.ToString();
                        BetMaxUnitInt = betInt;
                    }

                    NotifyPropertyChanged("BetMaxUnit");
                }
            }
        }

        public int NDecksInt { get; set; }
        private string _nDecks;
        public string NDecks
        {
            get
            {
                return _nDecks;
            }

            set
            {
                if (value != _nDecks)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int nDecks = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.NDecksMax, "EXCEPTION: GameBaccaratViewModel/NDecks");
                        
                        if (nDecks <= 0)
                            nDecks = 1;

                        _nDecks = nDecks.ToString();
                        NDecksInt = nDecks;
                    }

                    NotifyPropertyChanged("NDecks");
                }
            }
        }

        public int NShoesInt { get; set; }
        private string _nShoes;
        public string NShoes
        {
            get
            {
                return _nShoes;
            }

            set
            {
                if (value != _nShoes)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int nShoes = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.NShoesMax, "EXCEPTION: GameBaccaratViewModel/NShoes");

                        _nShoes = nShoes.ToString();
                        NShoesInt = nShoes;
                    }

                    NotifyPropertyChanged("NShoes");
                }
            }
        }

        public int BankrollInt { get; set; }
        private string _bankrollString;
        public string BankrollString
        {
            get
            {
                return _bankrollString;
            }

            set
            {
                if (value != _bankrollString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int bankroll = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.BankrollMax, "EXCEPTION: GameBaccaratViewModel/BankrollString");

                        _bankrollString = bankroll.ToString();
                        BankrollInt = bankroll;
                    }

                    NotifyPropertyChanged("BankrollString");
                }
            }
        }

        public int ShoeStopLossInt { get; set; }
        private string _shoeStopLossString;
        public string ShoeStopLossString
        {
            get
            {
                return _shoeStopLossString;
            }

            set
            {
                if (value != _shoeStopLossString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int sl = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.ShoeStopLossMax, "EXCEPTION: GameBaccaratViewModel/ShoeStopLossString");

                        _shoeStopLossString = sl.ToString();
                        ShoeStopLossInt = sl;
                    }

                    NotifyPropertyChanged("ShoeStopLossString");
                }
            }
        }

        public int ShoeTakeProfitInt { get; set; }
        private string _shoeTakeProfitString;
        public string ShoeTakeProfitString
        {
            get
            {
                return _shoeTakeProfitString;
            }

            set
            {
                if (value != _shoeTakeProfitString)
                {
                    if (regexNumber.IsMatch(value))
                    {
                        int tp = Utilities.Utilities.CheckAndConvertValueToInt(value, Constants.ShoeTakeProfitMax, "EXCEPTION: GameBaccaratViewModel/ShoeTakeProfitString");

                        _shoeTakeProfitString = tp.ToString();
                        ShoeTakeProfitInt = tp;
                    }

                    NotifyPropertyChanged("ShoeTakeProfitString");
                }
            }
        }
    }
}
