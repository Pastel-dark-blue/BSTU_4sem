using System;
using System.Windows.Forms;

namespace Laba1_calc
{
    public partial class Calculator : Form, ICalc
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public void delClick(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // смена знака числа
        public void signClick(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                if (textBox1.Text != "")
                {
                    // мы добавляем минус в начало числа, если в начале, то есть первым символом строки,
                    // уже стоит "-" => сменяем его на плюс, то есть просто минус убираем
                    if (textBox1.Text[0] == '-')
                    {
                        textBox1.Text = textBox1.Text.Remove(0, 1);
                    }
                    // если же минуса нет, то ставим его
                    else
                    {
                        textBox1.Text = "-" + textBox1.Text;
                    }
                }
            }
        }

        // ряд возведений в степень, у меня это степени числа от нулевой (включительно) до пятой (включительно)
        public void rowClick(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox1.Text != "")
            {
                double num = Convert.ToDouble(textBox1.Text);

                textBox1.Text = num.ToString() + "^(0...5) = ";

                string result = Math.Pow(num, 0).ToString() + "; " +
                    Math.Pow(num, 1).ToString() + "; " +
                    Math.Pow(num, 2).ToString() + "; " +
                    Math.Pow(num, 3).ToString() + "; " +
                    Math.Pow(num, 4).ToString() + "; " +
                    Math.Pow(num, 5).ToString();

                textBox2.Text = result;
            }
        }

        public void operClick(object sender, EventArgs e)
        {
            // мы должны ввести значение в первый бокс, затем выбрать операцию и получить ответ во втором
            // в случае, если мы после получения ответа, то есть наличия текста во втором боксе,
            // выбираем операцию, то пускай ничего не происходит
            if (textBox2.Text == "" && textBox1.Text != "")
            {
                double num = 0;
                string operation = "";
                double result = 0;

                string data = textBox1.Text;
                // конвертируем полученное число из типа строки в тип double
                num = Convert.ToDouble(data);
                // переводим градусы в радианы
                double rad = num * Math.PI / 180;

                // получаем операцию, нажатую пользователем
                operation = (sender as Button).Text;

                // очищаем первый бокс, предназначенный для информации, воодимой пользователем
                textBox1.Text = "";

                switch (operation)
                {
                    case "sin":
                        result = Math.Sin(rad);
                        // записываем представленную операцию в приемлемом виде в бокс воода данных
                        textBox1.Text = "sin(" + data + "°" + ") " + "= ";
                        break;
                    case "cos":
                        result = Math.Cos(rad);
                        textBox1.Text = "cos(" + data + "°" + ") " + "= ";
                        break;
                    case "tan":
                        result = Math.Tan(rad);
                        textBox1.Text = "tan(" + data + "°" + ") " + "= ";
                        break;
                    case "cot":
                        result = 1 / Math.Tan(rad);
                        textBox1.Text = "cot(" + data + "°" + ") " + "= ";
                        break;
                    case "x^2":
                        result = num * num;
                        textBox1.Text = data + "^2 = ";
                        break;
                    case "x^3":
                        result = num * num * num;
                        textBox1.Text = data + "^3 = ";
                        break;
                }

                // записываем результат во второй бокс
                textBox2.Text = result.ToString();
            }
        }

        public void commaClick(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                bool thereIsComma = false;

                // во-первых, мы можем ввести запятую только при наличии в боксе, как минимум одной цифры
                if (textBox1.Text.Length > 0)
                {
                    foreach (char ch in textBox1.Text)
                    {
                        // во-вторых, мы убираем возможность ввести в бокс несколько запятых
                        if (ch == ',')
                        {
                            thereIsComma = true;
                        }
                    }
                    if (!thereIsComma)
                    {
                        textBox1.Text += (sender as Button).Text;
                    }
                }
            }
        }

        public void numClick(object sender, EventArgs e)
        {
            // если мы начинаем вводить данные в первое поле при наличии результата во втором,
            // то есть сразу после получения результата предыдущих вычислений
            // то нужно очистить оба поля и позволить пользователю ввести число для последующих операций
            if (textBox2.Text != "")
            {
                textBox1.Clear();
                textBox2.Clear();
            }

            // если введен ноль, но за ним не идет запятой
            if (textBox1.Text == "0" && (sender as Button).Text != ",")
            {
                // то записываем введенное число бокс, то есть вместо записи, например, "08", мы получим просто "8"
                textBox1.Text = (sender as Button).Text;
            }
            else
            {
                textBox1.Text += (sender as Button).Text;
            }
        }
    }
}
