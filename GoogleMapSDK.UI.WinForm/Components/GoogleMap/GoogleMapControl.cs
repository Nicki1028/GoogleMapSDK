using GMap.NET;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GoogleMapSDK.UI.Contract.API.Models;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using System.Linq;
using GMap.NET.WindowsForms;

namespace GoogleMapSDK.UI.WinForm.Components.GoogleMap
{
    public partial class GoogleMapControl : UserControl, IGoogleMap
    {
        IOverlayService _overlayService;
        public GoogleMapControl(IOverlayService overlayService)
        {
            InitializeComponent();
            _overlayService = overlayService;
            this.ParentChanged += GoogleMapControl_ParentChanged;
            this.MapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            this.SetCenter(24.9682806, 121.1928889);
            this.SetZoomLevel(16);
           
        }

        private void GoogleMapControl_ParentChanged(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height;
        }

        private void TryAddOverlay(IOverlay overlay)
        {
            if (!this.MapControl.Overlays.Any(x => x == (GMapOverlay)overlay))
            {
                this.MapControl.Overlays.Add((GMapOverlay)overlay);
            }
        }
        public void AddMarker(Location location, string overlayId = "defaultOverlay", object tooltip = null)
        {
            
            IOverlay overlay = _overlayService.AddMarker(location, overlayId, tooltip);
            TryAddOverlay(overlay);
        }

        public void AddMarkers(IEnumerable<Location> locations, string overlayId = "defaultOverlay", object toolTip = null)
        {
            TryAddOverlay(_overlayService.AddMarkers(locations, overlayId, toolTip));
        }

        public void AddRoute(IEnumerable<Location> routePoints, string overlayId = "defaultOverlay")
        {
            TryAddOverlay(_overlayService.AddRoute(routePoints, overlayId));
        }

        public void ClearAll(string overlayId = "defaultOverlay")
        {
            _overlayService.ClearAll(overlayId);
        }

        public void ClearMarkers(string overlayId = "defaultOverlay")
        {
            _overlayService.ClearMarkers(overlayId);
        }

        public void ClearRoutes(string overlayId = "defaultOverlay")
        {
            _overlayService.ClearRoutes(overlayId);
        }

        public void RemoveMarker(Location location)
        {
            _overlayService.RemoveMarker(location);
        }

        public void RemoveMarker(Location location, string overlayId = "defaultOverlay")
        {
            _overlayService.RemoveMarker(location, overlayId);
        }

        public void RemoveOverlay(string overlayid = "defaultOverlay")
        {
            _overlayService.RemoveOverlay(overlayid);
        }

        public void RemoveRoute(IEnumerable<Location> routePoints)
        {
            _overlayService.RemoveRoute(routePoints);
        }

        public void RemoveRoute(IEnumerable<Location> routePoints, string overlayId = "defaultOverlay")
        {
            _overlayService.RemoveRoute(routePoints, overlayId);
        }

        public void SetCenter(double latitude, double longitude)
        {
            MapControl.Position = new PointLatLng(latitude, longitude);
            Console.WriteLine($"地圖中心已設定為：({latitude}, {longitude})");
        }

        public void SetZoomLevel(int zoomLevel)
        {
            MapControl.MinZoom = 5;
            MapControl.MaxZoom = 20;
            MapControl.Zoom = zoomLevel;
            Console.WriteLine($"地圖縮放層級已設定為：{zoomLevel}");
        }
    }
}
