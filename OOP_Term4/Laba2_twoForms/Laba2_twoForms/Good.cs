using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;
using System.Xml.Serialization;

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

        private string name;
        public string Name       
        {
            get { return name; }
            set {
                string result = nameFunc(value);
                if (result == "ok") name = value;
            }
        }
        public string nameFunc(string value)
        {
            value = value.Trim();
            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Название\"";
            }
            else if (value.Length > 40)
            {
                return "Поле \"Название\" не может содержать более 40 символов";
            }
            else
            {
                name = value;
                return "ok";
            }
        }

        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                string result = numberFunc(value.ToString());
                if (result == "ok") number = value;
            }
        }
        public string numberFunc(string value)
        {
            int num = 0;
            bool isNum = Int32.TryParse(value, out num);

            if (!isNum)
            {
                return "Заполните поле \"Инвентарный номер\"";
            }
            else if (num == 0 || num > 100000)
            {
                return "Поле \"Инвентарный номер\" не может содержать значение равное 0 или большее 100000";
            }
            else
            {
                number = num;
                return "ok";
            }
        }

        private double width;
        public double Width
        {
            get { return width; }
            set
            {
                string result = widthFunc(value.ToString());
                if (result == "ok") width = value;
            }
        }
        public string widthFunc(string value)
        {
            double num = 0;
            bool isNum = Double.TryParse(value, out num);

            if (!isNum)
            {
                return "Заполните поле \"Ширина\"";
            }
            else if (num == 0 || num > 1000)
            {
                return "Поле \"Ширина\" не может содержать значение равное 0 или большее 1000";
            }
            else
            {
                width = num;
                return "ok";
            }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set
            {
                string result = heightFunc(value.ToString());
                if (result == "ok") height = value;
            }
        }
        public string heightFunc(string value)
        {
            double num = 0;
            bool isNum = Double.TryParse(value, out num);

            if (!isNum)
            {
                return "Заполните поле \"Высота\"";
            }
            else if (num == 0 || num > 1000)
            {
                return "Поле \"Высота\" не может содержать значение равное 0 или большее 1000";
            }
            else
            {
                height = num;
                return "ok";
            }
        }

        private double length;
        public double Length
        {
            get { return length; }
            set
            {
                string result = lengthFunc(value.ToString());
                if (result == "ok") length = value;
            }
        }
        public string lengthFunc(string value)
        {
            double num = 0;
            bool isNum = Double.TryParse(value, out num);

            if (!isNum)
            {
                return "Заполните поле \"Длина/глубина\"";
            }
            else if (num == 0 || num > 1000)
            {
                return "Поле \"Длина/глубина\" не может содержать значение равное 0 или большее 1000";
            }
            else
            {
                length = num;
                return "ok";
            }
        }

        // минимально проверяем валидацию, ибо поле NumericUpDown на этапе конструирования формы позволяет задать ограничения
        // + не позволяет вводить что-либо, кроме чисел
        private double weight;
        public double Weight { 
            get { return weight; }
            set
            {
                string result = weightFunc((decimal)value);
                if (result == "ok") weight = value;
            }
        }
        public string weightFunc(decimal value)
        {
            double num = (double)value;

            if (num == 0)
            {
                return "Поле \"Вес\" должно иметь значение, которое больше 0";
            }
            else
            {
                weight = num;
                return "ok";
            }
        }

        // проверка не нужна, так как первая радиокнопка изначально отмечена
        // соответственно значение поле не будет пустым, а это (пустое поле) был единственный невалидный вариант
        public string Type { get; set; }

        public string Date { get; set; }

        public int Amount { get; set; }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                string result = priceFunc(value.ToString());
                if (result == "ok") price = value;
            }
        }
        public string priceFunc(string value)
        {
            double num = 0;
            bool isNum = Double.TryParse(value, out num);

            if (!isNum)
            {
                return "Заполните поле \"Цена\"";
            }
            else if(num == 0)
            {
                return "Поле \"Цена\" должно иметь значение, которое больше 0";
            }
            else
            {
                price = num;
                return "ok";
            }
        }

        static public void saveXml()
        {
            string path = @"D:\ООП\OOP_Course2_Term2\Laba2_twoForms\Good.xml";
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
            string path = @"D:\ООП\OOP_Course2_Term2\Laba2_twoForms\Good.xml";

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
    }
}
