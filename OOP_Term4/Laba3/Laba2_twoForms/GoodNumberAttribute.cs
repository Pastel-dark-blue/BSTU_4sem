using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Laba2_twoForms
{
    class GoodNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // проверка на возможность приведения переданного значения, которое попадает в переменную value,
            // на возможность к приведению к типу double
            if (value is int goodNumber)
            {
                // считываем в список все объекты из файла 
                List<Good> goods = Good.readXml();

                // если список не пуст, то проверяем его на наличие объекта с таким же инвертарным номером, что был введен
                if (goods != null)
                {
                    foreach(var g in goods)
                    {
                        if (g.Number == goodNumber)
                        {
                            ErrorMessage = "В файле со списком товаров уже есть товар с таким инвертарным номером";
                            // возвращаем false, так как валидация не пройдена
                            return false;
                        }
                    }

                    return true;
                }

                // валидация пройдена
                return true;
            }
            ErrorMessage = "Поле \"Инвертарный\" номер не может быть пустым";
            return false;
        }
    }
}
