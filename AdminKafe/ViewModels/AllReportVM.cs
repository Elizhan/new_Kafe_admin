using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdminKafe.ViewModels
{
    public class AllReportVM : AbstractClass<Check>, ICommandMethod
    {
        public AllReportVM()
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
        private object _SelectedProperties;
        public object SelectedProperties {
            get => _SelectedProperties;
            set
            {
                Set(ref _SelectedProperties, value);
                PropertyInfo property = SelectedProperties.GetType().GetProperty("Id");
                int Id = (int)(property.GetValue(SelectedProperties, null));

                PropertyInfo CheckCount = SelectedProperties.GetType().GetProperty("CheckCount");
                NumberCheck = (int)(CheckCount.GetValue(SelectedProperties, null));

                PropertyInfo CheckDate = SelectedProperties.GetType().GetProperty("CheckDate");
                DateTimeProperties = (DateTime)(CheckDate.GetValue(SelectedProperties, null));

                PropertyInfo WaiterName = SelectedProperties.GetType().GetProperty("WaiterName");
                WaiterProperties = (string)(WaiterName.GetValue(SelectedProperties, null));
                
                PropertyInfo Status = SelectedProperties.GetType().GetProperty("Status");
                StatusProperties = (string)(Status.GetValue(SelectedProperties, null));
                
                PropertyInfo TableName = SelectedProperties.GetType().GetProperty("TableName");
                TableProperties = (string)(TableName.GetValue(SelectedProperties, null));

                PropertyInfo GuestCount = SelectedProperties.GetType().GetProperty("GuestCount");
              int  GuestCount1 = (int)(GuestCount.GetValue(SelectedProperties, null));
                ShowOreders(Id, GuestCount1);
            }
        }

        private int _NumberCheck;
        public int NumberCheck
        {
            get => _NumberCheck;
            set
            {
                Set(ref _NumberCheck, value);
            }
        }
        private string _WaiterProperties;
        public string WaiterProperties
        {
            get => _WaiterProperties;
            set
            {
                Set(ref _WaiterProperties, value);
            }
        }

        private DateTime _DateTimeProperties;
        public DateTime DateTimeProperties
        {
            get => _DateTimeProperties;
            set
            {
                Set(ref _DateTimeProperties, value);
            }
        }

        private string _TableProperties;
        public string TableProperties
        {
            get => _TableProperties;
            set
            {
                Set(ref _TableProperties, value);
            }
        }

        private double _SumCheck;
        public double SumCheck
        {
            get => _SumCheck;
            set
            {
                Set(ref _SumCheck, value);
            }
        }
        private double _SummService;
        public double SummService
        {
            get => _SummService;
            set
            {
                Set(ref _SummService, value);
            }
        }

        private string _StatusProperties;
        public string StatusProperties
        {
            get => _StatusProperties;
            set
            {
                Set(ref _StatusProperties, value);
            }
        }

        private List<object> _OrdersProperty;
        public List<object> OrdersProperty
        {
            get => _OrdersProperty;
            set
            {
                Set(ref _OrdersProperty, value);
                
            }
        }
        #endregion WaiterProperties

        public void CreateMethod(object p)
        {
            
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
                AllObjectDate = DateWorker.GetAllCkeck();
               // AllLocation = DateWorker.GetAllLocation();
            });

        }

        public void ShowWindowMethod(object p)
        {
            AddMenuFoodWindow mf = new AddMenuFoodWindow();
            mf.ShowDialog();
        }

        private async void ShowOreders(int Id, int goustCount)
        {
            await Task.Run(() =>
            {
                OrdersProperty = DateWorker.GetAllOrder(Id, goustCount);
                SumCheck = DateWorker.SummByProduct;
                SummService = DateWorker.SummServices;
            });
        }
    }
}

