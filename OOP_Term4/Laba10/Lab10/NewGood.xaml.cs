using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для NewGood.xaml
    /// </summary>
    public partial class NewGood : Window
    {
        SqlConnection connection = new SqlConnection(
            ConfigurationManager.ConnectionStrings["Lab10.Properties.Settings.ShopConnectionString"].ConnectionString
        );

        public NewGood()
        {
            InitializeComponent();

            // заносим в ComboBox'ы типы и производителей из таблиц
            try
            {
                connection.Open();

                // бокс типов
                SqlCommand cmdTypes = new SqlCommand();
                cmdTypes.CommandText = "select * from TypesEnum";
                cmdTypes.Connection = connection;

                SqlDataAdapter adapterTypes = new SqlDataAdapter();
                adapterTypes.SelectCommand = cmdTypes;

                DataSet dsTypes = new DataSet();
                adapterTypes.Fill(dsTypes);

                TypeComboBox.ItemsSource = dsTypes.Tables[0].DefaultView;


                // бокс производителей
                SqlCommand cmdOrg = new SqlCommand();
                cmdOrg.CommandText = "select * from Organization";
                cmdOrg.Connection = connection;

                SqlDataAdapter adapterOrg = new SqlDataAdapter();
                adapterOrg.SelectCommand = cmdOrg;

                DataSet dsOrg = new DataSet();
                adapterOrg.Fill(dsOrg);
                
                ManufacturerComboBox.ItemsSource = dsOrg.Tables[0].DefaultView;
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // только поле с названием товара не может быть пустым, так что для него тернарной операции не будет
            string goodName = NameTxtBox.txtLimitedInput.Text;

            // если в поле не введено значение, то в таблицу дабавляем null
            string goodWidth = (WidthTxtBox.Text.Trim() == "") ? null : WidthTxtBox.Text.Trim();
            string goodHeight = (HeightTxtBox.Text.Trim() == "") ? null : HeightTxtBox.Text.Trim();
            string goodLength = (LengthTxtBox.Text.Trim() == "") ? null : LengthTxtBox.Text.Trim();

            // получаем из ComboBox тип
            var typeItem = TypeComboBox.SelectedItem as DataRowView;
            string goodType = null;
            if (typeItem != null)    // если тип был выбран
                goodType = typeItem.Row["Name"].ToString();

            string goodWeight = (WeightTxtBox.Text.Trim() == "") ? null : WeightTxtBox.Text.Trim();
            string goodAmount = (AmountTxtBox.Text.Trim() == "") ? null : AmountTxtBox.Text.Trim();
            string goodPrice = (PriceTxtBox.Text.Trim() == "") ? null : PriceTxtBox.Text.Trim();
            DateTime? goodDate = GoodCalendar.SelectedDate;
            string goodImg = GoodImg.Source?.ToString();

            // получаем из ComboBox производителя
            var manItem = ManufacturerComboBox.SelectedItem as DataRowView; 
            int? goodManId = null;
            if (manItem != null)    // если производитель был выбран
                goodManId = (int?)manItem.Row["Id"];

            bool IsValid = true;
            bool IsNotValid = false;
            #region Валидация
            // название, не может быть пустым
            string nameError = ValidationClass.nameValidation(goodName);
            if (nameError != null)
            {
                changeNotValidBox(nameError, NameTxtBox.txtLimitedInput);
                IsNotValid = true;
            }
            else
            {
                changeValidBox(NameTxtBox.txtLimitedInput);
                IsValid = true;
            }

            // валидация ширины (значение не может превышать максимально допустимое значение для float)
            // при этом отсутствие значения допустимо, тогда в таблицу попадет значение NULL
            if (goodWidth != null)
            {
                string widthError = ValidationClass.floatValidation(goodWidth);
                if(widthError != null)
                {
                    changeNotValidBox(widthError, WidthTxtBox);
                    IsNotValid = true;
                }
                else
                {
                    changeValidBox(WidthTxtBox);
                    IsValid = true;
                }
            }

            // высота
            if (goodHeight != null)
            {
                string heightError = ValidationClass.floatValidation(goodHeight);
                if (heightError != null)
                {
                    changeNotValidBox(heightError, HeightTxtBox);
                    IsNotValid = true;
                }
                else
                {
                    changeValidBox(HeightTxtBox);
                    IsValid = true;
                }
            }

            // длина
            if (goodLength != null)
            {
                string lengthError = ValidationClass.floatValidation(goodLength);
                if (lengthError != null)
                {
                    changeNotValidBox(lengthError, LengthTxtBox);
                    IsNotValid = true;
                }
                else
                {
                    changeValidBox(LengthTxtBox);
                    IsValid = true;
                }
            }

            // вес
            if (goodWeight != null)
            {
                string weightError = ValidationClass.floatValidation(goodWeight);
                if (weightError != null)
                {
                    changeNotValidBox(weightError, WeightTxtBox);
                    IsNotValid = true;
                }
                else
                {
                    changeValidBox(WeightTxtBox);
                    IsValid = true;
                }
            }

            // кол-во
            if (goodAmount != null)
            {
                string amountError = ValidationClass.intValidation(goodAmount);
                if (amountError != null)
                {
                    changeNotValidBox(amountError, AmountTxtBox);
                    IsNotValid = true;
                }
                else
                {
                    changeValidBox(AmountTxtBox);
                    IsValid = true;
                }
            }

            // цена
            if (goodPrice != null)
            {
                string priceError = ValidationClass.floatValidation(goodPrice);
                if (priceError != null)
                {
                    changeNotValidBox(priceError, PriceTxtBox);
                    IsNotValid = true;
                }
                else
                {
                    changeValidBox(PriceTxtBox);
                    IsValid = true;
                }
            }

            #endregion

            if (IsValid && (!IsNotValid))
            {
                bool nullValuesIsOk = true;
                #region Оповещение пользователя о том, что не все поля заполнены
                bool thereAreNullValues = false;
                string nullValues = "Следующие поля не заполнены:";

                if (goodWidth == null)
                {
                    nullValues += "\n\"Ширина, см\"";
                    thereAreNullValues = true;
                }

                if (goodHeight == null)
                {
                    nullValues += "\n\"Высота, см\"";
                    thereAreNullValues = true;
                }

                if (goodLength == null)
                {
                    nullValues += "\n\"Длина, см\"";
                    thereAreNullValues = true;
                }

                if (goodType == null)
                {
                    nullValues += "\n\"Тип\"";
                    thereAreNullValues = true;
                }
                
                if (goodWeight == null)
                {
                    nullValues += "\n\"Вес (1 шт), кг\"";
                    thereAreNullValues = true;
                }

                if (goodAmount == null)
                {
                    nullValues += "\n\"Количество, шт\"";
                    thereAreNullValues = true;
                }

                if (goodPrice == null)
                {
                    nullValues += "\n\"Цена, $\"";
                    thereAreNullValues = true;
                }

                if (goodDate == null)
                {
                    nullValues += "\n\"Высота, см\"";
                    thereAreNullValues = true;
                }

                if (goodImg == null)
                {
                    nullValues += "\n\"Фотография\"";
                    thereAreNullValues = true;
                }

                if (goodManId == null)
                {
                    nullValues += "\n\"Производитель\"";
                    thereAreNullValues = true;
                }

                if (thereAreNullValues)
                {
                    System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(
                        nullValues + "\nЕсли хотите исправить это нажмите кнопку \"Отмена\", если вас это устаривает нажмите \"ОК\".",
                        "Пустые значения",
                        System.Windows.Forms.MessageBoxButtons.OKCancel
                    );

                    if(dialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        nullValuesIsOk = true;
                    }
                    else
                    {
                        nullValuesIsOk = false;
                    }
                }
                #endregion

                if (nullValuesIsOk)
                {
                    SqlTransaction transaction = null;

                    try
                    {
                        connection.Open();

                        string sqlExpression = "INSERT INTO Good (Name, Width_cm, Height_cm, Length_cm, Weight_kg, " +
                                                "Type, Date, Amount, Price_$, ManufacturerId, Photo)" +
                                                "VALUES(@Name, @Width_cm, @Height_cm, @Length_cm, @Weight_kg, " +
                                                "@Type, @Date, @Amount, @Price_$, @ManufacturerId, @Photo)";

                        // начало транзакции
                        transaction = connection.BeginTransaction();

                        SqlCommand command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = sqlExpression;
                        command.Connection = connection;

                        #region Добавление параметров в команду
                        // создаем параметр для названия
                        SqlParameter nameParameter = new SqlParameter("Name", SqlDbType.NVarChar, 50);
                        // определяем значение
                        nameParameter.Value = goodName;
                        // добавляем параметр к команде
                        command.Parameters.Add(nameParameter);

                        // ширина
                        float width;
                        if (Single.TryParse(goodWidth, out width))
                            command.Parameters.AddWithValue("Width_cm", width);
                        else
                            command.Parameters.AddWithValue("Width_cm", System.DBNull.Value);

                        // высота
                        float height;
                        if (Single.TryParse(goodHeight, out height))
                            command.Parameters.AddWithValue("Height_cm", height);
                        else
                            command.Parameters.AddWithValue("Height_cm", System.DBNull.Value);

                        // длина
                        float length;
                        if (Single.TryParse(goodLength, out length))
                            command.Parameters.AddWithValue("Length_cm", length);
                        else
                            command.Parameters.AddWithValue("Length_cm", System.DBNull.Value);

                        // вес
                        float weight;
                        if (Single.TryParse(goodWeight, out weight))
                            command.Parameters.AddWithValue("Weight_kg", weight);
                        else
                            command.Parameters.AddWithValue("Weight_kg", System.DBNull.Value);

                        // тип товара
                        if (goodType != null)
                            command.Parameters.AddWithValue("Type", goodType);
                        else
                            command.Parameters.AddWithValue("Type", System.DBNull.Value);

                        // дата поступления
                        if (goodDate != null)
                            command.Parameters.AddWithValue("Date", goodDate);
                        else
                            command.Parameters.AddWithValue("Date", System.DBNull.Value);

                        // кол-во
                        int amount;
                        if (Int32.TryParse(goodAmount, out amount))
                            command.Parameters.AddWithValue("Amount", amount);
                        else
                            command.Parameters.AddWithValue("Amount", System.DBNull.Value);

                        // цена
                        float price;
                        if (Single.TryParse(goodPrice, out price))
                            command.Parameters.AddWithValue("Price_$", price);
                        else
                            command.Parameters.AddWithValue("Price_$", System.DBNull.Value);

                        // изображение
                        if (goodImg != null)
                            command.Parameters.AddWithValue("Photo", goodImg);
                        else
                            command.Parameters.AddWithValue("Photo", System.DBNull.Value);

                        // производитель
                        int manId;
                        if(Int32.TryParse(goodManId.ToString(), out manId))
                            command.Parameters.AddWithValue("ManufacturerId", manId);
                        else
                            command.Parameters.AddWithValue("ManufacturerId", System.DBNull.Value);

                        #endregion

                        command.ExecuteNonQuery();
                        transaction.Commit();

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
            else
            {
                // Popup о том, что нужно исправить ошибки
                ErrorPopup.IsOpen = true;
                // таймер на показ Popup на 2 секунды
                DispatcherTimer time = new DispatcherTimer();
                time.Interval = TimeSpan.FromSeconds(2);
                time.Start();
                time.Tick += delegate
                {
                    ErrorPopup.IsOpen = false;
                    time.Stop();
                };
            }
        }

        // для полей, допускающих лишь рациональные числа
        private void FloatTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // получаем текст из поля ввода
            string txt = ((TextBox)sender).Text;

            int numOfChar = (int)(char)e.Text[0];
            if (!((numOfChar >= 48 && numOfChar <= 57) || numOfChar == 44) ||   // нельзя ввести что-то, кроме цифры или запятой
                (txt.Contains(',') && numOfChar == 44) ||   // нельзя ввести несколько запятых в одно поле
                (txt.Length==0) && numOfChar == 44)   //   нельзя ввести запятую первым символом
            {
                e.Handled = true;
            }
        }

        // для полей, допускающих лишь целые числа
        private void IntTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // получаем текст из поля ввода
            string txt = ((TextBox)sender).Text;

            int numOfChar = (int)(char)e.Text[0];
            if (!((numOfChar >= 48 && numOfChar <= 57))) 
            {
                e.Handled = true;
            }
        }

        // когда поле теряет фокус - убираем все пробелы в нем, а так же запятую, если она была поставлена в конце
        private void TxtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb= sender as TextBox;
            if(tb != null)
            {
                // если юзер ctrl+c и ctrl+v невалидные символы
                string allowedSymbols = "0123456789,";  // допустимые символы
                StringBuilder sb = new StringBuilder();
                
                foreach(char ch in tb.Text)
                {
                    // в новую (валидную) строку добавляем только те символы строки tb.Text, которые есть в allowedSymbols
                    sb.Append(allowedSymbols.Contains(ch) ? ch : ' ');
                }
                tb.Text = sb.ToString();

                // убираем пробелы
                tb.Text = string.Join(
                    "",
                    (tb.Text.Split(default(string[]),
                    StringSplitOptions.RemoveEmptyEntries))
                );

                // убираем запятую, если она стоит как последний символ
                if (tb.Text.Length > 0 && tb.Text[tb.Text.Length - 1] == ',') 
                {
                    tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
                }
            }
        }

        // подсказка для поля с не валидными данными
        private ToolTip CreateToolTip(string text)
        {
            // всплывающая подсказка для отображения текста ошибки
            ToolTip tooltip = new ToolTip();

            Style style = Application.Current.FindResource("errorToolTipStyle") as Style;
            tooltip.Style = style;
            tooltip.Content = text;

            return tooltip;
        }

        // добавляем красную обводку невалидному полю и подсказку в виде ToolTip
        private void changeNotValidBox(string errorMessage, object boxName)
        {
            TextBox textBox = boxName as TextBox;
            if (textBox!=null)
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Red) { Opacity = 0.8 };
                textBox.ToolTip = CreateToolTip(errorMessage);
            }
        }

        // убираем красную обводку у валидного поля и подсказку тоже убираем
        private void changeValidBox(object boxName)
        {
            TextBox textBox = boxName as TextBox;
            if (textBox != null)
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Black);
                textBox.ToolTip = null;
            }
        }

        // добавление фото
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog=new System.Windows.Forms.OpenFileDialog();

            dialog.Filter= "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";

            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;

                GoodImg.Source = new BitmapImage(new Uri(path));
            }
        }

        // удаление фото
        private void DelImageButton_Click(object sender, RoutedEventArgs e)
        {
            GoodImg.Source = null;
        }
    }
}
