using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPImageViewer.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UWPImageViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel PageData { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            PageData = new MainPageViewModel();

            this.DataContext = PageData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int code = Convert.ToInt16(button.Tag);

            PageData.PictureNumber = code;
        }

        private void ClickSelectionButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int category = Convert.ToInt16(button.Tag);

            PageData.LoadData(category);
        }
    }
}
