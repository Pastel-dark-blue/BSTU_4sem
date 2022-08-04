using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace экзамен_2к2с_задание_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<string> list = new List<string>();

            foreach (var st in Student.students)
            {
                listBox1.Items.Add("Имя: " + st.Name + "\t" + "Возраст: " + st.Age.ToString());
            }
        }
    }
}
