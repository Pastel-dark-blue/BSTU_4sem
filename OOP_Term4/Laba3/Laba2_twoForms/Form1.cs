using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations; 

namespace Laba2_twoForms
{
    public partial class Form1 : Form
    {
        // сразу создаем объект класса "Товар"
        public Good newGood = new Good();

        // объявление переменных ЭУ строки состояния
        ToolStripLabel objLabel; // надпись "Кол-во объектов"
        ToolStripLabel objAmountLabel; // счетчик кол-ва объектов
        ToolStripLabel infoLabel; // надпись "Текущие дата и время"
        ToolStripLabel dateLabel; // дата
        ToolStripLabel timeLabel; // время
        // таймер
        Timer timer;

        public Form1()
        {
            InitializeComponent();

            //      2 лабораторная
            Program.f1 = this;
            // обеспечит запрет на ввод нечисловых значений в полях, где должный храниться числа
            numBox.KeyPress += TextChanged_onlyIntNums;
            widthBox.KeyPress += TextChanged_onlyDoubleNums;
            heightBox.KeyPress += TextChanged_onlyDoubleNums;
            lengthBox.KeyPress += TextChanged_onlyDoubleNums;
            priceBox.KeyPress += TextChanged_onlyDoubleNums;

            //      3 лабораторная
            // Меню
            toolStripMenuItemSearch.Click += toolStripMenuItemSearch_Click; // открывает форму для поиска
            toolStripMenuItemDate.Click += toolStripMenuItemDate_Click;
            toolStripMenuItemManCountry.Click += toolStripMenuItemManCountry_Click;
            toolStripMenuItemName.Click += toolStripMenuItemName_Click;
            toolStripMenuItemAbout.Click += toolStripMenuItemAbout_Click;

            // Панель управления
            toolStripDelete.Click += toolStripDelete_Click;
            toolStripClear.Click += toolStripClear_Click;

            // инициализируем ЭУ начальными значениями
            objLabel = new ToolStripLabel();
            objLabel.Text = "Количество объектов : ";
            objAmountLabel = new ToolStripLabel();
            objAmountLabel.Text = "0";
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "\tТекущие дата и время : ";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            toolStripBack.Click += toolStripBack_Click;
            toolStripForward.Click += toolStripForward_Click;

            // добавляем ЭУ на форму в строку состояния
            statusStrip1.Items.Add(objLabel);
            statusStrip1.Items.Add(objAmountLabel);
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 }; // инициализация таймера и определение интервала
            timer.Tick += timer_Tick; // событие Timer.Tick повторяется через указанный интервал времени
            timer.Start(); // запуск таймера
        }

