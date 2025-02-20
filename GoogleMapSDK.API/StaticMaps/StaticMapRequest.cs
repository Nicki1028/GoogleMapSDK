using GoogleMapSDK.API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoogleMapSDK.API.StaticMaps
{
    public class StaticMapRequest:BaseRequest
    {
        [Required]
        [GoogleMapSDK.API.Attributes.Classtostr("size","x")]
        public Mapsize size { get ; set; }
        public int scale { get; set; }

        [Required]
        public string center { get; set; }
        public int? zoom
        {
            get { return _zoom; }
            set
            {
                if (value != null)
                {
                    if (value < 0) throw new ArgumentOutOfRangeException(string.Format("value cannot be less than {0}.", 0));
                }
                _zoom = value;
            }
        }
        private int? _zoom;
        public EnumImageType format { get; set; }
        public EnumMapType maptype { get; set; }
    }
}
