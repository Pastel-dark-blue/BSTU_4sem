using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; // CallerMemberName
using System.Runtime.CompilerServices; // интерфейс INotifyPropertyChanged
using System.IO;
using System.Xml.Serialization;
using System.Windows.Controls;
using System.Globalization;
using System.Collections.ObjectModel;

namespace Laba6_7.Goods
{
    // INotifyPropertyChanged
    // Чтобы поддерживать привязку OneWay или TwoWay, чтобы ваши целевые свойства привязки могли автоматически отражать 
    // динамические изменения источника привязки (например, чтобы панель предварительного просмотра автоматически обновлялась, 
    // когда пользователь редактирует форму), ваш класс должен предоставлять надлежащие уведомления об изменении свойства.
    // Для реализации INotifyPropertyChanged необходимо объявить событие PropertyChanged и создать OnPropertyChanged метод.
    // Затем для каждого свойства, для которого вы хотите получать уведомления об изменениях, вы уведомляете OnPropertyChanged 
    // всякий раз, когда свойство обновляется.

    // IDataErrorInfo
    // Мы можем реализовать свою логику валидации для класса модели. Для этого модель должна реализовать интерфейс IDataErrorInfo. 
    [Serializable]
    public class Good : INotifyPropertyChanged, IDataErrorInfo, IEquatable<Good>
    {
        static public string goodsFilePath = @"D:\ООП\OOP_Course2_Term2\Laba6-7\goodsFile.xml";

        #region PropertyChanged
        // ------ реагирование на редактирование элементов
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID"); 
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name"); // для динамического показа выбранной картинки в окне товара
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category"); // для динамического показа выбранной картинки в окне товара
            }
        }

        private int rate = 1;
        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate"); // для динамического показа выбранной картинки в окне товара
            }
        }

        private float price;
        public float Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price"); // для динамического показа выбранной картинки в окне товара
            }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount"); // для динамического показа выбранной картинки в окне товара
            }
        }

        private string imagePath;
        public string ImagePath {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath"); // для динамического показа выбранной картинки в окне товара
            }
        }
        #endregion 

        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        // атрибут CallerMemberNameAttribute позволяет получить имя метода, который вызвал ваш код.
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        // --------------- Валидация
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch(columnName){
                    case "ID":
                        if (ID <= 0 || ID >= 100000)
                            error = "Артикул должен быть в диапазоне от 0 до 100000";
                        
                        //foreach(Good g in readXml())
                        //{
                        //    if (ID == g.ID)
                        //        error = "Товар с таким артикулом уже есть, введите уникальное значение";
                        //}
                        break;
                    case "Name":
                        if (Name == null) 
                            error = "Введите название товара";
                        break;
                    case "Price":
                        if (Price <= 0 || Price >= 100000)
                            error = "Цена должна быть в диапазоне от 0 до 100000";
                        break;
                    case "Amount":
                        if (Amount < 0 || Amount >= 100000)
                            error = "Количество должно быть в диапазоне от 0 до 100000";
                        break;
                    case "Category":
                        if (Category == null)
                            error = "Выберите категорию";
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { return String.Empty; }
        }
        // --------------- 

        // сериализация в Xml файл
        public static void SerializerInXml(Good good)
        {
            ObservableCollection<Good> goodsCollection = new ObservableCollection<Good>();
            // если файл существует
            if (File.Exists(goodsFilePath))
            {
                // пытаемся считать из него данные в коллекцию
                goodsCollection = readXml();
                // если в файле не было найдено ничего или не было найдено того, что можно принять за объекты типа Good и
                // добавить их в коллекцию, то метод readXml возвращается null и нам нужно инициализировать goodsCollection
                if (goodsCollection == null)
                {
                    goodsCollection = new ObservableCollection<Good>();

                    File.Delete(goodsFilePath); // удаляем файл, содержимое которого не соответствует типу ObservableCollection<Good>
                }
            }

            goodsCollection.Add(good);

            using (FileStream fs = new FileStream(goodsFilePath, FileMode.OpenOrCreate)) 
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Good>));
                xmlSerializer.Serialize(fs, goodsCollection);
            }
        }

        static public ObservableCollection<Good> readXml()
        {
            if (File.Exists(goodsFilePath)){
                string data = File.ReadAllText(goodsFilePath);
                var stringReader = new StringReader(data);
                ObservableCollection<Good> collection; 

                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Good>));
                    collection = (ObservableCollection<Good>)xmlSerializer.Deserialize(stringReader);
                }
                catch
                {
                    return null;
                }
                return collection;
            }
            return null;
        }

        public bool Equals(Good other)
        {
            return (other.ID == ID &&
                other.Name == Name &&
                other.Price == Price && 
                other.Rate == Rate &&
                other.Amount == Amount &&
                other.Category == Category &&
                other.ImagePath == ImagePath);
        }
    }
}
