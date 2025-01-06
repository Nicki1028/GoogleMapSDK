using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Google_Map_API.Place_Photo
{
    public class PlacePhotoRequest
    {
        [Required]
        public string photo_reference { get; set; }

        [Required]
        public int maxheight { get; set; }

        [Google_Map_API.Attributes.Optional]
        public int? maxwidth { get; set; }

    }
}
