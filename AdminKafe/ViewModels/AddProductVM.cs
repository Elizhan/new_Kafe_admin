using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdminKafe.ViewModels
{
    public class AddProductVM : AbstractClass<Product>, ICommandMethod
    {
        
        public AddProductVM()
        {
            CreateCommand = new LambdaCommand(CreateMethod, CanCloseApplicationExecat);
            DeleteCommand = new LambdaCommand(DeleteMethod, CanCloseApplicationExecat);
            CreatMenuCommand = new LambdaCommand(AddMenuMethod, CanCloseApplicationExecat);
            NextPage = new LambdaCommand(NextPageMethod, CanCloseApplicationExecat);
            BackPage = new LambdaCommand(BackPagePageMethod, CanCloseApplicationExecat);
            ShowOtchet = new LambdaCommand(SortDateSklad, CanCloseApplicationExecat);
            EditCommand = new LambdaCommand(EditMethod, CanCloseApplicationExecat);
            LoadAllDateMenu();
            LoadAllDateProduct();
            LoadCountDate();
            LoadDateSklad();
        }

        public override string Search
        {
            get => base.Search;
            set
            {
                base.Search = value;
                LoadCountDate(base.Search);
                ShowAllPage();
            }
        }
        
        #region AddProduct and ByProduct

        private DateTime _DateTimeReceiptGoods = DateTime.Now;
        public DateTime DateTimeReceiptGoods
        {
            get => _DateTimeReceiptGoods;
            set => Set(ref _DateTimeReceiptGoods, value);
        }

        private double _SummPropertyBy;
        public double SummPropertyBy
        {
            get => _SummPropertyBy;
            set => Set(ref _SummPropertyBy, value);
        }
        
        private double _Price;
        public double Price
        {
            get => _Price;
            set => Set(ref _Price, value);
        }

        private double note;
        public double Note
        {
            get => note;
            set => Set(ref note, value);
        }

        private List<object> _ProductList;

        public List<object> ProductList
        {
            get { return _ProductList; }
            set { Set(ref _ProductList , value); }
        }


        private object _AllReceiptGood;
        public object AllReceiptGood
        {
            get => _AllReceiptGood;
            set => Set(ref _AllReceiptGood, value);
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


        private object allProductSklad;
        public object AllProductSklad
        {
            get => allProductSklad;
            set => Set(ref allProductSklad, value);
        }

        private double allProductSkladItog;
        public double AllProductSkladItog
        {
            get => allProductSkladItog;
            set => Set(ref allProductSkladItog, value);
        }

        private DateTime allProductSkladDateDo = DateTime.Now.AddDays(-7);
        public DateTime AllProductSkladDateDo
        {
            get => allProductSkladDateDo;
            set => Set(ref allProductSkladDateDo, value);
        }

        private DateTime allProductSkladDatePosle = DateTime.Now;
        public DateTime AllProductSkladDatePosle
        {
            get => allProductSkladDatePosle;
            set => Set(ref allProductSkladDatePosle, value);
        }

        private string allProductSearchText;
        public string AllProductSearchText
        {
            get => allProductSearchText;
            set
            {
                Set(ref allProductSearchText, value);
                AllProductSklad = DateWorker.GetAllProductSclad2(AllProductSkladDateDo, AllProductSkladDatePosle, AllProductSearchText);
                AllProductSkladItog = DateWorker.SummByProduct;
            }
        }

        private int comboDays;
        public int ComboDays
        {
            get => comboDays;
            set
            {
                Set(ref comboDays, value);
                switch (comboDays)
                {
                    case 0:
                        AllProductSkladDateDo = DateTime.Now;
                        break;
                    case 1:
                        AllProductSkladDateDo = DateTime.Now.AddDays(-7);
                        break;
                    case 2:
                        AllProductSkladDateDo = DateTime.Now.AddDays(-15);
                        break;
                    case 3:
                        AllProductSkladDateDo = DateTime.Now.AddDays(-31);
                        break;
                    default:
                        AllProductSkladDateDo = DateTime.Now;
                        break;
                }
            }
        }
        #endregion

        public void NextPageMethod(object p)
        {
            CountPage++;
            ShowAllPage();
        }
        public void BackPagePageMethod(object p)
        {
            CountPage--;
            ShowAllPage();
        }
        public void CreateMethod(object p)
        {
            result = "Запольните поля ";
            int flag = 0;
            if (SelectedProduct == null)
            {
                result += "Продукт, ";
                flag = 1;

            }
            if (Count == 0)
            {
                result += "Количество ,";

                flag = 1;
            }
            if (Price == 0)
            {
                result += "Цена ,";
                flag = 1;
            }

            if (flag == 0)
            {
                result = DateWorker.CreateReceiptGoods(DateTimeReceiptGoods, Count, Price, SelectedProduct);
                Count = 0;
                Price = 0;
                LoadAllDate();
            }
            LoadAllDate();
            OpenOkMethod(result + "!");

        }
        public void AddMenuMethod(object p)
        {
            result = "Запольните поля ";

            if (Name == null || Name.Replace(" ", "").Length == 0)
            {
                result += "Ф.И.О, ";
            }
            else if (SelectedComboboxText == null || SelectedComboboxText.Replace(" ", "").Length == 0)
            {
                result += "Кг, л, шт ";
            }
            else
            {
                result = DateWorker.CreateProduct(Name, SelectedComboboxText,Note);
                Name = string.Empty;               
                Note = 0;               
            }
            LoadAllDateMenu();
            LoadCountDate();
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
                    result = DateWorker.DeleteProduct(SelectedDate);
                    LoadAllDate();
                }
            };
            mv.ShowDialog();
        }
        public void EditMethod(object p)
        {
            result = DateWorker.EditProduct(DateTimeReceiptGoods, SelectedText, Count, Price);
            OpenOkMethod(result + "!");
            LoadAllDate();
        }
        public override async void LoadAllDate(string name = "")
        {
            await Task.Run(() =>
            {
                AllObjectDate = DateWorker.GetAllReceiptgoods(name, SkipCount,TakeCount);
                Count1 = DateWorker.SummByProduct;
            });

        }
        public  async void LoadAllDateMenu(string name = "")
        {
            await Task.Run(() =>
            {
                AllDate = DateWorker.GetAllProduct(name);
            });

        }
        public async void LoadAllDateProduct(string name = "")
        {
            await Task.Run(() =>
            {
                ProductList = DateWorker.GetAllProductRecipes();
            });

        }
        public  async void LoadCountDate(string name = "")
        {
            await Task.Run(() =>
            {
                Count1 = DateWorker.GetCountReceiptgoods(name);
                ShowAllPage();
            });

        }
        public async void LoadDateSklad()
        {
            await Task.Run(() =>
            {
                AllProductSklad = DateWorker.GetAllProductSclad();
                AllProductSkladItog = DateWorker.SummByProduct;
            });

        }
        private async void SortDateSklad(object o)
        {
            await Task.Run(() =>
            {
                AllProductSklad = DateWorker.GetAllProductSclad2(AllProductSkladDateDo,AllProductSkladDatePosle);
                AllProductSkladItog = DateWorker.SummByProduct;
                
            });
        }        
        
    }
}