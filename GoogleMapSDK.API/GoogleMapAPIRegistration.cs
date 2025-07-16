using GoogleMapSDK.API.Directions;
using GoogleMapSDK.API.DistanceMatrixs;
using GoogleMapSDK.API.Geocodings;
using GoogleMapSDK.API.Place_Photo;
using GoogleMapSDK.API.PlaceDetails;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.StaticMaps;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Directions;
using GoogleMapSDK.UI.Contract.API.DistanceMatrixs;
using GoogleMapSDK.UI.Contract.API.Geocodings;
using GoogleMapSDK.UI.Contract.API.Place_Detail;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.StaticMaps;
using HttpUtility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoogleMapSDK.API
{
    public static class GoogleMapAPIRegistration
    {
        public static void AddGoogleMapAPIRegistration(this IServiceCollection collection,IConfiguration configuration)
        {
            collection.AddSingleton<HttpRequest>(x =>
            {
                HttpRequest httpRequest = new HttpRequest();
                httpRequest.BaseUrl = "https://maps.google.com/maps/api/";
                return httpRequest;
            });
            collection.AddSingleton<IPlaceSearch, PlacesSearch>();
            collection.AddSingleton<INearbyAndText, NearbyAndText>();
            collection.AddSingleton<IAutoComplete, AutoComplete>();
            collection.AddSingleton<IPlacePhoto, PlacePhoto>();
            collection.AddSingleton<IStaticMap, StaticMap>();
            collection.AddSingleton<IPlaceDetail, PlaceDetail>();
            collection.AddSingleton<IGeocoding, Geocoding>();
            collection.AddSingleton<IDistanceMatrix, DistanceMatrix>();
            collection.AddSingleton<IDirection, Direction>();
            collection.AddSingleton<IGoogleContext, GoogleContext>();
            collection.AddSingleton<GoogleAPIConfigure>(x =>
            {
                return new GoogleAPIConfigure(configuration.GetSection("apikey").Value);
            });
            //PlaceRresponse response =IGoogleAPIContext.NearBySearch(parms);
        }
    }
}
