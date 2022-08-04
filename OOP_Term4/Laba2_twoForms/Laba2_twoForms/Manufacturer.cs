using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2_twoForms
{
    public class Manufacturer
    {
        private string org;
        public string Org
        {
            get { return org; }
            set
            {
                string result = orgFunc(value);
                if (result == "ok") org = value;
            }
        }
        public string orgFunc(string value)
        {
            value = value.Trim();

            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Организация\"";
            }
            else if (value.Length > 40)
            {
                return "Поле \"Организация\" не может содержать более 40 символов";
            }
            else
            {
                org = value;
                return "ok";
            }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                string result = countryFunc(value);
                if (result == "ok") country = value;
            }
        }
        public string countryFunc(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Страна\"";
            }
            else {
                country = value;
                return "ok"; 
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                string result = phoneFunc(value);
                if (result == "ok") phone = value;
            }
        }
        public string phoneFunc(string value)
        {
            if (value.Length < 13)
            {
                return "Заполните поле \"Телефон\" 9-ю цифрами";
            }
            else
            {
                phone = "+375" + value;
                return "ok";
            }
        }

        private string region;
        public string Region
        {
            get { return region; }
            set
            {
                string result = regionFunc(value);
                if (result == "ok") region = value;
            }
        }
        public string regionFunc (string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Область\"";
            }
            else if (value.Length > 40)
            {
                return "Поле \"Область\" не может содержать более 40 символов";
            }
            else
            {
                region = value;
                return "ok";
            }
        }

        private string district;
        public string District
        {
            get { return district; }
            set
            {
                string result = districtFunc(value);
                if (result == "ok") district = value;
            }
        }
        public string districtFunc(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Район\"";
            }
            else if (value.Length > 40)
            {
                return "Поле \"Район\" не может содержать более 40 символов";
            }
            else
            {
                district = value;
                return "ok";
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                string result = cityFunc(value);
                if (result == "ok") city = value;
            }
        }
        public string cityFunc(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Город\"";
            }
            else if (value.Length > 40)
            {
                return "Поле \"Город\" не может содержать более 40 символов";
            }
            else
            {
                city = value;
                return "ok";
            }
        }

        private string street;
        public string Street
        {
            get { return street; }
            set
            {
                string result = streetFunc(value);
                if (result == "ok") street = value;
            }
        }
        public string streetFunc(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return "Заполните поле \"Улица\"";
            }
            else if (value.Length > 40)
            {
                return "Поле \"Улица\" не может содержать более 40 символов";
            }
            else
            {
                street = value;
                return "ok";
            }
        }

        private int house;
        public int House
        {
            get { return house; }
            set
            {
                string result = houseFunc(value.ToString());
                if (result == "ok") house = value;
            }
        }
        public string houseFunc(string value)
        {
            int num = 0;
            bool isNum = Int32.TryParse(value, out num);

            if (!isNum)
            {
                return "Заполните поле \"Дом\"";
            }
            else if (num == 0 || num > 1000)
            {
                return "Поле \"Дом\" не может содержать значение равное 0 или большее 1000";
            }
            else
            {
                house = num;
                return "ok";
            }
        }
    }
}
