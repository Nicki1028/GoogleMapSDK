using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Overlay
{
    public abstract class MapOverlay : GMapOverlay
    {

        public abstract void Add(double latitude, double longitude, PlaceInfo markerInfo = null);
        public abstract void Add(PointLatLng point, PlaceInfo markerInfo = null);
        public abstract void AddRange(IEnumerable<(double latitude, double longitude)> points);
        public abstract void AddRange(IEnumerable<PointLatLng> points);
        public abstract void Clear();
        public abstract MapOverlay GetGMapOverlay();

    }
}
