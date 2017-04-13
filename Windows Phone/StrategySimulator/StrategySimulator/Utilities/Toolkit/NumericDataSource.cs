using Microsoft.Phone.Controls.Primitives;
using System;
using System.Windows.Controls;

namespace StrategySimulator.Utilities.Toolkit
{
    public class NumericDataSource : ILoopingSelectorDataSource
    {
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        protected virtual void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            EventHandler<SelectionChangedEventArgs> tempEvent = SelectionChanged;
            if (tempEvent != null)
            {
                tempEvent(this, e);
            }
        }

        public object GetNext(object relativeTo)
        {
            int nextValue = (int) relativeTo + increment;
            return nextValue <= Maximum ? nextValue : Minimum;
        }

        public object GetPrevious(object relativeTo)
        {
            int previousValue = (int)relativeTo - increment;
            return previousValue >= Minimum ? previousValue : Maximum;
        }

        int selectedItem = 1;

        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                int newValue = (int)value;

                if (selectedItem == newValue)
                {
                    return;
                }
                int oldValue = selectedItem;
                selectedItem = newValue;

                OnSelectionChanged(new SelectionChangedEventArgs(new[] { oldValue }, new[] { newValue }));
            }
        }

        public int SelectedNumber
        {
            get
            {
                return (int)SelectedItem;
            }

            set
            {
                SelectedItem = value;
            }

        }

        int minimum = 1;

        public int Minimum
        {
            get
            {
                return minimum;
            }

            set
            {
                minimum = value;
                if (selectedItem < minimum)
                {
                    SelectedItem = value;
                }
            }
        }

        int maximum = 100;

        public int Maximum
        {
            get
            {
                return maximum;
            }

            set
            {
                maximum = value;

                if (selectedItem > maximum)
                {
                    SelectedItem = value;
                }
            }
        }

        int increment = 1;

        public int Increment
        {
            get
            {
                return increment;
            }

            set
            {
                increment = value;
            }
        }
    }
}
