using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions;
using GoogleMapSDK.UI.Contract.API.Geocodings;
using GoogleMapSDK.UI.Contract.API.Place_Detail;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.StaticMaps;
using HttpUtility;

namespace GoogleMapSDK.API
{
    public class GoogleContext: IGoogleContext
    {
        public IGeocoding Geocoding { get; set; }

        public IStaticMap StaticMap { get; set; }

        public IPlaceDetail PlaceDetail { get; set; }

        public INearbyAndText NearbyAndText { get; set; }

        public IPlaceSearch PlacesSearch { get; set; }

        public IAutoComplete AutoComplete { get; set; }

        public IPlacePhoto PlacePhoto { get; set; }

        public IDirection Direction { get; set; }

        private static GoogleContext _context = null;
        public static GoogleContext MapAPIContext => _context;
        public GoogleContext(IGeocoding geocoding, IStaticMap staticMap, IPlaceDetail placeDetail, INearbyAndText nearbyAndText, IPlaceSearch placeSearch, IAutoComplete autoComplete, IPlacePhoto placePhoto, IDirection direction)
        {
             
            this.Geocoding = geocoding;
            this.StaticMap = staticMap;
            this.PlaceDetail = placeDetail;
            this.NearbyAndText = nearbyAndText;
            this.PlacesSearch = placeSearch;
            this.AutoComplete = autoComplete;
            this.PlacePhoto = placePhoto;
            this.Direction = direction;

        }

        //public static GoogleContext InitialGoogleContext()
        //{
            
        //    if (_context != null)
        //    {
        //        return _context;
        //    }
        //    Type type = typeof(GoogleContext);
        //    _context = (GoogleContext)Activator.CreateInstance(type);
        //    return _context;
        //}


    }

}
