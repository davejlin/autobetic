
namespace StrategySimulator.ViewModels
{
    public class ItemResultBaccaratCoupViewModel : BaseViewModel
    {
        private string _indexDecision;
        public string IndexDecision
        {
            get
            {
                return _indexDecision;
            }
            set
            {
                if (value != _indexDecision)
                {
                    _indexDecision = value;
                    NotifyPropertyChanged("IndexDecision");
                }
            }
        }

        private string _winner;
        public string Winner
        {
            get
            {
                return _winner;
            }
            set
            {
                if (value != _winner)
                {
                    _winner = value;
                    NotifyPropertyChanged("Winner");
                }
            }
        }

        private string _cardPlayer1;
        public string CardPlayer1
        {
            get
            {
                return _cardPlayer1;
            }
            set
            {
                if (value != _cardPlayer1)
                {
                    _cardPlayer1 = value;
                    NotifyPropertyChanged("CardPlayer1");
                }
            }
        }

        private string _cardPlayer2;
        public string CardPlayer2
        {
            get
            {
                return _cardPlayer2;
            }
            set
            {
                if (value != _cardPlayer2)
                {
                    _cardPlayer2 = value;
                    NotifyPropertyChanged("CardPlayer2");
                }
            }
        }

        private string _cardPlayer3;
        public string CardPlayer3
        {
            get
            {
                return _cardPlayer3;
            }
            set
            {
                if (value != _cardPlayer3)
                {
                    _cardPlayer3 = value;
                    NotifyPropertyChanged("PlayerCard3");
                }
            }
        }

        private string _cardBanker1;
        public string CardBanker1
        {
            get
            {
                return _cardBanker1;
            }
            set
            {
                if (value != _cardBanker1)
                {
                    _cardBanker1 = value;
                    NotifyPropertyChanged("CardBanker1");
                }
            }
        }

        private string _cardBanker2;
        public string CardBanker2
        {
            get
            {
                return _cardBanker2;
            }
            set
            {
                if (value != _cardBanker2)
                {
                    _cardBanker2 = value;
                    NotifyPropertyChanged("CardBanker2");
                }
            }
        }

        private string _cardBanker3;
        public string CardBanker3
        {
            get
            {
                return _cardBanker3;
            }
            set
            {
                if (value != _cardBanker3)
                {
                    _cardBanker3 = value;
                    NotifyPropertyChanged("CardBanker3");
                }
            }
        }

        private bool _isBetPlayer;
        public bool IsBetPlayer
        {
            get
            {
                return _isBetPlayer;
            }
            set
            {
                if (value != _isBetPlayer)
                {
                    _isBetPlayer = value;
                    NotifyPropertyChanged("IsBetPlayer");
                }
            }
        }

        private bool _isBetBanker;
        public bool IsBetBanker
        {
            get
            {
                return _isBetBanker;
            }
            set
            {
                if (value != _isBetBanker)
                {
                    _isBetBanker = value;
                    NotifyPropertyChanged("IsBetBanker");
                }
            }
        }

        private bool _isBetTie;
        public bool IsBetTie
        {
            get
            {
                return _isBetTie;
            }
            set
            {
                if (value != _isBetTie)
                {
                    _isBetTie = value;
                    NotifyPropertyChanged("IsBetTie");
                }
            }
        }

        private string _unitBet;
        public string UnitBet
        {
            get
            {
                return _unitBet;
            }
            set
            {
                if (value != _unitBet)
                {
                    _unitBet = value;
                    NotifyPropertyChanged("UnitBet");
                }
            }
        }

        private string _totalScore;
        public string TotalScore
        {
            get
            {
                return _totalScore;
            }
            set
            {
                if (value != _totalScore)
                {
                    _totalScore = value;
                    NotifyPropertyChanged("TotalScore");
                }
            }
        }
    }
}
