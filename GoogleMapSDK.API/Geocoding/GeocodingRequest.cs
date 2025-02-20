using System.ComponentModel.DataAnnotations;


namespace GoogleMapSDK.API.Geocoding
{
    public class GeocodingRequest : BaseRequest
    {
       
        [Required]
        public string address { get; set; }
        public string place_id { get; set; } 
       
    }
}
