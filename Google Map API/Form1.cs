using Google_Map_API.Place_Photo;
using Google_Map_API.Places_Detail;
using GoogleApi.Entities.Places.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Google_Map_API
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            GoogleContext context = new GoogleContext(new GoogleSigned());
            PlacePhotoRequest placePhotoRequest = new PlacePhotoRequest();
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = "ChIJXQy7EvkeaDQRmdRXwKhr5OY";
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);
            
            var photos = result.result.photos;
            List<PlacePhotoRequest> placePhotoRequests = photos.Select(x => new PlacePhotoRequest()
            {
                photo_reference = x.photo_reference,
                maxheight = 100
            }).ToList();
                                   
            List<Bitmap> maps  = await context.PlacePhoto.GetPhotos(placePhotoRequests);

            foreach (var map in maps)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = map;
                pictureBox.Width = 100;
                pictureBox.Height = 100;
                flowLayoutPanel1.Controls.Add(pictureBox);
            }          

        }
    }
}
