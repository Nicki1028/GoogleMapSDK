using GoogleMapSDK.API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places
{
    public class TextSearchRequest:BaseRequest
    {
        [Required]
        public string query { get; set; }

        [Required]
        public int? radius { get; set; }

        public int? minprice { get; set; }

        public int? maxprice { get; set; }

        public bool? openNow { get; set; }

        public EnumPlaceType[] type { get; set; }
    }
}
