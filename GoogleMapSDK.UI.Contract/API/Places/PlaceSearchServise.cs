using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places
{
    public class PlaceSearchServise
    {
        private HttpRequest _HttpRequest;

        public PlaceSearchServise(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }

        public async Task<PlaceSearchResponse> PlaceSearch(PlaceSearchRequest placeSearchRequest)
        {
            BaseService baseService = new BaseService();
           
            string url = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?" + baseService.ToUri(placeSearchRequest) + "&fields="+baseService.PlaceSearchtype(placeSearchRequest.searchtype)+"&key=" + GoogleSigned.SigningInstance._key;
                
            return await _HttpRequest.Get<PlaceSearchResponse>(url);
        }
    }
}
