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
    public class AddServiceVM : AbstractClass<Consumption>, ICommandMethod
    {
        public AddServiceVM()
        {
            CreateCommand = new LambdaCommand(CreateMethod, CanCloseApplicationExecat);
            DeleteCommand = new LambdaCommand(DeleteMethod, CanCloseApplicationExecat);

        }
        #region WaiterProperties


        private double _Summ;
        public double Summ
        {
            get => _Summ;
            set => Set(ref _Summ, value);
        }



        #endregion WaiterProperties

        public void CreateMethod(object p)
        {
            result = "Запольните поля ";
            if (Name == "")
            {
                result += "Названи блюда, ";

            }
            else
            {
                result = DateWorker.CreateConsumption(Name, Summ);
                Name = string.Empty;
                Summ = 0;
                LoadAllDate();
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
                   result = DateWorker.DeleteConsumption(SelectedDate);
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
                AllDate = DateWorker.GetAllConsumption(name);
            });

        }


    }
}

