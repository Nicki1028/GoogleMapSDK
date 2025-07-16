using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.UI.Contract.API.Attributes;

namespace GoogleMapSDK.UI.Contract.API.Place_Photo
{
    public class PlacePhotoRequest
    {
        [Required]
        public string photo_reference { get; set; }

        [Required]
        public int maxheight { get; set; }

        [@Optional]
        public int? maxwidth { get; set; }

    }
}
