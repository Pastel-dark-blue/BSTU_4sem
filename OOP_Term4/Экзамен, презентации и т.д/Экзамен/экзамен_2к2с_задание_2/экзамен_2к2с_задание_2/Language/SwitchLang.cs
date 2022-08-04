using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace экзамен_2к2с_задание_2.Language
{
    static public class SwitchLang
    {
        static private ResourceDictionary lang = new ResourceDictionary();

        // MergedDictionaries — это коллекция объектов ResourceDictionary, которые будут использоваться для пополнения коллекции ресурсов.
        static public void SwitchLangEng()
        {
            string langPath = @"pack://application:,,,/Language/eng.xaml";
            lang.Clear();
            lang.Source = new Uri(langPath);
            Application.Current.Resources.MergedDictionaries.Add(lang);
        }

        static public void SwitchLangRus()
        {
            string langPath = @"pack://application:,,,/Language/rus.xaml";
            lang.Clear();
            lang.Source = new Uri(langPath);
            Application.Current.Resources.MergedDictionaries.Add(lang);
        }
    }
}