        void timer_Tick(object sender, EventArgs e)
        { 
            // обновляем дату и время
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        // срабатывает при вводе символов в поле
        public void TextChanged_onlyDoubleNums(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            // при этом получится ввести использовать лишь цифры, запятую и Backspace
            // e.Handled = true позволяет остановить дальнейшую обработку события
            // e.Handled = false передаст событие обработчику по умолчанию
            if (!Char.IsDigit(number) && number != 44 && number != 8)
            {
                e.Handled = true;
            }

            // запрет на ввод запятой первым символом
            if ((sender as TextBox).Text.Length <= 0 && number == ',')
            {
                e.Handled = true;
            }

            // запрет на ввод нескольких запятых в поле
            if((sender as TextBox).Text.Contains(",") && number == 44)
            {
                e.Handled = true;
            }
        }

        public void TextChanged_onlyIntNums(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            // при этом получится ввести лишь цифры и Backspace
            // e.Handled = true позволяет остановить дальнейшую обработку события
            // e.Handled = false передаст событие обработчику по умолчанию
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void saveXml_Click(object sender, EventArgs e)
        {
            if (Good.list.Count > 0)
            {
                Good.saveXml();
                MessageBox.Show("Данные были сохранены в файл");
            }
        }

        private void readXml_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            List<Good> goods = Good.readXml();

            if (goods != null)
            {
                foreach(var obj in goods)
                {
                    dataGridView1.Rows.Add(
                    obj.Name,
                    obj.Number,
                    obj.Height + "×" + obj.Width + "×" + obj.Length,
                    obj.Weight,
                    obj.Type,
                    obj.Date,
                    obj.Amount,
                    obj.Price
                );
                    if (obj.manufacturer != null)
                    {
                        dataGridView2.Rows.Add(
                            obj.manufacturer.Org,
                            obj.manufacturer.Country,
                            obj.manufacturer.Region + " область, " +
                            obj.manufacturer.District + " район, г. " +
                            obj.manufacturer.City + ", ул. " +
                            obj.manufacturer.Street + ", д. " +
                            obj.manufacturer.House,
                            obj.manufacturer.Phone
                        );
                    }
                    else
                    {
                        dataGridView2.Rows.Add(); // добавляем пустую строку в таблицу
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала сохраните объект в файл");
            }
        }

        private void manufacturer_Click(object sender, EventArgs e)
        {
            Form2 manufacturer = new Form2();
            manufacturer.ShowDialog();
        }

        // добавление объекта в статическое поле список класса Good
        private void addButton_Click(object sender, EventArgs e)
        {
            // делаем неактивными все ErrorProvider'ы
            nameError.Clear();
            numberError.Clear();
            widthError.Clear();
            heightError.Clear();
            lengthError.Clear();
            weightError.Clear();
            priceError.Clear();

            // присваиваем значения всем свойствам объекта newGood 
            if (nameBox.Text != "") { newGood.Name = nameBox.Text; }

            if (numBox.Text != "") {
                try
                {
                    newGood.Number = Convert.ToInt32(numBox.Text);
                }
                catch {
                    newGood.Number = Int32.MaxValue;
                }
            }

            if (widthBox.Text != "") {
                try
                {
                    newGood.Width = Convert.ToDouble(widthBox.Text);
                }
                catch
                {
                    newGood.Width = Double.MaxValue;
                }
            }

            if (heightBox.Text != "")
            {
                try
                {
                    newGood.Height = Convert.ToDouble(heightBox.Text);
                }
                catch
                {
                    newGood.Height = Double.MaxValue;
                }
            }

            if (lengthBox.Text != "")
            {
                try
                {
                    newGood.Length = Convert.ToDouble(lengthBox.Text);
                }
                catch
                {
                    newGood.Length = Double.MaxValue;
                }
            }

            newGood.Weight = (double)weightNumericUpDown.Value;

            if (typeRadioButton1.Checked) newGood.Type = typeRadioButton1.Text;
            if (typeRadioButton2.Checked) newGood.Type = typeRadioButton2.Text;

            newGood.Date = monthCalendar1.SelectionStart.ToShortDateString();

            newGood.Amount = amountTrackBar.Value;

            newGood.manufacturer = newGood.manufacturer;

            if (priceBox.Text != "") {
                try
                {
                    newGood.Price = Convert.ToDouble(priceBox.Text);
                }
                catch
                {
                    newGood.Price = Double.MaxValue;
                }
            }

            // валидация
            // список объектов ValidationResult оказывается заполенным если валидация не пройдена
            var results = new List<ValidationResult>();
            // ValidationContext - контекст валидации; передается валидируемый объект
            // Этот класс описывает тип или элемент, для которого выполняется проверка. 
            var context = new ValidationContext(newGood);

            // Определяет, является ли указанный объект (newGood) допустимым, используя контекст проверки (context), 
            // коллекцию результатов проверки (results) и значение, указывающее, следует ли проверять все свойства (true - проверка всех свойств).
            if (!Validator.TryValidateObject(newGood, context, results, true))
            {
                foreach (var err in results)
                {
                    string strWithError = err.ErrorMessage;

                    string incorrectPropertyName = err.MemberNames.First(); // получаем название свойства, не прошедшего валидацию
                    // в зависимости от того, какое свойство не прошло валидацию, активируем ErrorProvider возле соответствующего элемента
                    switch (incorrectPropertyName)
                    {
                        case "Name":
                            nameError.SetError(nameBox, strWithError);
                            break;
                        case "Number":
                            numberError.SetError(numBox, strWithError);
                            break;
                        case "Width":
                            widthError.SetError(widthBox, strWithError);
                            break;
                        case "Height":
                            heightError.SetError(heightBox, strWithError);
                            break;
                        case "Length":
                            lengthError.SetError(lengthBox, strWithError);
                            break;
                        case "Weight":
                            weightError.SetError(weightNumericUpDown, strWithError);
                            break;
                        case "Price":
                            priceError.SetError(priceBox, strWithError);
                            break;
                    }
                }

                MessageBox.Show(
                    "Вернитесь на предыдущую страницу и исправьте ошибки",
                    "Валидация не пройдена",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                Good.list.Add(newGood);

                listForBackForward = new List<Good>(Good.list); // копируем список Good.list в список listForBackForward
                amountOfObjects = Good.list.Count;

                // без этой строки в соответствии со значением newGood будут менятся и объекты 
                // уже добавленные в список
                newGood = new Good();

                MessageBox.Show(
                    "Объект был добавлен в список",
                    "Валидация пройдена"
                    );

                // отображение количества объектов в списке в строке состояния
                objAmountLabel.Text = Good.list.Count.ToString();
            }
        }

        public void toolStripMenuItemSearch_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm();
            search.ShowDialog();
        }

        public void toolStripMenuItemDate_Click(object sender, EventArgs e)
        {
            // коллекция для обработки считывается из файла
            IEnumerable<Good> goods = Good.readXml();
            // если в файле не было ни одного объекта
            if (goods == null)
            {
                MessageBox.Show("Прежде чем начать сортировку сохраните коллекцию объектов в файл");
                return;
            }

            var selection = from g in goods
                            orderby Convert.ToDateTime(g.Date)
                            select g;

            if (selection != null)
            {
                string path = @"D:\ООП\OOP_Course2_Term2\Laba3\orderbyDate.xml";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Good>));
                    //  ToList() - Creates a List<T> from an IEnumerable<T>.
                    xmlSerializer.Serialize(fs, selection.ToList());
                }
            }
        }

