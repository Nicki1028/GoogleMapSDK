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
    public class PlaceReviewItem : BaseReview
    {
        GoogleContext context = null;
        public PlaceReviewItem() { 
            this.context = GoogleContext.InitialGoogleContext();
        }
        public override List<Review> ReviewSource
        {
            set
            {
                this._reviews = value;
                InitializeComponent();
            }

        }


        public async Task<List<Review>> GetReviewsAsync(string placeId)
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await context.PlacesDetail.GetPlaceDetail(placesDetailRequest);

            return result.result.reviews.ToList();

        }
    }
}
