using GMap.NET;
using GoogleMapSDK.Core.Models;
using GoogleMapSDK.Core.Overlay.RouteOverlay;
using GoogleMapSDK.UI.Contract.API;
using System.Collections.Generic;
namespace GoogleMapSDK.Core.Route
{
    public class RouteContext
    {
        private IGoogleContext _googleContext;
        MapControl _mapControl;
        RouteOverlay route = new RouteOverlay("route");
        DirectionRoute _directionRoute;
        public RouteContext(MapControl mapControl, IGoogleContext googleContext)
        {
            this._mapControl = mapControl;
            this._googleContext = googleContext;
            _directionRoute = new DirectionRoute(_googleContext);
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
            var data = await _directionRoute.GetDirectionResponseAsync(origin, destination, waypoints);
            LoadRoutes(data);
        }

        public async void PlanRoutes(PointLatLng origin, PointLatLng destination, List<string> waypoints)
        {
            route.Clear();
            var data = await _directionRoute.GetDirectionResponseAsync(origin, destination, waypoints);
            LoadRoutes(data);
        }

        public async void PlanRoutes(PointLatLng origin, PointLatLng destination)
        {
            route.Clear();
            var data = await _directionRoute.GetDirectionResponseAsync(origin, destination);
            LoadRoutes(data);
        }
        public async void PlanRoutes(string origin, string destination)
        {
            route.Clear();
            var data = await _directionRoute.GetDirectionResponseAsync(origin, destination);
            LoadRoutes(data);
        }

    }
}
