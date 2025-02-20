using GoogleMapSDK.API.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Direction
{
    public class DirectionRequest:BaseRequest
    {
        [Required]
        public string destination { get; set; }

        [Required] 
        public string origin { get; set; }

        public bool? alternatives { get; set; }

        public int? arrival_time { get; set; }

        public EnumAvoidType avoid { get; set; }

        public EnumTrafficType mode { get; set; }

        public int? departure_time { get; set; }

        public List<string> waypoints { get; set; }=new List<string>();

        public bool? optimize { get; set; }

        public void Addwaypoint(string waypoint)
        {
            if (waypoint == null) return;
            waypoints.Add(waypoint);

        }



    }
}
