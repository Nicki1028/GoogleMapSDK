using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForm.Components.GoogleMap
{
    public class MapOverlay : GMapOverlay, IOverlay
    {
        public void AddMarker(Location location, object toolTip = null)
        {
            PointLatLng point = new PointLatLng(location.Latitude, location.Longitude);
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            if (toolTip != null)
            {
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTip = (GMapToolTip)toolTip;
            }   
            var existing = this.Markers.FirstOrDefault(x => x.Position == marker.Position);
            if (existing != null)
            {
                this.Markers.Remove(existing);
            }            
            this.Markers.Add(marker);
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
            var routeObject = new GMapRoute(routePoints, "MyRoute")
            {
                Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 3)
            };
            this.Routes.Clear();
            this.Routes.Add(routeObject);            
        }   
        public void RemoveMarker(Location location)
        {
            var target = this.Markers.FirstOrDefault(x => x.Position == new PointLatLng(location.Latitude, location.Longitude));
            if (target != null)
            {
                this.Markers.Remove(target);
            }
        }

        public void RemoveRoute(IEnumerable<Location> routes)
        {
            var route = this.Routes.FirstOrDefault(r => r.Points == routes);
            if (route != null)
            {
                this.Routes.Remove(route);
            }
        }

        public void ClearAll()
        {
            this.Markers.Clear();
            this.Routes.Clear();
            Console.WriteLine("所有地標和路徑已清除。");
        }

        public void ClearMarkers()
        {
            this.Markers.Clear();
            Console.WriteLine("所有地標已清除。");
        }

        public void ClearRoutes()
        {
            this.Routes.Clear();
            Console.WriteLine("所有路徑已清除。");
        }
    }
}
