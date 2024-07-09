using AdminKafe.View.Windows;
using KafeProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace AdminKafe.ViewModels
{
    public abstract class AbstractClass<T> : ViewModel
    {
      
        public AbstractClass()
        {
            LoadAllDate();
        }
        public abstract void LoadAllDate(string name = "");
        
        public int SkipCount = 0;
        public int TakeCount = 50;

        #region PropertyRegion
        private string _Search = "";
        public virtual string Search
        {
            get => _Search;
            set
            {
                Set(ref _Search, value);
                SeachAllDate = AllDate;
                LoadAllDate(_Search);
            }
        }
        
        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }
        private int _Count;
        public int Count
        {
            get => _Count;
            set => Set(ref _Count, value);
        }


        private string _SelectedText;
        public string SelectedText
        {
            get => _SelectedText;
            set => Set(ref _SelectedText, value);
        }

        private string _SelectedComboboxText;
        public string SelectedComboboxText
        {
            get => _SelectedComboboxText;
            set => Set(ref _SelectedComboboxText, value);
        }
        private List<T> _AllDate;
        public List<T> AllDate
        {
            get => _AllDate;
            set => Set(ref _AllDate, value);
        }

        private List<T> _SeachAllDate;
        public List<T> SeachAllDate
        {
            get => _SeachAllDate;
            set => Set(ref _SeachAllDate, value);
        }

        private List<object> _AllObjectDate;
        public List<object> AllObjectDate
        {
            get => _AllObjectDate;
            set => Set(ref _AllObjectDate, value);
        }

        private object _ObjectDate;
        public object ObjectDate
        {
            get => _ObjectDate;
            set => Set(ref _ObjectDate, value);
        }

        private T _SelectedDate;
        public T SelectedDate
        {
            get => _SelectedDate;
            set => Set(ref _SelectedDate, value);
        }

        private object _SelectedDateObject;
        public object SelectedDateObject
        {
            get => _SelectedDateObject;
            set => Set(ref _SelectedDateObject, value);
        }

        #endregion PropertyRegion

        #region Pagination
        private double _CountPage = 0;
        public double CountPage
        {
            get => _CountPage;
            set
            {
                if (value > -1 && value < AllCoutPage)
                    Set(ref _CountPage, value);

            }
        }

        private int AllCoutPage;
        private string _TextPage;
        public string TextPage
        {
            get => _TextPage;
            set => Set(ref _TextPage, value);
        }

        private double _SelectedCountPage = 50;
        public double SelectedCountPage
        {
            get => _SelectedCountPage;
            set
            {
                Set(ref _SelectedCountPage, value);
                CountPage = 0;
                ShowAllPage();
                LoadAllDate();
            }
        }
        private double _Count1;
        public double Count1
        {
            get => _Count1;
            set => Set(ref _Count1, value);

        }

        private double _Price;
        public double Price
        {
            get => _Price;
            set => Set(ref _Price, value);
        }
        private byte[] _ImgSourse;
        public byte[] ImgSourse
        {
            get => _ImgSourse;
            set => Set(ref _ImgSourse, value);
        }

        public void ShowAllPage()
        {

            SkipCount = Convert.ToInt32(CountPage * SelectedCountPage);
            TakeCount = Convert.ToInt32(SelectedCountPage);
            AllCoutPage = Convert.ToInt32(Count1 / SelectedCountPage);
            if (Count1 % 2 != 0) AllCoutPage = AllCoutPage + 1;
            TextPage = $"{CountPage + 1} до {AllCoutPage} ";
            LoadAllDate(Search);
        }
        #endregion Pagination

        public void ImgSourceMethod(object p)
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
        public ICommand CreateCommand{ get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand ShowWindowCommand { get; set; }
        public ICommand CreatMenuCommand { get; set; }
        public ICommand NextPage { get; set; }
        public ICommand BackPage { get; set; }
        public ICommand ImgSourceCommand { get; set; }
        public ICommand ShowOtchet { get; set; }

        public bool CanCloseApplicationExecat(object p) => true;
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
        public void CloseCommandMethod(object p)
        {
            Window wn = p as Window;
            wn.Close();
        }

        public string result = "";
    }
}
