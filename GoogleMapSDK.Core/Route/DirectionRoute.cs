using GMap.NET;
using GoogleMapSDK.API;
using GoogleMapSDK.API.Direction;
using GoogleMapSDK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Direction.DirectionResponse;

namespace GoogleMapSDK.Core.Route
{
    internal class DirectionRoute
    {
        GoogleContext context = new GoogleContext();

       
        public async Task <DirectionModel> GetDirectionResponseAsync(string origin, string destination, List<string> waypoints = null)
        {
            DirectionModel directionModel = new DirectionModel();
            DirectionRequest directionRequest = new DirectionRequest();
            directionRequest.origin = origin;
            directionRequest.destination = destination;
            directionRequest.waypoints = waypoints;
            var result = await context.Direction.Direction(directionRequest);
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
            var result = await context.Direction.Direction(directionRequest);
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
