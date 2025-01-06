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
              
        List<string> autocompletetext = new List<string>();
        List<string> autocompletetext2 = new List<string>();
        GMap.NET.WindowsForms.GMapMarker markerorigin = null;
        GMap.NET.WindowsForms.GMapMarker markerdestination = null;
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

            autoCompleteTextBox2.KeyUp += AutoCompleteTextBox2_KeyUp;
            autoCompleteTextBox2._getPlaceId += AutoCompleteGetplaceId2;
            autoCompleteTextBox2.DisplayMember = "Name";
            autoCompleteTextBox2.ValueMember = "Id";
        }

        private void GMapControl1_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
            Console.WriteLine(((MarkerInfo)marker.Tag).PlaceId);
            MarkerInfo info = (MarkerInfo)marker.Tag;
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

        private void AutoCompleteTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            this.Timerextention((async () =>
            {
                AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
                autoCompleteRequest.input = autoCompleteTextBox2.Text;
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
                autoCompleteTextBox2.DataSource = places;
            }));
            
        }

        private void AutoCompleteTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.Timerextention((async () =>
            {
                AutoCompleteRequest autoCompleteRequest = new AutoCompleteRequest();
                autoCompleteRequest.input = autoCompleteTextBox1.Text;
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
                autoCompleteTextBox1.DataSource = places;
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

            //if (marker1.Markers.Contains(markerdestination))
            //{
            //    marker1.Markers.Remove(markerdestination);
            //    this.gMapControl1.Refresh();
            //}
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
            //PlacePhotoRequest photoRequest = new PlacePhotoRequest();
            //photoRequest.photo_reference = result.result.photos[0].photo_reference;
            //photoRequest.maxheight = 30;
            //Bitmap photobitmap = context.PlacePhoto.GetPhoto(photoRequest);


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

       
        
        private async void AutoCompleteGetplaceId(object sender, object e)
        {            
            //if (markers.Markers.Contains(markerorigin))
            //{
            //    markers.Markers.Remove(markerorigin);
            //    this.gMapControl1.Refresh();
            //}
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = e.ToString();
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);
            PointLatLng markerorigin = new PointLatLng(result.result.geometry.location.lat, result.result.geometry.location.lng);
            MarkerInfo markerinfo = new MarkerInfo();
            markerinfo.Name = result.result.name;
            markerinfo.Address = result.result.formatted_address;
            markerinfo.PlaceId = result.result.place_id;
            markerinfo.TextboxId = autoCompleteTextBox1.Name;
            this.mapControl1.AddMarker(markerorigin, "marker1", markerinfo);
          
            //this.mapControl1.AddMarkers(pointLatLng[]);          
            //this.mapControl1.AddMarker(pointLatLng,"id");
            //this.mapControl1.AddMarkers(pointLatLng[],"id");
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            route1.Clear();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = textBox1.Text;
            directionRequest.destination = textBox2.Text;
            var result = await context.Direction.Direction(directionRequest);
            foreach (var item in result.routes)
            {
                origin = new PointLatLng(item.legs[0].start_location.lat, item.legs[0].start_location.lng);
                destination = new PointLatLng(item.legs[0].end_location.lat, item.legs[0].end_location.lng);
                route1.AddRange(item.overview_polyline.polylinePoints.Select(x => (x.Latitude, x.Longitude)));
                
                //foreach (var data in item.legs[0].steps)
                //{               
                //    route1.Points.Add(new PointLatLng(data.end_location.lat, data.end_location.lng));                  
                //}

            }
            
            this.mapControl1.AddMarker(origin, "marker1");
            this.mapControl1.AddMarker(destination, "marker1");
            //GMap.NET.WindowsForms.GMapMarker markerorigin = new GMarkerGoogle(origin, GMarkerGoogleType.red_dot);
            //GMap.NET.WindowsForms.GMapMarker markerdes = new GMarkerGoogle(destination, GMarkerGoogleType.red_dot);
            //markers.Markers.Add(markerorigin);
            //markers.Markers.Add(markerdes);
        }
                       
       
        private async void button2_Click(object sender, EventArgs e)
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
                route1.AddRange(item.overview_polyline.polylinePoints.Select(x=> (x.Latitude,x.Longitude)));
                //foreach (var data in item.legs[0].steps)
                //{
                //    route1.Points.Add(new PointLatLng(data.end_location.lat, data.end_location.lng));
                //}

            }
            
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            List<PlaceModel> placeModels = new List<PlaceModel>();
            placeModels.Add(new PlaceModel { Name = "NCU", Id = "1" });
            placeModels.Add(new PlaceModel { Name = "CYCU", Id="2" });
            listBox1.DataSource = placeModels;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(listBox1.SelectedValue.ToString());        
        }

        private void autoCompleteTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
