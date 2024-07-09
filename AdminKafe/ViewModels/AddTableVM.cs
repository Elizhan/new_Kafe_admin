using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace AdminKafe.ViewModels
{
    public class AddTableVM : AbstractClass<Table>, ICommandMethod
    {
        public AddTableVM()
        {
            CreateCommand = new LambdaCommand(CreateMethod, CanCloseApplicationExecat);
            DeleteCommand = new LambdaCommand(DeleteMethod, CanCloseApplicationExecat);
            ShowWindowCommand = new LambdaCommand(ShowWindowMethod, CanCloseApplicationExecat);
      
        }
        #region WaiterProperties
       

        private List<Location> allLocation;
        public List<Location> AllLocation
        {
            get => allLocation;
            set => Set(ref allLocation, value);
        }
        private Location _SelectedLocation;
        public Location SelectedLocation
        {
            get => _SelectedLocation;
            set => Set(ref _SelectedLocation, value);
        }

        private string _Tel;
        public string Tel
        {
            get => _Tel;
            set => Set(ref _Tel, value);
        }

        private string _Adress;
        public string Adress
        {
            get => _Adress;
            set => Set(ref _Adress, value);
        }
        private string _TableName;
        public string TableName
        {
            get => _TableName;
            set => Set(ref _TableName, value);
        }

        #endregion WaiterProperties

        public void CreateMethod(object p)
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
            LoadAllDate();
            OpenOkMethod(result);
        }

        public void DeleteMethod(object p)
        {
            PropertyInfo property = SelectedDateObject.GetType().GetProperty("Id");
            int Id = (int)(property.GetValue(SelectedDateObject, null));
            MessageWindow mv = new MessageWindow("Вы уеронно хотите удалить?");
            mv._mess += x =>
            {
                if (x == 1)
                {
                    result = DateWorker.DeleteTable(Id);
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
                AllObjectDate = DateWorker.GetAllTables();
                AllLocation = DateWorker.GetAllLocation();
            });

        }

        public void ShowWindowMethod(object p)
        {
            AddMenuFoodWindow mf = new AddMenuFoodWindow();
            mf.ShowDialog();
        }

    }
}
