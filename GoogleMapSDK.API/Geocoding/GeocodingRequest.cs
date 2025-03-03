using GoogleMapSDK.API.Places;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using GoogleMapSDK.API.Attributes;

namespace GoogleMapSDK.API.Geocoding
{
    public class GeocodingRequest : BaseRequest
    {

        [@Optional]
        public string address { get; set; }
        public string place_id { get; set; }
       
        [Required]
        [Classtostr("latlng", ",")]
        public Location Location { get; set; }
       
    }
}
