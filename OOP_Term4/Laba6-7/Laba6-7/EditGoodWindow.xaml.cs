using Laba6_7.Goods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Laba6_7
{
    /// <summary>
    /// Логика взаимодействия для EditGoodWindow.xaml
    /// </summary>
    public partial class EditGoodWindow : Window
    {
        Good good = new Good();
        ObservableCollection<Good> goodsCollection = new ObservableCollection<Good>();

        Cursor myCursorArrow;
        Cursor myCursorHand;

        public EditGoodWindow(Good goodEdit, ObservableCollection<Good> goodsCollectionEdit)
        {
            InitializeComponent();

            good = goodEdit;
            goodsCollection = goodsCollectionEdit;

            this.DataContext = good;

            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // курсоры
            string currentDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string currentDirCursor = currentDir + "\\Cursors";

            myCursorArrow = new Cursor($"{currentDirCursor}\\arrow.cur");
            myCursorHand = new Cursor($"{currentDirCursor}\\hand.cur");

            this.Cursor = myCursorArrow;
        }

        // проверка всех полей на валидацию и сохранение информации о товаре
        private void SaveGood(object sender, RoutedEventArgs e)
        {
            // проверка корректности введенных данных
            if (Validation.GetHasError(IDTextBox) ||
                Validation.GetHasError(NameTextBox) ||
                Validation.GetHasError(CategoryComboBox) ||
                Validation.GetHasError(PriceTextBox) ||
                Validation.GetHasError(AmountTextBox))
            {
                ErrorLabel.Visibility = Visibility.Visible;
                return;
            }

            // валидация пройдена
            // скрываем метку с сообщением о необходимости исправить ошибки, если метка отображалась
            if (ErrorLabel.Visibility == Visibility.Visible)
            {
                ErrorLabel.Visibility = Visibility.Collapsed;
            }

            if (File.Exists(Good.goodsFilePath))
            {
                File.Delete(Good.goodsFilePath);
            }

            foreach (Good g in goodsCollection)
            {
                Good.SerializerInXml(g);
            }

            // Popup о том, что данные сохранены
            SavePopup.IsOpen = true;
            // таймер на показ Popup на 2 секунды
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = TimeSpan.FromSeconds(2);
            time.Start();
            time.Tick += delegate
            {
                SavePopup.IsOpen = false;
                time.Stop();
            };
        }

        // добавление изображения к товару
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (fileDialog.ShowDialog() == true)
            {
                good.ImagePath = fileDialog.FileName;
            }
        }

        // удаление изображения
        private void DelImageButton_Click(object sender, RoutedEventArgs e)
        {
            good.ImagePath = null;
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;

            // получится ввести использовать лишь цифры Backspace
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void ClickableElement_MouseEnter(object sender, RoutedEventArgs e)
        {
            if ((sender as Button) != null)
                (sender as Button).Cursor = myCursorHand;
            if ((sender as ComboBoxItem) != null)
                (sender as ComboBoxItem).Cursor = myCursorHand;
        }

        private void ClickableElement_MouseLeave(object sender, RoutedEventArgs e)
        {
            if ((sender as Button) != null)
                (sender as Button).Cursor = myCursorArrow;
            if ((sender as ComboBoxItem) != null)
                (sender as ComboBoxItem).Cursor = myCursorArrow;
        }
    }
}
