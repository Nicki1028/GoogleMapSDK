using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmap
{
    public abstract class MapOverlay:GMapOverlay
    {
       
        public abstract void Add(double latitude, double longitude, MarkerInfo markerInfo = null);
        public abstract void Add(PointLatLng point, MarkerInfo markerInfo = null);
        
        public abstract void AddRange(IEnumerable<(double latitude, double longitude)> points);
        public abstract void AddRange(IEnumerable<PointLatLng> points);
       
        public abstract void Clear();

        
        public abstract MapOverlay GetGMapOverlay();




    }
}
