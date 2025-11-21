using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIContainer;
using GoogleMapSDK.Core.CommentItem;
using GoogleMapSDK.UI.Contract.API;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Models;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;
using static GoogleMapSDK.UI.Contract.Components.Comment.ReviewContract;

namespace GoogleMapSDK.UI.WinForm.Components.Comment
{
    public class PlaceReviewView : BaseReview<ReviewModel>
    {
        public PlaceReviewView(PresenterFactory presenterFactory) : base(presenterFactory)
        {
        }
    }
}
