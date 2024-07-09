using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AdminKafe.ViewModels
{
    public class AdminClassVM : ClassProperties
    {
        private bool CanCloseApplicationExecat(object p) => true;
        public AdminClassVM()
        {
            CreateWater = new LambdaCommand(MethodCreateWaiter, CanCloseApplicationExecat);
            DeleteWaiterCommand = new LambdaCommand(DeleteWaiterMethod, CanCloseApplicationExecat);
            DeleteLocationCommand = new LambdaCommand(DeleteLocationMethod, CanCloseApplicationExecat);
            ChangeWiaterCommand = new LambdaCommand(ChanceProperties, CanCloseApplicationExecat);
            EditWaiterCommand = new LambdaCommand(EditWaiterMethod, CanCloseApplicationExecat);
            ClearWaiterCommand = new LambdaCommand(ClearWaiterMethod, CanCloseApplicationExecat);
            CreateLocationCommand = new LambdaCommand(CreateLocationMethod, CanCloseApplicationExecat);
            CreateTableCommand = new LambdaCommand(CreateTablenMethod, CanCloseApplicationExecat);
            Test = new LambdaCommand(test, CanCloseApplicationExecat);
            ChangeTableCommand = new LambdaCommand(ChangeTableMethod, CanCloseApplicationExecat);
            DeleteTableCommand = new LambdaCommand(DeleteTableMethod, CanCloseApplicationExecat);
            AddProductCommand = new LambdaCommand(AddProductMethod, CanCloseApplicationExecat);
            CreateReceiptGoodsCommand = new LambdaCommand(CreateReceiptGoodsMethod, CanCloseApplicationExecat);
            CreateFoodCommand = new LambdaCommand(AddFoodMethod, CanCloseApplicationExecat);
            ImgSourceCommand = new LambdaCommand(ImgSourceMethod, CanCloseApplicationExecat);
            CloseCommand = new LambdaCommand(CloseCommandMethod, CanCloseApplicationExecat);
            MenuFoodCommand = new LambdaCommand(AddMenuFoodMethod, CanCloseApplicationExecat);
            CreateReciepsCommand = new LambdaCommand(AddReciepsMethod, CanCloseApplicationExecat);
            CreateConsumptionCommand = new LambdaCommand(AddConsumptionMethod, CanCloseApplicationExecat);
            DeleteConsumptionCommand = new LambdaCommand(DeleteConsumptionMethod, CanCloseApplicationExecat);
            EditConsumptionCommand = new LambdaCommand(EditConsumptionMethod, CanCloseApplicationExecat);
            DeleteFoodCommand = new LambdaCommand(DeleteFoodMethod, CanCloseApplicationExecat);
        }


        private void CloseCommandMethod(object p)
        {
            Window wn= p as Window;
            wn.Close();
        }
        private void ImgSourceMethod(object p)
        {
            Image te = p as Image;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.QualityLevel = 100;

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)te.Source));
                encoder.Save(ms);
                ImgSourse = ms.ToArray();
            }
            encoder = null;

        }
        private void test(object p)
        {


            byte[] imageData = ImgSourse; // that you get from db
            if (imageData == null || imageData.Length == 0)
            {
                //Show error msg or return here;
                return;
            }

            BitmapImage Imgs = new BitmapImage();

            using (var ms = new System.IO.MemoryStream(imageData))
            {
                Imgs.BeginInit();
                Imgs.CacheOption = BitmapCacheOption.OnLoad;
                Imgs.StreamSource = ms;
                Imgs.EndInit();

            }
            Img1 = Imgs;
        }
        string result = "";

        #region Consumption
       
        public void AddConsumptionMethod(object p)
        {
            result = "Запольните поля ";
            if (Name =="")
            {
                result += "Названи блюда, ";

            }
            else
            {
                result = DateWorker.CreateConsumption(Name,Summ);
                Name = string.Empty;
                Summ = 0;
                LoadConsumptionAsync();
            }
            OpenOkMethod(result + "!");
        }
        public void EditConsumptionMethod(object p)
        {
            result = "Запольните поля ";
            if (Name == "")
            {
                result += "Названи блюда, ";

            }
            else
            {
                result = DateWorker.EditConsumption(DateWorker.AllId, Name, Summ);
                Name = string.Empty;
                Summ = 0;
                LoadConsumptionAsync();
            }
            OpenOkMethod(result + "!");
        }
        private void DeleteConsumptionMethod(object p)
        {
            result = "";
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteConsumption(SelectedConsumption);
                    LoadConsumptionAsync();
                }
            };
            mv.ShowDialog();


        }
        #endregion Consumption

        #region Recieps
        public void AddReciepsMethod(object p)
        {
           result = "Запольните поля ";
           if ( SelectedFood == null || CountRecept == 0 || SelectedProduct==null )
            {
                result += "Названи блюда, ";

            }
            else
            {
                result = DateWorker.CreateRecieps(SelectedFood, SelectedProduct, CountRecept, Unit);
                CountRecept = 0;
                //AllProduct = AllProduct;
                LoadFoodAsync();
            }
            OpenOkMethod(result + "!");
        }
        #endregion
        
        #region Food
        public void AddFoodMethod(object p)
        {
            Image img = p as Image;
            result = "Запольните поля ";

            if ((Name == null || Name.Replace(" ", "").Length == 0) && SelectedFood == null && Price == 0)
            {
                result += "Названи блюда, ";

            }
            else
            {

                result = DateWorker.CreateFood(Name,Price,SelectedFood, ImgSourse);
                img.Source = null; 
                Name = string.Empty;
                ImgSourse = null;
                LoadFoodAsync();
            }
            OpenOkMethod(result + "!");
        }
        public void AddMenuFoodMethod(object p)
        {
            result = "Запольните поля ";

            if ((NameMenuFood == null || NameMenuFood.Replace(" ", "").Length == 0))
            {
                result += "Названи меню  ";
                OpenOkMethod(result + "!");
            }
            else 
            {
                result = DateWorker.CreateMenuFood(NameMenuFood);
                NameMenuFood = string.Empty;
                LoadFoodAsync();
            }
            
           
        }
        private void DeleteFoodMethod(object p)
        {
            PropertyInfo property = SelectedTable1.GetType().GetProperty("Id");
            int Id = (int)(property.GetValue(SelectedTable1, null));
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteFood(Id);
                    LoadFoodAsync();
                }
            };
            mv.ShowDialog();

        }
        #endregion  Food

        #region AddProduct and ByProduct
        private void CreateReceiptGoodsMethod(object p)
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
                LoadReceiptDoodAsync("");
            }
            OpenOkMethod(result + "!");
        }
        public void AddProductMethod(object p)
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
                result = DateWorker.CreateProduct(Name, SelectedComboboxText);
                Name = string.Empty;
                LoadProductAsync();
            }
            OpenOkMethod(result + "!");
        }
        #endregion  AddProduct and ByProduct
        
        #region Waiter
        private void ClearWaiterMethod(object p)
        {
            Name = string.Empty;
            Pass = string.Empty;
            Tel = string.Empty;
            Adress = string.Empty;
            AliasName = string.Empty;
            SalaryType = 0;
            SalaryType2 = 0;
            SalaryType3 = 0;
        }
        private void EditWaiterMethod(object p)
        {
            result = "Запольните поля ";
            int flag = 0;
            if (Name == null || Name.Replace(" ", "").Length == 0)
            {
                result += "Ф.И.О, ";
                flag = 1;

            }
            if (Pass == null || Pass.Replace(" ", "").Length == 0)
            {
                result += "Пароль ,";

                flag = 1;
            }
            if (Tel == null || Tel.Replace(" ", "").Length == 0)
            {
                result += "Телефон ,";
                flag = 1;
            }
            if (Adress == null || Adress.Replace(" ", "").Length == 0)
            {
                result += "Адрес ,";
                flag = 1;
            }

            if (flag == 0)
            {
                result = DateWorker.EditWaiter(SelectedWaiters, Name, Pass, Tel, Adress, AliasName, SalaryType, SalaryType2, SalaryType3);
                Name = string.Empty;
                Pass = string.Empty;
                Tel = string.Empty;
                Adress = string.Empty;
                SalaryType = 0;
                SalaryType2 = 0;
                SalaryType3 = 0;
                UpdateWaiterAsync();
            }
            OpenOkMethod(result + "!");

        }
        private void ChanceProperties(object p)
        {
            Name = SelectedWaiters.Name;
            Adress = SelectedWaiters.address;
            Tel = SelectedWaiters.Tel;
            Pass = SelectedWaiters.Pass;
        }
        private void DeleteWaiterMethod(object p)
        {
            result = "";
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteWaiter(SelectedWaiters);
                    UpdateWaiterAsync();
                }
            };
            mv.ShowDialog();


        }
        private void MethodCreateWaiter(object p)
        {
            result = "Запольните поля ";
            int flag = 0;
            if (Name == null || Name.Replace(" ", "").Length == 0)
            {
                result += "Ф.И.О, ";
                flag = 1;

            }
            if (Pass == null || Pass.Replace(" ", "").Length == 0)
            {
                result += "Пароль ,";

                flag = 1;
            }
            if (Tel == null || Tel.Replace(" ", "").Length == 0)
            {
                result += "Телефон ,";
                flag = 1;
            }
            if (Adress == null || Adress.Replace(" ", "").Length == 0)
            {
                result += "Адрес ,";
                flag = 1;
            }

            if (flag == 0)
            {
                result = DateWorker.CreateWaiter(Name, Pass, Tel, Adress, AliasName, SalaryType, SalaryType2, SalaryType3);
                Name = string.Empty;
                Pass = string.Empty;
                Tel = string.Empty;
                Adress = string.Empty;
                AliasName = string.Empty;
                UpdateWaiterAsync();
            }
            OpenOkMethod(result + "!");
        }
        #endregion Waiter

        #region Location and Table
        private void DeleteTableMethod(object p)
        {
            PropertyInfo property = SelectedTable1.GetType().GetProperty("Id");
            int Id = (int)(property.GetValue(SelectedTable1, null));
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteTable(Id);
                    UpdateWaiterAsync();
                }
            };
            mv.ShowDialog();

        }
        private void ChangeTableMethod(object p)
        {
            PropertyInfo property = SelectedTable1.GetType().GetProperty("TableName");
            TableName = (string)(property.GetValue(SelectedTable1, null));

        }
        private void CreateLocationMethod(object p)
        {
            result = "Запольните поля ";
            if (Name == null || Name.Replace(" ", "").Length == 0)
            {
                result += "Ф.И.О, ";
            }
            else
            {
                result = DateWorker.CreateLocation(Name);
                Name = string.Empty;

            }
            UpdateWaiterAsync();
            OpenOkMethod(result);

        }
        private void CreateTablenMethod(object p)
        {
            result = "Запольните поля ";
            int flag = 0;
            if (TableName == null || TableName.Replace(" ", "").Length == 0)
            {
                result += "Ф.И.О, ";
                flag = 1;
            }
            if (SelectedLocation == null)
            {
                result += "Комната, ";
                flag = 1;
            }

            if (flag == 0)
            {
                result = DateWorker.CreateTable(TableName, SelectedLocation);
                TableName = string.Empty;

            }
            OpenOkMethod(result);

        }
        private void DeleteLocationMethod(object p)
        {
            result = "";
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteLocation(SelectedLocation);
                    UpdateWaiterAsync();
                }
            };
            mv.ShowDialog();


        }
        #endregion Location
        public void OpenOkCancelMethod(string s)
        {
            MessageWindow wn = new MessageWindow(s);
            wn.ShowDialog();
        }
        public void OpenOkMethod(string s)
        {
            s = s.Substring(0, s.Length - 2);
            MessageWindowOk wn = new MessageWindowOk(s);
            wn.ShowDialog();
        }

    }
}

