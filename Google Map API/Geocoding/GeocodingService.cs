using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Maps.Common;
using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Map_API.Geocoding
{
    public class GeocodingService
    {
        private HttpRequest _HttpRequest;

        
        public GeocodingService(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
            
        }
        
        public async Task<GeocodingResponse> GetPostion(GeocodingRequest geocodingRequest)
        {
            BaseService baseService = new BaseService();
            
            string url = _HttpRequest.BaseUrl+ "geocode/json?"+baseService.ToUri(geocodingRequest) + "&key=" + GoogleSigned.SigningInstance._key;
            
            return await _HttpRequest.Get<GeocodingResponse>(url);
        }
    }
}
