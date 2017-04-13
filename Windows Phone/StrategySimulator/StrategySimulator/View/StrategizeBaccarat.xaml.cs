using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using StrategySimulator.Model.BetProgressions;
using System.Text;

namespace StrategySimulator.View
{
    public partial class StrategizeBaccarat : PhoneApplicationPage
    {
        public StrategizeBaccarat()
        {
            InitializeComponent();
            DataContext = App.StrategizeBaccaratViewModel;
        }

        private void targetCustomPatternTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(targetCustomPatternTextBox);
        }

        private void targetCustomPatternTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(targetCustomPatternTextBox);
        }

        private void targetStreakLengthTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(targetStreakLengthTextBox);
        }

        private void targetStreakLengthTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(targetStreakLengthTextBox);
        }

        private void customProgressionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(customProgressionTextBox);
        }

        private void customProgressionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(customProgressionTextBox);
        }

        private void dAlembertStartTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(dAlembertStartTextBox);
        }

        private void dAlembertStartTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(dAlembertStartTextBox);
        }

        private void dAlembertUpTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(dAlembertUpTextBox);
        }

        private void dAlembertUpTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(dAlembertUpTextBox);
        }

        private void dAlembertDownTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(dAlembertDownTextBox);
        }

        private void dAlembertDownTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(dAlembertDownTextBox);
        }

        private void martingaleMultiplierTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(martingaleMultiplierTextBox);
        }

        private void martingaleMultiplierTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(martingaleMultiplierTextBox);
        }

        private void fibonacciDownTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(fibonacciDownTextBox);
        }

        private void fibonacciDownTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(fibonacciDownTextBox);
        }

        private void labouchereProgressionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(labouchereProgressionTextBox);
        }

        private void labouchereProgressionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(labouchereProgressionTextBox);
        }

        private void parlayProgressionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(parlayProgressionTextBox);
        }

        private void parlayProgressionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(parlayProgressionTextBox);
        }

        private void oscarsGrindTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(oscarsGrindTextBox);
        }

        private void oscarsGrindTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(oscarsGrindTextBox);
        }

        private void customRepeatTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(customRepeatTextBox);
        }

        private void customRepeatTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(customRepeatTextBox);
        }

        private void customOppositeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(customOppositeTextBox);
        }

        private void customOppositeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(customOppositeTextBox);
        }

        private void followTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.GotFocusActions(followTextBox);
        }

        private void followTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Utilities.UtilitiesView.LostFocusActions(followTextBox);
        }

        private void betPlacementStrategyListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (betPlacementStrategyListPicker.SelectedItem.ToString().Contains("custom pattern"))
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomPatternVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomPatternVisible = false;
            }

            if (betPlacementStrategyListPicker.SelectedItem.ToString().Contains("streaks"))
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsStreaksVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsStreaksVisible = false;
            }

            if (betPlacementStrategyListPicker.SelectedItem.ToString().Contains("custom repeat"))
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomRepeatVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomRepeatVisible = false;
            }

            if (betPlacementStrategyListPicker.SelectedItem.ToString().Contains("custom opposite"))
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomOppositeVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomOppositeVisible = false;
            }

            if (betPlacementStrategyListPicker.SelectedItem.ToString().Contains("follow"))
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsFollowVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsFollowVisible = false;
            }

        }

        private void betProgressionListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (betProgressionListPicker.SelectedItem.ToString().Contains("flat"))
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsProgressionPolarityVisible = false;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsProgressionPolarityVisible = true;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("martingale"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Negative;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsMartingaleMultiplierVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsMartingaleMultiplierVisible = false;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("custom"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Positive;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomProgressionVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsCustomProgressionVisible = false;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("d'alembert"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Negative;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsDAlembertVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsDAlembertVisible = false;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("fibonacci"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Negative;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsFibonacciVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsFibonacciVisible = false;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("labouchere"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Negative;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsLabouchereProgressionVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsLabouchereProgressionVisible = false;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("parlay"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Positive;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsParlayProgressionVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsParlayProgressionVisible = false;
            }

            if (betProgressionListPicker.SelectedItem.ToString().Contains("oscar"))
            {
                App.StrategizeBaccaratViewModel.ProgressionPolarityOptionPickedIndex = (int)BetProgressionPolarity.Positive;
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsOscarsGrindVisible = true;
            }
            else
            {
                App.StrategizeBaccaratViewModel.GameBaccaratStateModel.IsOscarsGrindVisible = false;
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string set = "";
            if (NavigationContext.QueryString.TryGetValue("set", out set))
            {
                App.StrategizeSetNumber = Convert.ToInt32(set)-1;
                DataContext = App.StrategizeBaccaratViewModel;

                App.StrategizeBaccaratViewModel.Header = new StringBuilder("strategy set ").Append(set).ToString();
            }

            base.OnNavigatedTo(e);
        }

    }
}