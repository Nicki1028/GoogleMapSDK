using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.UI.Contract.API;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;

namespace GoogleMapSDK.UI.WPF.Comment
{
    internal class PlaceReviewItem_WPF:BaseReview_WPF
    {
        private IGoogleContext _googlecontext;
        public PlaceReviewItem_WPF(IGoogleContext googlecontext) 
        { 
            this._googlecontext = googlecontext;
        }
        public override List<Review> ReviewSource
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
            var result = await _googlecontext.PlaceDetail.GetPlaceDetail(placesDetailRequest);

            return result.result.reviews;

        }
    }
}
