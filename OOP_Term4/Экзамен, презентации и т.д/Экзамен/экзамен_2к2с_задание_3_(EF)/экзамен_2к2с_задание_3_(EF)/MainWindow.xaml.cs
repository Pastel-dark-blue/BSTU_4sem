using DbCon;
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

namespace экзамен_2к2с_задание_3__EF_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //
            using(Model1 db=new Model1())
            {
                try
                {
                    var list = db.Good.ToList();

                    GoodsDataGrid.ItemsSource = list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var list = db.Good.ToList();

                    double? price = list[0].Price__;
                    var listCheap = new List<Good>();

                    foreach(var i in list)
                    {
                        if (i.Price__ != null)
                        {
                            if (i.Price__ < price)
                            {
                                price = i.Price__;
                                listCheap.Clear();
                                listCheap.Add(i);
                            }
                        }
                    }

                    GoodsDataGrid.ItemsSource = listCheap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                try
                {
                    var list = db.Good.ToList();

                    GoodsDataGrid.ItemsSource = list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
