using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using экзамен_2к2с_задание_2.Language;

namespace экзамен_2к2с_задание_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EngLangMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SwitchLang.SwitchLangEng();
        }

        private void RusLangMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SwitchLang.SwitchLangRus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtBlock1.Text + ": " + txtBox1.Text + "\n" + txtBlock2.Text + ": " + txtBox2.Text);
        }
    }
}
