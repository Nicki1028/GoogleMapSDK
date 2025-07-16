using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.UI.Contract.API.Models;

namespace GoogleMapSDK.Core.Overlay.RouteOverlay
{
    public class RouteOverlay : MapOverlay
    {

        private readonly List<PointLatLng> routePoints = new List<PointLatLng>();

        public RouteOverlay(string nameid)
        {
            this.Id = nameid;
        }
        public override void AddRange(IEnumerable<(double latitude, double longitude)> route)
        {
            routePoints.Clear();
            foreach (var point in route)
            {
                routePoints.Add(new PointLatLng(point.latitude, point.longitude));
            }
            var routeObject = new GMapRoute(routePoints, "MyRoute")
            {
                Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 2)
            };
            this.Routes.Clear();
            this.Routes.Add(routeObject);
            Console.WriteLine("已添加一條路徑。");
        }

        public override void Clear()
        {
            this.Routes.Clear();
            Console.WriteLine("所有路徑已清除。");
        }
        public override MapOverlay GetGMapOverlay()
        {
            return this;
        }
        public override void Add(double latitude, double longitude, PlaceInfo markerInfo)
        {
            throw new NotImplementedException();
        }
        public override void AddRange(IEnumerable<PointLatLng> points)
        {
            throw new NotImplementedException();
        }
        public override void Add(PointLatLng point, PlaceInfo markerInfo)
        {
            throw new NotImplementedException();
        }
    }
}
