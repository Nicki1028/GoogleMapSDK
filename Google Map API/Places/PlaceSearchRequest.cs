﻿using Google_Map_API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Map_API.Places
{
    public class PlaceSearchRequest:BaseRequest
    {
        [Required]
        public string input { get; set; }

        [Required]
        public string inputtype { get; set; }

        public EnumPlaceSearchtype searchtype { get; set; }
    }
}
