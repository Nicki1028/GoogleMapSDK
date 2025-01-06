using GoogleApi.Entities;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using HttpUtility;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Google_Map_API.Geocoding
{
    public class GeocodingRequest : BaseRequest
    {
       
        [Required]
        public string address { get; set; }
        public string place_id { get; set; } 
       
    }
}
