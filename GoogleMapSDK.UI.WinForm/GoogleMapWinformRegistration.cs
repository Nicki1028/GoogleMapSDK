using GoogleMapSDK.API.Directions;
using GoogleMapSDK.API.DistanceMatrixs;
using GoogleMapSDK.API.Geocodings;
using GoogleMapSDK.API.Place_Photo;
using GoogleMapSDK.API.PlaceDetails;
using GoogleMapSDK.API.Places;
using GoogleMapSDK.API.StaticMaps;
using GoogleMapSDK.API;
using GoogleMapSDK.UI.Contract.API.Directions;
using GoogleMapSDK.UI.Contract.API.DistanceMatrixs;
using GoogleMapSDK.UI.Contract.API.Geocodings;
using GoogleMapSDK.UI.Contract.API.Place_Detail;
using GoogleMapSDK.UI.Contract.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API.Places;
using GoogleMapSDK.UI.Contract.API.StaticMaps;
using GoogleMapSDK.UI.Contract.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HttpUtility;
using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WinForm
{
    public static class GoogleMapWinformRegistration
    {
        //IServiceCollection collection  = new NickiServiceCollection();
        //collection.AddGoogleMapAPIRegistration();
        public static void AddGoogleMapRegistration(this IServiceCollection collection, IConfiguration configuration)
        {
            
            collection.AddSingleton<IAutoCompleteView, PlaceAutoCompleteView>();
            collection.AddSingleton<IAutoCompleteView, EmployeeAutoCompleteView>();
            
        }
    }
}
