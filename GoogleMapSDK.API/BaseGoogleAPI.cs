using HttpUtility;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
{
    public class BaseGoogleAPI
    {
        protected HttpRequest _httpRequest;
        protected GoogleAPIConfigure _apiConfig;
        public BaseGoogleAPI(HttpRequest httpRequest, GoogleAPIConfigure apiConfig)
        {
            _httpRequest = httpRequest;
            this._apiConfig = apiConfig;
        }
    }
}
