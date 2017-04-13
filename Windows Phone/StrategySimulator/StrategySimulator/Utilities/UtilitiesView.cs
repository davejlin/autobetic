using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StrategySimulator.Utilities
{
    public class UtilitiesView
    {
        static SolidColorBrush PhoneTextHighContrastBrush = new SolidColorBrush((Application.Current.Resources["PhoneTextHighContrastBrush"] as SolidColorBrush).Color);
        static SolidColorBrush PhoneTextBoxForegroundBrush = new SolidColorBrush((Application.Current.Resources["PhoneTextBoxForegroundBrush"] as SolidColorBrush).Color);

        public static void GotFocusActions(TextBox textBox)
        {
            textBox.Foreground = PhoneTextBoxForegroundBrush;
            textBox.SelectAll();
        }

        public static void LostFocusActions(TextBox textBox)
        {
            textBox.Foreground = PhoneTextHighContrastBrush;
        }
    }
}
