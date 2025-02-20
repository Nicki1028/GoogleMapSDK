using GoogleMapSDK.API.Places;
using HttpUtility;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Direction
{
    public class DirectionService
    {
        private HttpRequest _HttpRequest;
        public DirectionService(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }

        public async Task<DirectionResponse> Direction(DirectionRequest directionRequest)
        {
            BaseService baseService = new BaseService();
            string url = "https://maps.googleapis.com/maps/api/directions/json?" + baseService.ToUri(directionRequest) + "&waypoints=" + WaypointstoUrl(directionRequest) + "&key=" + GoogleSigned.SigningInstance._key;

            DirectionResponse response = await _HttpRequest.Get<DirectionResponse>(url);
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
