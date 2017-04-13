
namespace StrategySimulator.Model.State
{
    public class GameBaccaratStateModel : BaseStateModel
    {
        private bool _isCustomPatternVisible;
        public bool IsCustomPatternVisible
        {
            get { return _isCustomPatternVisible; }
            set
            {
                if (value != _isCustomPatternVisible)
                {
                    _isCustomPatternVisible = value;
                    NotifyPropertyChanged("IsCustomPatternVisible");
                }
            }
        }

        private bool _isStreaksVisible;
        public bool IsStreaksVisible
        {
            get { return _isStreaksVisible; }
            set
            {
                if (value != _isStreaksVisible)
                {
                    _isStreaksVisible = value;
                    NotifyPropertyChanged("IsStreaksVisible");
                }
            }
        }

        private bool _isMartingaleMultiplierVisible;
        public bool IsMartingaleMultiplierVisible
        {
            get { return _isMartingaleMultiplierVisible; }
            set
            {
                if (value != _isMartingaleMultiplierVisible)
                {
                    _isMartingaleMultiplierVisible = value;
                    NotifyPropertyChanged("IsMartingaleMultiplierVisible");
                }
            }
        }

        private bool _isCustomProgressionVisible;
        public bool IsCustomProgressionVisible
        {
            get { return _isCustomProgressionVisible; }
            set
            {
                if (value != _isCustomProgressionVisible)
                {
                    _isCustomProgressionVisible = value;
                    NotifyPropertyChanged("IsCustomProgressionVisible");
                }
            }
        }

        private bool _isDAlembertVisible;
        public bool IsDAlembertVisible
        {
            get { return _isDAlembertVisible; }
            set
            {
                if (value != _isDAlembertVisible)
                {
                    _isDAlembertVisible = value;
                    NotifyPropertyChanged("IsDAlembertVisible");
                }
            }
        }

        private bool _isFibonacciVisible;
        public bool IsFibonacciVisible
        {
            get { return _isFibonacciVisible; }
            set
            {
                if (value != _isFibonacciVisible)
                {
                    _isFibonacciVisible = value;
                    NotifyPropertyChanged("IsFibonacciVisible");
                }
            }
        }

        private bool _isLabouchereProgressionVisible;
        public bool IsLabouchereProgressionVisible
        {
            get { return _isLabouchereProgressionVisible; }
            set
            {
                if (value != _isLabouchereProgressionVisible)
                {
                    _isLabouchereProgressionVisible = value;
                    NotifyPropertyChanged("IsLabouchereProgressionVisible");
                }
            }
        }

        private bool _isProgressionPolarityVisible;
        public bool IsProgressionPolarityVisible
        {
            get { return _isProgressionPolarityVisible; }
            set
            {
                if (value != _isProgressionPolarityVisible)
                {
                    _isProgressionPolarityVisible = value;
                    NotifyPropertyChanged("IsProgressionPolarityVisible");
                }
            }
        }

        private bool _isParlayProgressionVisible;
        public bool IsParlayProgressionVisible
        {
            get { return _isParlayProgressionVisible; }
            set
            {
                if (value != _isParlayProgressionVisible)
                {
                    _isParlayProgressionVisible = value;
                    NotifyPropertyChanged("IsParlayProgressionVisible");
                }
            }
        }

        private bool _isOscarsGrindVisible;
        public bool IsOscarsGrindVisible
        {
            get { return _isOscarsGrindVisible; }
            set
            {
                if (value != _isOscarsGrindVisible)
                {
                    _isOscarsGrindVisible = value;
                    NotifyPropertyChanged("IsOscarsGrindVisible");
                }
            }
        }

        private bool _isCustomRepeatVisible;
        public bool IsCustomRepeatVisible
        {
            get { return _isCustomRepeatVisible; }
            set
            {
                if (value != _isCustomRepeatVisible)
                {
                    _isCustomRepeatVisible = value;
                    NotifyPropertyChanged("IsCustomRepeatVisible");
                }
            }
        }

        private bool _isCustomOppositeVisible;
        public bool IsCustomOppositeVisible
        {
            get { return _isCustomOppositeVisible; }
            set
            {
                if (value != _isCustomOppositeVisible)
                {
                    _isCustomOppositeVisible = value;
                    NotifyPropertyChanged("IsCustomOppositeVisible");
                }
            }
        }

        private bool _isFollowVisible;
        public bool IsFollowVisible
        {
            get { return _isFollowVisible; }
            set
            {
                if (value != _isFollowVisible)
                {
                    _isFollowVisible = value;
                    NotifyPropertyChanged("IsFollowVisible");
                }
            }
        }

    }
}
