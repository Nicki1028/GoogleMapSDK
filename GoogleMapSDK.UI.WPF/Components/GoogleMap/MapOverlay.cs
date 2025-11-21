using GMap.NET.WindowsPresentation;
using GMap.NET;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using GoogleMapSDK.UI.Contract.API.Directions;
using System.Windows;
using System.Windows.Media;

namespace GoogleMapSDK.UI.WPF.Components.GoogleMap
{
    public class MapOverlay : IOverlay
    {
        public ObservableCollection<GMapMarker> markers = new ObservableCollection<GMapMarker>();
        public ObservableCollection<GRoute> routes = new ObservableCollection<GRoute>();
        public void AddMarker(Location location, object toolTip = null)
        {
            PointLatLng point = new PointLatLng(location.Latitude, location.Longitude);
            GMapMarker marker = new GMapMarker(point);
            
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("https://raw.githubusercontent.com/luxiaoxun/MapDownloader/refs/heads/master/GMap.NET.WindowsForms/Resources/red-dot.png", UriKind.Absolute);
            bitmap.EndInit();
            var img = new Image()
            {
                Source = bitmap,
            };
            var customertooltip = new PlaceToolTip();
            customertooltip.DataContext = new PlaceModel()
            {
                Name = "NCU",
                Description = $"{location.Latitude}, {location.Longitude}",
                SourceURL = bitmap.UriSource.ToString(),
            };                                      
            var markerTooltip = customertooltip;           
            ToolTipService.SetInitialShowDelay(markerTooltip,500);                    

            img.ToolTip = new ToolTip
            {
                Content = customertooltip,            
                BorderThickness = new Thickness(0),
                HasDropShadow = false,
                Padding = new Thickness(0)
            };
            marker.Shape = img;

            img.MouseLeftButtonDown += (sender, e) =>
            {
                RemoveMarker(location);                 
            };

            var existing = this.markers.FirstOrDefault(x => x.Position == marker.Position);
            if (existing != null)
            {
                this.markers.Remove(existing);
            }
            this.markers.Add(marker);
        }

        public void AddMarkers(IEnumerable<Location> locations, object toolTip = null)
        {
            foreach (var point in locations)
            {
                AddMarker(point);
            }
        }
        private readonly List<PointLatLng> routePoints = new List<PointLatLng>();
        public void AddRoute(IEnumerable<Location> routes)
        {
            routePoints.Clear();
            foreach (var point in routes)
            {
                PointLatLng data = new PointLatLng(point.Latitude, point.Longitude);
                routePoints.Add(data);
            }
            //BitmapImage bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri("https://raw.githubusercontent.com/luxiaoxun/MapDownloader/refs/heads/master/GMap.NET.WindowsForms/Resources/red-dot.png", UriKind.Absolute);
            //bitmap.EndInit();
            //var img = new Image()
            //{
            //    Source = bitmap,
            //};
            //Line line = new Line() { StrokeThickness = 20, Stroke = System.Windows.Media.Brushes.BlueViolet };
           
         
            
            var routeObject = new GRoute(routePoints)
            {
                Tag = PolylineEncoder.EncodeCoordinates(routes),

            };
          
            //img.MouseLeftButtonDown += (sender, e) =>
            //{
            //    RemoveRoute(routes);                
            //};
            //this.routes.Clear();
            this.routes.Add(routeObject);
            routeObject.Shape.IsHitTestVisible = true;
            routeObject.Shape.MouseLeftButtonDown += (sender, e) =>
            {
                RemoveRoute(routes);
            };
        }

        public void ClearAll()
        {
            this.routes.Clear();
            this.markers.Clear();
        }

        public void ClearMarkers()
        {
            this.markers.Clear();
        }

        public void ClearRoutes()
        {
            this.routes.Clear();
        }

        public void RemoveMarker(Location location)
        {
            var target = this.markers.FirstOrDefault(x => x.Position == new PointLatLng(location.Latitude, location.Longitude));
            if (target != null)
            {
                this.markers.Remove(target);
            }
        }

        public void RemoveRoute(IEnumerable<Location> routes)
        {
            var route = this.routes.FirstOrDefault(r => r.Tag.ToString() == PolylineEncoder.EncodeCoordinates(routes));
            if (route != null)
            {
                this.routes.Remove(route);
            }
        }
    }
}
