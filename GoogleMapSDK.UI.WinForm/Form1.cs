using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
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
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            PlacePhotoItem placePhotoItem = new PlacePhotoItem();
            placePhotoItem.ImageSource = await placePhotoItem.CollectPhotosAsync("ChIJy02Q7MEjaDQRVuRcRdQpwc0", 200);
            

            placePhotoItem.Size = new Size(800, 200);
            this.Controls.Add(placePhotoItem);
        }
    }
}
