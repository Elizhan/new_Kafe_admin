using System.Windows;

namespace AdminKafe.View.Windows
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public delegate void MessageDelegate(int i);
        public event MessageDelegate _mess;
        public MessageWindow(string s)
        {
            InitializeComponent();
            TextBlock1.Text = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mess(1);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
