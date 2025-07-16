using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places;
using HttpUtility;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;


namespace GoogleMapSDK.API.Places
{
    public class NearbyAndText: BaseGoogleAPI, INearbyAndText
    {
        public NearbyAndText(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public async Task<NearbyAndTextResponse> TextSearch(TextSearchRequest textSearchRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?" + baseService.ToUri(textSearchRequest) + "&key=" + _apiConfig.apikey;

            return await _httpRequest.Get<NearbyAndTextResponse>(url);
        }

        public async Task<NearbyAndTextResponse> NearbySearch(NearbySearchRequest nearbySearchRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?" + baseService.ToUri(nearbySearchRequest) + "&key=" + _apiConfig.apikey;
            
            return await _httpRequest.Get<NearbyAndTextResponse>(url);
        }
    }
}
