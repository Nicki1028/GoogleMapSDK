using GMap.NET;
using GoogleMapSDK.Core.Models;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Route
{
    internal class DirectionRoute
    {
        private IGoogleContext _googlecontext;

        public DirectionRoute(IGoogleContext googleContext)
        {
            this._googlecontext = googleContext;
        }
        public async Task <DirectionModel> GetDirectionResponseAsync(string origin, string destination, List<string> waypoints = null)
        {
            DirectionModel directionModel = new DirectionModel();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = origin;
            directionRequest.destination = destination;
            directionRequest.waypoints = waypoints;
            var result = await _googlecontext.Direction.GetDirection(directionRequest);
            directionModel.origin = new PointLatLng(result.routes[0].legs[0].start_location.lat, result.routes[0].legs[0].start_location.lng);
            directionModel.destination = new PointLatLng(result.routes[0].legs[0].end_location.lat, result.routes[0].legs[0].end_location.lng);
            foreach (var item in result.routes)
            {
                directionModel.waypoints = item.overview_polyline.polylinePoints.Select(x => (x.Latitude, x.Longitude)).ToList();
            }
            return directionModel;
        }

        public async Task<DirectionModel> GetDirectionResponseAsync(PointLatLng origin, PointLatLng destination, List<string> waypoints = null)
        {
            DirectionModel directionModel = new DirectionModel();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = $"{origin.Lat},{origin.Lng}"; 
            directionRequest.destination = $"{destination.Lat},{destination.Lng}"; 
            directionRequest.waypoints = waypoints;
            var result = await _googlecontext.Direction.GetDirection(directionRequest);
            directionModel.origin = new PointLatLng(result.routes[0].legs[0].start_location.lat, result.routes[0].legs[0].start_location.lng);
            directionModel.destination = new PointLatLng(result.routes[0].legs[0].end_location.lat, result.routes[0].legs[0].end_location.lng);
            foreach (var item in result.routes)
            {
                directionModel.waypoints = item.overview_polyline.polylinePoints.Select(x => (x.Latitude, x.Longitude)).ToList();
            }
            return directionModel;
        }
    }
}
