using GoogleMapSDK.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpUtility;
using GoogleMapSDK.UI.Contract.API.Place_Detail;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.API;
using Microsoft.Extensions.Options;

namespace GoogleMapSDK.API.PlaceDetails
{
    public class PlaceDetail:BaseGoogleAPI, IPlaceDetail
    {
        public PlaceDetail(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public async Task<PlacesDetailResponse> GetPlaceDetail(PlacesDetailRequest placesdetailRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/details/json?" + baseService.ToUri(placesdetailRequest) + "&key=" + _apiConfig.apikey;

            return await _httpRequest.Get<PlacesDetailResponse>(url);
        }
    }
}
