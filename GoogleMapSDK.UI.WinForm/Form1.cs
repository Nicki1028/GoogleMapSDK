using GoogleMapSDK.UI.Contract.Components;
using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
using GoogleMapSDK.UI.WinForm.Components.Comment;
using GoogleMapSDK.UI.WinForm.Components.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForm
{
    public partial class Form1 : Form
    {
        PlaceReviewItem placeReviewItem;
        public Form1(IEnumerable<ReviewBase> reviewBase)
        {
            InitializeComponent();
            placeReviewItem =  (PlaceReviewItem)reviewBase.First(x => x is PlaceReviewItem);
            this.Controls.Add((Control)reviewBase);
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            //PlacePhotoItem placePhotoItem = new PlacePhotoItem();
            //placePhotoItem.ImageSource = await placePhotoItem.CollectPhotosAsync("ChIJy02Q7MEjaDQRVuRcRdQpwc0", 200);

            //placePhotoItem.Size = new Size(800, 200);

            placeReviewItem.Size = new Size(350, 600);
            placeReviewItem.ReviewSource = await placeReviewItem.GetReviewsAsync("ChIJy02Q7MEjaDQRVuRcRdQpwc0");

        }
    }
}
