using GoogleMapSDK.Core.AutoComplete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using GoogleMapSDK.API;
using GoogleMapSDK.Core.GoogleMap;
using GoogleMapSDK.UI.Contract.Components.GoogleMap;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;
using GoogleMapSDK.Core.CommentItem;
using static GoogleMapSDK.UI.Contract.Components.Photo.PhotoContract;
using GoogleMapSDK.Core.PhotoItem;

namespace GoogleMapSDK.Core
{
    public static class GoogleMapCoreRegistration
    {
        public static void AddGoogleMapCoreRegistration(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddGoogleMapAPIRegistration(configuration);
            collection.AddSingleton<IAutoCompletePresenter, PlaceAutoCompletePresenter>();
            collection.AddSingleton<IAutoCompletePresenter, EmployeeAutoCompletePresenter>();
            collection.AddSingleton<IOverlayService, OverlayService>();
            collection.AddSingleton<IReviewPresenter, PlaceReviewPresenter>();
            collection.AddSingleton<IPhotoPresenter, PlacePhotoPresenter>();

        }
    }
}
