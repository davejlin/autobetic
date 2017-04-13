using Microsoft.Phone.Controls;
using StrategySimulator.Model.BetProgressions;
using StrategySimulator.Model.Strategies;
using StrategySimulator.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using StrategySimulator.Model.ListPickerItem;

namespace StrategySimulator.View
{
    public partial class GameBaccarat : PhoneApplicationPage
    {
        public GameBaccarat()
        {
            InitializeComponent();
            DataContext = App.GameBaccaratViewModel;

            //betPlacementStrategyListPicker.SetValue(ListPicker.ItemCountThresholdProperty, 20);
            //betProgressionListPicker.SetValue(ListPicker.ItemCountThresholdProperty, 20);
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            //App.GameBaccaratSessionViewModel.ShowProgressStatus();
            //App.GameBaccaratSessionViewModel.HideResults();

            NavigationService.Navigate(new Uri("/View/GameBaccaratSession.xaml", UriKind.Relative));
            App.GameBaccaratSessionViewModel.PlaySession();

            //App.GameBaccaratSessionViewModel.HideProgressStatus();
            //App.GameBaccaratSessionViewModel.ShowResults();
        }

        private void maxUnitBetTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(maxUnitBetTextBox);
        }

        private void maxUnitBetTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(maxUnitBetTextBox);
        }

        private void baseUnitBetTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(baseUnitBetTextBox);
        }

        private void baseUnitBetTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(baseUnitBetTextBox);
        }

        private void nDecksTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(nDecksTextBox);
        }

        private void nDecksTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(nDecksTextBox);
        }

        private void nShoesTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(nShoesTextBox);
        }

        private void nShoesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(nShoesTextBox);
        }

        private void bankrollTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(bankrollTextBox);
        }

        private void bankrollTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(bankrollTextBox);
        }

        private void shoeStopLossTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(shoeStopLossTextBox);
        }

        private void shoeStopLossTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(shoeStopLossTextBox);
        }

        private void shoeTakeProfitTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(shoeTakeProfitTextBox);
        }

        private void shoeTakeProfitTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(shoeTakeProfitTextBox);
        }

        private void tiePayoffListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiePayoffListPicker.SelectedItem != null)
            {
                Constants.TiePayoff = Convert.ToInt32(tiePayoffListPicker.SelectedItem);
            }
        }

        private void strategy1Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/StrategizeBaccarat.xaml?set=1", UriKind.Relative));
        }

        private void strategy2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/StrategizeBaccarat.xaml?set=2", UriKind.Relative));
        }

        private void strategy3Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/StrategizeBaccarat.xaml?set=3", UriKind.Relative));
        }

        private void strategy4Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/StrategizeBaccarat.xaml?set=4", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PopulateStrategyTextStrings();
        }

        private void PopulateStrategyTextStrings()
        {
            List<Model.ListPickerItem.ListPickerItem> betPlacementList = (List<Model.ListPickerItem.ListPickerItem>)App.StrategizeBaccaratViewModel.BetPlacementStrategyOptions;
            List<Model.ListPickerItem.ListPickerItem> betProgressionList = (List<Model.ListPickerItem.ListPickerItem>)App.StrategizeBaccaratViewModel.BetProgressionOptions;

            App.StrategizeSetNumber = 0;
            strategySet1BetPlacementTextBlock.Text = betPlacementList[App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex].DisplayName;
            strategySet1BetProgressionTextBlock.Text = betProgressionList[App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex].DisplayName;

            App.StrategizeSetNumber = 1;
            strategySet2BetPlacementTextBlock.Text = betPlacementList[App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex].DisplayName;
            strategySet2BetProgressionTextBlock.Text = betProgressionList[App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex].DisplayName;

            App.StrategizeSetNumber = 2;
            strategySet3BetPlacementTextBlock.Text = betPlacementList[App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex].DisplayName;
            strategySet3BetProgressionTextBlock.Text = betProgressionList[App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex].DisplayName;

            App.StrategizeSetNumber = 3;
            strategySet4BetPlacementTextBlock.Text = betPlacementList[App.StrategizeBaccaratViewModel.BetPlacementStrategyOptionPickedIndex].DisplayName;
            strategySet4BetProgressionTextBlock.Text = betProgressionList[App.StrategizeBaccaratViewModel.BetProgressionOptionPickedIndex].DisplayName;

        }

        private void resetAllSettingValuesButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("press ok to reset all settings, including strategy set options, to their initial, default values", "reset all settings", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                App.GameBaccaratViewModel.ResetToInitialValues();
                for (int setN = 0; setN < Constants.StrategizeTotalNumber; setN++)
                {
                    App.StrategizeSetNumber = setN;
                    App.StrategizeBaccaratViewModel.ResetToInitialValues();
                }

                PopulateStrategyTextStrings();
            }
        }
    }
}