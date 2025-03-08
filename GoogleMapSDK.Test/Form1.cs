using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Core.Overlay.MarkerOverlay;
using GoogleMapSDK.Core.Overlay.RouteOverlay;
using GoogleMapSDK.Core;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.Direction;

namespace GoogleMapSDK.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   
        GoogleContext context = new GoogleContext();
        GMapOverlay markers = new GMapOverlay("markers");
        List<LocationMarker> locationMarkers = new List<LocationMarker>();       
        RouteOverlay route1 = new RouteOverlay("route1");
        PointLatLng origin;
        PointLatLng destination;


   
        public async Task<List<PointLatLng>> GooglePlaceDetailAsync(string destination, int radius)
        {

            List<PointLatLng> Latlngpoints = new List<PointLatLng>();
            TextSearchRequest textSearchRequest = new TextSearchRequest();
            {
                textSearchRequest.query = destination;
                textSearchRequest.radius = radius;
            };
            var result = await context.NearbyAndText.TextSearch(textSearchRequest);
            if (result.results != null)
            {
                foreach (var item in result.results)
                {
                    var lat = item.geometry.location.lat;
                    var lng = item.geometry.location.lng;
                    PointLatLng point = new PointLatLng(lat, lng);
                    Latlngpoints.Add(point);
                }
            }
            return Latlngpoints;
        }
        public async Task<List<string>> GooglePlaceDetailNameAsync(string destination, int radius)
        {
            List<string> namepoints = new List<string>();
            TextSearchRequest textSearchRequest = new TextSearchRequest();
            {
                textSearchRequest.query = destination;
                textSearchRequest.radius = radius;
            };
            var result = await context.NearbyAndText.TextSearch(textSearchRequest);
            if (result.results != null)
            {
                foreach (var item in result.results)
                {
                    string name = item.name;
                    namepoints.Add(name);
                }
            }
            return namepoints;
        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {
            this.mapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            this.mapControl1.DragButton = MouseButtons.Left;
            this.mapControl1.MinZoom = 4;                                                                            // whole world zoom
            this.mapControl1.MaxZoom = 20;
            this.mapControl1.Zoom = 15;
            this.mapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.mapControl1.Position = new PointLatLng(24.93, 121.21);
            this.mapControl1.Overlays.Add(markers);
           
            //this.mapControl1.OnMarkerClick += GMapControl1_OnMarkerClick;
            //this.mapControl1.OnMapZoomChanged += GMapControl1_OnMapZoomChanged;
            //this.mapControl1.OnPositionChanged += GMapControl1_OnPositionChanged;
        }

        //private void GMapControl1_OnPositionChanged(PointLatLng point)
        //{
        //    if (Mapleft1)
        //    {
        //        this.gMapControl2.Position = point;
        //    }
        //}

        //private void GMapControl1_OnMapZoomChanged()
        //{
        //    //double zoom =  + Convert.ToDouble(5);
        //    this.gMapControl2.Zoom = this.gMapControl1.Zoom; //zoom;
        //}

        //private void GMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        //{
        //    MessageBox.Show(item.ToolTipText);
        //}

        //private void gMapControl2_Load(object sender, EventArgs e)
        //{
        //    this.gMapControl2.MapProvider = GoogleMapProvider.Instance;
        //    GMaps.Instance.Mode = AccessMode.ServerAndCache;
        //    this.gMapControl2.MaxZoom = 20;
        //    this.gMapControl2.Zoom = 17;
        //    this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
        //    this.gMapControl2.Position = new PointLatLng(24.93, 121.21);
        //}

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            List<PointLatLng> pointLatlng = await GooglePlaceDetailAsync(textBox1.Text, int.Parse(textBox2.Text));
            if (pointLatlng != null)
            {
                foreach (var item in pointLatlng)
                {
                    GMapMarker markeritem = new GMarkerGoogle(item, GMarkerGoogleType.red_dot);
                    markers.Markers.Add(markeritem);
                }
            }
            List<string> pointList = await GooglePlaceDetailNameAsync(textBox1.Text, int.Parse(textBox2.Text));
            if (pointList != null)
            {
                foreach (var item in pointList)
                {
                    listBox1.Items.Add(item);
                }
            }
            for (int i = 0; i < pointLatlng.Count; i++)
            {
                locationMarkers.Add(new LocationMarker(pointList[i], markers.Markers[i]));
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;

            var selectedLocation = locationMarkers[listBox1.SelectedIndex];
            var selectedMarker = selectedLocation.Marker;
            selectedMarker.ToolTipText = selectedLocation.Name.ToString();
            this.mapControl1.Position = selectedLocation.Marker.Position;
        }
        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            route1.Clear();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = textBox1.Text;
            directionRequest.destination = textBox3.Text;
            var result = await context.Direction.Direction(directionRequest);
            foreach (var item in result.routes)
            {
                origin = new PointLatLng(item.legs[0].start_location.lat, item.legs[0].start_location.lng);
                destination = new PointLatLng(item.legs[0].end_location.lat, item.legs[0].end_location.lng);
                route1.AddRange(item.overview_polyline.polylinePoints.Select(x => (x.Latitude, x.Longitude)));
            }
            this.mapControl1.AddMarker(origin, "markers");
            this.mapControl1.AddMarker(destination, "markers");
            this.mapControl1.AddOverlay(route1);
            this.mapControl1.SetCenter(origin.Lat, origin.Lng);
        }

        private void mapControl2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> waypoints = new List<string>();
            waypoints.Add("元智大學");
            waypoints.Add("健行科技大學");

        }
    }
}
