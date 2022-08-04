using Laba6_7.Goods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.XPath;

namespace Laba6_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Good> goodsCollection = new ObservableCollection<Good>();
        Cursor myCursorArrow;
        Cursor myCursorHand;

        public MainWindow()
        {
            InitializeComponent();

            // в xaml коде формы мы использовали привязки (binding)
            // Привязка подразумевает взаимодействие двух объектов: источника и приемника. 
            // Объект-приемник создает привязку к определенному свойству объекта-источника. 
            // В случае модификации объекта-источника, объект-приемник также будет модифицирован. 
            // Для установки источника или контекста данных в элементах управления WPF предусмотрено свойство DataContext.
            this.DataContext = new Laba6_7.Command.ApplicationViewModel(); // т.о. все binding будут обращаться к объекту типа ApplicationViewModel и использовать его св-ва и методы

            goodsCollection = Good.readXml();
            GoodsListBox.ItemsSource = goodsCollection;

            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // курсоры
            string currentDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string currentDirCursor = currentDir + "\\Cursors";

            myCursorArrow = new Cursor($"{currentDirCursor}\\arrow.cur");
            myCursorHand = new Cursor($"{currentDirCursor}\\hand.cur");

            this.Cursor = myCursorArrow;
        }

        // открытие окна редактирования
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // проверка на то, чтобы в ListBox что-то было
            if (GoodsListBox.ItemsSource != null)
            {
                Good editGood = (Good)GoodsListBox.SelectedItem;
                EditGoodWindow editWindow = new EditGoodWindow(editGood, goodsCollection);
                editWindow.ShowDialog();
            }
        }

        // удаление товара, долго что-то делала, методом самоистязаний составила некий рабочий метод 
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // проверка на то, чтобы в ListBox что-то было
            if (GoodsListBox.ItemsSource != null && goodsCollection != null)
            {
                goodsCollection.Remove(GoodsListBox.SelectedItem as Good);

                if (File.Exists(Good.goodsFilePath))
                {
                    File.Delete(Good.goodsFilePath);
                }

                foreach (Good g in goodsCollection)
                {
                    Good.SerializerInXml(g);
                }

                goodsCollection = Good.readXml();
                GoodsListBox.ItemsSource = null;
                GoodsListBox.ItemsSource = goodsCollection;
            }
        }

        public void OpenAddGoodWindow(object sender, RoutedEventArgs e)
        {
            Laba6_7.GoodWindow goodWindow = new Laba6_7.GoodWindow(GoodsListBox);
            goodWindow.ShowDialog();
        }

        // поиск по артикулу, названию и вообще всему
        private void SearchTextButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsListBox.ItemsSource != null)
            {
                ObservableCollection<Good> GoodsBuffer = new ObservableCollection<Good>();
                string textInBox= (string)((SearchMenuItem.Template.FindName("SearchTextBox", SearchMenuItem) as TextBox).Text);
                Regex lowerReg = new Regex(textInBox.ToLower());

                if(textInBox == String.Empty)
                {
                    ApplyButton_Click(new object(), new RoutedEventArgs());
                    return;
                }

                foreach (Good g in GoodsListBox.ItemsSource)
                {
                    if (lowerReg.IsMatch(g.ID.ToString().ToLower()) ||
                        lowerReg.IsMatch(g.Name.ToLower()) ||
                        lowerReg.IsMatch(g.Category.ToLower()) ||
                        lowerReg.IsMatch(g.Rate.ToString().ToLower()) ||
                        lowerReg.IsMatch(g.Price.ToString().ToLower()) ||
                        lowerReg.IsMatch(g.Amount.ToString().ToLower()))
                    {
                        GoodsBuffer.Add(g);
                    }
                }

                GoodsListBox.ItemsSource = null;
                GoodsListBox.ItemsSource = GoodsBuffer;
            }
        }

        // применить фильтрацию и сортировку
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //goodsCollection = Good.readXml();

            if (goodsCollection != null)
            {
                //ObservableCollection<Good> GoodsBuffer = goodsCollection;

                Regex bicycleReg = new Regex("Category");
                Regex accessoriesReg = new Regex("Category");
                Regex cyclingClothingReg = new Regex("Category");
                Regex partsReg = new Regex("Category");

                // Фильтрация
                if (BicyclesFilterCheckBox.IsChecked == true)
                {
                    bicycleReg = new Regex("Bicycles|Велосипеды");
                }

                if (AccessoriesFilterCheckBox.IsChecked == true)
                {
                    accessoriesReg = new Regex("Accessories|Аксессуары");
                }

                if (CyclingClothingFilterCheckBox.IsChecked == true)
                {
                    cyclingClothingReg = new Regex("Cycling clothing|Велоформа");
                }

                if (PartsFilterCheckBox.IsChecked == true)
                {
                    partsReg = new Regex("Parts|Запчасти");
                }

                if (BicyclesFilterCheckBox.IsChecked == false &&
                    AccessoriesFilterCheckBox.IsChecked == false &&
                    CyclingClothingFilterCheckBox.IsChecked == false &&
                    PartsFilterCheckBox.IsChecked == false)
                {
                    bicycleReg = new Regex("");
                    accessoriesReg = new Regex("");
                    cyclingClothingReg = new Regex("");
                    partsReg = new Regex("");
                }

                ObservableCollection<Good> GoodsBuffer = new ObservableCollection<Good>();

                foreach (var good in 
                                    from g in goodsCollection
                                    where
                                        bicycleReg.IsMatch(g.Category) || accessoriesReg.IsMatch(g.Category) ||
                                        cyclingClothingReg.IsMatch(g.Category) || partsReg.IsMatch(g.Category)
                                    select g)
                {
                    GoodsBuffer.Add(good);
                }

                // Сортировка
                if (GoodsBuffer != null && PriceDescRadioButton.IsChecked == true)
                {
                    GoodsBuffer = new ObservableCollection<Good>(from g in GoodsBuffer
                                                                 orderby g.Price descending
                                                                 select g);
                }

                else if (GoodsBuffer != null && PriceAscRadioButton.IsChecked == true)
                {
                    GoodsBuffer = new ObservableCollection<Good>(from g in GoodsBuffer
                                                                 orderby g.Price ascending
                                                                 select g);
                }

                if (GoodsListBox.ItemsSource != null && NameAlphabeticallyRadioButton.IsChecked == true)
                {
                    GoodsBuffer = new ObservableCollection<Good>(from g in GoodsBuffer
                                                                 orderby g.Name ascending
                                                                 select g);
                }

                if (GoodsListBox.ItemsSource != null && NameReverseAlphabeticallyRadioButton.IsChecked == true)
                {
                    GoodsBuffer = new ObservableCollection<Good>(from g in GoodsBuffer
                                                                 orderby g.Name descending
                                                                 select g);
                }

                if (GoodsListBox.ItemsSource != null && RateDescRadioButton.IsChecked == true)
                {
                    GoodsBuffer = new ObservableCollection<Good>(from g in GoodsBuffer
                                                                 orderby g.Rate descending
                                                                 select g);
                }

                if (GoodsListBox.ItemsSource != null && RateAscRadioButton.IsChecked == true)
                {
                    GoodsBuffer = new ObservableCollection<Good>(from g in GoodsBuffer
                                                                 orderby g.Rate ascending
                                                                 select g);
                }

                GoodsListBox.ItemsSource = null;
                GoodsListBox.ItemsSource = GoodsBuffer;

                // убираем текст из строки поиска
                (SearchMenuItem.Template.FindName("SearchTextBox", SearchMenuItem) as TextBox).Text = "";
            }
        }

        private void ResetAllButton_Click(object sender, RoutedEventArgs e)
        {
            PriceDescRadioButton.IsChecked = false;
            PriceAscRadioButton.IsChecked = false;
            NameAlphabeticallyRadioButton.IsChecked = false;
            NameReverseAlphabeticallyRadioButton.IsChecked = false;
            RateAscRadioButton.IsChecked = false;
            RateDescRadioButton.IsChecked = false;

            BicyclesFilterCheckBox.IsChecked = false;
            AccessoriesFilterCheckBox.IsChecked = false;
            CyclingClothingFilterCheckBox.IsChecked = false;
            PartsFilterCheckBox.IsChecked = false;

            GoodsListBox.ItemsSource = null;
            GoodsListBox.ItemsSource = goodsCollection;
        }

        // курсор "рука" при наведении курсора на кнопку
        private void ClickableElement_MouseEnter(object sender, RoutedEventArgs e)
        {
            if ((sender as Button) != null) 
                (sender as Button).Cursor = myCursorHand;

            if ((sender as MenuItem) != null)
                (sender as MenuItem).Cursor = myCursorHand;
        }

        private void ClickableElement_MouseLeave(object sender, RoutedEventArgs e)
        {
            if ((sender as Button) != null)
                (sender as Button).Cursor = myCursorArrow;

            if ((sender as MenuItem) != null)
                (sender as MenuItem).Cursor = myCursorArrow;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            goodsCollection = Good.readXml();
            GoodsListBox.ItemsSource = null;
            GoodsListBox.ItemsSource = goodsCollection;
        }

        private void ClickableElement_MouseEnter()
        {

        }
    }
}
