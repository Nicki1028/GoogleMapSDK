using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places
{
    public class AutoCompleteServise
    {
        private HttpRequest _HttpRequest;

        public AutoCompleteServise(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }

        public async Task<AutoCompleteResponse> AutoCompleteSearch(AutoCompleteRequest autoCompleteRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?" + baseService.ToUri(autoCompleteRequest) + "&key=" + GoogleSigned.SigningInstance._key;

            return await _HttpRequest.Get<AutoCompleteResponse>(url);
        }
    }
}
