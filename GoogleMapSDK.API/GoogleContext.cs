using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.API.Direction;
using GoogleMapSDK.API.DistanceMatrix;
using GoogleMapSDK.API.Geocoding;
using GoogleMapSDK.API.Place_Photo;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.Places_Detail;
using GoogleMapSDK.API.StaticMaps;
using HttpUtility;

namespace GoogleMapSDK.API
{
    public class GoogleContext
    {
        public GeocodingService Geocoding { get; set; }

        public StaticMapService StaticMap { get; set; }

        public PlacesDetailService PlacesDetail { get; set; }

        public NearbyAndTextServise NearbyAndText { get; set; }

        public PlaceSearchServise PlaceSearch { get; set; }

        public AutoCompleteServise AutoComplete { get; set; }

        public PlacePhotoServise PlacePhoto { get; set; }

        public DirectionService Direction { get; set; }

        public GoogleContext()
        {
            GoogleSigned googleSigned = new GoogleSigned();
            GoogleSigned.AssignAllServices(googleSigned);
            HttpRequest httpRequest = new HttpRequest();
            httpRequest.BaseUrl = "https://maps.google.com/maps/api/";
           
            Geocoding = new GeocodingService(httpRequest);
            StaticMap = new StaticMapService(httpRequest);
            PlacesDetail = new PlacesDetailService(httpRequest);
            NearbyAndText = new NearbyAndTextServise(httpRequest);
            PlaceSearch = new PlaceSearchServise(httpRequest);
            AutoComplete = new AutoCompleteServise(httpRequest);
            PlacePhoto = new PlacePhotoServise();
            Direction = new DirectionService(httpRequest);

        }
        
        public static GoogleContext GetGoogleContext()
        {
            GoogleContext context = new GoogleContext();
            if (context != null)
            {
                return context;
            }
            return null;
        }


    }
}
