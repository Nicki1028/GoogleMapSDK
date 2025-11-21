using GMap.NET;
using GoogleMapSDK.UI.Contract.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapSDK.UI.Contract.Components.GoogleMap
{
    public interface IGoogleMap
    {
        void SetCenter(double latitude, double longitude);

        void SetZoomLevel(int zoomLevel);       

        void AddMarker(Location location, string overlayId = "defaultoverlay", object tooltip = null);
        
        void AddMarkers(IEnumerable<Location> locations, string overlayId = "defaultoverlay", object toolTip = null);
        
        void AddRoute(IEnumerable<Location> routePoints, string overlayId = "defaultoverlay");       

        void RemoveMarker(Location location, string overlayId = "defaultoverlay");

        void RemoveRoute(IEnumerable<Location> routePoints, string overlayId = "defaultoverlay");
        
        void RemoveOverlay(string overlayId = "defaultoverlay");
        
        void ClearAll(string overlayId = "defaultoverlay");
        
        void ClearMarkers(string overlayId = "defaultoverlay");
       
        void ClearRoutes(string overlayId = "defaultoverlay");
    }
}
