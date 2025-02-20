using GoogleMapSDK.API.Places_Detail;
using GoogleMapSDK.API.Geocoding;
using GoogleMapSDK.API.StaticMaps;
using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace GoogleMapSDK.API.Places_Detail
{
    public class PlacesDetailService
    {
        private HttpRequest _HttpRequest;

        public PlacesDetailService(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }

        public async Task<PlacesDetailResponse> GetPlaceDetail(PlacesDetailRequest placesdetailRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/details/json?" + baseService.ToUri(placesdetailRequest) + "&key=" + GoogleSigned.SigningInstance._key;

            return await _HttpRequest.Get<PlacesDetailResponse>(url); 
        }
    }
}
