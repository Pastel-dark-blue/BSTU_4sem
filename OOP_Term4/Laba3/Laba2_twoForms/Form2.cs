using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Laba2_twoForms
{
    public partial class Form2 : Form
    {
        public Manufacturer newMan = new Manufacturer();

        public Form2()
        {
            InitializeComponent();

            houseTextBox.KeyPress += textChanged_onlyNums;

            saveButton.Click += saveButton_Click;

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

        private void textChanged_onlyNums(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            // при этом получится ввести лишь цифры и Backspace
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            // запрет на ввод нуля первым символом
            if ((sender as TextBox).Text.Length <= 0 && number == '0')
            {
                e.Handled = true;
            }
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            // делаем неактивынми все ErrorProvider'ы
            orgError.Clear();
            countryError.Clear();
            phoneError.Clear();
            regionError.Clear();
            districtError.Clear();
            cityError.Clear();
            streetError.Clear();
            houseError.Clear();

            // присваиваем значения всем свойствам объекта newMan
            newMan.Org = orgTextBox.Text;
            newMan.Country = countryComboBox.Text;
            newMan.Phone = phoneMaskedTextBox.Text;
            newMan.Region = regionTextBox.Text;
            newMan.District = districtTextBox.Text;
            newMan.City = cityTextBox.Text;
            newMan.Street = streetTextBox.Text;
            if (houseTextBox.Text != "") {
                newMan.House = Convert.ToInt32(houseTextBox.Text);
            }

            // валидация
            var results = new List<ValidationResult>();
            var context = new ValidationContext(newMan);

            if(!Validator.TryValidateObject(newMan, context, results, true))
            {
                foreach(var err in results)
                {
                    string strWithError = err.ErrorMessage;

                    string incorrectPropertyName = err.MemberNames.First(); // получаем название свойства, не прошедшего валидацию
                    // в зависимости от того, какое свойство не прошло валидацию, активируем ErrorProvider возле соответствующего элемента
                    switch (incorrectPropertyName)
                    {
                        case "Org":
                            orgError.SetError(orgTextBox, strWithError);
                            break;
                        case "Country":
                            countryError.SetError(countryComboBox, strWithError);
                            break;
                        case "Phone":
                            phoneError.SetError(phoneMaskedTextBox, strWithError);
                            break;
                        case "Region":
                            regionError.SetError(regionTextBox, strWithError);
                            break;
                        case "District":
                            districtError.SetError(districtTextBox, strWithError);
                            break;
                        case "City":
                            cityError.SetError(cityTextBox, strWithError);
                            break;
                        case "Street":
                            streetError.SetError(streetTextBox, strWithError);
                            break;
                        case "House":
                            houseError.SetError(houseTextBox, strWithError);
                            break;
                    }
                }

                MessageBox.Show(
                    "Исправьте ошибки",
                    "Валидация не пройдена",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                Program.f1.newGood.manufacturer = newMan;
                MessageBox.Show("Данные о производителе текущего товара были сохранены");
            }
        }
    }
}
