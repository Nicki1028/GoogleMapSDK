using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Models
{
    public class NearbySearchModel
    {
        public PointLatLng NearbySearchPoint { get; set; } 

        public string NearbySearchName { get; set;}
    }
}
