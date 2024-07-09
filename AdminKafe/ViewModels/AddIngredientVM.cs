using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.ViewModels
{
    public class AddIngredientVM : AbstractClass<Reciep>, ICommandMethod
    {
        public AddIngredientVM()
        {
            CreateCommand = new LambdaCommand(CreateMethod, CanCloseApplicationExecat);
            DeleteCommand = new LambdaCommand(DeleteMethod, CanCloseApplicationExecat);
            LoadAllFood(); LoadAllProduct();
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
        private List<Food> _AllFood;
        public List<Food> AllFood
        {
            get => _AllFood;
            set=> Set(ref _AllFood, value);
               
            
        }

        private List<Product> _AllProduct;
        public List<Product> AllProduct
        {
            get => _AllProduct;
            set => Set(ref _AllProduct, value);


        }


        #endregion Reciept

        public void CreateMethod(object p)
        {
            result = "Запольните поля ";
            if (SelectedFood == null || CountRecept == 0 || SelectedProduct == null)
            {
                result += "Названи блюда, ";

            }
            else
            {
                result = DateWorker.CreateRecieps(SelectedFood, SelectedProduct, CountRecept, Unit);
                CountRecept = 0;

            }
            OpenOkMethod(result + "!");
        }

        public void DeleteMethod(object p)
        {
            result = "";
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    //result = DateWorker.DeleteWaiter(SelectedDate);
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
                AllObjectDate = DateWorker.GetAllResiep(name);
            });

        }

        public  async void LoadAllFood(string name = "")
        {
            await Task.Run(() =>
            {
                AllFood = DateWorker.GetAllFood();
            });

        }

        public async void LoadAllProduct(string name = "")
        {
            await Task.Run(() =>
            {
                AllProduct = DateWorker.GetAllProduct(name);
            });

        }


    }
}

