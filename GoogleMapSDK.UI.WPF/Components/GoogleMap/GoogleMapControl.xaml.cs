using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GoogleMapSDK.UI.WPF.Components.GoogleMap
{
    /// <summary>
    /// GoogleMapControl.xaml 的互動邏輯
    /// </summary>
    public partial class GoogleMapControl : UserControl, IGoogleMap
    {
        private GMapControl gMapControl;

        private IOverlayService _overlayService;

        private List<IOverlay> overlays = new List<IOverlay>();
        public GoogleMapControl(IOverlayService overlayService)
        {
            InitializeComponent();
            this.gMapControl = new GMapControl();
            this.gMapControl.VerticalAlignment = VerticalAlignment.Stretch;
            this.gMapControl.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.gMapControl.MapProvider = GoogleMapProvider.Instance;
            this.gMapControl.CanDragMap = true;
            Grid.SetRow(gMapControl, 1);
            mapContainer.Children.Add(gMapControl);
            this._overlayService = overlayService;
            this.SetCenter(24.9682806, 121.1928889);
            this.SetZoomLevel(16);

        }


        public void SetCenter(double latitude, double longitude)
        {
            gMapControl.Position = new PointLatLng(latitude, longitude);
            Console.WriteLine($"地圖中心已設定為：({latitude}, {longitude})");
        }

        public void SetZoomLevel(int zoomLevel)
        {
            gMapControl.MinZoom = 5;
            gMapControl.MaxZoom = 20;
            gMapControl.Zoom = zoomLevel;
            Console.WriteLine($"地圖縮放層級已設定為：{zoomLevel}");
        }

        private void TryAddOverlay(IOverlay overlay)
        {
            if (!overlays.Any(x => x == overlay))
            {
                MapOverlay mapOverlay = (MapOverlay)overlay;
                this.gMapControl.Markers.Add(mapOverlay.markers.First());
                mapOverlay.markers.CollectionChanged += ElementChanged;
                mapOverlay.routes.CollectionChanged += ElementChanged;
                overlays.Add(mapOverlay);
            }
        }

        private void ElementChanged(object sender, NotifyCollectionChangedEventArgs e)
        {


            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (GMapMarker item in e.NewItems)
                {
                    this.gMapControl.Markers.Add(item);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (GMapMarker item in e.OldItems)
                {
                    this.gMapControl.Markers.Remove(item);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                if (sender is ObservableCollection<GMapMarker>)
                {
                    var markers = this.gMapControl.Markers.OfType<GMapMarker>().Where(x=>x.GetType()!= typeof(GRoute)).ToList();
                    foreach (GMapMarker item in markers)
                    {
                        this.gMapControl.Markers.Remove(item);
                    }
                }
                else if (sender is ObservableCollection<GRoute>)
                {
                    var routes = this.gMapControl.Markers.OfType<GMapMarker>().Where(x => x.GetType() == typeof(GRoute)).ToList();
                    foreach (GRoute item in routes)
                    {
                        this.gMapControl.Markers.Remove(item);
                    }

                }
            }
        }

        public void AddMarker(GoogleMapSDK.UI.Contract.API.Models.Location location, string overlayId = "defaultoverlay", object tooltip = null)
        {
            IOverlay overlay = _overlayService.AddMarker(location, overlayId, tooltip);
            TryAddOverlay(overlay);
        }

        public void AddMarkers(IEnumerable<GoogleMapSDK.UI.Contract.API.Models.Location> locations, string overlayId = "defaultoverlay", object toolTip = null)
        {
            TryAddOverlay(_overlayService.AddMarkers(locations, overlayId, toolTip));
        }

        public void AddRoute(IEnumerable<GoogleMapSDK.UI.Contract.API.Models.Location> routePoints, string overlayId = "defaultoverlay")
        {
            TryAddOverlay(_overlayService.AddRoute(routePoints, overlayId));
        }

        public void RemoveMarker(GoogleMapSDK.UI.Contract.API.Models.Location location, string overlayId = "defaultoverlay")
        {
            _overlayService.RemoveMarker(location, overlayId);
        }

        public void RemoveRoute(IEnumerable<GoogleMapSDK.UI.Contract.API.Models.Location> routePoints, string overlayId = "defaultoverlay")
        {
            _overlayService.RemoveRoute(routePoints, overlayId);
        }

        public void RemoveOverlay(string overlayId = "defaultoverlay")
        {
            _overlayService.RemoveOverlay(overlayId);
        }

        public void ClearAll(string overlayId = "defaultoverlay")
        {
            _overlayService.ClearAll(overlayId);
        }

        public void ClearMarkers(string overlayId = "defaultoverlay")
        {
            _overlayService.ClearMarkers(overlayId);
        }

        public void ClearRoutes(string overlayId = "defaultoverlay")
        {
            _overlayService.ClearRoutes(overlayId);
        }
    }
}
