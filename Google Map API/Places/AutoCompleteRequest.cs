using Google_Map_API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Map_API.Places
{
    public class AutoCompleteRequest:BaseRequest
    {
        [Required]
        public string input { get; set; }

        public EnumPlaceType[] types { get; set; }
    }
}   
