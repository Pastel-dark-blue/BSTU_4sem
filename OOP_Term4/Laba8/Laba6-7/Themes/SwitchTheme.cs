using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba6_7.Themes
{
    class SwitchTheme
    {
        static private ResourceDictionary theme = new ResourceDictionary();

        // MergedDictionaries — это коллекция объектов ResourceDictionary, которые будут использоваться для пополнения коллекции ресурсов.
        static public void SwitchLightThemeCommand()
        {
            string themePath = @"pack://application:,,,/Themes/LightTheme.xaml";
            theme.Clear();
            theme.Source = new Uri(themePath);
            Application.Current.Resources.MergedDictionaries.Add(theme);
        }

        static public void SwitchDarkThemeCommand()
        {
            string themePath = @"pack://application:,,,/Themes/DarkTheme.xaml";
            theme.Clear();
            theme.Source = new Uri(themePath);
            Application.Current.Resources.MergedDictionaries.Add(theme);
        }

    }
}
