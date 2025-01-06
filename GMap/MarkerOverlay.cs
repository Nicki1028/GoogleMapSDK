using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gmap
{
    public class MarkerOverlay : MapOverlay
    {
        

        public MarkerOverlay(string nameid)
        {
            this.Id = nameid;   
        }
        public override void Add(double latitude, double longitude, MarkerInfo markerInfo = null)
        {
            Add(new PointLatLng(latitude, longitude), markerInfo);
            
        }
        public override void Add(PointLatLng point, MarkerInfo markerInfo = null)
        {
            var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
           
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.Tag = markerInfo;
            marker.ToolTipText = markerInfo.Name + "\r\n" + markerInfo.Address;
            if (!this.Markers.Any(x => ((MarkerInfo)x.Tag).TextboxId == markerInfo.TextboxId))
            {
                this.Markers.Add(marker);
            }         
            else
            {
                var markerclear = this.Markers.First(x => ((MarkerInfo)x.Tag).TextboxId == markerInfo.TextboxId);
                this.Markers.Remove(markerclear);
                this.Markers.Add(marker);
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
            foreach (var  point in points)
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
