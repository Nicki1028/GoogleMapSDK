using GoogleMapSDK.Core.Utility;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;

namespace GoogleMapSDK.Core.CommentItem
{
    public class PlaceReviewPresenter : IReviewPresenter
    {
        IGoogleContext context = null;
        public PlaceReviewPresenter(IGoogleContext context, IReviewView reviewView)
        {
            this.context = context;
        }

        public async Task<List<T>> GetReviewsAsync<T>(string placeId) where T : ReviewModel
        {
            PlacesDetailRequest placesDetailRequest = new PlacesDetailRequest();
            placesDetailRequest.place_id = placeId;
            var result = await context.PlaceDetail.GetPlaceDetail(placesDetailRequest);


            List<T> data = Mapper.Map<PlacesDetailResponse.Review, T>(result.result.reviews).ToList();

            return data;
        }
    }
}
