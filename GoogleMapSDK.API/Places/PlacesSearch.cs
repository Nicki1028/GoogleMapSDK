using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places;
using HttpUtility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places
{
    public class PlacesSearch:BaseGoogleAPI, IPlaceSearch
    {
        public PlacesSearch(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public async Task<PlaceSearchResponse> PlaceSearch(PlaceSearchRequest placeSearchRequest)
        {
            BaseService baseService = new BaseService();
           
            string url = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?" + baseService.ToUri(placeSearchRequest) + "&fields="+baseService.PlaceSearchtype(placeSearchRequest.searchtype)+"&key=" + _apiConfig.apikey;
                
            return await _httpRequest.Get<PlaceSearchResponse>(url);
        }
    }
}
