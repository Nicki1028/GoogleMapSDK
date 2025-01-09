using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google_Map_API;
using Google_Map_API.Direction;
using Google_Map_API.Place_Photo;
using Google_Map_API.Places;
using Google_Map_API.Places_Detail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;

namespace Gmap
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();          
        }
        GoogleContext context = new GoogleContext(new GoogleSigned());
        MarkerOverlay marker1 = new MarkerOverlay("marker1");
        RouteOverlay route1 = new RouteOverlay("route1");
             
        PointLatLng origin;
        PointLatLng destination;
        List<Bitmap> allPhotos;
        private void mapControl1_Load(object sender, EventArgs e)
        {
            this.mapControl1.DragButton = MouseButtons.Left;
            this.mapControl1.SetCenter(24.93, 121.21);
            this.mapControl1.SetZoomLevel(15);
            this.mapControl1.AddOverlay(marker1);
            this.mapControl1.AddOverlay(route1);
            this.mapControl1.OnMarkerClick += GMapControl1_OnMarkerClick;
            
            autoCompleteTextBox1.KeyUp += AutoCompleteTextBox1_KeyUp;
            autoCompleteTextBox1._getPlaceId += AutoCompleteGetplaceId2;
            autoCompleteTextBox1.DisplayMember = "Name";
            autoCompleteTextBox1.ValueMember = "Id";

            autoCompleteTextBox2.KeyUp += AutoCompleteTextBox1_KeyUp;
            autoCompleteTextBox2._getPlaceId += AutoCompleteGetplaceId2;
            autoCompleteTextBox2.DisplayMember = "Name";
            autoCompleteTextBox2.ValueMember = "Id";
        }

        private void GMapControl1_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
            Console.WriteLine(((MarkerInfo)marker.Tag).PlaceId);
            MarkerInfo info = (MarkerInfo)marker.Tag;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            GetReview(info);
            GetPicture(allPhotos);
            
        }
        private void GetReview(MarkerInfo markerInfo)
        {
            
            flowLayoutPanel1.Controls.AddRange(markerInfo.reviews.Select(x=> new ReviewItem(x)).ToArray());

        }
        private void GetPicture(List<Bitmap> bitmaps)
        {
            
            flowLayoutPanel2.Controls.Add(new PhotoItem(bitmaps));

        }

       

        private void AutoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            AutoCompleteTextBox autoComplete = (AutoCompleteTextBox)sender;
            this.Timerextention((async () =>
            {
                AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
                autoCompleteRequest.input = autoComplete.Text;
                var result = await context.AutoComplete.AutoCompleteSearch(autoCompleteRequest);

                List<PlaceModel> places = new List<PlaceModel>();
                foreach (var item in result.predictions)
                {
                    places.Add(new PlaceModel
                    {
                        Name = item.structured_formatting.main_text,
                        Id = item.place_id
                    });
                }
                autoComplete.DataSource = places;
            }));
        }
        public async Task<List<Bitmap>> CollectPhotosAsync(List<string> photoReferences, int maxHeight)
        {
  
            List<Task<Bitmap>> photoTasks = new List<Task<Bitmap>>();

            foreach (var photoRef in photoReferences)
            {
              
                photoTasks.Add(Task.Run(() =>
                {
                    var photoRequest = new PlacePhotoRequest
                    {
                        photo_reference = photoRef,
                        maxheight = maxHeight
                    };               
                    return context.PlacePhoto.GetPhoto(photoRequest);
                }));
            }

            List<Bitmap> allPhotos = (await Task.WhenAll(photoTasks)).ToList() ;
            return allPhotos;
        }




        private async void AutoCompleteGetplaceId2(object sender, object e)
        {

            AutoCompleteTextBox data = (AutoCompleteTextBox)sender;
            
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = e.ToString();
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);
            
            List<string> photoReferences = new List<string>();
            foreach (var info in result.result.photos)
            {
                photoReferences.Add(info.photo_reference);
            }
          
            allPhotos = await CollectPhotosAsync(photoReferences, 200);

            PointLatLng markerdestination = new PointLatLng(result.result.geometry.location.lat, result.result.geometry.location.lng);
            MarkerInfo markerinfo = new MarkerInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.TextboxId = data.Name;
            markerinfo.reviews = result.result.reviews;
            markerinfo.Lat = result.result.geometry.location.lat;
            markerinfo.Lng = result.result.geometry.location.lng;
            
           
            this.mapControl1.AddMarker(markerdestination, "marker1", markerinfo);
            this.mapControl1.SetCenter(markerinfo.Lat, markerinfo.Lng);
        }


        private async void button2_Click_1(object sender, EventArgs e)
        {
            route1.Clear();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = autoCompleteTextBox1.GetPlaceId();
            directionRequest.destination = autoCompleteTextBox2.GetPlaceId();
            var result = await context.Direction.Direction(directionRequest);
            foreach (var item in result.routes)
            {
                origin = new PointLatLng(item.legs[0].start_location.lat, item.legs[0].start_location.lng);
                destination = new PointLatLng(item.legs[0].end_location.lat, item.legs[0].end_location.lng);
                route1.AddRange(item.overview_polyline.polylinePoints.Select(x => (x.Latitude, x.Longitude)));

            }
        }
    }
}
