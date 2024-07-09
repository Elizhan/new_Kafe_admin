using AdminKafe.Models;
using KafeProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace AdminKafe.ViewModels
{
    public  abstract class ClassProperties : ViewModel
    {
        public ClassProperties()
        {
           /* UpdateWaiterAsync();
            LoadProductAsync();
            LoadReceiptDoodAsync();
            LoadFoodAsync();
            LoadReciepAsync();
            LoadConsumptionAsync();*/
        }

        #region GetDateAsyncMethod
        public async void UpdateWaiterAsync()
        {
            await Task.Run(() =>
            {
                //AllWaiter = DateWorker.GetAllWaiter();
                AllLocation = DateWorker.GetAllLocation();
                AllTable = DateWorker.GetAllTables();
            });
        }
        public async void LoadProductAsync()
        {
            await Task.Run(() =>
            {
                AllProduct = DateWorker.GetAllProduct("");
            });
        }
        public async void LoadConsumptionAsync(string name = "")
        {
            await Task.Run(() =>
            {
                AllConsumption = DateWorker.GetAllConsumption(name);
            });
        }
        public async void LoadReceiptDoodAsync(string name = "")
        {
            await Task.Run(() =>
            {
                AllReceiptGood = DateWorker.GetAllReceiptgoods(name);
                SummPropertyBy = DateWorker.SummByProduct;
            });
        }
        public async void SearchWaiterAsync(string name)
        {
            await Task.Run(() =>
            {
                AllWaiter = DateWorker.SearchAllWaiter(name);
            });
        }
        public async void LoadFoodAsync()
        {
            await Task.Run(() =>
            {
                AllFoodMenu = DateWorker.GetAllFoodMenu();
                AllFood = DateWorker.GetAllFood();
                AllFood2 = AllFood;

            });
        }
        public async void LoadReciepAsync(string name = "")
        {
            await Task.Run(() =>
            {
                AllReciept = DateWorker.GetAllResiep(name);
            });
        }
        public async void SearchFoodAsync(string s)
        {
            await Task.Run(() =>
            {
                AllFood = AllFood2.Where(t => t.Name.ToLower().Contains(s.ToLower())).ToList();
            });
        }

        #endregion GetAsyncMethod

        #region WaiterProperties

        private string _Search;
        public string Search
        {
            get => _Search;
            set
            {
                Set(ref _Search, value);
                SearchWaiterAsync(_Search);
            }
        }
        private double _SalaryType;
        public double SalaryType
        {
            get => _SalaryType;
            set => Set(ref _SalaryType, value);
        }
        private double _SalaryType2;
        public double SalaryType2
        {
            get => _SalaryType2;
            set => Set(ref _SalaryType2, value);
        }
        private double _SalaryType3;
        public double SalaryType3
        {
            get => _SalaryType3;
            set => Set(ref _SalaryType3, value);
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private string _AliasName;
        public string AliasName
        {
            get => _AliasName;
            set => Set(ref _AliasName, value);
        }

        private string _MessageProperties;
        public string MessageProperties
        {
            get => _MessageProperties;
            set => Set(ref _MessageProperties, value);
        }

        private string _Pass;
        public string Pass
        {
            get => _Pass;
            set => Set(ref _Pass, value);
        }
        private string _Tel;
        public string Tel
        {
            get => _Tel;
            set => Set(ref _Tel, value);
        }

        private Waiter _SelectedWaiters;
        public Waiter SelectedWaiters
        {
            get => _SelectedWaiters;
            set => Set(ref _SelectedWaiters, value);
        }

        private string _Adress;
        public string Adress
        {
            get => _Adress;
            set => Set(ref _Adress, value);
        }
        private List<Waiter> allWaiter;
        public List<Waiter> AllWaiter
        {
            get => allWaiter;
            set => Set(ref allWaiter, value);
        }
        private List<object> allTable;
        public List<object> AllTable
        {
            get => allTable;
            set => Set(ref allTable, value);
        }
        #endregion WaiterProperties

        #region TableRoom
        private List<Location> allLocation;
        public List<Location> AllLocation
        {
            get => allLocation;
            set => Set(ref allLocation, value);
        }

        private object _SelectedTable;
        public object SelectedTable1
        {
            get => _SelectedTable;
            set => Set(ref _SelectedTable, value);
        }

        private Location _SelectedLocation;
        public Location SelectedLocation
        {
            get => _SelectedLocation;
            set => Set(ref _SelectedLocation, value);
        }
        private string _TableName;
        public string TableName
        {
            get => _TableName;
            set => Set(ref _TableName, value);
        }
        #endregion TableRoom

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
        private string _SearchProduct;
        public string SearchProduct
        {
            get => _SearchProduct;
            set
            {
                Set(ref _SearchProduct, value);
                LoadReceiptDoodAsync(_SearchProduct);
            }
        }

        private int _Count;
        public int Count
        {
            get => _Count;
            set => Set(ref _Count, value);
        }
        private double _Price;
        public double Price
        {
            get => _Price;
            set => Set(ref _Price, value);
        }

        private object _AllReceiptGood;
        public object AllReceiptGood
        {
            get => _AllReceiptGood;
            set => Set(ref _AllReceiptGood, value);
        }

        private List<Product> allProduct;
        public List<Product> AllProduct
        {
            get => allProduct;
            set => Set(ref allProduct, value);
        }
        private string _TextSelect;
        public string TextSelect
        {
            get => _TextSelect;
            set => Set(ref _TextSelect, value);
        }
        private string _SelectedComboboxText;
        public string SelectedComboboxText
        {
            get => _SelectedComboboxText;
            set => Set(ref _SelectedComboboxText, value);
        }

        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get => _SelectedProduct;
            set
            {
                Set(ref _SelectedProduct, value);
                if (_SelectedProduct != null)
                    TextSelect = _SelectedProduct.Type;
            }
        }


        #endregion

        #region AddFood
        private List<Food> _AllFoodMenu;
        public List<Food> AllFoodMenu
        {

            get => _AllFoodMenu;
            set => Set(ref _AllFoodMenu, value);
        }

        private ListCollectionView _AllFood1;
        public ListCollectionView AllFood1
        {

            get
            {


                ListCollectionView collection = new ListCollectionView(AllFood);
                collection.GroupDescriptions.Add(new PropertyGroupDescription("Price"));
                return collection;
            }
            set
            {
                _AllFood1 = value;
            }
        }
        private List<Food> _AllFood;
        public List<Food> AllFood
        {

            get => _AllFood;
            set => Set(ref _AllFood, value);
        }
        private List<Food> _AllFood2;
        public List<Food> AllFood2
        {

            get => _AllFood2;
            set => Set(ref _AllFood2, value);
        }
        private Food _SelectedFood;
        public Food SelectedFood
        {
            get => _SelectedFood;
            set => Set(ref _SelectedFood, value);
        }
        private ImageSource _Img1;
        public ImageSource Img1
        {
            get => _Img1;
            set => Set(ref _Img1, value);
        }

        private byte[] _ImgSourse;
        public byte[] ImgSourse
        {
            get => _ImgSourse;
            set => Set(ref _ImgSourse, value);
        }
        private string _NameMenuFood;
        public string NameMenuFood
        {
            get => _NameMenuFood;
            set => Set(ref _NameMenuFood, value);
        }

        private string _SearchFood;
        public string SearchFood
        {
            get => _SearchFood;
            set
            {
                Set(ref _SearchFood, value);
                SearchFoodAsync(_SearchFood);
            }
        }



        #endregion AddFood

        #region Reciep
        private List<object> allReciept;
        public List<object> AllReciept
        {
            get => allReciept;
            set => Set(ref allReciept, value);
        }
        private string _Unit;
        public string Unit
        {
            get => _Unit;
            set => Set(ref _Unit, value);
        }
        private string _SearchReciep;
        public string SearchReciep
        {
            get => _SearchReciep;
            set
            {
                Set(ref _SearchReciep, value);
                LoadReciepAsync(_SearchReciep);
            }
        }
        private double _CountRecept;
        public double CountRecept
        {
            get => _CountRecept;
            set => Set(ref _CountRecept, value);
        }
        #endregion Reciept

        #region Consumption
        private Consumption _SelectedConsumption;
        public Consumption SelectedConsumption
        {
            get => _SelectedConsumption;
            set => Set(ref _SelectedConsumption, value);
        }

        private List<Consumption> allConsumption;
        public List<Consumption> AllConsumption
        {
            get => allConsumption;
            set => Set(ref allConsumption, value);
        }
        private double _Summ;
        public double Summ
        {
            get => _Summ;
            set => Set(ref _Summ, value);
        }
        private string _SearchConsumption;
        public string SearchConsumption
        {
            get => _SearchConsumption;
            set
            {
                Set(ref _SearchConsumption, value);
                LoadConsumptionAsync(_SearchConsumption);
            }
        }
        #endregion Consumption

        #region Command
        public ICommand CreateWater { get; set; }
        public ICommand CreateFoodCommand { get; set; }
        public ICommand DeleteFoodCommand { get; set; }
        public ICommand MenuFoodCommand { get; set; }
        public ICommand ImgSourceCommand { get; set; }
        public ICommand Test { get; set; }
        public ICommand DeleteWaiterCommand { get; set; }
        public ICommand DeleteLocationCommand { get; set; }
        public ICommand ChangeWiaterCommand { get; set; }
        public ICommand EditWaiterCommand { get; set; }
        public ICommand ClearWaiterCommand { get; set; }
        public ICommand CreateLocationCommand { get; set; }
        public ICommand CreateTableCommand { get; set; }
        public ICommand CreateReciepsCommand { get; set; }
        public ICommand CreateReceiptGoodsCommand { get; set; }
        public ICommand CreateConsumptionCommand { get; set; }
        public ICommand DeleteConsumptionCommand { get; set; }
        public ICommand EditConsumptionCommand { get; set; }
        public ICommand ChangeTableCommand { get; set; }
        public ICommand DeleteTableCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion Command

        #region AddCafeName
        #endregion
    }
}
