using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba9.Classes
{
    internal class Person : DependencyObject
    {
        public static readonly DependencyProperty NameProperty;
        public static readonly DependencyProperty SurnameProperty;
        public static readonly DependencyProperty BirthDateProperty;

        static Person()
        {
            NameProperty = DependencyProperty.Register(
                "Name", 
                typeof(string), 
                typeof(Person), 
                new PropertyMetadata(null));

            SurnameProperty = DependencyProperty.Register(
                "Surname",
                typeof(string),
                typeof(Person),
                new PropertyMetadata(null));

            BirthDateProperty = DependencyProperty.Register(
                "BirthDate",
                typeof(string),
                typeof(Person),
                new PropertyMetadata(DateTime.Now.ToString("d"), null, CorrectBirthDate));
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }

        public string BirthDate
        {
            get { return (string)GetValue(BirthDateProperty); }
            set { SetValue(BirthDateProperty, value); }
        }

        // имя и фамилия не должны быть null, или длиной в 0 символов, или более 50
        // при возврате false - выбрасывается исключение
        private static bool ValidateNameSurname(object value)
        {
            string currentValue = (string)value;
            if (string.IsNullOrEmpty(currentValue)) 
                return false;
            else if (currentValue.Length > 50) 
                return false;

            return true;
        }

        // если в качестве даты рождения, указана дата больше текущей, то меняем знаечние на текущую дату
        private static object CorrectBirthDate(DependencyObject d, object baseValue)
        {
            DateTime date;
            if (DateTime.TryParse(baseValue.ToString(), out date))
            {
                if (date > DateTime.Now)
                {
                    baseValue = DateTime.Now.ToString("d");
                }
                else
                {
                    baseValue = date.ToString("d");
                }
            }
            else
            {
                baseValue = "-";
            }
            return baseValue;
        }
    }
}
