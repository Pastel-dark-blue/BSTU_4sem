using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;

namespace Laba2_twoForms
{
    public partial class Form1 : Form
    {
        // сразу создаем объект класса "Товар"
        public Good newGood = new Good();

        public Form1()
        {
            Program.f1 = this;
            InitializeComponent();

            // обеспечит запрет на ввод нечисловых значений в полях, где должный храниться числа
            numBox.KeyPress += TextChanged_onlyIntNums;
            widthBox.KeyPress += TextChanged_onlyDoubleNums;
            heightBox.KeyPress += TextChanged_onlyDoubleNums;
            lengthBox.KeyPress += TextChanged_onlyDoubleNums;
            priceBox.KeyPress += TextChanged_onlyDoubleNums;

            // проверка валидности введенных данных, когда пользователь покидает элемент
            nameBox.Leave += nameBox_Leave;
            numBox.Leave += numBox_Leave;
            widthBox.Leave += widthBox_Leave;
            heightBox.Leave += heightBox_Leave;
            lengthBox.Leave += lengthBox_Leave;
            weightNumericUpDown.Leave += weightNumericUpDown_Leave;
            priceBox.Leave += priceBox_Leave;

            amountTrackBar.Scroll += amountTrackBar_Change;
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
            if ((sender as TextBox).Text.Contains(",") && number == 44)
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

        private void nameBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newGood.nameFunc(field.Text);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void numBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newGood.numberFunc(field.Text);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void widthBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newGood.widthFunc(field.Text);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void heightBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newGood.heightFunc(field.Text);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void lengthBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newGood.lengthFunc(field.Text);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void weightNumericUpDown_Leave(object sender, EventArgs e)
        {
            NumericUpDown field = sender as NumericUpDown;
            string result = "";

            result = newGood.weightFunc(field.Value);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void priceBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newGood.priceFunc(field.Text);

            if (result != "ok")
            {
                field.BackColor = Color.Red;
                MessageBox.Show(result);
            }
            else
            {
                field.BackColor = Color.White;
            }
        }

        private void amountTrackBar_Change(object sender, EventArgs e)
        {
            amountLabel.Text = (sender as TrackBar).Value.ToString();
        }

        private void saveXml_Click(object sender, EventArgs e)
        {
            if(Good.list != null)
            {
                Good.saveXml();
            }
        }

        private void readXml_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            List<Good> goods = Good.readXml();

            if (goods != null)
            {
                foreach (var obj in goods)
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
            // запускаем проверку всех полей
            string returnedValue = "";
            string result = "";

            returnedValue = newGood.nameFunc(nameBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                nameBox.BackColor = Color.Red;
            }

            returnedValue = newGood.numberFunc(numBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                numBox.BackColor = Color.Red;
            }

            returnedValue = newGood.widthFunc(widthBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                widthBox.BackColor = Color.Red;
            }

            returnedValue = newGood.heightFunc(heightBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                heightBox.BackColor = Color.Red;
            }

            returnedValue = newGood.lengthFunc(lengthBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                lengthBox.BackColor = Color.Red;
            }

            returnedValue = newGood.weightFunc(weightNumericUpDown.Value);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                weightNumericUpDown.BackColor = Color.Red;
            }

            returnedValue = newGood.priceFunc(priceBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                priceBox.BackColor = Color.Red;
            }

            if (typeRadioButton1.Checked) newGood.Type = typeRadioButton1.Text;
            if (typeRadioButton2.Checked) newGood.Type = typeRadioButton2.Text;

            newGood.Date = monthCalendar1.SelectionStart.ToShortDateString();

            newGood.Amount = amountTrackBar.Value;

            if (result != "") MessageBox.Show(result);
            else
            {
                Good.list.Add(newGood);

                // без этой строки в соответствии со значением newGood будут менятся и объекты 
                // уже добавленные в список
                newGood = new Good();

                MessageBox.Show(
                    "Объект был добавлен в список",
                    "Валидация пройдена"
                    );
            }
        }
    }
}
