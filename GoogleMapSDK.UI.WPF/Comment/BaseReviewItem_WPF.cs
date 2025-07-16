
using System.Collections.Generic;
using static GoogleMapSDK.UI.Contract.API.Places_Detail.Models.PlacesDetailResponse;

namespace GoogleMapSDK.UI.WPF.Comment
{
    internal class BaseReviewItem_WPF : BaseReview_WPF
    {
        public BaseReviewItem_WPF()
        {

        }

        public override List<Review> ReviewSource
        {
            set
            {
                this._reviews = value;
                InitializeComponent();
            }
        }
    }
}
