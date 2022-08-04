using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Laba2_twoForms
{
    public partial class Form2 : Form
    {
        public Manufacturer newMan = new Manufacturer();

        public Form2()
        {
            InitializeComponent();

            houseTextBox.KeyPress += TextChanged_onlyIntNums;

            saveButton.Click += saveButton_Click;

            orgTextBox.Leave += orgTextBox_Leave;
            countryComboBox.Leave += countryComboBox_Leave;
            phoneMaskedTextBox.Leave += phoneMaskedTextBox_Leave;
            regionTextBox.Leave += regionTextBox_Leave;
            districtTextBox.Leave += districtTextBox_Leave;
            cityTextBox.Leave += cityTextBox_Leave;
            streetTextBox.Leave += streetTextBox_Leave;
            houseTextBox.Leave += houseTextBox_Leave;

            orgTextBox.KeyPress += textChanged_onlyLetters;
            regionTextBox.KeyPress += textChanged_onlyLetters;
            districtTextBox.KeyPress += textChanged_onlyLetters;
            cityTextBox.KeyPress += textChanged_onlyLetters;
            streetTextBox.KeyPress += textChanged_onlyLetters;

            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Уверены, что не забыли сохранить введенные данные?",
                "Закрытие формы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
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

        private void orgTextBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newMan.orgFunc(field.Text);

            message(field, result);
        }

        private void textChanged_onlyLetters(object sender, KeyPressEventArgs e)
        {
            char let = e.KeyChar;

            // получится ввести русские и английские буквы, Backspace, пробел и дефис
            if ((let < 'A' || let > 'z') && (let < 'А' || let > 'я') && let != 8 && let != 32 && let != 45)  
            {
                e.Handled = true;
            }
        }

        private void countryComboBox_Leave(object sender, EventArgs e)
        {
            ComboBox field = sender as ComboBox;
            string result = "";

            result = newMan.countryFunc(field.Text);

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

        private void phoneMaskedTextBox_Leave(object sender, EventArgs e)
        {
            MaskedTextBox field = sender as MaskedTextBox;
            string result = "";

            result = newMan.phoneFunc(field.Text);

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

        private void regionTextBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newMan.regionFunc(field.Text);

            message(field, result);
        }

        private void districtTextBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newMan.districtFunc(field.Text);

            message(field, result);
        }

        private void cityTextBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newMan.cityFunc(field.Text);

            message(field, result);
        }

        private void streetTextBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newMan.streetFunc(field.Text);

            message(field, result);
        }

        private void houseTextBox_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            string result = "";

            result = newMan.houseFunc(field.Text);

            message(field, result);
        }

        private void message(TextBox field, string result)
        {
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            // запускаем проверку всех полей
            string returnedValue = "";
            string result = "";

            returnedValue = newMan.orgFunc(orgTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                orgTextBox.BackColor = Color.Red;
            }

            returnedValue = newMan.countryFunc(countryComboBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                countryComboBox.BackColor = Color.Red;
            }

            returnedValue = newMan.phoneFunc(phoneMaskedTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                phoneMaskedTextBox.BackColor = Color.Red;
            }

            returnedValue = newMan.regionFunc(regionTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                regionTextBox.BackColor = Color.Red;
            }

            returnedValue = newMan.districtFunc(districtTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                districtTextBox.BackColor = Color.Red;
            }

            returnedValue = newMan.cityFunc(cityTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                cityTextBox.BackColor = Color.Red;
            }

            returnedValue = newMan.streetFunc(streetTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                streetTextBox.BackColor = Color.Red;
            }

            returnedValue = newMan.houseFunc(houseTextBox.Text);
            if (returnedValue != "ok")
            {
                result += returnedValue + "\n";
                houseTextBox.BackColor = Color.Red;
            }

            if (result != "") MessageBox.Show(result);
            else
            {
                Program.f1.newGood.manufacturer = newMan;
                MessageBox.Show("Данные о производителе текущего товара были сохранены");
            }
        }
    }
}
