using AdminKafe.View.Windows;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AdminKafe.Windows.PageMenu
{
    /// <summary>
    /// Логика взаимодействия для AddFood.xaml
    /// </summary>
    public partial class AddFood : Page
    {
        public AddFood()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";

            if (dlg.ShowDialog() == true)
            {
                string FileName = dlg.FileName.ToString();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(FileName);
                bitmap.EndInit();
                imgBox.Source = bitmap;

                byte[] image;

                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.QualityLevel = 100;

                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgBox.Source));
                    encoder.Save(ms);
                    image = ms.ToArray();
                }
                encoder = null;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddMenuFoodWindow wn = new AddMenuFoodWindow();
            wn.ShowDialog();

        }
    }
}
