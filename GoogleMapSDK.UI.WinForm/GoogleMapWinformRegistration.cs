using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GoogleMapSDK.UI.WinForm.Components.AutoComplete;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using GoogleMapSDK.UI.WinForm.Components.GoogleMap;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;
using GoogleMapSDK.UI.WinForm.Components.Comment;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;
using GoogleMapSDK.UI.WinForm.Components.Photo;

namespace GoogleMapSDK.UI.WinForm
{
    public static class GoogleMapWinformRegistration
    {
    
        public static void AddGoogleMapWinformRegistration(this IServiceCollection collection, IConfiguration configuration)
        {
            
            collection.AddTransient<IAutoCompleteView, PlaceAutoCompleteView>();
            collection.AddSingleton<IAutoCompleteView, EmployeeAutoCompleteView>();
            collection.AddTransient<IGoogleMap, GoogleMapControl>();
            collection.AddTransient<IOverlay, MapOverlay>();
            collection.AddTransient<IReviewView, PlaceReviewView>();
            collection.AddTransient<IPhotoView, PlacePhotoView>();

        }
    }
}
