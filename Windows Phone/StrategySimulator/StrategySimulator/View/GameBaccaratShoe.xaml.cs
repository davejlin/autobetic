using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Data;
using System.Text;

namespace StrategySimulator.View
{
    public partial class GameBaccaratShoe : PhoneApplicationPage
    {
        string shoeNumber;
        public GameBaccaratShoe()
        {
            InitializeComponent();
            DataContext = App.GameBaccaratShoeViewModel;
            shoeNumber = "0";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.TryGetValue("shoeNumber", out shoeNumber))
            {
                App.GameBaccaratShoeViewModel.Header = new StringBuilder("shoe #").Append(shoeNumber).ToString();
                App.GameBaccaratShoeViewModel.LoadShoeResults(int.Parse(shoeNumber) - 1);
            }
        }

        private void PhoneApplicationPage_LostFocus(object sender, RoutedEventArgs e)
        {
            App.GameBaccaratShoeViewModel.ClearItems();
        }
    }
}