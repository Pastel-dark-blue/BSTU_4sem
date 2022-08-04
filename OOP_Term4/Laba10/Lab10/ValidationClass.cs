using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    static internal class ValidationClass
    {
        static public string floatValidation(string value)
        {
            float number;
            if (Single.TryParse(value, out number))
                return null;
            else
                return "Введено недопустимое значение. Можно вводить только рациональные положительные числа " +
                    "не больше 3.402823466 в 38 степени." +
                    "\nНапример, \"1,2\" или \"109\"";
        }

        static public string intValidation(string value)
        {
            int number;
            if (Int32.TryParse(value, out number))
                return null;
            else
                return "Введено недопустимое значение. Можно вводить только целые положительные числа " +
                    "не больше 2147483647." +
                    "\nНапример, \"12\" или \"0\"";
        }

        static public string nameValidation(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
            {
                return "Поле названия не может быть пустым.";
            }
            else
            {
                return null;
            }
        }
    }
}
