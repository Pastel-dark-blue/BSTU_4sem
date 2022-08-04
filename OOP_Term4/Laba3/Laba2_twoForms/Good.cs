using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Laba2_twoForms
{
    // в свойствах вызваются функции, но эти функции может вызвать и сам пользователь
    // если свойства молча устанавливают или отвергают какое-либо значение, то функции возвращают строки с пояснением того, что 
    // не так ввел пользователь
    [Serializable]
    public class Good
    {
        [XmlElement("ListOfGoods")]
        static public List<Good> list = new List<Good>();

        public Manufacturer manufacturer { get; set; }

        [Required(ErrorMessage = "Поле \"Название\" не может быть пустым")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Поле \"Название\" не может содержать более 40 символов")]
        public string Name { get; set; }

        [GoodNumber]
        [Range(0, 2147483646, ErrorMessage = "Поле \"Инвертарный номер\" должно иметь значение от 0 до 2147483646")]
        public int Number { get; set; }
        
        [Range(0.05, 1000, ErrorMessage = "Поле \"Ширина\" не может содержать значение равное 0 или большее 1000")]
        public double Width { get; set; }

        [Range(0.05, 1000, ErrorMessage = "Поле \"Высота\" не может содержать значение равное 0 или большее 1000")]
        public double Height { get; set; }

        [Range(0.05, 1000, ErrorMessage = "Поле \"Длина/глубина\" не может содержать значение равное 0 или большее 1000")]
        public double Length { get; set; }

        // минимально проверяем валидацию, ибо поле NumericUpDown на этапе конструирования формы позволяет задать ограничения
        // + не позволяет вводить что-либо, кроме чисел
        [Range(0.0001, 1000, ErrorMessage = "Поле \"Вес\" должно иметь значение, которое больше 0")]
        public double Weight { get; set; }

        // проверка не нужна, так как первая радиокнопка изначально отмечена
        // соответственно значение поле не будет пустым, а это (пустое поле) был единственный невалидный вариант
        [Required(ErrorMessage = "Заполните поле \"Тип\"")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Дата поступления\"")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Заполните поле \"Количество\"")]
        public int Amount { get; set; }

        [Range(0.05, 1000, ErrorMessage = "Поле \"Цена\" должно иметь значение, которое больше 0")]
        public double Price { get; set; }

        static public void saveXml()
        {
            string path = @"D:\ООП\OOP_Course2_Term2\Laba3\Good.xml";
            if (File.Exists(path))
            {
                List<Good> newList = list;
                List<Good> fileGood = readXml();

                if (fileGood != null) newList.AddRange(readXml());

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Good>));
                    xmlSerializer.Serialize(fs, newList);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Good>));
                    xmlSerializer.Serialize(fs, list);
                }
            }  
        }

        static public List<Good> readXml()
        {
            string path = @"D:\ООП\OOP_Course2_Term2\Laba3\Good.xml";

            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                var stringReader = new StringReader(data);
                var xmlSerializer = new XmlSerializer(typeof(List<Good>));
                List<Good> collection;
                try
                {
                    collection = (List<Good>)xmlSerializer.Deserialize(stringReader);
                }
                catch
                {
                    return null;
                }

                return collection;
            }

            return null;
        }

        public override string ToString() {

            string str = "Название : " + Name + "\n" +
                "Инвертарный номер : " + Number + "\n" +
                "Размер (высота×ширина×длина), м : " + Height + "×" + Width + "×" + Length + "\n" +
                "Вес, кг : " + Weight + "\n" +
                "Тип : " + Type + "\n" +
                "Дата поступления : " + Date + "\n" +
                "Количество : " + Amount + "\n" +
                "Цена, BYN : " + Price;

            if (manufacturer != null) 
                str += "\nПРОИЗВОДИТЕЛЬ \n" + manufacturer.ToString();

            return str;
        }
    }
}
