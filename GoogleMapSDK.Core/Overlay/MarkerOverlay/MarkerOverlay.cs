using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.UI.Contract.API.Models;

namespace GoogleMapSDK.Core.Overlay.MarkerOverlay
{
    public class MarkerOverlay : MapOverlay
    {
        public MarkerOverlay(string nameid)
        {
            this.Id = nameid;
        }
        public override void Add(double latitude, double longitude, PlaceInfo markerInfo = null)
        {
            Add(new PointLatLng(latitude, longitude), markerInfo);
            if ( markerInfo == null)
            {
                return;
            }          
        }
        public override void Add(PointLatLng point, PlaceInfo markerInfo = null)
        {
            if (markerInfo != null)
            {
                var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);

                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.Tag = markerInfo;
                marker.ToolTipText = markerInfo.Name + "\r\n" + markerInfo.Address;
                if (!this.Markers.Any(x => ((PlaceInfo)x.Tag).TextboxId == markerInfo.TextboxId))
                {
                    this.Markers.Add(marker);
                }
                else
                {
                    var markerclear = this.Markers.First(x => ((PlaceInfo)x.Tag).TextboxId == markerInfo.TextboxId);
                    this.Markers.Remove(markerclear);
                    this.Markers.Add(marker);
                }
            }
            else
            {
                return;
            }

        }
        public override void AddRange(IEnumerable<(double latitude, double longitude)> markersList)
        {
            foreach (var (latitude, longitude) in markersList)
            {
                Add(latitude, longitude);
            }
        }
        public override void AddRange(IEnumerable<PointLatLng> points)
        {
            foreach (var point in points)
            {
                Add(point);
            }
        }

        public override void Clear()
        {
            this.Markers.Clear();
            Console.WriteLine("所有標記已清除");
        }

        public override MapOverlay GetGMapOverlay()
        {
            return this;
        }
    }
}
