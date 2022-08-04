using Laba9.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Laba9.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PersonUC.xaml
    /// </summary>
    public partial class PersonUC : UserControl
    {
        public PersonUC()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = (Person)this.Resources["personClass"];

            string currentDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string path = currentDir + "\\people.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                string str = "--------------------------\n" +
                    "ИМЯ : " + person.Name + "\n" +
                    "ФАМИЛИЯ : " + person.Surname + "\n" +
                    "ДАТА РОЖДЕНИЯ : " + person.BirthDate + "\n" +
                    "--------------------------\n";

                writer.Write(str, true); 
            }

            showSavePopup();
        }

        private void showSavePopup()
        {
            // Popup о том, что данные сохранены
            SavePopup.IsOpen = true;
            // таймер на показ Popup на 2 секунды
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = TimeSpan.FromSeconds(2);
            time.Start();
            time.Tick += delegate
            {
                SavePopup.IsOpen = false;
                time.Stop();
            };
        }
    }
}
