using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions;
using GoogleMapSDK.UI.Contract.API.StaticMaps;
using GoogleMapSDK.UI.Contract.API.StaticMaps.Models;
using HttpUtility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.StaticMaps
{
    public class StaticMap:BaseGoogleAPI, IStaticMap
    {
        public StaticMap(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public string GetStream(StaticMapRequest staticmapRequest)
        {
            BaseService baseService = new BaseService();

            string url = _httpRequest.BaseUrl + "staticmap?" + baseService.ToUri(staticmapRequest) + "&key=" + _apiConfig.apikey;

            return url;
        }
    }
}
