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
using System.Windows.Shapes;

namespace AdminKafe.View.Windows
{
    /// <summary>
    /// Interaction logic for MessageWindowOk.xaml
    /// </summary>
    public partial class MessageWindowOk : Window
    {
        private string Mess { get; set; } = "";
       public MessageWindowOk(string s)
        {
            InitializeComponent();
            Mess = s;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = Mess;
        }
    }
}
