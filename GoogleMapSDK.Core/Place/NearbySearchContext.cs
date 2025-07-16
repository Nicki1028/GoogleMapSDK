using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GoogleMapSDK.API;
using GoogleMapSDK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.Geocodings;
using GoogleMapSDK.UI.Contract.API.StaticMaps;
using GoogleMapSDK.UI.Contract.API.Place_Detail;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Directions;

namespace GoogleMapSDK.Core.Place
{
    public class NearbySearchContext: GoogleContext
    {
        public NearbySearchContext(IGeocoding geocoding, IStaticMap staticMap, IPlaceDetail placeDetail, INearbyAndText nearbyAndText, IPlaceSearch placeSearch, IAutoComplete autoComplete, IPlacePhoto placePhoto, IDirection direction) : base(geocoding, staticMap, placeDetail, nearbyAndText, placeSearch, autoComplete, placePhoto, direction)
        {
        }

        public async Task<List<NearbySearchModel>> NearbySearch(string destination, int radius)
        {
           
            TextSearchRequest textSearchRequest = new TextSearchRequest();
            {
                textSearchRequest.query = destination;
                textSearchRequest.radius = radius;
            };
            var result = await MapAPIContext.NearbyAndText.TextSearch(textSearchRequest);
            var res = result.results.Select(x => new NearbySearchModel
            {
                NearbySearchPoint = new PointLatLng(x.geometry.location.lat, x.geometry.location.lng),
                NearbySearchName = x.name,

            }).ToList();

            return res ;
        }
        
    }
}
