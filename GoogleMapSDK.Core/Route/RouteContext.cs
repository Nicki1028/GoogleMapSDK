using GMap.NET;
using GoogleMapSDK.API;
using GoogleMapSDK.API.Direction;
using GoogleMapSDK.Core.Models;
using GoogleMapSDK.Core.Overlay.RouteOverlay;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Direction.DirectionResponse;

namespace GoogleMapSDK.Core.Route
{
    public class RouteContext
    {
        MapControl _mapControl;
        RouteOverlay route = new RouteOverlay("route");
        DirectionRoute directionRoute = new DirectionRoute();
        public RouteContext(MapControl mapControl)
        {
            this._mapControl = mapControl;
        }

        private void LoadRoutes(DirectionModel data)
        {
            this._mapControl.AddMarker(data.origin, "mapoverlay");
            this._mapControl.AddMarker(data.destination, "mapoverlay");
            route.AddRange(data.waypoints);
            this._mapControl.AddOverlay(route);
            this._mapControl.SetCenter(data.origin.Lat, data.origin.Lng);
        }
        public async void PlanRoutes(string origin, string destination, List<string> waypoints)
        {
            route.Clear();
            var data = await directionRoute.GetDirectionResponseAsync(origin, destination, waypoints);
            LoadRoutes(data);
        }

        public async void PlanRoutes(PointLatLng origin, PointLatLng destination, List<string> waypoints)
        {
            route.Clear();
            var data = await directionRoute.GetDirectionResponseAsync(origin, destination, waypoints);
            LoadRoutes(data);
        }

        public async void PlanRoutes(PointLatLng origin, PointLatLng destination)
        {
            route.Clear();
            var data = await directionRoute.GetDirectionResponseAsync(origin, destination);
            LoadRoutes(data);
        }
        public async void PlanRoutes(string origin, string destination)
        {
            route.Clear();
            var data = await directionRoute.GetDirectionResponseAsync(origin, destination);
            LoadRoutes(data);
        }

    }
}
