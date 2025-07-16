using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WinForm.Components.Comment
{
    public class PlaceReviewItem : BaseReview
    {
        IGoogleContext context = null;
        public PlaceReviewItem(IGoogleContext context) { 
            this.context = context; //GoogleContext.InitialGoogleContext();
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
            var result = await context.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            return result.result.reviews.ToList();

        }
    }
}
