
using StrategySimulator.Model.Scores;
namespace StrategySimulator.ViewModels
{
    public class ItemResultBaccaratShoeViewModel : BaseViewModel
    {
        private string _indexShoe;
        public string IndexShoe
        {
            get
            {
                return _indexShoe;
            }
            set
            {
                if (value != _indexShoe)
                {
                    _indexShoe = value;
                    NotifyPropertyChanged("IndexShoe");
                }
            }
        }

        private string _nCoup;
        public string NCoup
        {
            get
            {
                return _nCoup;
            }
            set
            {
                if (value != _nCoup)
                {
                    _nCoup = value;
                    NotifyPropertyChanged("NCoup");
                }
            }
        }

        private string _nPlayer;
        public string NPlayer
        {
            get
            {
                return _nPlayer;
            }
            set
            {
                if (value != _nPlayer)
                {
                    _nPlayer = value;
                    NotifyPropertyChanged("NPlayer");
                }
            }
        }

        private string _nBanker;
        public string NBanker
        {
            get
            {
                return _nBanker;
            }
            set
            {
                if (value != _nBanker)
                {
                    _nBanker = value;
                    NotifyPropertyChanged("NBanker");
                }
            }
        }

        private string _nTie;
        public string NTie
        {
            get
            {
                return _nTie;
            }
            set
            {
                if (value != _nTie)
                {
                    _nTie = value;
                    NotifyPropertyChanged("NTie");
                }
            }
        }

        public string _scoreShoe;
        public string ScoreShoe
        {
            get
            {
                return _scoreShoe;
            }
            set
            {
                if (value != _scoreShoe)
                {
                    _scoreShoe = value;
                    NotifyPropertyChanged("ScoreShoe");
                }
            }
        }

        public string _scoreTotal;
        public string ScoreTotal
        {
            get
            {
                return _scoreTotal;
            }
            set
            {
                if (value != _scoreTotal)
                {
                    _scoreTotal = value;
                    NotifyPropertyChanged("ScoreTotal");
                }
            }
        }
    }
}
