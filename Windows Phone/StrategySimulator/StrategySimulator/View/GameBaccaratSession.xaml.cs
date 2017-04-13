using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using StrategySimulator.ViewModels;

namespace StrategySimulator.View
{
    public partial class GameBaccaratSession : PhoneApplicationPage
    {
        public GameBaccaratSession()
        {
            InitializeComponent();
            DataContext = App.GameBaccaratSessionViewModel;
        }

        private void BaccaratLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (SessionLongListSelector.SelectedItem == null)
                return;

            // Navigate to the Shoe page
            NavigationService.Navigate(new Uri("/View/GameBaccaratShoe.xaml?shoeNumber=" + (SessionLongListSelector.SelectedItem as ItemResultBaccaratShoeViewModel).IndexShoe, UriKind.Relative));

            // Reset selected item to null (no selection)
            SessionLongListSelector.SelectedItem = null;
        }
    }
}