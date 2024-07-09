using AdminKafe.Models;
using AdminKafe.View.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AdminKafe.Windows.PageMenu
{
    /// <summary>
    /// Логика взаимодействия для AddFood.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        AddProductParameter addProductParameter;
        public AddProduct()
        {
            InitializeComponent();
        }


       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Element1.Text = "";
            Element2.Text = DateTime.Now.ToString();
            Element3.Text = "";
            Element4.Text = "0";
            Element5.Text = "0";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addProductParameter = new AddProductParameter();
            addProductParameter.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object item = DataGrid1.SelectedItem; //probably you find this object
            DateWorker.AllId = Convert.ToInt32((DataGrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            Element1.Text = (DataGrid1.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            Element2.Text = (DataGrid1.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            Element3.Text = (DataGrid1.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            Element4.Text = (DataGrid1.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            Element5.Text = (DataGrid1.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
        }
    }
}
