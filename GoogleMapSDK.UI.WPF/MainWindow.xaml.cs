using GoogleMapSDK.UI.WPF.Components.Comment;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
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
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WPF
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEnumerable<IAutoCompleteView> autoCompletes)
        {
            InitializeComponent();
            //PlaceAutoComplete_WPF completeView = (PlaceAutoComplete_WPF)autoCompletes.First(x => x.GetType() == typeof(PlaceAutoComplete_WPF));
            //this.container.Children.Add(completeView);
        }
        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            //PlacePhotoItem_WPF placePhotoItem = new PlacePhotoItem_WPF();
            //placePhotoItem.ImageSource = await placePhotoItem.CollectPhotosAsync("ChIJy02Q7MEjaDQRVuRcRdQpwc0", 200);

            //PlaceReviewItem_WPF placeReviewItem_WPF = new PlaceReviewItem_WPF();
            //placeReviewItem_WPF.ReviewSource = (await placeReviewItem_WPF.GetReviewsAsync("ChIJy02Q7MEjaDQRVuRcRdQpwc0")).ToList();
            
            //PlaceAutoComplete placeAutoComplete = new PlaceAutoComplete();

            //this.container.Children.Add(placeReviewItem_WPF);
        }
    }
}
