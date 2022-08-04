using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Laba9.Classes
{
    public static class SliderCommands 
    {
        public static readonly RoutedUICommand Next = new RoutedUICommand
        (
            "Next",
            "Next",
            typeof(SliderCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Right),
                new MouseGesture(MouseAction.LeftClick)
            }
        );

        public static readonly RoutedUICommand Previous = new RoutedUICommand
        (
            "Previous",
            "Previous",
            typeof(SliderCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Left),
                new MouseGesture(MouseAction.LeftClick)
            }
        );
    }
}
