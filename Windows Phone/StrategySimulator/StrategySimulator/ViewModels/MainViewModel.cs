using StrategySimulator.Resources;
using System.Collections.ObjectModel;

namespace StrategySimulator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }


        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { ItemGames = "baccarat" });
            this.Items.Add(new ItemViewModel() { ItemGames = "blackjack" });
            this.Items.Add(new ItemViewModel() { ItemGames = "craps" });
            this.Items.Add(new ItemViewModel() { ItemGames = "poker" });
            this.Items.Add(new ItemViewModel() { ItemGames = "roulette" });
            this.Items.Add(new ItemViewModel() { ItemGames = "slots" });

            this.IsDataLoaded = true;
        }

    }
}
