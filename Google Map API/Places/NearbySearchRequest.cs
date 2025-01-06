using Google_Map_API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Map_API.Places
{
    public class NearbySearchRequest:BaseRequest
    {
        [Required]
        [Google_Map_API.Attributes.Classtostr("location", ",")]
        public Location location { get; set; }

        public int radius { get; set; }

        
    }
}
