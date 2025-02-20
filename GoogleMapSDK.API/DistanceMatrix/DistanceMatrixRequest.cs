using GoogleMapSDK.API.Geocoding;
using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.DistanceMatrix
{
    public class DistanceMatrixRequest
    {
        private HttpRequest _HttpRequest;

        public DistanceMatrixRequest(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }

        public async Task<DistanceMatrixResponse> GetDistance(string des, string ori, string key, string language)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("destinations", des);
            parameters.Add("origins", ori);
            parameters.Add("key", key);
            parameters.Add("language", language);

            return await _HttpRequest.Get<DistanceMatrixResponse>($"distancematrix/json", parameters);
        }
    }
}
