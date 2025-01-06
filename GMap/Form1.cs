using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google_Map_API;
using Google_Map_API.Places;
using System.Linq;

namespace Gmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool Mapleft1 = true;
        GoogleContext context = new GoogleContext(new GoogleSigned());
        GMapOverlay markers = new GMapOverlay("markers");
        List<LocationMarker> locationMarkers = new List<LocationMarker>();

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
            
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            this.gMapControl1.DragButton = MouseButtons.Left;
            this.gMapControl1.MinZoom = 4;                                                                            // whole world zoom
            this.gMapControl1.MaxZoom = 20;
            this.gMapControl1.Zoom = 15;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControl1.Position = new PointLatLng(24.93, 121.21);
            this.gMapControl1.Overlays.Add(markers);


            //GMapRoute route1 = new GMapRoute("route1");
            //route1.Stroke = new Pen(Color.Black, 5);
            //route1.Points.Add(new PointLatLng(24.93759, 121.2168));
            //route1.Points.Add(new PointLatLng(24, 121));
            //route1.Points.Add(new PointLatLng(23.5, 120.5));
            //markers.Routes.Add(route1);
            this.gMapControl1.OnMarkerClick += GMapControl1_OnMarkerClick;
            this.gMapControl1.OnMapZoomChanged += GMapControl1_OnMapZoomChanged;
            this.gMapControl1.OnPositionChanged += GMapControl1_OnPositionChanged;

        }

        private void GMapControl1_OnPositionChanged(PointLatLng point)
        {
            if (Mapleft1)
            {
                this.gMapControl2.Position = point;               
            }
        }

        private void GMapControl1_OnMapZoomChanged()
        {
            //double zoom =  + Convert.ToDouble(5);
            this.gMapControl2.Zoom = this.gMapControl1.Zoom; //zoom;
        }

        private void GMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {           
            MessageBox.Show(item.ToolTipText);
        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {
            this.gMapControl2.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            this.gMapControl2.MaxZoom = 20;
            this.gMapControl2.Zoom = 17;
            this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControl2.Position = new PointLatLng(24.93, 121.21);
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            List<PointLatLng> pointLatlng = await GooglePlaceDetailAsync(textBox1.Text, int.Parse(textBox2.Text));
            if (pointLatlng != null)
            {
                foreach (var item in pointLatlng)
                {
                    GMap.NET.WindowsForms.GMapMarker markeritem = new GMarkerGoogle(item, GMarkerGoogleType.red_dot);
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

            // 聚焦到該標記的位置
            this.gMapControl1.Position = selectedLocation.Marker.Position;
           

        }
    }
}
