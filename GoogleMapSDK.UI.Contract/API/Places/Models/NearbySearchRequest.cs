
using GoogleMapSDK.UI.Contract.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API.Places
{
    public class NearbySearchRequest:BaseRequest
    {
        [Required]
        [Attributes.Classtostr("location", ",")]
        public Location location { get; set; }

        public int radius { get; set; }

        
    }
}
