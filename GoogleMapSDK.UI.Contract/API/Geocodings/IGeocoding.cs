using GoogleMapSDK.UI.Contract.API.Geocodings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.Geocodings
{
    public interface IGeocoding
    {
        Task<GeocodingResponse> GetPostion(GeocodingRequest geocodingRequest);
    }
}
