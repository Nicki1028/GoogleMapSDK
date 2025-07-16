
using System.ComponentModel.DataAnnotations;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.API.Attributes;

namespace GoogleMapSDK.UI.Contract.API.Geocodings.Models
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
