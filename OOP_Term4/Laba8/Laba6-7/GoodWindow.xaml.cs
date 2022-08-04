using Laba6_7.Goods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace Laba6_7
{
    /// <summary>
    /// Логика взаимодействия для GoodWindow.xaml
    /// </summary>
    public partial class GoodWindow : Window
    {
        Good good = new Good();
        ListBox GoodsListBox;

        Cursor myCursorArrow;
        Cursor myCursorHand;

        public GoodWindow(ListBox _GoodsListBox)
        {
            InitializeComponent();

            this.DataContext = good;

            GoodsListBox = _GoodsListBox;

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
            if(ErrorLabel.Visibility == Visibility.Visible)
            {
                ErrorLabel.Visibility = Visibility.Collapsed;
            }
            // сериализуем объект
            Good.SerializerInXml(good);

            //// добавлен новый товар, его помещаем в стек, где действия "назад"
            //// то есть это товар при последующем действии "назад" будет удален из этого стека и из файла товаров тоже
            //State.undoActions.Push(good);
            ////MessageBox.Show(good.ID.ToString() + " " + State.undoActions.Peek().ID.ToString()); 

            //State.redoActions.Clear();

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

        // ввод только цифр
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

        //// ввод только цифр и точки (не работает)
        //private void PriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    foreach (var ch in e.Text)
        //    {
        //        if (!(Char.IsDigit(ch) || ch == '.'))
        //        {
        //            e.Handled = true;
        //            break;
        //        }
        //    }
        //}

    }
}
