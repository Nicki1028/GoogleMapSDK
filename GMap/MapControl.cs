using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmap
{
    public class MapControl :GMapControl
    {
                
        public MapControl() 
        {
            this.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;          
            this.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;                  
        }

        public Dictionary<string, MapOverlay> OverlayPairs = new Dictionary<string, MapOverlay>();

        public void SetCenter(double latitude, double longitude)
        {
            this.Position = new PointLatLng(latitude, longitude);
            Console.WriteLine($"地圖中心已設定為：({latitude}, {longitude})");
        }

      
        public void SetZoomLevel(int zoomLevel)
        {
            this.MinZoom = 5;
            this.MaxZoom = 20;
            this.Zoom = zoomLevel;
            Console.WriteLine($"地圖縮放層級已設定為：{zoomLevel}");
        }


        public void AddMarker(PointLatLng location)
        {
            if (OverlayPairs.ContainsKey("default"))
            {
                OverlayPairs["default"].Add(location);
            }
            else
            {
                MapOverlay defaultoverlay = new MarkerOverlay("default");
                defaultoverlay.Add(location);
                OverlayPairs["default"] = defaultoverlay;
                this.AddOverlay(defaultoverlay);
            }
        }
        

        public void AddMarker(PointLatLng location, string overlayId)
        {
            if (OverlayPairs.ContainsKey(overlayId))
            {
                OverlayPairs[overlayId].Add(location);
            }
            else
            {
                MapOverlay mapOverlay = new MarkerOverlay(overlayId);
                mapOverlay.Add(location);
                OverlayPairs[overlayId] = mapOverlay;
                this.AddOverlay(mapOverlay);
            }          
           
        }
       
        public void AddMarker(PointLatLng location, string overlayId, MarkerInfo markerInfo)
        {
            if (OverlayPairs.ContainsKey(overlayId))
            {
                OverlayPairs[overlayId].Add(location, markerInfo);
            }
            else
            {
                MapOverlay mapOverlay = new MarkerOverlay(overlayId);
                mapOverlay.Add(location, markerInfo);
                OverlayPairs[overlayId] = mapOverlay;
                this.AddOverlay(mapOverlay);
            }

        }

        public void AddOverlay(MapOverlay overlay)
        {
            if (overlay != null)
            {
                this.Overlays.Add(overlay);
                OverlayPairs.Add(overlay.Id, overlay);
                Console.WriteLine("已新增一個疊加層");
            }
        }

      
        public void RemoveOverlay(string overlayid)
        {
            if (OverlayPairs.ContainsKey(overlayid))
            {
                OverlayPairs.Remove(overlayid);
                this.Overlays.Remove(OverlayPairs[overlayid]);
            }
        }

        //public void CreateMarkerorRoute(EnumPointType pointType, PointLatLng point)
        //{
        //    switch (pointType)
        //    {
        //        case EnumPointType.Marker:
        //            GMarkerGoogle gMarker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
        //            break;
        //        case EnumPointType.Route:
        //            GMapRoute mapRoute = new GMapRoute("route");
        //            mapRoute.Points.Add(point);
        //            break;


        //    }
          
        //}    

    }
}
