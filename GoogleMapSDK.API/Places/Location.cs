using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Places
{
    public class Location
    {
        private double _latitude;
        private double _longitude;

        public double Latitude
        {
            get { return _latitude; }
        }

        public double Longitude
        {
            get { return _longitude; }
        }
        public Location(double latitude, double longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }

        public Location(float latitude, float longitude)
        {
            this._latitude = Convert.ToDouble(latitude);
            this._longitude = Convert.ToDouble(longitude);
        }


    }
}
