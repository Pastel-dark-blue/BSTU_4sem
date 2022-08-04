using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Lab10.UOW;

// 10 лабораторная: изучение ADO.NET
namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Good> allGoods = null;

        public MainWindow()
        {
            InitializeComponent();
            UploadGoods();
        }

        // --------------------------------------- загрузка товаров в DataGrid
        private void UploadGoods()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    allGoods = uow.GoodRepository.GetAll();
                    GoodsDataGrid.ItemsSource = allGoods;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // --------------------------------------- добавление нового товара
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Lab10.NewGood newGoodWindow = new Lab10.NewGood();
            newGoodWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Lab10.EditGood editWindow = new Lab10.EditGood(GoodsDataGrid.SelectedItem as Good);
            editWindow.Show();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            UploadGoods();
        }

        private void DeleteTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                        "Вы уверены, что хотите удалить товар?\n" +
                        "Если нет, то нажмите кнопку \"Отмена\", если хотите удалить то нажмите - \"ОК\".",
                        "Подтверждение удаления товара",
                        System.Windows.Forms.MessageBoxButtons.OKCancel
                    );

            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Good selectedGood = GoodsDataGrid.SelectedItem as Good;

                bool success = false;

                if (selectedGood != null)
                {
                    try
                    {
                        using (UnitOfWork uow = new UnitOfWork())
                        {
                            uow.GoodRepository.Remove(selectedGood);
                            uow.Save();
                            success = true;
                        }

                        if (success)
                            UploadGoods();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void prevItem_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex != 0)
            {
                GoodsDataGrid.SelectedIndex--;
            }
        }

        private void nextItem_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedIndex != GoodsDataGrid.Items.Count - 1)
            {
                GoodsDataGrid.SelectedIndex++;
            }
        }

        private void searchQueryName_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Regex lowerReg = new Regex(searchQueryName.Text.ToLower()); // введенный для поиска текст

                if (allGoods != null)
                {
                    List<Good> resultListOfGoods = new List<Good>();
                    foreach (var g in allGoods)
                    {
                        if (lowerReg.IsMatch(g.Name.ToLower()))
                        {
                            resultListOfGoods.Add(g);
                        }
                    }

                    // заполняем список найденными товарами
                    GoodsDataGrid.ItemsSource = resultListOfGoods;
                }
            }
        }

        private void searchQueryNamePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Regex lowerReg = new Regex(searchQueryNamePrice.Text.ToLower()); // введенный для поиска текст

                if (allGoods != null)
                {
                    List<Good> resultListOfGoods = new List<Good>();
                    foreach (var g in allGoods)
                    {
                        if (lowerReg.IsMatch(g.Name.ToLower()) || lowerReg.IsMatch(g.Price__.ToString().ToLower()))
                        {
                            resultListOfGoods.Add(g);
                        }
                    }

                    // заполняем список найденными товарами
                    GoodsDataGrid.ItemsSource = resultListOfGoods;
                }
            }
        }
    }
}
