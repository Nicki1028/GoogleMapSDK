using GoogleMapSDK.API;
using GoogleMapSDK.API.Places_Detail;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Core;

namespace GoogleMapSDK.UI.WinForm.Components.Comment
{
    internal class PlaceReviewItem : BaseReview
    {
        public PlaceReviewItem() { }
        public override Review[] ReviewSource
        {
            set
            {
                this._reviews = value;
                InitializeComponent();
            }
        }

        GoogleContext context = GoogleContext.InitialGoogleContext();

        public async Task<Review[]> GetReviewsAsync(string placeId)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

            return result.result.reviews;

        }
    }
}
