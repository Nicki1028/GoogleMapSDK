using GoogleMapSDK.API;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Geocodings;
using GoogleMapSDK.UI.Contract.API.Geocodings.Models;
using HttpUtility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Geocodings
{
    public class Geocoding: BaseGoogleAPI, IGeocoding
    {
        public Geocoding(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public async Task<GeocodingResponse> GetPostion(GeocodingRequest geocodingRequest)
        {
            BaseService baseService = new BaseService();

            string url = _httpRequest.BaseUrl + "geocode/json?" + baseService.ToUri(geocodingRequest) + "&key=" + _apiConfig.apikey;

            return await _httpRequest.Get<GeocodingResponse>(url);
        }
    }
}
