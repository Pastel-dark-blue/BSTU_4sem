using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Laba9.UserControls
{
    /// <summary>
    /// Логика взаимодействия для GalleryUC.xaml
    /// </summary>
    public partial class GalleryUC : UserControl
    {
        string[] imagesPaths = new string[]
        {
            @"/Images/sf1.jpg",
            @"/Images/sf2.jpg",
            @"/Images/sf3.jpg",
            @"/Images/sf4.jpg",
            @"/Images/sf5.jpg",
        };

        int index = 0;

        public GalleryUC()
        {
            InitializeComponent();

            imgElement.Source = new BitmapImage(new Uri(imagesPaths[0], UriKind.Relative));
        }

        //private void ArrowBack_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    // если нажимаем стрелку назад, находясь на первом изображении, то откроется последнее изображения
        //    if (index <= 0) index = imagesPaths.Length - 1;
        //    else index--;

        //    imgElement.Source = new BitmapImage(new Uri(imagesPaths[index], UriKind.Relative));
        //}

        //private void ArrowNext_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    // если нажимаем стрелку вперед, находясь на последнем изображении, то откроется первое изображения
        //    if (index >= imagesPaths.Length - 1) index = 0;
        //    else index++;

        //    imgElement.Source = new BitmapImage(new Uri(imagesPaths[index], UriKind.Relative));
        //}

        // code behind RoutedUICommand комманд
        private void Arrow_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (imagesPaths != null) 
                e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void Next_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // если нажимаем стрелку вперед, находясь на последнем изображении, то откроется первое изображения
            if (index >= imagesPaths.Length - 1) index = 0;
            else index++;

            imgElement.Source = new BitmapImage(new Uri(imagesPaths[index], UriKind.Relative));
        }

        private void Previous_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // если нажимаем стрелку назад, находясь на первом изображении, то откроется последнее изображения
            if (index <= 0) index = imagesPaths.Length - 1;
            else index--;

            imgElement.Source = new BitmapImage(new Uri(imagesPaths[index], UriKind.Relative));
        }

    }
}
