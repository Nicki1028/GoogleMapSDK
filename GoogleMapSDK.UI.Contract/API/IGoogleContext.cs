using GoogleMapSDK.UI.Contract.API.Directions;
using GoogleMapSDK.UI.Contract.API.Geocodings;
using GoogleMapSDK.UI.Contract.API.Place_Detail;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.StaticMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.API
{
    public interface IGoogleContext
    {
        IGeocoding Geocoding { get; set; }

        IStaticMap StaticMap { get; set; }

        IPlaceDetail PlaceDetail { get; set; }

        INearbyAndText NearbyAndText { get; set; }

        IPlaceSearch PlacesSearch { get; set; }

        IAutoComplete AutoComplete { get; set; }

        IPlacePhoto PlacePhoto { get; set; }

        IDirection Direction { get; set; }        
    }
}
