using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WinForm.Models
{
    public class MarkerInfo
    {
        public string Name { get; set; }
        public string TextboxId { get; set; }
        public string Address { get; set; }
        public string PlaceId { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
}