        public void toolStripMenuItemManCountry_Click(object sender, EventArgs e)
        {
            IEnumerable<Good> goods = Good.readXml();
            if (goods == null)
            {
                MessageBox.Show("Прежде чем начать сортировку сохраните коллекцию объектов в файл");
                return;
            }

            var selection = from g in goods
                            where g.manufacturer != null
                            orderby g.manufacturer.Country
                            select g;

            if (selection != null)
            {
                string path = @"D:\ООП\OOP_Course2_Term2\Laba3\orderbyManCountry.xml";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Good>));
                    //  ToList() - Creates a List<T> from an IEnumerable<T>.
                    xmlSerializer.Serialize(fs, selection.ToList());
                }
            }
        }

        public void toolStripMenuItemName_Click(object sender, EventArgs e)
        {
            List<Good> goods = Good.readXml();
            if (goods == null)
            {
                MessageBox.Show("Прежде чем начать сортировку сохраните коллекцию объектов в файл");
                return;
            }

            var selection = from g in goods
                            orderby g.Name
                            select g;

            if (selection != null)
            {
                string path = @"D:\ООП\OOP_Course2_Term2\Laba3\orderbyName.xml";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Good>));
                    //  ToList() - Creates a List<T> from an IEnumerable<T>.
                    xmlSerializer.Serialize(fs, selection.ToList());
                }
            }
        }

        public void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                (
                        "The product version is : " + Application.ProductVersion + "\n" +
                        "Full name of the developer : Курносенко Софья Андреевна",
                        "О программе",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                );
        }

        private void buttonShowHide_Click(object sender, EventArgs e)
        {
            if (toolStrip1.Visible == true)
            {
                toolStrip1.Visible = false;
                buttonShowHide.Text = "Показать";
            }
            else
            {
                toolStrip1.Visible = true;
                buttonShowHide.Text = "Скрыть";
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            Good.list.Clear();
            // отображение количества объектов в списке в строке состояния
            objAmountLabel.Text = Good.list.Count.ToString();
            amountOfObjects = 0;
        }

        private void toolStripClear_Click(object sender, EventArgs e)
        {
            // this.tabPage1.Controls - коллекция всех элементов на странице tabPage1
            foreach (Control con in this.tabPage1.Controls)
            {
                switch (con.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        (con as TextBox).Text = "";
                        break;
                    case "System.Windows.Forms.Panel":
                        foreach (Control box in con.Controls)
                        {
                            if(box is TextBox)
                                (box as TextBox).Text = "";
                        }
                        break;
                    case "System.Windows.Forms.NumericUpDown":
                        (con as NumericUpDown).Value = 0;
                        break;
                    case "System.Windows.Forms.TrackBar":
                        (con as TrackBar).Value = 1;
                        break;
                    case "System.Windows.Forms.monthCalendar":
                        (con as MonthCalendar).SelectionStart = DateTime.Now;
                        (con as MonthCalendar).SelectionEnd = DateTime.Now;
                        break;
                }
            }
        }

        // коллекция хранит
        List<Good> listForBackForward = new List<Good>();
        // индекс элемента коллекции listForBackForward, на котором сейчас стоит указатель
        int amountOfObjects = 0;

        // кнопка НАЗАД
        private void toolStripBack_Click(object sender, EventArgs e)
        {
            // если в
            if (amountOfObjects > 0)
            {
                Good.list.RemoveAt(--amountOfObjects);

                // отображение количества объектов в списке в строке состояния
                objAmountLabel.Text = Good.list.Count.ToString();
            }
        }

        // кнопка ВПЕРЕД
        private void toolStripForward_Click(object sender, EventArgs e)
        {
            if (amountOfObjects < listForBackForward.Count)
            {
                Good.list.Add(listForBackForward[amountOfObjects++]);

                // отображение количества объектов в списке в строке состояния
                objAmountLabel.Text = Good.list.Count.ToString();
            }
        }

        private void amountTrackBar_Scroll(object sender, EventArgs e)
        {
            amountLabel.Text = amountTrackBar.Value.ToString();
        }
    }
}
