using GoogleMapSDK.UI.WinForm.Components.Photo;
using GoogleMapSDK.UI.WPF.Components.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleMapSDK.UI.WPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            PlacePhotoItem_WPF placePhotoItem = new PlacePhotoItem_WPF();
            placePhotoItem.ImageSource = await placePhotoItem.CollectPhotosAsync("ChIJy02Q7MEjaDQRVuRcRdQpwc0", 200);

            this.container.Children.Add(placePhotoItem);
        }
    }
}
