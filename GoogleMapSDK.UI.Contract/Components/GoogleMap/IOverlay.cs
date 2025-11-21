
using GoogleMapSDK.UI.Contract.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Components.GoogleMap
{
    public interface IOverlay
    {

        void ClearAll();
        void ClearMarkers();
        void ClearRoutes();
        void RemoveMarker(Location location);
        void RemoveRoute(IEnumerable<Location> routes);
        void AddMarker(Location location, object toolTip = null);
        void AddMarkers(IEnumerable<Location> locations, object toolTip = null);
        void AddRoute(IEnumerable<Location> routes);
    }

}
