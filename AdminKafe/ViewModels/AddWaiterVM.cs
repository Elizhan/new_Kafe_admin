using AdminKafe.Models;
using AdminKafe.View.Windows;
using CV19.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AdminKafe.ViewModels
{
    public class AddWaiterVM : AbstractClass<Waiter>, ICommandMethod
    {
        public ICommand ViewReportButtom { get; set; }
        public AddWaiterVM()
        {
            ViewReportButtom = new LambdaCommand(GetAllWaiterSalary, CanCloseApplicationExecat);
            CreateCommand = new LambdaCommand(CreateMethod, CanCloseApplicationExecat);
            DeleteCommand = new LambdaCommand(DeleteMethod, CanCloseApplicationExecat);
           
        }
        #region WaiterProperties
       
        private double _SalaryType;
        public double SalaryType
        {
            get => _SalaryType;
            set => Set(ref _SalaryType, value);
        }
        private string _SalaryType1;
        public string SalaryType1
        {
            get => _SalaryType1;
            set => Set(ref _SalaryType1, value);
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

        private string _Adress;
        public string Adress
        {
            get => _Adress;
            set => Set(ref _Adress, value);
        }

        private int Waiterid;
        public int WaiterID
        {
            get => Waiterid;
            set => Set(ref Waiterid, value);
        }

        private double salaryItog;
        public double SalaryItog
        {
            get => salaryItog;
            set => Set(ref salaryItog, value);
        }

        private DateTime searchText;
        public DateTime SearchText
        {
            get => searchText;
            set
            {
                Set(ref searchText, value);
                AllObjectDate = DateWorker.GetAllWaiterSalarySearch(selected.Id, DateDo, DatePosle, searchText);
            }
        }

        private DateTime dateDo = DateTime.Now;
        public DateTime DateDo
        {
            get => dateDo;
            set => Set(ref dateDo, value);
        }

        private DateTime datePosle = DateTime.Now;
        public DateTime DatePosle
        {
            get => datePosle;
            set => Set(ref datePosle, value);
        }

        private Waiter selected;
        public Waiter Selected
        {
            get => selected;
            set
            {
                Set(ref selected, value);
                if (selected!=null)
                {
                    WaiterID = selected.Id;
                    Name = selected.Name;
                    Adress = selected.address;
                    Tel = selected.Tel;
                    SalaryType1 = selected.SalaryType;
                    AllObjectDate = DateWorker.GetAllWaiterSalary(selected.Id, DateDo, DatePosle);
                    SalaryItog = DateWorker.SummServices;
                    //MessageBox.Show(SalaryItog.ToString());
                }
            }
        }
        #endregion WaiterProperties

        public void CreateMethod(object p)
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
                    result = DateWorker.DeleteWaiter(SelectedDate);
                    LoadAllDate();
                }
            };
            mv.ShowDialog();
        }

        public void EditMethod(object p)
        {
            throw new NotImplementedException();
        }

        public override async void LoadAllDate(string name="")
        {
            await Task.Run(() =>
            {
                AllDate = DateWorker.GetAllWaiter(name);
                AllObjectDate = DateWorker.GetAllWaiterSalary(0, DateDo, DatePosle);
            });

        }

        private async void GetAllWaiterSalary(object o)
        {
            await Task.Run(() =>
            {
                if (SelectedText!=String.Empty)
                {
                    AllObjectDate = DateWorker.GetAllWaiterSalary(WaiterID, DateDo, DatePosle);
                    SalaryItog = DateWorker.SummServices;
                }
            });
        }

        /*public async void LoadSalaryMethod()
        {
            await Task.Run(() =>
            {
                AllObjectDate = DateWorker.GetAllWaiterSalary("");
            });
        }*/
    }
}
