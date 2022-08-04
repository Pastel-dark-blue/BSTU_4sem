using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

// 10 лабораторная: изучение ADO.NET
namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // чтобы получить данные из БД, нам необходимо к ней подключится
        // сначала я задала строку подключения в файле App.config
        // теперь же необходимо получить эту строку и ОТКРЫТЬ подключение

        // чтобы работать с конфигурацией приложения, нам надо добавить в проект библиотеку System.Configuration.dll. =>
        // ПКМ по проекту -> Управление пакетами NuGet... -> System.Configuration.ConfigurationManager
        // С помощью объекта ConfigurationManager.ConnectionStrings["название_строки_подключения"]
        // мы можем получить строку подключения и использовать ее в приложении. 
        SqlConnection connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Lab10.Properties.Settings.ShopConnectionString"].ConnectionString
            );

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
                // --------------------------------------- процедура
                // create or alter - оператор объединяет операторы CREATE и ALTER и создает объект, если он не существует, или изменяет его, если он уже существует.
                string procSelect = @" 
                                    create or alter procedure dbo.SelectGoods
                                    as select * from Good
                                    go";

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); // открываем подключение
                }

                // создание команды
                SqlCommand command = new SqlCommand();

                // специфицируем запрос SQL для команды
                command.CommandText = procSelect;
                command.Connection = connection;

                // добавляем процедуру в БД
                command.ExecuteNonQuery();

                // выполняем процедуру
                command.CommandText = "dbo.SelectGoods";
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();  // Создаем объект DataAdapter
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();     // Создаем объект DataSet
                adapter.Fill(ds);   // Заполняем Dataset

                GoodsDataGrid.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
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
            Lab10.EditGood editWindow = new Lab10.EditGood(GoodsDataGrid.SelectedItem as DataRowView);
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
                DataRowView selectedGood = GoodsDataGrid.SelectedItem as DataRowView;
                int? goodId = null;
                if(selectedGood != null)
                    goodId = selectedGood.Row["Id"] as int?;

                if (goodId != null)
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open();

                        string sqlExpression = "DELETE FROM Good WHERE Id=@Id";

                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = sqlExpression;
                        command.Connection = connection;

                        command.Parameters.AddWithValue("Id", goodId);

                        transaction = connection.BeginTransaction();
                        command.Transaction = transaction;

                        command.ExecuteNonQuery();

                        transaction.Commit();

                        UploadGoods(); // обновим датагрид с товарами
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                        if (transaction != null)
                            transaction.Rollback();
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
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
    }
}
