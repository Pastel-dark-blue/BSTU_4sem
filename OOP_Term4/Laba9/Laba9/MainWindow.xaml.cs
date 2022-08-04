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

namespace Laba9
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

        private void Control_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string tunnelingEventInfo = "sender : " + sender.ToString() + "\n" +
                "source : " + e.Source.ToString() + "\n" +
                "-----------------------------" + "\n";
            tunnelingTextBlock.Text += tunnelingEventInfo;
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string bubblingEventInfo = "sender : " + sender.ToString() + "\n" +
                "source : " + e.Source.ToString() + "\n" +
                "-----------------------------" + "\n";
            bubblingTextBlock.Text += bubblingEventInfo;
        }
    }
}
