using GMap.NET;
using GoogleMapSDK.API.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Models
{
    internal class DirectionModel
    {
        public PointLatLng origin;

        public PointLatLng destination;

        public List<(double,double)> waypoints;
    }
}
