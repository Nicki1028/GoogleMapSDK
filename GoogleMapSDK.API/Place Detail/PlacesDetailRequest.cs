﻿using GoogleMapSDK.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places_Detail
{
    public class PlacesDetailRequest:BaseRequest
    {
        [Required]
        public string place_id { get; set; }

        public string[] fileds { get; set; }

    }
}
