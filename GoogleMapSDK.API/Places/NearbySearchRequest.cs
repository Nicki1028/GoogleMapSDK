using GoogleMapSDK.API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places
{
    public class NearbySearchRequest:BaseRequest
    {
        [Required]
        [GoogleMapSDK.API.Attributes.Classtostr("location", ",")]
        public Location location { get; set; }

        public int radius { get; set; }

        
    }
}
