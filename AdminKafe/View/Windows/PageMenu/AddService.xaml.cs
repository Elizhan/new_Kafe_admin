using AdminKafe.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AdminKafe.Windows.PageMenu
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Page
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object item = DataGrid1.SelectedItem; //probably you find this object
           DateWorker.AllId = Convert.ToInt32( (DataGrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            TextBox1.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            TextBox2.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "0";

        }
    }
}
