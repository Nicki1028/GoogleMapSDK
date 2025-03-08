using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;

namespace GoogleMapSDK.Core
{
    public class PlaceInfo
    {
        public string Name { get; set; }
        public string TextboxId { get; set; }
        public string Address { get; set; }
        public string PlaceId { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }

    }
}
