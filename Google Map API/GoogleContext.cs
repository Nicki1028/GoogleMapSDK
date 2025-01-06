using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google_Map_API.Direction;
using Google_Map_API.DistanceMatrix;
using Google_Map_API.Geocoding;
using Google_Map_API.Place_Photo;
using Google_Map_API.Places;
using Google_Map_API.Places_Detail;
using Google_Map_API.StaticMaps;
using HttpUtility;

namespace Google_Map_API
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

        public GoogleContext(GoogleSigned googleSigned)
        {
            
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

    }
}
