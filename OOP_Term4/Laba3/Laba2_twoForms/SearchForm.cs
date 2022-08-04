using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;

namespace Laba2_twoForms
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            buttonSearch.Click += buttonSearch_Click;
        }

        public void buttonSearch_Click(object sender, EventArgs e)
        {
            string name;
            string type1 = "", type2 = "";
            double low;
            double top;

            //  убираем пробелы
            name = textBoxName.Text.Trim();

            if (typeCheckBox1.Checked) type1 = typeCheckBox1.Text;
            if (typeCheckBox2.Checked) type2 = typeCheckBox2.Text;

            if (!Double.TryParse(textBoxPriceLow.Text, out low)) 
                low = -1;
            if (!Double.TryParse(textBoxPriceTop.Text, out top)) 
                top = -1;
            //  в случае, если пользователь заполнил только одно из полей группы поиска по цене
            if ((low == -1 && top != -1) || (top == -1 && low != -1))
            {
                MessageBox.Show("Заполните оба поля цены");
                return;
            }

            // если не было заполнено ни одно поле
            if (name == "" && type1 == "" && type2 == "" && low == -1 && top == -1)
            {
                MessageBox.Show("Заполните, как минимум, одно поле");
                return;
            }

            // коллекция для обработки считывается из файла
            IEnumerable<Good> goods = Good.readXml();
            // если в файле не было ни одного объекта
            if (goods == null)
            {
                MessageBox.Show("Прежде чем начать поиск сохраните коллекцию объектов в файл");
                return;
            }

            //  если коллекция, в которой осуществляется поиск, не пустая И в поле "Имя" введена строка
            if (name != "" && goods != null)
            {
                    Regex regex = new Regex(@"(\D*)" + name + @"(\D*)");

                    goods = from g in goods
                       where regex.IsMatch(g.Name)
                       select g;
            }

            //  если коллекция, в которой осуществляется поиск, не пустая И в поле "Тип" введена строка
            if ((type1 != "" || type2 != "") && goods != null)
            {
                goods = from g in goods
                        where (g.Type == type1 || g.Type == type2)
                        select g;
            }

            //  если коллекция, в которой осуществляется поиск, не пустая И группа "Цена" заполнена
            if (low != -1 && top != -1 && goods != null)
            {
                goods = from g in goods
                        where g.Price >= low && g.Price <= top
                        select g;
            }

            //  если коллекция, которая по итогу должна хранить подходящие по поиску объекты, не пуста
            if (goods != null)
            {
                string result = "";
                foreach (var el in goods)
                {
                    result += "--------------------------------\n";
                    result += el.ToString() + "\n";
                    result += "--------------------------------\n";
                }

                if (result != "")
                {
                    MessageBox.Show(result);

                    string path = @"D:\ООП\OOP_Course2_Term2\Laba3\search.xml";

                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Good>));
                        //  ToList() - Creates a List<T> from an IEnumerable<T>.
                        xmlSerializer.Serialize(fs, goods.ToList());
                    }
                }
                else
                {
                    MessageBox.Show("Подходящих товаров не найдено");
                }
            }
                
        }
    }
}
