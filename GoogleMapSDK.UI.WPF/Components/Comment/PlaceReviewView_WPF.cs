using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.UI.Contract.API;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;
using GoogleMapSDK.UI.Contract.API.Places_Detail.Models;
using GoogleMapSDK.UI.Contract.Models;
using DIContainer;

namespace GoogleMapSDK.UI.WPF.Components.Comment
{
    public class PlaceReviewView_WPF: BaseReview_WPF<ReviewModel>
    {

        public PlaceReviewView_WPF(PresenterFactory presenterFactory) : base(presenterFactory)
        {
        }
      
    }
}
