using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Laba2_twoForms
{
    public class Manufacturer
    {
        [Required(ErrorMessage = "Поле \"Организация\" не может быть пустым")]
        public string Org { get; set; }

        [Required(ErrorMessage = "Поле \"Страна\" не может быть пустым")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Поле \"Телефон\" не может быть пустым")]
        [RegularExpression(@"^\(\d{2}\)\d{3}-\d{2}-\d{2}", ErrorMessage = "Поле заполнено некорректно")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле \"Область\" не может быть пустым")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Поле \"Район\" не может быть пустым")]
        public string District { get; set; }

        [Required(ErrorMessage = "Поле \"Город\" не может быть пустым")]
        public string City { get; set; }

        [Required(ErrorMessage = "Поле \"Улица\" не может быть пустым")]
        public string Street { get; set; }

        [Range(1, 1000, ErrorMessage = "Поле \"Дом\" должно иметь значение от 1 до 1000")]
        public int House { get; set; }

        public override string ToString()
        {
            return "\tОгранизация : " + Org + "\n" +
            "\tСтрана : " + Country + "\n" +
            "\tТелефон : " + Phone + "\n" +
            "\tАдрес : \n" +
            "\t\tОбласть : " + Region + "\n" +
            "\t\tРайон : " + District + "\n" +
            "\t\tГород : " + City + "\n" +
            "\t\tУлица : " + Street + "\n" +
            "\t\tДом : " + House;
        }
    }
}
