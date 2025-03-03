using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core
{

        public class LocationMarker
        {
            public string Name { get; }
            public GMapMarker Marker { get; }

            public LocationMarker(string name, GMapMarker marker)
            {
                Name = name;
                Marker = marker;
            }
        }
    
}
