using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions;
using GoogleMapSDK.UI.Contract.API.Directions.Models;
using GoogleMapSDK.UI.Contract.API.Models;
using HttpUtility;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Directions
{
    public class Direction:BaseGoogleAPI, IDirection
    {
        public Direction(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public async Task<DirectionResponse> GetDirection(DirectionRequest directionRequest)
        {
            BaseService baseService = new BaseService();
            string url = "https://maps.googleapis.com/maps/api/directions/json?" + baseService.ToUri(directionRequest) + "&waypoints=" + WaypointstoUrl(directionRequest) + "&key=" + _apiConfig.apikey;

            DirectionResponse response = await _httpRequest.Get<DirectionResponse>(url);
            foreach (var route in response.routes)
            {
                route.overview_polyline.polylinePoints = (List<Location>)PolylineEncoder.Decode(route.overview_polyline.points);
            }
            return response;
        }


        public string WaypointstoUrl(DirectionRequest directionRequest)
        {
            if (directionRequest.waypoints == null || directionRequest.waypoints.Count == 0) return null;

            StringBuilder sb = new StringBuilder();
            if (directionRequest.optimize == true) sb.Append("optimize:true");

            foreach (string waypoint in directionRequest.waypoints)
            {
                if (sb.Length > 0) sb.Append("|");
                sb.Append(waypoint.ToString());
            }
            return sb.ToString();
        }
    }
}
