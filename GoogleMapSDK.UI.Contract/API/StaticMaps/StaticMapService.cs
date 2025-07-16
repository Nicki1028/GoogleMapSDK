using GoogleMapSDK.API.Geocoding;
using HttpUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.StaticMaps
{
    public class StaticMapService
    {
        private HttpRequest _HttpRequest;
        public StaticMapService(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }
        public string GetStream(StaticMapRequest staticmapRequest)
        {
            BaseService baseService = new BaseService();

            string url = _HttpRequest.BaseUrl + "staticmap?" + baseService.ToUri(staticmapRequest) + "&key=" + GoogleSigned.SigningInstance._key;

            return url;
        }
    }
}
