using GoogleMapSDK.UI.Contract.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Components.GoogleMap
{
    public interface IOverlayService
    {
        IOverlay AddMarker(Location location, string overlayId = "defalutOverlay", object toolTip = null);
        IOverlay AddMarkers(IEnumerable<Location> locations, string overlayId = "defalutOverlay", object toolTip = null);
        IOverlay AddRoute(IEnumerable<Location> routes, string overlayId = "defalutOverlay");
        void ClearAll(string overlayId);
        void ClearMarkers(string overlayId);
        void ClearRoutes(string overlayId);
        void RemoveMarker(Location location, string overlayId = "defalutOverlay");
        void RemoveRoute(IEnumerable<Location> routes, string overlayId = "defalutOverlay");
        bool RemoveOverlay(string overlayId);
    }
}
