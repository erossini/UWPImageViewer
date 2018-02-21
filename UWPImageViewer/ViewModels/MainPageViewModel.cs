using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWPImageViewer.Data;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPImageViewer.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<string> Images { get; set; }

        public MainPageViewModel()
        {
            LoadData();
        }

        public void LoadData(int category = 1)
        {
            switch(category)
            {
                case 2:
                    Images = new ObservableCollection<string>(ImageData.Dogs);
                    break;
                case 3:
                    Images = new ObservableCollection<string>(ImageData.Babies);
                    break;
                default:
                    Images = new ObservableCollection<string>(ImageData.Cats);
                    break;
            }
            PictureNumber = Images.Count;

            if (PictureNumber < 9)
                for (int i = PictureNumber; i < 10; i++)
                    Images.Add("");

            CallUpdate();
        }

        void CallUpdate()
        {
            OnPropertyChanged(nameof(Images));
            OnPropertyChanged(nameof(Picture1));
            OnPropertyChanged(nameof(Picture2));
            OnPropertyChanged(nameof(Picture3));
            OnPropertyChanged(nameof(Picture4));
            OnPropertyChanged(nameof(Picture5));
            OnPropertyChanged(nameof(Picture6));
            OnPropertyChanged(nameof(Picture7));
            OnPropertyChanged(nameof(Picture8));
            OnPropertyChanged(nameof(Picture9));
        }

        public string Picture1 => Images[0];
        public string Picture2 => Images[1];
        public string Picture3 => Images[2];
        public string Picture4 => Images[3];
        public string Picture5 => Images[4];
        public string Picture6 => Images[5];
        public string Picture7 => Images[6];
        public string Picture8 => Images[7];
        public string Picture9 => Images[8];

        public int PictureNumber
        {
            get => _pictures;
            set {
                if (_pictures != value)
                {
                    _pictures = value;
                    OnPropertyChanged(nameof(PictureNumber));
                }
            }
        }
        private int _pictures;

        #region "propertychanged"
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}