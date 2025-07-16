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
    public class AutoComplete:BaseGoogleAPI, IAutoComplete
    {
        public AutoComplete(HttpRequest httpRequest, GoogleAPIConfigure apiConfig) : base(httpRequest, apiConfig)
        {
        }

        public async Task<AutoCompleteResponse> AutoCompleteSearch(AutoCompleteRequest autoCompleteRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?" + baseService.ToUri(autoCompleteRequest) + "&key=" + _apiConfig.apikey;

            return await _httpRequest.Get<AutoCompleteResponse>(url);
        }
    }
}
