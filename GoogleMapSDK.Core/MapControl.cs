using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GoogleMapSDK.Core.Overlay;
using GoogleMapSDK.Core.Overlay.MarkerOverlay;
using GoogleMapSDK.Core.Overlay.RouteOverlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.Core.Route;
using GoogleMapSDK.Core.Marker;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.API;

namespace GoogleMapSDK.Core
{
    public class MapControl : GMapControl, IGoogleMap
    {
      
        GMapOverlay mapoverlay = new GMapOverlay("mapoverlay");
        public RouteContext _routeContext;
        public MarkerContext _MarkerContext;
        private IGoogleContext _googleContext;
        public MapControl(IGoogleContext googleContext)
        {
            _googleContext = googleContext;
            this.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            this.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            this.DragButton = MouseButtons.Left;
            this.Position = new PointLatLng(24.93, 121.21);
            this.MinZoom = 4;                                                                            // whole world zoom
            this.MaxZoom = 20;
            this.Zoom = 15;
            this.Overlays.Add(mapoverlay);
            _routeContext = new RouteContext(this, _googleContext);
            _MarkerContext = new MarkerContext(this, _googleContext);
            
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
                this.AddOverlay(mapOverlay);
            }

        }

        public void AddMarker(PointLatLng location, string overlayId, PlaceInfo markerInfo)
        {
            if (OverlayPairs.ContainsKey(overlayId))
            {
                OverlayPairs[overlayId].Add(location, markerInfo);
            }
            else
            {
                MapOverlay mapOverlay = new MarkerOverlay(overlayId);
                mapOverlay.Add(location, markerInfo);
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
