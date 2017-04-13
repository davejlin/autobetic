
namespace StrategySimulator.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private string _itemGames;
        public string ItemGames
        {
            get
            {
                return _itemGames;
            }
            set
            {
                if (value != _itemGames)
                {
                    _itemGames = value;
                    NotifyPropertyChanged("ItemGames");
                }
            }
        }
    }
}
