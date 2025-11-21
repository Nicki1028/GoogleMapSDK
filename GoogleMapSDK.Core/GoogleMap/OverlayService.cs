using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapSDK.Core.GoogleMap
{
    public class OverlayService : IOverlayService
    {
        public Dictionary<string, IOverlay> overlays = new Dictionary<string, IOverlay>();
        IOverlay _overlay;

        public OverlayService(IOverlay overlay)
        {
            _overlay = overlay;
        }

        public IOverlay AddMarker(UI.Contract.API.Models.Location location, string overlayId, object toolTip = null)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.AddMarker(location, toolTip);
                return overlay;
            }
            else
            {
                overlays[overlayId] = _overlay;
                _overlay.AddMarker(location, toolTip);
                return _overlay;
            }
        }

        public IOverlay AddMarkers(IEnumerable<UI.Contract.API.Models.Location> locations, string overlayId, object toolTip = null)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.AddMarkers(locations, toolTip);
                return overlay;
            }
            else
            {
                overlays[overlayId] = _overlay;
                _overlay.AddMarkers(locations, toolTip);
                return _overlay;
            }
        }

        public IOverlay AddRoute(IEnumerable<UI.Contract.API.Models.Location> routes, string overlayId)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.AddRoute(routes);
                return overlay;
            }
            else
            {
                overlays[overlayId] = _overlay;
                _overlay.AddRoute(routes);
                return _overlay;
            }
        }

        public void ClearAll(string overlayId)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.ClearAll();
            }           
        }

        public void ClearMarkers(string overlayId)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.ClearMarkers();
            }
        }

        public void ClearRoutes(string overlayId)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.ClearRoutes();
            }
        }

        public void RemoveMarker(UI.Contract.API.Models.Location location, string overlayId)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.RemoveMarker(location);
            }
        }

        public bool RemoveOverlay(string overlayId)
        {
          
            if (overlays.ContainsKey(overlayId))
            {              
                overlays.Remove(overlayId);
                return true;
            }
            return false; 
            
        }

        public void RemoveRoute(IEnumerable<UI.Contract.API.Models.Location> routes, string overlayId)
        {
            if (overlays.TryGetValue(overlayId, out IOverlay overlay))
            {
                overlay.RemoveRoute(routes);
            }
        }
    }
}
