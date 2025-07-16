using GoogleMapSDK.UI.Contract.API.DistanceMatrixs;
using HttpUtility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.DistanceMatrixs
{
    public class DistanceMatrix:BaseGoogleAPI, IDistanceMatrix
    {
        public DistanceMatrix(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        async Task<DistanceMatrixResponse> IDistanceMatrix.GetDistance(string des, string ori, string key, string language)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("destinations", des);
            parameters.Add("origins", ori);
            parameters.Add("key", key);
            parameters.Add("language", language);

            return await _httpRequest.Get<DistanceMatrixResponse>($"distancematrix/json", parameters);
        }
    }
}
