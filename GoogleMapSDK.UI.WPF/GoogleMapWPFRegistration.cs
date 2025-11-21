using GoogleMapSDK.Core.GoogleMap;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.Comment;
using GoogleMapSDK.UI.WPF.Components.GoogleMap;
using GoogleMapSDK.UI.WPF.Components.Photo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;

namespace GoogleMapSDK.UI.WPF
{
    public static class GoogleMapWPFRegistration
    {
        public static void AddGoogleMapRegistration(this IServiceCollection collection, IConfiguration configuration)
        {

            collection.AddTransient<IAutoCompleteView, PlaceAutoComplete_WPF>();
            collection.AddSingleton<IGoogleMap, GoogleMapControl>();
            collection.AddTransient<IOverlay, MapOverlay>();
            collection.AddTransient<IPhotoView, PlacePhotoView_WPF>();
            collection.AddTransient<IReviewView, PlaceReviewView_WPF>();
        }
    }
}
