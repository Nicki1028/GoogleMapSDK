using GoogleMapSDK.API.Places_Detail;
using GoogleMapSDK.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Places_Detail.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WPF.Comment
{
    internal class PlaceReviewItem_WPF:BaseReview_WPF
    {
        GoogleContext context = GoogleContext.InitialGoogleContext();

        public PlaceReviewItem_WPF() { }
        public override Review[] ReviewSource
        {
            set
            {
                this._reviews = value;
                InitializeComponent();
            }
        }
        public async Task<Review[]> GetReviewsAsync(string placeId)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

            return result.result.reviews;

        }
    }
}
