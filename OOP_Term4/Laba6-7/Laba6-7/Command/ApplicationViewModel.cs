using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba6_7.Command
{
    class ApplicationViewModel 
    {
         private RelayCommand switchLangEngCommand;
         public RelayCommand SwitchLangEngCommand
         {
             get
             {
                 return switchLangEngCommand ?? (switchLangEngCommand = new RelayCommand(obj =>
                     {
                         Laba6_7.Language.SwitchLang.SwitchLangEng();
                     }
                 ));
             }
         }

        private RelayCommand switchLangRusCommand;
        public RelayCommand SwitchLangRusCommand
        {
            get
            {
                return switchLangRusCommand ?? (switchLangRusCommand = new RelayCommand(obj =>
                    {
                        Laba6_7.Language.SwitchLang.SwitchLangRus();
                    }
                ));
            }
        }

        //// команда открытия окна для добавления товара
        //private RelayCommand addGood;
        //public RelayCommand AddGood
        //{
        //    get
        //    {
        //        return addGood ?? (addGood = new RelayCommand(obj =>
        //                {
        //                    (new MainWindow()).OpenAddGoodWindow();
        //                    //Laba6_7.GoodWindow goodWindow = new Laba6_7.GoodWindow();
        //                    //goodWindow.ShowDialog();
        //                }
        //        ));
        //    }
        //}
    }
}
