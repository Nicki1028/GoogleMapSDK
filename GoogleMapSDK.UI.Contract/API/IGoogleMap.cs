using GMap.NET;
using GoogleMapSDK.UI.Contract.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapSDK.UI.Contract.API
{
    public interface IGoogleMap
    {
        void SetCenter(double latitude, double longitude);

        void SetZoomLevel(int zoomLevel);

        void AddMarker(PointLatLng location);

        void AddMarker(PointLatLng location, string overlayId);

        void AddMarker(PointLatLng location, string overlayId, PlaceInfo markerInfo);

        void RemoveOverlay(string overlayid);
    }
}
