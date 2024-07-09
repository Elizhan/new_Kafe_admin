using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AdminKafe.ViewModels
{
    public class AddFoodVM : AbstractClass<Food>, ICommandMethod
    {
        public ICommand MenuFoodCommand { get; set; }
        public AddFoodVM()
        {
            CreateCommand = new LambdaCommand(CreateMethod, CanCloseApplicationExecat);
            DeleteCommand = new LambdaCommand(DeleteMethod, CanCloseApplicationExecat);
           ImgSourceCommand = new LambdaCommand(ImgSourceMethod, CanCloseApplicationExecat);
            MenuFoodCommand = new LambdaCommand(AddMenuFoodMethod, CanCloseApplicationExecat);
        }
        #region Reciep

        private string _Unit;
        public string Unit
        {
            get => _Unit;
            set => Set(ref _Unit, value);
        }

        private double _CountRecept;
        public double CountRecept
        {
            get => _CountRecept;
            set => Set(ref _CountRecept, value);
        }

        private Food _SelectedFood;
        public Food SelectedFood
        {
            get => _SelectedFood;
            set => Set(ref _SelectedFood, value);
        }

        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get => _SelectedProduct;
            set
            {
                Set(ref _SelectedProduct, value);
                if (_SelectedProduct != null)
                    SelectedText = _SelectedProduct.Type;
            }
        }
        private List<Food> _AllFoodMenu;
        public List<Food> AllFoodMenu
        {

            get => _AllFoodMenu;
            set => Set(ref _AllFoodMenu, value);
        }
        

        #endregion Reciept

        public void CreateMethod(object p)
        {
            Image img = p as Image;
            result = "Запольните поля ";

            if ((Name == null || Name.Replace(" ", "").Length == 0) && SelectedFood == null && Price == 0)
            {
                result += "Названи блюда, ";

            }
            else
            {

                result = DateWorker.CreateFood(Name, Price, SelectedFood, ImgSourse);
                img.Source = null;
                Name = string.Empty;
                ImgSourse = null;
                LoadAllDate(); 
            }
            OpenOkMethod(result + "!");
        }
        public void AddMenuFoodMethod(object p)
        {
            result = "Запольните поля ";

            if ((Name == null || Name.Replace(" ", "").Length == 0))
            {
                result += "Названи меню  ";
                OpenOkMethod(result + "!");
            }
            else
            {
                result = DateWorker.CreateMenuFood(Name);
                Name = string.Empty;
                LoadAllDate();
            }


        }
        public void DeleteMethod(object p)
        {
            PropertyInfo property = SelectedDateObject.GetType().GetProperty("Id");
            int Id = (int)(property.GetValue(SelectedDateObject, null));
            result = "";
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteFood(Id);
                    LoadAllDate();
                }
            };
            mv.ShowDialog();
        }

        public void EditMethod(object p)
        {
            throw new NotImplementedException();
        }

        public override async void LoadAllDate(string name = "")
        {
            await Task.Run(() =>
            {
                AllDate = DateWorker.GetAllFood();
                AllFoodMenu = DateWorker.GetAllFoodMenu();
            });

        }

        
       


    }
}

