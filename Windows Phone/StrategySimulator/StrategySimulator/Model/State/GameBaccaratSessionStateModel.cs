
namespace StrategySimulator.Model.State
{
    public class GameBaccaratSessionStateModel : BaseStateModel
    {
        private bool _isResultsVisisble;
        public bool IsResultsVisible
        {
            get { return _isResultsVisisble; }
            set
            {
                if(value != _isResultsVisisble)
                {
                    _isResultsVisisble = value;
                    NotifyPropertyChanged("IsResultsVisible");
                }
            }
        }

        private bool _isProgressStatusVisisble;
        public bool IsProgressStatusVisible
        {
            get { return _isProgressStatusVisisble; }
            set
            {
                if (value != _isProgressStatusVisisble)
                {
                    _isProgressStatusVisisble = value;
                    NotifyPropertyChanged("IsProgressStatusVisible");
                }
            }
        }
    }
}
