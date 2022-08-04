namespace экзамен_2к2с_задание_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Name = textBox1.Text;

            int age;
            if (Int32.TryParse(textBox2.Text, out age))
                st.Age = age;
            else
            {
                MessageBox.Show("Возрастом должно быть число");
                return;
            }

            Student.students.Add(st);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
        }
    }
}